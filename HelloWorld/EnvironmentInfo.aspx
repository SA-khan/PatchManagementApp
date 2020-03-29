<%@ Page Title="Portal - Environmnet Overview" Language="C#" MasterPageFile="~/MasterPages/Layer1.Master" AutoEventWireup="true" CodeBehind="EnvironmentInfo.aspx.cs" Inherits="HelloWorld.EnvironmentInfo"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
      <meta name="viewport" content="width=device-width, initial-scale=1" />
      <script src="Scripts/jquery-3.4.1.min.js" type="text/javascript"></script>
      <style>
        .row-centered {
            text-align:center;
        }
        .col-centered {
            display:inline-block;
            float:none;
            /* reset the text-align */
            text-align:left;
            /* inline-block space fix */
            margin-right:-4px;
            text-align: center;
        .categories{
              font-size: 13px;
              padding: 10px 8px 10px 14px;
              background: #fff;
              border: 1px solid #ccc;
              border-radius: 6px;
              position: relative;
            }
        }
      </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
    <br/>
    <br/>
    <div class="card" style="width:100%;margin-top:5px;">
        <div class="container-fluid" style="margin-top:8px;margin-bottom:3px;margin-left:5px;margin-right:5px;">
          <div class="row row-centered">
            <div id="ProductFilter" class="col-sm-4 col-centered">
                <asp:DropDownList ID="DropDownList1" Height="25" runat="server" class="categories" DataSourceID="srcProduct" DataTextField="ProductName" style="text-align:center" DataValueField="ProductID" AutoPostBack="True" ViewStateMode="Enabled" AppendDataBoundItems="True">
                                  <asp:ListItem Value="0">Select Product..</asp:ListItem>
                </asp:DropDownList>   
                <asp:SqlDataSource ID="srcProduct" runat="server" ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" SelectCommand="SELECT [ProductID],[ProductName] FROM [Products]"> </asp:SqlDataSource>
            </div>
            <div id="EnvironmentFilter" class="col-sm-4 col-centered">
                <asp:DropDownList ID="DropEnvType" runat="server" Height="25" CssClass="selectpicker" AutoPostBack="true" ViewStateMode="Enabled" AppendDataBoundItems="True" DataSourceID="SqlDataSourceEnv" DataTextField="EnvTitle" DataValueField="EnvID">
                                  <asp:ListItem Value=0>Select Environment..</asp:ListItem>
                </asp:DropDownList> 
                <asp:SqlDataSource ID="SqlDataSourceEnv" runat="server" ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" SelectCommand="SELECT [EnvID],[EnvTitle] FROM [EnvironmentType]"> </asp:SqlDataSource>
            </div>
            <div id="ClientFilter" class="col-sm-4 col-centered">
                <asp:DropDownList ID="DropClientID" runat="server" Height="25" AutoPostBack="true" ViewStateMode="Enabled" AppendDataBoundItems="True" DataSourceID="SqlDataSourceClient" DataTextField="ClientName" DataValueField="ClientID">
                                    <asp:ListItem Value="0">Select Client..</asp:ListItem>
                </asp:DropDownList>  
                <asp:SqlDataSource ID="SqlDataSourceClient" runat="server" ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" SelectCommand="SELECT [ClientID], [ClientName] FROM [ClientDetail]"> </asp:SqlDataSource>
                <%--<asp:Button ID="Button1" runat="server" Height="28px" Text="SEARCH" onclick="Button1_Click" />--%>
            </div>
          </div>
          <div class="row row-centered" style="margin-top:3px;margin-bottom:3px;">
            <div id="DivTallyRecords" class="col-sm-12 text-left">
            <span id="TallyRecords" runat="server"></span>
            </div>
          </div>
        </div>
        <asp:Panel ID="Panel2" runat="server">
            <asp:Table ID="tblInfo" runat="server" Width="99%" GridLines="Both">
                <%--    <asp:TableRow BackColor="LightGray" HorizontalAlign="Center" VerticalAlign="Middle">
                    </asp:TableRow>--%>
                    <%--<asp:TableRow>
                        <asp:TableCell ID="totalRecords" ColumnSpan="8" BackColor="lightgray" ForeColor="Black" HorizontalAlign="Left" Font-Italic="true" Font-Bold="false" style="padding:5px;"> </asp:TableCell>
                    </asp:TableRow>--%>
                </asp:Table>
        </asp:Panel>
  </div>

    <asp:Panel ID="Panel1" runat="server" style="padding:10px;">


    </asp:Panel>

    

</asp:Content>
