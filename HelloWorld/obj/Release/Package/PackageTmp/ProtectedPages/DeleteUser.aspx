<%@ Page Title="Portal - Delete User" Language="C#" MasterPageFile="~/MasterPages/SimpleLogin.Master" AutoEventWireup="true" CodeBehind="DeleteUser.aspx.cs" Inherits="HelloWorld.ProtectedPages.DeleteUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel ID="Panel1" runat="server">
        <asp:Table ID="Table1" runat="server" Width="100%" BackColor="Menu" BorderStyle="Solid" BorderColor="DarkGray" BorderWidth="2px" HorizontalAlign="Center" CellSpacing="5" CellPadding="5" style="margin:5px;padding:5px;">
            <asp:TableHeaderRow Height="40px">
                <asp:TableHeaderCell ColumnSpan="3" HorizontalAlign="Left" style="margin:5px;padding:5px;">
                    <asp:Label ID="Label1" runat="server" Text="Remove A Client.." Font-Italic="true" ForeColor="Black" Font-Names="Arial" Font-Size="Large"></asp:Label>
                    <asp:ValidationSummary ID="ValidationSummary1" EnableClientScript="true" DisplayMode="BulletList" HeaderText="Please Enter Following Fields: " ShowMessageBox="true" runat="server" ForeColor="Red" ShowSummary="False" />
                    <br />
                    <br />
                    <asp:Label ID="lblSubmission" runat="server" Text="Client is successfully deleted." Font-Italic="true" ForeColor="Navy" Font-Names="Arial" Font-Size="Medium" Visible="false"></asp:Label>
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow ID="rowUser" runat="server">
                <asp:TableCell>
                    <asp:Label ID="lblPatchClientName" runat="server" Text="User Name" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <%--<asp:TextBox ID="txtPatchClientName" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" placeholder="Enter Patch Client Name Here"></asp:TextBox>--%>
                    <asp:DropDownList ID="dropUser" runat="server" BackColor="ButtonFace"
        Width="250px" Height="27px" Font-Italic="true" Font-Size="Medium" Font-Names="Arial" ForeColor="black"
        DataSourceID="SqlDataSource1" DataTextField="USER_NAME" style="text-align=center"
        DataValueField="USER_ID" AutoPostBack="false" ViewStateMode="Enabled" 
        AppendDataBoundItems="True">
        <asp:ListItem>Select..</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
        SelectCommand="SELECT [USER_ID],[USER_NAME] FROM [USER]"></asp:SqlDataSource>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="ReqPatchClientName" runat="server" InitialValue="Select.." ControlToValidate="dropUser"  ErrorMessage="Please Select User" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow ID="rowSubmit" runat="server">
                <asp:TableCell>
                    
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="btnDelete" runat="server" Text="DELETE" Width="70px" 
        Height="30px" style="margin:5px;padding:5px;" onclick="btnDelete_Click" />
                    <asp:Button ID="btnClear" runat="server" Text="CLEAR" 
        Width="70px" Height="30px" style="margin:5px;padding:5px;" 
        onclick="btnClear_Click" />
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
