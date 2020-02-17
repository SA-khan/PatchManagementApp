using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelloWorld.App_Code;

namespace HelloWorld.ProtectedPages
{
    public partial class DeleteCompany : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DatabaseConnectivity dbcon = new DatabaseConnectivity();
            int ClientID = Convert.ToInt32(dropPatchClientName.SelectedValue);
            int res = dbcon.deleteAClient(ClientID);
            rowPatchClientName.Visible = false;
            rowSubmit.Visible = false;
            lblSubmission.Visible = true;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            dropPatchClientName.SelectedIndex = 0;
        }
    }
}