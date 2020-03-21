using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using HelloWorld.App_Code;
using System.Drawing;

namespace HelloWorld
{
    public partial class EnvironmentInfo : System.Web.UI.Page
    {
        DatabaseConnectivity dbcon = new DatabaseConnectivity();
        Log log = new Log();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                log.DetailLog("EnvironmentInfo.aspx.cs", "Page_Load", STATE.INITIALIZED, "Method: Page_Load in Class: EnvironmentInfo.aspx.cs has Initialized.");
                int product = Convert.ToInt32(DropDownList1.Text);
                int environment = Convert.ToInt32(DropEnvType.Text);
                int client = Convert.ToInt32(DropClientID.Text);
                List<HelloWorld.App_Code.Environment> latestPatchOfClient = dbcon.getClientEnvironmentInfo(product, environment, client);
                int count = 0;
                int total = latestPatchOfClient.Count;
                totalRecords.Text = "Total Number of Records: " + total;
                foreach (var item in latestPatchOfClient)
                {
                    TableRow row7 = new TableRow();
                    TableRow row6 = new TableRow();
                    TableRow row5 = new TableRow();
                    TableRow row4 = new TableRow();
                    TableRow row3 = new TableRow();
                    TableRow row2 = new TableRow();
                    TableRow row1 = new TableRow();
                    TableRow row00 = new TableRow();
                    TableRow row0 = new TableRow();
                    TableRow row = new TableRow();

                    TableRow row16 = new TableRow();
                    TableRow row15 = new TableRow();
                    TableRow row14 = new TableRow();
                    TableRow row13 = new TableRow();
                    TableRow row12 = new TableRow();
                    TableRow row11 = new TableRow();
                    TableRow row10 = new TableRow();
                    TableRow row9 = new TableRow();
                    TableRow row8 = new TableRow();

                    row.Style.Add("width", "100%");

                    TableCell cellClient1 = new TableCell();
                    cellClient1.Height = 40;
                    cellClient1.ForeColor = Color.White;
                    cellClient1.BackColor = ColorTranslator.FromHtml("#3A4F63");
                    cellClient1.Style.Add("Font-Size", "22px");
                    cellClient1.Text = "Environment " + ++count;
                    cellClient1.HorizontalAlign = HorizontalAlign.Center;
                    cellClient1.ColumnSpan = 10;
                    row0.Cells.Add(cellClient1);

                    TableCell cellProductLbl = new TableCell();
                    cellProductLbl.ForeColor = Color.Black;
                    cellProductLbl.BackColor = Color.LightGray;
                    cellProductLbl.Height = 35;
                    cellProductLbl.Style.Add("Font-Weight", "bold");
                    cellProductLbl.Text = "Product Name";
                    cellProductLbl.HorizontalAlign = HorizontalAlign.Center;
                    cellProductLbl.ColumnSpan = 5;
                    row00.Cells.Add(cellProductLbl);

                    TableCell cellProduct = new TableCell();
                    cellProduct.ForeColor = Color.Black;
                    cellProduct.BackColor = Color.LightGray;
                    cellProduct.Height = 35;
                    cellProduct.Style.Add("Font-Weight", "bold");
                    cellProduct.Text = item.ProductName;
                    cellProduct.HorizontalAlign = HorizontalAlign.Center;
                    cellProduct.ColumnSpan = 5;
                    row00.Cells.Add(cellProduct);

                    TableCell cellClient = new TableCell();
                    cellClient.ForeColor = Color.White;
                    cellClient.Style.Add("Font-Weight", "bold");
                    cellClient.Style.Add("padding", "10px");
                    cellClient.BackColor = Color.Gray;
                    cellClient.Text = "APPLICATION SERVER DETAILS";
                    cellClient.HorizontalAlign = HorizontalAlign.Left;
                    cellClient.ColumnSpan = 10;
                    row1.Cells.Add(cellClient);

                    TableCell cellClientNameLbl = new TableCell();
                    cellClientNameLbl.ForeColor = Color.Black;
                    cellClientNameLbl.Text = "Client Name";
                    cellClientNameLbl.HorizontalAlign = HorizontalAlign.Right;
                    cellClientNameLbl.ColumnSpan = 2;
                    row2.Cells.Add(cellClientNameLbl);

                    TableCell cellClientName = new TableCell();
                    cellClientName.ForeColor = Color.Black;
                    cellClientName.Text = item.ClientName;
                    cellClientName.ColumnSpan = 3;
                    cellClientName.HorizontalAlign = HorizontalAlign.Right;
                    row2.Cells.Add(cellClientName);

                    TableCell cellClientTypeLbl = new TableCell();
                    cellClientTypeLbl.ForeColor = Color.Black;
                    cellClientTypeLbl.Text = "Environment Type";
                    cellClientTypeLbl.ColumnSpan = 2;
                    cellClientTypeLbl.HorizontalAlign = HorizontalAlign.Right;
                    row2.Cells.Add(cellClientTypeLbl);

                    TableCell cellClientType = new TableCell();
                    cellClientType.ForeColor = Color.Black;
                    cellClientType.Text = item.EnvironmentAppServerEnvType;
                    cellClientType.ColumnSpan = 3;
                    cellClientType.HorizontalAlign = HorizontalAlign.Right;
                    row2.Cells.Add(cellClientType);

                    TableCell cellClientEnvTypeLbl = new TableCell();
                    cellClientEnvTypeLbl.ForeColor = Color.Black;
                    cellClientEnvTypeLbl.Text = "Operating System";
                    cellClientEnvTypeLbl.ColumnSpan = 2;
                    cellClientEnvTypeLbl.HorizontalAlign = HorizontalAlign.Right;
                    row3.Cells.Add(cellClientEnvTypeLbl);

                    TableCell cellClientEnvType = new TableCell();
                    cellClientEnvType.ForeColor = Color.Black;
                    cellClientEnvType.Text = item.EnvironmentAppServerOS;
                    cellClientEnvType.ColumnSpan = 3;
                    cellClientEnvType.HorizontalAlign = HorizontalAlign.Right;
                    row3.Cells.Add(cellClientEnvType);

                    TableCell cellClientPOCLbl = new TableCell();
                    cellClientPOCLbl.ForeColor = Color.Black;
                    cellClientPOCLbl.Text = "Operating System Build Number";
                    cellClientPOCLbl.ColumnSpan = 2;
                    cellClientPOCLbl.HorizontalAlign = HorizontalAlign.Right;
                    row3.Cells.Add(cellClientPOCLbl);

                    TableCell cellAppServerOSx86Lbl = new TableCell();
                    cellAppServerOSx86Lbl.ForeColor = Color.Black;
                    cellAppServerOSx86Lbl.Text = "Operating System 32 Bit";
                    cellAppServerOSx86Lbl.ColumnSpan = 2;
                    cellAppServerOSx86Lbl.HorizontalAlign = HorizontalAlign.Right;
                    row7.Cells.Add(cellAppServerOSx86Lbl);

                    TableCell cellAppServerOSx86 = new TableCell();
                    cellAppServerOSx86.ForeColor = Color.Black;
                    cellAppServerOSx86.Text = item.EnvironmentAppServerIsX86Version == "False" ? "No" : "Yes";
                    cellAppServerOSx86.ColumnSpan = 3;
                    cellAppServerOSx86.HorizontalAlign = HorizontalAlign.Right;
                    row7.Cells.Add(cellAppServerOSx86);

                    TableCell cellAppServerOSVirtualLbl = new TableCell();
                    cellAppServerOSVirtualLbl.ForeColor = Color.Black;
                    cellAppServerOSVirtualLbl.Text = "Operating System Is Virtual";
                    cellAppServerOSVirtualLbl.ColumnSpan = 2;
                    cellAppServerOSVirtualLbl.HorizontalAlign = HorizontalAlign.Right;
                    row7.Cells.Add(cellAppServerOSVirtualLbl);

                    TableCell cellAppServerOSVirtual = new TableCell();
                    cellAppServerOSVirtual.ForeColor = Color.Black;
                    cellAppServerOSVirtual.Text = item.EnvironmentAppServerIsVirtual == "False" ? "No" : "Yes";
                    cellAppServerOSVirtual.ColumnSpan = 3;
                    cellAppServerOSVirtual.HorizontalAlign = HorizontalAlign.Right;
                    row7.Cells.Add(cellAppServerOSVirtual);

                    TableCell cellClientPOC = new TableCell();
                    cellClientPOC.ForeColor = Color.Black;
                    cellClientPOC.Text = item.EnvironmentAppServerOSBuild;
                    cellClientPOC.ColumnSpan = 3;
                    cellClientPOC.HorizontalAlign = HorizontalAlign.Right;
                    row3.Cells.Add(cellClientPOC);

                    TableCell cellClientPOCNameLbl = new TableCell();
                    cellClientPOCNameLbl.ForeColor = Color.Black;
                    cellClientPOCNameLbl.Text = "App Server Processor";
                    cellClientPOCNameLbl.ColumnSpan = 2;
                    cellClientPOCNameLbl.HorizontalAlign = HorizontalAlign.Right;
                    row4.Cells.Add(cellClientPOCNameLbl);

                    TableCell cellClientPOCName = new TableCell();
                    cellClientPOCName.ForeColor = Color.Black;
                    cellClientPOCName.Text = item.EnvironmentAppServerProcessor;
                    cellClientPOCName.ColumnSpan = 3;
                    cellClientPOCName.HorizontalAlign = HorizontalAlign.Right;
                    row4.Cells.Add(cellClientPOCName);

                    TableCell cellPatchHotNumberLbl = new TableCell();
                    cellPatchHotNumberLbl.ForeColor = Color.Black;
                    cellPatchHotNumberLbl.Text = "App Server Memory";
                    cellPatchHotNumberLbl.ColumnSpan = 2;
                    cellPatchHotNumberLbl.HorizontalAlign = HorizontalAlign.Right;
                    row4.Cells.Add(cellPatchHotNumberLbl);

                    TableCell cellPatchHotNumber = new TableCell();
                    cellPatchHotNumber.ForeColor = Color.Black;
                    cellPatchHotNumber.Text = item.EnvironmentAppServerMemory;
                    cellPatchHotNumber.ColumnSpan = 3;
                    cellPatchHotNumber.HorizontalAlign = HorizontalAlign.Right;
                    row4.Cells.Add(cellPatchHotNumber);

                    TableCell cellAppServerIPLbl = new TableCell();
                    cellAppServerIPLbl.ForeColor = Color.Black;
                    cellAppServerIPLbl.Text = "IP";
                    cellAppServerIPLbl.ColumnSpan = 2;
                    cellAppServerIPLbl.HorizontalAlign = HorizontalAlign.Right;
                    row5.Cells.Add(cellAppServerIPLbl);

                    TableCell cellAppLink = new TableCell();
                    cellAppLink.ForeColor = Color.Black;
                    cellAppLink.Text = item.EnvironmentAppServerIP;
                    cellAppLink.ColumnSpan = 3;
                    cellAppLink.HorizontalAlign = HorizontalAlign.Right;
                    row5.Cells.Add(cellAppLink);

                    TableCell cellPatchQATestedLbl = new TableCell();
                    cellPatchQATestedLbl.ForeColor = Color.Black;
                    cellPatchQATestedLbl.Text = "Port";
                    cellPatchQATestedLbl.ColumnSpan = 2;
                    cellPatchQATestedLbl.HorizontalAlign = HorizontalAlign.Right;
                    row5.Cells.Add(cellPatchQATestedLbl);

                    TableCell cellPatchQATested = new TableCell();
                    cellPatchQATested.ForeColor = Color.Black;
                    cellPatchQATested.Text = item.EnvironmentAppServerPort;
                    cellPatchQATested.ColumnSpan = 3;
                    cellPatchQATested.HorizontalAlign = HorizontalAlign.Right;
                    row5.Cells.Add(cellPatchQATested);

                    TableCell cellAppServerWebbrowserLbl = new TableCell();
                    cellAppServerWebbrowserLbl.ForeColor = Color.Black;
                    cellAppServerWebbrowserLbl.Text = "Web Server";
                    cellAppServerWebbrowserLbl.ColumnSpan = 2;
                    cellAppServerWebbrowserLbl.HorizontalAlign = HorizontalAlign.Right;
                    row6.Cells.Add(cellAppServerWebbrowserLbl);

                    TableCell cellPatchDeployedDate = new TableCell();
                    cellPatchDeployedDate.ForeColor = Color.Black;
                    cellPatchDeployedDate.Text = item.EnvironmentAppServerWebBrowser;
                    cellPatchDeployedDate.ColumnSpan = 3;
                    cellPatchDeployedDate.HorizontalAlign = HorizontalAlign.Right;
                    row6.Cells.Add(cellPatchDeployedDate);

                    TableCell cellAppServerWebbrowserVersionLbl = new TableCell();
                    cellAppServerWebbrowserVersionLbl.ForeColor = Color.Black;
                    cellAppServerWebbrowserVersionLbl.Text = "Web Server Version";
                    cellAppServerWebbrowserVersionLbl.ColumnSpan = 2;
                    cellAppServerWebbrowserVersionLbl.HorizontalAlign = HorizontalAlign.Right;
                    row6.Cells.Add(cellAppServerWebbrowserVersionLbl);

                    TableCell cellPatchPassedByTime = new TableCell();
                    cellPatchPassedByTime.ForeColor = Color.Black;
                    cellPatchPassedByTime.Text = item.EnvironmentAppServerWebBrowserVersion;
                    cellPatchPassedByTime.ColumnSpan = 3;
                    cellPatchPassedByTime.HorizontalAlign = HorizontalAlign.Right;
                    row6.Cells.Add(cellPatchPassedByTime);

                    TableCell cellAppServerNameLbl = new TableCell();
                    cellAppServerNameLbl.ForeColor = Color.Black;
                    cellAppServerNameLbl.Text = "Server Name";
                    cellAppServerNameLbl.ColumnSpan = 2;
                    cellAppServerNameLbl.HorizontalAlign = HorizontalAlign.Right;
                    row.Cells.Add(cellAppServerNameLbl);

                    TableCell cellAppServerName = new TableCell();
                    cellAppServerName.ForeColor = Color.Black;
                    cellAppServerName.Text = item.EnvironmentAppServerName;
                    cellAppServerName.ColumnSpan = 3;
                    cellAppServerName.HorizontalAlign = HorizontalAlign.Right;
                    row.Cells.Add(cellAppServerName);

                    TableCell cellPatchStatusLbl = new TableCell();
                    cellPatchStatusLbl.ForeColor = Color.Black;
                    cellPatchStatusLbl.Text = "Server Dependency";
                    cellPatchStatusLbl.ColumnSpan = 2;
                    cellPatchStatusLbl.HorizontalAlign = HorizontalAlign.Right;
                    row.Cells.Add(cellPatchStatusLbl);

                    TableCell cellPatchStatus = new TableCell();
                    cellPatchStatus.ForeColor = Color.Black;
                    cellPatchStatus.Text = item.EnvironmentAppServerDependency;
                    cellPatchStatus.ColumnSpan = 3;
                    cellPatchStatus.HorizontalAlign = HorizontalAlign.Right;
                    row.Cells.Add(cellPatchStatus);

                    TableCell cellDBTitle = new TableCell();
                    cellDBTitle.ForeColor = Color.White;
                    cellDBTitle.BackColor = Color.Gray;
                    cellDBTitle.Style.Add("Font-Weight", "bold");
                    cellDBTitle.Style.Add("padding", "10px");
                    cellDBTitle.Text = "DATABASE SERVER DETAILS";
                    cellDBTitle.HorizontalAlign = HorizontalAlign.Left;
                    cellDBTitle.ColumnSpan = 10;
                    row8.Cells.Add(cellDBTitle);

                    TableCell cellDBNameLbl = new TableCell();
                    cellDBNameLbl.ForeColor = Color.Black;
                    cellDBNameLbl.Text = "Server Name";
                    cellDBNameLbl.HorizontalAlign = HorizontalAlign.Right;
                    cellDBNameLbl.ColumnSpan = 2;
                    row9.Cells.Add(cellDBNameLbl);

                    TableCell cellDBName = new TableCell();
                    cellDBName.ForeColor = Color.Black;
                    cellDBName.Text = item.EnvironmentDBServerName;
                    cellDBName.ColumnSpan = 3;
                    cellDBName.HorizontalAlign = HorizontalAlign.Right;
                    row9.Cells.Add(cellDBName);

                    TableCell cellDBServerTypeLbl = new TableCell();
                    cellDBServerTypeLbl.ForeColor = Color.Black;
                    cellDBServerTypeLbl.Text = "Environment Type";
                    cellDBServerTypeLbl.ColumnSpan = 2;
                    cellDBServerTypeLbl.HorizontalAlign = HorizontalAlign.Right;
                    row9.Cells.Add(cellDBServerTypeLbl);

                    TableCell cellDBServerType = new TableCell();
                    cellDBServerType.ForeColor = Color.Black;
                    cellDBServerType.Text = item.EnvironmentDBServerEnvType;
                    cellDBServerType.ColumnSpan = 3;
                    cellDBServerType.HorizontalAlign = HorizontalAlign.Right;
                    row9.Cells.Add(cellDBServerType);

                    TableCell cellDBServerOSLbl = new TableCell();
                    cellDBServerOSLbl.ForeColor = Color.Black;
                    cellDBServerOSLbl.Text = "Operating System";
                    cellDBServerOSLbl.ColumnSpan = 2;
                    cellDBServerOSLbl.HorizontalAlign = HorizontalAlign.Right;
                    row10.Cells.Add(cellDBServerOSLbl);

                    TableCell cellDBServerOS = new TableCell();
                    cellDBServerOS.ForeColor = Color.Black;
                    cellDBServerOS.Text = item.EnvironmentDBServerOS;
                    cellDBServerOS.ColumnSpan = 3;
                    cellDBServerOS.HorizontalAlign = HorizontalAlign.Right;
                    row10.Cells.Add(cellDBServerOS);

                    TableCell cellDBServerOSBuildLbl = new TableCell();
                    cellDBServerOSBuildLbl.ForeColor = Color.Black;
                    cellDBServerOSBuildLbl.Text = "Operating System Build Number";
                    cellDBServerOSBuildLbl.ColumnSpan = 2;
                    cellDBServerOSBuildLbl.HorizontalAlign = HorizontalAlign.Right;
                    row10.Cells.Add(cellDBServerOSBuildLbl);

                    TableCell cellDBServerOSBuild = new TableCell();
                    cellDBServerOSBuild.ForeColor = Color.Black;
                    cellDBServerOSBuild.Text = item.EnvironmentDBServerOSBuild;
                    cellDBServerOSBuild.ColumnSpan = 3;
                    cellDBServerOSBuild.HorizontalAlign = HorizontalAlign.Right;
                    row10.Cells.Add(cellDBServerOSBuild);

                    TableCell cellDBServerOSx86Lbl = new TableCell();
                    cellDBServerOSx86Lbl.ForeColor = Color.Black;
                    cellDBServerOSx86Lbl.Text = "Operating System 32 Bit";
                    cellDBServerOSx86Lbl.ColumnSpan = 2;
                    cellDBServerOSx86Lbl.HorizontalAlign = HorizontalAlign.Right;
                    row11.Cells.Add(cellDBServerOSx86Lbl);

                    TableCell cellDBServerOSx86 = new TableCell();
                    cellDBServerOSx86.ForeColor = Color.Black;
                    cellDBServerOSx86.Text = item.EnvironmentDBServerIsX86Version == "False" ? "No" : "Yes";
                    cellDBServerOSx86.ColumnSpan = 3;
                    cellDBServerOSx86.HorizontalAlign = HorizontalAlign.Right;
                    row11.Cells.Add(cellDBServerOSx86);

                    TableCell cellDBServerOSVirtualLbl = new TableCell();
                    cellDBServerOSVirtualLbl.ForeColor = Color.Black;
                    cellDBServerOSVirtualLbl.Text = "Operating System Is Virtual";
                    cellDBServerOSVirtualLbl.ColumnSpan = 2;
                    cellDBServerOSVirtualLbl.HorizontalAlign = HorizontalAlign.Right;
                    row11.Cells.Add(cellDBServerOSVirtualLbl);

                    TableCell cellDBServerOSVirtual = new TableCell();
                    cellDBServerOSVirtual.ForeColor = Color.Black;
                    cellDBServerOSVirtual.Text = item.EnvironmentDBServerIsVirtual == "False" ? "No" : "Yes";
                    cellDBServerOSVirtual.ColumnSpan = 3;
                    cellDBServerOSVirtual.HorizontalAlign = HorizontalAlign.Right;
                    row11.Cells.Add(cellDBServerOSVirtual);

                    TableCell cellDBServerProcessorLbl = new TableCell();
                    cellDBServerProcessorLbl.ForeColor = Color.Black;
                    cellDBServerProcessorLbl.Text = "Database Server Processor";
                    cellDBServerProcessorLbl.ColumnSpan = 2;
                    cellDBServerProcessorLbl.HorizontalAlign = HorizontalAlign.Right;
                    row12.Cells.Add(cellDBServerProcessorLbl);

                    TableCell cellDBServerProcessor = new TableCell();
                    cellDBServerProcessor.ForeColor = Color.Black;
                    cellDBServerProcessor.Text = item.EnvironmentDBServerProcessor;
                    cellDBServerProcessor.ColumnSpan = 3;
                    cellDBServerProcessor.HorizontalAlign = HorizontalAlign.Right;
                    row12.Cells.Add(cellDBServerProcessor);

                    TableCell cellDBServerMemoryLbl = new TableCell();
                    cellDBServerMemoryLbl.ForeColor = Color.Black;
                    cellDBServerMemoryLbl.Text = "Database Server Memory";
                    cellDBServerMemoryLbl.ColumnSpan = 2;
                    cellDBServerMemoryLbl.HorizontalAlign = HorizontalAlign.Right;
                    row12.Cells.Add(cellDBServerMemoryLbl);

                    TableCell cellDBServerMemory = new TableCell();
                    cellDBServerMemory.ForeColor = Color.Black;
                    cellDBServerMemory.Text = item.EnvironmentDBServerMemory;
                    cellDBServerMemory.ColumnSpan = 3;
                    cellDBServerMemory.HorizontalAlign = HorizontalAlign.Right;
                    row12.Cells.Add(cellDBServerMemory);

                    TableCell cellDBServerIPLbl = new TableCell();
                    cellDBServerIPLbl.ForeColor = Color.Black;
                    cellDBServerIPLbl.Text = "IP";
                    cellDBServerIPLbl.ColumnSpan = 2;
                    cellDBServerIPLbl.HorizontalAlign = HorizontalAlign.Right;
                    row13.Cells.Add(cellDBServerIPLbl);

                    TableCell cellDBServerIP = new TableCell();
                    cellDBServerIP.ForeColor = Color.Black;
                    cellDBServerIP.Text = item.EnvironmentEnvDBServerIP;
                    cellDBServerIP.ColumnSpan = 3;
                    cellDBServerIP.HorizontalAlign = HorizontalAlign.Right;
                    row13.Cells.Add(cellDBServerIP);

                    TableCell cellDBServerPortLbl = new TableCell();
                    cellDBServerPortLbl.ForeColor = Color.Black;
                    cellDBServerPortLbl.Text = "Port";
                    cellDBServerPortLbl.ColumnSpan = 2;
                    cellDBServerPortLbl.HorizontalAlign = HorizontalAlign.Right;
                    row13.Cells.Add(cellDBServerPortLbl);

                    TableCell cellDBServerPort = new TableCell();
                    cellDBServerPort.ForeColor = Color.Black;
                    cellDBServerPort.Text = item.EnvironmentDBServerPort;
                    cellDBServerPort.ColumnSpan = 3;
                    cellDBServerPort.HorizontalAlign = HorizontalAlign.Right;
                    row13.Cells.Add(cellDBServerPort);

                    TableCell cellDBServerMDFFileSizeLbl = new TableCell();
                    cellDBServerMDFFileSizeLbl.ForeColor = Color.Black;
                    cellDBServerMDFFileSizeLbl.Text = "MDF File Size";
                    cellDBServerMDFFileSizeLbl.ColumnSpan = 2;
                    cellDBServerMDFFileSizeLbl.HorizontalAlign = HorizontalAlign.Right;
                    row14.Cells.Add(cellDBServerMDFFileSizeLbl);

                    TableCell cellDBServerMDFFileSize = new TableCell();
                    cellDBServerMDFFileSize.ForeColor = Color.Black;
                    cellDBServerMDFFileSize.Text = item.EnvironmentDBMDFFileSize;
                    cellDBServerMDFFileSize.ColumnSpan = 3;
                    cellDBServerMDFFileSize.HorizontalAlign = HorizontalAlign.Right;
                    row14.Cells.Add(cellDBServerMDFFileSize);

                    TableCell cellDBServerMDFFileLocationLbl = new TableCell();
                    cellDBServerMDFFileLocationLbl.ForeColor = Color.Black;
                    cellDBServerMDFFileLocationLbl.Text = "MDF File Location";
                    cellDBServerMDFFileLocationLbl.ColumnSpan = 2;
                    cellDBServerMDFFileLocationLbl.HorizontalAlign = HorizontalAlign.Right;
                    row14.Cells.Add(cellDBServerMDFFileLocationLbl);

                    TableCell cellDBServerMDFFileLocation = new TableCell();
                    cellDBServerMDFFileLocation.ForeColor = Color.Black;
                    cellDBServerMDFFileLocation.Text = item.EnvironmentDBMDFFileLocation;
                    cellDBServerMDFFileLocation.ColumnSpan = 3;
                    cellDBServerMDFFileLocation.HorizontalAlign = HorizontalAlign.Right;
                    row14.Cells.Add(cellDBServerMDFFileLocation);

                    TableCell cellDBServerLDFFileSizeLbl = new TableCell();
                    cellDBServerLDFFileSizeLbl.ForeColor = Color.Black;
                    cellDBServerLDFFileSizeLbl.Text = "LDF File Size";
                    cellDBServerLDFFileSizeLbl.ColumnSpan = 2;
                    cellDBServerLDFFileSizeLbl.HorizontalAlign = HorizontalAlign.Right;
                    row15.Cells.Add(cellDBServerLDFFileSizeLbl);

                    TableCell cellDBServerLDFFileSize = new TableCell();
                    cellDBServerLDFFileSize.ForeColor = Color.Black;
                    cellDBServerLDFFileSize.Text = item.EnvironmentDBLDFFileSize;
                    cellDBServerLDFFileSize.ColumnSpan = 3;
                    cellDBServerLDFFileSize.HorizontalAlign = HorizontalAlign.Right;
                    row15.Cells.Add(cellDBServerLDFFileSize);

                    TableCell cellDBServerLDFFileLocationLbl = new TableCell();
                    cellDBServerLDFFileLocationLbl.ForeColor = Color.Black;
                    cellDBServerLDFFileLocationLbl.Text = "LDF File Location";
                    cellDBServerLDFFileLocationLbl.ColumnSpan = 2;
                    cellDBServerLDFFileLocationLbl.HorizontalAlign = HorizontalAlign.Right;
                    row15.Cells.Add(cellDBServerLDFFileLocationLbl);

                    TableCell cellDBServerLDFFileLocation = new TableCell();
                    cellDBServerLDFFileLocation.ForeColor = Color.Black;
                    cellDBServerLDFFileLocation.Text = item.EnvironmentDBLDFFileLocation;
                    cellDBServerLDFFileLocation.ColumnSpan = 3;
                    cellDBServerLDFFileLocation.HorizontalAlign = HorizontalAlign.Right;
                    row15.Cells.Add(cellDBServerLDFFileLocation);

                    TableCell cellDBServerLocationLbl = new TableCell();
                    cellDBServerLocationLbl.ForeColor = Color.Black;
                    cellDBServerLocationLbl.Text = "Database File Location";
                    cellDBServerLocationLbl.ColumnSpan = 2;
                    cellDBServerLocationLbl.HorizontalAlign = HorizontalAlign.Right;
                    row16.Cells.Add(cellDBServerLocationLbl);

                    TableCell cellDBServerLocation = new TableCell();
                    cellDBServerLocation.ForeColor = Color.Black;
                    cellDBServerLocation.Text = item.EnvironmentDBServerDirectoryLocation;
                    cellDBServerLocation.ColumnSpan = 3;
                    cellDBServerLocation.HorizontalAlign = HorizontalAlign.Right;
                    row16.Cells.Add(cellDBServerLocation);

                    TableCell cellDBServerDependencyLbl = new TableCell();
                    cellDBServerDependencyLbl.ForeColor = Color.Black;
                    cellDBServerDependencyLbl.Text = "Database Server Dependency";
                    cellDBServerDependencyLbl.ColumnSpan = 2;
                    cellDBServerDependencyLbl.HorizontalAlign = HorizontalAlign.Right;
                    row16.Cells.Add(cellDBServerDependencyLbl);

                    TableCell cellDBServerDependency = new TableCell();
                    cellDBServerDependency.ForeColor = Color.Black;
                    cellDBServerDependency.Text = item.EnvironmentDBServerDependency;
                    cellDBServerDependency.ColumnSpan = 3;
                    cellDBServerDependency.HorizontalAlign = HorizontalAlign.Right;
                    row16.Cells.Add(cellDBServerDependency);

                    tblInfo.Style.Add("width", "100%");
                    tblInfo.Width = 100;
                    tblInfo.Rows.Add(row0);
                    tblInfo.Rows.Add(row00);
                    tblInfo.Rows.Add(row1);
                    tblInfo.Rows.Add(row2);
                    tblInfo.Rows.Add(row3);
                    tblInfo.Rows.Add(row7);
                    tblInfo.Rows.Add(row4);
                    tblInfo.Rows.Add(row5);
                    tblInfo.Rows.Add(row6);
                    tblInfo.Rows.Add(row);
                    tblInfo.Rows.Add(row8);
                    tblInfo.Rows.Add(row9);
                    tblInfo.Rows.Add(row10);
                    tblInfo.Rows.Add(row11);
                    tblInfo.Rows.Add(row12);
                    tblInfo.Rows.Add(row13);
                    tblInfo.Rows.Add(row14);
                    tblInfo.Rows.Add(row15);
                    tblInfo.Rows.Add(row16);
                }
                log.DetailLog("EnvironmentInfo.aspx.cs", "Page_Load", STATE.COMPLETED, "Method: Page_Load Inn Class: EnvironmentInfo.aspx.cs Has Completed Its Execution Successfully.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
                log.ErrorLog("EnvironmentInfo.aspx.cs", "Page_Load", ExceptionType.SQLException, ex);
                log.DetailLog("EnvironmentInfo.aspx.cs", "Page_Load", STATE.INTERRUPTED, ex.Message);
            }
            finally {
                Response.Redirect("ErrorPages\\Error500.aspx?Param=EnvironmentInfo.aspx", true);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                log.DetailLog("EnvironmentInfo.aspx.cs", "Button1_Click", STATE.INITIALIZED, "Method: Button1_Click in Class: EnvironmentInfo.aspx.cs has Initialized.");
                tblInfo.Rows.Clear();
                int product = Convert.ToInt32(DropDownList1.Text);
                int environment = Convert.ToInt32(DropEnvType.Text);
                int client = Convert.ToInt32(DropClientID.Text);
                List<HelloWorld.App_Code.Environment> latestPatchOfClient = dbcon.getClientEnvironmentInfo(product, environment, client);
                int count = 0;
                int total = latestPatchOfClient.Count;
                totalRecords.Text = "Total Number of Records: " + total;
                foreach (var item in latestPatchOfClient)
                {
                    //Debug.WriteLine("Name:" + item.clientName + " | PatchHotNumber: " + item.patchHotNumber + " | PatchDeployedDate: " + item.patchDeployedDate + "\n");

                    TableRow row7 = new TableRow();
                    TableRow row6 = new TableRow();
                    TableRow row5 = new TableRow();
                    TableRow row4 = new TableRow();
                    TableRow row3 = new TableRow();
                    TableRow row2 = new TableRow();
                    TableRow row1 = new TableRow();
                    TableRow row000 = new TableRow();
                    TableRow row00 = new TableRow();
                    TableRow row0 = new TableRow();
                    TableRow row = new TableRow();

                    TableRow row16 = new TableRow();
                    TableRow row15 = new TableRow();
                    TableRow row14 = new TableRow();
                    TableRow row13 = new TableRow();
                    TableRow row12 = new TableRow();
                    TableRow row11 = new TableRow();
                    TableRow row10 = new TableRow();
                    TableRow row9 = new TableRow();
                    TableRow row8 = new TableRow();

                    row.Style.Add("width", "100%");
                    TableCell cellTotal = new TableCell();
                    cellTotal.Height = 22;
                    cellTotal.ForeColor = Color.Black;
                    cellTotal.BackColor = ColorTranslator.FromHtml("#3A4F63");
                    cellTotal.Style.Add("Font-Size", "16px");
                    cellTotal.Style.Add("padding", "5px");
                    cellTotal.Style.Add("Font-Italic", "true");
                    cellTotal.Text = "Total Number of Records: " + total;
                    cellTotal.BackColor = Color.LightBlue;
                    cellTotal.HorizontalAlign = HorizontalAlign.Left;
                    cellTotal.ColumnSpan = 8;
                    row000.Cells.Add(cellTotal);

                    TableCell cellClient1 = new TableCell();
                    cellClient1.Height = 40;
                    cellClient1.ForeColor = Color.White;
                    cellClient1.BackColor = ColorTranslator.FromHtml("#3A4F63");
                    cellClient1.Style.Add("Font-Size", "22px");
                    cellClient1.Text = "Environment " + ++count;
                    cellClient1.HorizontalAlign = HorizontalAlign.Center;
                    cellClient1.ColumnSpan = 10;
                    row0.Cells.Add(cellClient1);

                    TableCell cellProductLbl = new TableCell();
                    cellProductLbl.ForeColor = Color.Black;
                    cellProductLbl.BackColor = Color.LightGray;
                    cellProductLbl.Height = 35;
                    cellProductLbl.Style.Add("Font-Weight", "bold");
                    cellProductLbl.Text = "Product Name";
                    cellProductLbl.HorizontalAlign = HorizontalAlign.Center;
                    cellProductLbl.ColumnSpan = 5;
                    row00.Cells.Add(cellProductLbl);

                    TableCell cellProduct = new TableCell();
                    cellProduct.ForeColor = Color.Black;
                    cellProduct.BackColor = Color.LightGray;
                    cellProduct.Height = 35;
                    cellProduct.Style.Add("Font-Weight", "bold");
                    cellProduct.Text = item.ProductName;
                    cellProduct.HorizontalAlign = HorizontalAlign.Center;
                    cellProduct.ColumnSpan = 5;
                    row00.Cells.Add(cellProduct);

                    TableCell cellClient = new TableCell();
                    cellClient.ForeColor = Color.White;
                    cellClient.Style.Add("Font-Weight", "bold");
                    cellClient.Style.Add("padding", "10px");
                    cellClient.BackColor = Color.Gray;
                    cellClient.Text = "APPLICATION SERVER DETAILS";
                    cellClient.HorizontalAlign = HorizontalAlign.Left;
                    cellClient.ColumnSpan = 10;
                    row1.Cells.Add(cellClient);

                    TableCell cellClientNameLbl = new TableCell();
                    cellClientNameLbl.ForeColor = Color.Black;
                    cellClientNameLbl.Text = "Client Name";
                    cellClientNameLbl.HorizontalAlign = HorizontalAlign.Right;
                    cellClientNameLbl.ColumnSpan = 2;
                    row2.Cells.Add(cellClientNameLbl);

                    TableCell cellClientName = new TableCell();
                    cellClientName.ForeColor = Color.Black;
                    cellClientName.Text = item.ClientName;
                    cellClientName.ColumnSpan = 3;
                    cellClientName.HorizontalAlign = HorizontalAlign.Right;
                    row2.Cells.Add(cellClientName);

                    TableCell cellClientTypeLbl = new TableCell();
                    cellClientTypeLbl.ForeColor = Color.Black;
                    cellClientTypeLbl.Text = "Environment Type";
                    cellClientTypeLbl.ColumnSpan = 2;
                    cellClientTypeLbl.HorizontalAlign = HorizontalAlign.Right;
                    row2.Cells.Add(cellClientTypeLbl);

                    TableCell cellClientType = new TableCell();
                    cellClientType.ForeColor = Color.Black;
                    cellClientType.Text = item.EnvironmentAppServerEnvType;
                    cellClientType.ColumnSpan = 3;
                    cellClientType.HorizontalAlign = HorizontalAlign.Right;
                    row2.Cells.Add(cellClientType);

                    TableCell cellClientEnvTypeLbl = new TableCell();
                    cellClientEnvTypeLbl.ForeColor = Color.Black;
                    cellClientEnvTypeLbl.Text = "Operating System";
                    cellClientEnvTypeLbl.ColumnSpan = 2;
                    cellClientEnvTypeLbl.HorizontalAlign = HorizontalAlign.Right;
                    row3.Cells.Add(cellClientEnvTypeLbl);

                    TableCell cellClientEnvType = new TableCell();
                    cellClientEnvType.ForeColor = Color.Black;
                    cellClientEnvType.Text = item.EnvironmentAppServerOS;
                    cellClientEnvType.ColumnSpan = 3;
                    cellClientEnvType.HorizontalAlign = HorizontalAlign.Right;
                    row3.Cells.Add(cellClientEnvType);

                    TableCell cellClientPOCLbl = new TableCell();
                    cellClientPOCLbl.ForeColor = Color.Black;
                    cellClientPOCLbl.Text = "Operating System Build Number";
                    cellClientPOCLbl.ColumnSpan = 2;
                    cellClientPOCLbl.HorizontalAlign = HorizontalAlign.Right;
                    row3.Cells.Add(cellClientPOCLbl);

                    TableCell cellAppServerOSx86Lbl = new TableCell();
                    cellAppServerOSx86Lbl.ForeColor = Color.Black;
                    cellAppServerOSx86Lbl.Text = "Operating System 32 Bit";
                    cellAppServerOSx86Lbl.ColumnSpan = 2;
                    cellAppServerOSx86Lbl.HorizontalAlign = HorizontalAlign.Right;
                    row7.Cells.Add(cellAppServerOSx86Lbl);

                    TableCell cellAppServerOSx86 = new TableCell();
                    cellAppServerOSx86.ForeColor = Color.Black;
                    cellAppServerOSx86.Text = item.EnvironmentAppServerIsX86Version == "False" ? "No" : "Yes";
                    cellAppServerOSx86.ColumnSpan = 3;
                    cellAppServerOSx86.HorizontalAlign = HorizontalAlign.Right;
                    row7.Cells.Add(cellAppServerOSx86);

                    TableCell cellAppServerOSVirtualLbl = new TableCell();
                    cellAppServerOSVirtualLbl.ForeColor = Color.Black;
                    cellAppServerOSVirtualLbl.Text = "Operating System Is Virtual";
                    cellAppServerOSVirtualLbl.ColumnSpan = 2;
                    cellAppServerOSVirtualLbl.HorizontalAlign = HorizontalAlign.Right;
                    row7.Cells.Add(cellAppServerOSVirtualLbl);

                    TableCell cellAppServerOSVirtual = new TableCell();
                    cellAppServerOSVirtual.ForeColor = Color.Black;
                    cellAppServerOSVirtual.Text = item.EnvironmentAppServerIsVirtual == "False" ? "No" : "Yes";
                    cellAppServerOSVirtual.ColumnSpan = 3;
                    cellAppServerOSVirtual.HorizontalAlign = HorizontalAlign.Right;
                    row7.Cells.Add(cellAppServerOSVirtual);

                    TableCell cellClientPOC = new TableCell();
                    cellClientPOC.ForeColor = Color.Black;
                    cellClientPOC.Text = item.EnvironmentAppServerOSBuild;
                    cellClientPOC.ColumnSpan = 3;
                    cellClientPOC.HorizontalAlign = HorizontalAlign.Right;
                    row3.Cells.Add(cellClientPOC);

                    TableCell cellClientPOCNameLbl = new TableCell();
                    cellClientPOCNameLbl.ForeColor = Color.Black;
                    cellClientPOCNameLbl.Text = "App Server Processor";
                    cellClientPOCNameLbl.ColumnSpan = 2;
                    cellClientPOCNameLbl.HorizontalAlign = HorizontalAlign.Right;
                    row4.Cells.Add(cellClientPOCNameLbl);

                    TableCell cellClientPOCName = new TableCell();
                    cellClientPOCName.ForeColor = Color.Black;
                    cellClientPOCName.Text = item.EnvironmentAppServerProcessor;
                    cellClientPOCName.ColumnSpan = 3;
                    cellClientPOCName.HorizontalAlign = HorizontalAlign.Right;
                    row4.Cells.Add(cellClientPOCName);

                    TableCell cellPatchHotNumberLbl = new TableCell();
                    cellPatchHotNumberLbl.ForeColor = Color.Black;
                    cellPatchHotNumberLbl.Text = "App Server Memory";
                    cellPatchHotNumberLbl.ColumnSpan = 2;
                    cellPatchHotNumberLbl.HorizontalAlign = HorizontalAlign.Right;
                    row4.Cells.Add(cellPatchHotNumberLbl);

                    TableCell cellPatchHotNumber = new TableCell();
                    cellPatchHotNumber.ForeColor = Color.Black;
                    cellPatchHotNumber.Text = item.EnvironmentAppServerMemory;
                    cellPatchHotNumber.ColumnSpan = 3;
                    cellPatchHotNumber.HorizontalAlign = HorizontalAlign.Right;
                    row4.Cells.Add(cellPatchHotNumber);

                    TableCell cellAppServerIPLbl = new TableCell();
                    cellAppServerIPLbl.ForeColor = Color.Black;
                    cellAppServerIPLbl.Text = "IP";
                    cellAppServerIPLbl.ColumnSpan = 2;
                    cellAppServerIPLbl.HorizontalAlign = HorizontalAlign.Right;
                    row5.Cells.Add(cellAppServerIPLbl);

                    TableCell cellAppLink = new TableCell();
                    cellAppLink.ForeColor = Color.Black;
                    cellAppLink.Text = item.EnvironmentAppServerIP;
                    cellAppLink.ColumnSpan = 3;
                    cellAppLink.HorizontalAlign = HorizontalAlign.Right;
                    row5.Cells.Add(cellAppLink);

                    TableCell cellPatchQATestedLbl = new TableCell();
                    cellPatchQATestedLbl.ForeColor = Color.Black;
                    cellPatchQATestedLbl.Text = "Port";
                    cellPatchQATestedLbl.ColumnSpan = 2;
                    cellPatchQATestedLbl.HorizontalAlign = HorizontalAlign.Right;
                    row5.Cells.Add(cellPatchQATestedLbl);

                    TableCell cellPatchQATested = new TableCell();
                    cellPatchQATested.ForeColor = Color.Black;
                    cellPatchQATested.Text = item.EnvironmentAppServerPort;
                    cellPatchQATested.ColumnSpan = 3;
                    cellPatchQATested.HorizontalAlign = HorizontalAlign.Right;
                    row5.Cells.Add(cellPatchQATested);

                    TableCell cellAppServerWebbrowserLbl = new TableCell();
                    cellAppServerWebbrowserLbl.ForeColor = Color.Black;
                    //int spaceInDate = item.patchDeployedDate.IndexOf(' ');
                    cellAppServerWebbrowserLbl.Text = "Web Server";
                    cellAppServerWebbrowserLbl.ColumnSpan = 2;
                    cellAppServerWebbrowserLbl.HorizontalAlign = HorizontalAlign.Right;
                    row6.Cells.Add(cellAppServerWebbrowserLbl);

                    TableCell cellPatchDeployedDate = new TableCell();
                    cellPatchDeployedDate.ForeColor = Color.Black;
                    //int spaceInDate = item.patchDeployedDate.IndexOf(' ');
                    cellPatchDeployedDate.Text = item.EnvironmentAppServerWebBrowser;
                    cellPatchDeployedDate.ColumnSpan = 3;
                    cellPatchDeployedDate.HorizontalAlign = HorizontalAlign.Right;
                    row6.Cells.Add(cellPatchDeployedDate);

                    //

                    TableCell cellAppServerWebbrowserVersionLbl = new TableCell();
                    cellAppServerWebbrowserVersionLbl.ForeColor = Color.Black;
                    cellAppServerWebbrowserVersionLbl.Text = "Web Server Version";
                    cellAppServerWebbrowserVersionLbl.ColumnSpan = 2;
                    cellAppServerWebbrowserVersionLbl.HorizontalAlign = HorizontalAlign.Right;
                    row6.Cells.Add(cellAppServerWebbrowserVersionLbl);

                    TableCell cellPatchPassedByTime = new TableCell();
                    cellPatchPassedByTime.ForeColor = Color.Black;
                    cellPatchPassedByTime.Text = item.EnvironmentAppServerWebBrowserVersion;
                    cellPatchPassedByTime.ColumnSpan = 3;
                    cellPatchPassedByTime.HorizontalAlign = HorizontalAlign.Right;
                    row6.Cells.Add(cellPatchPassedByTime);

                    TableCell cellAppServerNameLbl = new TableCell();
                    cellAppServerNameLbl.ForeColor = Color.Black;
                    cellAppServerNameLbl.Text = "Server Name";
                    cellAppServerNameLbl.ColumnSpan = 2;
                    cellAppServerNameLbl.HorizontalAlign = HorizontalAlign.Right;
                    row.Cells.Add(cellAppServerNameLbl);

                    TableCell cellAppServerName = new TableCell();
                    cellAppServerName.ForeColor = Color.Black;
                    cellAppServerName.Text = item.EnvironmentAppServerName;
                    cellAppServerName.ColumnSpan = 3;
                    cellAppServerName.HorizontalAlign = HorizontalAlign.Right;
                    row.Cells.Add(cellAppServerName);

                    TableCell cellPatchStatusLbl = new TableCell();
                    cellPatchStatusLbl.ForeColor = Color.Black;
                    cellPatchStatusLbl.Text = "Server Dependency";
                    cellPatchStatusLbl.ColumnSpan = 2;
                    cellPatchStatusLbl.HorizontalAlign = HorizontalAlign.Right;
                    row.Cells.Add(cellPatchStatusLbl);

                    TableCell cellPatchStatus = new TableCell();
                    cellPatchStatus.ForeColor = Color.Black;
                    cellPatchStatus.Text = item.EnvironmentAppServerDependency;
                    cellPatchStatus.ColumnSpan = 3;
                    cellPatchStatus.HorizontalAlign = HorizontalAlign.Right;
                    row.Cells.Add(cellPatchStatus);
                    //

                    TableCell cellDBTitle = new TableCell();
                    cellDBTitle.ForeColor = Color.White;
                    cellDBTitle.BackColor = Color.Gray;
                    cellDBTitle.Style.Add("Font-Weight", "bold");
                    cellDBTitle.Style.Add("padding", "10px");
                    cellDBTitle.Text = "DATABASE SERVER DETAILS";
                    //cellDBTitle.Attributes.Add("padding", "10px");
                    cellDBTitle.HorizontalAlign = HorizontalAlign.Left;
                    cellDBTitle.ColumnSpan = 10;
                    row8.Cells.Add(cellDBTitle);

                    TableCell cellDBNameLbl = new TableCell();
                    cellDBNameLbl.ForeColor = Color.Black;
                    cellDBNameLbl.Text = "Server Name";
                    cellDBNameLbl.HorizontalAlign = HorizontalAlign.Right;
                    cellDBNameLbl.ColumnSpan = 2;
                    row9.Cells.Add(cellDBNameLbl);

                    TableCell cellDBName = new TableCell();
                    cellDBName.ForeColor = Color.Black;
                    cellDBName.Text = item.EnvironmentDBServerName;
                    cellDBName.ColumnSpan = 3;
                    cellDBName.HorizontalAlign = HorizontalAlign.Right;
                    row9.Cells.Add(cellDBName);

                    TableCell cellDBServerTypeLbl = new TableCell();
                    cellDBServerTypeLbl.ForeColor = Color.Black;
                    cellDBServerTypeLbl.Text = "Environment Type";
                    cellDBServerTypeLbl.ColumnSpan = 2;
                    cellDBServerTypeLbl.HorizontalAlign = HorizontalAlign.Right;
                    row9.Cells.Add(cellDBServerTypeLbl);

                    TableCell cellDBServerType = new TableCell();
                    cellDBServerType.ForeColor = Color.Black;
                    cellDBServerType.Text = item.EnvironmentDBServerEnvType;
                    cellDBServerType.ColumnSpan = 3;
                    cellDBServerType.HorizontalAlign = HorizontalAlign.Right;
                    row9.Cells.Add(cellDBServerType);

                    TableCell cellDBServerOSLbl = new TableCell();
                    cellDBServerOSLbl.ForeColor = Color.Black;
                    cellDBServerOSLbl.Text = "Operating System";
                    cellDBServerOSLbl.ColumnSpan = 2;
                    cellDBServerOSLbl.HorizontalAlign = HorizontalAlign.Right;
                    row10.Cells.Add(cellDBServerOSLbl);

                    TableCell cellDBServerOS = new TableCell();
                    cellDBServerOS.ForeColor = Color.Black;
                    cellDBServerOS.Text = item.EnvironmentDBServerOS;
                    cellDBServerOS.ColumnSpan = 3;
                    cellDBServerOS.HorizontalAlign = HorizontalAlign.Right;
                    row10.Cells.Add(cellDBServerOS);

                    TableCell cellDBServerOSBuildLbl = new TableCell();
                    cellDBServerOSBuildLbl.ForeColor = Color.Black;
                    cellDBServerOSBuildLbl.Text = "Operating System Build Number";
                    cellDBServerOSBuildLbl.ColumnSpan = 2;
                    cellDBServerOSBuildLbl.HorizontalAlign = HorizontalAlign.Right;
                    row10.Cells.Add(cellDBServerOSBuildLbl);

                    TableCell cellDBServerOSBuild = new TableCell();
                    cellDBServerOSBuild.ForeColor = Color.Black;
                    cellDBServerOSBuild.Text = item.EnvironmentDBServerOSBuild;
                    cellDBServerOSBuild.ColumnSpan = 3;
                    cellDBServerOSBuild.HorizontalAlign = HorizontalAlign.Right;
                    row10.Cells.Add(cellDBServerOSBuild);

                    TableCell cellDBServerOSx86Lbl = new TableCell();
                    cellDBServerOSx86Lbl.ForeColor = Color.Black;
                    cellDBServerOSx86Lbl.Text = "Operating System 32 Bit";
                    cellDBServerOSx86Lbl.ColumnSpan = 2;
                    cellDBServerOSx86Lbl.HorizontalAlign = HorizontalAlign.Right;
                    row11.Cells.Add(cellDBServerOSx86Lbl);

                    TableCell cellDBServerOSx86 = new TableCell();
                    cellDBServerOSx86.ForeColor = Color.Black;
                    cellDBServerOSx86.Text = item.EnvironmentDBServerIsX86Version == "False" ? "No" : "Yes";
                    cellDBServerOSx86.ColumnSpan = 3;
                    cellDBServerOSx86.HorizontalAlign = HorizontalAlign.Right;
                    row11.Cells.Add(cellDBServerOSx86);

                    TableCell cellDBServerOSVirtualLbl = new TableCell();
                    cellDBServerOSVirtualLbl.ForeColor = Color.Black;
                    cellDBServerOSVirtualLbl.Text = "Operating System Is Virtual";
                    cellDBServerOSVirtualLbl.ColumnSpan = 2;
                    cellDBServerOSVirtualLbl.HorizontalAlign = HorizontalAlign.Right;
                    row11.Cells.Add(cellDBServerOSVirtualLbl);

                    TableCell cellDBServerOSVirtual = new TableCell();
                    cellDBServerOSVirtual.ForeColor = Color.Black;
                    cellDBServerOSVirtual.Text = item.EnvironmentDBServerIsVirtual == "False" ? "No" : "Yes";
                    cellDBServerOSVirtual.ColumnSpan = 3;
                    cellDBServerOSVirtual.HorizontalAlign = HorizontalAlign.Right;
                    row11.Cells.Add(cellDBServerOSVirtual);

                    TableCell cellDBServerProcessorLbl = new TableCell();
                    cellDBServerProcessorLbl.ForeColor = Color.Black;
                    cellDBServerProcessorLbl.Text = "Database Server Processor";
                    cellDBServerProcessorLbl.ColumnSpan = 2;
                    cellDBServerProcessorLbl.HorizontalAlign = HorizontalAlign.Right;
                    row12.Cells.Add(cellDBServerProcessorLbl);

                    TableCell cellDBServerProcessor = new TableCell();
                    cellDBServerProcessor.ForeColor = Color.Black;
                    cellDBServerProcessor.Text = item.EnvironmentDBServerProcessor;
                    cellDBServerProcessor.ColumnSpan = 3;
                    cellDBServerProcessor.HorizontalAlign = HorizontalAlign.Right;
                    row12.Cells.Add(cellDBServerProcessor);

                    TableCell cellDBServerMemoryLbl = new TableCell();
                    cellDBServerMemoryLbl.ForeColor = Color.Black;
                    cellDBServerMemoryLbl.Text = "Database Server Memory";
                    cellDBServerMemoryLbl.ColumnSpan = 2;
                    cellDBServerMemoryLbl.HorizontalAlign = HorizontalAlign.Right;
                    row12.Cells.Add(cellDBServerMemoryLbl);

                    TableCell cellDBServerMemory = new TableCell();
                    cellDBServerMemory.ForeColor = Color.Black;
                    cellDBServerMemory.Text = item.EnvironmentDBServerMemory;
                    cellDBServerMemory.ColumnSpan = 3;
                    cellDBServerMemory.HorizontalAlign = HorizontalAlign.Right;
                    row12.Cells.Add(cellDBServerMemory);

                    TableCell cellDBServerIPLbl = new TableCell();
                    cellDBServerIPLbl.ForeColor = Color.Black;
                    cellDBServerIPLbl.Text = "IP";
                    cellDBServerIPLbl.ColumnSpan = 2;
                    cellDBServerIPLbl.HorizontalAlign = HorizontalAlign.Right;
                    row13.Cells.Add(cellDBServerIPLbl);

                    TableCell cellDBServerIP = new TableCell();
                    cellDBServerIP.ForeColor = Color.Black;
                    cellDBServerIP.Text = item.EnvironmentEnvDBServerIP;
                    cellDBServerIP.ColumnSpan = 3;
                    cellDBServerIP.HorizontalAlign = HorizontalAlign.Right;
                    row13.Cells.Add(cellDBServerIP);

                    TableCell cellDBServerPortLbl = new TableCell();
                    cellDBServerPortLbl.ForeColor = Color.Black;
                    cellDBServerPortLbl.Text = "Port";
                    cellDBServerPortLbl.ColumnSpan = 2;
                    cellDBServerPortLbl.HorizontalAlign = HorizontalAlign.Right;
                    row13.Cells.Add(cellDBServerPortLbl);

                    TableCell cellDBServerPort = new TableCell();
                    cellDBServerPort.ForeColor = Color.Black;
                    cellDBServerPort.Text = item.EnvironmentDBServerPort;
                    cellDBServerPort.ColumnSpan = 3;
                    cellDBServerPort.HorizontalAlign = HorizontalAlign.Right;
                    row13.Cells.Add(cellDBServerPort);

                    TableCell cellDBServerMDFFileSizeLbl = new TableCell();
                    cellDBServerMDFFileSizeLbl.ForeColor = Color.Black;
                    cellDBServerMDFFileSizeLbl.Text = "MDF File Size";
                    cellDBServerMDFFileSizeLbl.ColumnSpan = 2;
                    cellDBServerMDFFileSizeLbl.HorizontalAlign = HorizontalAlign.Right;
                    row14.Cells.Add(cellDBServerMDFFileSizeLbl);

                    TableCell cellDBServerMDFFileSize = new TableCell();
                    cellDBServerMDFFileSize.ForeColor = Color.Black;
                    cellDBServerMDFFileSize.Text = item.EnvironmentDBMDFFileSize;
                    cellDBServerMDFFileSize.ColumnSpan = 3;
                    cellDBServerMDFFileSize.HorizontalAlign = HorizontalAlign.Right;
                    row14.Cells.Add(cellDBServerMDFFileSize);

                    TableCell cellDBServerMDFFileLocationLbl = new TableCell();
                    cellDBServerMDFFileLocationLbl.ForeColor = Color.Black;
                    //int spaceInDate = item.patchDeployedDate.IndexOf(' ');
                    cellDBServerMDFFileLocationLbl.Text = "MDF File Location";
                    cellDBServerMDFFileLocationLbl.ColumnSpan = 2;
                    cellDBServerMDFFileLocationLbl.HorizontalAlign = HorizontalAlign.Right;
                    row14.Cells.Add(cellDBServerMDFFileLocationLbl);

                    TableCell cellDBServerMDFFileLocation = new TableCell();
                    cellDBServerMDFFileLocation.ForeColor = Color.Black;
                    //int spaceInDate = item.patchDeployedDate.IndexOf(' ');
                    cellDBServerMDFFileLocation.Text = item.EnvironmentDBMDFFileLocation;
                    cellDBServerMDFFileLocation.ColumnSpan = 3;
                    cellDBServerMDFFileLocation.HorizontalAlign = HorizontalAlign.Right;
                    row14.Cells.Add(cellDBServerMDFFileLocation);

                    TableCell cellDBServerLDFFileSizeLbl = new TableCell();
                    cellDBServerLDFFileSizeLbl.ForeColor = Color.Black;
                    //int spaceInDate = item.patchDeployedDate.IndexOf(' ');
                    cellDBServerLDFFileSizeLbl.Text = "LDF File Size";
                    cellDBServerLDFFileSizeLbl.ColumnSpan = 2;
                    cellDBServerLDFFileSizeLbl.HorizontalAlign = HorizontalAlign.Right;
                    row15.Cells.Add(cellDBServerLDFFileSizeLbl);

                    TableCell cellDBServerLDFFileSize = new TableCell();
                    cellDBServerLDFFileSize.ForeColor = Color.Black;
                    //int spaceInDate = item.patchDeployedDate.IndexOf(' ');
                    cellDBServerLDFFileSize.Text = item.EnvironmentDBLDFFileSize;
                    cellDBServerLDFFileSize.ColumnSpan = 3;
                    cellDBServerLDFFileSize.HorizontalAlign = HorizontalAlign.Right;
                    row15.Cells.Add(cellDBServerLDFFileSize);

                    TableCell cellDBServerLDFFileLocationLbl = new TableCell();
                    cellDBServerLDFFileLocationLbl.ForeColor = Color.Black;
                    //int spaceInDate = item.patchDeployedDate.IndexOf(' ');
                    cellDBServerLDFFileLocationLbl.Text = "LDF File Location";
                    cellDBServerLDFFileLocationLbl.ColumnSpan = 2;
                    cellDBServerLDFFileLocationLbl.HorizontalAlign = HorizontalAlign.Right;
                    row15.Cells.Add(cellDBServerLDFFileLocationLbl);

                    TableCell cellDBServerLDFFileLocation = new TableCell();
                    cellDBServerLDFFileLocation.ForeColor = Color.Black;
                    //int spaceInDate = item.patchDeployedDate.IndexOf(' ');
                    cellDBServerLDFFileLocation.Text = item.EnvironmentDBLDFFileLocation;
                    cellDBServerLDFFileLocation.ColumnSpan = 3;
                    cellDBServerLDFFileLocation.HorizontalAlign = HorizontalAlign.Right;
                    row15.Cells.Add(cellDBServerLDFFileLocation);

                    //

                    TableCell cellDBServerLocationLbl = new TableCell();
                    cellDBServerLocationLbl.ForeColor = Color.Black;
                    cellDBServerLocationLbl.Text = "Database File Location";
                    cellDBServerLocationLbl.ColumnSpan = 2;
                    cellDBServerLocationLbl.HorizontalAlign = HorizontalAlign.Right;
                    row16.Cells.Add(cellDBServerLocationLbl);

                    TableCell cellDBServerLocation = new TableCell();
                    cellDBServerLocation.ForeColor = Color.Black;
                    cellDBServerLocation.Text = item.EnvironmentDBServerDirectoryLocation;
                    cellDBServerLocation.ColumnSpan = 3;
                    cellDBServerLocation.HorizontalAlign = HorizontalAlign.Right;
                    row16.Cells.Add(cellDBServerLocation);

                    TableCell cellDBServerDependencyLbl = new TableCell();
                    cellDBServerDependencyLbl.ForeColor = Color.Black;
                    cellDBServerDependencyLbl.Text = "Database Server Dependency";
                    cellDBServerDependencyLbl.ColumnSpan = 2;
                    cellDBServerDependencyLbl.HorizontalAlign = HorizontalAlign.Right;
                    row16.Cells.Add(cellDBServerDependencyLbl);

                    TableCell cellDBServerDependency = new TableCell();
                    cellDBServerDependency.ForeColor = Color.Black;
                    cellDBServerDependency.Text = item.EnvironmentDBServerDependency;
                    cellDBServerDependency.ColumnSpan = 3;
                    cellDBServerDependency.HorizontalAlign = HorizontalAlign.Right;
                    row16.Cells.Add(cellDBServerDependency);

                    tblInfo.Style.Add("width", "100%");
                    tblInfo.Width = 100;
                    tblInfo.Rows.Add(row000);
                    tblInfo.Rows.Add(row0);
                    tblInfo.Rows.Add(row00);
                    tblInfo.Rows.Add(row1);
                    tblInfo.Rows.Add(row2);
                    tblInfo.Rows.Add(row3);
                    tblInfo.Rows.Add(row7);
                    tblInfo.Rows.Add(row4);
                    tblInfo.Rows.Add(row5);
                    tblInfo.Rows.Add(row6);
                    tblInfo.Rows.Add(row);
                    tblInfo.Rows.Add(row8);
                    tblInfo.Rows.Add(row9);
                    tblInfo.Rows.Add(row10);
                    tblInfo.Rows.Add(row11);
                    tblInfo.Rows.Add(row12);
                    tblInfo.Rows.Add(row13);
                    tblInfo.Rows.Add(row14);
                    tblInfo.Rows.Add(row15);
                    tblInfo.Rows.Add(row16);

                }

                log.DetailLog("EnvironmentInfo.aspx.cs", "Button1_Click", STATE.COMPLETED, "Method: Page_Load Inn Class: EnvironmentInfo.aspx.cs Has Completed Its Execution Successfully.");

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
                log.ErrorLog("EnvironmentInfo.aspx.cs", "Button1_Click", ExceptionType.SQLException, ex);
                log.DetailLog("EnvironmentInfo.aspx.cs", "Button1_Click", STATE.INTERRUPTED, ex.Message);
            }
            finally
            {
                Response.Redirect("ErrorPages\\Error500.aspx?Param=EnvironmentInfo.aspx", true);
            }
        }
    }
}