<%@ Page Title="Portal - BA Dashboard" Language="C#" MasterPageFile="~/SiteLogout.Master" AutoEventWireup="true" CodeBehind="BA-Dashboard.aspx.cs" Inherits="HelloWorld.ProtectedPages.BA_Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Styles/bootstrap.min.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <panel runat="server" style="padding:5px;background-image:url('../Images/bi-dashboard.png');">
        <h2>Business Analysis Dashboard</h2>
        
    </panel>
</asp:Content>
