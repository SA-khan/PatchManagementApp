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
            txtDBServerName.BackColor = Color.White;

            txtAppServerName.Text = String.Empty;
            txtAppServerOS.Text = String.Empty;
            txtAppHyperLink.Text = String.Empty;
            txtAppServerDependency.Text = String.Empty;
            txtAppServerIP.Text = String.Empty;
            txtAppServerPort.Text = String.Empty;
            txtAppServerProcessor.Text = String.Empty;
            txtAppServerWebBrowserVersion.Text = String.Empty;
            txtAppServerWorkingDirectoryLocation.Text = String.Empty;
            txtDBLDFFileLocation.Text = String.Empty;
            txtDBLDFFileSize.Text = String.Empty;
            txtDBMDFFileLocation.Text = String.Empty;
            txtDBMDFFileSize.Text = String.Empty;
            txtDBServerDependency.Text = String.Empty;
            txtDBServerDirectoryLocation.Text = String.Empty;
            txtDBServerIP.Text = String.Empty;
            txtDBServerName.Text = String.Empty;
            txtDBServerPort.Text = String.Empty;
            txtDBServerProcessor.Text = String.Empty;
            txtDBServerOS.Text = String.Empty;

            dropAppEnvType.SelectedIndex = 0;
            dropAppServerMemory.SelectedIndex = 0;
            dropAppServerOSBuild.SelectedIndex = 0;
            dropAppServerWebBrowser.SelectedIndex = 0;
            dropClientName.SelectedIndex = 0;
            dropDBEnvType.SelectedIndex = 0;
            dropDBServerMemory.SelectedIndex = 0;
            dropDBServerOSBuild.SelectedIndex = 0;
            dropProductName.SelectedIndex = 0;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int ClientID = Convert.ToInt32(dropClientName.SelectedValue);
            int ProductID = Convert.ToInt32(dropProductName.SelectedValue);
            int AppEnvType = Convert.ToInt32(dropAppEnvType.SelectedValue);
            int DBEnvType = Convert.ToInt32(dropDBEnvType.SelectedValue);
            string AppServerName = txtAppServerName.Text.ToString();
            string DBServerName = txtDBServerName.Text.ToString();
            string AppServerOS = txtAppServerOS.Text.ToString();
            string DBServerOS = txtDBServerOS.Text.ToString();
            double AppServerOSBuild = Convert.ToDouble(dropAppServerOSBuild.SelectedValue);
            double DBServerOSBuild = Convert.ToDouble(dropDBServerOSBuild.SelectedValue);
            string AppServerProcessor = txtAppServerProcessor.Text.ToString();
            string DBServerProcessor = txtDBServerProcessor.Text.ToString();
            double AppServerMemory = Convert.ToDouble(dropAppServerMemory.SelectedValue);
            double DBServerMemory = Convert.ToDouble(dropDBServerMemory.SelectedValue);
            int AppServerIsX86Version = Convert.ToInt32(radAppServerIsX86.SelectedValue);
            int DBServerIsX86Version = Convert.ToInt32(radDBServerIsx86.SelectedValue);
            int AppServerIsVirtual = Convert.ToInt32(radAppServerIsVirtual.SelectedValue);
            int DBServerIsVirtual = Convert.ToInt32(radDBServerIsVirtual.SelectedValue);
            string AppServerIP = txtAppServerIP.Text.ToString();
            string DBServerIP = txtDBServerIP.Text.ToString();
            double AppServerPort = Convert.ToInt32(txtAppServerPort.Text);
            double DBServerPort = Convert.ToInt32(txtDBServerPort.Text);
            string AppServerDependency = txtAppServerDependency.Text.ToString();
            string DBServerDependency = txtDBServerDependency.Text.ToString();
            string AppHyperLink = txtAppHyperLink.Text.ToString();
            string AppServerWebServer = dropAppServerWebBrowser.SelectedValue.ToString();
            string AppServerWebServerVersion = txtAppServerWebBrowserVersion.Text.ToString();
            string AppServerWorkingDirectoryLocation = txtAppServerWorkingDirectoryLocation.Text.ToString();
            string DBServerDirectoryLocation = txtDBServerDirectoryLocation.Text.ToString();
            string DBMDFFileLocation = txtDBMDFFileLocation.Text.ToString();
            double DBMDFFileSize = Convert.ToDouble(txtDBMDFFileSize.Text);
            string DBLDFFileLocation = txtDBLDFFileLocation.Text.ToString();
            double DBLDFFileSize = Convert.ToDouble(txtDBLDFFileSize.Text);

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
                rowAppEnvType.Visible = false;
                rowAppHyperLink.Visible = false;
                rowAppServerDependency.Visible = false;
                rowAppServerIP.Visible = false;
                rowAppServerIsVirtual.Visible = false;
                rowAppServerIsX86.Visible = false;
                rowAppServerMemory.Visible = false;
                rowAppServerName.Visible = false;
                rowAppServerOS.Visible = false;
                rowAppServerOSBuild.Visible = false;
                rowAppServerPort.Visible = false;
                rowAppServerProcessor.Visible = false;
                rowAppServerWebBrowser.Visible = false;
                rowAppServerWebBrowserVersion.Visible = false;
                rowAppServerWorkingDirectoryLocation.Visible = false;
                rowClientName.Visible = false;
                rowDBEnvType.Visible = false;
                rowDBLDFFileLocation.Visible = false;
                rowDBLDFFileSize.Visible = false;
                rowDBMDFFileLocation.Visible = false;
                rowDBMDFFileSize.Visible = false;
                rowDBServerDependency.Visible = false;
                rowDBServerDirectoryLocation.Visible = false;
                rowDBServerIP.Visible = false;
                rowDBServerIsVirtual.Visible = false;
                rowDBServerIsx86.Visible = false;
                rowDBServerMemory.Visible = false;
                rowDBServerName.Visible = false;
                rowDBServerPort.Visible = false;
                rowDBServerProcessor.Visible = false;
                rowIsEnvSameAsDB.Visible = false;
                rowlblDBServerOS.Visible = false;
                rowlblDBServerOSBuild.Visible = false;
                rowProductName.Visible = false;
                rowSubmit.Visible = false;
                lblDatabaseHeader.Visible = false;
                lblSubmission.Visible = true;
            }

            else {
                rowAppEnvType.Visible = false;
                rowAppHyperLink.Visible = false;
                rowAppServerDependency.Visible = false;
                rowAppServerIP.Visible = false;
                rowAppServerIsVirtual.Visible = false;
                rowAppServerIsX86.Visible = false;
                rowAppServerMemory.Visible = false;
                rowAppServerName.Visible = false;
                rowAppServerOS.Visible = false;
                rowAppServerOSBuild.Visible = false;
                rowAppServerPort.Visible = false;
                rowAppServerProcessor.Visible = false;
                rowAppServerWebBrowser.Visible = false;
                rowAppServerWebBrowserVersion.Visible = false;
                rowAppServerWorkingDirectoryLocation.Visible = false;
                rowClientName.Visible = false;
                rowDBEnvType.Visible = false;
                rowDBLDFFileLocation.Visible = false;
                rowDBLDFFileSize.Visible = false;
                rowDBMDFFileLocation.Visible = false;
                rowDBMDFFileSize.Visible = false;
                rowDBServerDependency.Visible = false;
                rowDBServerDirectoryLocation.Visible = false;
                rowDBServerIP.Visible = false;
                rowDBServerIsVirtual.Visible = false;
                rowDBServerIsx86.Visible = false;
                rowDBServerMemory.Visible = false;
                rowDBServerName.Visible = false;
                rowDBServerPort.Visible = false;
                rowDBServerProcessor.Visible = false;
                rowIsEnvSameAsDB.Visible = false;
                rowlblDBServerOS.Visible = false;
                rowlblDBServerOSBuild.Visible = false;
                rowProductName.Visible = false;
                rowSubmit.Visible = false;
                lblDatabaseHeader.Visible = false;
                lblSubmission.Visible = true;
                lblSubmission.Text = "Data Insertion Failed, Please Check Database Connection.";
            }
        }

        protected void checkIsEnvSameAsDBYes_CheckedChanged(object sender, EventArgs e)
        {
            if (checkIsEnvSameAsDBYes.Checked) {
                checkIsEnvSameAsDBNo.Checked = false;
                txtAppServerName.BackColor = Color.LightYellow;
                txtDBServerName.Text = txtAppServerName.Text.ToString();
                txtDBServerName.BackColor = Color.LightYellow;
                txtDBServerOS.Text = txtAppServerOS.Text.ToString();
                txtDBServerIP.Text = txtAppServerIP.Text.ToString();
                txtDBServerPort.Text = txtAppServerPort.Text.ToString();
                txtDBServerProcessor.Text = txtAppServerProcessor.Text.ToString();
                dropDBServerOSBuild.SelectedIndex = dropAppServerOSBuild.SelectedIndex;
                dropDBServerMemory.SelectedIndex = dropAppServerMemory.SelectedIndex;
                radDBServerIsx86.SelectedIndex = radAppServerIsX86.SelectedIndex;
                radDBServerIsVirtual.SelectedIndex = radAppServerIsVirtual.SelectedIndex;
                txtDBServerDependency.Text = txtAppServerDependency.Text.ToString();
            }
        }

        protected void checkIsEnvSameAsDBNo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkIsEnvSameAsDBNo.Checked)
            {
                checkIsEnvSameAsDBYes.Checked = false;
                if (txtDBServerName.Text == String.Empty || txtDBServerOS.Text == String.Empty)
                {
                    txtAppServerName.BackColor = Color.White;
                    txtDBServerName.Text = String.Empty;
                    txtDBServerName.BackColor = Color.White;
                    txtDBServerOS.Text = String.Empty;
                }
            }
        }

        
    }
}