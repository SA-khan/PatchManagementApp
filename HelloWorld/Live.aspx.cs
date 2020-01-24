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
            //PAMS for Parameter 1
            //Test Env For Parameter 2
            Debug.WriteLine("Product: " + DropDownList1.Text);
            int product = Convert.ToInt32(DropDownList1.Text);
            List<Patch> latestPatchOfClient = dbcon.getAllUpdatedClientPatches(product == 0 ? 1 : product, 1);
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
                cellClientName.ForeColor = Color.Black;
                cellClientName.Text = item.clientName;
                cellClientName.HorizontalAlign = HorizontalAlign.Left;
                cellClientName.BackColor = ColorTranslator.FromHtml("#5C6BC0");
                cellClientName.ForeColor = ColorTranslator.FromHtml("#fff");
                cellClientName.Style.Add("padding", "5px");
                cellClientName.BorderColor = ColorTranslator.FromHtml("#fff");
                cellClientName.Font.Bold = true;
                row.Cells.Add(cellClientName);
                TableCell cellClientType = new TableCell();
                cellClientType.ForeColor = Color.Black;
                cellClientType.Style.Add("padding", "5px");
                cellClientType.Text = item.clientType;
                cellClientType.HorizontalAlign = HorizontalAlign.Right;
                row.Cells.Add(cellClientType);
                TableCell cellClientEnvType = new TableCell();
                cellClientEnvType.ForeColor = Color.Black;
                cellClientEnvType.Style.Add("padding", "5px");
                cellClientEnvType.Text = item.clientEnvType;
                cellClientEnvType.HorizontalAlign = HorizontalAlign.Right;
                row.Cells.Add(cellClientEnvType);
                TableCell cellClientPOC = new TableCell();
                cellClientPOC.ForeColor = Color.Black;
                cellClientPOC.Style.Add("padding", "5px");
                cellClientPOC.Text = item.clientPOCName;
                cellClientPOC.HorizontalAlign = HorizontalAlign.Right;
                row.Cells.Add(cellClientPOC);
                TableCell cellClientPOCName = new TableCell();
                cellClientPOCName.ForeColor = Color.Black;
                cellClientPOCName.Style.Add("padding", "5px");
                cellClientPOCName.Text = item.numberOfPatches;
                cellClientPOCName.HorizontalAlign = HorizontalAlign.Right;
                row.Cells.Add(cellClientPOCName);
                TableCell cellPatchHotNumber = new TableCell();
                cellPatchHotNumber.ForeColor = Color.Black;
                cellPatchHotNumber.Style.Add("padding", "5px");
                cellPatchHotNumber.Text = item.patchHotNumber;
                cellPatchHotNumber.HorizontalAlign = HorizontalAlign.Right;
                row.Cells.Add(cellPatchHotNumber);
                TableCell cellAppLink = new TableCell();
                cellAppLink.ForeColor = Color.Black;
                cellAppLink.Text = "<a target=\"_blank\" href=\"" + item.clientAppLink + "\" >" + item.clientAppLink + "</a>";
                cellAppLink.HorizontalAlign = HorizontalAlign.Right;
                row.Cells.Add(cellAppLink);
                TableCell cellPatchQATested = new TableCell();
                cellPatchQATested.ForeColor = Color.Black;
                cellPatchQATested.Style.Add("padding", "5px");
                cellPatchQATested.Text = item.patchQATested;
                cellPatchQATested.HorizontalAlign = HorizontalAlign.Right;
                row.Cells.Add(cellPatchQATested);
                TableCell cellPatchDeployedDate = new TableCell();
                cellPatchDeployedDate.ForeColor = Color.Black;
                cellPatchDeployedDate.Style.Add("padding", "5px");
                //int spaceInDate = item.patchDeployedDate.IndexOf(' ');
                //cellPatchDeployedDate.Text = item.patchDeployedDate.Substring(0, spaceInDate);
                //Debug.WriteLine("Deployed Date: " + item.patchDeployedDate);
                cellPatchDeployedDate.Text = item.patchDeployedDate;
                cellPatchDeployedDate.HorizontalAlign = HorizontalAlign.Right;
                row.Cells.Add(cellPatchDeployedDate);

                //
                TableCell cellPatchPassedByTime = new TableCell();
                cellPatchPassedByTime.ForeColor = Color.Black;
                cellPatchPassedByTime.Style.Add("padding", "5px");
                cellPatchPassedByTime.Text = numberOfDaysPassed.ToString() == "-1" ? "" : numberOfDaysPassed.ToString() + " days ago.";
                cellPatchPassedByTime.HorizontalAlign = HorizontalAlign.Right;
                row.Cells.Add(cellPatchPassedByTime);
                TableCell cellPatchStatus = new TableCell();
                cellPatchStatus.ForeColor = Color.Black;
                cellPatchStatus.Style.Add("padding", "5px");
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


                //
                tblInfo.Rows.Add(row);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception: " + ex.Message);
                }

            }
        }
    }
}