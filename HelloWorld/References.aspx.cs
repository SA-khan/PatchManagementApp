using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelloWorld.App_Code;

namespace HelloWorld
{
    public partial class References : System.Web.UI.Page
    {
        DatabaseConnectivity dbcon = new DatabaseConnectivity();
        string guid = Guid.NewGuid().ToString();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile) {
                try
                {
                    string extension = System.IO.Path.GetExtension(FileUpload1.FileName);
                    string path = Server.MapPath("Resources\\");
                    string fileName = guid + FileUpload1.FileName;
                    FileUpload1.SaveAs(path + fileName);
                    dbcon.insertReference(guid, fileName, txtFileTitle.Text.ToString(), txtFileDesc.Text.ToString(), 2, 4, extension, path, path+fileName, "Initial Draft", 0, "", true,DateTime.Now);
                }
                catch(InsufficientMemoryException ex){
                    lblHeading.Text = "Low Memory Error: ";
                    lblStatus.Text = ex.Message;
                }
                catch(Exception ex) {
                    lblHeading.Text = "Error: ";
                    lblStatus.Text = ex.Message;
                }
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            div_upload.Style.Add("display","none");
            div_view.Style.Add("display", "none");
            _BindService();
        }

        private void _BindService()
        {
            DatabaseConnectivity dbcon = new DatabaseConnectivity();
            List<ReferenceDoc> service = dbcon.getReferencesDesc();
            if (service.Count > 0 && service != null)
            {
                GridView1.DataSource = service;
                GridView1.DataBind();
            }
        }
    }
}