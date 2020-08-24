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
            string _usergroup = dropUserGroup.SelectedValue.ToString();
            string _password = Convert.ToString(System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(txtPasscode.Text.ToString())));
            string _designation = dropUserDesignation.SelectedValue.ToString();
            string _department = dropUserDepartment.SelectedValue.ToString();
            //var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            //return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            if (_username != null)
            {
                Debug.WriteLine("");
                Debug.WriteLine("Username: " + _username);
                Debug.WriteLine("User Group: " + _usergroup);
                Debug.WriteLine("Password: " + _password);
                Debug.WriteLine("Designation: " + _designation);
                Debug.WriteLine("Department: " + _department);
                DatabaseConnectivity dbcon = new DatabaseConnectivity();
                int res = dbcon.insertUser(_username, _usergroup, _password, _designation, _department);
                Debug.WriteLine("Query Status: " + res);
                if (res == 1)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('User has been created.');", true);
                }
                else {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('An error has been occured during saving the record, check your connectivity.');", true);
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
            dropUserGroup.SelectedIndex = 0;
            txtPasscode.Text = "";
            txtRePasscode.Text = "";
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Input Fields have been cleared.');", true);
        }
    }
}