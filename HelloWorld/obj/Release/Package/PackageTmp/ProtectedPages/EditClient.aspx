<%@ Page Title="Edit Client - Portal" Language="C#" MasterPageFile="~/MasterPages/SimpleLogin.Master" AutoEventWireup="true" CodeBehind="EditClient.aspx.cs" Inherits="HelloWorld.ProtectedPages.EditClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Styles/bootstrap.min.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Width="100%" Height="460px" style="padding:5px;">

    <asp:DetailsView ID="DetailsView1" CssClass="accordionView" runat="server" 
        Height="50px" Width="40%" 
        AutoGenerateRows="False" BackColor="White" BorderColor="#CCCCCC" OnRowCommand="GridView1_RowCommand"
        BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        onpageindexchanging="DetailsView1_PageIndexChanging" 
        ondatabound="DetailsView1_DataBound">
        <EditRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <Fields>
            <asp:TemplateField HeaderText="Client ID" SortExpression="ClientID">
                <ItemTemplate>
                    <asp:TextBox ID="txtClientID" runat="server" Enabled="false" Text='<%# Bind("ClientID") %>' EnableViewState="true" ViewStateMode="Enabled"></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtClientID" runat="server" Text='<%# Bind("ClientID") %>'></asp:TextBox>
                </EditItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtClientID" runat="server" Text='<%# Bind("ClientID") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtClientID" runat="server" Text='<%# Bind("ClientID") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Client Name" SortExpression="ClientName">
                <ItemTemplate>
                    <asp:TextBox ID="txtClientName" runat="server" Text='<%# Bind("ClientName") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtClientName" runat="server" Text='<%# Bind("ClientName") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtClientName" runat="server" Text='<%# Bind("ClientName") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Client Type" SortExpression="ClientName">
                <ItemTemplate>
                    <asp:HiddenField ID="hidClientType" runat="server" Value='<%# Bind("ClientType") %>' />
                    <asp:DropDownList ID="dropClientType" runat="server" AppendDataBoundItems="true"  DataSourceID="SqlDataSourceCType" DataTextField="CTYPE_TITLE" DataValueField="CTYPE_TITLE" SelectedValue='<%# Bind("ClientType") %>'>
                        <asp:ListItem>Select..</asp:ListItem>
                    </asp:DropDownList>
                    <%--DataValueField='<%# Bind("ClientType")DataTextField='<%# Bind("ClientType") %>' %>' DataTextFormatString='<%# Bind("ClientType") %>'--%>
                    <asp:SqlDataSource ID="SqlDataSourceCType" runat="server" ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" SelectCommand="SELECT [CTYPE_ID], [CTYPE_TITLE] FROM [CLIENT_TYPE]">
                    </asp:SqlDataSource>
                </ItemTemplate>
                <%--<EditItemTemplate>
                    <asp:TextBox ID="txtClientType" runat="server" Text='<%# Bind("ClientType") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <%--                <InsertItemTemplate>
                    <asp:TextBox ID="txtClientType" runat="server" Text='<%# Bind("ClientType") %>'></asp:TextBox>
                </InsertItemTemplate>--%></asp:TemplateField>
            <asp:TemplateField HeaderText="ClientDesc" SortExpression="ClientName">
                <ItemTemplate>
                    <asp:TextBox ID="txtClientDesc" runat="server" Text='<%# Bind("ClientDesc") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtClientDesc" runat="server" Text='<%# Bind("ClientDesc") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtClientDesc" runat="server" Text='<%# Bind("ClientDesc") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Current Client" 
                SortExpression="ClientName">
                <ItemTemplate>
                    <asp:CheckBox ID="chkClientStill" runat="server" 
                        Checked='<%# Bind("ClientStill") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:CheckBox ID="chkClientStill" runat="server" 
                        Checked='<%# Bind("ClientStill") %>' />
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:CheckBox ID="chkClientStill" runat="server" 
                        Checked='<%# Bind("ClientStill") %>' />
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Client Person of Contact" 
                SortExpression="ClientName">
                <ItemTemplate>
                    <asp:TextBox ID="txtPOCName" runat="server" 
                        Text='<%# Bind("POCName") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtPOCName" runat="server" 
                        Text='<%# Bind("POCName") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtPOCName" runat="server" 
                        Text='<%# Bind("POCName") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Client POC Email" 
                SortExpression="ClientName">
                <ItemTemplate>
                    <asp:TextBox ID="txtPOCEmail" runat="server" 
                        Text='<%# Bind("POCEmail") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtPOCEmail" runat="server" 
                        Text='<%# Bind("POCEmail") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtPOCEmail" runat="server" 
                        Text='<%# Bind("POCEmail") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Client POC Phone" 
                SortExpression="ClientName">
                <ItemTemplate>
                    <asp:TextBox ID="txtPOCPhone" runat="server" 
                        Text='<%# Bind("POCPhone") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtPOCPhone" runat="server" 
                        Text='<%# Bind("POCPhone") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtPOCPhone" runat="server" 
                        Text='<%# Bind("POCPhone") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Button ID="btnSave" runat="server" CausesValidation="false" 
                        Text="Save" onclick="btnSave_Click" />
                    <asp:Button ID="btnCancel" runat="server" CssClass="accordionButton" CausesValidation="false" 
                        Text="Cancel" onclick="btnCancel_Click" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:TemplateField>
        </Fields>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
    </asp:DetailsView>
    <br/>
    <div style="overflow-x:auto;width:1500px;padding:5px;margin:5px;">
    <asp:GridView ID="GridView1" Width="100%" runat="server" DataKeyNames="_clientName"
        style="min-height:300px;margin:5px;padding:5px;elevation:higher;"
        AllowPaging="true"
        AutoGenerateColumns="false" AllowSorting="true"
        AlternatingRowStyle-BackColor="LightGray" BorderColor="ControlDark" 
        BorderStyle="Solid" BorderWidth="1" EditRowStyle-Font-Names="Comic" 
        EditRowStyle-Font-Size="Small" EditRowStyle-ForeColor="Black" 
        Font-Names="Comic" Font-Size="Small" Font-Bold="false" GridLines="Both" 
        HeaderStyle-BackColor="Aqua" HeaderStyle-Font-Names="Comic" ForeColor="Black" 
        HeaderStyle-Font-Size="Medium" HeaderStyle-Font-Bold="false" 
        HeaderStyle-Font-Italic="true" HeaderStyle-Font-Underline="false" 
        HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" 
        HorizontalAlign="Right" RowStyle-HorizontalAlign="Right" PagerSettings-Mode="NumericFirstLast" PagerStyle-HorizontalAlign="Left"
        RowStyle-VerticalAlign="Middle" SelectedRowStyle-BackColor="DarkGray" UseAccessibleHeader="true"
        SelectedRowStyle-Font-Bold="true" SelectedRowStyle-Font-Size="Small" 
        SelectedRowStyle-Height="24px" onrowediting="GridView1_RowEditing" 
        onrowupdating="GridView1_RowUpdating" 
        onpageindexchanging="GridView1_PageIndexChanging"  overflow="scroll"
        onrowcancelingedit="GridView1_RowCancelingEdit" 
        onselectedindexchanged="GridView1_SelectedIndexChanged" PageSize="6">
        <Columns>
            <asp:TemplateField Visible="false" HeaderText="Client ID">
                <ItemTemplate>
                    <asp:Label ID="lblClientID" runat="server" 
                 Text='<%# Eval("_clientID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Client Logo" ItemStyle-CssClass="mylogo" HeaderStyle-Width="150" HeaderStyle-Height="45" ControlStyle-Height="35" ItemStyle-VerticalAlign="Middle">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl="../Images/release.png" Width="100%" Height="100%" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Client Name" HeaderStyle-Width="200" HeaderStyle-Height="45" ControlStyle-Height="35" ItemStyle-VerticalAlign="Middle">
                <ItemTemplate>
                    <asp:Label ID="lblClientName" runat="server" 
                 Text='<%# Eval("_clientName") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Client Type" HeaderStyle-Height="45" ControlStyle-Width="100" ControlStyle-Height="35" ItemStyle-VerticalAlign="Middle">
                <ItemTemplate>
                    <asp:Label ID="lblClientType" runat="server" 
                 Text='<%# Eval("_clientType") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Client Description" HeaderStyle-Height="45" ControlStyle-Width="300" ControlStyle-Height="35" ItemStyle-VerticalAlign="Middle">
                <ItemTemplate>
                    <asp:Label ID="lblClientDesc" runat="server" 
                 Text='<%# Eval("_clientDesc") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Active Client" HeaderStyle-Height="45" ControlStyle-Width="100" ControlStyle-Height="35" ItemStyle-VerticalAlign="Middle">
                <ItemTemplate>
                    <asp:Label ID="lblClientStill" runat="server"
                 Text='<%# Eval("_clientStill") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Client Representive Name" HeaderStyle-Height="45" ControlStyle-Width="200" ControlStyle-Height="35" ItemStyle-VerticalAlign="Middle">
                <ItemTemplate>
                    <asp:Label ID="lblPOCName" runat="server" 
                 Text='<%# Eval("_clientPOCName") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Email Address" HeaderStyle-Height="45" ControlStyle-Width="250" ControlStyle-Height="35" ItemStyle-VerticalAlign="Middle">
                <ItemTemplate>
                    <asp:Label ID="lblPOCEmail" runat="server" 
                 Text='<%# Eval("_clientPOCEmail") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Contact Number" HeaderStyle-Height="45" ControlStyle-Width="200" ControlStyle-Height="35" ItemStyle-VerticalAlign="Middle">
                <ItemTemplate>
                    <asp:Label ID="lblPOCPhone" runat="server" 
                 Text='<%# Eval("_clientPOCPhone") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="true" HeaderText="Update Info" HeaderStyle-Height="45" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ControlStyle-Width="100" ControlStyle-Height="35">
                <ItemTemplate>
                    <asp:LinkButton ID="LnkSelect" runat="server" Text="Update"                           
                     CommandName="Select" />
                    &nbsp;           
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </div>

    </asp:Panel>

</asp:Content>
