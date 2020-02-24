<%@ Page Title="Portal - Edit Environment" Language="C#" MasterPageFile="~/SiteLogout.Master" AutoEventWireup="true" CodeBehind="EditEnvironemt.aspx.cs" Inherits="HelloWorld.ProtectedPages.EditClientEnvironemt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<style>
    .accordionView 
    {
       <%--Display: none; --%>
    }
</style>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        //ACCORDION BUTTON ACTION
        $('.accordionView').click(function () {
            alert("HERE!");
            $(this).next().slideToggle();
        });
        $('.accordionButton').click(function () {
            //            $('.accordionView').css.Display('none');
        });
    });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <%--<asp:Panel ID="Panel1" runat="server" Width="100%" ScrollBars="Both" height="470px">--%>
    <asp:Panel ID="Panel1" runat="server" GroupingText="Edit Environment" ScrollBars="Both" Height="460px" BorderStyle="Ridge">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
    <ContentTemplate>
   <asp:DetailsView ID="DetailsView1" CssClass="accordionView" runat="server" 
        Height="50px" Width="8%" 
        AutoGenerateRows="False" BackColor="White" BorderColor="#CCCCCC" OnRowCommand="GridView1_RowCommand"
        BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        onpageindexchanging="DetailsView1_PageIndexChanging" 
        ondatabound="DetailsView1_DataBound">
        <EditRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <Fields>
            <asp:TemplateField HeaderText="Environment ID" SortExpression="EnvironmentID">
                <ItemTemplate>
                    <asp:TextBox ID="txtEnvironmentID" runat="server" disabled Text='<%# Bind("EnvironmentID") %>' EnableViewState=true ViewStateMode="Enabled"></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEnvironmentID" runat="server" Text='<%# Bind("EnvironmentID") %>'></asp:TextBox>
                </EditItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEnvironmentID" runat="server" Text='<%# Bind("EnvironmentID") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtEnvironmentID" runat="server" Text='<%# Bind("EnvironmentID") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Client Name" SortExpression="ClientName">
                <ItemTemplate>
                    <asp:TextBox ID="txtClientName" runat="server" disabled Text='<%# Bind("ClientName") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtClientName" runat="server" Text='<%# Bind("ClientName") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtClientName" runat="server" Text='<%# Bind("ClientName") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Product Name" SortExpression="ProductName">
                <ItemTemplate>
                    <asp:TextBox ID="txtProductName" runat="server" disabled Text='<%# Bind("ProductName") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtProductName" runat="server" Text='<%# Bind("ProductName") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtProductName" runat="server" Text='<%# Bind("ProductName") %>'></asp:TextBox>
                </InsertItemTemplate>
                <%--<EditItemTemplate>
                    <asp:TextBox ID="txtClientType" runat="server" Text='<%# Bind("ClientType") %>'></asp:TextBox>
                </EditItemTemplate>--%>
