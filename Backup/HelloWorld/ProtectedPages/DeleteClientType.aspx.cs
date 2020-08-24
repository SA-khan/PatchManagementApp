using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelloWorld.App_Code;

namespace HelloWorld.ProtectedPages
{
    public partial class DeleteClientType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DatabaseConnectivity dbcon = new DatabaseConnectivity();
            int clientType = Convert.ToInt32(dropClientType.SelectedValue);
            int res = dbcon.deleteClientType(clientType);
            rowClientType.Visible = false;
            rowSubmit.Visible = false;
            lblSubmission.Visible = true;
            lblSubmission.Text = "Delete User Role Query is successfully executed with the Response Code: " + (res == 1 ? "0200 OK" : (res == -1 ? "0203 NOT OK" : "0500 SERVER ERROR"));
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            dropClientType.SelectedIndex = 0;
        }
    }
}