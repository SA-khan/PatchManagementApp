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
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('New Role Has Been Created.');", true);
                }
                else {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('An Error has occured during the operation of new role creation, Please check your Database Connectivity.');", true);
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
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Input Fields Have Been Cleared.');", true);
        }
    }
}