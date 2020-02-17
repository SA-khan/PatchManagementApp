using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelloWorld.App_Code;

namespace HelloWorld.ProtectedPages
{
    public partial class DeleteRelease : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DatabaseConnectivity dbcon = new DatabaseConnectivity();
            string title = txtPatchTitle.Text.ToString();
            string patchNumber = txtPatchNumber.Text.ToString();
            string createdDate = txtPatchCreatedDate.Text.ToString();
            string deployedDate = txtPatchDeployedDate.Text.ToString();
            string clientID = dropPatchClientName.SelectedValue;
            string environment = dropEnvironmentType.SelectedValue;
            string product = dropProductName.SelectedValue;
            int res = dbcon.deleteARelease(title, patchNumber, createdDate, deployedDate, clientID, environment, product);
            rowPatchTitle.Visible = false;
            rowPatchNumber.Visible = false;
            rowPatchCreatedDate.Visible = false;
            rowPatchDeployedDate.Visible = false;
            rowPatchClientName.Visible = false;
            rowEnvironmentType.Visible = false;
            rowProductName.Visible = false;
            rowSubmit.Visible = false;
            lblSubmission.Visible = true;
            
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtPatchTitle.Text = "";
            txtPatchNumber.Text = "";
            txtPatchCreatedDate.Text = "";
            txtPatchDeployedDate.Text = "";
            dropPatchClientName.SelectedIndex = 0;
            dropEnvironmentType.SelectedIndex = 0;
            dropProductName.SelectedIndex = 0;
        }

        protected void DropDownList1_DataBinding(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_DataBound(object sender, EventArgs e)
        {

        }
    }
}