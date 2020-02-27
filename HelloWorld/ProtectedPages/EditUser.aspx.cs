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
    public partial class EditUser : System.Web.UI.Page
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
            List<User> service = dbcon.getUserList();
            if (service.Count > 0 && service != null)
            {
                GridView1.DataSource = service;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DetailsView1.Visible = true;
            string userID = (GridView1.SelectedRow.FindControl("lblUserID") as Label).Text;
            string userName = (GridView1.SelectedRow.FindControl("lblUserName") as Label).Text;
            string userRole = (GridView1.SelectedRow.FindControl("lblUserRole") as Label).Text;
            string userStatus = (GridView1.SelectedRow.FindControl("lblUserStatus") as Label).Text;
            string userLoginDate = (GridView1.SelectedRow.FindControl("lblUserLoginDate") as Label).Text;
            int userWrongAttempts = Convert.ToInt32((GridView1.SelectedRow.FindControl("lblUserWrongAttempt") as Label).Text);
            Debug.WriteLine(GridView1.SelectedRow.Cells[0].Text);
            Debug.WriteLine(GridView1.SelectedRow.Cells[1].Text);
            Debug.WriteLine(GridView1.SelectedRow.Cells[2].Text);
            Debug.WriteLine(GridView1.SelectedRow.Cells[3].Text);
            Debug.WriteLine(GridView1.SelectedRow.Cells[4].Text);
            Debug.WriteLine(GridView1.SelectedRow.Cells[5].Text);
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[6] { 
                    new DataColumn("UserID", typeof(string)),
                    new DataColumn("UserName", typeof(string)),
                    new DataColumn("UserRole", typeof(string)),
                    new DataColumn("UserStatus",typeof(string)), 
                    new DataColumn("UserLoginDate",typeof(string)),
                    new DataColumn("UserWrongAttempt",typeof(int)) });
            dt.Rows.Add(userID, userName, userRole, userStatus, userLoginDate, userWrongAttempts);
            //DetailsView1.m
            DetailsView1.DataSource = dt;
            DetailsView1.DataBind();
            //.Attributes["accordionView"] = "hidden";
            //DetailsView1.Attributes.Add("style", "display:block");
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Debug.WriteLine("Clicked!!!!");
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

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridView1.EditIndex = e.NewEditIndex;
                _BindService();
                //Debug.WriteLine(e.NewEditIndex);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
            }
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

        protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {

        }

        protected void DetailsView1_DataBound(object sender, EventArgs e)
        {
            //HiddenField hidType = DetailsView1.FindControl("hidClientType") as HiddenField;
            //DropDownList dropType = DetailsView1.FindControl("dropClientType") as DropDownList;
            //dropType.SelectedValue = hidType.Value;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            TextBox txtUserID = DetailsView1.FindControl("txtUserID") as TextBox;
            TextBox txtUserName = DetailsView1.FindControl("txtUserName") as TextBox;
            DropDownList dropUserRole = DetailsView1.FindControl("dropUserRole") as DropDownList;
            TextBox txtUserStatus = DetailsView1.FindControl("txtUserStatus") as TextBox;
            TextBox txtUserLoginDate = DetailsView1.FindControl("txtUserLoginDate") as TextBox;
            TextBox txtWrongAttempts = DetailsView1.FindControl("txtWrongAttempts") as TextBox;
            int userID = Convert.ToInt32(txtUserID.Text.ToString());
            string userName = txtUserName.Text.ToString();
            string userRole = dropUserRole.SelectedValue.ToString();
            string userStatus = txtUserStatus.Text.ToString();
            string userLoginDate = txtUserLoginDate.Text.ToString();
            string wrongAttempts = txtWrongAttempts.Text.ToString();
            Debug.WriteLine("");
            Debug.WriteLine("Data From Grid:");
            Debug.WriteLine("User ID: " + userID);
            Debug.WriteLine("User Name: " + userName);
            Debug.WriteLine("User Type: " + userRole);
            Debug.WriteLine("User Status: " + userStatus);
            Debug.WriteLine("User Login Date: " + userLoginDate);
            Debug.WriteLine("User Wrong Attempts: " + wrongAttempts);
            DatabaseConnectivity dbcon = new DatabaseConnectivity();
            int res = dbcon.setAUser(userID, userName, userRole, userStatus, userLoginDate, wrongAttempts);
            //nt ResultQuery = dbcon.setAClient(userID, userName, userRole, userStatus, userLoginDate, wrongAttempts);
            //Console.WriteLine("<script>alert(" + ResultQuery + "record has been updated." + ")</script>");
            //ClientScript.RegisterStartupScript(this.GetType(), DateTime.Now.ToString(), "<script>alert(" + ResultQuery + "record has been updated." + ")</script>", true);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString(), "<script>alert(" + ResultQuery +")</script>", true);
            DetailsView1.Visible = false;
            //DetailsView1.Style.Add("display", "none");
            _BindService();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            DetailsView1.Visible = false;
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Debug.WriteLine("HHHH");
        }
    }
}