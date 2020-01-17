<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="HelloWorld._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to the Portal..
    </h2>
    <p>
        This Portal will help you find bugs in Live Applications deployed on this Portal through there specific releases through there specific Links and Let the SQA diagnose issues occured on Multiple Sites.
    </p>
<p>
        <asp:Button ID="Button1" Visible="false" runat="server" onclick="Button1_Click" Text="Goto Login" />
    </p>

</asp:Content>
