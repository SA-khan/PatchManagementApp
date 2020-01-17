﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EnvironmentInfo.aspx.cs" Inherits="HelloWorld.EnvironmentInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:Label ID="lblHeading1" runat="server" Text="Client Environment Overview" Font-Size="X-Large"></asp:Label>
    <br/>
    <br/>
    <asp:Table ID="tblInfo" runat="server" Width="100%" GridLines="Both">
    <asp:TableHeaderRow HorizontalAlign="Center" VerticalAlign="Middle">
        <asp:TableCell ColumnSpan="11" HorizontalAlign="Center" ForeColor="Black" VerticalAlign="Middle" Font-Size="Large">
            Client Environment Infrastructure
        </asp:TableCell> 
    </asp:TableHeaderRow>
    <asp:TableRow BackColor="LightGray" HorizontalAlign="Center" VerticalAlign="Middle">
    <asp:TableCell ColumnSpan="11" Font-Size="Medium" Font-Italic="true" ForeColor="Black">
    
    SELECT PRODUCT:   <asp:DropDownList ID="DropDownList1" runat="server" BackColor="Gray"
        Width="200px" Height="28px" Font-Italic="true" Font-Size="Medium" Font-Names="Arial" ForeColor="White"
        DataSourceID="SqlDataSource1" DataTextField="ProductName" style="text-align=center"
        DataValueField="ProductID" AutoPostBack="true" ViewStateMode="Enabled" 
        AppendDataBoundItems="False">
        <asp:ListItem Value="0">Select..</asp:ListItem>
        </asp:DropDownList>   

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
        SelectCommand="SELECT [ProductID],[ProductName] FROM [Products]">

    </asp:SqlDataSource>

    </asp:TableCell>
    </asp:TableRow>


    <asp:TableRow>
        <asp:TableCell BackColor="Aqua" ForeColor="Black" HorizontalAlign="Center" Font-Italic="true" Font-Bold="true">
            Client Name
        </asp:TableCell>
        <asp:TableCell BackColor="Aqua" ForeColor="Black" HorizontalAlign="Center" Font-Bold="true" Font-Italic="true">
            Client Type
        </asp:TableCell>
        <asp:TableCell BackColor="Aqua" ForeColor="Black" HorizontalAlign="Center" Font-Bold="true" Font-Italic="true">
            Environment
        </asp:TableCell>
        <asp:TableCell BackColor="Aqua" ForeColor="Black" HorizontalAlign="Center" Font-Bold="true" Font-Italic="true">
            POC
        </asp:TableCell>
        <asp:TableCell BackColor="Aqua" ForeColor="Black" HorizontalAlign="Center" Font-Bold="true" Font-Italic="true">
            Total Patches
        </asp:TableCell>
        <asp:TableCell BackColor="Aqua" ForeColor="Black" HorizontalAlign="Center" Font-Bold="true" Font-Italic="true">
            Latest Patch #
        </asp:TableCell>
        <asp:TableCell BackColor="Aqua" ForeColor="Black" HorizontalAlign="Center" Font-Bold="true" Font-Italic="true">
            Link
        </asp:TableCell>
        <asp:TableCell BackColor="Aqua" ForeColor="Black" HorizontalAlign="Center" Font-Bold="true" Font-Italic="true">
            QA Tested
        </asp:TableCell>
        <asp:TableCell BackColor="Aqua" ForeColor="Black" HorizontalAlign="Center" Font-Bold="true" Font-Italic="true">
            Deployed Date
        </asp:TableCell>
        <asp:TableCell BackColor="Aqua" ForeColor="Black" HorizontalAlign="Center" Font-Bold="true" Font-Italic="true">
            Duration
        </asp:TableCell>
        <asp:TableCell BackColor="Aqua" ForeColor="Black" HorizontalAlign="Center" Font-Bold="true" Font-Italic="true">
            Status
        </asp:TableCell>
    </asp:TableRow>


