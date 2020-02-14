<%@ Page Title="Portal - Environmnet Overview" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EnvironmentInfo.aspx.cs" Inherits="HelloWorld.EnvironmentInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:Label ID="lblHeading1" runat="server" Text="Client Environment Overview" Font-Size="X-Large"></asp:Label>
    <br/>
    <br/>

    <div class="card" style="width:100%">

        
        

        <asp:Table ID="Table1" runat="server" Width="100%" style="border: 1px solid lightgray;padding:2px;background-color:lightgray;">
            <asp:TableRow BackColor="LightGray" >
                    <asp:TableCell ColumnSpan="2" Font-Size="Medium" Font-Italic="false" ForeColor="Black" style="padding-left:10px;padding-right:10px;border-color:Lightgray;">
    
    PRODUCT:   <asp:DropDownList ID="DropDownList1" runat="server" BackColor="Gray"
        Width="150px" Height="28px" Font-Italic="true" Font-Size="Medium" Font-Names="Arial" ForeColor="White"
        DataSourceID="SqlDataSource1" DataTextField="ProductName" style="text-align=center"
        DataValueField="ProductID" AutoPostBack="false" ViewStateMode="Enabled" 
        AppendDataBoundItems="True">
        <asp:ListItem Value="0">Select..</asp:ListItem>
        </asp:DropDownList>   

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
        SelectCommand="SELECT [ProductID],[ProductName] FROM [Products]">
    </asp:SqlDataSource>

    </asp:TableCell>

    <asp:TableCell ColumnSpan="2" Font-Size="Medium" Font-Italic="false" ForeColor="Black" style="padding-left:10px;padding-right:10px;">

     ENVIRONMENT:   <asp:DropDownList ID="DropEnvType" runat="server" BackColor="Gray"
        Width="150px" Height="28px" Font-Italic="True" Font-Size="Medium" 
        Font-Names="Arial" ForeColor="White" style="text-align=center" ViewStateMode="Enabled" 
        AppendDataBoundItems="True" DataSourceID="SqlDataSourceEnv" 
        DataTextField="EnvTitle" DataValueField="EnvID">
        <asp:ListItem Value=0>Select..</asp:ListItem>
        </asp:DropDownList> 
    

    <asp:SqlDataSource ID="SqlDataSourceEnv" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
        SelectCommand="SELECT [EnvID],[EnvTitle] FROM [EnvironmentType]">
    </asp:SqlDataSource>

    </asp:TableCell>

    <asp:TableCell ColumnSpan="2" Font-Size="Medium" Font-Italic="false" ForeColor="Black" style="padding-left:10px;padding-right:10px;">

        <span style="font-family:Arial;">CLIENT:</span> <asp:DropDownList ID="DropClientID" runat="server" BackColor="Gray"
        Width="150px" Height="28px" Font-Italic="True" Font-Size="Medium" 
        Font-Names="Arial" ForeColor="White"
         style="text-align=center"
          ViewStateMode="Enabled" 
        AppendDataBoundItems="True" DataSourceID="SqlDataSourceClient" 
        DataTextField="ClientName" DataValueField="ClientID">
        <asp:ListItem Value="0">Select..</asp:ListItem>
        </asp:DropDownList>  

    <asp:SqlDataSource ID="SqlDataSourceClient" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
        SelectCommand="SELECT [ClientID], [ClientName] FROM [ClientDetail]">
    </asp:SqlDataSource>

    

    </asp:TableCell>

    <asp:TableCell ColumnSpan="2" HorizontalAlign="Right" Font-Size="Medium" Font-Italic="true" ForeColor="Black">
        
        <asp:Button ID="Button1" runat="server" Height="28px" Text="SEARCH" onclick="Button1_Click" />

    </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

    <asp:Panel ID="Panel2" runat="server" Height="370px" ScrollBars="Vertical">

    <asp:Table ID="tblInfo" runat="server" Width="100%" GridLines="Both">
<%--    <asp:TableHeaderRow HorizontalAlign="Center" VerticalAlign="Middle">
        <asp:TableCell ColumnSpan="8" HorizontalAlign="Center" ForeColor="Black" VerticalAlign="Middle" Font-Size="Large">
            Client Environment Infrastructure
        </asp:TableCell> 
    </asp:TableHeaderRow>--%>
    <asp:TableRow BackColor="LightGray" HorizontalAlign="Center" VerticalAlign="Middle">


    </asp:TableRow>


    <asp:TableRow>
        <asp:TableCell ID="totalRecords" ColumnSpan="8" BackColor="Aqua" ForeColor="Black" HorizontalAlign="Left" Font-Italic="true" Font-Bold="false" style="padding:5px;">
            
        </asp:TableCell>
<%--        <asp:TableCell BackColor="Aqua" ForeColor="Black" HorizontalAlign="Center" Font-Bold="true" Font-Italic="true">
            Environment Type
        </asp:TableCell>
        <asp:TableCell BackColor="Aqua" ForeColor="Black" HorizontalAlign="Center" Font-Bold="true" Font-Italic="true">
            Operating System
        </asp:TableCell>
        <asp:TableCell BackColor="Aqua" ForeColor="Black" HorizontalAlign="Center" Font-Bold="true" Font-Italic="true">
            App Server Memory
        </asp:TableCell>
        <asp:TableCell BackColor="Aqua" ForeColor="Black" HorizontalAlign="Center" Font-Bold="true" Font-Italic="true">
            App Server Processor
        </asp:TableCell>
        <asp:TableCell BackColor="Aqua" ForeColor="Black" HorizontalAlign="Center" Font-Bold="true" Font-Italic="true">
            App Server Memory
        </asp:TableCell>
        <asp:TableCell BackColor="Aqua" ForeColor="Black" HorizontalAlign="Center" Font-Bold="true" Font-Italic="true">
            DB Server Processor
        </asp:TableCell>
        <asp:TableCell BackColor="Aqua" ForeColor="Black" HorizontalAlign="Center" Font-Bold="true" Font-Italic="true">
            DB Server Memory
        </asp:TableCell>
        <asp:TableCell BackColor="Aqua" ForeColor="Black" HorizontalAlign="Center" Font-Bold="true" Font-Italic="true">
            Web Browser 
        </asp:TableCell>
        <asp:TableCell BackColor="Aqua" ForeColor="Black" HorizontalAlign="Center" Font-Bold="true" Font-Italic="true">
            Web Browser Version
        </asp:TableCell>
        <asp:TableCell BackColor="Aqua" ForeColor="Black" HorizontalAlign="Center" Font-Bold="true" Font-Italic="true">
            Status
        </asp:TableCell>--%>
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

    </asp:Panel>

  </div>

    <asp:Panel ID="Panel1" runat="server" style="padding:10px;">


    </asp:Panel>

    

</asp:Content>