<%--                <InsertItemTemplate>
                    <asp:TextBox ID="txtClientType" runat="server" Text='<%# Bind("ClientType") %>'></asp:TextBox>
                </InsertItemTemplate>--%>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="App Server Env Type" SortExpression="EnvironmentAppServerEnvType">
                <ItemTemplate>
                    <asp:TextBox ID="txtEnvironmentAppServerEnvType" runat="server" disabled Text='<%# Bind("AppServerEnvType") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEnvironmentAppServerEnvType" runat="server" Text='<%# Bind("EnvironmentAppServerEnvType") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtEnvironmentAppServerEnvType" runat="server" Text='<%# Bind("EnvironmentAppServerEnvType") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DB Server Env Type" 
                SortExpression="DBServerEnvType">
                <ItemTemplate>
                    <asp:TextBox ID="txtDBServerEnvType" runat="server" disabled Text='<%# Bind("DBServerEnvType") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtDBServerEnvType" runat="server" Text='<%# Bind("DBServerEnvType") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtDBServerEnvType" runat="server" Text='<%# Bind("DBServerEnvType") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="App Server Name" 
                SortExpression="AppServerName">
                <ItemTemplate>
                    <asp:TextBox ID="txtAppServerName" runat="server" 
                        Text='<%# Bind("AppServerName") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtAppServerName" runat="server" 
                        Text='<%# Bind("AppServerName") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtAppServerName" runat="server" 
                        Text='<%# Bind("AppServerName") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="App Server OS" 
                SortExpression="AppServerOS">
                <ItemTemplate>
                    <asp:TextBox ID="txtAppServerOS" runat="server" 
                        Text='<%# Bind("AppServerOS") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtAppServerOS" runat="server" 
                        Text='<%# Bind("AppServerOS") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtAppServerOS" runat="server" 
                        Text='<%# Bind("AppServerOS") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="App Server OS Build" 
                SortExpression="AppServerOSBuild">
                <ItemTemplate>
                    <asp:TextBox ID="txtAppServerOSBuild" runat="server" 
                        Text='<%# Bind("AppServerOSBuild") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtAppServerOSBuild" runat="server" 
                        Text='<%# Bind("AppServerOSBuild") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtAppServerOSBuild" runat="server" 
                        Text='<%# Bind("AppServerOSBuild") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="App Server Is 32-Bit Version" 
                SortExpression="AppServerIsX86Version">
                <ItemTemplate>
                    <asp:TextBox ID="txtAppServerOSBuild" runat="server" 
                        Text='<%# Bind("AppServerIsX86Version") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtAppServerOSBuild" runat="server" 
                        Text='<%# Bind("AppServerIsX86Version") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtAppServerOSBuild" runat="server" 
                        Text='<%# Bind("AppServerIsX86Version") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="App Server Is Virtual" 
                SortExpression="AppServerIsVirtual">
                <ItemTemplate>
                    <asp:TextBox ID="txtAppServerIsVirtual" runat="server" 
                        Text='<%# Bind("AppServerIsVirtual") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtAppServerIsVirtual" runat="server" 
                        Text='<%# Bind("AppServerIsVirtual") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtAppServerIsVirtual" runat="server" 
                        Text='<%# Bind("AppServerIsVirtual") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="App Server Processor" 
                SortExpression="AppServerProcessor">
                <ItemTemplate>
                    <asp:TextBox ID="txtAppServerProcessor" runat="server" 
                        Text='<%# Bind("AppServerProcessor") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtAppServerOSBuild" runat="server" 
                        Text='<%# Bind("AppServerProcessor") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtAppServerOSBuild" runat="server" 
                        Text='<%# Bind("AppServerProcessor") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="App Server Memory" 
                SortExpression="AppServerMemory">
                <ItemTemplate>
                    <asp:TextBox ID="txtAppServerMemory" runat="server" 
                        Text='<%# Bind("AppServerMemory") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtAppServerMemory" runat="server" 
                        Text='<%# Bind("AppServerMemory") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtAppServerMemory" runat="server" 
                        Text='<%# Bind("AppServerMemory") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="App Server Web Browser" 
                SortExpression="AppServerWebBrowser">
                <ItemTemplate>
                    <asp:TextBox ID="txtAppServerWebBrowser" runat="server" 
                        Text='<%# Bind("AppServerWebBrowser") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtAppServerWebBrowser" runat="server" 
                        Text='<%# Bind("AppServerWebBrowser") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtAppServerWebBrowser" runat="server" 
                        Text='<%# Bind("AppServerWebBrowser") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="App Server Web Browser Version" 
                SortExpression="AppServerWebBrowserVersion">
                <ItemTemplate>
                    <asp:TextBox ID="txtAppServerWebBrowserVersion" runat="server" 
                        Text='<%# Bind("AppServerWebBrowserVersion") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtAppServerWebBrowserVersion" runat="server" 
                        Text='<%# Bind("AppServerWebBrowserVersion") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtAppServerWebBrowserVersion" runat="server" 
                        Text='<%# Bind("AppServerWebBrowserVersion") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="App Server Working Directory Location" 
                SortExpression="AppServerWorkingDirectoryLocation">
                <ItemTemplate>
                    <asp:TextBox ID="txtAppServerWorkingDirectoryLocation" runat="server" 
                        Text='<%# Bind("AppServerWorkingDirectoryLocation") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtAppServerWorkingDirectoryLocation" runat="server" 
                        Text='<%# Bind("AppServerWorkingDirectoryLocation") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtAppServerWorkingDirectoryLocation" runat="server" 
                        Text='<%# Bind("AppServerWorkingDirectoryLocation") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="App Hyper Link" 
                SortExpression="AppHyperLink">
                <ItemTemplate>
                    <asp:TextBox ID="txtAppHyperLink" runat="server" 
                        Text='<%# Bind("AppHyperLink") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtAppHyperLink" runat="server" 
                        Text='<%# Bind("AppHyperLink") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtAppHyperLink" runat="server" 
                        Text='<%# Bind("AppHyperLink") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="App Server IP" 
                SortExpression="AppServerIP">
                <ItemTemplate>
                    <asp:TextBox ID="txtAppServerIP" runat="server" 
                        Text='<%# Bind("AppServerIP") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtAppServerIP" runat="server" 
                        Text='<%# Bind("AppServerIP") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtAppServerIP" runat="server" 
                        Text='<%# Bind("AppServerIP") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="App Server Port" 
                SortExpression="AppServerPort">
                <ItemTemplate>
                    <asp:TextBox ID="txtAppServerPort" runat="server" 
                        Text='<%# Bind("AppServerPort") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtAppServerPort" runat="server" 
                        Text='<%# Bind("AppServerPort") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtAppServerPort" runat="server" 
                        Text='<%# Bind("AppServerPort") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="App Server Dependency" 
                SortExpression="AppServerDependency">
                <ItemTemplate>
                    <asp:TextBox ID="txtAppServerDependency" runat="server" 
                        Text='<%# Bind("AppServerDependency") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtAppServerDependency" runat="server" 
                        Text='<%# Bind("AppServerDependency") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtAppServerDependency" runat="server" 
                        Text='<%# Bind("AppServerDependency") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DB Server Name" 
                SortExpression="DBServerName">
                <ItemTemplate>
                    <asp:TextBox ID="txtDBServerName" runat="server" 
                        Text='<%# Bind("DBServerName") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtDBServerName" runat="server" 
                        Text='<%# Bind("DBServerName") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtDBServerName" runat="server" 
                        Text='<%# Bind("DBServerName") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DBServerIsX86Version" 
                SortExpression="DBServerIsX86Version">
                <ItemTemplate>
                    <asp:TextBox ID="txtDBServerIsX86Version" runat="server" 
                        Text='<%# Bind("DBServerIsX86Version") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtDBServerIsX86Version" runat="server" 
                        Text='<%# Bind("DBServerIsX86Version") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtDBServerIsX86Version" runat="server" 
                        Text='<%# Bind("DBServerIsX86Version") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DBServerIsVirtual" 
                SortExpression="DBServerIsVirtual">
                <ItemTemplate>
                    <asp:TextBox ID="txtDBServerIsVirtual" runat="server" 
                        Text='<%# Bind("DBServerIsVirtual") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtDBServerIsVirtual" runat="server" 
                        Text='<%# Bind("DBServerIsVirtual") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtDBServerIsVirtual" runat="server" 
                        Text='<%# Bind("DBServerIsVirtual") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DB Server Memory" 
                SortExpression="DBServerMemory">
                <ItemTemplate>
                    <asp:TextBox ID="txtDBServerMemory" runat="server" 
                        Text='<%# Bind("DBServerMemory") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtDBServerMemory" runat="server" 
                        Text='<%# Bind("DBServerMemory") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtDBServerMemory" runat="server" 
                        Text='<%# Bind("DBServerMemory") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DB Server Processor" 
                SortExpression="DBServerProcessor">
                <ItemTemplate>
                    <asp:TextBox ID="txtDBServerProcessor" runat="server" 
                        Text='<%# Bind("DBServerProcessor") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtDBServerProcessor" runat="server" 
                        Text='<%# Bind("DBServerProcessor") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtDBServerProcessor" runat="server" 
                        Text='<%# Bind("DBServerProcessor") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DB Server OS" 
                SortExpression="DBServerOS">
                <ItemTemplate>
                    <asp:TextBox ID="txtDBServerOS" runat="server" 
                        Text='<%# Bind("DBServerOS") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtDBServerOS" runat="server" 
                        Text='<%# Bind("DBServerOS") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtDBServerOS" runat="server" 
                        Text='<%# Bind("DBServerOS") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DB Server OS Build" 
                SortExpression="DBServerOSBuild">
                <ItemTemplate>
                    <asp:TextBox ID="txtDBServerOSBuild" runat="server" 
                        Text='<%# Bind("DBServerOSBuild") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtDBServerOSBuild" runat="server" 
                        Text='<%# Bind("DBServerOSBuild") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtDBServerOSBuild" runat="server" 
                        Text='<%# Bind("DBServerOSBuild") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DB Server Directory Location" 
                SortExpression="DBServerDirectoryLocation">
                <ItemTemplate>
                    <asp:TextBox ID="txtDBServerDirectoryLocation" runat="server" 
                        Text='<%# Bind("DBServerDirectoryLocation") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtDBServerDirectoryLocation" runat="server" 
                        Text='<%# Bind("DBServerDirectoryLocation") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtDBServerDirectoryLocation" runat="server" 
                        Text='<%# Bind("DBServerDirectoryLocation") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DB MDF File Location" 
                SortExpression="DBMDFFileLocation">
                <ItemTemplate>
                    <asp:TextBox ID="txtDBMDFFileLocation" runat="server" 
                        Text='<%# Bind("DBMDFFileLocation") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtDBMDFFileLocation" runat="server" 
                        Text='<%# Bind("DBMDFFileLocation") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtDBMDFFileLocation" runat="server" 
                        Text='<%# Bind("DBMDFFileLocation") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DB MDF File Size" 
                SortExpression="DBMDFFileSize">
                <ItemTemplate>
                    <asp:TextBox ID="txtDBMDFFileSize" runat="server" 
                        Text='<%# Bind("DBMDFFileSize") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtDBMDFFileSize" runat="server" 
                        Text='<%# Bind("DBMDFFileSize") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtDBMDFFileSize" runat="server" 
                        Text='<%# Bind("DBMDFFileSize") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DB LDF File Location" 
                SortExpression="DBLDFFileLocation">
                <ItemTemplate>
                    <asp:TextBox ID="txtDBLDFFileLocation" runat="server" 
                        Text='<%# Bind("DBLDFFileLocation") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtDBLDFFileLocation" runat="server" 
                        Text='<%# Bind("DBLDFFileLocation") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtDBLDFFileLocation" runat="server" 
                        Text='<%# Bind("DBLDFFileLocation") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DB LDF File Size" 
                SortExpression="DBLDFFileSize">
                <ItemTemplate>
                    <asp:TextBox ID="txtDBLDFFileSize" runat="server" 
                        Text='<%# Bind("DBLDFFileSize") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtDBLDFFileSize" runat="server" 
                        Text='<%# Bind("DBLDFFileSize") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtDBLDFFileSize" runat="server" 
                        Text='<%# Bind("DBLDFFileSize") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DB Server IP" 
                SortExpression="DBServerIP">
                <ItemTemplate>
                    <asp:TextBox ID="txtDBServerIP" runat="server" 
                        Text='<%# Bind("DBServerIP") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtDBServerIP" runat="server" 
                        Text='<%# Bind("DBServerIP") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtDBServerIP" runat="server" 
                        Text='<%# Bind("DBServerIP") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DB Server Port" 
                SortExpression="DBServerPort">
                <ItemTemplate>
                    <asp:TextBox ID="txtDBServerPort" runat="server" 
                        Text='<%# Bind("DBServerPort") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtDBServerPort" runat="server" 
                        Text='<%# Bind("DBServerPort") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtDBServerPort" runat="server" 
                        Text='<%# Bind("DBServerPort") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DB Server Dependency" 
                SortExpression="DBServerDependency">
                <ItemTemplate>
                    <asp:TextBox ID="txtDBServerDependency" runat="server" 
                        Text='<%# Bind("DBServerDependency") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtDBServerDependency" runat="server" 
                        Text='<%# Bind("DBServerDependency") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtDBServerDependency" runat="server" 
                        Text='<%# Bind("DBServerDependency") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate>
                       <asp:Button ID="btnSave" runat="server" CausesValidation="false" 
                        Text="Save" onclick="btnSave_Click" />
                    <asp:Button ID="btnCancel" runat="server" CssClass="accordionButton" CausesValidation="false" 
                        Text="Cancel" onclick="btnCancel_Click" />
                </ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:TemplateField>
        </Fields>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
    </asp:DetailsView>

    <br/>
        
    <asp:GridView ID="GridView1" Width="100%" runat="server" DataKeyNames="EnvironmentID"
        style="min-height:100px;padding:5px;" CellPadding="5" S
        RowStyle-Height="60px"
        AutoGenerateColumns="false" AllowSorting="true"
        AlternatingRowStyle-BackColor="LightGray" BorderColor="ControlDark" 
        BorderStyle="Solid" BorderWidth="1" EditRowStyle-Font-Names="Arial" 
        EditRowStyle-Font-Size="Small" EditRowStyle-ForeColor="Black" 
        Font-Names="Arial" Font-Size="Small" Font-Bold="false" GridLines="Both" 
        HeaderStyle-BackColor="Aqua" HeaderStyle-Font-Names="Arial" ForeColor="Black" 
        HeaderStyle-Font-Size="Small" HeaderStyle-Font-Bold="false" 
        HeaderStyle-Font-Italic="true" HeaderStyle-Font-Underline="false" 
        HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" 
        HorizontalAlign="Right" RowStyle-HorizontalAlign="Right" 
        RowStyle-VerticalAlign="Middle" SelectedRowStyle-BackColor="DarkGray" 
        SelectedRowStyle-Font-Bold="true" SelectedRowStyle-Font-Size="Small" 
        SelectedRowStyle-Height="24px" onrowediting="GridView1_RowEditing" 
        onrowupdating="GridView1_RowUpdating" 
        onpageindexchanging="GridView1_PageIndexChanging" 
        onrowcancelingedit="GridView1_RowCancelingEdit" 
        onselectedindexchanged="GridView1_SelectedIndexChanged">
         <Columns>     
         <asp:TemplateField Visible="false" HeaderText="Environment ID">
         <ItemTemplate>
                 <asp:Label ID="lblEnvID" runat="server" 
                 Text='<%# Eval("EnvironmentID") %>' Width="200" />                              
         </ItemTemplate>
   </asp:TemplateField>                     
    <asp:TemplateField HeaderText="Client Name">
         <ItemTemplate>
                 <asp:Label ID="lblClientName" runat="server" 
                 Text='<%# Eval("ClientName") %>' Width="150" />                              
         </ItemTemplate>
   </asp:TemplateField>             
           <asp:TemplateField HeaderText="Product Name">
         <ItemTemplate>
                 <asp:Label ID="lblProductName" runat="server" 
                 Text='<%# Eval("ProductName") %>' Width="150" />                              
         </ItemTemplate>
   </asp:TemplateField>
           <asp:TemplateField HeaderText="App Env Type">
             <ItemTemplate>
                 <asp:Label ID="lblEnvironmentAppServerEnvType" runat="server" 
                 Text='<%# Eval("EnvironmentAppServerEnvType") %>' Width="150" />                              
             </ItemTemplate>
           </asp:TemplateField>
           <asp:TemplateField HeaderText="DB Env Type">
             <ItemTemplate>
                 <asp:Label ID="lblEnvironmentDBServerEnvType" runat="server" 
                 Text='<%# Eval("EnvironmentDBServerEnvType") %>' Width="150" />                              
             </ItemTemplate>
           </asp:TemplateField>  
           <asp:TemplateField HeaderText="App Server Name">
             <ItemTemplate>
                 <asp:Label ID="lblEnvironmentAppServerName" runat="server" 
                 Text='<%# Eval("EnvironmentAppServerName") %>' Width="150" />                              
             </ItemTemplate>
           </asp:TemplateField>  
           <asp:TemplateField HeaderText="App Server OS">
             <ItemTemplate>
                 <asp:Label ID="lblEnvironmentAppServerOS" runat="server" 
                 Text='<%# Eval("EnvironmentAppServerOS") %>' Width="150" />                              
             </ItemTemplate>
           </asp:TemplateField>
           <asp:TemplateField HeaderText="App Server OS Build">
             <ItemTemplate>
                 <asp:Label ID="lblEnvironmentAppServerOSBuild" runat="server" 
                 Text='<%# Eval("EnvironmentAppServerOSBuild") %>' Width="150" />                              
             </ItemTemplate>
           </asp:TemplateField>
           <asp:TemplateField HeaderText="App Server Is 32 Bit">
         <ItemTemplate>
                 <asp:Label ID="lblEnvironmentAppServerIsX86Version" runat="server" 
                 Text='<%# Eval("EnvironmentAppServerIsX86Version") %>' Width="150" />                              
         </ItemTemplate>
   </asp:TemplateField>             
           <asp:TemplateField HeaderText="App Server Is Virtual">
         <ItemTemplate>
                 <asp:Label ID="lblEnvironmentAppServerIsVirtual" runat="server" 
                 Text='<%# Eval("EnvironmentAppServerIsVirtual") %>' Width="150" />                              
         </ItemTemplate>
   </asp:TemplateField>
           <asp:TemplateField HeaderText="App Server Processor">
             <ItemTemplate>
                 <asp:Label ID="lblEnvironmentAppServerProcessor" runat="server" 
                 Text='<%# Eval("EnvironmentAppServerProcessor") %>' Width="150" />                              
             </ItemTemplate>
           </asp:TemplateField>
           <asp:TemplateField HeaderText="App Server Memory">
             <ItemTemplate>
                 <asp:Label ID="lblEnvironmentAppServerMemory" runat="server" 
                 Text='<%# Eval("EnvironmentAppServerMemory") %>' Width="150" />                              
             </ItemTemplate>
           </asp:TemplateField>  
           <asp:TemplateField HeaderText="Web Browser">
             <ItemTemplate>
                 <asp:Label ID="lblEnvironmentAppServerWebBrowser" runat="server" 
                 Text='<%# Eval("EnvironmentAppServerWebBrowser") %>' Width="150" />                              
             </ItemTemplate>
           </asp:TemplateField>  
           <asp:TemplateField HeaderText="Web Browser Version">
             <ItemTemplate>
                 <asp:Label ID="lblEnvironmentAppServerWebBrowserVersion" runat="server" 
                 Text='<%# Eval("EnvironmentAppServerWebBrowserVersion") %>' Width="150" />                              
             </ItemTemplate>
           </asp:TemplateField>
           <asp:TemplateField HeaderText="Working Directory Location">
             <ItemTemplate>
                 <asp:Label ID="lblEnvironmentAppServerWorkingDirectoryLocation" runat="server" 
                 Text='<%# Eval("EnvironmentAppServerWorkingDirectoryLocation") %>' Width="150" />                              
             </ItemTemplate>
           </asp:TemplateField> 
           <%--sa--%>
               <asp:TemplateField HeaderText="Hyper Link">
             <ItemTemplate>
                 <asp:Label ID="lblEnvironmentAppHyperLink" runat="server" 
                 Text='<%# Eval("EnvironmentAppHyperLink") %>' Width="150" />                              
             </ItemTemplate>
           </asp:TemplateField>  
           <asp:TemplateField HeaderText="App Server IP">
             <ItemTemplate>
                 <asp:Label ID="lblEnvironmentAppServerIP" runat="server" 
                 Text='<%# Eval("EnvironmentAppServerIP") %>' Width="150" />                              
             </ItemTemplate>
           </asp:TemplateField>
           <asp:TemplateField HeaderText="App Server Port">
             <ItemTemplate>
                 <asp:Label ID="lblEnvironmentAppServerPort" runat="server" 
                 Text='<%# Eval("EnvironmentAppServerPort") %>' Width="150" />                              
             </ItemTemplate>
           </asp:TemplateField>
           <asp:TemplateField HeaderText="App Server Dependency">
         <ItemTemplate>
                 <asp:Label ID="lblEnvironmentAppServerDependency" runat="server" 
                 Text='<%# Eval("EnvironmentAppServerDependency") %>' Width="150" />                              
         </ItemTemplate>
   </asp:TemplateField>             
           <asp:TemplateField HeaderText="DB Server Name">
         <ItemTemplate>
                 <asp:Label ID="lblEnvironmentDBServerName" runat="server" 
                 Text='<%# Eval("EnvironmentDBServerName") %>' Width="150" />                              
         </ItemTemplate>
   </asp:TemplateField>
           <%--<asp:TemplateField HeaderText="DB Server Env Type">
             <ItemTemplate>
                 <asp:Label ID="lblEnvironmentDBServerEnvType" runat="server" 
                 Text='<%# Eval("EnvironmentDBServerEnvType") %>' />                              
             </ItemTemplate>
           </asp:TemplateField>--%>
           <asp:TemplateField HeaderText="DB Server Is 32-Bit">
             <ItemTemplate>
                 <asp:Label ID="lblEnvironmentDBServerIsX86Version" runat="server" 
                 Text='<%# Eval("EnvironmentDBServerIsX86Version") %>' Width="150" />                              
             </ItemTemplate>
           </asp:TemplateField>  
           <asp:TemplateField HeaderText="DB Server Is Virtual">
             <ItemTemplate>
                 <asp:Label ID="lblEnvironmentDBServerIsVirtual" runat="server" 
                 Text='<%# Eval("EnvironmentDBServerIsVirtual") %>' Width="150" />                              
             </ItemTemplate>
           </asp:TemplateField>  
           <asp:TemplateField HeaderText="DB Server Memory">
             <ItemTemplate>
                 <asp:Label ID="lblEnvironmentDBServerMemory" runat="server" 
                 Text='<%# Eval("EnvironmentDBServerMemory") %>' Width="150" />                              
             </ItemTemplate>
           </asp:TemplateField>
           <asp:TemplateField HeaderText="DB Server Processor">
             <ItemTemplate>
                 <asp:Label ID="lblEnvironmentDBServerProcessor" runat="server" 
                 Text='<%# Eval("EnvironmentDBServerProcessor") %>' Width="150" />                              
             </ItemTemplate>
           </asp:TemplateField> 
           <asp:TemplateField HeaderText="DB Server OS">
             <ItemTemplate>
                 <asp:Label ID="lblEnvironmentDBServerOS" runat="server" 
                 Text='<%# Eval("EnvironmentDBServerOS") %>' Width="150" />                              
             </ItemTemplate>
           </asp:TemplateField> 
           <asp:TemplateField HeaderText="DB Server OS Build">
             <ItemTemplate>
                 <asp:Label ID="lblEnvironmentDBServerOSBuild" runat="server" 
                 Text='<%# Eval("EnvironmentDBServerOSBuild") %>' Width="150" />                              
             </ItemTemplate>
           </asp:TemplateField> 
            <asp:TemplateField HeaderText="DB Server Directory Location">
             <ItemTemplate>
                 <asp:Label ID="lblEnvironmentDBServerDirectoryLocation" runat="server" 
                 Text='<%# Eval("EnvironmentDBServerDirectoryLocation") %>' Width="150" />                              
             </ItemTemplate>
           </asp:TemplateField> 
           <asp:TemplateField HeaderText="DB MDF File Location">
             <ItemTemplate>
                 <asp:Label ID="lblEnvironmentDBMDFFileLocation" runat="server" 
                 Text='<%# Eval("EnvironmentDBMDFFileLocation") %>' Width="150" />                              
             </ItemTemplate>
           </asp:TemplateField> 
           <asp:TemplateField HeaderText="DB MDF File Size">
             <ItemTemplate>
                 <asp:Label ID="lblEnvironmentDBMDFFileSize" runat="server" 
                 Text='<%# Eval("EnvironmentDBMDFFileSize") %>' Width="150" />                              
             </ItemTemplate>
           </asp:TemplateField> 
           <asp:TemplateField HeaderText="DB LDF File Location">
             <ItemTemplate>
                 <asp:Label ID="lblEnvironmentDBLDFFileLocation" runat="server" 
                 Text='<%# Eval("EnvironmentDBLDFFileLocation") %>' Width="150" />                              
             </ItemTemplate>
           </asp:TemplateField>
           <asp:TemplateField HeaderText="DB LDF File Size">
             <ItemTemplate>
                 <asp:Label ID="lblEnvironmentDBLDFFileSize" runat="server" 
                 Text='<%# Eval("EnvironmentDBLDFFileSize") %>' Width="150" />                              
             </ItemTemplate>
           </asp:TemplateField>  
           <asp:TemplateField HeaderText="DB Server IP">
             <ItemTemplate>
                 <asp:Label ID="lblEnvironmentEnvDBServerIP" runat="server" 
                 Text='<%# Eval("EnvironmentEnvDBServerIP") %>' Width="150" />                              
             </ItemTemplate>
           </asp:TemplateField>
           <asp:TemplateField HeaderText="DB Server Port">
             <ItemTemplate>
                 <asp:Label ID="lblEnvironmentDBServerPort" runat="server" 
                 Text='<%# Eval("EnvironmentDBServerPort") %>' Width="150" />                              
             </ItemTemplate>
           </asp:TemplateField>
           <asp:TemplateField HeaderText="DB Server Dependency">
             <ItemTemplate>
                 <asp:Label ID="lblEnvironmentDBServerDependency" runat="server" 
                 Text='<%# Eval("EnvironmentDBServerDependency") %>' Width="150" />                              
             </ItemTemplate>
           </asp:TemplateField>
                <%--sa--%>
           <asp:TemplateField ShowHeader="true" HeaderText="Select">
             <ItemTemplate>                     
                    <asp:LinkButton ID="LnkSelect" runat="server" Text="Update"                           
                     CommandName="Select" Width="150" />&nbsp;           
             </ItemTemplate>
           </asp:TemplateField>                                      
   </Columns>
    </asp:GridView>
    </ContentTemplate>
    <Triggers>
        <%--<asp:AsyncPostBackTrigger ControlID="DetailsView1" EventName="btnCancel_Click" EventName="RowCommand" />--%>
    </Triggers>
        </asp:UpdatePanel>

        </asp:Panel>

        <br/>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>



</asp:Content>
