using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using HelloWorld.App_Code;

namespace HelloWorld.ProtectedPages
{
    public partial class AddUserRole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string title = txtRoleTitle.Text.ToString();
            string desc = txtRoleDesc.Text.ToString();
            if (title != null)
            {
                Debug.WriteLine("");
                Debug.WriteLine("User Role Title: " + title);
                Debug.WriteLine("User Role Description: " + desc);
                DatabaseConnectivity dbcon = new DatabaseConnectivity();
                int res = dbcon.insertUserRole(title, desc);
                Debug.WriteLine("Query Status: " + res);
                if (res == 1)
                {
                    lblSubmission.Visible = true;
                    rowRoleTitle.Visible = false;
                    rowRoleDesc.Visible = false;
                    rowSubmit.Visible = false;
                }
            }
            else
            {
                Debug.WriteLine("alert(Please Enter User Role Title.)");
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtRoleTitle.Text = "";
            txtRoleDesc.Text = "";
        }
    }
}