<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HelloWorld.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--<asp:Label ID="lblName" runat="server" Text=""></asp:Label>--%>
    <div runat="server" style="width:100%;padding:both;margin:both;">
    <div runat="server" style="margin:auto;">
    <asp:Table ID="Table1" runat="server" BackColor="Control" BorderColor="ControlDark" BorderStyle="Solid" BorderWidth="1" syle="width:100%;margin:auto;">
    <asp:TableHeaderRow BackColor="ActiveCaption" Height="30px">
        <asp:TableHeaderCell ColumnSpan="2" Font-Size="Larger" Font-Names="Arial">
            LOGIN PANEL
        </asp:TableHeaderCell>
    </asp:TableHeaderRow>
    <asp:TableRow>
        <asp:TableCell>
            <label id="lblUserId" title="User ID:" style="Width:200px;font-family:@Arial Unicode MS;font-size:medium">User ID:</label>
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
            <label id="lblPassword" title="Password:" style="Width:200px;font-family:@Arial Unicode MS;font-size:medium">Password:</label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="txtPassword" runat="server" Width="196px" Height="25px" TextMode="Password" Font-Size="Large"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
        <asp:TableRow>
        <asp:TableCell>
        </asp:TableCell>
        <asp:TableCell>
            <asp:CheckBox ID="checkRemember" runat="server" TextAlign="Right" Text="Remember Me" Font-Size="Medium" Font-Names="Arial" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Button ID="btnSubmit" runat="server" Text="LOGIN" OnClick="Login_Clicked" />
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
