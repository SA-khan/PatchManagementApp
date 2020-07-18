using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Diagnostics;
using HelloWorld.App_Code;

namespace HelloWorld.ProtectedPages
{
    public partial class AddClientEnvironment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

            txtAppServerName.BackColor = Color.White;

            txtAppServerName.Text = String.Empty;
            txtAppServerOS.Text = String.Empty;
            txtAppHyperLink.Text = String.Empty;
            txtAppServerDependency.Text = String.Empty;
            txtAppServerIP.Text = String.Empty;
            txtAppServerPort.Text = String.Empty;
            txtAppServerProcessor.Text = String.Empty;
            txtAppServerWebBrowserVersion.Text = String.Empty;
            txtAppServerWorkingDirectoryLocation.Text = String.Empty;

            dropAppEnvType.SelectedIndex = 0;
            dropAppServerMemory.SelectedIndex = 0;
            dropAppServerOSBuild.SelectedIndex = 0;
            dropAppServerWebBrowser.SelectedIndex = 0;
            dropClientName.SelectedIndex = 0;
            dropDBEnvType.SelectedIndex = 0;
            dropProductName.SelectedIndex = 0;

            lblResponse.Text = "Data Fields have been refreshed successfully.";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script language='javascript'>");
            sb.Append(@"$('#myModal').modal('show');");
            sb.Append(@"</script>");
            ClientScript.RegisterStartupScript(this.GetType(), "JSScript", sb.ToString());
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int ClientID = Convert.ToInt32(dropClientName.SelectedValue);
            int ProductID = Convert.ToInt32(dropProductName.SelectedValue);
            int AppEnvType = Convert.ToInt32(dropAppEnvType.SelectedValue);
            int DBEnvType = Convert.ToInt32(dropDBEnvType.SelectedValue);
            string AppServerName = txtAppServerName.Text.ToString();
            string DBServerName = "";
            string AppServerOS = txtAppServerOS.Text.ToString();
            string DBServerOS = "";
            double AppServerOSBuild = Convert.ToDouble(dropAppServerOSBuild.SelectedValue == "Select.." ? "0" : dropAppServerOSBuild.SelectedValue.ToString());
            double DBServerOSBuild = 0;
            string AppServerProcessor = txtAppServerProcessor.Text.ToString();
            string DBServerProcessor = "";
            double AppServerMemory = Convert.ToDouble(dropAppServerMemory.SelectedValue == "Select.." ? "0" : dropAppServerMemory.SelectedValue.ToString());
            double DBServerMemory = 0;
            int AppServerIsX86Version = Convert.ToInt32(radAppServerIsX86.SelectedValue == "Select.." ? "0" : radAppServerIsX86.SelectedValue.ToString());
            int DBServerIsX86Version = 0;
            int AppServerIsVirtual = Convert.ToInt32(radAppServerIsVirtual.SelectedValue == "Select.." ? "0" : radAppServerIsVirtual.SelectedValue.ToString());
            int DBServerIsVirtual = 0;
            string AppServerIP = txtAppServerIP.Text.ToString();
            string DBServerIP = "";
            double AppServerPort = Convert.ToInt32(txtAppServerPort.Text == "" ? "0" : txtAppServerPort.Text.ToString());
            double DBServerPort = 0;
            string AppServerDependency = txtAppServerDependency.Text.ToString();
            string DBServerDependency = "";
            string AppHyperLink = txtAppHyperLink.Text.ToString();
            string AppServerWebServer = dropAppServerWebBrowser.SelectedValue.ToString() == "Select.." ? "" : dropAppServerWebBrowser.SelectedValue.ToString();
            string AppServerWebServerVersion = txtAppServerWebBrowserVersion.Text.ToString();
            string AppServerWorkingDirectoryLocation = txtAppServerWorkingDirectoryLocation.Text.ToString();
            string DBServerDirectoryLocation = "";
            string DBMDFFileLocation = "";
            double DBMDFFileSize = 0;
            string DBLDFFileLocation = "";
            double DBLDFFileSize = 0;

