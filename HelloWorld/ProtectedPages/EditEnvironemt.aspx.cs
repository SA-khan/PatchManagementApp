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
    public partial class EditClientEnvironemt : System.Web.UI.Page
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

        private void _BindService()
        {
            DatabaseConnectivity dbcon = new DatabaseConnectivity();
            List<HelloWorld.App_Code.Environment> service = dbcon.getAllEnvironments();
            if (service.Count > 0 && service != null)
            {
                GridView1.DataSource = service;
                GridView1.DataBind();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DetailsView1.Visible = true;
            //DetailsView1.Style.Add("display", "block");
            string envID = (GridView1.SelectedRow.FindControl("lblEnvID") as Label).Text;
            string clientName = (GridView1.SelectedRow.FindControl("lblClientName") as Label).Text;
            string productName = (GridView1.SelectedRow.FindControl("lblProductName") as Label).Text;
            string AppServerEnvType = (GridView1.SelectedRow.FindControl("lblEnvironmentAppServerEnvType") as Label).Text;
            string DBServerEnvType = (GridView1.SelectedRow.FindControl("lblEnvironmentDBServerEnvType") as Label).Text;
            string AppServerName = (GridView1.SelectedRow.FindControl("lblEnvironmentAppServerName") as Label).Text;
            string AppServerOS = (GridView1.SelectedRow.FindControl("lblEnvironmentAppServerOS") as Label).Text;
            string AppServerOSBuild = (GridView1.SelectedRow.FindControl("lblEnvironmentAppServerOSBuild") as Label).Text;
            string AppServerIsX86Version = (GridView1.SelectedRow.FindControl("lblEnvironmentAppServerIsX86Version") as Label).Text;
            string AppServerIsVirtual = (GridView1.SelectedRow.FindControl("lblEnvironmentAppServerIsVirtual") as Label).Text;
            string AppServerProcessor = (GridView1.SelectedRow.FindControl("lblEnvironmentAppServerProcessor") as Label).Text;
            string AppServerMemory = (GridView1.SelectedRow.FindControl("lblEnvironmentAppServerMemory") as Label).Text;
            string AppServerWebBrowser = (GridView1.SelectedRow.FindControl("lblEnvironmentAppServerWebBrowser") as Label).Text;
            string AppServerWebBrowserVersion = (GridView1.SelectedRow.FindControl("lblEnvironmentAppServerWebBrowserVersion") as Label).Text;
            string AppServerWorkingDirectoryLocation = (GridView1.SelectedRow.FindControl("lblEnvironmentAppServerWorkingDirectoryLocation") as Label).Text;
            string AppHyperLink = (GridView1.SelectedRow.FindControl("lblEnvironmentAppHyperLink") as Label).Text;
            string AppServerIP = (GridView1.SelectedRow.FindControl("lblEnvironmentAppServerIP") as Label).Text;
            string AppServerPort = (GridView1.SelectedRow.FindControl("lblEnvironmentAppServerPort") as Label).Text;
            string AppServerDependency = (GridView1.SelectedRow.FindControl("lblEnvironmentAppServerDependency") as Label).Text;
            //-----------------------------------------------------------------------------------------------
            string DBServerName = (GridView1.SelectedRow.FindControl("lblEnvironmentDBServerName") as Label).Text;
            string DBServerIsX86Version = (GridView1.SelectedRow.FindControl("lblEnvironmentDBServerIsX86Version") as Label).Text;
            string DBServerIsVirtual = (GridView1.SelectedRow.FindControl("lblEnvironmentDBServerIsVirtual") as Label).Text;
            string DBServerMemory = (GridView1.SelectedRow.FindControl("lblEnvironmentDBServerMemory") as Label).Text;
            string DBServerProcessor = (GridView1.SelectedRow.FindControl("lblEnvironmentDBServerProcessor") as Label).Text;
            string DBServerOS = (GridView1.SelectedRow.FindControl("lblEnvironmentDBServerOS") as Label).Text;
            string DBServerOSBuild = (GridView1.SelectedRow.FindControl("lblEnvironmentDBServerOSBuild") as Label).Text;
            string DBServerDirectoryLocation = (GridView1.SelectedRow.FindControl("lblEnvironmentDBServerDirectoryLocation") as Label).Text;
            string DBMDFFileLocation = (GridView1.SelectedRow.FindControl("lblEnvironmentDBMDFFileLocation") as Label).Text;
            string DBMDFFileSize = (GridView1.SelectedRow.FindControl("lblEnvironmentDBMDFFileSize") as Label).Text;
            string DBLDFFileLocation = (GridView1.SelectedRow.FindControl("lblEnvironmentDBLDFFileLocation") as Label).Text;
            string DBLDFFileSize = (GridView1.SelectedRow.FindControl("lblEnvironmentDBLDFFileSize") as Label).Text;
            string DBServerIP = (GridView1.SelectedRow.FindControl("lblEnvironmentEnvDBServerIP") as Label).Text;
            string DBServerPort = (GridView1.SelectedRow.FindControl("lblEnvironmentDBServerPort") as Label).Text;
            string DBServerDependency = (GridView1.SelectedRow.FindControl("lblEnvironmentDBServerDependency") as Label).Text;

            Debug.WriteLine(GridView1.SelectedRow.Cells[0].Text);
            Debug.WriteLine(GridView1.SelectedRow.Cells[1].Text);
            Debug.WriteLine(GridView1.SelectedRow.Cells[2].Text);
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[34] { 
                    new DataColumn("EnvironmentID", typeof(string)),
                    new DataColumn("ClientName", typeof(string)),
                    new DataColumn("ProductName", typeof(string)),
                    new DataColumn("AppServerEnvType",typeof(string)), 
                    new DataColumn("DBServerEnvType",typeof(string)),
                    new DataColumn("AppServerName",typeof(string)),
                    new DataColumn("AppServerOS",typeof(string)),
                    new DataColumn("AppServerOSBuild", typeof(string)),
                    new DataColumn("AppServerIsX86Version", typeof(string)),
                    new DataColumn("AppServerIsVirtual", typeof(string)),
                    new DataColumn("AppServerProcessor",typeof(string)), 
                    new DataColumn("AppServerMemory",typeof(string)),
                    new DataColumn("AppServerWebBrowser",typeof(string)),
                    new DataColumn("AppServerWebBrowserVersion",typeof(string)),
                    new DataColumn("AppServerWorkingDirectoryLocation", typeof(string)),
                    new DataColumn("AppHyperLink", typeof(string)),
                    new DataColumn("AppServerIP", typeof(string)),
                    new DataColumn("AppServerPort",typeof(string)), 
                    new DataColumn("AppServerDependency",typeof(string)),
                    new DataColumn("DBServerName",typeof(string)),
                    new DataColumn("DBServerIsX86Version",typeof(string)),
                    new DataColumn("DBServerIsVirtual", typeof(string)),
                    new DataColumn("DBServerMemory", typeof(string)),
                    new DataColumn("DBServerProcessor", typeof(string)),
                    new DataColumn("DBServerOS",typeof(string)), 
                    new DataColumn("DBServerOSBuild",typeof(string)),
                    new DataColumn("DBServerDirectoryLocation",typeof(string)),
                    new DataColumn("DBMDFFileLocation",typeof(string)),
                    new DataColumn("DBMDFFileSize", typeof(string)),
                    new DataColumn("DBLDFFileLocation",typeof(string)), 
                    new DataColumn("DBLDFFileSize",typeof(string)),
                    new DataColumn("DBServerIP",typeof(string)),
                    new DataColumn("DBServerPort",typeof(string)),
                    new DataColumn("DBServerDependency",typeof(string)) });
            dt.Rows.Add(envID, clientName, productName, AppServerEnvType, DBServerEnvType, AppServerName, AppServerOS, AppServerOSBuild, AppServerIsX86Version, AppServerIsVirtual, AppServerProcessor, AppServerMemory, AppServerWebBrowser, AppServerWebBrowserVersion, AppServerWorkingDirectoryLocation, AppHyperLink, AppServerIP, AppServerPort, AppServerDependency, DBServerName, DBServerIsX86Version, DBServerIsVirtual, DBServerMemory, DBServerProcessor, DBServerOS, DBServerOSBuild, DBServerDirectoryLocation, DBMDFFileLocation, DBMDFFileSize, DBLDFFileLocation, DBLDFFileSize, DBServerIP, DBServerPort, DBServerDependency);
            //DetailsView1.m
            DetailsView1.DataSource = dt;
            DetailsView1.DataBind();
            //.Attributes["accordionView"] = "hidden";
            //DetailsView1.Attributes.Add("style", "display:block");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //TextBox txtClientId = DetailsView1.FindControl("txtClientID") as TextBox;
            Debug.WriteLine("Not Index!");
            //DetailsView1.Visible = false;
            //Page.PreRender += new EventHandler(Page_PreRender);
            DetailsView1.Visible = false;
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
            //Console.WriteLine("<script>alert(" + ResultQuery + "record has been updated." + ")</script>");
            //ClientScript.RegisterStartupScript(this.GetType(), DateTime.Now.ToString(), "<script>alert(" + ResultQuery + "record has been updated." + ")</script>", true);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString(), "<script>alert(" + ResultQuery +")</script>", true);
            DetailsView1.Visible = false;
            //DetailsView1.Style.Add("display", "none");
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

        protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {

        }

        protected void DetailsView1_DataBound(object sender, EventArgs e)
        {
            //HiddenField hidType = DetailsView1.FindControl("hidClientType") as HiddenField;
            //DropDownList dropType = DetailsView1.FindControl("dropClientType") as DropDownList;
            //dropType.SelectedValue = hidType.Value;
        }
    }
}