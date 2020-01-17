using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace HelloWorld.ProtectedPages
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["UserID"] != null) // && Request.Cookies["Password"] != null
            {
                //String[] cookies = Request.Cookies.AllKeys;
                String userid = Request.Cookies.Get("UserID").Value;
                String password = Request.Cookies.Get("Password").Value;
                Debug.WriteLine("User Loggedin with UserID: " + userid + " and Pwd: " + password);
            }
            //if()
            //try
            //{
            //    if (Session["UserID"] != null)
            //    {
            //        lblUser.Text = "Hi " + Session["UserID"];
            //    }
            //    else
            //    {
            //        Response.Redirect("~/Default.aspx", true);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(ex.Message);
            //}
        }
    }
}