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
using System.Security.AccessControl;
using System.Security.Principal;

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
        public string DetailLogPath = "C:\\SHMA_PORTAL_DETAILS\\LOGS\\DetailLogs\\";
        public string ErrorLogPath = System.Environment.CurrentDirectory + "C:\\SHMA_PORTAL_DETAILS\\LOGS\\ErrorLogs\\";
        public bool DetailLog(string className, string methodName, STATE state, string text)
        {
            if (DetailLogs_Location != null)
            {
                bool checkPermission = CheckLocationPermission(DetailLogs_Location);
                if (checkPermission)
                {
                    System.IO.Directory.CreateDirectory(DetailLogs_Location);
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
                        return true;
                    }
                    else
                    {
                        //Response.Write("<script>Directory Not Found..</script>");
                        //throw new System.IO.DirectoryNotFoundException();
                        return false;
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
                    return true;
                }
            }
            else {
                return false;
            }
        }


        public bool ErrorLog(string className, string methodName, ExceptionType ExType, Exception ex)
        {
            #region IF_WEB.CONFIG_ERROR_LOG_LOCATION_IS_DEFINED
            if (ErrorLogs_Location != null)
            {
                bool checkPermission = CheckLocationPermission(ErrorLogs_Location);
                #region IF_PERMISSION_THEN_PRINT
                if (checkPermission)
                {
                    System.IO.Directory.CreateDirectory(ErrorLogs_Location);
                    #region IF_DIR_EXIST_PRINT_LOG
                    if (System.IO.Directory.Exists(ErrorLogs_Location))
                    {
                        #region ERROR_LOG
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
                        #endregion
                        return true;
                    }
                    else
                    {
                        return false;//Response.Write("<script>Directory Not Found..</script>");//throw new System.IO.DirectoryNotFoundException();
                    }
                    #endregion
                }
                else {
                    return false;
                }
                #endregion
            }
            #endregion
            #region ELSE_ERROR_LOG_LOCATION_C_SHMA_PORTAL_LOGS_ERRORLOGS
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
                return true;
            }
            #endregion
        }

        public bool CheckLocationPermission(string path)
        {
            return true;
        }

    }
}