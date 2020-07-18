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
    public partial class AddCompany : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtClientName.Text = "";
            dropClientType.SelectedIndex = 0;
            txtClientDesc.Text = "";
            txtPOCName.Text = "";
            txtPOCEmail.Text = "";
            txtPOCPhone.Text = "";
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Input Fields have been Cleared.');", true);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "View", "<script>$(function() { alert('Input Fields have been Cleared.'); });</script>", false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string ClientName = txtClientName.Text.ToString();
            string ClientType = dropClientType.SelectedValue.ToString();
            string ClientDescription = txtClientDesc.Text.ToString();
            string POCName = txtPOCName.Text.ToString();
            //string POCName = "";
            string POCEmail = txtPOCEmail.Text.ToString();
            string POCPhone = txtPOCPhone.Text.ToString();
            if (ClientName != null)
            {
                Debug.WriteLine("");
                Debug.WriteLine("Client Name: " + ClientName);
                Debug.WriteLine("Client Type: " + ClientType);
                Debug.WriteLine("Client Description: " + ClientDescription);
                Debug.WriteLine("Client POCName: " + POCName);
                Debug.WriteLine("Client POCEmail: " + POCEmail);
                Debug.WriteLine("Client POCPhone: " + POCPhone);
                DatabaseConnectivity dbcon = new DatabaseConnectivity();
                int res = dbcon.insertClient(ClientName, ClientType, ClientDescription, POCName, POCEmail, POCPhone);
                Debug.WriteLine("Query Status: " + res);
                if (res == 1)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('An Client Has Been Created Successfully.');", true);
                }
                else {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('There Is An Issue Occured, Please Check Your Database Connectivity.');", true);
                }
            }
            else {
                Debug.WriteLine("alert(Please Enter Client Name.)");
            }
        }
    }
}