<%--
    <asp:TableRow>
        <asp:TableCell>
            FAYSAL AMC
        </asp:TableCell>
        <asp:TableCell>

        </asp:TableCell>
        <asp:TableCell>

        </asp:TableCell>
        <asp:TableCell>

        </asp:TableCell>
        <asp:TableCell>

        </asp:TableCell>
        <asp:TableCell>

        </asp:TableCell>
        <asp:TableCell>

        </asp:TableCell>
        <asp:TableCell>

        </asp:TableCell>
        <asp:TableCell>

        </asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
        <asp:TableCell>
            ALFALAH AMC
        </asp:TableCell>
        <asp:TableCell>
            O.S
        </asp:TableCell>
        <asp:TableCell>
            Web Browser
        </asp:TableCell>
        <asp:TableCell>
            Web Browser Version
        </asp:TableCell>
        <asp:TableCell>
            Database Server
        </asp:TableCell>
        <asp:TableCell>
            File Server Location
        </asp:TableCell>
        <asp:TableCell>
            IP:Port
        </asp:TableCell>
        <asp:TableCell>
            Hot Patch Number
        </asp:TableCell>
        <asp:TableCell>
            Dependency / Comments
        </asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
        <asp:TableCell>
            HBL AMC
        </asp:TableCell>
        <asp:TableCell>
            O.S
        </asp:TableCell>
        <asp:TableCell>
            Web Browser
        </asp:TableCell>
        <asp:TableCell>
            Web Browser Version
        </asp:TableCell>
        <asp:TableCell>
            Database Server
        </asp:TableCell>
        <asp:TableCell>
            File Server Location
        </asp:TableCell>
        <asp:TableCell>
            IP:Port
        </asp:TableCell>
        <asp:TableCell>
            Hot Patch Number
        </asp:TableCell>
        <asp:TableCell>
            Dependency / Comments
        </asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
        <asp:TableCell>
            HBL Bank
        </asp:TableCell>
        <asp:TableCell>
            O.S
        </asp:TableCell>
        <asp:TableCell>
            Web Browser
        </asp:TableCell>
        <asp:TableCell>
            Web Browser Version
        </asp:TableCell>
        <asp:TableCell>
            Database Server
        </asp:TableCell>
        <asp:TableCell>
            File Server Location
        </asp:TableCell>
        <asp:TableCell>
            IP:Port
        </asp:TableCell>
        <asp:TableCell>
            Hot Patch Number
        </asp:TableCell>
        <asp:TableCell>
            Dependency / Comments
        </asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
        <asp:TableCell>
            Jubilee Insurance
        </asp:TableCell>
        <asp:TableCell>
            O.S
        </asp:TableCell>
        <asp:TableCell>
            Web Browser
        </asp:TableCell>
        <asp:TableCell>
            Web Browser Version
        </asp:TableCell>
        <asp:TableCell>
            Database Server
        </asp:TableCell>
        <asp:TableCell>
            File Server Location
        </asp:TableCell>
        <asp:TableCell>
            IP:Port
        </asp:TableCell>
        <asp:TableCell>
            Hot Patch Number
        </asp:TableCell>
        <asp:TableCell>
            Dependency / Comments
        </asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
        <asp:TableCell>
            PAK OMAN
        </asp:TableCell>
        <asp:TableCell>
            O.S
        </asp:TableCell>
        <asp:TableCell>
            Web Browser
        </asp:TableCell>
        <asp:TableCell>
            Web Browser Version
        </asp:TableCell>
        <asp:TableCell>
            Database Server
        </asp:TableCell>
        <asp:TableCell>
            File Server Location
        </asp:TableCell>
        <asp:TableCell>
            IP:Port
        </asp:TableCell>
        <asp:TableCell>
            Hot Patch Number
        </asp:TableCell>
        <asp:TableCell>
            Dependency / Comments
        </asp:TableCell>
    </asp:TableRow>

    <asp:TableFooterRow>
    <asp:TableCell ColumnSpan="9">---</asp:TableCell>
    </asp:TableFooterRow>

--%>

    </asp:Table>

    

</asp:Content>
