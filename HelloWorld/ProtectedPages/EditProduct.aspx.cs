using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using HelloWorld.App_Code;
using System.Data;

namespace HelloWorld.ProtectedPages
{
    public partial class EditProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] != null)
                {
                    _BindService();
                }
                else
                {
                    Response.Redirect("~/Default.aspx", true);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void _BindService()
        {
            DatabaseConnectivity dbcon = new DatabaseConnectivity();
            List<Product> service = dbcon.getProductList();
            if (service.Count > 0 && service != null)
            {
                GridView1.DataSource = service;
                GridView1.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            TextBox txtClientId = DetailsView1.FindControl("txtClientID") as TextBox;
            TextBox txtClientName = DetailsView1.FindControl("txtClientName") as TextBox;
            DropDownList txtClientType = DetailsView1.FindControl("dropClientType") as DropDownList;
            TextBox txtClientDesc = DetailsView1.FindControl("txtClientDesc") as TextBox;
            CheckBox chkClientStill = DetailsView1.FindControl("chkClientStill") as CheckBox;
            TextBox txtPOCName = DetailsView1.FindControl("txtPOCName") as TextBox;
            TextBox txtPOCEmail = DetailsView1.FindControl("txtPOCEmail") as TextBox;
            TextBox txtPOCPhone = DetailsView1.FindControl("txtPOCPhone") as TextBox;
            int ClientID = Convert.ToInt32(txtClientId.Text.ToString());
            string ClientName = txtClientName.Text.ToString();
            string ClientType = txtClientType.SelectedValue.ToString();
            string ClientDesc = txtClientDesc.Text.ToString();
            bool ClientStill = chkClientStill.Checked;
            string ClientPOC = txtPOCName.Text.ToString();
            string ClientPOCEmail = txtPOCEmail.Text.ToString();
            string ClientPOCPhone = txtPOCPhone.Text.ToString();
            Debug.WriteLine("");
            Debug.WriteLine("Data From Grid:");
            Debug.WriteLine("ClientID: " + ClientID);
            Debug.WriteLine("ClientName: " + ClientName);
            Debug.WriteLine("ClientType: " + ClientType);
            Debug.WriteLine("ClientDesc: " + ClientDesc);
            Debug.WriteLine("ClientStill: " + ClientStill);
            Debug.WriteLine("ClientPOC: " + ClientPOC);
            Debug.WriteLine("ClientPOCEmail: " + ClientPOCEmail);
            Debug.WriteLine("ClientPOCPhone: " + ClientPOCPhone);
            DatabaseConnectivity dbcon = new DatabaseConnectivity();
            int ResultQuery = dbcon.setAClient(ClientID, ClientName, ClientType, ClientDesc, ClientStill, ClientPOC, ClientPOCEmail, ClientPOCPhone);
            DetailsView1.Visible = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            DetailsView1.Visible = false;
        }

        protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {

        }

        protected void DetailsView1_DataBound(object sender, EventArgs e)
        {
            HiddenField hidType = DetailsView1.FindControl("hidClientType") as HiddenField;
            DropDownList dropType = DetailsView1.FindControl("dropClientType") as DropDownList;
            dropType.SelectedValue = hidType.Value;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            _BindService();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            _BindService();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridView1.EditIndex = e.NewEditIndex;
                _BindService();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DatabaseConnectivity dbcon = new DatabaseConnectivity();
            String ClientName = GridView1.DataKeys[e.RowIndex].Value.ToString();
            _BindService();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DetailsView1.Visible = true;
            string clientID = (GridView1.SelectedRow.FindControl("lblClientID") as Label).Text;
            string clientName = (GridView1.SelectedRow.FindControl("lblClientName") as Label).Text;
            string clientType = (GridView1.SelectedRow.FindControl("lblClientType") as Label).Text;
            string clientDesc = (GridView1.SelectedRow.FindControl("lblClientDesc") as Label).Text;
            string clientPOCName = (GridView1.SelectedRow.FindControl("lblPOCName") as Label).Text;
            string clientPOCEmail = (GridView1.SelectedRow.FindControl("lblPOCEmail") as Label).Text;
            string clientPOCPhone = (GridView1.SelectedRow.FindControl("lblPOCPhone") as Label).Text;
            Debug.WriteLine(GridView1.SelectedRow.Cells[0].Text);
            Debug.WriteLine(GridView1.SelectedRow.Cells[1].Text);
            Debug.WriteLine(GridView1.SelectedRow.Cells[2].Text);
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[7] { 
                    new DataColumn("ClientID", typeof(string)),
                    new DataColumn("ClientName", typeof(string)),
                    new DataColumn("ClientType", typeof(string)),
                    new DataColumn("ClientDesc",typeof(string)), 
                    new DataColumn("POCName",typeof(string)),
                    new DataColumn("POCEmail",typeof(string)),
                    new DataColumn("POCPhone",typeof(string)) });
            dt.Rows.Add(clientID, clientName, clientType, clientDesc, clientPOCName, clientPOCEmail, clientPOCPhone);
            DetailsView1.DataSource = dt;
            DetailsView1.DataBind();
        }
    }
}