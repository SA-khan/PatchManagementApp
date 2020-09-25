<%@ Page Title="Portal - My Profile" Language="C#" MasterPageFile="~/MasterPages/SimpleLogin.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="HelloWorld.ProtectedPages.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Styles/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/bootstrap.min.js" type="text/javascript"></script>
    <link href="../Styles/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-3.5.1.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.js" type="text/javascript"></script>

    <div class="container">
        <h2 style="margin:10px;padding:10px;">My Profile</h2>
        <table class="table table-hover">
            <tbody>
                <tr>
                <td><asp:Localize ID="locallblUserLoginID" runat="server">Login ID</asp:Localize></td>
                <td><asp:Localize ID="localUserLoginID" runat="server">Saad Ahmed</asp:Localize></td>
                </tr>
                <tr>
                <td><asp:Localize ID="locallblUserPasscode" runat="server">Passcode</asp:Localize></td>
                <td><asp:Localize ID="localUserPasscode" runat="server">Saad Ahmed</asp:Localize></td>
                </tr>
                <tr>
                <td><asp:Localize ID="locallblUserDepartment" runat="server">Department</asp:Localize></td>
                <td><asp:Localize ID="localUserDepartment" runat="server">I.T.</asp:Localize></td>
                </tr>
                <tr>
                <td><asp:Localize ID="locallblUserDesignation" runat="server">Designation</asp:Localize></td>
                <td><asp:Localize ID="localUserDesignation" runat="server">Technical Consultant</asp:Localize></td>
                </tr>
                <tr>
                <td><asp:Localize ID="locallblUserLanguage" runat="server">Preferred Language</asp:Localize></td>
                <td><asp:Localize ID="localUserLanguage" runat="server">English</asp:Localize></td>
                </tr>
                <tr>
                <td><asp:Localize ID="locallblUserTheme" runat="server">Preferred Theme</asp:Localize></td>
                <td><asp:Localize ID="localUserTheme" runat="server">Classic</asp:Localize></td>
                </tr>
                <tr>
                <td><asp:Localize ID="locallblUserRegion" runat="server">Region</asp:Localize></td>
                <td><asp:Localize ID="localUserRegion" runat="server">Pakistan</asp:Localize></td>
                </tr>
                <tr>
                <td><asp:Localize ID="locallblUserLastLoginDate" runat="server">Last Login Date</asp:Localize></td>
                <td><asp:Localize ID="localUserLastLoginDate" runat="server">August 5th, 2020</asp:Localize></td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>
