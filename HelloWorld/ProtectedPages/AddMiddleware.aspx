<%@ Page Title="Portal - Add API" Language="C#" MasterPageFile="~/SiteLogout.Master" AutoEventWireup="true" CodeBehind="AddMiddleware.aspx.cs" Inherits="HelloWorld.ProtectedPages.AddMiddleware" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <asp:Panel ID="Panel1" runat="server">
       <%-- <asp:Label ID="Label1" runat="server" Text="Add Environment Type"></asp:Label>--%>

       <asp:Table ID="Table1" runat="server" Width="100%" BackColor="Menu" BorderStyle="Solid" BorderColor="DarkGray" BorderWidth="2px" HorizontalAlign="Center" CellSpacing="5" CellPadding="5" style="margin:5px;padding:5px;">
            <asp:TableHeaderRow Height="40px">
                <asp:TableHeaderCell ColumnSpan="3" HorizontalAlign="Left" style="margin:5px;padding:5px;">
                    <asp:Label ID="Label1" runat="server" Text="Add Database.." Font-Italic="true" ForeColor="Black" Font-Names="Arial" Font-Size="Large"></asp:Label>
                    <asp:ValidationSummary ID="ValidationSummary1" EnableClientScript="true" DisplayMode="BulletList" HeaderText="Please Enter Following Fields: " ShowMessageBox="true" runat="server" ForeColor="Red" ShowSummary="False" />
                    <br />
                    <br />
                    <asp:Label ID="lblSubmission" runat="server" Text="Database is successfully added." Font-Italic="true" ForeColor="Navy" Font-Names="Arial" Font-Size="Medium" Visible="false"></asp:Label>
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow ID="rowEnvironmetID" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="Label2" runat="server" Text="Select Environment" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="DropEnvironment" runat="server" 
        DataSourceID="SqlDataSourceDatabase" DataTextField="ENV_DESC" Width="500"
        DataValueField="ENV_ID" AppendDataBoundItems="True">
        <asp:ListItem Value="0">Select Environment..</asp:ListItem>
                    </asp:DropDownList>

    <asp:SqlDataSource ID="SqlDataSourceDatabase" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" SelectCommand="select ENV_ID,CONCAT('CLIENT NAME: ' ,UPPER((select ClientName from clientdetail 
						  where clientid=ENV_Client_ID)) , ' | ', 'PRODUCT NAME: ', UPPER((select ProductName from PRODUCTS 
						  where ProductID=ENV_Product_ID)) , ' | ' , 'ENVIRONMENT TYPE: ', UPPER((select EnvTitle from EnvironmentType 
						  where EnvID=ENV_AppServerEnvironmentType))) AS ENV_DESC
