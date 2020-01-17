<%@ Page Title="" Language="C#" MasterPageFile="~/SiteLogout.Master" AutoEventWireup="true" CodeBehind="EditCompanyInfo.aspx.cs" Inherits="HelloWorld.ProtectedPages.EditCompanyInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
             <asp:GridView ID="GridView1" runat="server">

             </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
