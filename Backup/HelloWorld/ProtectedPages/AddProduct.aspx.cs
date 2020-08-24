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
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string _productName = txtProductName.Text.ToString();
            string _productDesc = txtProductDesc.Text.ToString();
            string _productVersion = txtProductVersion.Text.ToString();
            string _productType = txtProductType.Text.ToString();
            string _productCategory = txtProductCategory.Text.ToString();
            string _productRating = txtProductRating.Text.ToString();
            string _productUserID = txtProductUserID.Text.ToString();
            string _productPassword = txtProductPassword.Text.ToString();
            string _productPOC = txtProductPOC.Text.ToString();
            string _productSupportEmail = txtProductSupportEmail.Text.ToString();
            string _productComments = txtProductComments.Text.ToString();
            if (_productName != null)
            {
                Debug.WriteLine("");
                Debug.WriteLine("Product Name: " + _productName);
                Debug.WriteLine("Product Desc: " + _productDesc);
                DatabaseConnectivity dbcon = new DatabaseConnectivity();
                int res = dbcon.insertProduct(_productName, _productDesc, _productVersion, _productType, _productCategory, _productRating, _productUserID, _productPassword, _productPOC, _productSupportEmail, _productComments);
                Debug.WriteLine("Query Status: " + res);
                if (res == 1)
                {
                    lblSubmission.Visible = true;
                    rowProductName.Visible = false;
                    rowProductDesc.Visible = false;
                    rowProductType.Visible = false;
                    rowProductCategory.Visible = false;
                    rowProductComments.Visible = false;
                    rowProductUserID.Visible = false;
                    rowProductPassword.Visible = false;
                    rowProductPOC.Visible = false;
                    rowProductRating.Visible = false;
                    rowProductSupportEmail.Visible = false;
                    rowProductVersion.Visible = false;
                    rowSubmit.Visible = false;
                }
            }
            else
            {
                Debug.WriteLine("alert(Please Enter Product Name.)");
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtProductName.Text = "";
            txtProductDesc.Text = "";
            txtProductType.Text = "";
            txtProductVersion.Text = "";
            txtProductCategory.Text = "";
            txtProductComments.Text = "";
            txtProductPassword.Text = "";
            txtProductPOC.Text = "";
            txtProductRating.Text = "";
            txtProductSupportEmail.Text = "";
            txtProductUserID.Text = "";
        }
    }
}