using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using HelloWorld.App_Code;
using System.Diagnostics;

namespace HelloWorld
{
    public partial class Live : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Debug.WriteLine("Product: " + DropDownList1.Text);
            //Console.WriteLine("GGG");

            DatabaseConnectivity dbcon = new DatabaseConnectivity();
            List<Patch> latestPatchOfClient = dbcon.getAllUpdatedClientPatches(4, 1);

            //HEADER COLUMN START

            TableRow rowHeader = new TableRow();

            TableCell cellClientNameHeader = new TableCell();
            cellClientNameHeader.BackColor = ColorTranslator.FromHtml("#004D40");
            cellClientNameHeader.ForeColor = ColorTranslator.FromHtml("#fff");
            cellClientNameHeader.Font.Name = "Arial Black";
            cellClientNameHeader.Font.Size = FontUnit.Parse("9");
            cellClientNameHeader.Style.Add("padding", "5px");
            cellClientNameHeader.Text = "Client Name";
            cellClientNameHeader.HorizontalAlign = HorizontalAlign.Center;
            rowHeader.Cells.Add(cellClientNameHeader);
            TableCell cellClientTypeHeader = new TableCell();
            cellClientTypeHeader.BackColor = ColorTranslator.FromHtml("#004D40");
            cellClientTypeHeader.ForeColor = ColorTranslator.FromHtml("#fff");
            cellClientTypeHeader.Font.Name = "Arial Black";
            cellClientTypeHeader.Font.Size = FontUnit.Parse("9");
            cellClientTypeHeader.Style.Add("padding", "5px");
            cellClientTypeHeader.Text = "Type";
            cellClientTypeHeader.HorizontalAlign = HorizontalAlign.Center;
            rowHeader.Cells.Add(cellClientTypeHeader);

            TableCell cellClientEnvTypeHeader = new TableCell();
            cellClientEnvTypeHeader.BackColor = ColorTranslator.FromHtml("#004D40");
            cellClientEnvTypeHeader.ForeColor = ColorTranslator.FromHtml("#fff");
            cellClientEnvTypeHeader.Font.Name = "Arial Black";
            cellClientEnvTypeHeader.Font.Size = FontUnit.Parse("9");
            cellClientEnvTypeHeader.Style.Add("padding", "5px");
            cellClientEnvTypeHeader.Text = "Environment";
            cellClientEnvTypeHeader.HorizontalAlign = HorizontalAlign.Center;
            rowHeader.Cells.Add(cellClientEnvTypeHeader);

            TableCell cellClientPOCHeader = new TableCell();
            cellClientPOCHeader.BackColor = ColorTranslator.FromHtml("#004D40");
            cellClientPOCHeader.ForeColor = ColorTranslator.FromHtml("#fff");
            cellClientPOCHeader.Font.Name = "Arial Black";
            cellClientPOCHeader.Font.Size = FontUnit.Parse("9");
            cellClientPOCHeader.Style.Add("padding", "5px");
            cellClientPOCHeader.Text = "POC";
            cellClientPOCHeader.HorizontalAlign = HorizontalAlign.Center;
            rowHeader.Cells.Add(cellClientPOCHeader);

            TableCell cellClientPOCNameHeader = new TableCell();
            cellClientPOCNameHeader.BackColor = ColorTranslator.FromHtml("#004D40");
            cellClientPOCNameHeader.ForeColor = ColorTranslator.FromHtml("#fff");
            cellClientPOCNameHeader.Font.Name = "Arial Black";
            cellClientPOCNameHeader.Font.Size = FontUnit.Parse("9");
            cellClientPOCNameHeader.Style.Add("padding", "5px");
            cellClientPOCNameHeader.Text = "Total Releases";
            cellClientPOCNameHeader.HorizontalAlign = HorizontalAlign.Center;
            rowHeader.Cells.Add(cellClientPOCNameHeader);

            TableCell cellPatchHotNumberHeader = new TableCell();
            cellPatchHotNumberHeader.BackColor = ColorTranslator.FromHtml("#004D40");
            cellPatchHotNumberHeader.ForeColor = ColorTranslator.FromHtml("#fff");
            cellPatchHotNumberHeader.Font.Name = "Arial Black";
            cellPatchHotNumberHeader.Font.Size = FontUnit.Parse("9");
            cellPatchHotNumberHeader.Style.Add("padding", "5px");
            cellPatchHotNumberHeader.Text = "Updated Release";
            cellPatchHotNumberHeader.HorizontalAlign = HorizontalAlign.Center;
            rowHeader.Cells.Add(cellPatchHotNumberHeader);

            TableCell cellPatchQATestedHeader = new TableCell();
            cellPatchQATestedHeader.BackColor = ColorTranslator.FromHtml("#004D40");
            cellPatchQATestedHeader.ForeColor = ColorTranslator.FromHtml("#fff");
            cellPatchQATestedHeader.Font.Name = "Arial Black";
            cellPatchQATestedHeader.Font.Size = FontUnit.Parse("9");
            cellPatchQATestedHeader.Style.Add("padding", "5px");
            cellPatchQATestedHeader.Text = "QA";
            cellPatchQATestedHeader.HorizontalAlign = HorizontalAlign.Center;
            rowHeader.Cells.Add(cellPatchQATestedHeader);

