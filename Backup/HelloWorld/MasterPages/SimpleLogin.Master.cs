using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelloWorld.App_Code;
using System.Diagnostics;

namespace HelloWorld.MasterPages
{
    public partial class SimpleLogin : System.Web.UI.MasterPage
    {
        Log log = new Log();
        DatabaseConnectivity dbcon = new DatabaseConnectivity();
        protected void Page_Load(object sender, EventArgs e)
        {
            log.DetailLog("Login", "Page_Load", STATE.INITIALIZED, "Page_Load Method of Class Login has been initialized.(Login.Master Page)");
            string userID = Session["USR_LOGIN_ID"].ToString();
            string deptID = Session["USR_DEPT_ID"].ToString();
            string desgID = Session["USR_DESIGNATION"].ToString();
            string last_login = Session["USR_LAST_LOGIN_DATE"].ToString();
            string theme = Session["USR_PREF_THEME"].ToString();
            string language = Session["USR_PREF_LANG"].ToString();
            string region = Session["USR_REGION"].ToString();
            Debug.WriteLine("Login With User ID: " + userID);
            lblName.Text = "Welcome " + userID.ToUpper() + "";
            lblDepartment.Text = dbcon.getDepartmentNameByID(deptID);
            log.DetailLog("Login", "Page_Load", STATE.INITIALIZED, "Login with User ID: " + userID);
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {

        }
    }
}