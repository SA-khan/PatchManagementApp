<%@ Page Title="Portal - Add Environment" Language="C#" MasterPageFile="~/SiteLogout.Master" AutoEventWireup="true" CodeBehind="AddClientEnvironment.aspx.cs" Inherits="HelloWorld.ProtectedPages.AddClientEnvironment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server">

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

    <asp:Panel ID="pnlEnvironment" runat="server" GroupingText="Add an Environment" ForeColor="navy" Font-Size="Larger" Font-Names="Arial">
        <asp:Table ID="Table1" runat="server" Width="100%" BackColor="Menu" BorderStyle="Solid" BorderColor="DarkGray" BorderWidth="2px" HorizontalAlign="Center" CellSpacing="5" CellPadding="5" style="margin:5px;padding:5px;">
            <asp:TableHeaderRow Height="40px">
                <asp:TableHeaderCell ColumnSpan="3" HorizontalAlign="Left" style="padding:5px;">
                    <asp:Label ID="Label1" runat="server" Text="Application Infrastructure Configuration" Font-Italic="true" ForeColor="White" BackColor="Navy" Font-Names="Arial" Font-Size="Small" style="padding:10px;"></asp:Label>
                    <asp:ValidationSummary ID="ValidationSummary1" EnableClientScript="true" DisplayMode="BulletList" HeaderText="Please Enter Following Fields: " ShowMessageBox="true" runat="server" ForeColor="Red" ShowSummary="False" />
                    <br />
                    <br />
                    <asp:Label ID="lblSubmission" runat="server" Text="Environment is successfully added." Font-Italic="true" ForeColor="Navy" Font-Names="Arial" Font-Size="Medium" Visible="false"></asp:Label>
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow ID="rowClientName" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblClientName" runat="server" Text="Client Name" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="dropClientName" runat="server" BackColor="ButtonFace" Width="250px" Height="27px" Font-Italic="true" Font-Size="Medium" Font-Names="Arial" ForeColor="black" DataSourceID="SqlDataSource4" DataTextField="ClientName" style="text-align=center" DataValueField="ClientID" AutoPostBack="true" ViewStateMode="Enabled" AppendDataBoundItems="True">
                        <asp:ListItem>Select..</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" SelectCommand="SELECT [ClientID],[ClientName] FROM [ClientDetail]"></asp:SqlDataSource>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:RequiredFieldValidator ID="ReqClientName" runat="server" InitialValue="Select.." ControlToValidate="dropClientName" ErrorMessage="Select Client Name." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowProductName" runat="server">
                <asp:TableCell>
                    <asp:Label ID="lblProductName" runat="server" Text="Product Name" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <%--<asp:TextBox ID="txtProductName" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" TextMode="Email" placeholder="Enter Product Name Here"></asp:TextBox>--%>
                    <asp:DropDownList ID="dropProductName" runat="server" BackColor="ButtonFace" Width="250px" Height="27px" Font-Italic="true" Font-Size="Medium" Font-Names="Arial" ForeColor="black" DataSourceID="SqlDataSource1" DataTextField="ProductName" style="text-align=center" DataValueField="ProductID" AutoPostBack="true" ViewStateMode="Enabled" AppendDataBoundItems="True">
                        <asp:ListItem>Select..</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" SelectCommand="SELECT [ProductID],[ProductName] FROM [Products]"></asp:SqlDataSource>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="ReqProductName" runat="server" InitialValue="Select.." ControlToValidate="dropProductName" Display="Dynamic" EnableClientScript="true" Text="(Required)" ForeColor="Red" Font-Bold="true" ErrorMessage="Select Product Name."></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowAppEnvType" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAppEnvType" runat="server" Text="Application Environment Type" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="dropAppEnvType" runat="server" BackColor="ButtonFace" Width="250px" Height="27px" Font-Italic="true" Font-Size="Medium" Font-Names="Arial" ForeColor="black" DataSourceID="SqlDataSource2" DataTextField="EnvTitle" style="text-align=center" DataValueField="EnvID" AutoPostBack="true" ViewStateMode="Enabled" AppendDataBoundItems="True">
                        <asp:ListItem>Select..</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" SelectCommand="SELECT [EnvID],[EnvTitle] FROM [EnvironmentType]"></asp:SqlDataSource>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:RequiredFieldValidator ID="ReqAppEnvType" runat="server" InitialValue="Select.." ControlToValidate="dropAppEnvType" ErrorMessage="Select Application Environment Type." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowDBEnvType" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblDBEnvType" runat="server" Text="Database Environment Type" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="dropDBEnvType" runat="server" BackColor="ButtonFace" Width="250px" Height="27px" Font-Italic="true" Font-Size="Medium" Font-Names="Arial" ForeColor="black" DataSourceID="SqlDataSource2" DataTextField="EnvTitle" style="text-align=center" DataValueField="EnvID" AutoPostBack="true" ViewStateMode="Enabled" AppendDataBoundItems="True">
                        <asp:ListItem>Select..</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:RequiredFieldValidator ID="ReqDBEnvType" runat="server" InitialValue="Select.." ControlToValidate="dropDBEnvType" ErrorMessage="Select Database Environment Type." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowAppServerName" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAppServerName" runat="server" Text="Application Server Name" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtAppServerName" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter App Server Name Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:RequiredFieldValidator ID="ReqAppServerName" runat="server" ControlToValidate="txtAppServerName" ErrorMessage="Enter Application Server Name." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowAppServerOS" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAppServerOS" runat="server" Text="Application Server OS" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtAppServerOS" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter App Server OS Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqAppServerOS" runat="server" ControlToValidate="txtAppServerOS" ErrorMessage="Enter Application Server OS." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowAppServerOSBuild" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAppServerOSBuild" runat="server" Text="Application Server OS Build" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
