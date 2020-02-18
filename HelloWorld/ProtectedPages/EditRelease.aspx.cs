using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelloWorld.App_Code;
using System.Diagnostics;
using System.Data;

namespace HelloWorld.ProtectedPages
{
    public partial class EditEnvironemtInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] != null)
                {
                    _BindService();
                    //lblUser.Text = "Hi " + Session["UserID"];
                    //DatabaseConnectivity dbcon = new DatabaseConnectivity();
                    //List<Patch> service = dbcon.getAllUpdatedClientPatches(1, 1);
                    //if (service.Count > 0 && service != null)
                    //{
                    //    GridView1.DataSource = service;
                    //    GridView1.DataBind();
                    //}
                    //else
                    //{
                    //    Response.Redirect("~/Default.aspx", true);
                    //}
                }
                else {
                    Response.Redirect("~/Default.aspx", true);
                }

            }
            catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            if (dropProduct.SelectedIndex != 0 && dropEnvironment.SelectedIndex != 0)
            {
                DetailsView1.Visible = true;
                try
                {
                    GridView1.EditIndex = e.NewEditIndex;
                    _BindService();
                    Debug.WriteLine(e.NewEditIndex);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else {
                Panel1.GroupingText = "Select Product / Environment.";
            }
        }

        private void _BindService()
        {
            DatabaseConnectivity dbcon = new DatabaseConnectivity();
            List<Patch> service = dbcon.getAllUpdatedClientPatches(Convert.ToInt32(dropProduct.SelectedValue), Convert.ToInt32(dropEnvironment.SelectedValue));
            if (service.Count > 0 && service != null)
            {
                GridView1.DataSource = service;
                GridView1.DataBind();
            } 
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //if (!Page.IsPostBack)
            //{
                DatabaseConnectivity dbcon = new DatabaseConnectivity();
                String ClientName = GridView1.DataKeys[e.RowIndex].Value.ToString();
                int queryResult = dbcon.updateClientPatches2(dbcon.getClientId(ClientName), Convert.ToInt32(dropProduct.SelectedValue), Convert.ToInt32(dropEnvironment.SelectedValue));
                //int userid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
                //GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
                //Label lblID = (Label)row.FindControl("lblClientName");
                ////TextBox txtname=(TextBox)gr.cell[].control[];  
                //TextBox textName = (TextBox)row.Cells[0].Controls[0];
                //TextBox textadd = (TextBox)row.Cells[1].Controls[0];
                //TextBox textc = (TextBox)row.Cells[2].Controls[0];
                ////TextBox textadd = (TextBox)row.FindControl("txtadd");  
                ////TextBox textc = (TextBox)row.FindControl("txtc");  
                //GridView1.EditIndex = -1;
                Debug.WriteLine("Query Result: " + queryResult);
                //Debug.WriteLine(textName.Text + "\n" + textadd.Text + "\n" + textc.Text + "\n");
                //conn.Open();
                ////SqlCommand cmd = new SqlCommand("SELECT * FROM detail", conn);  
                //SqlCommand cmd = new SqlCommand("update detail set name='" + textName.Text + "',address='" + textadd.Text + "',country='" + textc.Text + "'where id='" + userid + "'", conn);
                //cmd.ExecuteNonQuery();
                //conn.Close();
                //gvbind();
           // }
                _BindService();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DetailsView1.Visible = true;
            GridView1.PageIndex = e.NewPageIndex;
            _BindService();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            _BindService();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string nullDataChecker = (GridView1.SelectedRow.FindControl("lblPatchDeployed") as Label).Text;
            if (dropProduct.SelectedIndex != 0 && dropEnvironment.SelectedIndex != 0)
            {
                DetailsView1.Visible = true;
                string clientName = (GridView1.SelectedRow.FindControl("lblClientName") as Label).Text;
                string clientType = (GridView1.SelectedRow.FindControl("lblClientType") as Label).Text;
                string totalPatches = (GridView1.SelectedRow.FindControl("lblTotalPatches") as Label).Text;
                string latestPatch = (GridView1.SelectedRow.FindControl("lblLatestPatch") as Label).Text;
                string patchDeployedBy = (GridView1.SelectedRow.FindControl("lblPatchDeployedBy") as Label).Text;
                string patchCreatedDate = (GridView1.SelectedRow.FindControl("lblPatchCreatedDate") as Label).Text;
                string patchDeployedDate = (GridView1.SelectedRow.FindControl("lblPatchDeployed") as Label).Text;
                string patchStatus = (GridView1.SelectedRow.FindControl("lblPatchStatus") as Label).Text;
                Debug.WriteLine(GridView1.SelectedRow.Cells[0].Text);
                Debug.WriteLine(GridView1.SelectedRow.Cells[1].Text);
                Debug.WriteLine(GridView1.SelectedRow.Cells[2].Text);
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[8] { new DataColumn("ClientName", typeof(string)),
                    new DataColumn("ClientType", typeof(string)),
                    new DataColumn("TotalPatches",typeof(string)), 
                    new DataColumn("LatestHotPatch",typeof(string)),
                    new DataColumn("PatchDeployedBy",typeof(string)),
                    new DataColumn("PatchCreatedDate",typeof(string)),
                    new DataColumn("PatchDeployedDate",typeof(string)),
                    new DataColumn("PatchStatus",typeof(string)) });
                dt.Rows.Add(clientName, clientType, totalPatches, latestPatch, patchDeployedBy, patchCreatedDate, patchDeployedDate, patchStatus);
                //DetailsView1.m
                DetailsView1.DataSource = dt;
                DetailsView1.DataBind();
                //.Attributes["accordionView"] = "hidden";
                //DetailsView1.Attributes.Add("style", "display:block");
            }
            else {
                Panel1.GroupingText = "Please select Product / Environment.";
            }
        }

        protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {
            Debug.WriteLine("Index");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Index");
            DatabaseConnectivity dbcon = new DatabaseConnectivity();
            string title = "Demo Title Manual";
            string desc = "Demo desc Manual";
            TextBox txtpatchNumber = DetailsView1.FindControl("txtPatchHotNumber") as TextBox;
            TextBox txtDeployedBy = DetailsView1.FindControl("txtPatchDeployedBy") as TextBox;
            TextBox txtCreatedDate = DetailsView1.FindControl("txtPatchCreatedDate") as TextBox;
            TextBox txtDeployedDate = DetailsView1.FindControl("txtPatchDeployedDate") as TextBox;
            TextBox txtStatus = DetailsView1.FindControl("txtPatchStatus") as TextBox;
            TextBox txtClient = DetailsView1.FindControl("lblClientName") as TextBox;
            int clientID = dbcon.getClientId(txtClient.Text);
            string patchNumber = txtpatchNumber.Text.ToString();
            string deployedBy = txtDeployedBy.Text.ToString();
            string createdDate = txtCreatedDate.Text.ToString();
            string deployedDate = txtDeployedDate.Text.ToString();
            string status = txtStatus.Text.ToString();
            int productID = Convert.ToInt32(dropProduct.SelectedValue);
            int envType = Convert.ToInt32(dropEnvironment.SelectedValue);
            int res = dbcon.updatePatcheManually(title, desc, patchNumber, deployedBy, createdDate, deployedDate, status, clientID, productID, envType);
            DetailsView1.Visible = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //DetailsView1.Attributes.Add("style", "display:none");
            //DetailsView1.Attributes.Add("style", "visible:false");
            Debug.WriteLine("NotIndex");
            DetailsView1.Visible = false;
            //DetailsView1.Style.Add("Display", "none");
            //DetailsView1.FindControl("lblClientName").Visible = false;
            //UpdatePanel1.Update();
        }

        protected void DetailsView1_DataBound(object sender, EventArgs e)
        {
            //Button lb = e.Equals("btnCancel") as Button;
            //ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(lb);
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            //Label nullValueWatcher = GridView1.FindControl("lblPatchDeployed") as Label;
            //string nullValue = nullValueWatcher.Text;
            //if (nullValue == "") {
            //    Debug.WriteLine("Bee");
            //}
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                Label nullValueWatcher = e.Row.FindControl("lblPatchDeployed") as Label;
                Label nonnullValueWatcher = e.Row.FindControl("lblTotalPatches") as Label;
                LinkButton selectlink = e.Row.FindControl("LnkSelect") as LinkButton;
                LinkButton updatelink = e.Row.FindControl("LnkEdit") as LinkButton;
                string nullValue = nullValueWatcher.Text;
                Debug.WriteLine("lblPatchDeployed: " + nullValue);
                if (nullValue == "")
                {
                    //Debug.WriteLine("Bee");
                    nonnullValueWatcher.Text = "";
                    selectlink.Visible = false;
                    updatelink.Visible = false;
                }
            }
            catch (Exception ex) {
                Debug.WriteLine("Exception: " + ex.Message);
            }
        }



    }
}