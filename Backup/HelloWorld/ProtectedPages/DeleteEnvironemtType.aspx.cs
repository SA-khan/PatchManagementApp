using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelloWorld.App_Code;

namespace HelloWorld.ProtectedPages
{
    public partial class DeleteEnvironemtType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DatabaseConnectivity dbcon = new DatabaseConnectivity();
            int envTypeID = Convert.ToInt32(dropEnvType.SelectedValue);
            int res = dbcon.deleteEnvironmentType(envTypeID);
            rowPatchClientName.Visible = false;
            rowSubmit.Visible = false;
            lblSubmission.Visible = true;
            lblSubmission.Text = "Environment Type Query is successfully executed with the Response Code: " + (res == 1 ? "0200 OK" : ( res == -1 ? "0203 NOT OK" : "0500 SERVER ERROR"));
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            dropEnvType.SelectedIndex = 0;
        }
    }
}