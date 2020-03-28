<%@ Page Title="Portal - Environmnet Overview" Language="C#" MasterPageFile="~/MasterPages/Layer1.Master" AutoEventWireup="true" CodeBehind="EnvironmentInfo.aspx.cs" Inherits="HelloWorld.EnvironmentInfo" EnableTheming = "False" StylesheetTheme="" Theme=""  %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server" runat="server">
      <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
  <script>
      $(function () {
          $("#dialog").dialog({
              autoOpen: false,
              show: {
                  effect: "blind",
                  duration: 1000
              },
              hide: {
                  effect: "explode",
                  duration: 1000
              }
          });

          $("#opener").on("click", function () {
              $("#dialog").dialog("open");
          });
      });
  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
    <br/>
    <div class="card" style="width:100%" style="margin-top:5px;">
        <asp:Table ID="Table1" runat="server" Width="100%" style="border: 1px solid lightgray;padding:2px;background-color:lightgray;margin-top:5px;">
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

    <asp:Panel ID="Panel2" runat="server">

    <asp:Table ID="tblInfo" runat="server" Width="100%" GridLines="Both">
<%--    <asp:TableHeaderRow HorizontalAlign="Center" VerticalAlign="Middle">
        <asp:TableCell ColumnSpan="8" HorizontalAlign="Center" ForeColor="Black" VerticalAlign="Middle" Font-Size="Large">
            Client Environment Infrastructure
        </asp:TableCell> 
    </asp:TableHeaderRow>--%>
    <asp:TableRow BackColor="LightGray" HorizontalAlign="Center" VerticalAlign="Middle">


    </asp:TableRow>


    <asp:TableRow>
        <asp:TableCell ID="totalRecords" ColumnSpan="8" BackColor="lightgray" ForeColor="Black" HorizontalAlign="Left" Font-Italic="true" Font-Bold="false" style="padding:5px;">
            
        </asp:TableCell>
    </asp:TableRow>

    </asp:Table>

    </asp:Panel>

  </div>

    <asp:Panel ID="Panel1" runat="server" style="padding:10px;">


    </asp:Panel>

    

</asp:Content>
