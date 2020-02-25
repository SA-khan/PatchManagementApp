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
    public partial class AddPatch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //if(dropPatchClientName.SelectedIndex != 0)
            
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtPatchTitle.Text = String.Empty;
            txtPatchDesc.Text = String.Empty;
            txtPatchNumber.Text = String.Empty;
            txtPatchDeployedBy.Text = String.Empty;
            checkIsQAPassedYes.Checked = false;
            checkIsQAPassedNo.Checked = false;
            txtPatchDependency.Text = String.Empty;
            dropPatchClientName.SelectedIndex = 0;
            dropProductName.SelectedIndex = 0;
            dropEnvironmentType.SelectedIndex = 0;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string _patchTitle = txtPatchTitle.Text;
            string _patchDesc = txtPatchDesc.Text;
            string _patchNumber = txtPatchNumber.Text;
            string _patchDeployedBy = txtPatchDeployedBy.Text;
            int _patchQATested = checkIsQAPassedYes.Checked == true ? 1 : 0;
            _patchQATested = checkIsQAPassedNo.Checked == true ? 0 : 1;
            string _patchDependency = txtPatchDependency.Text;
            int _patchClientID = Convert.ToInt32(dropPatchClientName.SelectedItem.Value);
            int _patchProductID = Convert.ToInt32(dropProductName.SelectedItem.Value);
            int _patchEnvironmentID = Convert.ToInt32(dropEnvironmentType.SelectedItem.Value);

            Debug.WriteLine("Patch Title: " + _patchTitle);
            Debug.WriteLine("Patch Description: " + _patchDesc);
            Debug.WriteLine("Patch Number: " + _patchNumber);
            Debug.WriteLine("Patch Deployed By: " + _patchDeployedBy);
            Debug.WriteLine("Patch QA Passed " + _patchQATested);
            Debug.WriteLine("Patch Dependency " + _patchDependency);
            Debug.WriteLine("Patch Client ID " + _patchClientID);
            Debug.WriteLine("Patch Product ID: " + _patchProductID);
            Debug.WriteLine("Patch Environment ID: " + _patchEnvironmentID);

            DatabaseConnectivity db = new DatabaseConnectivity();
            int res = db.insertPatch(_patchTitle, _patchDesc, _patchNumber, _patchDeployedBy, DateTime.Now, DateTime.Now, _patchQATested, _patchDependency, _patchClientID, _patchProductID, _patchEnvironmentID);
            Debug.WriteLine("Query Result: " + res);

        }

        protected void DropDownList1_DataBound(object sender, EventArgs e)
        {
            Debug.WriteLine("");
            Debug.WriteLine("Write Here!!!");
        }

        protected void DropDownList1_DataBinding(object sender, EventArgs e)
        {
            //Debug.WriteLine("");
            //Debug.WriteLine("Donot Write Here!!!");
            //string jsMethodName = "<script>alert(1)</script>";
            //ScriptManager.RegisterClientScriptBlock(this, typeof(string), "uniqueKey", jsMethodName, true);
        }

        protected void dropPatchClientName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (dropPatchClientName.SelectedIndex != 0)
                {
                    rowProductName.Visible = true;
                    //dropProductName.Items.Clear();
                    SqlDataSource1.SelectCommand = "SELECT P.ProductID,P.ProductName from (((Environment E Inner Join ClientDetail C on E.ENV_Client_ID = C.ClientID) INNER JOIN Products P On E.ENV_Product_ID = P.ProductID ) INNER JOIN EnvironmentType ET ON ET.EnvID = E.ENV_AppServerEnvironmentType) WHERE C.ClientID = " + dropPatchClientName.SelectedValue.ToString();
                    if (dropProductName.SelectedIndex != 0)
                    {
                        //dropEnvironmentType.Items.Clear();
                        SqlDataSource3.SelectCommand = "SELECT E.ENV_ID As [ENV_ID],ET.EnvTitle As [Env_Title] from (((Environment E Inner Join ClientDetail C on E.ENV_Client_ID = C.ClientID) INNER JOIN Products P On E.ENV_Product_ID = P.ProductID ) INNER JOIN EnvironmentType ET ON ET.EnvID = E.ENV_AppServerEnvironmentType) WHERE C.ClientID = " + dropPatchClientName.SelectedValue.ToString() + " AND P.ProductID = " + dropProductName.SelectedValue.ToString() + ";";
                    }
                }

            }
            catch (Exception) { }
        }

        protected void dropProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                if (dropProductName.SelectedIndex != 0 && dropPatchClientName.SelectedIndex != 0)
                {
                    rowEnvironmentType.Visible = true;
                    //dropProductName.Items.Clear();
                    //SqlDataSource1.SelectCommand = "SELECT P.ProductID,P.ProductName from (((Environment E Inner Join ClientDetail C on E.ENV_Client_ID = C.ClientID) INNER JOIN Products P On E.ENV_Product_ID = P.ProductID ) INNER JOIN EnvironmentType ET ON ET.EnvID = E.ENV_AppServerEnvironmentType) WHERE C.ClientID = " + dropPatchClientName.SelectedValue.ToString();
                    //dropEnvironmentType.Items.Clear();
                    SqlDataSource3.SelectCommand = "SELECT E.ENV_ID As [ENV_ID],ET.EnvTitle As [Env_Title] from (((Environment E Inner Join ClientDetail C on E.ENV_Client_ID = C.ClientID) INNER JOIN Products P On E.ENV_Product_ID = P.ProductID ) INNER JOIN EnvironmentType ET ON ET.EnvID = E.ENV_AppServerEnvironmentType) WHERE C.ClientID = " + dropPatchClientName.SelectedValue.ToString() + " AND P.ProductID = " + dropProductName.SelectedValue.ToString() + ";";
                }
                else {
                    dropEnvironmentType.Items.Clear();
                }
            }
            catch (Exception) { }
        }

        
    }
}