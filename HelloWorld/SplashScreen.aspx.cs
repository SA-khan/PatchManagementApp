using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelloWorld.App_Code;
using System.Diagnostics;
using System.IO;

namespace HelloWorld
{
    public partial class SplashScreen : System.Web.UI.Page
    {
        Log log = new Log();
        protected void Page_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("Location: " + Directory.GetCurrentDirectory());
            string messgae = CreateDirectory();
            if (messgae != null)
            {
                Response.Redirect("ErrorPages\\Error500.aspx?Param=SplashScreen.aspx.cs&MethodName=Page_Load", true);
            }
            else
            {
                log.DetailLog("SplashScreen.aspx.cs", "Page_Load", STATE.INITIALIZED, "Method: Page_Load in Class: SplashScreen.aspx.cs has Initialized.");
            }
        }

        public string CreateDirectory() {
            string root = "\\Logs";
            // If directory does not exist, create it. 
            try
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                    Directory.CreateDirectory(root + "\\DetailLogs");
                    Directory.CreateDirectory(root + "\\ErrorLogs");
                }
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally {
                //Response.Redirect("ErrorPages\\Error500.aspx?Param=SplashScreen.aspx.cs&MethodName=Page_Load", true);
            }

        }

    }
}