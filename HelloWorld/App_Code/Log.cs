using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics.Eventing;
using Microsoft.Win32;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Configuration;
using System.Web.Configuration;

namespace HelloWorld.App_Code
{
    public enum STATE { 
        INITIALIZED,
        COMPLETED,
        INTERRUPTED
    }

    public enum ExceptionType { 
        SQLException,
        NullPointerException,
        Exception
    }

    public class Log
    {
        string ErrorLogs_Location = WebConfigurationManager.AppSettings["ErrorLogs_Location"];
        string DetailLogs_Location = WebConfigurationManager.AppSettings["DetailLogs_Location"];
        public string DetailLogPath = "E:\\Logs\\DetailLogs\\";
        public string ErrorLogPath = System.Environment.CurrentDirectory+"E:\\Logs\\ErrorLogs\\";
        public void DetailLog(string className, string methodName, STATE state, string text)
        {
            if (DetailLogs_Location != null)
            {
                if (System.IO.Directory.Exists(DetailLogs_Location))
                {
                    System.IO.File.AppendAllText(DetailLogs_Location + DateTime.Now.Year.ToString() + "-" +
                        DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + "_" +
                        DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + ".txt",
                        DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" +
                        DateTime.Now.Day.ToString() + " " + DateTime.Now.Hour.ToString() + ":" +
                        DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + ":" +
                        DateTime.Now.Millisecond.ToString() + @" | Class: " + className + @" |
                                                           Method: " + methodName + "" + @" |
                                                           State:  " + state + @" |
                                                           Domain: " + System.Environment.UserDomainName + @" |
                                                           Machine Name: " + System.Environment.MachineName + @" |
                                                           Username: " + System.Environment.UserName + @" |
                                                           OS Version: " + System.Environment.OSVersion + @" |
                                                           O.S 64-Bit: " + System.Environment.Is64BitOperatingSystem + @" |
                                                           Physical Memory: " + System.Environment.WorkingSet + @" |
                                                           Directory Location: " + System.Environment.CurrentDirectory + @" |
                                                           System Started Tick: " + System.Environment.TickCount + @" |
                                                           Description: " + text + ". \n" + System.Environment.NewLine);
                }
                else {
                    //Response.Write("<script>Directory Not Found..</script>");
                    throw new  System.IO.DirectoryNotFoundException();
                }
            }
            else
            {
                //Debug.WriteLine("Log Location: " + System.Environment.CurrentDirectory);
                System.IO.File.AppendAllText(DetailLogPath + DateTime.Now.Year.ToString() + "-" +
                    DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + "_" +
                    DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + ".txt",
                    DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" +
                    DateTime.Now.Day.ToString() + " " + DateTime.Now.Hour.ToString() + ":" +
                    DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + ":" +
                    DateTime.Now.Millisecond.ToString() + @" | Class: " + className + @" |
                                                           Method: " + methodName + "" + @" |
                                                           State:  " + state + @" |
                                                           Domain: " + System.Environment.UserDomainName + @" |
                                                           Machine Name: " + System.Environment.MachineName + @" |
                                                           Username: " + System.Environment.UserName + @" |
                                                           OS Version: " + System.Environment.OSVersion + @" |
                                                           O.S 64-Bit: " + System.Environment.Is64BitOperatingSystem + @" |
                                                           Physical Memory: " + System.Environment.WorkingSet + @" |
                                                           Directory Location: " + System.Environment.CurrentDirectory + @" |
                                                           System Started Tick: " + System.Environment.TickCount + @" |
                                                           Description: " + text + ". \n" + System.Environment.NewLine);
            }
        }


        public void ErrorLog(string className, string methodName, ExceptionType ExType, Exception ex)
        {
            if (ErrorLogs_Location != null)
            {
                if (System.IO.Directory.Exists(ErrorLogs_Location))
                {
                System.IO.File.AppendAllText(ErrorLogs_Location + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" +
                    DateTime.Now.Day.ToString() + "_" + DateTime.Now.Hour.ToString() + "-" +
                    DateTime.Now.Minute.ToString() + ".txt", DateTime.Now.Year.ToString() + "/" +
                    DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + " " +
                    DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" +
                    DateTime.Now.Second.ToString() + ":" + DateTime.Now.Millisecond.ToString() + " | Class: " + className + @" |
                                                                                                     Method: " + methodName + "" + @" |
                                                                                                     State: Interrupted" + @" |
                                                                                                     Domain: " + System.Environment.UserDomainName + @" |
                                                                                                     Machine Name: " + System.Environment.MachineName + @" |
                                                                                                     Username: " + System.Environment.UserName + @" |
                                                                                                     OS Version: " + System.Environment.OSVersion + @" |
                                                                                                     O.S 64-Bit: " + System.Environment.Is64BitOperatingSystem + @" |
                                                                                                     Physical Memory: " + System.Environment.WorkingSet + @" |
                                                                                                     Directory Location: " + System.Environment.CurrentDirectory + @" |
                                                                                                     System Started Tick: " + System.Environment.TickCount + @" |
                                                                                                     " + ExType + ": " + ex.Source + @"\n
                                                                                                     Exception Description: " + ex.Message + ". \n" + System.Environment.NewLine);
                }
                else
                {
                    //Response.Write("<script>Directory Not Found..</script>");
                    throw new System.IO.DirectoryNotFoundException();
                }
            }
            else
            {
                System.IO.File.AppendAllText(ErrorLogPath + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" +
                    DateTime.Now.Day.ToString() + "_" + DateTime.Now.Hour.ToString() + "-" +
                    DateTime.Now.Minute.ToString() + ".txt", DateTime.Now.Year.ToString() + "/" +
                    DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + " " +
                    DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" +
                    DateTime.Now.Second.ToString() + ":" + DateTime.Now.Millisecond.ToString() + " | Class: " + className + @" |
                                                                                                     Method: " + methodName + "" + @" |
                                                                                                     State: Interrupted" + @" |
                                                                                                     Domain: " + System.Environment.UserDomainName + @" |
                                                                                                     Machine Name: " + System.Environment.MachineName + @" |
                                                                                                     Username: " + System.Environment.UserName + @" |
                                                                                                     OS Version: " + System.Environment.OSVersion + @" |
                                                                                                     O.S 64-Bit: " + System.Environment.Is64BitOperatingSystem + @" |
                                                                                                     Physical Memory: " + System.Environment.WorkingSet + @" |
                                                                                                     Directory Location: " + System.Environment.CurrentDirectory + @" |
                                                                                                     System Started Tick: " + System.Environment.TickCount + @" |
                                                                                                     " + ExType + ": " + ex.Source + @"\n
                                                                                                     Exception Description: " + ex.Message + ". \n" + System.Environment.NewLine);
            }
        }
    }
}