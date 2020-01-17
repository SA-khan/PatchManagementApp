﻿using System;
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

        private void _BindService()
        {
            DatabaseConnectivity dbcon = new DatabaseConnectivity();
            List<Patch> service = dbcon.getAllUpdatedClientPatches(1, 1);
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
                int queryResult = dbcon.updateClientPatches(ClientName, "ONLINE_PORTAL");
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
            string clientName = (GridView1.SelectedRow.FindControl("lblClientName") as Label).Text;
            string clientType = (GridView1.SelectedRow.FindControl("lblClientType") as Label).Text;
            string totalPatches = (GridView1.SelectedRow.FindControl("lblTotalPatches") as Label).Text;
            string latestPatch = (GridView1.SelectedRow.FindControl("lblLatestPatch") as Label).Text;
            string patchDeployedDate = (GridView1.SelectedRow.FindControl("lblPatchDeployed") as Label).Text;
            Debug.WriteLine(GridView1.SelectedRow.Cells[0].Text);
            Debug.WriteLine(GridView1.SelectedRow.Cells[1].Text);
            Debug.WriteLine(GridView1.SelectedRow.Cells[2].Text);
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[5] { new DataColumn("ClientName", typeof(string)),
                    new DataColumn("ClientType", typeof(string)),
                    new DataColumn("TotalPatches",typeof(string)), 
                    new DataColumn("LatestHotPatch",typeof(string)),
                    new DataColumn("PatchDeployedDate",typeof(string)) });
            dt.Rows.Add(clientName, clientType, totalPatches, latestPatch, patchDeployedDate);
            //DetailsView1.m
            DetailsView1.DataSource = dt;
            DetailsView1.DataBind();
            //.Attributes["accordionView"] = "hidden";
            //DetailsView1.Attributes.Add("style", "display:block");
        }

        protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {
            Debug.WriteLine("Index");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Index");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //DetailsView1.Attributes.Add("style", "display:none");
            //DetailsView1.Attributes.Add("style", "visible:false");
            Debug.WriteLine("NotIndex");
            DetailsView1.Rows[0].Visible = false;
            DetailsView1.Rows[1].Visible = false;
            DetailsView1.Visible = false;
            DetailsView1.Width = 0;
            DetailsView1.Height = 0;
            //DetailsView1.Style.Add("Display", "none");
            //DetailsView1.FindControl("lblClientName").Visible = false;
            //UpdatePanel1.Update();
        }

        protected void DetailsView1_DataBound(object sender, EventArgs e)
        {
            //Button lb = e.Equals("btnCancel") as Button;
            //ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(lb);
        }



    }
}