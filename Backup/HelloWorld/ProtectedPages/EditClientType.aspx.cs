using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelloWorld.App_Code;
using System.Data;
using System.Diagnostics;

namespace HelloWorld.ProtectedPages
{
    public partial class EditClientType : System.Web.UI.Page
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            TextBox txtCTypeId = DetailsView1.FindControl("txtClientTypeID") as TextBox;
            TextBox txtCTypeTitle = DetailsView1.FindControl("txtClientTypeTitle") as TextBox;
            TextBox txtCTypeDesc = DetailsView1.FindControl("txtClientTypeDesc") as TextBox;
            int CTypeId = Convert.ToInt32(txtCTypeId.Text.ToString());
            string CTypeTitle = txtCTypeTitle.Text.ToString();
            string CTypeDesc = txtCTypeDesc.Text.ToString();
            Debug.WriteLine("");
            Debug.WriteLine("Data From Grid:");
            Debug.WriteLine("CType ID: " + CTypeId);
            Debug.WriteLine("CType Title: " + CTypeTitle);
            Debug.WriteLine("CType Desc: " + CTypeDesc);
            DatabaseConnectivity dbcon = new DatabaseConnectivity();
            int ResultQuery = dbcon.setClientType(CTypeId, CTypeTitle, CTypeDesc);
            //Console.WriteLine("<script>alert(" + ResultQuery + "record has been updated." + ")</script>");
            //ClientScript.RegisterStartupScript(this.GetType(), DateTime.Now.ToString(), "<script>alert(" + ResultQuery + "record has been updated." + ")</script>", true);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString(), "<script>alert(" + ResultQuery +")</script>", true);
            DetailsView1.Visible = false;
            //this.Page_Load(null, null);
            _BindService();
            //UpdatePanel1.Update();
            //UpdatePanel1.Update();
            //DetailsView1.Style.Add("display", "none");
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
            //HiddenField hidType = DetailsView1.FindControl("hidClientType") as HiddenField;
            //DropDownList dropType = DetailsView1.FindControl("dropClientType") as DropDownList;
            //dropType.SelectedValue = hidType.Value;
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
                //Debug.WriteLine(e.NewEditIndex);
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //if (!Page.IsPostBack)
            //{
            DatabaseConnectivity dbcon = new DatabaseConnectivity();
            String ClientName = GridView1.DataKeys[e.RowIndex].Value.ToString();
            //int queryResult = dbcon.updateClientPatches2(dbcon.get);
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
            //Debug.WriteLine("Query Result: " + queryResult);
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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DetailsView1.Visible = true;
            //DetailsView1.Style.Add("display", "block");
            string clientTypeID = (GridView1.SelectedRow.FindControl("lblCTypeID") as Label).Text;
            string clientTypeTitle = (GridView1.SelectedRow.FindControl("lblCTypeTitle") as Label).Text;
            string clientTypeDesc = (GridView1.SelectedRow.FindControl("lblCTypeDesc") as Label).Text;
            Debug.WriteLine(GridView1.SelectedRow.Cells[0].Text);
            Debug.WriteLine(GridView1.SelectedRow.Cells[1].Text);
            Debug.WriteLine(GridView1.SelectedRow.Cells[2].Text);
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { 
                    new DataColumn("ClientTypeID", typeof(string)),
                    new DataColumn("ClientTypeTitle", typeof(string)),
                    new DataColumn("ClientTypeDesc",typeof(string)) });
            dt.Rows.Add(clientTypeID, clientTypeTitle, clientTypeDesc);
            //DetailsView1.m
            DetailsView1.DataSource = dt;
            DetailsView1.DataBind();
            //.Attributes["accordionView"] = "hidden";
            //DetailsView1.Attributes.Add("style", "display:block");
        }

        private void _BindService()
        {
            DatabaseConnectivity dbcon = new DatabaseConnectivity();
            List<ClientType> service = dbcon.getClientType();
            if (service.Count > 0 && service != null)
            {
                GridView1.DataSource = service;
                GridView1.DataBind();
            }
        }

    }
}