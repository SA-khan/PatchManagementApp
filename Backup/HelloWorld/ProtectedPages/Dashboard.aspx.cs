using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelloWorld.App_Code;

namespace HelloWorld.ProtectedPages
{
    public partial class Dashboard : System.Web.UI.Page
    {
        Log log = new Log();
        protected void Page_Load(object sender, EventArgs e)
        {
            log.DetailLog("Dashboard", "Page_Load", STATE.INITIALIZED, "Page_Load Method of Class Dashoard has been initialized.");


        }
    }
}