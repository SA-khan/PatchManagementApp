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
            //EnableTheming = false; StyleSheetTheme = ""; Theme = ""; 
            try
            {
                log.DetailLog("EnvironmentInfo.aspx.cs", "Page_Load", STATE.INITIALIZED, "Method: Page_Load in Class: EnvironmentInfo.aspx.cs has Initialized.");
                int product = Convert.ToInt32(DropDownList1.Text);
                int environment = Convert.ToInt32(DropEnvType.Text);
                int client = Convert.ToInt32(DropClientID.Text);
                List<HelloWorld.App_Code.Environment> latestPatchOfClient = dbcon.getClientEnvironmentInfo(product, environment, client);
                int count = 0;
                int total = latestPatchOfClient.Count;
                //totalRecords.Text = "Total Number of Records: " + total;
                TallyRecords.InnerText = "Total Environment Found # " + total;

                // START
                TableRow row000 = new TableRow();
                row000.Style.Add("width", "100%");
                TableCell cell1 = new TableCell();
                cell1.HorizontalAlign = HorizontalAlign.Center;
                cell1.ColumnSpan = 10;

                row000.Controls.Add(cell1);
                tblInfo.Rows.Add(row000);

                foreach (var item in latestPatchOfClient)
                {

                    // START
                    //TableRow row000 = new TableRow();
                    //row000.Style.Add("width", "100%");
                    //TableCell cell1 = new TableCell();
                    //cell1.HorizontalAlign = HorizontalAlign.Center;
                    //cell1.ColumnSpan = 10;
                    //row000.Controls.Add(cell1);
                    //tblInfo.Rows.Add(row000);

                    #region Layout

                    // Layout

                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Card_Bg_Light_Main = new System.Web.UI.HtmlControls.HtmlGenericControl("div");

                    Div_Card_Bg_Light_Main.Attributes.Add("class", "card bg-light");
                    Div_Card_Bg_Light_Main.ID = "Div_Card_Bg_Light_Main" + count;
                    Div_Card_Bg_Light_Main.Style.Add("padding", "2%");
                    cell1.Controls.Add(Div_Card_Bg_Light_Main);

                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Card_Bg_Light_Second = new System.Web.UI.HtmlControls.HtmlGenericControl("div");

                    Div_Card_Bg_Light_Second.Attributes.Add("class", "card bg-light");
                    Div_Card_Bg_Light_Second.ID = "Div_Card_Bg_Light_Second" + count;
                    Div_Card_Bg_Light_Main.Controls.Add(Div_Card_Bg_Light_Second);

                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Card_Bg_Dark = new System.Web.UI.HtmlControls.HtmlGenericControl("div");

                    Div_Card_Bg_Dark.Attributes.Add("class", "card bg-dark");
                    Div_Card_Bg_Dark.ID = "Div_Card_Bg_Dark" + count;
                    Div_Card_Bg_Light_Second.Controls.Add(Div_Card_Bg_Dark);

                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Collapse = new System.Web.UI.HtmlControls.HtmlGenericControl("div");

                    Div_Collapse.Attributes.Add("class", "collapse");
                    Div_Collapse.ID = "collapse" + count;
                    Div_Card_Bg_Light_Second.Controls.Add(Div_Collapse);

                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Card_Body = new System.Web.UI.HtmlControls.HtmlGenericControl("div");

                    Div_Card_Body.Attributes.Add("class", "card-body");
                    Div_Collapse.Controls.Add(Div_Card_Body);

                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Card_Header = new System.Web.UI.HtmlControls.HtmlGenericControl("div");

                    Div_Card_Header.Attributes.Add("class", "card-header");
                    Div_Card_Bg_Dark.Controls.Add(Div_Card_Header);

                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Row_Image_Labels_Button = new System.Web.UI.HtmlControls.HtmlGenericControl("div");

                    Div_Row_Image_Labels_Button.Attributes.Add("class", "row");
                    Div_Card_Header.Controls.Add(Div_Row_Image_Labels_Button);

                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_1_Image = new System.Web.UI.HtmlControls.HtmlGenericControl("div");

                    Div_Col_Sm_1_Image.Attributes.Add("class", "col-sm-1");
                    Div_Col_Sm_1_Image.InnerHtml = "<img ID=\"Image" + count + "\" runat=\"server\" src=\"../Images/release.png\" Width=\"60\" Height=\"60\" style=\"margin:5px;\" />";
                    Div_Row_Image_Labels_Button.Controls.Add(Div_Col_Sm_1_Image);

                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_10_Client_Env_Product = new System.Web.UI.HtmlControls.HtmlGenericControl("div");

                    Div_Col_Sm_10_Client_Env_Product.Attributes.Add("class", "col-sm-10");
                    Div_Row_Image_Labels_Button.Controls.Add(Div_Col_Sm_10_Client_Env_Product);

                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Row_Client_Env_Product = new System.Web.UI.HtmlControls.HtmlGenericControl("div");

                        Div_Row_Client_Env_Product.Attributes.Add("class", "row");
                        Div_Col_Sm_10_Client_Env_Product.Controls.Add(Div_Row_Client_Env_Product);

                                System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_ClientName = new System.Web.UI.HtmlControls.HtmlGenericControl("div");

                                Div_Col_ClientName.Attributes.Add("class", "col-sm-12 text-left");
                                Div_Col_ClientName.Style.Add("align", "left");
                                Div_Col_ClientName.InnerHtml = "<span style=\"color:white;\">" + item.ClientName.ToUpper() + "</span>";
                                Div_Row_Client_Env_Product.Controls.Add(Div_Col_ClientName);

                                System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Env = new System.Web.UI.HtmlControls.HtmlGenericControl("div");

                                Div_Col_Env.Attributes.Add("class", "col-sm-12 text-left");
                                Div_Col_Env.Style.Add("align", "left");
                                Div_Col_Env.InnerHtml = "<span style=\"color:white;\">" + item.EnvironmentAppServerEnvType.ToUpper() + "</span>";
                                Div_Row_Client_Env_Product.Controls.Add(Div_Col_Env);

                                System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Product = new System.Web.UI.HtmlControls.HtmlGenericControl("div");

                                Div_Col_Product.Attributes.Add("class", "col-sm-12 text-left");
                                Div_Col_Product.Style.Add("align", "left");
                                Div_Col_Product.InnerHtml = "<span style=\"color:white;\">" + item.ProductName + "</span>";
                                Div_Row_Client_Env_Product.Controls.Add(Div_Col_Product);

                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_1_Btn_Expand = new System.Web.UI.HtmlControls.HtmlGenericControl("div");

                    Div_Col_Sm_1_Btn_Expand.Attributes.Add("class", "col-sm-1");
                    Div_Col_Sm_1_Btn_Expand.Style.Add("margin", "auto");
                    Div_Col_Sm_1_Btn_Expand.Style.Add("float", "right");
                    Div_Col_Sm_1_Btn_Expand.InnerHtml = "<button id=\"btnExpand" + count + "\" type=\"button\" class=\"btn btn-primary\" data-toggle=\"collapse\" data-target=\"#MainContent_collapse" + count + "\" >Expand</button>";
                    Div_Row_Image_Labels_Button.Controls.Add(Div_Col_Sm_1_Btn_Expand);

                    #endregion Layout

                    


                    #region ClientName

                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Row_ClientName = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_ClientName_Label = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_ClientName = new System.Web.UI.HtmlControls.HtmlGenericControl("div");

                    Div_Row_ClientName.Attributes.Add("class", "row");
                    Div_Row_ClientName.Style.Add("background-color", "lightgray");
                    Div_Card_Body.Controls.Add(Div_Row_ClientName);

                    Div_Col_Sm_6_ClientName_Label.Attributes.Add("class", "col-sm-6 text-right");
                    Div_Col_Sm_6_ClientName_Label.InnerHtml = "<i>CLIENT NAME</i>";
                    Div_Row_ClientName.Controls.Add(Div_Col_Sm_6_ClientName_Label);

                    Div_Col_Sm_6_ClientName.Attributes.Add("class", "col-sm-6 text-left");
                    Div_Col_Sm_6_ClientName.InnerHtml = "<b>" + item.ClientName.ToUpper() + "</b>";
                    Div_Row_ClientName.Controls.Add(Div_Col_Sm_6_ClientName);

                    #endregion
                    #region Environment_Type

                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Row_Environment = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_EnvType_Label = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_EnvType = new System.Web.UI.HtmlControls.HtmlGenericControl("div");

                    Div_Row_Environment.Attributes.Add("class", "row");
                    Div_Card_Body.Controls.Add(Div_Row_Environment);

                    Div_Col_Sm_6_EnvType_Label.Attributes.Add("class", "col-sm-6 text-right");
                    Div_Col_Sm_6_EnvType_Label.InnerHtml = "<i>ENVIRONMENT TYPE</i>";
                    Div_Row_Environment.Controls.Add(Div_Col_Sm_6_EnvType_Label);

                    Div_Col_Sm_6_EnvType.Attributes.Add("class", "col-sm-6 text-left");
                    Div_Col_Sm_6_EnvType.InnerHtml = "<b>" + item.EnvironmentAppServerEnvType.ToUpper() + "</b>";
                    Div_Row_Environment.Controls.Add(Div_Col_Sm_6_EnvType);

                    #endregion
                    #region Product_Name

                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Row_Product = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_ProductName_Label = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_ProductName = new System.Web.UI.HtmlControls.HtmlGenericControl("div");

                    Div_Row_Product.Attributes.Add("class", "row");
                    Div_Row_Product.Style.Add("background-color", "lightgray");
                    Div_Card_Body.Controls.Add(Div_Row_Product);

                    Div_Col_Sm_6_ProductName_Label.Attributes.Add("class", "col-sm-6 text-right");
                    Div_Col_Sm_6_ProductName_Label.InnerHtml = "<i>PRODUCT NAME</i>";
                    Div_Row_Product.Controls.Add(Div_Col_Sm_6_ProductName_Label);

                    Div_Col_Sm_6_ProductName.Attributes.Add("class", "col-sm-6 text-left");
                    Div_Col_Sm_6_ProductName.InnerHtml = "<b>" + item.ProductName.ToUpper() + "</b>";
                    Div_Row_Product.Controls.Add(Div_Col_Sm_6_ProductName);

                    #endregion
                    #region Application_Server_Name

                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Row_App_Server_Name = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Server_Name_Label = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Server_Name = new System.Web.UI.HtmlControls.HtmlGenericControl("div");

                    Div_Row_App_Server_Name.Attributes.Add("class", "row");
                    Div_Card_Body.Controls.Add(Div_Row_App_Server_Name);

                    Div_Col_Sm_6_App_Server_Name_Label.Attributes.Add("class", "col-sm-6 text-right");
                    Div_Col_Sm_6_App_Server_Name_Label.InnerHtml = "<i>APPLICATION SERVER NAME</i>";
                    Div_Row_App_Server_Name.Controls.Add(Div_Col_Sm_6_App_Server_Name_Label);

                    Div_Col_Sm_6_App_Server_Name.Attributes.Add("class", "col-sm-6 text-left");
                    Div_Col_Sm_6_App_Server_Name.InnerHtml = "<b>" + item.EnvironmentAppServerName.ToUpper() + "</b>";
                    Div_Row_App_Server_Name.Controls.Add(Div_Col_Sm_6_App_Server_Name);

                    #endregion
                    #region Application_Server_OS

                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Row_App_OS = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_OS_Label = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_OS = new System.Web.UI.HtmlControls.HtmlGenericControl("div");

                    Div_Row_App_OS.Attributes.Add("class", "row");
                    Div_Row_App_OS.Style.Add("background-color", "lightgray");
                    Div_Card_Body.Controls.Add(Div_Row_App_OS);

                    Div_Col_Sm_6_App_OS_Label.Attributes.Add("class", "col-sm-6 text-right");
                    Div_Col_Sm_6_App_OS_Label.InnerHtml = "<i>APPLICATION SERVER OPERATING SYSTEM</i>";
                    Div_Row_App_OS.Controls.Add(Div_Col_Sm_6_App_OS_Label);

                    Div_Col_Sm_6_App_OS.Attributes.Add("class", "col-sm-6 text-left");
                    Div_Col_Sm_6_App_OS.InnerHtml = "<b>" + item.EnvironmentAppServerOS.ToUpper() + "</b>";
                    Div_Row_App_OS.Controls.Add(Div_Col_Sm_6_App_OS);

                    #endregion
                    #region Application_Server_OS_Build


                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Row_App_OS_Build = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_OS_Build_Label = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_OS_Build = new System.Web.UI.HtmlControls.HtmlGenericControl("div");

                    Div_Row_App_OS_Build.Attributes.Add("class", "row");
                    Div_Card_Body.Controls.Add(Div_Row_App_OS_Build);

                    Div_Col_Sm_6_App_OS_Build_Label.Attributes.Add("class", "col-sm-6 text-right");
                    Div_Col_Sm_6_App_OS_Build_Label.InnerHtml = "<i>Application SERVER OPERATING SYSTEM BUILD</i>";
                    Div_Row_App_OS_Build.Controls.Add(Div_Col_Sm_6_App_OS_Build_Label);

                    Div_Col_Sm_6_App_OS_Build.Attributes.Add("class", "col-sm-6 text-left");
                    Div_Col_Sm_6_App_OS_Build.InnerHtml = "<b>" + item.EnvironmentAppServerOSBuild + "</b>";
                    Div_Row_App_OS_Build.Controls.Add(Div_Col_Sm_6_App_OS_Build);

                    #endregion
                    #region Application_Server_WebBrowser


                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Row_App_WebBrower = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_WebBrowerLabel = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_WebBrower = new System.Web.UI.HtmlControls.HtmlGenericControl("div");

                    Div_Row_App_WebBrower.Attributes.Add("class", "row");
                    Div_Row_App_WebBrower.Style.Add("background-color", "lightgray");
                    Div_Card_Body.Controls.Add(Div_Row_App_WebBrower);

                    Div_Col_Sm_6_App_WebBrowerLabel.Attributes.Add("class", "col-sm-6 text-right");
                    Div_Col_Sm_6_App_WebBrowerLabel.InnerHtml = "<i>APPLICATION SERVER WEB BROWSER</i>";
                    Div_Row_App_WebBrower.Controls.Add(Div_Col_Sm_6_App_WebBrowerLabel);

                    Div_Col_Sm_6_App_WebBrower.Attributes.Add("class", "col-sm-6 text-left");
                    Div_Col_Sm_6_App_WebBrower.InnerHtml = "<b>" + item.EnvironmentAppServerWebBrowser.ToUpper() + "</b>";
                    Div_Row_App_WebBrower.Controls.Add(Div_Col_Sm_6_App_WebBrower);

                    #endregion
                    #region Application_Server_WebBrowser_Version


                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Row_App_WebBrower_Version = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_WebBrower_Version_Label = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_WebBrower_Version = new System.Web.UI.HtmlControls.HtmlGenericControl("div");

                    Div_Row_App_WebBrower_Version.Attributes.Add("class", "row");
                    Div_Card_Body.Controls.Add(Div_Row_App_WebBrower_Version);

                    Div_Col_Sm_6_App_WebBrower_Version_Label.Attributes.Add("class", "col-sm-6 text-right");
                    Div_Col_Sm_6_App_WebBrower_Version_Label.InnerHtml = "<i>APPLICATION SERVER WEB BROWSER VERSION</i>";
                    Div_Row_App_WebBrower_Version.Controls.Add(Div_Col_Sm_6_App_WebBrower_Version_Label);

                    Div_Col_Sm_6_App_WebBrower_Version.Attributes.Add("class", "col-sm-6 text-left");
                    Div_Col_Sm_6_App_WebBrower_Version.InnerHtml = "<b>" + item.EnvironmentAppServerWebBrowserVersion.ToUpper() + "</b>";
                    Div_Row_App_WebBrower_Version.Controls.Add(Div_Col_Sm_6_App_WebBrower_Version);

                    #endregion
                    #region Application_Server_Register


                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Row_App_Server_Register = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Server_Register_Label = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Server_Register = new System.Web.UI.HtmlControls.HtmlGenericControl("div");

                    Div_Row_App_Server_Register.Attributes.Add("class", "row");
                    Div_Row_App_Server_Register.Style.Add("background-color", "lightgray");
                    Div_Card_Body.Controls.Add(Div_Row_App_Server_Register);

                    Div_Col_Sm_6_App_Server_Register_Label.Attributes.Add("class", "col-sm-6 text-right");
                    Div_Col_Sm_6_App_Server_Register_Label.InnerHtml = "<i>APPLICATION SERVER IS 32-BIT</i>";
                    Div_Row_App_Server_Register.Controls.Add(Div_Col_Sm_6_App_Server_Register_Label);

                    Div_Col_Sm_6_App_Server_Register.Attributes.Add("class", "col-sm-6 text-left");
                    Div_Col_Sm_6_App_Server_Register.InnerHtml = "<b>" + item.EnvironmentAppServerIsX86Version.ToUpper() + "</b>";
                    Div_Row_App_Server_Register.Controls.Add(Div_Col_Sm_6_App_Server_Register);

                    #endregion
                    #region Application_Server_Virtualization


                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Row_App_Server_Virtualization = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Server_Virtualization_Label = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Server_Virtualization = new System.Web.UI.HtmlControls.HtmlGenericControl("div");

                    Div_Row_App_Server_Virtualization.Attributes.Add("class", "row");
                    Div_Card_Body.Controls.Add(Div_Row_App_Server_Virtualization);

                    Div_Col_Sm_6_App_Server_Virtualization_Label.Attributes.Add("class", "col-sm-6 text-right");
                    Div_Col_Sm_6_App_Server_Virtualization_Label.InnerHtml = "<i>APPLICATION SERVER IS VIRTUAL</i>";
                    Div_Row_App_Server_Virtualization.Controls.Add(Div_Col_Sm_6_App_Server_Virtualization_Label);

                    Div_Col_Sm_6_App_Server_Virtualization.Attributes.Add("class", "col-sm-6 text-left");
                    Div_Col_Sm_6_App_Server_Virtualization.InnerHtml = "<b>" + item.EnvironmentAppServerIsVirtual.ToUpper() + "</b>";
                    Div_Row_App_Server_Virtualization.Controls.Add(Div_Col_Sm_6_App_Server_Virtualization);

                    #endregion
                    #region Application_Server_IP


                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Row_App_Server_IP = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Server_IP_Label = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Server_IP = new System.Web.UI.HtmlControls.HtmlGenericControl("div");

                    Div_Row_App_Server_IP.Attributes.Add("class", "row");
                    Div_Row_App_Server_IP.Style.Add("background-color", "lightgray");
                    Div_Card_Body.Controls.Add(Div_Row_App_Server_IP);

                    Div_Col_Sm_6_App_Server_IP_Label.Attributes.Add("class", "col-sm-6 text-right");
                    Div_Col_Sm_6_App_Server_IP_Label.InnerHtml = "<i>APPLICATION SERVER IP</i>";
                    Div_Row_App_Server_IP.Controls.Add(Div_Col_Sm_6_App_Server_IP_Label);

                    Div_Col_Sm_6_App_Server_IP.Attributes.Add("class", "col-sm-6 text-left");
                    Div_Col_Sm_6_App_Server_IP.InnerHtml = "<b>" + item.EnvironmentAppServerIP + "</b>";
                    Div_Row_App_Server_IP.Controls.Add(Div_Col_Sm_6_App_Server_IP);

                    #endregion
                    #region Application_Server_Port


                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Row_App_Server_Port = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Row_App_OS_Build");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Server_Port_Label = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_App_OS_Build_Label");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Server_Port = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_App_OS_Build");

                    Div_Row_App_Server_Port.Attributes.Add("class", "row");
                    Div_Card_Body.Controls.Add(Div_Row_App_Server_Port);

                    Div_Col_Sm_6_App_Server_Port_Label.Attributes.Add("class", "col-sm-6 text-right");
                    Div_Col_Sm_6_App_Server_Port_Label.InnerHtml = "<i>APPLICATION RUNING ON PORT</i>";
                    Div_Row_App_Server_Port.Controls.Add(Div_Col_Sm_6_App_Server_Port_Label);

                    Div_Col_Sm_6_App_Server_Port.Attributes.Add("class", "col-sm-6 text-left");
                    Div_Col_Sm_6_App_Server_Port.InnerHtml = "<b>" + item.EnvironmentAppServerPort + "</b>";
                    Div_Row_App_Server_Port.Controls.Add(Div_Col_Sm_6_App_Server_Port);

                    #endregion
                    #region Application_Server_Memory


                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Row_App_Server_Memory = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Row_App_OS_Build");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Server_Memory_Label = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_App_OS_Build_Label");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Server_Memory = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_App_OS_Build");

                    Div_Row_App_Server_Memory.Attributes.Add("class", "row");
                    Div_Row_App_Server_Memory.Style.Add("background-color", "lightgray");
                    Div_Card_Body.Controls.Add(Div_Row_App_Server_Memory);

                    Div_Col_Sm_6_App_Server_Memory_Label.Attributes.Add("class", "col-sm-6 text-right");
                    Div_Col_Sm_6_App_Server_Memory_Label.InnerHtml = "<i>APPLICATION SERVER MEMORY</i>";
                    Div_Row_App_Server_Memory.Controls.Add(Div_Col_Sm_6_App_Server_Memory_Label);

                    Div_Col_Sm_6_App_Server_Memory.Attributes.Add("class", "col-sm-6 text-left");
                    Div_Col_Sm_6_App_Server_Memory.InnerHtml = "<b>" + item.EnvironmentAppServerMemory + "</b>";
                    Div_Row_App_Server_Memory.Controls.Add(Div_Col_Sm_6_App_Server_Memory);

                    #endregion
                    #region Application_Server_Processor


                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Row_App_Server_Processor = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Row_App_OS_Build");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Server_Processor_Label = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_App_OS_Build_Label");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Server_Processor = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_App_OS_Build");

                    Div_Row_App_Server_Processor.Attributes.Add("class", "row");
                    Div_Card_Body.Controls.Add(Div_Row_App_Server_Processor);

                    Div_Col_Sm_6_App_Server_Processor_Label.Attributes.Add("class", "col-sm-6 text-right");
                    Div_Col_Sm_6_App_Server_Processor_Label.InnerHtml = "<i>APPLICATION SERVER PROCESSOR</i>";
                    Div_Row_App_Server_Processor.Controls.Add(Div_Col_Sm_6_App_Server_Processor_Label);

                    Div_Col_Sm_6_App_Server_Processor.Attributes.Add("class", "col-sm-6 text-left");
                    Div_Col_Sm_6_App_Server_Processor.InnerHtml = "<b>" + item.EnvironmentAppServerProcessor.ToUpper() + "</b>";
                    Div_Row_App_Server_Processor.Controls.Add(Div_Col_Sm_6_App_Server_Processor);

                    #endregion
                    #region Application_Server_Link


                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Row_App_Link = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Row_App_OS_Build");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Link_Label = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_App_OS_Build_Label");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Link = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_App_OS_Build");

                    Div_Row_App_Link.Attributes.Add("class", "row");
                    Div_Row_App_Link.Style.Add("background-color", "lightgray");
                    Div_Card_Body.Controls.Add(Div_Row_App_Link);

                    Div_Col_Sm_6_App_Link_Label.Attributes.Add("class", "col-sm-6 text-right");
                    Div_Col_Sm_6_App_Link_Label.InnerHtml = "<i>APPLICATION LINK</i>";
                    Div_Row_App_Link.Controls.Add(Div_Col_Sm_6_App_Link_Label);

                    Div_Col_Sm_6_App_Link.Attributes.Add("class", "col-sm-6 text-left");
                    Div_Col_Sm_6_App_Link.InnerHtml = "<b>" + item.EnvironmentAppHyperLink + "</b>";
                    Div_Row_App_Link.Controls.Add(Div_Col_Sm_6_App_Link);

                    #endregion
                    #region Application_Working_Directory


                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Row_App_Working_Directory = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Row_App_OS_Build");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Working_Directory_Label = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_App_OS_Build_Label");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Working_Directory = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_App_OS_Build");

                    Div_Row_App_Working_Directory.Attributes.Add("class", "row");
                    Div_Card_Body.Controls.Add(Div_Row_App_Working_Directory);

                    Div_Col_Sm_6_App_Working_Directory_Label.Attributes.Add("class", "col-sm-6 text-right");
                    Div_Col_Sm_6_App_Working_Directory_Label.InnerHtml = "<i>APPLICATION WORKING DIRECTORY</i>";
                    Div_Row_App_Working_Directory.Controls.Add(Div_Col_Sm_6_App_Working_Directory_Label);

                    Div_Col_Sm_6_App_Working_Directory.Attributes.Add("class", "col-sm-6 text-left");
                    Div_Col_Sm_6_App_Working_Directory.InnerHtml = "<b>" + item.EnvironmentAppServerWorkingDirectoryLocation + "</b>";
                    Div_Row_App_Working_Directory.Controls.Add(Div_Col_Sm_6_App_Working_Directory);

                    #endregion
                    #region Application_Server_Dependency


                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Row_App_Server_Dependency = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Row_App_OS_Build");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Server_Dependency_Label = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_App_OS_Build_Label");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Server_Dependency = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_App_OS_Build");

                    Div_Row_App_Server_Dependency.Attributes.Add("class", "row");
                    Div_Row_App_Server_Dependency.Style.Add("background-color", "lightgray");
                    Div_Card_Body.Controls.Add(Div_Row_App_Server_Dependency);

                    Div_Col_Sm_6_App_Server_Dependency_Label.Attributes.Add("class", "col-sm-6 text-right");
                    Div_Col_Sm_6_App_Server_Dependency_Label.InnerHtml = "<i>APPLICATION SERVER DEPENDENCY</i>";
                    Div_Row_App_Server_Dependency.Controls.Add(Div_Col_Sm_6_App_Server_Dependency_Label);

                    Div_Col_Sm_6_App_Server_Dependency.Attributes.Add("class", "col-sm-6 text-left");
                    Div_Col_Sm_6_App_Server_Dependency.InnerHtml = "<b>" + item.EnvironmentAppServerDependency.ToUpper() + "</b>";
                    Div_Row_App_Server_Dependency.Controls.Add(Div_Col_Sm_6_App_Server_Dependency);

                    #endregion

                    // Adding Database and Middleware Logic
                    List<DataSource_Database> Db_DataSources = dbcon.getAllDatabaseDataSourceDesc(Convert.ToInt32(item.EnvironmentID));
                    List<DataSource_Middleware> Mdw_DataSources = dbcon.getAllMiddlewareDataSourceDesc(Convert.ToInt32(item.EnvironmentID));
                    //int DataSources = dbcon.getAllDataSources(Convert.ToInt32(item.EnvironmentID));
                    int DataSources = Db_DataSources.Count + Mdw_DataSources.Count;

                    System.Web.UI.HtmlControls.HtmlGenericControl Div_DataSource = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                    Div_DataSource.Attributes.Add("class", "card bg-light");
                    Div_DataSource.ID = "Div_DataSource" + count;
                    Div_DataSource.Style.Add("margin", "5px");
                    //Div_DataSource.InnerHtml = "<p>There is no data source for this application exist.</p>";
                    Div_Collapse.Controls.Add(Div_DataSource);

                    System.Web.UI.HtmlControls.HtmlGenericControl Div_DataSource_Element_Container = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                    Div_DataSource_Element_Container.Attributes.Add("class", "card-columns");
                    Div_DataSource_Element_Container.ID = "Div_DataSource_Element_Container" + count;
                    Div_DataSource_Element_Container.Style.Add("margin-left", "4px");
                    Div_DataSource_Element_Container.Style.Add("margin-right", "4px");
                    Div_DataSource_Element_Container.Style.Add("margin-top", "6px");
                    Div_DataSource_Element_Container.Style.Add("margin-bottom", "6px");
                    Div_DataSource.Controls.Add(Div_DataSource_Element_Container);

                    if (DataSources == 0)
                    {

                        System.Web.UI.HtmlControls.HtmlGenericControl Div_DataSource_Element = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                        Div_DataSource_Element.Attributes.Add("class", "card-body text-center");
                        Div_DataSource_Element.ID = "Div_DataSource_Element" + count;
                        //Div_DataSource_Element.Style.Add("margin", "5px");
                        Div_DataSource.Controls.Add(Div_DataSource_Element);

                        System.Web.UI.HtmlControls.HtmlGenericControl Div_DataSource_Element_Text = new System.Web.UI.HtmlControls.HtmlGenericControl("p");
                        Div_DataSource_Element_Text.Attributes.Add("class", "card-text");
                        Div_DataSource_Element_Text.ID = "div_DataSource_Element_Text" + count;
                        Div_DataSource_Element_Text.InnerText = "There is no data source exist in this environment.";
                        Div_DataSource_Element.Controls.Add(Div_DataSource_Element_Text);
                    }

                    else
                    {
                        #region Database Logic

                        // Adding Database Logic

                        foreach(var dt in Db_DataSources) {

                            //Create Model

                            System.Web.UI.HtmlControls.HtmlGenericControl Div_Model_Fade = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            Div_Model_Fade.Attributes.Add("class", "modal fade");
                            Div_Model_Fade.Attributes.Add("data-backdrop", "static");
                            Div_Model_Fade.Attributes.Add("data-keyboard", "false");
                            Div_Model_Fade.ID = "myModal" + count + dt.DB_NAME.Replace(" ","");
                            Div_Collapse.Controls.Add(Div_Model_Fade);

                            System.Web.UI.HtmlControls.HtmlGenericControl Div_Model_Dialog = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            Div_Model_Dialog.Attributes.Add("class", "modal-dialog");
                            Div_Model_Dialog.ID = "myModalDialog" + count + dt.DB_NAME;
                            Div_Model_Fade.Controls.Add(Div_Model_Dialog);

                            System.Web.UI.HtmlControls.HtmlGenericControl Div_Model_Content = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            Div_Model_Content.Attributes.Add("class", "modal-content");
                            Div_Model_Content.ID = "myModalContent" + count + dt.DB_NAME;
                            Div_Model_Dialog.Controls.Add(Div_Model_Content);

                            System.Web.UI.HtmlControls.HtmlGenericControl Div_Model_Content_Header = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            Div_Model_Content_Header.Attributes.Add("class", "modal-header");
                            Div_Model_Content_Header.ID = "myModalContentHeader" + count + dt.DB_NAME;
                            Div_Model_Content_Header.InnerHtml = "<h4 class=\"modal-title\">" + dt.DB_NAME + " Details" + "</h4><button type=\"button\" class=\"close\" data-dismiss=\"modal\">×</button>";
                            Div_Model_Content.Controls.Add(Div_Model_Content_Header);

                            System.Web.UI.HtmlControls.HtmlGenericControl Div_Model_Content_Body = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            Div_Model_Content_Body.Attributes.Add("class", "modal-body");
                            Div_Model_Content_Body.ID = "myModalContentBody" + count + dt.DB_NAME;
                            Div_Model_Content_Body.InnerHtml = "<table class=\"table\" style=\"width:100%\"><tr class=\"table-light\"><td>Database ID</td><td>" + dt.DB_ID + "</td></tr><tr><td>Database Name</td><td>" + dt.DB_NAME + "</td></tr><tr><td>Environment ID</td><td>" + dt.DB_ENV_ID + "</td></tr><tr><td>Server IP</td><td>" + dt.DB_SERVER_IP + "</td></tr><tr><td>Server Name</td><td>" + dt.DB_SERVER_NAME + "</td></tr><tr><td>Server Instance</td><td>" + dt.DB_SERVER_INSTANCE + "</td></tr><tr><td>Login</td><td>" + dt.DB_SERVER_LOGIN + "</td></tr><tr><td>Password</td><td>" + dt.DB_SERVER_PASSWORD + "</td></tr><tr><td>Database Running Port</td><td>" + dt.DB_SERVER_PORT + "</td></tr><tr><td>Server Operating System</td><td>" + dt.DB_SERVER_OS + "</td></tr><tr><td>Server Operating System Version</td><td>" + dt.DB_SERVER_OS_BUILD + "</td></tr><tr><td>Server OS 32 or 64 Bit</td><td>" + dt.DB_SERVER_REGISTER_TYPE + "</td></tr><tr><td>Server Physical or Virtual</td><td>" + dt.DB_SERVER_VIRTUALIZATION + "</td></tr><tr><td>Server Memory</td><td>" + dt.DB_SERVER_MEMORY + "</td></tr><tr><td>Server Processor</td><td>" + dt.DB_SERVER_PROCESSOR + "</td></tr><tr><td>Is Administrative Database</td><td>" + dt.DB_SERVER_ADMINISTRATOR + "</td></tr><tr><td>Database Directory Location</td><td>" + dt.DB_DIRECTORY_LOCATION + "</td></tr><tr><td>Database MDF File Location</td><td>" + dt.DB_MDF_FILE_LOCATION + "</td></tr><tr><td>Database LDF File Location</td><td>" + dt.DB_LDF_FILE_LOCATION + "</td></tr><tr><td>Database MDF File Size</td><td>" + dt.DB_MDF_FILE_SIZE + "</td></tr><tr><td>Database LDF File Size</td><td>" + dt.DB_LDF_FILE_SIZE + "</td></tr><tr><td>Database Last Backup Date</td><td>" + dt.DB_LAST_BACKUP_DATE + "</td></tr><tr><td>Database Last Restored Date</td><td>" + dt.DB_LAST_RESTORE_DATE + "</td></tr><tr><td>Database Server Dependency</td><td>" + dt.DB_SERVER_DEPENDENCY + "</td></tr><tr><td>Database Vendor ID</td><td>" + dt.DB_VENDER_ID + "</td></tr><tr><td>Database Vendor Name</td><td>" + dt.DB_VENDER_NAME + "</td></tr><tr><td>Database Vendor Description</td><td>" + dt.DB_VENDER_DESC + "</td></tr><tr><td>Database Vendor Image Source</td><td>" + dt.DB_VENDER_IMAGE_SRC + "</td></tr><tr><td>Database Hash</td><td>" + dt.DB_HASH + "</td></tr></table>";
                            //Div_Model_Content_Body.InnerHtml = "<tr class=\"table-light\"><td>Database ID</td><td>" + dt.DB_ID + "</td></tr>" +
                            //                                   "<tr class=\"table-light\"><td>Database Name</td><td>" + dt.DB_NAME + "</td></tr>";
                            Div_Model_Content.Controls.Add(Div_Model_Content_Body);

                            //System.Web.UI.HtmlControls.HtmlGenericControl Div_Model_Content_Body_Container = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            //Div_Model_Content_Body_Container.Attributes.Add("class", "container");
                            //Div_Model_Content_Body_Container.ID = "myModalContentBodyContainer" + count + dt.DB_NAME;
                            ////Div_Model_Content_Body.InnerHtml = "";
                            //Div_Model_Content_Body.Controls.Add(Div_Model_Content_Body_Container);

                            //System.Web.UI.HtmlControls.HtmlGenericControl Div_Model_Content_Body_Container_Table = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            //Div_Model_Content_Body_Container_Table.Attributes.Add("class", "table");
                            //Div_Model_Content_Body_Container_Table.ID = "myModalContentBodyContainerTable" + count + dt.DB_NAME;
                            ////Div_Model_Content_Body.InnerHtml = "";
                            //Div_Model_Content.Controls.Add(Div_Model_Content_Body_Container_Table);

                            //System.Web.UI.HtmlControls.HtmlGenericControl Div_Model_Content_Body_Container_Table_tbody = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            //Div_Model_Content_Body_Container_Table_tbody.Attributes.Add("class", "tbody");
                            //Div_Model_Content_Body_Container_Table_tbody.ID = "myModalContentBodyContainerTabletbody" + count + dt.DB_NAME;
                            //Div_Model_Content_Body_Container_Table_tbody.InnerHtml = "<tr class=\"table-light\"><td>Database ID</td><td>"+dt.DB_ID+"</td></tr>" +
                            //                                                         "<tr class=\"table-light\"><td>Database Name</td><td>" + dt.DB_NAME + "</td></tr>";
                            //Div_Model_Content.Controls.Add(Div_Model_Content_Body_Container_Table_tbody);

                            System.Web.UI.HtmlControls.HtmlGenericControl Div_Model_Content_Footer = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            Div_Model_Content_Footer.Attributes.Add("class", "modal-footer");
                            Div_Model_Content_Footer.ID = "myModalContentFooter" + count + dt.DB_NAME;
                            Div_Model_Content_Footer.InnerHtml = "<button type=\"button\" class=\"btn btn-danger\" data-dismiss=\"modal\">Close</button>";
                            Div_Model_Content.Controls.Add(Div_Model_Content_Footer);


                            //Model End

                            System.Web.UI.HtmlControls.HtmlGenericControl Div_DataSource_Element = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            Div_DataSource_Element.Attributes.Add("class", "card bg-primary text-white");
                            Div_DataSource_Element.ID = "Div_DataSource_Element" + count + dt.DB_NAME;
                            Div_DataSource_Element.Style.Add("padding-top", "10px");
                            Div_DataSource_Element.Style.Add("padding-left", "5px");
                            Div_DataSource_Element.Style.Add("padding-right", "5px");
                            Div_DataSource_Element.Style.Add("padding-bottom", "10px");
                            //Div_DataSource_Element.InnerHtml = "<p>DataSources</p>";
                            Div_DataSource_Element_Container.Controls.Add(Div_DataSource_Element);

                            //System.Web.UI.HtmlControls.HtmlGenericControl Div_DataSource_Element_Container_Children = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            //Div_DataSource_Element_Container_Children.Attributes.Add("class", "container-fluid");
                            //Div_DataSource_Element_Container_Children.ID = "Div_DataSource_Element_Container_Children" + count + i;
                            ////Div_DataSource_Element.InnerHtml = "<p>DataSources</p>";
                            //Div_DataSource_Element.Controls.Add(Div_DataSource_Element_Container_Children);

                            System.Web.UI.HtmlControls.HtmlGenericControl Div_DataSource_Element_Child_Row_1 = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            Div_DataSource_Element_Child_Row_1.Attributes.Add("class", "row");
                            Div_DataSource_Element_Child_Row_1.ID = "Div_DataSource_Element_Child_Row_1" + count + dt.DB_NAME;
                            //Div_DataSource_Element.InnerHtml = "<p>DataSources</p>";
                            Div_DataSource_Element.Controls.Add(Div_DataSource_Element_Child_Row_1);

                            System.Web.UI.HtmlControls.HtmlGenericControl Div_DataSource_Element_Child_Col_1 = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            Div_DataSource_Element_Child_Col_1.Attributes.Add("class", "col");
                            Div_DataSource_Element_Child_Col_1.ID = "Div_DataSource_Element_Child_Col_1" + count + dt.DB_NAME;
                            Div_DataSource_Element_Child_Col_1.InnerHtml = "<img ID=\"Image" + count + "\" runat=\"server\" src=\""+dt.DB_VENDER_IMAGE_SRC+"\" Width=\"100\" Height=\"70\" style=\"margin:5px;\" />";
                            Div_DataSource_Element_Child_Row_1.Controls.Add(Div_DataSource_Element_Child_Col_1);

                            System.Web.UI.HtmlControls.HtmlGenericControl Div_DataSource_Element_Child_Row_2 = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            Div_DataSource_Element_Child_Row_2.Attributes.Add("class", "row");
                            Div_DataSource_Element_Child_Row_2.ID = "Div_DataSource_Element_Child_Row_2" + count + dt.DB_NAME;
                            //Div_DataSource_Element.InnerHtml = "<p class="card-text">DataSources</p>";
                            Div_DataSource_Element.Controls.Add(Div_DataSource_Element_Child_Row_2);

                            System.Web.UI.HtmlControls.HtmlGenericControl Div_DataSource_Element_Child_Col_2 = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            Div_DataSource_Element_Child_Col_2.Attributes.Add("class", "col");
                            Div_DataSource_Element_Child_Col_2.ID = "Div_DataSource_Element_Child_Col_2" + count + dt.DB_NAME;
                            Div_DataSource_Element_Child_Col_2.InnerHtml = "<p class=\"card-text\" style=\"font-weight:bold\">"+dt.DB_NAME+"</p>";
                            Div_DataSource_Element_Child_Row_2.Controls.Add(Div_DataSource_Element_Child_Col_2);

                            System.Web.UI.HtmlControls.HtmlGenericControl Div_DataSource_Element_Child_Row_3 = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            Div_DataSource_Element_Child_Row_3.Attributes.Add("class", "row");
                            Div_DataSource_Element_Child_Row_3.ID = "Div_DataSource_Element_Child_Row_3" + count + dt.DB_NAME;
                            //Div_DataSource_Element.InnerHtml = "<p class=\"card-text\">"++"</p>";
                            Div_DataSource_Element.Controls.Add(Div_DataSource_Element_Child_Row_3);

                            System.Web.UI.HtmlControls.HtmlGenericControl Div_DataSource_Element_Child_Col_3 = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            Div_DataSource_Element_Child_Col_3.Attributes.Add("class", "col");
                            Div_DataSource_Element_Child_Col_3.ID = "Div_DataSource_Element_Child_Col_3" + count + dt.DB_NAME;
                            Div_DataSource_Element_Child_Col_3.InnerHtml = "<p class=\"card-text\" style=\"color:white;font-size:12px;font-weight:italic\">"+dt.TYPE+"</p>";
                            Div_DataSource_Element_Child_Row_3.Controls.Add(Div_DataSource_Element_Child_Col_3);

                            System.Web.UI.HtmlControls.HtmlGenericControl Div_DataSource_Element_Child_Row_4 = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            Div_DataSource_Element_Child_Row_4.Attributes.Add("class", "row");
                            Div_DataSource_Element_Child_Row_4.ID = "Div_DataSource_Element_Child_Row_4" + count + dt.DB_NAME;
                            //Div_DataSource_Element_Child_Row_3.InnerHtml = "<p class=\"card-text\">DataSources</p>";
                            Div_DataSource_Element.Controls.Add(Div_DataSource_Element_Child_Row_4);

                            System.Web.UI.HtmlControls.HtmlGenericControl Div_DataSource_Element_Child_Col_4 = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            Div_DataSource_Element_Child_Col_4.Attributes.Add("class", "col");
                            Div_DataSource_Element_Child_Col_4.ID = "Div_DataSource_Element_Child_Col_4" + count + dt.DB_NAME;
                            Div_DataSource_Element_Child_Col_4.InnerHtml = "<button id=\"btnExpandExpert" + count + dt.DB_NAME.Replace(" ","") + "\" type=\"button\" class=\"btn btn-primary\" data-toggle=\"modal\" data-target=\"#MainContent_myModal" + count + dt.DB_NAME.Replace(" ","") + "\" >View Details</button>";
                            Div_DataSource_Element_Child_Row_4.Controls.Add(Div_DataSource_Element_Child_Col_4);
                        }

                        #endregion

                        #region Middleware Logic

                        // Adding Middleware Logic

                        foreach (var dt in Mdw_DataSources)
                        {
                            //Create Model

                            System.Web.UI.HtmlControls.HtmlGenericControl Div_Model_Fade = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            Div_Model_Fade.Attributes.Add("class", "modal fade");
                            Div_Model_Fade.Attributes.Add("data-backdrop", "static");
                            Div_Model_Fade.Attributes.Add("data-keyboard", "false");
                            Div_Model_Fade.ID = "myModal" + count + dt.MDW_NAME.Replace(" ", "");
                            Div_Collapse.Controls.Add(Div_Model_Fade);

                            System.Web.UI.HtmlControls.HtmlGenericControl Div_Model_Dialog = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            Div_Model_Dialog.Attributes.Add("class", "modal-dialog");
                            Div_Model_Dialog.ID = "myModalDialog" + count + dt.MDW_NAME;
                            Div_Model_Fade.Controls.Add(Div_Model_Dialog);

                            System.Web.UI.HtmlControls.HtmlGenericControl Div_Model_Content = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            Div_Model_Content.Attributes.Add("class", "modal-content");
                            Div_Model_Content.ID = "myModalContent" + count + dt.MDW_NAME;
                            Div_Model_Dialog.Controls.Add(Div_Model_Content);

                            System.Web.UI.HtmlControls.HtmlGenericControl Div_Model_Content_Header = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            Div_Model_Content_Header.Attributes.Add("class", "modal-header");
                            Div_Model_Content_Header.ID = "myModalContentHeader" + count + dt.MDW_NAME;
                            Div_Model_Content_Header.InnerHtml = "<h4 class=\"modal-title\">" + dt.MDW_NAME + " Details" + "</h4><button type=\"button\" class=\"close\" data-dismiss=\"modal\">×</button>";
                            Div_Model_Content.Controls.Add(Div_Model_Content_Header);

                            System.Web.UI.HtmlControls.HtmlGenericControl Div_Model_Content_Body = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            Div_Model_Content_Body.Attributes.Add("class", "modal-body");
                            Div_Model_Content_Body.ID = "myModalContentBody" + count + dt.MDW_NAME;
                            Div_Model_Content_Body.InnerHtml = "<table class=\"table\" style=\"width:100%\"><tr class=\"table-light\"><td>Database ID</td><td>" + dt.MDW_ID + "</td></tr><tr><td>Middleware Name</td><td>" + dt.MDW_NAME + "</td></tr><tr><td>Environment ID</td><td>" + dt.MDW_ENV_ID + "</td></tr><tr><td>Server IP</td><td>" + dt.MDW_SERVER_IP + "</td></tr><tr><td>Server Name</td><td>" + dt.MDW_SERVER_NAME + "</td></tr><tr><td>Middleware Access key</td><td>" + dt.MDW_ACCESS_KEY + "</td></tr><tr><td>Login</td><td>" + dt.MDW_SERVER_LOGIN + "</td></tr><tr><td>Password</td><td>" + dt.MDW_SERVER_PASSWORD + "</td></tr><tr><td>Database Running Port</td><td>" + dt.MDW_SERVER_PORT + "</td></tr><tr><td>Server Operating System</td><td>" + dt.MDW_SERVER_OS + "</td></tr><tr><td>Server Operating System Version</td><td>" + dt.MDW_SERVER_OS_BUILD + "</td></tr><tr><td>Server OS 32 or 64 Bit</td><td>" + dt.MDW_SERVER_REGISTER_TYPE + "</td></tr><tr><td>Server Physical or Virtual</td><td>" + dt.MDW_SERVER_VIRTUALIZATION + "</td></tr><tr><td>Server Memory</td><td>" + dt.MDW_SERVER_MEMORY + "</td></tr><tr><td>Server Processor</td><td>" + dt.MDW_SERVER_PROCESSOR + "</td></tr><tr><td>Middleware Type</td><td>" + dt.MDW_TYPE + "</td></tr><tr><td>Directory Location</td><td>" + dt.MDW_DIRECTORY_LOCATION + "</td></tr><tr><td>Middleware Hyper Link</td><td>" + dt.MDW_LINK + "</td></tr><tr><td>Middleware Database MDF File Location</td><td>" + dt.MDW_MDF_FILE_LOCATION + "</td></tr><tr><td>Middleware Database LDF File Location</td><td>" + dt.MDW_LDF_FILE_LOCATION + "</td></tr><tr><td>Middleware Database MDF File Size</td><td>" + dt.MDW_MDF_FILE_SIZE + "</td></tr><tr><td>Middleware Database LDF File Size</td><td>" + dt.MDW_LDF_FILE_SIZE + "</td></tr><tr><td>Middleware Database Last Backup Date</td><td>" + dt.MDW_DATABASE_LAST_BACKUP_DATE + "</td></tr><tr><td>Middleware Database Last Restored Date</td><td>" + dt.MDW_DATABASE_LAST_RESTORE_DATE + "</td></tr><tr><td>Middleware Server Dependency</td><td>" + dt.MDW_SERVER_DEPENDENCY + "</td></tr><tr><td>Middleware Vendor ID</td><td>" + dt.MDW_VENDER_ID + "</td></tr><tr><td>Middleware Vendor Name</td><td>" + dt.MDW_VENDER_NAME + "</td></tr><tr><td>Middleware Vendor Description</td><td>" + dt.MDW_VENDER_DESC + "</td></tr><tr><td>Database Vendor Image Source</td><td>" + dt.MDW_VENDER_IMAGE_SRC + "</td></tr><tr><td>Middleware Web Server</td><td>" + dt.MDW_WEB_SERVER + "</td></tr><tr><td>Middleware Web Server Version</td><td>" + dt.MDW_WEB_SERVER_VERSION + "</td></tr><tr><td>Middleware Documentation Link</td><td>" + dt.MDW_DOCUMENTATION_LOCATION + "</td></tr><tr><td>Middleware Directory Hash Value</td><td>" + dt.MDW_HASH + "</td></tr></table>";
                            //Div_Model_Content_Body.InnerHtml = "<tr class=\"table-light\"><td>Database ID</td><td>" + dt.DB_ID + "</td></tr>" +
                            //                                   "<tr class=\"table-light\"><td>Database Name</td><td>" + dt.DB_NAME + "</td></tr>";
                            Div_Model_Content.Controls.Add(Div_Model_Content_Body);

                            //System.Web.UI.HtmlControls.HtmlGenericControl Div_Model_Content_Body_Container = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            //Div_Model_Content_Body_Container.Attributes.Add("class", "container");
                            //Div_Model_Content_Body_Container.ID = "myModalContentBodyContainer" + count + dt.DB_NAME;
                            ////Div_Model_Content_Body.InnerHtml = "";
                            //Div_Model_Content_Body.Controls.Add(Div_Model_Content_Body_Container);

                            //System.Web.UI.HtmlControls.HtmlGenericControl Div_Model_Content_Body_Container_Table = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            //Div_Model_Content_Body_Container_Table.Attributes.Add("class", "table");
                            //Div_Model_Content_Body_Container_Table.ID = "myModalContentBodyContainerTable" + count + dt.DB_NAME;
                            ////Div_Model_Content_Body.InnerHtml = "";
                            //Div_Model_Content.Controls.Add(Div_Model_Content_Body_Container_Table);

                            //System.Web.UI.HtmlControls.HtmlGenericControl Div_Model_Content_Body_Container_Table_tbody = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            //Div_Model_Content_Body_Container_Table_tbody.Attributes.Add("class", "tbody");
                            //Div_Model_Content_Body_Container_Table_tbody.ID = "myModalContentBodyContainerTabletbody" + count + dt.DB_NAME;
                            //Div_Model_Content_Body_Container_Table_tbody.InnerHtml = "<tr class=\"table-light\"><td>Database ID</td><td>"+dt.DB_ID+"</td></tr>" +
                            //                                                         "<tr class=\"table-light\"><td>Database Name</td><td>" + dt.DB_NAME + "</td></tr>";
                            //Div_Model_Content.Controls.Add(Div_Model_Content_Body_Container_Table_tbody);

                            System.Web.UI.HtmlControls.HtmlGenericControl Div_Model_Content_Footer = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            Div_Model_Content_Footer.Attributes.Add("class", "modal-footer");
                            Div_Model_Content_Footer.ID = "myModalContentFooter" + count + dt.MDW_NAME;
                            Div_Model_Content_Footer.InnerHtml = "<button type=\"button\" class=\"btn btn-danger\" data-dismiss=\"modal\">Close</button>";
                            Div_Model_Content.Controls.Add(Div_Model_Content_Footer);


                            //Model End

                            System.Web.UI.HtmlControls.HtmlGenericControl Div_DataSource_Element = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            Div_DataSource_Element.Attributes.Add("class", "card bg-primary text-white");
                            Div_DataSource_Element.ID = "Div_DataSource_Element" + count + dt.MDW_NAME;
                            Div_DataSource_Element.Style.Add("padding-top", "10px");
                            Div_DataSource_Element.Style.Add("padding-left", "5px");
                            Div_DataSource_Element.Style.Add("padding-right", "5px");
                            Div_DataSource_Element.Style.Add("padding-bottom", "10px");
                            //Div_DataSource_Element.InnerHtml = "<p>DataSources</p>";
                            Div_DataSource_Element_Container.Controls.Add(Div_DataSource_Element);

                            //System.Web.UI.HtmlControls.HtmlGenericControl Div_DataSource_Element_Container_Children = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            //Div_DataSource_Element_Container_Children.Attributes.Add("class", "container-fluid");
                            //Div_DataSource_Element_Container_Children.ID = "Div_DataSource_Element_Container_Children" + count + i;
                            ////Div_DataSource_Element.InnerHtml = "<p>DataSources</p>";
                            //Div_DataSource_Element.Controls.Add(Div_DataSource_Element_Container_Children);

                            System.Web.UI.HtmlControls.HtmlGenericControl Div_DataSource_Element_Child_Row_1 = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            Div_DataSource_Element_Child_Row_1.Attributes.Add("class", "row");
                            Div_DataSource_Element_Child_Row_1.ID = "Div_DataSource_Element_Child_Row_1" + count + dt.MDW_NAME;
                            //Div_DataSource_Element.InnerHtml = "<p>DataSources</p>";
                            Div_DataSource_Element.Controls.Add(Div_DataSource_Element_Child_Row_1);

                            System.Web.UI.HtmlControls.HtmlGenericControl Div_DataSource_Element_Child_Col_1 = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            Div_DataSource_Element_Child_Col_1.Attributes.Add("class", "col");
                            Div_DataSource_Element_Child_Col_1.ID = "Div_DataSource_Element_Child_Col_1" + count + dt.MDW_NAME;
                            Div_DataSource_Element_Child_Col_1.InnerHtml = "<img ID=\"Image" + count + "\" runat=\"server\" src=\"" + dt.MDW_VENDER_IMAGE_SRC + "\" Width=\"100\" Height=\"70\" style=\"margin:5px;\" />";
                            Div_DataSource_Element_Child_Row_1.Controls.Add(Div_DataSource_Element_Child_Col_1);

                            System.Web.UI.HtmlControls.HtmlGenericControl Div_DataSource_Element_Child_Row_2 = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            Div_DataSource_Element_Child_Row_2.Attributes.Add("class", "row");
                            Div_DataSource_Element_Child_Row_2.ID = "Div_DataSource_Element_Child_Row_2" + count + dt.MDW_NAME;
                            //Div_DataSource_Element.InnerHtml = "<p class="card-text">DataSources</p>";
                            Div_DataSource_Element.Controls.Add(Div_DataSource_Element_Child_Row_2);

                            System.Web.UI.HtmlControls.HtmlGenericControl Div_DataSource_Element_Child_Col_2 = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            Div_DataSource_Element_Child_Col_2.Attributes.Add("class", "col");
                            Div_DataSource_Element_Child_Col_2.ID = "Div_DataSource_Element_Child_Col_2" + count + dt.MDW_NAME;
                            Div_DataSource_Element_Child_Col_2.InnerHtml = "<p class=\"card-text\" style=\"font-weight:bold\">" + dt.MDW_NAME + "</p>";
                            Div_DataSource_Element_Child_Row_2.Controls.Add(Div_DataSource_Element_Child_Col_2);

                            System.Web.UI.HtmlControls.HtmlGenericControl Div_DataSource_Element_Child_Row_3 = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            Div_DataSource_Element_Child_Row_3.Attributes.Add("class", "row");
                            Div_DataSource_Element_Child_Row_3.ID = "Div_DataSource_Element_Child_Row_3" + count + dt.MDW_NAME;
                            //Div_DataSource_Element.InnerHtml = "<p class=\"card-text\">"++"</p>";
                            Div_DataSource_Element.Controls.Add(Div_DataSource_Element_Child_Row_3);

                            System.Web.UI.HtmlControls.HtmlGenericControl Div_DataSource_Element_Child_Col_3 = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            Div_DataSource_Element_Child_Col_3.Attributes.Add("class", "col");
                            Div_DataSource_Element_Child_Col_3.ID = "Div_DataSource_Element_Child_Col_3" + count + dt.MDW_NAME;
                            Div_DataSource_Element_Child_Col_3.InnerHtml = "<p class=\"card-text\" style=\"color:white;font-size:12px;font-weight:italic\">" + dt.TYPE + "</p>";
                            Div_DataSource_Element_Child_Row_3.Controls.Add(Div_DataSource_Element_Child_Col_3);

                            System.Web.UI.HtmlControls.HtmlGenericControl Div_DataSource_Element_Child_Row_4 = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            Div_DataSource_Element_Child_Row_4.Attributes.Add("class", "row");
                            Div_DataSource_Element_Child_Row_4.ID = "Div_DataSource_Element_Child_Row_4" + count + dt.MDW_NAME;
                            //Div_DataSource_Element_Child_Row_3.InnerHtml = "<p class=\"card-text\">DataSources</p>";
                            Div_DataSource_Element.Controls.Add(Div_DataSource_Element_Child_Row_4);

                            System.Web.UI.HtmlControls.HtmlGenericControl Div_DataSource_Element_Child_Col_4 = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            Div_DataSource_Element_Child_Col_4.Attributes.Add("class", "col");
                            Div_DataSource_Element_Child_Col_4.ID = "Div_DataSource_Element_Child_Col_4" + count + dt.MDW_NAME;
                            Div_DataSource_Element_Child_Col_4.InnerHtml = "<button id=\"btnExpandExpert" + count + dt.MDW_NAME.Replace(" ", "") + "\" type=\"button\" class=\"btn btn-primary\" data-toggle=\"modal\" data-target=\"#MainContent_myModal" + count + dt.MDW_NAME.Replace(" ", "") + "\" >View Details</button>";
                            Div_DataSource_Element_Child_Row_4.Controls.Add(Div_DataSource_Element_Child_Col_4);
                        }

                        #endregion

                    }

                    // END

                    TableRow row0 = new TableRow();

                    TableCell cellClient1 = new TableCell();
                    cellClient1.Height = 40;
                    cellClient1.ForeColor = Color.White;
                    cellClient1.BackColor = ColorTranslator.FromHtml("#3A4F63");
                    cellClient1.Style.Add("Font-Size", "22px");
                    cellClient1.Text = "Environment " + ++count;
                    cellClient1.HorizontalAlign = HorizontalAlign.Center;
                    cellClient1.ColumnSpan = 10;
                    row0.Cells.Add(cellClient1);

                }

                log.DetailLog("EnvironmentInfo.aspx.cs", "Page_Load", STATE.COMPLETED, "Method: Page_Load Inn Class: EnvironmentInfo.aspx.cs Has Completed Its Execution Successfully.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
                log.ErrorLog("EnvironmentInfo.aspx.cs", "Page_Load", ExceptionType.SQLException, ex);
                log.DetailLog("EnvironmentInfo.aspx.cs", "Page_Load", STATE.INTERRUPTED, ex.Message);
                Response.Redirect("ErrorPages\\Error500.aspx?Param=EnvironmentInfo.aspx&Exception="+ex.Message, false);
            }
            finally {
                
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
                TallyRecords.InnerText = "Total Records Found # " + total;
                //totalRecords.Text = "Total Number of Records: " + total;

                // START
                TableRow row000 = new TableRow();
                row000.Style.Add("width", "100%");
                TableCell cell1 = new TableCell();
                cell1.HorizontalAlign = HorizontalAlign.Center;
                cell1.ColumnSpan = 10;

                row000.Controls.Add(cell1);
                tblInfo.Rows.Add(row000);

                foreach (var item in latestPatchOfClient)
                {

                    #region Layout

                    // Layout

                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Card_Bg_Light_Main = new System.Web.UI.HtmlControls.HtmlGenericControl("div");

                    Div_Card_Bg_Light_Main.Attributes.Add("class", "card bg-light");
                    Div_Card_Bg_Light_Main.ID = "Div_Card_Bg_Light_Main" + count;
                    Div_Card_Bg_Light_Main.Style.Add("padding", "2%");
                    cell1.Controls.Add(Div_Card_Bg_Light_Main);

                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Card_Bg_Light_Second = new System.Web.UI.HtmlControls.HtmlGenericControl("div");

                    Div_Card_Bg_Light_Second.Attributes.Add("class", "card bg-light");
                    Div_Card_Bg_Light_Second.ID = "Div_Card_Bg_Light_Second" + count;
                    Div_Card_Bg_Light_Main.Controls.Add(Div_Card_Bg_Light_Second);

                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Card_Bg_Dark = new System.Web.UI.HtmlControls.HtmlGenericControl("div");

                    Div_Card_Bg_Dark.Attributes.Add("class", "card bg-dark");
                    Div_Card_Bg_Dark.ID = "Div_Card_Bg_Dark" + count;
                    Div_Card_Bg_Light_Second.Controls.Add(Div_Card_Bg_Dark);

                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Collapse = new System.Web.UI.HtmlControls.HtmlGenericControl("div");

                    Div_Collapse.Attributes.Add("class", "collapse");
                    Div_Collapse.ID = "collapse" + count;
                    Div_Card_Bg_Light_Second.Controls.Add(Div_Collapse);

                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Card_Body = new System.Web.UI.HtmlControls.HtmlGenericControl("div");

                    Div_Card_Body.Attributes.Add("class", "card-body");
                    Div_Collapse.Controls.Add(Div_Card_Body);

                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Card_Header = new System.Web.UI.HtmlControls.HtmlGenericControl("div");

                    Div_Card_Header.Attributes.Add("class", "card-header");
                    Div_Card_Bg_Dark.Controls.Add(Div_Card_Header);

                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Row_Image_Labels_Button = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Row_Image_Labels_Button");

                    Div_Row_Image_Labels_Button.Attributes.Add("class", "row");
                    Div_Card_Header.Controls.Add(Div_Row_Image_Labels_Button);

                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_1_Image = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_1_Image");

                    Div_Col_Sm_1_Image.Attributes.Add("class", "col-sm-1");
                    Div_Col_Sm_1_Image.InnerHtml = "<img ID=\"Image" + count + "\" runat=\"server\" src=\"../Images/release.png\" Width=\"60\" Height=\"60\" style=\"margin:5px;\" />";
                    Div_Row_Image_Labels_Button.Controls.Add(Div_Col_Sm_1_Image);

                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_10_Client_Env_Product = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_10_Client_Env_Product");

                    Div_Col_Sm_10_Client_Env_Product.Attributes.Add("class", "col-sm-10");
                    Div_Row_Image_Labels_Button.Controls.Add(Div_Col_Sm_10_Client_Env_Product);

                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Row_Client_Env_Product = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Row_Client_Env_Product");

                    Div_Row_Client_Env_Product.Attributes.Add("class", "row");
                    Div_Col_Sm_10_Client_Env_Product.Controls.Add(Div_Row_Client_Env_Product);

                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_ClientName = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_ClientName");

                    Div_Col_ClientName.Attributes.Add("class", "col-sm-12 text-left");
                    Div_Col_ClientName.Style.Add("align", "left");
                    Div_Col_ClientName.InnerHtml = "<span style=\"color:white;\">" + item.ClientName.ToUpper() + "</span>";
                    Div_Row_Client_Env_Product.Controls.Add(Div_Col_ClientName);

                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Env = new System.Web.UI.HtmlControls.HtmlGenericControl("div");

                    Div_Col_Env.Attributes.Add("class", "col-sm-12 text-left");
                    Div_Col_Env.Style.Add("align", "left");
                    Div_Col_Env.InnerHtml = "<span style=\"color:white;\">" + item.EnvironmentAppServerEnvType.ToUpper() + "</span>";
                    Div_Row_Client_Env_Product.Controls.Add(Div_Col_Env);

                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Product = new System.Web.UI.HtmlControls.HtmlGenericControl("div");

                    Div_Col_Product.Attributes.Add("class", "col-sm-12 text-left");
                    Div_Col_Product.Style.Add("align", "left");
                    Div_Col_Product.InnerHtml = "<span style=\"color:white;\">" + item.ProductName + "</span>";
                    Div_Row_Client_Env_Product.Controls.Add(Div_Col_Product);

                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_1_Btn_Expand = new System.Web.UI.HtmlControls.HtmlGenericControl("div");

                    Div_Col_Sm_1_Btn_Expand.Attributes.Add("class", "col-sm-1");
                    Div_Col_Sm_1_Btn_Expand.Style.Add("margin", "auto");
                    Div_Col_Sm_1_Btn_Expand.Style.Add("float", "right");
                    Div_Col_Sm_1_Btn_Expand.InnerHtml = "<button id=\"btnExpand" + count + "\" type=\"button\" class=\"btn btn-primary\" data-toggle=\"collapse\" data-target=\"#MainContent_collapse" + count + "\" >Expand</button>";
                    Div_Row_Image_Labels_Button.Controls.Add(Div_Col_Sm_1_Btn_Expand);

                    #endregion Layout

                    #region ClientName

                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Row_ClientName = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Row_App_Details");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_ClientName_Label = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_ClientName_Label");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_ClientName = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_ClientName");

                    Div_Row_ClientName.Attributes.Add("class", "row");
                    Div_Row_ClientName.Style.Add("background-color", "lightgray");
                    Div_Card_Body.Controls.Add(Div_Row_ClientName);

                    Div_Col_Sm_6_ClientName_Label.Attributes.Add("class", "col-sm-6 text-right");
                    Div_Col_Sm_6_ClientName_Label.InnerHtml = "<i>CLIENT NAME</i>";
                    Div_Row_ClientName.Controls.Add(Div_Col_Sm_6_ClientName_Label);

                    Div_Col_Sm_6_ClientName.Attributes.Add("class", "col-sm-6 text-left");
                    Div_Col_Sm_6_ClientName.InnerHtml = "<b>" + item.ClientName.ToUpper() + "</b>";
                    Div_Row_ClientName.Controls.Add(Div_Col_Sm_6_ClientName);

                    #endregion
                    #region Environment_Type

                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Row_Environment = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_ClientName");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_EnvType_Label = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_ClientType_Label");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_EnvType = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_ClientType");

                    Div_Row_Environment.Attributes.Add("class", "row");
                    Div_Card_Body.Controls.Add(Div_Row_Environment);

                    Div_Col_Sm_6_EnvType_Label.Attributes.Add("class", "col-sm-6 text-right");
                    Div_Col_Sm_6_EnvType_Label.InnerHtml = "<i>ENVIRONMENT TYPE</i>";
                    Div_Row_Environment.Controls.Add(Div_Col_Sm_6_EnvType_Label);

                    Div_Col_Sm_6_EnvType.Attributes.Add("class", "col-sm-6 text-left");
                    Div_Col_Sm_6_EnvType.InnerHtml = "<b>" + item.EnvironmentAppServerEnvType.ToUpper() + "</b>";
                    Div_Row_Environment.Controls.Add(Div_Col_Sm_6_EnvType);

                    #endregion
                    #region Product_Name

                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Row_Product = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_ClientName");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_ProductName_Label = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_ClientType_Label");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_ProductName = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_ClientType");

                    Div_Row_Product.Attributes.Add("class", "row");
                    Div_Row_Product.Style.Add("background-color", "lightgray");
                    Div_Card_Body.Controls.Add(Div_Row_Product);

                    Div_Col_Sm_6_ProductName_Label.Attributes.Add("class", "col-sm-6 text-right");
                    Div_Col_Sm_6_ProductName_Label.InnerHtml = "<i>PRODUCT NAME</i>";
                    Div_Row_Product.Controls.Add(Div_Col_Sm_6_ProductName_Label);

                    Div_Col_Sm_6_ProductName.Attributes.Add("class", "col-sm-6 text-left");
                    Div_Col_Sm_6_ProductName.InnerHtml = "<b>" + item.ProductName.ToUpper() + "</b>";
                    Div_Row_Product.Controls.Add(Div_Col_Sm_6_ProductName);

                    #endregion
                    #region Application_Server_Name

                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Row_App_Server_Name = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_ClientName");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Server_Name_Label = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_ClientType_Label");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Server_Name = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_ClientType");

                    Div_Row_App_Server_Name.Attributes.Add("class", "row");
                    Div_Card_Body.Controls.Add(Div_Row_App_Server_Name);

                    Div_Col_Sm_6_App_Server_Name_Label.Attributes.Add("class", "col-sm-6 text-right");
                    Div_Col_Sm_6_App_Server_Name_Label.InnerHtml = "<i>APPLICATION SERVER NAME</i>";
                    Div_Row_App_Server_Name.Controls.Add(Div_Col_Sm_6_App_Server_Name_Label);

                    Div_Col_Sm_6_App_Server_Name.Attributes.Add("class", "col-sm-6 text-left");
                    Div_Col_Sm_6_App_Server_Name.InnerHtml = "<b>" + item.EnvironmentAppServerName.ToUpper() + "</b>";
                    Div_Row_App_Server_Name.Controls.Add(Div_Col_Sm_6_App_Server_Name);

                    #endregion
                    #region Application_Server_OS

                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Row_App_OS = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Row_App_OS");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_OS_Label = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_App_OS_Label");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_OS = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_App_OS");

                    Div_Row_App_OS.Attributes.Add("class", "row");
                    Div_Row_App_OS.Style.Add("background-color", "lightgray");
                    Div_Card_Body.Controls.Add(Div_Row_App_OS);

                    Div_Col_Sm_6_App_OS_Label.Attributes.Add("class", "col-sm-6 text-right");
                    Div_Col_Sm_6_App_OS_Label.InnerHtml = "<i>APPLICATION SERVER OPERATING SYSTEM</i>";
                    Div_Row_App_OS.Controls.Add(Div_Col_Sm_6_App_OS_Label);

                    Div_Col_Sm_6_App_OS.Attributes.Add("class", "col-sm-6 text-left");
                    Div_Col_Sm_6_App_OS.InnerHtml = "<b>" + item.EnvironmentAppServerOS.ToUpper() + "</b>";
                    Div_Row_App_OS.Controls.Add(Div_Col_Sm_6_App_OS);

                    #endregion
                    #region Application_Server_OS_Build


                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Row_App_OS_Build = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Row_App_OS_Build");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_OS_Build_Label = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_App_OS_Build_Label");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_OS_Build = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_App_OS_Build");

                    Div_Row_App_OS_Build.Attributes.Add("class", "row");
                    Div_Card_Body.Controls.Add(Div_Row_App_OS_Build);

                    Div_Col_Sm_6_App_OS_Build_Label.Attributes.Add("class", "col-sm-6 text-right");
                    Div_Col_Sm_6_App_OS_Build_Label.InnerHtml = "<i>Application SERVER OPERATING SYSTEM BUILD</i>";
                    Div_Row_App_OS_Build.Controls.Add(Div_Col_Sm_6_App_OS_Build_Label);

                    Div_Col_Sm_6_App_OS_Build.Attributes.Add("class", "col-sm-6 text-left");
                    Div_Col_Sm_6_App_OS_Build.InnerHtml = "<b>" + item.EnvironmentAppServerOSBuild + "</b>";
                    Div_Row_App_OS_Build.Controls.Add(Div_Col_Sm_6_App_OS_Build);

                    #endregion
                    #region Application_Server_WebBrowser


                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Row_App_WebBrower = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Row_App_OS_Build");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_WebBrowerLabel = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_App_OS_Build_Label");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_WebBrower = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_App_OS_Build");

                    Div_Row_App_WebBrower.Attributes.Add("class", "row");
                    Div_Row_App_WebBrower.Style.Add("background-color", "lightgray");
                    Div_Card_Body.Controls.Add(Div_Row_App_WebBrower);

                    Div_Col_Sm_6_App_WebBrowerLabel.Attributes.Add("class", "col-sm-6 text-right");
                    Div_Col_Sm_6_App_WebBrowerLabel.InnerHtml = "<i>APPLICATION SERVER WEB BROWSER</i>";
                    Div_Row_App_WebBrower.Controls.Add(Div_Col_Sm_6_App_WebBrowerLabel);

                    Div_Col_Sm_6_App_WebBrower.Attributes.Add("class", "col-sm-6 text-left");
                    Div_Col_Sm_6_App_WebBrower.InnerHtml = "<b>" + item.EnvironmentAppServerWebBrowser.ToUpper() + "</b>";
                    Div_Row_App_WebBrower.Controls.Add(Div_Col_Sm_6_App_WebBrower);

                    #endregion
                    #region Application_Server_WebBrowser_Version


                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Row_App_WebBrower_Version = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Row_App_OS_Build");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_WebBrower_Version_Label = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_App_OS_Build_Label");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_WebBrower_Version = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_App_OS_Build");

                    Div_Row_App_WebBrower_Version.Attributes.Add("class", "row");
                    Div_Card_Body.Controls.Add(Div_Row_App_WebBrower_Version);

                    Div_Col_Sm_6_App_WebBrower_Version_Label.Attributes.Add("class", "col-sm-6 text-right");
                    Div_Col_Sm_6_App_WebBrower_Version_Label.InnerHtml = "<i>APPLICATION SERVER WEB BROWSER VERSION</i>";
                    Div_Row_App_WebBrower_Version.Controls.Add(Div_Col_Sm_6_App_WebBrower_Version_Label);

                    Div_Col_Sm_6_App_WebBrower_Version.Attributes.Add("class", "col-sm-6 text-left");
                    Div_Col_Sm_6_App_WebBrower_Version.InnerHtml = "<b>" + item.EnvironmentAppServerWebBrowserVersion.ToUpper() + "</b>";
                    Div_Row_App_WebBrower_Version.Controls.Add(Div_Col_Sm_6_App_WebBrower_Version);

                    #endregion
                    #region Application_Server_Register


                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Row_App_Server_Register = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Row_App_OS_Build");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Server_Register_Label = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_App_OS_Build_Label");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Server_Register = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_App_OS_Build");

                    Div_Row_App_Server_Register.Attributes.Add("class", "row");
                    Div_Row_App_Server_Register.Style.Add("background-color", "lightgray");
                    Div_Card_Body.Controls.Add(Div_Row_App_Server_Register);

                    Div_Col_Sm_6_App_Server_Register_Label.Attributes.Add("class", "col-sm-6 text-right");
                    Div_Col_Sm_6_App_Server_Register_Label.InnerHtml = "<i>APPLICATION SERVER IS 32-BIT</i>";
                    Div_Row_App_Server_Register.Controls.Add(Div_Col_Sm_6_App_Server_Register_Label);

                    Div_Col_Sm_6_App_Server_Register.Attributes.Add("class", "col-sm-6 text-left");
                    Div_Col_Sm_6_App_Server_Register.InnerHtml = "<b>" + item.EnvironmentAppServerIsX86Version.ToUpper() + "</b>";
                    Div_Row_App_Server_Register.Controls.Add(Div_Col_Sm_6_App_Server_Register);

                    #endregion
                    #region Application_Server_Virtualization


                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Row_App_Server_Virtualization = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Row_App_OS_Build");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Server_Virtualization_Label = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_App_OS_Build_Label");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Server_Virtualization = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_App_OS_Build");

                    Div_Row_App_Server_Virtualization.Attributes.Add("class", "row");
                    Div_Card_Body.Controls.Add(Div_Row_App_Server_Virtualization);

                    Div_Col_Sm_6_App_Server_Virtualization_Label.Attributes.Add("class", "col-sm-6 text-right");
                    Div_Col_Sm_6_App_Server_Virtualization_Label.InnerHtml = "<i>APPLICATION SERVER IS VIRTUAL</i>";
                    Div_Row_App_Server_Virtualization.Controls.Add(Div_Col_Sm_6_App_Server_Virtualization_Label);

                    Div_Col_Sm_6_App_Server_Virtualization.Attributes.Add("class", "col-sm-6 text-left");
                    Div_Col_Sm_6_App_Server_Virtualization.InnerHtml = "<b>" + item.EnvironmentAppServerIsVirtual.ToUpper() + "</b>";
                    Div_Row_App_Server_Virtualization.Controls.Add(Div_Col_Sm_6_App_Server_Virtualization);

                    #endregion
                    #region Application_Server_IP


                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Row_App_Server_IP = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Row_App_OS_Build");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Server_IP_Label = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_App_OS_Build_Label");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Server_IP = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_App_OS_Build");

                    Div_Row_App_Server_IP.Attributes.Add("class", "row");
                    Div_Row_App_Server_IP.Style.Add("background-color", "lightgray");
                    Div_Card_Body.Controls.Add(Div_Row_App_Server_IP);

                    Div_Col_Sm_6_App_Server_IP_Label.Attributes.Add("class", "col-sm-6 text-right");
                    Div_Col_Sm_6_App_Server_IP_Label.InnerHtml = "<i>APPLICATION SERVER IP</i>";
                    Div_Row_App_Server_IP.Controls.Add(Div_Col_Sm_6_App_Server_IP_Label);

                    Div_Col_Sm_6_App_Server_IP.Attributes.Add("class", "col-sm-6 text-left");
                    Div_Col_Sm_6_App_Server_IP.InnerHtml = "<b>" + item.EnvironmentAppServerIP + "</b>";
                    Div_Row_App_Server_IP.Controls.Add(Div_Col_Sm_6_App_Server_IP);

                    #endregion
                    #region Application_Server_Port


                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Row_App_Server_Port = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Row_App_OS_Build");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Server_Port_Label = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_App_OS_Build_Label");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Server_Port = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_App_OS_Build");

                    Div_Row_App_Server_Port.Attributes.Add("class", "row");
                    Div_Card_Body.Controls.Add(Div_Row_App_Server_Port);

                    Div_Col_Sm_6_App_Server_Port_Label.Attributes.Add("class", "col-sm-6 text-right");
                    Div_Col_Sm_6_App_Server_Port_Label.InnerHtml = "<i>APPLICATION RUNING ON PORT</i>";
                    Div_Row_App_Server_Port.Controls.Add(Div_Col_Sm_6_App_Server_Port_Label);

                    Div_Col_Sm_6_App_Server_Port.Attributes.Add("class", "col-sm-6 text-left");
                    Div_Col_Sm_6_App_Server_Port.InnerHtml = "<b>" + item.EnvironmentAppServerPort + "</b>";
                    Div_Row_App_Server_Port.Controls.Add(Div_Col_Sm_6_App_Server_Port);

                    #endregion
                    #region Application_Server_Memory


                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Row_App_Server_Memory = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Row_App_OS_Build");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Server_Memory_Label = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_App_OS_Build_Label");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Server_Memory = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_App_OS_Build");

                    Div_Row_App_Server_Memory.Attributes.Add("class", "row");
                    Div_Row_App_Server_Memory.Style.Add("background-color", "lightgray");
                    Div_Card_Body.Controls.Add(Div_Row_App_Server_Memory);

                    Div_Col_Sm_6_App_Server_Memory_Label.Attributes.Add("class", "col-sm-6 text-right");
                    Div_Col_Sm_6_App_Server_Memory_Label.InnerHtml = "<i>APPLICATION SERVER MEMORY</i>";
                    Div_Row_App_Server_Memory.Controls.Add(Div_Col_Sm_6_App_Server_Memory_Label);

                    Div_Col_Sm_6_App_Server_Memory.Attributes.Add("class", "col-sm-6 text-left");
                    Div_Col_Sm_6_App_Server_Memory.InnerHtml = "<b>" + item.EnvironmentAppServerMemory + "</b>";
                    Div_Row_App_Server_Memory.Controls.Add(Div_Col_Sm_6_App_Server_Memory);

                    #endregion
                    #region Application_Server_Processor


                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Row_App_Server_Processor = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Row_App_OS_Build");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Server_Processor_Label = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_App_OS_Build_Label");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Server_Processor = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_App_OS_Build");

                    Div_Row_App_Server_Processor.Attributes.Add("class", "row");
                    Div_Card_Body.Controls.Add(Div_Row_App_Server_Processor);

                    Div_Col_Sm_6_App_Server_Processor_Label.Attributes.Add("class", "col-sm-6 text-right");
                    Div_Col_Sm_6_App_Server_Processor_Label.InnerHtml = "<i>APPLICATION SERVER PROCESSOR</i>";
                    Div_Row_App_Server_Processor.Controls.Add(Div_Col_Sm_6_App_Server_Processor_Label);

                    Div_Col_Sm_6_App_Server_Processor.Attributes.Add("class", "col-sm-6 text-left");
                    Div_Col_Sm_6_App_Server_Processor.InnerHtml = "<b>" + item.EnvironmentAppServerProcessor.ToUpper() + "</b>";
                    Div_Row_App_Server_Processor.Controls.Add(Div_Col_Sm_6_App_Server_Processor);

                    #endregion
                    #region Application_Server_Link


                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Row_App_Link = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Row_App_OS_Build");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Link_Label = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_App_OS_Build_Label");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Link = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_App_OS_Build");

                    Div_Row_App_Link.Attributes.Add("class", "row");
                    Div_Row_App_Link.Style.Add("background-color", "lightgray");
                    Div_Card_Body.Controls.Add(Div_Row_App_Link);

                    Div_Col_Sm_6_App_Link_Label.Attributes.Add("class", "col-sm-6 text-right");
                    Div_Col_Sm_6_App_Link_Label.InnerHtml = "<i>APPLICATION LINK</i>";
                    Div_Row_App_Link.Controls.Add(Div_Col_Sm_6_App_Link_Label);

                    Div_Col_Sm_6_App_Link.Attributes.Add("class", "col-sm-6 text-left");
                    Div_Col_Sm_6_App_Link.InnerHtml = "<b>" + item.EnvironmentAppHyperLink + "</b>";
                    Div_Row_App_Link.Controls.Add(Div_Col_Sm_6_App_Link);

                    #endregion
                    #region Application_Working_Directory


                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Row_App_Working_Directory = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Row_App_OS_Build");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Working_Directory_Label = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_App_OS_Build_Label");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Working_Directory = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_App_OS_Build");

                    Div_Row_App_Working_Directory.Attributes.Add("class", "row");
                    Div_Card_Body.Controls.Add(Div_Row_App_Working_Directory);

                    Div_Col_Sm_6_App_Working_Directory_Label.Attributes.Add("class", "col-sm-6 text-right");
                    Div_Col_Sm_6_App_Working_Directory_Label.InnerHtml = "<i>APPLICATION WORKING DIRECTORY</i>";
                    Div_Row_App_Working_Directory.Controls.Add(Div_Col_Sm_6_App_Working_Directory_Label);

                    Div_Col_Sm_6_App_Working_Directory.Attributes.Add("class", "col-sm-6 text-left");
                    Div_Col_Sm_6_App_Working_Directory.InnerHtml = "<b>" + item.EnvironmentAppServerWorkingDirectoryLocation + "</b>";
                    Div_Row_App_Working_Directory.Controls.Add(Div_Col_Sm_6_App_Working_Directory);

                    #endregion
                    #region Application_Server_Dependency


                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Row_App_Server_Dependency = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Row_App_OS_Build");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Server_Dependency_Label = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_App_OS_Build_Label");
                    System.Web.UI.HtmlControls.HtmlGenericControl Div_Col_Sm_6_App_Server_Dependency = new System.Web.UI.HtmlControls.HtmlGenericControl("Div_Col_Sm_6_App_OS_Build");

                    Div_Row_App_Server_Dependency.Attributes.Add("class", "row");
                    Div_Row_App_Server_Dependency.Style.Add("background-color", "lightgray");
                    Div_Card_Body.Controls.Add(Div_Row_App_Server_Dependency);

                    Div_Col_Sm_6_App_Server_Dependency_Label.Attributes.Add("class", "col-sm-6 text-right");
                    Div_Col_Sm_6_App_Server_Dependency_Label.InnerHtml = "<i>APPLICATION SERVER DEPENDENCY</i>";
                    Div_Row_App_Server_Dependency.Controls.Add(Div_Col_Sm_6_App_Server_Dependency_Label);

                    Div_Col_Sm_6_App_Server_Dependency.Attributes.Add("class", "col-sm-6 text-left");
                    Div_Col_Sm_6_App_Server_Dependency.InnerHtml = "<b>" + item.EnvironmentAppServerDependency.ToUpper() + "</b>";
                    Div_Row_App_Server_Dependency.Controls.Add(Div_Col_Sm_6_App_Server_Dependency);

                    #endregion

                    // END

                    TableRow row0 = new TableRow();

                    TableCell cellClient1 = new TableCell();
                    cellClient1.Height = 40;
                    cellClient1.ForeColor = Color.White;
                    cellClient1.BackColor = ColorTranslator.FromHtml("#3A4F63");
                    cellClient1.Style.Add("Font-Size", "22px");
                    cellClient1.Text = "Environment " + ++count;
                    cellClient1.HorizontalAlign = HorizontalAlign.Center;
                    cellClient1.ColumnSpan = 10;
                    row0.Cells.Add(cellClient1);

                    log.DetailLog("EnvironmentInfo.aspx.cs", "Button1_Click", STATE.COMPLETED, "Method: Page_Load Inn Class: EnvironmentInfo.aspx.cs Has Completed Its Execution Successfully.");

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
                log.ErrorLog("EnvironmentInfo.aspx.cs", "Button1_Click", ExceptionType.SQLException, ex);
                log.DetailLog("EnvironmentInfo.aspx.cs", "Button1_Click", STATE.INTERRUPTED, ex.Message);
                Response.Redirect("ErrorPages\\Error500.aspx?Param=EnvironmentInfo.aspx&Exception=" + ex.Message, false);
            }
            finally
            {
                
            }
        }
    }
}