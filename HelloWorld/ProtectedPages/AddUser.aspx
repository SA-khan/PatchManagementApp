<%@ Page Title="" Language="C#" MasterPageFile="~/SiteLogout.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="HelloWorld.ProtectedPages.AddUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server" GroupingText="Add User">
       <%-- <asp:Label ID="Label1" runat="server" Text="Add Environment Type"></asp:Label>--%>

       <asp:Table ID="Table1" runat="server" Width="100%" BackColor="Menu" BorderStyle="Solid" BorderColor="DarkGray" BorderWidth="2px" HorizontalAlign="Center" CellSpacing="5" CellPadding="5" style="margin:5px;padding:5px;">
            <asp:TableHeaderRow Height="40px">
                <asp:TableHeaderCell ColumnSpan="3" HorizontalAlign="Left" style="margin:5px;padding:5px;">
                    <asp:Label ID="Label1" runat="server" Text="Add A User.." Font-Italic="true" ForeColor="Black" Font-Names="Arial" Font-Size="Large"></asp:Label>
                    <asp:ValidationSummary ID="ValidationSummary1" EnableClientScript="true" DisplayMode="BulletList" HeaderText="Please Enter Following Fields: " ShowMessageBox="true" runat="server" ForeColor="Red" ShowSummary="False" />
                    <br />
                    <br />
                    <asp:Label ID="lblSubmission" runat="server" Text="User is successfully added." Font-Italic="true" ForeColor="Navy" Font-Names="Arial" Font-Size="Medium" Visible="false"></asp:Label>
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow ID="rowUserName" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblUserName" runat="server" Text="Username" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtUserName" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" placeholder=" Enter Username Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:RequiredFieldValidator ID="ReqUserName" runat="server" ControlToValidate="txtUserName" ErrorMessage="Enter User Name." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
           
            <asp:TableRow ID="rowUserRole" runat="server">
                <asp:TableCell>
                    <asp:Label ID="lblUserRole" runat="server" Text="User Role" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="dropUserRole" runat="server" BackColor="ButtonFace"
        Width="250px" Height="27px" Font-Italic="true" Font-Size="Medium" Font-Names="Arial" ForeColor="black"
        DataSourceID="SqlDataSource1" DataTextField="ROLE_TITLE" style="text-align=center"
        DataValueField="ROLE_ID" AutoPostBack="true" ViewStateMode="Enabled" 
        AppendDataBoundItems="True">
        <asp:ListItem>Select..</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
        SelectCommand="SELECT [ROLE_ID],[ROLE_TITLE] FROM [ROLES]"></asp:SqlDataSource>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="ReqUserRole" runat="server" InitialValue="Select.." ControlToValidate="dropUserRole" ErrorMessage="Enter User Role." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowPasscode" runat="server">
                <asp:TableCell>
                    <asp:Label ID="lblPasscode" runat="server" Text="Enter Password" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtPasscode" runat="server" TextMode="Password" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" placeholder=" Enter Password Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="ReqPasscode" runat="server" ControlToValidate="txtPasscode" ErrorMessage="Enter Password." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowRePasscode" runat="server">
                <asp:TableCell>
                    <asp:Label ID="lblRePasscode" runat="server" Text="ReType Password" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtRePasscode" runat="server" TextMode="Password" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" placeholder=" Enter Product Type Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:CompareValidator ID="CompRePasscode" ControlToCompare="txtPasscode" ControlToValidate="txtRePasscode" runat="server" ErrorMessage="Passwords didn't mached." ForeColor="Red" Font-Bold="true"></asp:CompareValidator>
                    <asp:RequiredFieldValidator ID="ReqRePasscode" runat="server" ControlToValidate="txtRePasscode" ErrorMessage="Enter ReType Password." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowSubmit" runat="server">
                <asp:TableCell>
                    
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="btnSave" runat="server" Text="SAVE" Width="70px" Height="30px" style="margin:5px;padding:5px;" onclick="btnSave_Click" />
                    <asp:Button ID="btnClear" runat="server" Text="CLEAR" Width="70px" Height="30px" style="margin:5px;padding:5px;" onclick="btnClear_Click" />
                </asp:TableCell>
                <asp:TableCell>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" InitialValue="*" ControlToValidate="txtClientName" Display="Dynamic" EnableClientScript="true" Text="Please Enter Client Name"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <br />

    </asp:Panel>



</asp:Content>
