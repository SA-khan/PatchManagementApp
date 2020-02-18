<%@ Page Title="Portal - Login Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HelloWorld.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Images/icon.ico" rel="Shortcut Icon" />
<style>
.btn {
  background-color: DodgerBlue;
  border: none;
  color: white;
  padding: 12px 16px;
  font-size: 16px;
  cursor: pointer;
}

/* Darker background on mouse-over */
.btn:hover {
  background-color: RoyalBlue;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--<asp:Label ID="lblName" runat="server" Text=""></asp:Label>--%>
    <div runat="server" style="min-width:100%;height:100%;min-height:300px;margin:auto;border:1px solid gray;width:100%;float:inherit;background-image:url('\\Images\\loginBG.jpg');">
    <div runat="server" style="min-width:100%;height:100%;min-height:300px;margin:auto;border:1px solid gray;width:100%;opacity:0.8;padding-top:105px;">
    <asp:Table ID="Table1" runat="server" HorizontalAlign="Center" BackColor="Control" BorderColor="ControlDark" BorderStyle="Solid" BorderWidth="1" syle="width:100%;height:100%;min-height:100%;min-width:100%;margin:auto;HorizontalAlign:center;opacity:0.8;margin-top:50px;VerticalAlign:center;">
    <asp:TableHeaderRow BackColor="ActiveCaption" Height="30px">
        <asp:TableHeaderCell ColumnSpan="2" Font-Size="Larger" Font-Names="Arial" ForeColor="Black">
            LOGIN PANEL
        </asp:TableHeaderCell>
    </asp:TableHeaderRow>
    <asp:TableRow>
        <asp:TableCell>
            <label id="lblUserId" title="User ID:" ForeColor="Black" style="Width:200px;font-family:@Arial Unicode MS;font-size:medium;color:Black;">User ID:</label>
        </asp:TableCell>
        <asp:TableCell>
        
        <asp:DropDownList ID="dropUserId" runat="server" Width="200px" 
        Height="28px" DataSourceID="SqlDataSource1" DataTextField="UserID" DataValueField="UserID" AppendDataBoundItems=true>
                   <asp:ListItem>Select UserID</asp:ListItem>
            </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
        SelectCommand="SELECT [UserID] FROM [UsersAuth]"></asp:SqlDataSource> 

        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <label id="lblPassword" title="Password:" ForeColor="Black" style="Width:200px;font-family:@Arial Unicode MS;font-size:medium;color:Black;">Password:</label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="txtPassword" runat="server" Width="196px" Height="25px" TextMode="Password" Font-Size="Large"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
        <asp:TableRow>
        <asp:TableCell>
        </asp:TableCell>
        <asp:TableCell style="margin-top:15px;margin-bottom:15px;">
            <asp:CheckBox ID="checkRemember" runat="server" TextAlign="Right" ForeColor="Black" Font-Italic="true" Text="Remember Me" Font-Size="Small" AutoPostBack="true" Font-Names="Arial" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <%--<asp:TableCell>
        </asp:TableCell>--%>
        <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
            <asp:Button ID="btnSubmit" CssClass=".btn" runat="server" Text="LOGIN" Width="260px" BackColor="#009688" BorderStyle="None" BorderWidth="0" Height="40px" OnClick="Login_Clicked" style="border-radius: 50px;" /><span style="font-size:x-large" class="glyphicon glyphicon-log-in"></span>
            <%--<button ID="btnSubmit" class="btn" runat="server" Width="260px" BackColor="#009688" BorderStyle="None" BorderWidth="0" Height="40px" OnClick="Login_Clicked" style="border-radius: 50px;height:40px;width:260px;border:none;"> LOGIN </button>--%>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server">
        <asp:TableCell>
            <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label ID="lblStatusCode" runat="server" Text=""></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    </asp:Table>
    </div>
    </div>
               
                      
                
</asp:Content>
