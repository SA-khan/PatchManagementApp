using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelloWorld.App_Code;

namespace HelloWorld.ProtectedPages
{
    public partial class DeleteUser : System.Web.UI.Page
    {

        DatabaseConnectivity dbcon = new DatabaseConnectivity();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int user = Convert.ToInt32(dropUser.SelectedValue);
            int res = dbcon.deleteUser(user);
            rowUser.Visible = false;
            rowSubmit.Visible = false;
            lblSubmission.Visible = true;
            lblSubmission.Text = "User is successfully deleted. \nResponse Code:" + (res == 1 ? "0200" : "0500");
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            dropUser.SelectedIndex = 0;
        }
    }
}