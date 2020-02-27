<%@ Page Title="" Language="C#" MasterPageFile="~/SiteLogout.Master" AutoEventWireup="true" CodeBehind="EditUserRole.aspx.cs" Inherits="HelloWorld.ProtectedPages.EditUserRole" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <asp:Panel ID="Panel1" runat="server" GroupingText="Edit User Role">
       <%-- <asp:Label ID="Label1" runat="server" Text="Add Environment Type"></asp:Label>--%>

       <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
    <ContentTemplate>
   <asp:DetailsView ID="DetailsView1" CssClass="accordionView" runat="server" 
        Height="50px" Width="40%" 
        AutoGenerateRows="False" BackColor="White" BorderColor="#CCCCCC" OnRowCommand="GridView1_RowCommand"
        BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        onpageindexchanging="DetailsView1_PageIndexChanging" 
        ondatabound="DetailsView1_DataBound">
        <EditRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <Fields>
            <asp:TemplateField HeaderText="User Role ID" SortExpression="UserRoleID">
                <ItemTemplate>
                    <asp:TextBox ID="txtUserRoleID" runat="server" disabled Text='<%# Bind("UserRoleID") %>' EnableViewState=true ViewStateMode="Enabled"></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtUserRoleID" runat="server" Text='<%# Bind("UserRoleID") %>'></asp:TextBox>
                </EditItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtUserRoleID" runat="server" Text='<%# Bind("UserRoleID") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtUserRoleID" runat="server" Text='<%# Bind("UserRoleID") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="User Role Title" SortExpression="UserRoleTitle">
                <ItemTemplate>
                    <asp:TextBox ID="txtUserRoleTitle" runat="server" Text='<%# Bind("UserRoleTitle") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtUserRoleTitle" runat="server" Text='<%# Bind("UserRoleTitle") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtUserRoleTitle" runat="server" Text='<%# Bind("UserRoleTitle") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="User Role Description" SortExpression="UserRoleDesc">
                <ItemTemplate>
                    <asp:TextBox ID="txtUserRoleDesc" runat="server" Text='<%# Bind("UserRoleDesc") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtUserRoleDesc" runat="server" Text='<%# Bind("UserRoleDesc") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtUserRoleDesc" runat="server" Text='<%# Bind("UserRoleDesc") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate>
                   <asp:Button ID="btnSave" ClientIDMode="Static" runat="server" CausesValidation="false" 
                        Text="Save" onclick="btnSave_Click" />
                    <asp:Button ID="btnCancel" runat="server" 
        CssClass="accordionButton" CausesValidation="false" 
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
        
    <asp:GridView ID="GridView1" Width="100%" runat="server" DataKeyNames="ROLE_ID"
        style="min-height:300px;"
        RowStyle-Height="60px"
        AutoGenerateColumns="false" AllowSorting="true"
        AlternatingRowStyle-BackColor="LightGray" BorderColor="ControlDark" 
        BorderStyle="Solid" BorderWidth="1" EditRowStyle-Font-Names="Arial" 
        EditRowStyle-Font-Size="Small" EditRowStyle-ForeColor="Black" 
        Font-Names="Arial" Font-Size="Small" Font-Bold="false" GridLines="Both" 
        HeaderStyle-BackColor="Aqua" HeaderStyle-Font-Names="Arial" ForeColor="Black" 
        HeaderStyle-Font-Size="Small" HeaderStyle-Font-Bold="false" 
        HeaderStyle-Font-Italic="true" HeaderStyle-Font-Underline="false" 
        HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" 
        HorizontalAlign="Right" RowStyle-HorizontalAlign="Right" 
        RowStyle-VerticalAlign="Middle" SelectedRowStyle-BackColor="DarkGray" 
        SelectedRowStyle-Font-Bold="true" SelectedRowStyle-Font-Size="Small" 
        SelectedRowStyle-Height="24px" onrowediting="GridView1_RowEditing" 
        onrowupdating="GridView1_RowUpdating" 
        onpageindexchanging="GridView1_PageIndexChanging" 
        onrowcancelingedit="GridView1_RowCancelingEdit" 
        onselectedindexchanged="GridView1_SelectedIndexChanged">
         <Columns>     
         <asp:TemplateField Visible="false" HeaderText="User Role ID">
         <ItemTemplate>
                 <asp:Label ID="lblUserRoleID" runat="server" 
                 Text='<%# Eval("ROLE_ID") %>' />                              
         </ItemTemplate>
   </asp:TemplateField>                     
    <asp:TemplateField HeaderText="User Role Name">
         <ItemTemplate>
                 <asp:Label ID="lblUserRoleTitle" runat="server" 
                 Text='<%# Eval("ROLE_TITLE") %>' />                              
         </ItemTemplate>
   </asp:TemplateField>             
           <asp:TemplateField HeaderText="User Role Description">
         <ItemTemplate>
                 <asp:Label ID="lblUserRoleDesc" runat="server" 
                 Text='<%# Eval("ROLE_DESC") %>' />                              
         </ItemTemplate>
   </asp:TemplateField>
           <asp:TemplateField ShowHeader="true" HeaderText="Select">
             <ItemTemplate>                     
                    <asp:LinkButton ID="LnkSelect" runat="server" Text="Update"                           
                     CommandName="Select" />&nbsp;           
             </ItemTemplate>
           </asp:TemplateField>                                      
   </Columns>
    </asp:GridView>
    </ContentTemplate>
    <Triggers>
        <%--<asp:AsyncPostBackTrigger ControlID="btnSave" EventName="click" />--%>
    </Triggers>
        </asp:UpdatePanel>

    </asp:Panel>

    

</asp:Content>
