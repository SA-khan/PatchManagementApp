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
    public partial class AddEnvironmentType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string title = txtEnvironmentTitle.Text.ToString();
            string desc = txtEnvironmentDesc.Text.ToString();
            if (title != null)
            {
                Debug.WriteLine("");
                Debug.WriteLine("Environment Title: " + title);
                Debug.WriteLine("Environment Description: " + desc);
                DatabaseConnectivity dbcon = new DatabaseConnectivity();
                int res = dbcon.insertEnvironmentType(title, desc);
                Debug.WriteLine("Query Status: " + res);
                if (res == 1)
                {
                    lblSubmission.Visible = true;
                    rowEnvironmetTypeTitle.Visible = false;
                    rowEnvironmentTypeDesc.Visible = false;
                    rowSubmit.Visible = false;
                }
            }
            else
            {
                Debug.WriteLine("alert(Please Enter Client Name.)");
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtEnvironmentTitle.Text = "";
            txtEnvironmentDesc.Text = "";
        }
    }
}