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
            TextBox txtProductId = DetailsView1.FindControl("txtProductID") as TextBox;
            TextBox txtProductName = DetailsView1.FindControl("txtProductName") as TextBox;
            TextBox txtProductDesc = DetailsView1.FindControl("txtProductDesc") as TextBox;
            TextBox txtProductVersion = DetailsView1.FindControl("txtProductVersion") as TextBox;
            TextBox txtProductType = DetailsView1.FindControl("txtProductType") as TextBox;
            TextBox txtProductCategory = DetailsView1.FindControl("txtProductCategory") as TextBox;
            TextBox txtProductRating = DetailsView1.FindControl("txtProductRating") as TextBox;
            TextBox txtProductUserID = DetailsView1.FindControl("txtProductUserID") as TextBox;
            TextBox txtProductPassword = DetailsView1.FindControl("txtProductPassword") as TextBox;
            TextBox txtProductPOC = DetailsView1.FindControl("txtProductPOC") as TextBox;
            TextBox txtProductEmail = DetailsView1.FindControl("txtProductEmail") as TextBox;
            TextBox txtProductComment = DetailsView1.FindControl("txtProductComment") as TextBox;
            int ProductID = Convert.ToInt32(txtProductId.Text.ToString());
            string ProductName = txtProductName.Text.ToString();
            string ProductDesc = txtProductDesc.Text.ToString();
            string ProductVersion = txtProductVersion.Text.ToString();
            string ProductType = txtProductType.Text.ToString();
            string ProductCategory = txtProductCategory.Text.ToString();
            string ProductRating = txtProductRating.Text.ToString();
            string ProductUserID = txtProductUserID.Text.ToString();
            string ProductPassword = txtProductPassword.Text.ToString();
            string ProductPOC = txtProductPOC.Text.ToString();
            string ProductEmail = txtProductEmail.Text.ToString();
            string ProductComment = txtProductComment.Text.ToString();
            Debug.WriteLine("");
            Debug.WriteLine("Data From Grid:");
            Debug.WriteLine("ProductID: " + ProductID);
            Debug.WriteLine("ProductName: " + ProductName);
            Debug.WriteLine("ProductDesc: " + ProductDesc);
            Debug.WriteLine("ProductVersion: " + ProductVersion);
            Debug.WriteLine("ProductType: " + ProductType);
            Debug.WriteLine("ProductCategory: " + ProductCategory);
            Debug.WriteLine("ProductRating: " + ProductRating);
            Debug.WriteLine("ProductUserID: " + ProductUserID);
            Debug.WriteLine("ProductPassword: " + ProductPassword);
            Debug.WriteLine("ProductPOC: " + ProductPOC);
            Debug.WriteLine("ProductEmail: " + ProductEmail);
            Debug.WriteLine("ProductComment: " + ProductComment);
            DatabaseConnectivity dbcon = new DatabaseConnectivity();
            int ResultQuery = dbcon.setAProduct(ProductID, ProductName, ProductDesc, ProductVersion, ProductType, ProductCategory, ProductRating, ProductUserID, ProductPassword, ProductPOC, ProductEmail, ProductComment);
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
            string productID = (GridView1.SelectedRow.FindControl("lblProductID") as Label).Text;
            string productName = (GridView1.SelectedRow.FindControl("lblProductName") as Label).Text;
            string productDesc = (GridView1.SelectedRow.FindControl("lblProductDesc") as Label).Text;
            string productVersion = (GridView1.SelectedRow.FindControl("lblProductVersion") as Label).Text;
            string productType = (GridView1.SelectedRow.FindControl("lblProductType") as Label).Text;
            string productCategory = (GridView1.SelectedRow.FindControl("lblProductCategory") as Label).Text;
            string productRating = (GridView1.SelectedRow.FindControl("lblProductRating") as Label).Text;
            string productUserID = (GridView1.SelectedRow.FindControl("lblProductUserID") as Label).Text;
            string productPasscode = (GridView1.SelectedRow.FindControl("lblProductPassword") as Label).Text;
            string productPOC = (GridView1.SelectedRow.FindControl("lblProductPOC") as Label).Text;
            string productEmail = (GridView1.SelectedRow.FindControl("lblPOCEmail") as Label).Text;
            string productDependency = (GridView1.SelectedRow.FindControl("lblProductDependency") as Label).Text;
            Debug.WriteLine(GridView1.SelectedRow.Cells[0].Text);
            Debug.WriteLine(GridView1.SelectedRow.Cells[1].Text);
            Debug.WriteLine(GridView1.SelectedRow.Cells[2].Text);
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[12] { 
                    new DataColumn("ProductID", typeof(string)),
                    new DataColumn("ProductName", typeof(string)),
                    new DataColumn("ProductDesc", typeof(string)),
                    new DataColumn("ProductVersion",typeof(string)), 
                    new DataColumn("ProductType",typeof(string)),
                    new DataColumn("ProductCategory",typeof(string)),
                    new DataColumn("ProductRating", typeof(string)),
                    new DataColumn("ProductDemoUserID", typeof(string)),
                    new DataColumn("ProductDemoPasscode",typeof(string)), 
                    new DataColumn("ProductPOC",typeof(string)),
                    new DataColumn("ProductPOCEmail",typeof(string)),
                    new DataColumn("ProductDependency",typeof(string)) });
            dt.Rows.Add(productID, productName, productDesc, productVersion, productType, productCategory, productRating, productUserID, productPasscode, productPOC, productEmail, productDependency);
            DetailsView1.DataSource = dt;
            DetailsView1.DataBind();
        }
    }
}