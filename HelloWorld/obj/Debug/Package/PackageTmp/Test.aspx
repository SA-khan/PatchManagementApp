<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="HelloWorld.Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblHeading1" runat="server" Text="Test Environment" Font-Size=X-Large></asp:Label>
    <br/>
    <ul>
    <asp:Label ID="lblClient1" runat="server" Text="FAYSAL AMC" Font-Size=Large></asp:Label>
    <p>
        <asp:HyperLink ID="HyperLink1" Font-Underline=false runat="server" NavigateUrl="http://AAK183:81" Target="_blank" CssClass="mylink"> Faysal AMC pams 3G Link</asp:HyperLink>
        <br/>
        <asp:HyperLink ID="HyperLink2" Font-Underline=false runat="server" NavigateUrl="http://AAK183:82" Target="_blank" CssClass="mylink"> Faysal AMC pams 4G Link</asp:HyperLink>
    </p>
    </ul>
</asp:Content>
