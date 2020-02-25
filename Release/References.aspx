<%@ Page Title="Portal - References" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="References.aspx.cs" Inherits="HelloWorld.References" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Images/icon.ico" rel="Shortcut Icon" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblHeading1" runat="server" Text="References & Help" Font-Size=X-Large></asp:Label>
    <br/>
    <ul>
    <asp:Label ID="lblClient1" runat="server" Text="UPDATED DOCUMENTS" Font-Italic=true Font-Size=Large></asp:Label>
    <p>
        <asp:HyperLink ID="HyperLink2" Font-Underline=false runat="server" NavigateUrl="/Resources/Client-Application-Environment-Infrastructure.xlsx" Target="_blank" CssClass="mylink"> Client Application Environment Infrastructure < <b> EXCEL </b> ></asp:HyperLink>
        <br/>
        <br/>
        <asp:HyperLink ID="HyperLink3" Font-Underline=false runat="server" NavigateUrl="/Resources/Pams-3G-Deployment-Guide.docx" Target="_blank" CssClass="mylink">  IPAMS 3G Deployment Guide v1.0 < <b> <span style="font-size:small">DOCX</span> </b> > </asp:HyperLink>
        <asp:Label ID="Label1" runat="server" Text=" | " Font-Bold=true Font-Size=Large></asp:Label>
        <asp:HyperLink ID="HyperLink4" Font-Underline=false runat="server" NavigateUrl="/Resources/Pams-3G-Deployment-Guide.pdf" Target="_blank" CssClass="mylink">  IPAMS 3G Deployment Guide v1.0 < <b> <span style="font-size:small">PDF</span> </b> > </asp:HyperLink>
        <br/>
        <br/>
        <asp:HyperLink ID="HyperLink9" Font-Underline=false runat="server" NavigateUrl="/Resources/Pams-3G-Deployment-Guide-V2.0.docx" Target="_blank" CssClass="mylink">  IPAMS 3G Deployment Guide v2.0 < <b> <span style="font-size:small">DOCX</span> </b> > </asp:HyperLink>
        <asp:Label ID="Label5" runat="server" Text=" | " Font-Bold=true Font-Size=Large></asp:Label>
        <asp:HyperLink ID="HyperLink10" Font-Underline=false runat="server" NavigateUrl="/Resources/Pams-3G-Deployment-Guide-V2.0.pdf" Target="_blank" CssClass="mylink">  IPAMS 3G Deployment Guid v2.0 < <b> <span style="font-size:small">PDF</span> </b> > </asp:HyperLink>
        <br/>
        <br/>
        <asp:HyperLink ID="HyperLink6" Font-Underline=false runat="server" NavigateUrl="/Resources/IPAMS-Functional-Document-v1.0.vsdx" Target="_blank" CssClass="mylink">  IPAMS Functional Document Diagram v1.0 < <b> <span style="font-size:small">VSDX</span> </b> > </asp:HyperLink>
        <asp:Label ID="Label3" runat="server" Text=" | " Font-Bold=true Font-Size=Large></asp:Label>
        <asp:HyperLink ID="HyperLink1" Font-Underline=false runat="server" NavigateUrl="/Resources/IPAMS-Functional-Document-v1.0.pdf" Target="_blank" CssClass="mylink">  IPAMS Functional Document Diagram v1.0 < <b> <span style="font-size:small">PDF</span> </b> > </asp:HyperLink>
                <br/>
        <br/>
        <asp:HyperLink ID="HyperLink7" Font-Underline=false runat="server" NavigateUrl="/Resources/IPAMS-Functional-Document-v2.0.vsdx" Target="_blank" CssClass="mylink">  IPAMS Functional Document Diagram v2.0 < <b> <span style="font-size:small">VSDX</span> </b> > </asp:HyperLink>
        <asp:Label ID="Label4" runat="server" Text=" | " Font-Bold=true Font-Size=Large></asp:Label>
        <asp:HyperLink ID="HyperLink8" Font-Underline=false runat="server" NavigateUrl="/Resources/IPAMS-Functional-Document-v2.0.pdf" Target="_blank" CssClass="mylink">  IPAMS Functional Document Diagram v2.0 < <b> <span style="font-size:small">PDF</span> </b> > </asp:HyperLink>
    </p>
    </ul>

    <ul>
    <hr/>
    <asp:Label ID="Label2" runat="server" Text="ARCHIVES" Font-Italic=true Font-Size=Large></asp:Label>
    <p>
        <asp:HyperLink ID="HyperLink5" Font-Underline=false runat="server" NavigateUrl="/Resources/iPaMs.doc" Target="_blank" CssClass="mylink">  IPAMS 3G Deployment Guide < <b> <span style="font-size:small">DOC</span> </b> > </asp:HyperLink>
    </p>
    </ul>

</asp:Content>
