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
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string _username = txtUserName.Text.ToString();
            string _userrole = dropUserRole.SelectedValue.ToString();
            string _password = Convert.ToString(System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(txtPasscode.Text.ToString())));
            //var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            //return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            if (_username != null)
            {
                Debug.WriteLine("");
                Debug.WriteLine("Username: " + _username);
                Debug.WriteLine("User Role: " + _userrole);
                Debug.WriteLine("Password: " + _password);
                DatabaseConnectivity dbcon = new DatabaseConnectivity();
                int res = dbcon.insertUser(_username, _userrole, _password);
                Debug.WriteLine("Query Status: " + res);
                if (res == 1)
                {
                    lblSubmission.Visible = true;
                    rowUserName.Visible = false;
                    rowUserRole.Visible = false;
                    rowPasscode.Visible = false;
                    rowRePasscode.Visible = false;
                    rowSubmit.Visible = false;
                }
            }
            else
            {
                Debug.WriteLine("alert(Please Enter Product Name.)");
            }

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            dropUserRole.SelectedIndex = 0;
            txtPasscode.Text = "";
            txtRePasscode.Text = "";
        }
    }
}