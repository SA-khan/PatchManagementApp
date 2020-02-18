using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelloWorld.App_Code;

namespace HelloWorld.ProtectedPages
{
    public partial class DeleteProduct : System.Web.UI.Page
    {

        DatabaseConnectivity dbcon = new DatabaseConnectivity();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int product = Convert.ToInt32(dropProduct.SelectedValue);
            int res = dbcon.deleteProduct(product);
            rowProduct.Visible = false;
            rowSubmit.Visible = false;
            lblSubmission.Visible = true;
            lblSubmission.Text = "Product is successfully deleted. \nResponse Code:" + ( res == 1 ? "0200" : "0500" );
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            dropProduct.SelectedIndex = 0;
        }
    }
}