            TableCell cellPatchDeployedDateHeader = new TableCell();
            cellPatchDeployedDateHeader.BackColor = ColorTranslator.FromHtml("#004D40");
            cellPatchDeployedDateHeader.ForeColor = ColorTranslator.FromHtml("#fff");
            cellPatchDeployedDateHeader.Font.Name = "Arial Black";
            cellPatchDeployedDateHeader.Font.Size = FontUnit.Parse("9");
            cellPatchDeployedDateHeader.Style.Add("padding", "5px");
            cellPatchDeployedDateHeader.Text = "Deployed Date";
            cellPatchDeployedDateHeader.HorizontalAlign = HorizontalAlign.Center;
            rowHeader.Cells.Add(cellPatchDeployedDateHeader);

            //
            TableCell cellPatchPassedByTimeHeader = new TableCell();
            cellPatchPassedByTimeHeader.BackColor = ColorTranslator.FromHtml("#004D40");
            cellPatchPassedByTimeHeader.ForeColor = ColorTranslator.FromHtml("#fff");
            cellPatchPassedByTimeHeader.Font.Name = "Arial Black";
            cellPatchPassedByTimeHeader.Font.Size = FontUnit.Parse("9");
            cellPatchPassedByTimeHeader.Style.Add("padding", "5px");
            cellPatchPassedByTimeHeader.Text = "Days Passed";
            cellPatchPassedByTimeHeader.HorizontalAlign = HorizontalAlign.Center;
            rowHeader.Cells.Add(cellPatchPassedByTimeHeader);

            TableCell cellPatchStatusHeader = new TableCell();
            cellPatchStatusHeader.BackColor = ColorTranslator.FromHtml("#004D40");
            cellPatchStatusHeader.ForeColor = ColorTranslator.FromHtml("#fff");
            cellPatchStatusHeader.HorizontalAlign = HorizontalAlign.Center;
            cellPatchStatusHeader.Font.Name = "Arial Black";
            cellPatchStatusHeader.Font.Size = FontUnit.Parse("9");
            cellPatchStatusHeader.Style.Add("padding", "5px");
            cellPatchStatusHeader.Text = "STATUS";
            cellPatchStatusHeader.HorizontalAlign = HorizontalAlign.Center;
            rowHeader.Cells.Add(cellPatchStatusHeader);
            //
            //TableCell cellPatchFileServer = new TableCell();
            //cellPatchFileServer.ForeColor = Color.Black;
            //cellPatchFileServer.Text = "";
            //cellPatchFileServer.HorizontalAlign = HorizontalAlign.Right;
            //row.Cells.Add(cellPatchFileServer);
            //
            //TableCell cellPatchIP = new TableCell();
            //cellPatchIP.ForeColor = Color.Black;
            //cellPatchIP.Text = "";
            //cellPatchIP.HorizontalAlign = HorizontalAlign.Right;
            //row.Cells.Add(cellPatchIP);
            //
            //
            //TableCell cellPatchDependency = new TableCell();
            //cellPatchDependency.ForeColor = Color.Black;
            //cellPatchDependency.Text = "";
            //cellPatchDependency.HorizontalAlign = HorizontalAlign.Right;
            //row.Cells.Add(cellPatchDependency);
            //
            TableCell cellAppLinkHeader = new TableCell();
            cellAppLinkHeader.BackColor = ColorTranslator.FromHtml("#004D40");
            cellAppLinkHeader.ForeColor = ColorTranslator.FromHtml("#fff");
            cellAppLinkHeader.HorizontalAlign = HorizontalAlign.Center;
            cellAppLinkHeader.Font.Name = "Arial Black";
            cellAppLinkHeader.Font.Size = FontUnit.Parse("9");
            cellAppLinkHeader.Style.Add("padding", "5px");
            cellAppLinkHeader.Text = "Link";
            cellAppLinkHeader.HorizontalAlign = HorizontalAlign.Center;
            rowHeader.Cells.Add(cellAppLinkHeader);

            TableCell cellAppWorkingDirectoryHeader = new TableCell();
            cellAppWorkingDirectoryHeader.BackColor = ColorTranslator.FromHtml("#004D40");
            cellAppWorkingDirectoryHeader.ForeColor = ColorTranslator.FromHtml("#fff");
            cellAppWorkingDirectoryHeader.Font.Name = "Arial Black";
            cellAppWorkingDirectoryHeader.Font.Size = FontUnit.Parse("9");
            cellAppWorkingDirectoryHeader.Style.Add("padding", "5px");
            cellAppWorkingDirectoryHeader.Text = "Dir";
            cellAppWorkingDirectoryHeader.HorizontalAlign = HorizontalAlign.Center;
            rowHeader.Cells.Add(cellAppWorkingDirectoryHeader);


            //
            tblInfo.Rows.Add(rowHeader);

            //HEADER COLUMN END

