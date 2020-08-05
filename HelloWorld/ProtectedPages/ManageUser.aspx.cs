using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelloWorld.App_Code;
using System.Diagnostics;

namespace HelloWorld.ProtectedPages
{
    public partial class ManageUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["USR_LOGIN_ID"] != null)
                {
                    _BindService();
                }
                else
                {
                    Response.Redirect("~/Default.aspx", true);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void _BindService()
        {
            DatabaseConnectivity dbcon = new DatabaseConnectivity();
            List<User> service = dbcon.getUserList();
            if (service.Count > 0 && service != null)
            {
                GridView1.DataSource = service;
                GridView1.DataBind();
            }
        }
    }
}