<%@ Page Title="Portal - Add User" Language="C#" MasterPageFile="~/MasterPages/SimpleLogin.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="HelloWorld.ProtectedPages.AddUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Styles/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/modernizr-2.8.3.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" GroupingText="Add User" Font-Size="Large" ForeColor="Navy">
                <div class="container-fluid">
                    <div class="row" id="rowUserName" style="margin-bottom:5px;">
                        <div class="col-sm-4">
                            <asp:Label ID="lblUserName" runat="server" Text="Username" Font-Italic="true" ForeColor="Navy" Font-Size="Medium"></asp:Label>
                        </div>
                        <div class="col-sm-5">
                            <asp:TextBox ID="txtUserName" runat="server" Width="250px" Height="27px" style="border: 1px solid darkgray;background-color:ButtonFace;padding:2px;" ForeColor="Black" Font-Size="Medium" Font-Names="Arial"></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <asp:RequiredFieldValidator ID="ReqUserName" runat="server" ControlToValidate="txtUserName" ErrorMessage="Enter User Name." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row" id="rowUserGroup" style="margin-bottom:5px;">
                        <div class="col-sm-4">
                            <asp:Label ID="lblUserGroup" runat="server" Text="User Group" Font-Italic="true" ForeColor="Navy" Font-Size="Medium"></asp:Label>
                        </div>
                        <div class="col-sm-5">
                            <asp:DropDownList ID="dropUserGroup" runat="server" BackColor="ButtonFace"
                                Width="250px" Height="27px" Font-Italic="true" Font-Size="Medium" Font-Names="Arial" ForeColor="black"
                                DataSourceID="UserGroupSource" DataTextField="USRG_NAME" style="text-align:center;"
                                DataValueField="USRG_ID" AutoPostBack="true" ViewStateMode="Enabled" 
                                AppendDataBoundItems="True">
                                <asp:ListItem>Select..</asp:ListItem>
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="UserGroupSource" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
                                SelectCommand="SELECT [USRG_ID],[USRG_NAME] FROM [USER_GROUP]">
                            </asp:SqlDataSource>
                        </div>
                        <div class="col-sm-3">
                            <asp:RequiredFieldValidator ID="ReqUserGroup" runat="server" InitialValue="Select.." ControlToValidate="dropUserGroup" ErrorMessage="Enter User Group." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row" id="rowUserDesignation" style="margin-bottom:5px;">
                        <div class="col-sm-4">
                            <asp:Label ID="lblUserDesignation" runat="server" Text="User Designation" Font-Italic="true" ForeColor="Navy" Font-Size="Medium"></asp:Label>
                        </div>
                        <div class="col-sm-5">
                            <asp:DropDownList ID="dropUserDesignation" runat="server" BackColor="ButtonFace"
                                Width="250px" Height="27px" Font-Italic="true" Font-Size="Medium" Font-Names="Arial" ForeColor="black"
                                DataSourceID="UserDesignationSource" DataTextField="DESG_NAME" style="text-align:center;"
                                DataValueField="DESG_LVL" AutoPostBack="true" ViewStateMode="Enabled" 
                                AppendDataBoundItems="True">
                                <asp:ListItem>Select..</asp:ListItem>
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="UserDesignationSource" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
                                SelectCommand="SELECT [DESG_LVL],[DESG_NAME] FROM [DESIGNATION]">
                            </asp:SqlDataSource>
                        </div>
                        <div class="col-sm-3">
                            <asp:RequiredFieldValidator ID="RequiredUserDesignation" runat="server" InitialValue="Select.." ControlToValidate="dropUserDesignation" ErrorMessage="Enter User Designation." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row" id="rowUserDepartment" style="margin-bottom:5px;">
                        <div class="col-sm-4">
                            <asp:Label ID="lblUserDepartment" runat="server" Text="User Department" Font-Italic="true" ForeColor="Navy" Font-Size="Medium"></asp:Label>
                        </div>
                        <div class="col-sm-5">
                            <asp:DropDownList ID="dropUserDepartment" runat="server" BackColor="ButtonFace"
                                Width="250px" Height="27px" Font-Italic="true" Font-Size="Medium" Font-Names="Arial" ForeColor="black"
                                DataSourceID="UserDepartmentSource" DataTextField="DEPT_NAME" style="text-align:center;"
                                DataValueField="DEPT_ID" AutoPostBack="true" ViewStateMode="Enabled" 
                                AppendDataBoundItems="True">
                                <asp:ListItem>Select..</asp:ListItem>
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="UserDepartmentSource" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
                                SelectCommand="SELECT [DEPT_ID],[DEPT_NAME] FROM [DEPARTMENT]">
                            </asp:SqlDataSource>
                        </div>
                        <div class="col-sm-3">
                            <asp:RequiredFieldValidator ID="RequiredUserDepartment" runat="server" InitialValue="Select.." ControlToValidate="dropUserDepartment" ErrorMessage="Enter User Department." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row" id="rowPasscode" style="margin-bottom:5px;">
                        <div class="col-sm-4">
                            <asp:Label ID="lblPasscode" runat="server" Text="Enter Password" Font-Italic="true" ForeColor="Navy" Font-Size="Medium"></asp:Label>
                        </div>
                        <div class="col-sm-5">
                            <asp:TextBox ID="txtPasscode" runat="server" TextMode="Password" Width="250px" Height="27px" style="border: 1px solid darkgray;background-color:ButtonFace;padding:2px;" Font-Size="Medium" ForeColor="Black" Font-Names="Arial"></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <asp:RequiredFieldValidator ID="ReqPasscode" runat="server" ControlToValidate="txtPasscode" ErrorMessage="Enter Password." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row" id="rowRePasscode" style="margin-bottom:10px;">
                        <div class="col-sm-4">
                            <asp:Label ID="lblRePasscode" runat="server" Text="Re-Type Password" Font-Italic="true" ForeColor="Navy" Font-Size="Medium"></asp:Label>
                        </div>
                        <div class="col-sm-5">
                            <asp:TextBox ID="txtRePasscode" runat="server" TextMode="Password" Width="250px" BorderStyle="None" style="border: 1px solid darkgray;background-color:ButtonFace;padding:2px;" ForeColor="Black" Font-Names="Arial" Font-Size="Medium"></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <asp:CompareValidator ID="CompRePasscode" ControlToCompare="txtPasscode" ControlToValidate="txtRePasscode" runat="server" ErrorMessage="Passwords didn't mached." ForeColor="Red" Font-Bold="true"></asp:CompareValidator>
                            <asp:RequiredFieldValidator ID="ReqRePasscode" runat="server" ControlToValidate="txtRePasscode" ErrorMessage="Enter ReType Password." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row" id="rowSubmit" style="margin-bottom:5px;">
                        <div class="col-sm-4">
                            <%--<asp:Label ID="Label2" runat="server" Text="Re-Type Password" Font-Italic="true" ForeColor="Navy" Font-Size="Medium"></asp:Label>--%>
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
        <Triggers></Triggers>
    </asp:UpdatePanel>
</asp:Content>
