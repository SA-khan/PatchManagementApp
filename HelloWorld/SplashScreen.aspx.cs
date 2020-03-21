using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelloWorld.App_Code;

namespace HelloWorld
{
    public partial class SplashScreen : System.Web.UI.Page
    {
        Log log = new Log();
        protected void Page_Load(object sender, EventArgs e)
        {
            log.DetailLog("SplashScreen.aspx.cs", "Page_Load", STATE.INITIALIZED, "Method: Page_Load in Class: SplashScreen.aspx.cs has Initialized.");
        }
    }
}