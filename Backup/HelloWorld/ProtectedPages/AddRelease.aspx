<%@ Page Title="Portal - Add Release" Language="C#" MasterPageFile="~/SiteLogout.Master" AutoEventWireup="true" CodeBehind="AddRelease.aspx.cs" ViewStateMode="Enabled" Inherits="HelloWorld.ProtectedPages.AddPatch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Styles/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/modernizr-2.8.3.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server" class="container">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="Panel1" runat="server" GroupingText=" Add Release " Font-Size="Large" ForeColor="Navy">
                    <div class="container-fluid">
                      <div class="row" id="rowPatchTitle" style="margin-bottom:5px;">
                        <div class="col-sm-4">
                            <asp:Label ID="lblPatchTitle" runat="server" Text="Release Title" Font-Italic="true" ForeColor="Navy" Font-Size="Medium"></asp:Label>
                        </div>
                        <div class="col-sm-5">
                            <asp:TextBox ID="txtPatchTitle" runat="server" Width="250px" Height="27px" ForeColor="Black" Font-Size="Medium" style="border: 1px solid darkgray;background-color:ButtonFace;padding:2px;" Font-Names="Arial"></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <asp:RequiredFieldValidator ID="ReqPatchTitle" runat="server" ControlToValidate="txtPatchTitle" ErrorMessage="Enter Patch Title." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                        </div>
                      </div>
                      <div class="row" id="rowPatchDesc" style="margin-bottom:5px;">
                        <div class="col-sm-4">
                            <asp:Label ID="lblPatchDesc" runat="server" Text="Release Description" Font-Italic="true" ForeColor="Navy" Font-Size="Medium"></asp:Label>
                        </div>
                        <div class="col-sm-5">
                            <asp:TextBox ID="txtPatchDesc" class="sd" CausesValidation="true" runat="server" Width="250px" Height="50px" style="border: 1px solid darkgray;background-color:ButtonFace;padding:2px" TextMode="MultiLine" Font-Names="Arial" Font-Size="Medium" ForeColor="Black"></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <asp:RequiredFieldValidator ID="ReqPatchDesc" runat="server" ErrorMessage="Please Enter Patch Description" Text="(Required)" ControlToValidate="txtPatchDesc" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                        </div>
                      </div>
                      <div class="row" id="rowPatchNumber" style="margin-bottom:5px;">
                        <div class="col-sm-4">
                            <asp:Label ID="lblPatchNumber" runat="server" Text="Release Number" Font-Italic="true" ForeColor="Navy" Font-Size="Medium"></asp:Label>
                        </div>
                        <div class="col-sm-5">
                            <asp:TextBox ID="txtPatchNumber" CausesValidation="true" runat="server" Width="250px" Height="27px" style="border: 1px solid darkgray;background-color:ButtonFace;padding:2px" TextMode="MultiLine" Font-Names="Arial" Font-Size="Medium" ForeColor="Black"></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <asp:RequiredFieldValidator ID="ReqPatchNumber" runat="server" ControlToValidate="txtPatchNumber" ErrorMessage="Enter Patch Number." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                        </div>
                      </div>
                      <div class="row" id="rowPatchDeployedBy" style="margin-bottom:5px;">
                        <div class="col-sm-4">
                            <asp:Label ID="lblPatchDeployedBy" runat="server" Text="Deployed By" Font-Italic="true" ForeColor="Navy" Font-Size="Medium"></asp:Label>
                        </div>
                        <div class="col-sm-5">
                            <asp:TextBox ID="txtPatchDeployedBy" runat="server" Width="250px" Height="27px" style="border: 1px solid darkgray;background-color:ButtonFace;padding:2px" TextMode="MultiLine" Font-Names="Arial" Font-Size="Medium" ForeColor="Black"></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <asp:RequiredFieldValidator ID="ReqPatchDeployedBy" runat="server" ControlToValidate="txtPatchDeployedBy" ErrorMessage="Enter Patch Deployed By Field." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                        </div>
                      </div>
                      <div class="row" id="rowPatchCreatedDate" style="margin-bottom:5px;">
                        <div class="col-sm-4">
                            <asp:Label ID="lblPatchCreatedDate" runat="server" Text="Created Date" Font-Italic="true" ForeColor="Navy" Font-Size="Medium"></asp:Label>
                        </div>
                        <div class="col-sm-5">
                            <asp:TextBox ID="txtPatchCreatedDate" type="date" runat="server" Width="250px" Height="27px" style="border: 1px solid darkgray;background-color:ButtonFace;padding:2px" Font-Names="Arial" Font-Size="Medium" ForeColor="Black"></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <asp:RequiredFieldValidator ID="ReqPatchCreatedDate" runat="server" ControlToValidate="txtPatchDeployedBy" ErrorMessage="Enter Patch Created Date." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                        </div>
                      </div>
                      <div class="row" id="rowPatchDeployedDate" style="margin-bottom:5px;">
                        <div class="col-sm-4">
                            <asp:Label ID="lblPatchDeployedDate" runat="server" Text="Created Date" Font-Italic="true" ForeColor="Navy" Font-Size="Medium"></asp:Label>
                        </div>
                        <div class="col-sm-5">
                            <asp:TextBox ID="txtPatchDeployedDate" type="date" runat="server" Width="250px" Height="27px" style="border: 1px solid darkgray;background-color:ButtonFace;padding:2px" Font-Names="Arial" Font-Size="Medium" ForeColor="Black"></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <asp:RequiredFieldValidator ID="ReqPatchDeployedDate" runat="server" ControlToValidate="txtPatchDeployedDate" ErrorMessage="Enter Patch Deployed Date." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                        </div>
                      </div>
                      <div class="row" id="rowPatchIsQAPassed" style="margin-bottom:5px;">
                        <div class="col-sm-4">
                            <asp:Label ID="lblPatchIsQAPassed" runat="server" Text="Is Patch QA Passed" Font-Italic="true" ForeColor="Navy" Font-Size="Medium"></asp:Label>
                        </div>
                        <div class="col-sm-5">
                            <asp:CheckBox ID="CheckBox1" runat="server" TextAlign="Right" Text="Passed" ForeColor="black" Font-Size="Small" />
                            <asp:CheckBox ID="CheckBox2" runat="server" TextAlign="Right" Text="Failed" ForeColor="black" Font-Size="Small" />
                            <asp:CheckBox ID="CheckBox3" runat="server" TextAlign="Right" Text="Not Tested" ForeColor="black" Font-Size="Small" />
                        </div>
                        <div class="col-sm-3">
                            <%--<asp:RequiredFieldValidator ID="ReqPatchIsQAPassed" runat="server" ControlToValidate="txtPatchIsQAPassed" ErrorMessage="Please Check Patch Is QA Passed" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                        </div>
                      </div>
                      <div class="row" id="rowPatchDependency" style="margin-bottom:5px;">
                        <div class="col-sm-4">
                            <asp:Label ID="lblPatchDependency" runat="server" Text="Release Dependency" Font-Italic="true" ForeColor="Navy" Font-Size="Medium"></asp:Label>
                        </div>
                        <div class="col-sm-5">
                            <asp:TextBox ID="txtPatchDependency" class="sd" runat="server" Width="250px" Height="27px" style="border: 1px solid darkgray;background-color:ButtonFace;padding:2px;" Font-Names="Arial" Font-Size="Medium" ForeColor="Black"></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <asp:RequiredFieldValidator ID="ReqPatchDependency" runat="server" ControlToValidate="txtPatchDependency" ErrorMessage="Please enter Patch Dependency" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                        </div>
                      </div>
                      <div class="row" id="rowPatchClientName" style="margin-bottom:5px;">
                        <div class="col-sm-4">
                            <asp:Label ID="lblPatchClientName" runat="server" Text="Client Name" Font-Italic="true"  ForeColor="Navy" Font-Size="Medium"></asp:Label>
                        </div>
                        <div class="col-sm-5">
                            <asp:DropDownList ID="dropPatchClientName" runat="server" BackColor="ButtonFace" Width="250px" Height="27px" Font-Italic="true" Font-Size="Medium" Font-Names="Arial" ForeColor="black" DataSourceID="SqlDataSource2" DataTextField="ClientName" style="text-align:center;" DataValueField="ClientID" AutoPostBack="true" ViewStateMode="Enabled" AppendDataBoundItems="True" onselectedindexchanged="dropPatchClientName_SelectedIndexChanged">
                                <asp:ListItem>Select..</asp:ListItem>
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" SelectCommand="SELECT [ClientID],[ClientName] FROM [ClientDetail]">
                            </asp:SqlDataSource>
                        </div>
                        <div class="col-sm-3">
                            <asp:RequiredFieldValidator ID="ReqPatchClientName" runat="server" InitialValue="Select.." ControlToValidate="dropPatchClientName"  ErrorMessage="Please Select Client Name" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                        </div>
                      </div>
                      <div class="row" id="rowProductName" style="margin-bottom:5px;">
                        <div class="col-sm-4">
                            <asp:Label ID="lblProductName" runat="server" Text="Product Name" Font-Italic="true" ForeColor="Navy" Font-Size="Medium"></asp:Label>
                        </div>
                        <div class="col-sm-5">
                            <asp:DropDownList ID="dropProductName" class="sd" runat="server" BackColor="ButtonFace"
                                Width="250px" Height="27px" Font-Italic="true" Font-Size="Medium" 
                                    Font-Names="Arial" ForeColor="black"
                                DataSourceID="SqlDataSource1" DataTextField="ProductName" style="text-align:center;"
                                DataValueField="ProductID" AutoPostBack="true" ViewStateMode="Enabled" 
                                AppendDataBoundItems="True" 
                                    onselectedindexchanged="dropProductName_SelectedIndexChanged">
                                <asp:ListItem>SELECT..</asp:ListItem>
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
                                SelectCommand="SELECT [ProductID],[ProductName] FROM [Products] P INNER JOIN ENVIRONMENT E ON P.ProductID = E.ENV_AppServerEnvironmentType"></asp:SqlDataSource>
                        </div>
                        <div class="col-sm-3">
                            <asp:RequiredFieldValidator ID="ReqProductName" runat="server" InitialValue="SELECT.." ControlToValidate="dropProductName" Display="Dynamic" EnableClientScript="true" Text="(Required)" ForeColor="Red" Font-Bold="true" ErrorMessage="Please Select Product Name"></asp:RequiredFieldValidator>
                        </div>
                      </div>
                      <div class="row" id="rowEnvironmentType" style="margin-bottom:5px;">
                        <div class="col-sm-4">
                            <asp:Label ID="lblEnvironmentType" runat="server" Text="Environment Type" Font-Italic="true" ForeColor="Navy" Font-Size="Medium"></asp:Label>
                        </div>
                        <div class="col-sm-5">
                            <asp:DropDownList ID="dropEnvironmentType" runat="server" BackColor="ButtonFace"
                                Width="250px" Font-Italic="true" Font-Size="Medium" Font-Names="Arial" ForeColor="black"
                                DataSourceID="SqlDataSource3" DataTextField="ENV_TITLE" style="border: 1px solid #1cbaa5;padding: 5px 10px;height: 30px;text-align=center" ondatabinding="DropDownList1_DataBinding"
                                DataValueField="ENV_ID" AutoPostBack="false" ViewStateMode="Enabled" ondatabound="DropDownList1_DataBound"
                                AppendDataBoundItems="True">
                                <asp:ListItem>SELECT..</asp:ListItem>
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ApplicationServices %>"
                                SelectCommand="SELECT E.ENV_ID,CONCAT('Client: ',C.ClientName,', Product: ',P.ProductName,', Environment: ',ET.EnvTitle, '') As Env_Title from (((Environment E Inner Join ClientDetail C on E.ENV_Client_ID = C.ClientID) INNER JOIN Products P On E.ENV_Product_ID = P.ProductID ) INNER JOIN EnvironmentType ET ON ET.EnvID = E.ENV_AppServerEnvironmentType)"></asp:SqlDataSource>
                        </div>
                        <div class="col-sm-3">
                            <asp:RequiredFieldValidator ID="ReqEnvironmentType" runat="server" ControlToValidate="dropEnvironmentType" ErrorMessage="Please Select Environment Type" InitialValue="SELECT.." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                        </div>
                      </div>
                      <div class="row" id="rowSubmit" style="margin-bottom:5px;">
                        <div class="col-sm-4">
                            <%--<asp:Label ID="Label2" runat="server" Text="Contact Number" Font-Italic="true" ForeColor="Navy" Font-Size="Medium"></asp:Label>--%>
                        </div>
                        <div class="col-sm-5" style="float:right;">
                            <asp:Button ID="Button1" CssClass="btn-danger" runat="server" Text="SAVE" Width="100px" Height="35px" onclick="btnSave_Click" />
                            <asp:Button ID="Button2" CssClass="btn-danger" runat="server" Text="CLEAR" Width="100px" Height="35px" onclick="btnClear_Click" />
                        </div>
                        <div class="col-sm-3">
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="*" ControlToValidate="txtPOCPhone" Display="Dynamic" EnableClientScript="true" Text="Please Enter Client POC Phone Number"></asp:RequiredFieldValidator>--%>
                        </div>
                      </div>
                    </div>
                    <br />
                </asp:Panel>
            </ContentTemplate>
            <Triggers>
                <%--<asp:AsyncPostBackTrigger ControlID="DetailsView1" EventName="btnCancel_Click" EventName="RowCommand" />--%>
            </Triggers>
    </asp:UpdatePanel>  
</asp:Content>