<%--                    <asp:TextBox ID="txtAppServerOSBuild" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter App Server OS Here"></asp:TextBox>--%>
                        <asp:DropDownList ID="dropAppServerOSBuild" runat="server" BackColor="ButtonFace" Width="250px" Height="27px" Font-Italic="true" Font-Size="Medium" Font-Names="Arial" ForeColor="black" style="text-align=center" ViewStateMode="Enabled" AppendDataBoundItems="True">
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
                    <%--<asp:RequiredFieldValidator ID="ReqAppServerOSBuild" runat="server" InitialValue="Select.." ControlToValidate="dropAppServerOSBuild" ErrorMessage="Select Application Server OS Build." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowAppServerIsX86" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAppServerIsX86" runat="server" Text="App Server Version" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RadioButtonList ID="radAppServerIsX86" runat="server" ForeColor="black" Font-Size="Small">
                        <asp:ListItem Value="1">x86 Bit</asp:ListItem>
                        <asp:ListItem Value="0" Selected="True">x64 Bit</asp:ListItem>
                    </asp:RadioButtonList>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqPatchCreatedDate" runat="server" ControlToValidate="rowAppServerIsX86" ErrorMessage="Enter Patch Created Date." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowAppServerIsVirtual" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAppServerIsVirtual" runat="server" Text="App Server Environment" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RadioButtonList ID="radAppServerIsVirtual" runat="server" AppendDataBoundItems="true" ForeColor="black" Font-Size="Small">
                        <asp:ListItem Value="0">Physical Machine</asp:ListItem>
                        <asp:ListItem Value="1" Selected="True">Virtual Machine</asp:ListItem>
                    </asp:RadioButtonList>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqPatchCreatedDate" runat="server" ControlToValidate="rowAppServerIsX86" ErrorMessage="Enter Patch Created Date." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowAppServerProcessor" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAppServerProcessor" runat="server" Text="App Server Processor" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtAppServerProcessor" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter App Processor Details Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqAppServerProcessor" runat="server" ControlToValidate="txtAppServerProcessor" ErrorMessage="Enter App Server Processor." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowAppServerMemory" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAppServerMemory" runat="server" Text="App Server Memory" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="dropAppServerMemory" runat="server" BackColor="ButtonFace" Width="250px" Height="27px" Font-Italic="true" Font-Size="Medium" Font-Names="Arial" ForeColor="black" style="text-align=center" AutoPostBack="true" ViewStateMode="Enabled" AppendDataBoundItems="True">
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
                    <%--<asp:RequiredFieldValidator ID="ReqAppServerMemory" runat="server" InitialValue="Select.." ControlToValidate="dropAppServerMemory" ErrorMessage="Select App Server Memory." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowAppServerWebBrowser" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAppServerWebBrowser" runat="server" Text="App Server Web Browser" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="dropAppServerWebBrowser" runat="server" BackColor="ButtonFace" Width="250px" Height="27px" Font-Italic="true" Font-Size="Medium" Font-Names="Arial" ForeColor="black" style="text-align=center" AutoPostBack="true" ViewStateMode="Enabled" AppendDataBoundItems="True">
                        <asp:ListItem>Select..</asp:ListItem>
                        <asp:ListItem>	AOLserver	</asp:ListItem>
                        <asp:ListItem>	Apache HTTP Server	</asp:ListItem>
                        <asp:ListItem>	Apache Tomcat	</asp:ListItem>
                        <asp:ListItem>	Boa	</asp:ListItem>
                        <asp:ListItem>	Caddy	</asp:ListItem>
                        <asp:ListItem>	Caudium	</asp:ListItem>
                        <asp:ListItem>	Cherokee HTTP Server	</asp:ListItem>
                        <asp:ListItem>	GlassFish	</asp:ListItem>
                        <asp:ListItem>	Hiawatha	</asp:ListItem>
                        <asp:ListItem>	HFS	</asp:ListItem>
                        <asp:ListItem>	IBM HTTP Server	</asp:ListItem>
                        <asp:ListItem>	Internet Information Services	</asp:ListItem>
                        <asp:ListItem>	Jetty	</asp:ListItem>
                        <asp:ListItem>	Jexus	</asp:ListItem>
                        <asp:ListItem>	lighttpd	</asp:ListItem>
                        <asp:ListItem>	LiteSpeed Web Server	</asp:ListItem>
                        <asp:ListItem>	Mongoose	</asp:ListItem>
                        <asp:ListItem>	Monkey HTTP Server	</asp:ListItem>
                        <asp:ListItem>	NaviServer	</asp:ListItem>
                        <asp:ListItem>	NCSA HTTPd	</asp:ListItem>
                        <asp:ListItem>	Nginx	</asp:ListItem>
                        <asp:ListItem>	OpenLink Virtuoso	</asp:ListItem>
                        <asp:ListItem>	Oracle HTTP Server	</asp:ListItem>
                        <asp:ListItem>	Oracle iPlanet Web Server	</asp:ListItem>
                        <asp:ListItem>	Oracle WebLogic Server	</asp:ListItem>
                        <asp:ListItem>	Resin Open Source	</asp:ListItem>
                        <asp:ListItem>	Resin Professional	</asp:ListItem>
                        <asp:ListItem>	thttpd	</asp:ListItem>
                        <asp:ListItem>	TUX web server	</asp:ListItem>
                        <asp:ListItem>	Wakanda Server	</asp:ListItem>
                        <asp:ListItem>	WEBrick	</asp:ListItem>
                        <asp:ListItem>	Xitami	</asp:ListItem>
                        <asp:ListItem>	Yaws	</asp:ListItem>
                        <asp:ListItem>	Zeus Web Server	</asp:ListItem>
                        <asp:ListItem>	Zope	</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqAppServerWebBrowser" runat="server" InitialValue="Select.." ControlToValidate="dropAppServerWebBrowser" ErrorMessage="Select App Server Web Browser." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowAppServerWebBrowserVersion" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAppServerWebBrowserVersion" runat="server" Text="App Server Web Browser Version" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtAppServerWebBrowserVersion" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter App Server Web Browser Version Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqAppServerWebBrowserVersion" runat="server" ControlToValidate="txtAppServerWebBrowserVersion" ErrorMessage="Enter App Server Web Browser Version" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowAppServerWorkingDirectoryLocation" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAppServerWorkingDirectoryLocation" runat="server" Text="App Server Web Browser Version" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtAppServerWorkingDirectoryLocation" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter App Server Working Directory Location Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqAppServerWorkingDirectoryLocation" runat="server" ControlToValidate="txtAppServerWorkingDirectoryLocation" ErrorMessage="Enter App Server Working Directory Location" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowAppHyperLink" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAppHyperLink" runat="server" Text="App HyperLink" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtAppHyperLink" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter App Hyper Link Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqAppHyperLink" runat="server" ControlToValidate="txtAppHyperLink" ErrorMessage="Enter App Hyper Link" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowAppServerIP" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAppServerIP" runat="server" Text="App Server IP" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtAppServerIP" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter App Server IP Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqAppServerIP" runat="server" ControlToValidate="txtAppServerIP" ErrorMessage="Enter App Server IP" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowAppServerPort" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAppServerPort" runat="server" Text="App Server IP" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtAppServerPort" TextMode="Number" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter App Server Port Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqAppServerPort" runat="server" ControlToValidate="txtAppServerPort" ErrorMessage="Enter App Server Port" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowAppServerDependency" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblAppServerDependency" runat="server" Text="App Server Dependency" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtAppServerDependency" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter App Server Dependency Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqAppServerDependency" runat="server" ControlToValidate="txtAppServerDependency" ErrorMessage="Enter App Server Dependency" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableHeaderRow Height="40px">
                <asp:TableHeaderCell ColumnSpan="3" HorizontalAlign="Left" style="margin:5px;padding:5px;">
                    <br />
                    <asp:Label ID="lblDatabaseHeader" runat="server" Text="Database Infrastructure Configuration" Font-Italic="true" ForeColor="White" BackColor="Navy" Font-Names="Arial" Font-Size="Small" style="padding:10px;"></asp:Label>
                    <br />
                    <br />
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow ID="rowIsEnvSameAsDB" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblIsEnvSameAsDB" runat="server" Text="DB and App Server on Same Server" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <%--<asp:TextBox ID="txtPatchIsQAPassed" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter Patch Is QA Passed Here"></asp:TextBox>--%>
                    <asp:CheckBoxList>
                        <asp:CheckBox ID="checkIsEnvSameAsDBYes" runat="server" TextAlign="Right" Text="Yes" ForeColor="black" Font-Size="Medium" AutoPostBack="True" oncheckedchanged="checkIsEnvSameAsDBYes_CheckedChanged" />
                        <asp:CheckBox ID="checkIsEnvSameAsDBNo" runat="server" TextAlign="Right" Text="No" ForeColor="black" Font-Size="Medium" AutoPostBack="True" oncheckedchanged="checkIsEnvSameAsDBNo_CheckedChanged" />
                    </asp:CheckBoxList>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqPatchIsQAPassed" runat="server" ControlToValidate="txtPatchIsQAPassed" ErrorMessage="Please Check Patch Is QA Passed" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            
            <%--Start--%>

            <asp:TableRow ID="rowDBServerName" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblDBServerName" runat="server" Text="Database Server Name" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtDBServerName" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter DB Server Name Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqDBServerName" runat="server" ControlToValidate="txtDBServerName" ErrorMessage="Enter Database Server Name." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowlblDBServerOS" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblDBServerOS" runat="server" Text="Database Server OS" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtDBServerOS" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter DB Server OS Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqlblDBServerOS" runat="server" ControlToValidate="txtDBServerOS" ErrorMessage="Enter Database Server OS." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowlblDBServerOSBuild" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblDBServerOSBuild" runat="server" Text="Database Server OS Build" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                        <asp:DropDownList ID="dropDBServerOSBuild" runat="server" BackColor="ButtonFace" Width="250px" Height="27px" Font-Italic="true" Font-Size="Medium" Font-Names="Arial" ForeColor="black" style="text-align=center" ViewStateMode="Enabled" AppendDataBoundItems="True">
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
            <asp:TableRow ID="rowDBServerIsx86" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblDBServerIsx86" runat="server" Text="Database Server Version" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RadioButtonList ID="radDBServerIsx86" runat="server" ForeColor="black" Font-Size="Small">
                        <asp:ListItem Value="1">x86 Bit</asp:ListItem>
                        <asp:ListItem Value="0" Selected="True">x64 Bit</asp:ListItem>
                    </asp:RadioButtonList>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqPatchCreatedDate" runat="server" ControlToValidate="rowAppServerIsX86" ErrorMessage="Enter Patch Created Date." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowDBServerIsVirtual" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblDBServerIsVirtual" runat="server" Text="Database Server Environment" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RadioButtonList ID="radDBServerIsVirtual" runat="server" AppendDataBoundItems="true" ForeColor="black" Font-Size="Small">
                        <asp:ListItem Value="0" Selected="True">Physical Machine</asp:ListItem>
                        <asp:ListItem Value="1">Virtual Machine</asp:ListItem>
                    </asp:RadioButtonList>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqPatchCreatedDate" runat="server" ControlToValidate="rowAppServerIsX86" ErrorMessage="Enter Patch Created Date." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowDBServerProcessor" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblDBServerProcessor" runat="server" Text="Database Server Processor" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtDBServerProcessor" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter Database Processor Details Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqDBServerProcessor" runat="server" ControlToValidate="txtDBServerProcessor" ErrorMessage="Enter Database Server Processor." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowDBServerMemory" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblDBServerMemory" runat="server" Text="Database Server Memory" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="dropDBServerMemory" runat="server" BackColor="ButtonFace" Width="250px" Height="27px" Font-Italic="true" Font-Size="Medium" Font-Names="Arial" ForeColor="black" style="text-align=center" AutoPostBack="true" ViewStateMode="Enabled" AppendDataBoundItems="True">
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
                    <asp:Label ID="lblDBServerDirectoryLocation" runat="server" Text="Database Server Directory Location" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtDBServerDirectoryLocation" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter DB Server Directory Locationn Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqDBServerDirectoryLocation" runat="server" ControlToValidate="txtDBServerDirectoryLocation" ErrorMessage="Select DB Server Directory Location." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowDBMDFFileLocation" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblDBMDFFileLocation" runat="server" Text="Database MDF File Location" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtDBMDFFileLocation" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter DB MDF File Location Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                   <%-- <asp:RequiredFieldValidator ID="ReqDBMDFFileLocation" runat="server" ControlToValidate="txtDBMDFFileLocation" ErrorMessage="Enter Database MDF File Location" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowDBMDFFileSize" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblDBMDFFileSize" runat="server" Text="Database MDF File Size" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtDBMDFFileSize" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter DB MDF File Size Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqDBMDFFileSize" runat="server" ControlToValidate="txtDBMDFFileSize" ErrorMessage="Enter Database MDF File Size" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowDBLDFFileLocation" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblDBLDFFileLocation" runat="server" Text="Database LDF File Location" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtDBLDFFileLocation" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter DB LDF File Location Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqDBLDFFileLocation" runat="server" ControlToValidate="txtDBLDFFileLocation" ErrorMessage="Enter Database LDF File Location" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowDBLDFFileSize" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblDBLDFFileSize" runat="server" Text="Database LDF File Size" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtDBLDFFileSize" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter DB LDF File Size Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqDBLDFFileSize" runat="server" ControlToValidate="txtDBLDFFileSize" ErrorMessage="Enter DB LDF File Size" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowDBServerIP" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblDBServerIP" runat="server" Text="Database Server IP" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtDBServerIP" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter DB Server IP Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqDBServerIP" runat="server" ControlToValidate="txtDBServerIP" ErrorMessage="Enter Database Server IP" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowDBServerPort" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblDBServerPort" runat="server" Text="Database Server Port" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtDBServerPort" TextMode="Number" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter DB Server Port Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqDBServerPort" runat="server" ControlToValidate="txtDBServerPort" ErrorMessage="Enter Database Server Port" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowDBServerDependency" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblDBServerDependency" runat="server" Text="Database Server Dependency" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtDBServerDependency" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter DB Server Dependency Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqDBServerDependency" runat="server" ControlToValidate="txtDBServerDependency" ErrorMessage="Enter Database Server Dependency" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>

            <%--End--%>
            
            <asp:TableRow ID="rowSubmit" runat="server">
                <asp:TableCell>
                    
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="btnSave" runat="server" Text="SAVE" onclick="btnSave_Click" Width="70px" Height="30px" style="margin:5px;padding:5px;" />
                    <asp:Button ID="btnClear" runat="server" Text="CLEAR" onclick="btnClear_Click" Width="70px" Height="30px" style="margin:5px;padding:5px;" />
                </asp:TableCell>
                <asp:TableCell>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" InitialValue="*" ControlToValidate="txtClientName" Display="Dynamic" EnableClientScript="true" Text="Please Enter Client Name"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <br />
    </asp:Panel>

    </ContentTemplate>
        </asp:UpdatePanel>

    </asp:Panel>

</asp:Content>
