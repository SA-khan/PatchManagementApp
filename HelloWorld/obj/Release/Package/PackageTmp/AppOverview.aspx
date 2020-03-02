<%@ Page Title="Portal - Application Overview" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Live.aspx.cs" Inherits="HelloWorld.Live" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Images/icon.ico" rel="Shortcut Icon" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Table ID="Table1" runat="server" Width="100%" style="border: 1px solid lightgray;padding:2px;background-color:lightgray;">
            <asp:TableRow BackColor="LightGray" >
                    <asp:TableCell ColumnSpan="2" Font-Size="Medium" Font-Italic="false" ForeColor="Black" style="padding-left:10px;padding-right:10px;border-color:Lightgray;">
    
    PRODUCT:   <asp:DropDownList ID="DropProduct" runat="server" BackColor="Gray"
        Width="150px" Height="28px" Font-Italic="true" Font-Size="Medium" Font-Names="Arial" ForeColor="White"
        DataSourceID="SqlDataSourceProduct" DataTextField="ProductName" style="text-align=center"
        DataValueField="ProductID" AutoPostBack="false" ViewStateMode="Enabled" 
        AppendDataBoundItems="True">
        <asp:ListItem Value="0">Select..</asp:ListItem>
        </asp:DropDownList>   

    <asp:SqlDataSource ID="SqlDataSourceProduct" runat="server" 
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

    <asp:TableCell ColumnSpan="2" Font-Size="Medium" Font-Italic="false" ForeColor="Black" style="padding-left:2px;padding-right:1px;">

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
        
        <asp:Button ID="btnSearch" runat="server" Height="28px" Text="SEARCH" 
        onclick="btnSearch_Click" />

    </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    
    <asp:Panel ID="Panel1" runat="server" ScrollBars="None" Height="470px">

    <br/>
    <asp:Table ID="tblInfo" runat="server" Width="100%" GridLines="Both" Font-Size="Medium">
   

    </asp:Table>

    </asp:Panel>

</asp:Content>
