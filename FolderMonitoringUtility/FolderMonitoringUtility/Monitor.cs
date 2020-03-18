using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using System.IO;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace FolderMonitoringUtility
{
    public partial class Monitor : ServiceBase
    {
        private int eventId = 1;
        string fileNameXML;
        List<CustomFolderSettings> listFolders;
        List<FileSystemWatcher> listFileSystemWatcher;

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool SetServiceStatus(System.IntPtr handle, ref ServiceStatus serviceStatus);

        public Monitor(string[] args)
        {
            InitializeComponent();
            try
            {
                string eventSourceName = "SHMAUtility";
                string logName = "SHMAUtilityLogs";

                if (args.Length > 0)
                {
                    eventSourceName = args[0];
                }

                if (args.Length > 1)
                {
                    logName = args[1];
                }

                eventLog1 = new EventLog();

                if (!EventLog.SourceExists(eventSourceName))
                {
                    EventLog.CreateEventSource(eventSourceName, logName);
                }

                eventLog1.Source = eventSourceName;
                eventLog1.Log = logName;

            }
            catch (Exception) { }
        }

        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("In OnStart.",EventLogEntryType.Information);

            // Update the service state to Start Pending.
            ServiceStatus serviceStatus = new ServiceStatus();
            serviceStatus.dwCurrentState = ServiceState.SERVICE_START_PENDING;
            serviceStatus.dwWaitHint = 100000;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);

            Timer timer = new Timer();
            timer.Interval = 60000; // 60 seconds
            timer.Elapsed += new ElapsedEventHandler(this.OnTimer);
            timer.Start();

            // Update the service state to Running.
            serviceStatus.dwCurrentState = ServiceState.SERVICE_RUNNING;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);

            // Initialize the list of FileSystemWatchers based on the XML configuration file
            PopulateListFileSystemWatchers();
            // Start the file system watcher for each of the file specification
            // and folders found on the List<>
            StartFileSystemWatcher();

        }

        public void OnTimer(object sender, ElapsedEventArgs args)
        {
            // TODO: Insert monitoring activities here.
            //eventLog1.WriteEntry("Monitoring the System", EventLogEntryType.Information, eventId++);

            //// Initialize the list of FileSystemWatchers based on the XML configuration file
            //PopulateListFileSystemWatchers();
            //// Start the file system watcher for each of the file specification
            //// and folders found on the List<>
            //StartFileSystemWatcher();

        }

        protected override void OnStop()
        {
            if (listFileSystemWatcher != null)
            {
                foreach (FileSystemWatcher fsw in listFileSystemWatcher)
                {
                    // Stop listening
                    fsw.EnableRaisingEvents = false;
                    // Dispose the Object
                    fsw.Dispose();
                }
                // Clean the list
                listFileSystemWatcher.Clear();
            }

            // Update the service state to Stop Pending.
            ServiceStatus serviceStatus = new ServiceStatus();
            serviceStatus.dwCurrentState = ServiceState.SERVICE_STOP_PENDING;
            serviceStatus.dwWaitHint = 100000;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);

            // Update the service state to Stopped.
            serviceStatus.dwCurrentState = ServiceState.SERVICE_STOPPED;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);

            eventLog1.WriteEntry("In OnStop.",EventLogEntryType.Information);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        protected override void OnContinue()
        {
            eventLog1.WriteEntry("In OnContinue.",EventLogEntryType.Information);
        }

        public enum ServiceState
        {
            SERVICE_STOPPED = 0x00000001,
            SERVICE_START_PENDING = 0x00000002,
            SERVICE_STOP_PENDING = 0x00000003,
            SERVICE_RUNNING = 0x00000004,
            SERVICE_CONTINUE_PENDING = 0x00000005,
            SERVICE_PAUSE_PENDING = 0x00000006,
            SERVICE_PAUSED = 0x00000007,
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ServiceStatus
        {
            public int dwServiceType;
            public ServiceState dwCurrentState;
            public int dwControlsAccepted;
            public int dwWin32ExitCode;
            public int dwServiceSpecificExitCode;
            public int dwCheckPoint;
            public int dwWaitHint;
        };

        /// <summary>Reads an XML file and populates a list of <CustomFolderSettings> </summary>
        private void PopulateListFileSystemWatchers()
        {
            // Get the XML file name from the App.config file
            fileNameXML = ConfigurationManager.AppSettings["XMLFileFolderSettings"];
            // Create an instance of XMLSerializer
            XmlSerializer deserializer =
              new XmlSerializer(typeof(List<CustomFolderSettings>));
            TextReader reader = new StreamReader(fileNameXML);
            object obj = deserializer.Deserialize(reader);
            // Close the TextReader object
            reader.Close();
            // Obtain a list of CustomFolderSettings from XML Input data
            listFolders = obj as List<CustomFolderSettings>;
        }

        /// <summary>Start the file system watcher for each of the file
        /// specification and folders found on the List<>/// </summary>
        private void StartFileSystemWatcher()
        {
            // Creates a new instance of the list
            this.listFileSystemWatcher = new List<FileSystemWatcher>();
            // Loop the list to process each of the folder specifications found
            foreach (CustomFolderSettings customFolder in listFolders)
            {
                DirectoryInfo dir = new DirectoryInfo(customFolder.FolderPath);
                // Checks whether the folder is enabled and
                // also the directory is a valid location
                if (customFolder.FolderEnabled && dir.Exists)
                {
                    // Creates a new instance of FileSystemWatcher
                    FileSystemWatcher fileSWatch = new FileSystemWatcher();
                    // Sets the filter
                    //fileSWatch.Filter = customFolder.FolderFilter;
                    fileSWatch.Filter = "*.*";
                    // Sets the folder location
                    fileSWatch.Path = customFolder.FolderPath;
                    // Sets the action to be executed
                    StringBuilder actionToExecute = new StringBuilder(
                      customFolder.ExecutableFile);
                    // List of arguments
                    StringBuilder actionArguments = new StringBuilder(
                      customFolder.ExecutableArguments);
                    // Subscribe to notify filters
                    fileSWatch.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName |
                      NotifyFilters.DirectoryName;
                    // Associate the event that will be triggered when a new file
                    // is added to the monitored folder, using a lambda expression                   
                    fileSWatch.Created += (senderObj, fileSysArgs) =>
                      fileSWatch_Created(senderObj, fileSysArgs,
                       actionToExecute.ToString(), actionArguments.ToString());
                    // Begin watching
                    fileSWatch.EnableRaisingEvents = true;
                    // Add the systemWatcher to the list
                    listFileSystemWatcher.Add(fileSWatch);
                    // Record a log entry into Windows Event Log
                    eventLog1.WriteEntry(String.Format(
                      "Starting to monitor files with extension ({0}) in the folder ({1})",
                      fileSWatch.Filter, fileSWatch.Path),EventLogEntryType.Information);
                }
            }
        }

        /// <summary>This event is triggered when a file with the specified
        /// extension is created on the monitored folder</summary>
        /// <param name="sender">Object raising the event</param>
        /// <param name="e">List of arguments - FileSystemEventArgs</param>
        /// <param name="action_Exec">The action to be executed upon detecting a change in the File system</param>
        /// <param name="action_Args">arguments to be passed to the executable (action)</param>
        void fileSWatch_Created(object sender, FileSystemEventArgs e,
          string action_Exec, string action_Args)
        {
            string fileName = e.FullPath;
            // Adds the file name to the arguments. The filename will be placed in lieu of {0}
            string newStr = string.Format(action_Args, fileName);
            // Executes the command from the DOS window
            ExecuteCommandLineProcess(action_Exec, newStr);
        }

        /// <summary>Executes a set of instructions through the command window</summary>
        /// <param name="executableFile">Name of the executable file or program</param>
        /// <param name="argumentList">List of arguments</param>
        private void ExecuteCommandLineProcess(string executableFile, string argumentList)
        {
            // Use ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.FileName = executableFile;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = argumentList;
            try
            {
                // Start the process with the info specified
                // Call WaitForExit and then the using-statement will close
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                    // Register a log of the successful operation
                    eventLog1.WriteEntry(string.Format(
                      "Succesful operation --> Executable: {0} --> Arguments: {1}",
                      executableFile, argumentList),EventLogEntryType.Information);

                    string _from = "saad.ahmed@sidathyder.com.pk";
                    string _displayName = ConfigurationManager.AppSettings["EmailIDFromDisplayName"];
                    string _to = ConfigurationManager.AppSettings["EmailTo"];
                    string _subject = ConfigurationManager.AppSettings["EmailSubject"];
                    int findex = argumentList.LastIndexOf("//");
                    int findex1 = argumentList.LastIndexOf('-') + 2;
                    int findex2 = argumentList.LastIndexOf('>') - 1;
                    //int countChar = argumentList.Length;
                    //int countChar1 = countChar - findex1;
                    //DateTime.Now.ToString()
                    //argumentList.Substring(findex, findex2), argumentList.Substring(findex1, findex2)
                    string _body = String.Format("<!DOCTYPE html><html><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" /><title>Email Alert</title><meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\"/></head><body style=\"margin: 0; padding: 0;\"><table border=\"0\" bgcolor=\"#D3D3D3\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\"><tr><td><table align=\"center\" border=\"1\" cellpadding=\"0\" cellspacing=\"0\" width=\"600\"><tr bgcolor=\"#0D47A1\"><td style=\"float:right;border:0\"><span style=\"font-family:tahoma;font-size:12px;color:white;\">{0} &nbsp;</span></td></tr><tr><td align=\"center\" bgcolor=\"#70bbd9\" style=\"padding: 40px 0 30px 0;\"><img src=\"C:/SHMA_ServiceUtility/Images/header.png\" alt=\"Creating Email Magic\" width=\"300\" height=\"230\" style=\"display: block;\" /><h2 style=\"font-family:tahoma;font-size:32px;\">WINDOWS SERVICE ALERT</h2></td></tr><tr><td bgcolor=\"#ffffff\" style=\"padding: 40px 30px 40px 30px;\"><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\"><tr><td><p></p><span style=\"font-size:20px;font-weight:bold;font-family:tahoma;\">Windows Service Utility</span></td></tr><tr><td style=\"padding: 20px 0 30px 0;\"><span style=\"font-family:tahoma;\">The Windows Service Utility alerts fires when a defined location Folder monitoring triggers an event of a file that is newly created in Monitoring Folder location.</span></td></tr><tr><td><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\"><tr><td width=\"260\" valign=\"top\"><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"background-color:#BBDEFB\"><tr><td><img src=\"C:/SHMA_ServiceUtility/Images/h2.png\" alt=\"\" width=\"100%\" height=\"140\" style=\"display: block;\" /></td></tr><tr><td style=\"padding: 25px 0 0 0;align:center;\"><span style=\"font-family:tahoma;font-size:12px;\">Reads the file whenever a user add a file of any type to the monitoring folder.</span></td></tr></table></td><td style=\"font-size: 0; line-height: 0;\" width=\"20\">&nbsp;</td><td width=\"260\" valign=\"top\"><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"background-color:#BBDEFB\"><tr><td><img src=\"C:/SHMA_ServiceUtility/Images/h6.png\" alt=\"\" width=\"100%\" height=\"140\" style=\"display: block;\" /></td></tr><tr><td style=\"padding: 25px 0 0 0;\"><span style=\"font-family:tahoma;font-size:12px;\">Send a notification in the form of email address to the relevant user in case file is created.</span></td></tr></table></td></tr></table></td></tr></table></td></tr><tr bgcolor=\"#E0E0E0\" border=\"0\"><td style=\"align:center;\"><table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"600\"><tr><td align=\"center\" colspan=\"2\" bgcolor=\"#9E9E9E\" style=\"padding: 20px 0 15px 0;\"><span style=\"font-family:tahoma;font-size:20px;\"><i>Alert Information</i></span></td></tr><tr><td align=\"left\" bgcolor=\"#fff\" style=\"padding: 5px 0 5px 0;\"><span style=\"font-family:tahoma;font-size:16px;\">&nbsp;&nbsp;File Name: {1}</span></td></tr><tr><td align=\"left\" bgcolor=\"#E0E0E0\" style=\"padding: 5px 0 5px 0;\"><span style=\"font-family:tahoma;font-size:16px;\">&nbsp;&nbsp;File Location: {2}</span></td></tr><tr><td align=\"left\" bgcolor=\"#fff\" style=\"padding: 5px 0 5px 0;\"><span style=\"font-family:tahoma;font-size:16px;\">&nbsp;&nbsp;Log Creation Location: {3}</span></td></tr><tr><td align=\"left\" bgcolor=\"#E0E0E0\" style=\"padding: 5px 0 5px 0;\"><span style=\"font-family:tahoma;font-size:16px;\">&nbsp;&nbsp;Date and Time: {0}</span></td></tr><tr><td align=\"center\" bgcolor=\"#fff\" style=\"padding: 5px 0 5px 0;\"><span style=\"font-family:tahoma;font-size:16px;font-weight:bold;\">&nbsp;&nbsp;Thank You. </span></td></tr></table></td></tr><tr><td bgcolor=\"#003049\" style=\"padding: 30px 30px 30px 30px;\"><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\"><tr><td><td width=\"75%\"><span style=\"font-family:tahoma;font-size:12px;color:white;\">&reg; Copyright - All Right Reserved - Team of Developers </span></td></td><td><td align=\"right\"><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\"><tr><td><a href=\"http://www.twitter.com/\"><img src=\"C:/SHMA_ServiceUtility/Images/twitter.png\" alt=\"Twitter\" width=\"38\" height=\"38\" style=\"display: block;\" border=\"0\" /></a></td><td style=\"font-size: 0; line-height: 0;\" width=\"20\">&nbsp;</td><td><a href=\"http://www.facebook.com/\"><img src=\"C:/SHMA_ServiceUtility/Images/facebook.png\" alt=\"Facebook\" width=\"38\" height=\"38\" style=\"display: block;\" border=\"0\" /></a></td></tr></table></td></td></tr></table></td></tr></table></td></tr></table></body></html>", DateTime.Now.Day.ToString() + " " + DateTime.Now.Month+ " " + DateTime.Now.Date + ", " + DateTime.Now.Year + " " + DateTime.Now.Hour+":"+DateTime.Now.Minute + " " + DateTime.Now.Kind,argumentList, argumentList, @"C:\SHMA_ServiceUtility\DetailLogs\");
                    //string _body = System.IO.File.ReadAllText("show.html", Encoding.UTF8).Replace("Doe", argumentList.Substring(findex, findex2)).Replace("Moe", argumentList).Replace("Dooley", "E:\"");
                    SmtpClient smtpClient = new SmtpClient();
                    //MailMessage msgMail = new MailMessage(_from, _to, _subject, _body);
                    MailMessage msgMail = new MailMessage();
                    msgMail.IsBodyHtml = true;
                    smtpClient.UseDefaultCredentials = false;
                    msgMail.Body = _body;
                    msgMail.Subject = _subject;
                    msgMail.To.Add(_to);
                    System.Net.Mail.MailAddress m = new System.Net.Mail.MailAddress(_from, _displayName);
                    msgMail.From = m;
                    NEVER_EAT_POISON_Disable_CertificateValidation();
                    string _emailID = ConfigurationManager.AppSettings["EmailIDFrom"];
                    string _emailPassword = ConfigurationManager.AppSettings["PasswordFrom"];
                    smtpClient.Credentials = new NetworkCredential(_emailID, _emailPassword);
                    smtpClient.Send(msgMail);

                }
            }
            catch (Exception exc)
            {
                // Register a Log of the Exception
                eventLog1.WriteEntry(exc.Message, EventLogEntryType.Information);
            }
        }

        //[Obsolete("Do not use this in Production code!!!", true)]
        static void NEVER_EAT_POISON_Disable_CertificateValidation()
        {
            // Disabling certificate validation can expose you to a man-in-the-middle attack
            // which may allow your encrypted message to be read by an attacker
            // https://stackoverflow.com/a/14907718/740639
            ServicePointManager.ServerCertificateValidationCallback =
                delegate(
                    object s,
                    X509Certificate certificate,
                    X509Chain chain,
                    SslPolicyErrors sslPolicyErrors
                )
                {
                    return true;
                };
        }


    }
}