from environment"></asp:SqlDataSource>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:RequiredFieldValidator ID="ReqClientName" runat="server" ControlToValidate="DropEnvironment" ErrorMessage="Select Environment" InitialValue="0" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="rowAPIName" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAPIName" runat="server" Text="API Name" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtAPIName" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter API Name Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqDBServerName" runat="server" ControlToValidate="txtDBServerName" ErrorMessage="Enter Database Server Name." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="rowAPIType" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAPIType" runat="server" Text="API TYPE" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtAPIType" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter API Type Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqDBServerName" runat="server" ControlToValidate="txtDBServerName" ErrorMessage="Enter Database Server Name." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="rowAPIHyperLink" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAPIHyperLink" runat="server" Text="API Hyper Link" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtAPIHyperLink" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter API Hyper Link Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqDBServerName" runat="server" ControlToValidate="txtDBServerName" ErrorMessage="Enter Database Server Name." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="rowAPIAccessKey" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAPIAccessKey" runat="server" Text="API Access Key" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtAPIAccessKey" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter API Access Key Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqDBServerName" runat="server" ControlToValidate="txtDBServerName" ErrorMessage="Enter Database Server Name." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="rowAPIWebServer" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAPIWebServer" runat="server" Text="API Web Server" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtAPIWebServer" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter API Web Server Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqDBServerName" runat="server" ControlToValidate="txtDBServerName" ErrorMessage="Enter Database Server Name." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="rowAPIWebServerVersion" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAPIWebServerVersion" runat="server" Text="API Web Server Version" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtAPIWebServerVersion" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter API Web Server Version Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqDBServerName" runat="server" ControlToValidate="txtDBServerName" ErrorMessage="Enter Database Server Name." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="rowAPIDirectoryLocation" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAPIDirectoryLocation" runat="server" Text="API Directory Location" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtAPIDirectoryLocation" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter API Directory Location Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqDBServerDirectoryLocation" runat="server" ControlToValidate="txtDBServerDirectoryLocation" ErrorMessage="Select DB Server Directory Location." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="rowAPIDocumnetationLocation" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAPIDocumnetationLocation" runat="server" Text="API Documentation Location" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtAPIDocumnetationLocation" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter API Documentation Location Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqDBServerDirectoryLocation" runat="server" ControlToValidate="txtDBServerDirectoryLocation" ErrorMessage="Select DB Server Directory Location." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow ID="rowAPIServerName" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAPIServerName" runat="server" Text="API Server Name" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtAPIServerName" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter API Server Name Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqDBServerName" runat="server" ControlToValidate="txtDBServerName" ErrorMessage="Enter Database Server Name." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="rowAPIServerLogin" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAPIServerLogin" runat="server" Text="API Server Login" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtAPIServerLogin" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter API Server Login Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqDBServerName" runat="server" ControlToValidate="txtDBServerName" ErrorMessage="Enter Database Server Name." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="rowAPIServerPassword" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAPIServerPassword" runat="server" Text="API Server Password" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtAPIServerPassword" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter API Server Password Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqDBServerName" runat="server" ControlToValidate="txtDBServerName" ErrorMessage="Enter Database Server Name." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="rowlblAPIServerOS" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAPIServerOS" runat="server" Text="API Server OS" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtAPIServerOS" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter DB Server OS Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqlblDBServerOS" runat="server" ControlToValidate="txtDBServerOS" ErrorMessage="Enter Database Server OS." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowlblAPIServerOSBuild" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAPIServerOSBuild" runat="server" Text="API Server OS Build" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                        <asp:DropDownList ID="dropAPIServerOSBuild" runat="server" BackColor="ButtonFace" Width="250px" Height="27px" Font-Italic="true" Font-Size="Medium" Font-Names="Arial" ForeColor="black" style="text-align:center" ViewStateMode="Enabled" AppendDataBoundItems="True">
                            <asp:ListItem>Select..</asp:ListItem>
                            <asp:ListItem>	511	</asp:ListItem>
                            <asp:ListItem>	528	</asp:ListItem>
                            <asp:ListItem>	807	</asp:ListItem>
                            <asp:ListItem>	950	</asp:ListItem>
                            <asp:ListItem>	1057	</asp:ListItem>
                            <asp:ListItem>	1106	</asp:ListItem>
                            <asp:ListItem>	1381	</asp:ListItem>
                            <asp:ListItem>	1998	</asp:ListItem>
                            <asp:ListItem>	2195	</asp:ListItem>
                            <asp:ListItem>	2222	</asp:ListItem>
                            <asp:ListItem>	2600	</asp:ListItem>
                            <asp:ListItem>	2600	</asp:ListItem>
                            <asp:ListItem>	3000	</asp:ListItem>
                            <asp:ListItem>	3790	</asp:ListItem>
                            <asp:ListItem>	3790	</asp:ListItem>
                            <asp:ListItem>	3790	</asp:ListItem>
                            <asp:ListItem>	4500	</asp:ListItem>
                            <asp:ListItem>	6000	</asp:ListItem>
                            <asp:ListItem>	6001	</asp:ListItem>
                            <asp:ListItem>	6001	</asp:ListItem>
                            <asp:ListItem>	6002	</asp:ListItem>
                            <asp:ListItem>	6002	</asp:ListItem>
                            <asp:ListItem>	6003	</asp:ListItem>
                            <asp:ListItem>	7600	</asp:ListItem>
                            <asp:ListItem>	7600	</asp:ListItem>
                            <asp:ListItem>	7601	</asp:ListItem>
                            <asp:ListItem>	7601	</asp:ListItem>
                            <asp:ListItem>	8400	</asp:ListItem>
                            <asp:ListItem>	9200	</asp:ListItem>
                            <asp:ListItem>	9200	</asp:ListItem>
                            <asp:ListItem>	9600	</asp:ListItem>
                            <asp:ListItem>	9600	</asp:ListItem>
                            <asp:ListItem>	10240	</asp:ListItem>
                            <asp:ListItem>	10586	</asp:ListItem>
                            <asp:ListItem>	14393	</asp:ListItem>
                            <asp:ListItem>	14393	</asp:ListItem>
                            <asp:ListItem>	15063	</asp:ListItem>
                            <asp:ListItem>	16299	</asp:ListItem>
                            <asp:ListItem>	16299	</asp:ListItem>
                            <asp:ListItem>	17134	</asp:ListItem>
                            <asp:ListItem>	17763	</asp:ListItem>
                            <asp:ListItem>	17763	</asp:ListItem>
                            <asp:ListItem>	18362	</asp:ListItem>
                            <asp:ListItem>	18363	</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqDBServerOSBuild" runat="server" InitialValue="Select.." ControlToValidate="dropDBServerOSBuild" ErrorMessage="Select Database Server OS Build." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowAPIServerIsx86" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAPIServerIsx86" runat="server" Text="API Server Version" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RadioButtonList ID="radAPIServerIsx86" runat="server" ForeColor="black" Font-Size="Small">
                        <asp:ListItem Value="1">x86 Bit</asp:ListItem>
                        <asp:ListItem Value="0" Selected="True">x64 Bit</asp:ListItem>
                    </asp:RadioButtonList>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqPatchCreatedDate" runat="server" ControlToValidate="rowAppServerIsX86" ErrorMessage="Enter Patch Created Date." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowAPIServerIsVirtual" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAPIServerIsVirtual" runat="server" Text="API Server Environment" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RadioButtonList ID="radAPIServerIsVirtual" runat="server" AppendDataBoundItems="true" ForeColor="black" Font-Size="Small">
                        <asp:ListItem Value="0" Selected="True">Physical Machine</asp:ListItem>
                        <asp:ListItem Value="1">Virtual Machine</asp:ListItem>
                    </asp:RadioButtonList>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqPatchCreatedDate" runat="server" ControlToValidate="rowAppServerIsX86" ErrorMessage="Enter Patch Created Date." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowAPIServerProcessor" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAPIServerProcessor" runat="server" Text="API Server Processor" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtAPIServerProcessor" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter API Processor Details Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqDBServerProcessor" runat="server" ControlToValidate="txtDBServerProcessor" ErrorMessage="Enter Database Server Processor." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowAPIServerMemory" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAPIServerMemory" runat="server" Text="Database Server Memory" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="dropAPIServerMemory" runat="server" BackColor="ButtonFace" Width="250px" Height="27px" Font-Italic="true" Font-Size="Medium" Font-Names="Arial" ForeColor="black" style="text-align=center" AutoPostBack="true" ViewStateMode="Enabled" AppendDataBoundItems="True">
                        <asp:ListItem>Select..</asp:ListItem>
                        <asp:ListItem Value="1">1 GB</asp:ListItem>
                        <asp:ListItem Value="2">2 GB</asp:ListItem>
                        <asp:ListItem Value="4">4 GB</asp:ListItem>
                        <asp:ListItem Value="6">6 GB</asp:ListItem>
                        <asp:ListItem Value="8">8 GB</asp:ListItem>
                        <asp:ListItem Value="10">10 GB</asp:ListItem>
                        <asp:ListItem Value="12">12 GB</asp:ListItem>
                        <asp:ListItem Value="16">16 GB</asp:ListItem>
                        <asp:ListItem Value="32">32 GB</asp:ListItem>
                        <asp:ListItem Value="64">64 GB</asp:ListItem>
                        <asp:ListItem Value="128">128 GB</asp:ListItem>
                        <asp:ListItem Value="256">256 GB</asp:ListItem>
                        <asp:ListItem Value="512">512 GB</asp:ListItem>
                        <asp:ListItem Value="1024">1 TB</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqDBServerMemory" runat="server" InitialValue="Select.." ControlToValidate="dropDBServerMemory" ErrorMessage="Select Database Server Memory." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowDBServerDirectoryLocation" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAPIDBServerDirectoryLocation" runat="server" Text="API Database Server Directory Location" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtAPIDBServerDirectoryLocation" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter API DB Server Directory Locationn Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqDBServerDirectoryLocation" runat="server" ControlToValidate="txtDBServerDirectoryLocation" ErrorMessage="Select DB Server Directory Location." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowDBMDFFileLocation" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAPIMDFFileLocation" runat="server" Text="API Database MDF File Location" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtAPIMDFFileLocation" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter API DB MDF File Location Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                   <%-- <asp:RequiredFieldValidator ID="ReqDBMDFFileLocation" runat="server" ControlToValidate="txtDBMDFFileLocation" ErrorMessage="Enter Database MDF File Location" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowAPIMDFFileSize" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAPIMDFFileSize" runat="server" Text="API Database MDF File Size" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtAPIMDFFileSize" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter API DB MDF File Size Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqDBMDFFileSize" runat="server" ControlToValidate="txtDBMDFFileSize" ErrorMessage="Enter Database MDF File Size" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowAPILDFFileLocation" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAPILDFFileLocation" runat="server" Text="API Database LDF File Location" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtAPILDFFileLocation" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter API DB LDF File Location Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqDBLDFFileLocation" runat="server" ControlToValidate="txtDBLDFFileLocation" ErrorMessage="Enter Database LDF File Location" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowAPILDFFileSize" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAPIDBLDFFileSize" runat="server" Text="Database LDF File Size" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtAPIDBLDFFileSize" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter API DB LDF File Size Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqDBLDFFileSize" runat="server" ControlToValidate="txtDBLDFFileSize" ErrorMessage="Enter DB LDF File Size" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowAPIServerIP" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAPIServerIP" runat="server" Text="API Server IP" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtAPIServerIP" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter API Server IP Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqDBServerIP" runat="server" ControlToValidate="txtDBServerIP" ErrorMessage="Enter Database Server IP" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowDBServerPort" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lbAPIServerPort" runat="server" Text="API Server Port" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtAPIServerPort" TextMode="Number" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter API Server Port Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqDBServerPort" runat="server" ControlToValidate="txtDBServerPort" ErrorMessage="Enter Database Server Port" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowAPIServerDependency" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAPIServerDependency" runat="server" Text="API Server Dependency" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtAPIServerDependency" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter API Server Dependency Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqDBServerDependency" runat="server" ControlToValidate="txtDBServerDependency" ErrorMessage="Enter Database Server Dependency" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="rowAPIDatabaseLastBackedupDate" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAPIDatabaseLastBackedupDate" runat="server" Text="API Database Last Backup Date" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtAPIDatabaseLastBackedupDate" runat="server" TextMode="DateTime" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter API Database Last Backup Date Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqDBServerDependency" runat="server" ControlToValidate="txtDBServerDependency" ErrorMessage="Enter Database Server Dependency" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="rowAPIDatabaseLastRestoreDate" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAPIDatabaseLastRestoreDate" runat="server" Text="API Database Last Restore Date" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtAPIDatabaseLastRestoreDate" runat="server" TextMode="DateTime" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter API Database Last Restore Date Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqDBServerDependency" runat="server" ControlToValidate="txtDBServerDependency" ErrorMessage="Enter Database Server Dependency" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="rowVendor" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblVendor" runat="server" Text="Select Vender" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="dropVendor" runat="server" 
                        DataSourceID="SqlDataSourceVendor" DataTextField="VEN_NAME" 
                        DataValueField="VEN_ID">
                        <asp:ListItem>Select API Vendor</asp:ListItem>
                    </asp:DropDownList>

                    <asp:SqlDataSource ID="SqlDataSourceVendor" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
                        SelectCommand="SELECT [VEN_ID], [VEN_NAME] FROM [VENDER]">
                    </asp:SqlDataSource>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqDBServerDependency" runat="server" ControlToValidate="txtDBServerDependency" ErrorMessage="Enter Database Server Dependency" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="rowSubmit" runat="server">
                <asp:TableCell>
                    
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="btnSave" runat="server" Text="SAVE" Width="70px" Height="30px" style="margin:5px;padding:5px;" />
                    <asp:Button ID="btnClear" runat="server" Text="CLEAR" Width="70px" Height="30px" style="margin:5px;padding:5px;" />
                </asp:TableCell>
                <asp:TableCell>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" InitialValue="*" ControlToValidate="txtClientName" Display="Dynamic" EnableClientScript="true" Text="Please Enter Client Name"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <br />

    </asp:Panel>

    

</asp:Content>
