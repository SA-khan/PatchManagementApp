using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelloWorld.App_Code;

namespace HelloWorld
{
    public partial class Default : System.Web.UI.Page
    {
        Log log = new Log();
        protected void Page_Load(object sender, EventArgs e)
        {
            log.DetailLog("Default.aspx.cs", "Page_Load", STATE.INITIALIZED, "Method: Page_Load in Class: Default.aspx.cs has Initialized.");
        }
    }
}