            //Debug.WriteLine("Records Count: " + latestPatchOfClient.Count);
            foreach (var item in latestPatchOfClient)
            {




                //Debug.WriteLine("Name:" + item.clientName + " | PatchHotNumber: " + item.patchHotNumber + " | PatchDeployedDate: " + item.patchDeployedDate + "\n");
                
                TableRow row = new TableRow();

                //Passed By Time Duration Calculation Logic
                Debug.WriteLine(item.patchNumberOfDaysPassed.GetType() + " - " + item.patchNumberOfDaysPassed.Length);
                Debug.WriteLine("=>" + item.patchNumberOfDaysPassed);
                int numberOfDaysPassed = 0;
                if (item.patchNumberOfDaysPassed == "") { 
                    numberOfDaysPassed =  -1 ;
                    item.numberOfPatches = "";
                    item.patchDeployedDate = "";
                    item.clientAppLink = "";

                }
                else {
                    numberOfDaysPassed = Convert.ToInt32(item.patchNumberOfDaysPassed);
                }
                

                try
                {
                    switch (numberOfDaysPassed)
                    {
                        case 0:
                            row.BackColor = ColorTranslator.FromHtml("#f68787");
                            break;
                        case 1:
                            row.BackColor = ColorTranslator.FromHtml("#f8a978");
                            break;
                        case 2:
                            row.BackColor = ColorTranslator.FromHtml("#f1eb9a");
                            break;
                        case 3:
                            row.BackColor = ColorTranslator.FromHtml("#a4f6a5");
                            break;
                        case 4:
                            row.BackColor = ColorTranslator.FromHtml("#fff");
                            break;
                        case 5:
                            row.BackColor = ColorTranslator.FromHtml("#fff");
                            break;
                        case 6:
                            row.BackColor = ColorTranslator.FromHtml("#ffffff");
                            break;
                        case 7:
                            row.BackColor = ColorTranslator.FromHtml("#ffb6b9");
                            break;
                        case 8:
                            row.BackColor = ColorTranslator.FromHtml("#fff");
                            break;
                        case 9:
                            row.BackColor = ColorTranslator.FromHtml("#fff");
                            break;
                        case 10:
                            row.BackColor = ColorTranslator.FromHtml("#087");
                            break;

                    }

                

                TableCell cellClientName = new TableCell();
                cellClientName.ForeColor = Color.DarkGray;
                cellClientName.Font.Name = "Arial";
                cellClientName.Font.Size = FontUnit.Parse("9");
                cellClientName.Text = item.clientName;
                cellClientName.HorizontalAlign = HorizontalAlign.Left;
                cellClientName.BackColor = ColorTranslator.FromHtml("#E0F2F1");
                cellClientName.ForeColor = ColorTranslator.FromHtml("#3E2723");
                cellClientName.Style.Add("font-names", "Arial");
                cellClientName.Style.Add("padding", "3px");
                //cellClientName.BorderColor = ColorTranslator.FromHtml("#000");
                cellClientName.Font.Bold = false;
                row.Cells.Add(cellClientName);
                TableCell cellClientType = new TableCell();
                cellClientType.ForeColor = ColorTranslator.FromHtml("#3E2723");
                cellClientType.Font.Name = "Arial";
                cellClientType.Font.Size = FontUnit.Parse("9");
                cellClientType.Style.Add("padding", "3px");
                cellClientType.Text = item.clientType;
                cellClientType.HorizontalAlign = HorizontalAlign.Right;
                row.Cells.Add(cellClientType);
                TableCell cellClientEnvType = new TableCell();
                cellClientEnvType.ForeColor = ColorTranslator.FromHtml("#3E2723");
                cellClientEnvType.Font.Name = "Arial";
                cellClientEnvType.Font.Size = FontUnit.Parse("9");
                cellClientEnvType.Style.Add("padding", "3px");
                cellClientEnvType.Text = item.clientEnvType;
                cellClientEnvType.HorizontalAlign = HorizontalAlign.Right;
                row.Cells.Add(cellClientEnvType);
                TableCell cellClientPOC = new TableCell();
                cellClientPOC.ForeColor = ColorTranslator.FromHtml("#3E2723");
                cellClientPOC.Font.Name = "Arial";
                cellClientPOC.Font.Size = FontUnit.Parse("9");
                cellClientPOC.Style.Add("padding", "3px");
                cellClientPOC.Text = item.clientPOCName;
                cellClientPOC.HorizontalAlign = HorizontalAlign.Right;
                row.Cells.Add(cellClientPOC);
                TableCell cellClientPOCName = new TableCell();
                cellClientPOCName.ForeColor = ColorTranslator.FromHtml("#3E2723");
                cellClientPOCName.Font.Name = "Arial";
                cellClientPOCName.Font.Size = FontUnit.Parse("9");
                cellClientPOCName.Style.Add("padding", "3px");
                cellClientPOCName.Text = item.numberOfPatches;
                cellClientPOCName.HorizontalAlign = HorizontalAlign.Right;
                row.Cells.Add(cellClientPOCName);
                TableCell cellPatchHotNumber = new TableCell();
                cellPatchHotNumber.ForeColor = ColorTranslator.FromHtml("#3E2723");
                cellPatchHotNumber.Font.Name = "Arial";
                cellPatchHotNumber.Font.Size = FontUnit.Parse("9");
                cellPatchHotNumber.Style.Add("padding", "3px");
                cellPatchHotNumber.Text = item.patchHotNumber;
                cellPatchHotNumber.HorizontalAlign = HorizontalAlign.Right;
                row.Cells.Add(cellPatchHotNumber);
                
                TableCell cellPatchQATested = new TableCell();
                cellPatchQATested.ForeColor = ColorTranslator.FromHtml("#3E2723");
                cellPatchQATested.Font.Name = "Arial";
                cellPatchQATested.Font.Size = FontUnit.Parse("9");
                cellPatchQATested.Style.Add("padding", "3px");
                cellPatchQATested.Text = item.patchQATested;
                cellPatchQATested.HorizontalAlign = HorizontalAlign.Right;
                row.Cells.Add(cellPatchQATested);
                TableCell cellPatchDeployedDate = new TableCell();
                cellPatchDeployedDate.ForeColor = ColorTranslator.FromHtml("#3E2723");
                cellPatchDeployedDate.Font.Name = "Arial";
                cellPatchDeployedDate.Font.Size = FontUnit.Parse("9");
                cellPatchDeployedDate.Style.Add("padding", "3px");
                //int spaceInDate = item.patchDeployedDate.IndexOf(' ');
                //cellPatchDeployedDate.Text = item.patchDeployedDate.Substring(0, spaceInDate);
                //Debug.WriteLine("Deployed Date: " + item.patchDeployedDate);
                if (item.patchDeployedDate.ToString() != String.Empty) {
                int a = item.patchDeployedDate.IndexOf(' ');
                cellPatchDeployedDate.Text = item.patchDeployedDate.Substring(0,a).ToString();
                }
                cellPatchDeployedDate.HorizontalAlign = HorizontalAlign.Right;
                row.Cells.Add(cellPatchDeployedDate);

                //
                TableCell cellPatchPassedByTime = new TableCell();
                cellPatchPassedByTime.ForeColor = ColorTranslator.FromHtml("#3E2723");
                cellPatchPassedByTime.Font.Name = "Arial";
                cellPatchPassedByTime.Font.Size = FontUnit.Parse("9");
                cellPatchPassedByTime.Style.Add("padding", "3px");
                cellPatchPassedByTime.Text = numberOfDaysPassed.ToString() == "-1" ? "" : numberOfDaysPassed.ToString() + " days ago.";
                cellPatchPassedByTime.HorizontalAlign = HorizontalAlign.Right;
                row.Cells.Add(cellPatchPassedByTime);
                TableCell cellPatchStatus = new TableCell();
                cellPatchStatus.ForeColor = ColorTranslator.FromHtml("#3E2723");
                cellPatchStatus.Font.Name = "Arial";
                cellPatchStatus.Font.Size = FontUnit.Parse("9");
                cellPatchStatus.Style.Add("padding", "3px");
                cellPatchStatus.Text = item.patchStatus;
                cellPatchStatus.HorizontalAlign = HorizontalAlign.Right;
                row.Cells.Add(cellPatchStatus);
                //
                //TableCell cellPatchFileServer = new TableCell();
                //cellPatchFileServer.ForeColor = Color.Black;
                //cellPatchFileServer.Text = "";
                //cellPatchFileServer.HorizontalAlign = HorizontalAlign.Right;
                //row.Cells.Add(cellPatchFileServer);
                //
                //TableCell cellPatchIP = new TableCell();
                //cellPatchIP.ForeColor = Color.Black;
                //cellPatchIP.Text = "";
                //cellPatchIP.HorizontalAlign = HorizontalAlign.Right;
                //row.Cells.Add(cellPatchIP);
                //
                //
                //TableCell cellPatchDependency = new TableCell();
                //cellPatchDependency.ForeColor = Color.Black;
                //cellPatchDependency.Text = "";
                //cellPatchDependency.HorizontalAlign = HorizontalAlign.Right;
                //row.Cells.Add(cellPatchDependency);
                //
                TableCell cellAppLink = new TableCell();
                cellAppLink.ForeColor = ColorTranslator.FromHtml("#3E2723");
                cellAppLink.Font.Name = "Arial";
                cellAppLink.Font.Size = FontUnit.Parse("9");
                if (item.clientAppLink.ToString() != String.Empty)
                {
                    cellAppLink.Text = "<a target=\"_blank\" href=\"" + item.clientAppLink + "\" >" + "LINK" + "</a>";
                }
                cellAppLink.HorizontalAlign = HorizontalAlign.Right;
                row.Cells.Add(cellAppLink);

                TableCell cellAppWorkingDirectory = new TableCell();
                cellAppWorkingDirectory.ForeColor = ColorTranslator.FromHtml("#3E2723");
                cellAppWorkingDirectory.Font.Name = "Arial";
                cellAppWorkingDirectory.Font.Size = FontUnit.Parse("9");
                if (item.clientAppLink.ToString() != String.Empty)
                {
                    cellAppWorkingDirectory.Text = "<a target=\"_blank\" href=\"" + item.clientAppLink + "\" >" + "LINK" + "</a>";
                }
                cellAppWorkingDirectory.HorizontalAlign = HorizontalAlign.Right;
                row.Cells.Add(cellAppWorkingDirectory);


                //
                tblInfo.Rows.Add(row);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception: " + ex.Message);
                }

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            tblInfo.Rows.Clear();

            //DatabaseConnectivity dbcon = new DatabaseConnectivity();
            Debug.WriteLine("Product: " + DropProduct.Text);
            Debug.WriteLine("Env Type: " + DropEnvType.Text);
            Debug.WriteLine("Client: " + DropClientID.Text);
            int product = Convert.ToInt32(DropProduct.Text);
            int environment = Convert.ToInt32(DropEnvType.Text);
            int client = Convert.ToInt32(DropClientID.Text);

            //Start

            //Debug.WriteLine("Product: " + DropDownList1.Text);
            //Console.WriteLine("GGG");

            DatabaseConnectivity dbcon = new DatabaseConnectivity();
            List<Patch> latestPatchOfClient = dbcon.getAllUpdatedClientPatches(product, environment);
            //Debug.WriteLine("Records Count: " + latestPatchOfClient.Count);

            //HEADER COLUMN START

            TableRow rowHeader = new TableRow();

            TableCell cellClientNameHeader = new TableCell();
            cellClientNameHeader.BackColor = ColorTranslator.FromHtml("#004D40");
            cellClientNameHeader.ForeColor = ColorTranslator.FromHtml("#fff");
            cellClientNameHeader.Font.Name = "Arial Black";
            cellClientNameHeader.Font.Size = FontUnit.Parse("9");
            cellClientNameHeader.Style.Add("padding", "5px");
            cellClientNameHeader.Text = "Client Name";
            cellClientNameHeader.HorizontalAlign = HorizontalAlign.Center;
            rowHeader.Cells.Add(cellClientNameHeader);
            TableCell cellClientTypeHeader = new TableCell();
            cellClientTypeHeader.BackColor = ColorTranslator.FromHtml("#004D40");
            cellClientTypeHeader.ForeColor = ColorTranslator.FromHtml("#fff");
            cellClientTypeHeader.Font.Name = "Arial Black";
            cellClientTypeHeader.Font.Size = FontUnit.Parse("9");
            cellClientTypeHeader.Style.Add("padding", "5px");
            cellClientTypeHeader.Text = "Client Role";
            cellClientTypeHeader.HorizontalAlign = HorizontalAlign.Center;
            rowHeader.Cells.Add(cellClientTypeHeader);

            TableCell cellClientEnvTypeHeader = new TableCell();
            cellClientEnvTypeHeader.BackColor = ColorTranslator.FromHtml("#004D40");
            cellClientEnvTypeHeader.ForeColor = ColorTranslator.FromHtml("#fff");
            cellClientEnvTypeHeader.Font.Name = "Arial Black";
            cellClientEnvTypeHeader.Font.Size = FontUnit.Parse("9");
            cellClientEnvTypeHeader.Style.Add("padding", "5px");
            cellClientEnvTypeHeader.Text = "Environment";
            cellClientEnvTypeHeader.HorizontalAlign = HorizontalAlign.Center;
            rowHeader.Cells.Add(cellClientEnvTypeHeader);

            TableCell cellClientPOCHeader = new TableCell();
            cellClientPOCHeader.BackColor = ColorTranslator.FromHtml("#004D40");
            cellClientPOCHeader.ForeColor = ColorTranslator.FromHtml("#fff");
            cellClientPOCHeader.Font.Name = "Arial Black";
            cellClientPOCHeader.Font.Size = FontUnit.Parse("9");
            cellClientPOCHeader.Style.Add("padding", "5px");
            cellClientPOCHeader.Text = "Contact Person";
            cellClientPOCHeader.HorizontalAlign = HorizontalAlign.Center;
            rowHeader.Cells.Add(cellClientPOCHeader);

            TableCell cellClientPOCNameHeader = new TableCell();
            cellClientPOCNameHeader.BackColor = ColorTranslator.FromHtml("#004D40");
            cellClientPOCNameHeader.ForeColor = ColorTranslator.FromHtml("#fff");
            cellClientPOCNameHeader.Font.Name = "Arial Black";
            cellClientPOCNameHeader.Font.Size = FontUnit.Parse("9");
            cellClientPOCNameHeader.Style.Add("padding", "5px");
            cellClientPOCNameHeader.Text = "Total Releases";
            cellClientPOCNameHeader.HorizontalAlign = HorizontalAlign.Center;
            rowHeader.Cells.Add(cellClientPOCNameHeader);

            TableCell cellPatchHotNumberHeader = new TableCell();
            cellPatchHotNumberHeader.BackColor = ColorTranslator.FromHtml("#004D40");
            cellPatchHotNumberHeader.ForeColor = ColorTranslator.FromHtml("#fff");
            cellPatchHotNumberHeader.Font.Name = "Arial Black";
            cellPatchHotNumberHeader.Font.Size = FontUnit.Parse("9");
            cellPatchHotNumberHeader.Style.Add("padding", "5px");
            cellPatchHotNumberHeader.Text = "Latest Release ";
            cellPatchHotNumberHeader.HorizontalAlign = HorizontalAlign.Center;
            rowHeader.Cells.Add(cellPatchHotNumberHeader);

            TableCell cellPatchQATestedHeader = new TableCell();
            cellPatchQATestedHeader.BackColor = ColorTranslator.FromHtml("#004D40");
            cellPatchQATestedHeader.ForeColor = ColorTranslator.FromHtml("#fff");
            cellPatchQATestedHeader.Font.Name = "Arial Black";
            cellPatchQATestedHeader.Font.Size = FontUnit.Parse("9");
            cellPatchQATestedHeader.Style.Add("padding", "5px");
            cellPatchQATestedHeader.Text = "QA";
            cellPatchQATestedHeader.HorizontalAlign = HorizontalAlign.Center;
            rowHeader.Cells.Add(cellPatchQATestedHeader);

            TableCell cellPatchDeployedDateHeader = new TableCell();
            cellPatchDeployedDateHeader.BackColor = ColorTranslator.FromHtml("#004D40");
            cellPatchDeployedDateHeader.ForeColor = ColorTranslator.FromHtml("#fff");
            cellPatchDeployedDateHeader.Font.Name = "Arial Black";
            cellPatchDeployedDateHeader.Font.Size = FontUnit.Parse("9");
            cellPatchDeployedDateHeader.Style.Add("padding", "5px");
            cellPatchDeployedDateHeader.Text = "Deployed Date";
            cellPatchDeployedDateHeader.HorizontalAlign = HorizontalAlign.Center;
            rowHeader.Cells.Add(cellPatchDeployedDateHeader);

            //
            TableCell cellPatchPassedByTimeHeader = new TableCell();
            cellPatchPassedByTimeHeader.BackColor = ColorTranslator.FromHtml("#004D40");
            cellPatchPassedByTimeHeader.ForeColor = ColorTranslator.FromHtml("#fff");
            cellPatchPassedByTimeHeader.Font.Name = "Arial Black";
            cellPatchPassedByTimeHeader.Font.Size = FontUnit.Parse("9");
            cellPatchPassedByTimeHeader.Style.Add("padding", "5px");
            cellPatchPassedByTimeHeader.Text = "Days Passed";
            cellPatchPassedByTimeHeader.HorizontalAlign = HorizontalAlign.Center;
            rowHeader.Cells.Add(cellPatchPassedByTimeHeader);

            TableCell cellPatchStatusHeader = new TableCell();
            cellPatchStatusHeader.BackColor = ColorTranslator.FromHtml("#004D40");
            cellPatchStatusHeader.ForeColor = ColorTranslator.FromHtml("#fff");
            cellPatchStatusHeader.HorizontalAlign = HorizontalAlign.Center;
            cellPatchStatusHeader.Font.Name = "Arial Black";
            cellPatchStatusHeader.Font.Size = FontUnit.Parse("9");
            cellPatchStatusHeader.Style.Add("padding", "5px");
            cellPatchStatusHeader.Text = "STATUS";
            cellPatchStatusHeader.HorizontalAlign = HorizontalAlign.Center;
            rowHeader.Cells.Add(cellPatchStatusHeader);
            //
            //TableCell cellPatchFileServer = new TableCell();
            //cellPatchFileServer.ForeColor = Color.Black;
            //cellPatchFileServer.Text = "";
            //cellPatchFileServer.HorizontalAlign = HorizontalAlign.Right;
            //row.Cells.Add(cellPatchFileServer);
            //
            //TableCell cellPatchIP = new TableCell();
            //cellPatchIP.ForeColor = Color.Black;
            //cellPatchIP.Text = "";
            //cellPatchIP.HorizontalAlign = HorizontalAlign.Right;
            //row.Cells.Add(cellPatchIP);
            //
            //
            //TableCell cellPatchDependency = new TableCell();
            //cellPatchDependency.ForeColor = Color.Black;
            //cellPatchDependency.Text = "";
            //cellPatchDependency.HorizontalAlign = HorizontalAlign.Right;
            //row.Cells.Add(cellPatchDependency);
            //
            TableCell cellAppLinkHeader = new TableCell();
            cellAppLinkHeader.BackColor = ColorTranslator.FromHtml("#004D40");
            cellAppLinkHeader.ForeColor = ColorTranslator.FromHtml("#fff");
            cellAppLinkHeader.HorizontalAlign = HorizontalAlign.Center;
            cellAppLinkHeader.Font.Name = "Arial Black";
            cellAppLinkHeader.Font.Size = FontUnit.Parse("9");
            cellAppLinkHeader.Style.Add("padding", "5px");
            cellAppLinkHeader.Text = "Link";
            cellAppLinkHeader.HorizontalAlign = HorizontalAlign.Center;
            rowHeader.Cells.Add(cellAppLinkHeader);

            TableCell cellAppWorkingDirectoryHeader = new TableCell();
            cellAppWorkingDirectoryHeader.BackColor = ColorTranslator.FromHtml("#004D40");
            cellAppWorkingDirectoryHeader.ForeColor = ColorTranslator.FromHtml("#fff");
            cellAppWorkingDirectoryHeader.Font.Name = "Arial Black";
            cellAppWorkingDirectoryHeader.Font.Size = FontUnit.Parse("9");
            cellAppWorkingDirectoryHeader.Style.Add("padding", "5px");
            cellAppWorkingDirectoryHeader.Text = "Dir";
            cellAppWorkingDirectoryHeader.HorizontalAlign = HorizontalAlign.Center;
            rowHeader.Cells.Add(cellAppWorkingDirectoryHeader);


            //
            tblInfo.Rows.Add(rowHeader);

            //HEADER COLUMN END

            foreach (var item in latestPatchOfClient)
            {




                //Debug.WriteLine("Name:" + item.clientName + " | PatchHotNumber: " + item.patchHotNumber + " | PatchDeployedDate: " + item.patchDeployedDate + "\n");
                TableRow row = new TableRow();

                //Passed By Time Duration Calculation Logic
                Debug.WriteLine(item.patchNumberOfDaysPassed.GetType() + " - " + item.patchNumberOfDaysPassed.Length);
                Debug.WriteLine("=>" + item.patchNumberOfDaysPassed);
                int numberOfDaysPassed = 0;
                if (item.patchNumberOfDaysPassed == "")
                {
                    numberOfDaysPassed = -1;
                    item.numberOfPatches = "";
                    item.patchDeployedDate = "";
                    item.clientAppLink = "";

                }
                else
                {
                    numberOfDaysPassed = Convert.ToInt32(item.patchNumberOfDaysPassed);
                }


                try
                {
                    switch (numberOfDaysPassed)
                    {
                        case 0:
                            row.BackColor = ColorTranslator.FromHtml("#f68787");
                            break;
                        case 1:
                            row.BackColor = ColorTranslator.FromHtml("#f8a978");
                            break;
                        case 2:
                            row.BackColor = ColorTranslator.FromHtml("#f1eb9a");
                            break;
                        case 3:
                            row.BackColor = ColorTranslator.FromHtml("#a4f6a5");
                            break;
                        case 4:
                            row.BackColor = ColorTranslator.FromHtml("#fff");
                            break;
                        case 5:
                            row.BackColor = ColorTranslator.FromHtml("#fff");
                            break;
                        case 6:
                            row.BackColor = ColorTranslator.FromHtml("#ffffff");
                            break;
                        case 7:
                            row.BackColor = ColorTranslator.FromHtml("#ffb6b9");
                            break;
                        case 8:
                            row.BackColor = ColorTranslator.FromHtml("#fff");
                            break;
                        case 9:
                            row.BackColor = ColorTranslator.FromHtml("#fff");
                            break;
                        case 10:
                            row.BackColor = ColorTranslator.FromHtml("#087");
                            break;

                    }


                    TableCell cellClientName = new TableCell();
                    cellClientName.ForeColor = Color.DarkGray;
                    cellClientName.Font.Name = "Arial";
                    cellClientName.Font.Size = FontUnit.Parse("9");
                    cellClientName.Text = item.clientName;
                    cellClientName.HorizontalAlign = HorizontalAlign.Left;
                    cellClientName.BackColor = ColorTranslator.FromHtml("#E0F2F1");
                    cellClientName.ForeColor = ColorTranslator.FromHtml("#3E2723");
                    cellClientName.Style.Add("font-names", "Arial");
                    cellClientName.Style.Add("padding", "3px");
                    //cellClientName.BorderColor = ColorTranslator.FromHtml("#000");
                    cellClientName.Font.Bold = false;
                    row.Cells.Add(cellClientName);
                    TableCell cellClientType = new TableCell();
                    cellClientType.ForeColor = ColorTranslator.FromHtml("#3E2723");
                    cellClientType.Font.Name = "Arial";
                    cellClientType.Font.Size = FontUnit.Parse("9");
                    cellClientType.Style.Add("padding", "3px");
                    cellClientType.Text = item.clientType;
                    cellClientType.HorizontalAlign = HorizontalAlign.Right;
                    row.Cells.Add(cellClientType);
                    TableCell cellClientEnvType = new TableCell();
                    cellClientEnvType.ForeColor = ColorTranslator.FromHtml("#3E2723");
                    cellClientEnvType.Font.Name = "Arial";
                    cellClientEnvType.Font.Size = FontUnit.Parse("9");
                    cellClientEnvType.Style.Add("padding", "3px");
                    cellClientEnvType.Text = item.clientEnvType;
                    cellClientEnvType.HorizontalAlign = HorizontalAlign.Right;
                    row.Cells.Add(cellClientEnvType);
                    TableCell cellClientPOC = new TableCell();
                    cellClientPOC.ForeColor = ColorTranslator.FromHtml("#3E2723");
                    cellClientPOC.Font.Name = "Arial";
                    cellClientPOC.Font.Size = FontUnit.Parse("9");
                    cellClientPOC.Style.Add("padding", "3px");
                    cellClientPOC.Text = item.clientPOCName;
                    cellClientPOC.HorizontalAlign = HorizontalAlign.Right;
                    row.Cells.Add(cellClientPOC);
                    TableCell cellClientPOCName = new TableCell();
                    cellClientPOCName.ForeColor = ColorTranslator.FromHtml("#3E2723");
                    cellClientPOCName.Font.Name = "Arial";
                    cellClientPOCName.Font.Size = FontUnit.Parse("9");
                    cellClientPOCName.Style.Add("padding", "3px");
                    cellClientPOCName.Text = item.numberOfPatches;
                    cellClientPOCName.HorizontalAlign = HorizontalAlign.Right;
                    row.Cells.Add(cellClientPOCName);
                    TableCell cellPatchHotNumber = new TableCell();
                    cellPatchHotNumber.ForeColor = ColorTranslator.FromHtml("#3E2723");
                    cellPatchHotNumber.Font.Name = "Arial";
                    cellPatchHotNumber.Font.Size = FontUnit.Parse("9");
                    cellPatchHotNumber.Style.Add("padding", "3px");
                    cellPatchHotNumber.Text = item.patchHotNumber;
                    cellPatchHotNumber.HorizontalAlign = HorizontalAlign.Right;
                    row.Cells.Add(cellPatchHotNumber);

                    TableCell cellPatchQATested = new TableCell();
                    cellPatchQATested.ForeColor = ColorTranslator.FromHtml("#3E2723");
                    cellPatchQATested.Font.Name = "Arial";
                    cellPatchQATested.Font.Size = FontUnit.Parse("9");
                    cellPatchQATested.Style.Add("padding", "3px");
                    cellPatchQATested.Text = item.patchQATested;
                    cellPatchQATested.HorizontalAlign = HorizontalAlign.Right;
                    row.Cells.Add(cellPatchQATested);
                    TableCell cellPatchDeployedDate = new TableCell();
                    cellPatchDeployedDate.ForeColor = ColorTranslator.FromHtml("#3E2723");
                    cellPatchDeployedDate.Font.Name = "Arial";
                    cellPatchDeployedDate.Font.Size = FontUnit.Parse("9");
                    cellPatchDeployedDate.Style.Add("padding", "3px");
                    //int spaceInDate = item.patchDeployedDate.IndexOf(' ');
                    //cellPatchDeployedDate.Text = item.patchDeployedDate.Substring(0, spaceInDate);
                    //Debug.WriteLine("Deployed Date: " + item.patchDeployedDate);
                    if (item.patchDeployedDate.ToString() != String.Empty)
                    {
                        int a = item.patchDeployedDate.IndexOf(' ');
                        cellPatchDeployedDate.Text = item.patchDeployedDate.Substring(0, a).ToString();
                    }
                    cellPatchDeployedDate.HorizontalAlign = HorizontalAlign.Right;
                    row.Cells.Add(cellPatchDeployedDate);

                    //
                    TableCell cellPatchPassedByTime = new TableCell();
                    cellPatchPassedByTime.ForeColor = ColorTranslator.FromHtml("#3E2723");
                    cellPatchPassedByTime.Font.Name = "Arial";
                    cellPatchPassedByTime.Font.Size = FontUnit.Parse("9");
                    cellPatchPassedByTime.Style.Add("padding", "3px");
                    cellPatchPassedByTime.Text = numberOfDaysPassed.ToString() == "-1" ? "" : numberOfDaysPassed.ToString() + " days ago.";
                    cellPatchPassedByTime.HorizontalAlign = HorizontalAlign.Right;
                    row.Cells.Add(cellPatchPassedByTime);
                    TableCell cellPatchStatus = new TableCell();
                    cellPatchStatus.ForeColor = ColorTranslator.FromHtml("#3E2723");
                    cellPatchStatus.Font.Name = "Arial";
                    cellPatchStatus.Font.Size = FontUnit.Parse("9");
                    cellPatchStatus.Style.Add("padding", "3px");
                    cellPatchStatus.Text = item.patchStatus;
                    cellPatchStatus.HorizontalAlign = HorizontalAlign.Right;
                    row.Cells.Add(cellPatchStatus);
                    //
                    //TableCell cellPatchFileServer = new TableCell();
                    //cellPatchFileServer.ForeColor = Color.Black;
                    //cellPatchFileServer.Text = "";
                    //cellPatchFileServer.HorizontalAlign = HorizontalAlign.Right;
                    //row.Cells.Add(cellPatchFileServer);
                    //
                    //TableCell cellPatchIP = new TableCell();
                    //cellPatchIP.ForeColor = Color.Black;
                    //cellPatchIP.Text = "";
                    //cellPatchIP.HorizontalAlign = HorizontalAlign.Right;
                    //row.Cells.Add(cellPatchIP);
                    //
                    //
                    //TableCell cellPatchDependency = new TableCell();
                    //cellPatchDependency.ForeColor = Color.Black;
                    //cellPatchDependency.Text = "";
                    //cellPatchDependency.HorizontalAlign = HorizontalAlign.Right;
                    //row.Cells.Add(cellPatchDependency);
                    //
                    TableCell cellAppLink = new TableCell();
                    cellAppLink.ForeColor = ColorTranslator.FromHtml("#3E2723");
                    cellAppLink.Font.Name = "Arial";
                    cellAppLink.Font.Size = FontUnit.Parse("9");
                    if (item.clientAppLink.ToString() != String.Empty)
                    {
                        cellAppLink.Text = "<a target=\"_blank\" href=\"" + item.clientAppLink + "\" >" + "LINK" + "</a>";
                    }
                    cellAppLink.HorizontalAlign = HorizontalAlign.Right;
                    row.Cells.Add(cellAppLink);

                    TableCell cellAppWorkingDirectory = new TableCell();
                    cellAppWorkingDirectory.ForeColor = ColorTranslator.FromHtml("#3E2723");
                    cellAppWorkingDirectory.Font.Name = "Arial";
                    cellAppWorkingDirectory.Font.Size = FontUnit.Parse("9");
                    if (item.clientAppLink.ToString() != String.Empty)
                    {
                        cellAppWorkingDirectory.Text = "<a target=\"_blank\" href=\"" + item.clientAppLink + "\" >" + "LINK" + "</a>";
                    }
                    cellAppWorkingDirectory.HorizontalAlign = HorizontalAlign.Right;
                    row.Cells.Add(cellAppWorkingDirectory);


                    //
                    tblInfo.Rows.Add(row);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception: " + ex.Message);
                }

            }

            //End

        }

    }
}