            Debug.WriteLine("Environment Data Start: ");
            Debug.WriteLine("Client ID: " + ClientID);
            Debug.WriteLine("Product ID: " + ProductID);
            Debug.WriteLine("App Environment Type: " + AppEnvType);
            Debug.WriteLine("Database Environment Type: " + DBEnvType);
            Debug.WriteLine("App Server Name: " + AppServerName);
            Debug.WriteLine("Database Server Name: " + DBServerName);
            Debug.WriteLine("App Server OS: " + AppServerOS);
            Debug.WriteLine("Database Server OS: " + DBServerOS);
            Debug.WriteLine("App Server OS Build: " + AppServerOSBuild);
            Debug.WriteLine("DB Server OS Build: " + DBServerOSBuild);
            Debug.WriteLine("App Server Processor: " + AppServerProcessor);
            Debug.WriteLine("Database Server Processor: " + DBServerProcessor);
            Debug.WriteLine("App Server Memory: " + AppServerMemory);
            Debug.WriteLine("Database Server Memory: " + DBServerMemory);
            Debug.WriteLine("App Server IP: " + AppServerIP);
            Debug.WriteLine("Database Server IP: " + DBServerIP);
            Debug.WriteLine("App Server Port: " + AppServerPort);
            Debug.WriteLine("Database Server Port: " + DBServerPort);
            Debug.WriteLine("App Server Dependency: " + AppServerDependency);
            Debug.WriteLine("Database Server Dependency: " + DBServerDependency);
            Debug.WriteLine("App Server Web Server: " + AppServerWebServer);
            Debug.WriteLine("App Server Web Server Version: " + AppServerWebServerVersion);
            Debug.WriteLine("App Server Working Directory Location: " + AppServerWorkingDirectoryLocation);
            Debug.WriteLine("Database Server Directory Location: " + DBServerDirectoryLocation);
            Debug.WriteLine("Database MDF File Location: " + DBMDFFileLocation);
            Debug.WriteLine("Database MDF File Size: " + DBMDFFileSize);
            Debug.WriteLine("Database LDF File Location: " + DBLDFFileLocation);
            Debug.WriteLine("Database LDF File Size: " + DBLDFFileSize);
            Debug.WriteLine("Environment Data End.");

            DatabaseConnectivity dbcon = new DatabaseConnectivity();
                                  // insertEnvironment(ClientID,ProductID, AppEnvType, DBEnvType, AppServerName, AppServerOS, AppServerOSBuild, AppServerIsX86Version, AppServerIsVirtual, AppServerProcessor, int AppServerMemory, string AppServerWebBrowser, string AppServerWebBrowserVersion, striAppServerWorkingDirectoryLocation, string AppHyperLink, string AppServerIP, int AppServerPort, string AppServerDependency, string DBServerName, string DBServerOS, double DBerverOSBuild, int DBServerIsX86Version, int DBServerIsVirtual, string DBServerProcessor, int DBServerMemory, string DBServerWorkingDirectoryLocation, string DBMDFFileLocation, double DBMDFFileSize, string DBLDFFileLocation, double DBLDFFileSize, string DBServerIP, int DBServerPort, string DBServerDependency)
            int queryResult = dbcon.insertEnvironment(ClientID, ProductID, AppEnvType, DBEnvType, AppServerName, AppServerOS, AppServerOSBuild, AppServerIsX86Version, AppServerIsVirtual, AppServerProcessor, AppServerMemory, AppServerWebServer, AppServerWebServerVersion, AppServerWorkingDirectoryLocation, AppHyperLink, AppServerIP, AppServerPort, AppServerDependency, DBServerName, DBServerOS, DBServerOSBuild, DBServerIsX86Version, DBServerIsVirtual, DBServerProcessor, DBServerMemory, DBServerDirectoryLocation, DBMDFFileLocation, DBMDFFileSize, DBLDFFileLocation, DBLDFFileSize, DBServerIP, DBServerPort, DBServerDependency);
            Debug.WriteLine("Query Result: " + queryResult);
            if (queryResult == 1)
            {
                //System.Text.StringBuilder sb = new System.Text.StringBuilder();
                //lblResponse.Text = "Environment is added successfully.";
                //sb.Append(@"<script language='javascript'>");
                //sb.Append(@"$('#myModal').modal('show');");
                //sb.Append(@"</script>");
                //ClientScript.RegisterStartupScript(this.GetType(), "JSScript", sb.ToString());
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$(function() { $('#myModal').modal('show'); });</script>", false);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$(function() { alert('Environment has been created successfully.'); });</script>", false);
            }
            else {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$(document).ready(function(){$('#myModal').modal('sho‌​w');});</script>", false);
                //System.Text.StringBuilder sb = new System.Text.StringBuilder();
                //lblResponse.Text = "There is an issue occured, Please check your input field and try Again.";
                //sb.Append(@"<script language='javascript'>");
                //sb.Append(@"$('#myModal').modal('show');");
                //sb.Append(@"</script>");
                //ClientScript.RegisterStartupScript(this.GetType(), "JSScript", sb.ToString());
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$(function() { alert('There is an issue occured, Please check your connection with the database.'); });</script>", false);
            }
        }
        
    }
}