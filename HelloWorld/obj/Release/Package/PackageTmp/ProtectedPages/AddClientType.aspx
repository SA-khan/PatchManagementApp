﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SiteLogout.Master" AutoEventWireup="true" CodeBehind="AddClientType.aspx.cs" Inherits="HelloWorld.ProtectedPages.AddClientType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<asp:Panel ID="Panel1" runat="server" GroupingText="Add User Role">
       <%-- <asp:Label ID="Label1" runat="server" Text="Add Environment Type"></asp:Label>--%>

       <asp:Table ID="Table1" runat="server" Width="100%" BackColor="Menu" BorderStyle="Solid" BorderColor="DarkGray" BorderWidth="2px" HorizontalAlign="Center" CellSpacing="5" CellPadding="5" style="margin:5px;padding:5px;">
            <asp:TableHeaderRow Height="40px">
                <asp:TableHeaderCell ColumnSpan="3" HorizontalAlign="Left" style="margin:5px;padding:5px;">
                    <asp:Label ID="Label1" runat="server" Text="Add Client Type.." Font-Italic="true" ForeColor="Black" Font-Names="Arial" Font-Size="Large"></asp:Label>
                    <asp:ValidationSummary ID="ValidationSummary1" EnableClientScript="true" DisplayMode="BulletList" HeaderText="Please Enter Following Fields: " ShowMessageBox="true" runat="server" ForeColor="Red" ShowSummary="False" />
                    <br />
                    <br />
                    <asp:Label ID="lblSubmission" runat="server" Text="Client Type is successfully added." Font-Italic="true" ForeColor="Navy" Font-Names="Arial" Font-Size="Medium" Visible="false"></asp:Label>
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow ID="rowCTypeTitle" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblCTypeTitle" runat="server" Text="Client Type Title" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtCTypeTitle" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" placeholder="Enter Client Type Title Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:RequiredFieldValidator ID="ReqCTypeTitle" runat="server" ControlToValidate="txtCTypeTitle" ErrorMessage="Enter Client Type Title." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowCTypeDesc" runat="server">
                <asp:TableCell>
                    <asp:Label ID="lblCTypeDesc" runat="server" Text="User Client Type Description" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtCTypeDesc" CausesValidation="true" runat="server" Width="250px" Height="50px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" TextMode="MultiLine" placeholder="Enter Client Type Description Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="ReqCTypeDesc" runat="server" ControlToValidate="txtCTypeDesc" ErrorMessage="Enter Client Type Description." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
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
