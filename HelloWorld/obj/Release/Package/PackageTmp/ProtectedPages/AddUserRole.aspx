<%@ Page Title="Portal - Add User Role" Language="C#" MasterPageFile="~/MasterPages/SimpleLogin.Master" AutoEventWireup="true" CodeBehind="AddUserRole.aspx.cs" Inherits="HelloWorld.ProtectedPages.AddUserRole" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Styles/bootstrap.min.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="Panel1" runat="server" GroupingText="Add User Role" Font-Size="Large" ForeColor="Navy">
                    <div class="container-fluid">
                      <div class="row" id="rowRoleTitle" style="margin-bottom:5px;">
                        <div class="col-sm-4">
                            <asp:Label ID="lblUserRole" runat="server" Text="Role Title" Font-Italic="true" ForeColor="Navy" Font-Size="Medium"></asp:Label>
                        </div>
                        <div class="col-sm-5">
                            <asp:TextBox ID="txtRoleTitle" runat="server" Width="250px" Height="27px" style="border: 1px solid darkgray;background-color:ButtonFace;padding:2px;" ForeColor="Black" Font-Size="Medium" Font-Names="Arial"></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <asp:RequiredFieldValidator ID="ReqRoleTitle" runat="server" ControlToValidate="txtRoleTitle" ErrorMessage="Enter User Role Title." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                        </div>
                      </div>
                      <div class="row" id="rowRoleDesc" style="margin-bottom:5px;">
                        <div class="col-sm-4">
                            <asp:Label ID="lblRoleDesc" runat="server" Text="Role Description" Font-Italic="true" ForeColor="Navy" Font-Size="Medium"></asp:Label>
                        </div>
                        <div class="col-sm-5">
                            <asp:TextBox ID="txtRoleDesc" CausesValidation="true" runat="server" Width="250px" Height="50px" style="border: 1px solid darkgray;background-color:ButtonFace;padding:2px;" ForeColor="Black" Font-Size="Medium" Font-Names="Arial" TextMode="MultiLine" ></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <asp:RequiredFieldValidator ID="ReqRoleDesc" runat="server" ControlToValidate="txtRoleDesc" ErrorMessage="Enter User Role Description." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                        </div>
                      </div>
                      <div class="row" id="rowSubmit" style="margin-bottom:5px;">
                        <div class="col-sm-4">
                        </div>
                        <div class="col-sm-5">
                            <asp:Button ID="btnSave" runat="server" CssClass="btn-danger" Text="SAVE" Width="70px" Height="35px" onclick="btnSave_Click" />
                            <asp:Button ID="btnClear" runat="server" CssClass="btn-danger" Text="CLEAR" Width="70px" Height="35px" onclick="btnClear_Click" />
                        </div>
                        <div class="col-sm-3">
                        </div>
                      </div>
                    </div>
                    <br />
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
