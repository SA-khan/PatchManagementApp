<%@ Page Title="Portal - Edit User" Language="C#" MasterPageFile="~/SiteLogout.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="HelloWorld.ProtectedPages.EditUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server" GroupingText="Edit User">
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
            <asp:TemplateField HeaderText="User ID" SortExpression="UserID">
                <ItemTemplate>
                    <asp:TextBox ID="txtUserID" runat="server" disabled Text='<%# Bind("UserID") %>' EnableViewState=true ViewStateMode="Enabled"></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtUserID" runat="server" Text='<%# Bind("UserID") %>'></asp:TextBox>
                </EditItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtUserID" runat="server" Text='<%# Bind("UserID") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtUserID" runat="server" Text='<%# Bind("UserID") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="User Name" SortExpression="UserName">
                <ItemTemplate>
                    <asp:TextBox ID="txtUserName" runat="server" Text='<%# Bind("UserName") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtUserName" runat="server" Text='<%# Bind("UserName") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtUserName" runat="server" Text='<%# Bind("UserName") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="User Role" SortExpression="UserRole">
                <ItemTemplate>
                    <asp:HiddenField ID="hidUserRole" runat="server" Value='<%# Bind("UserRole") %>' />
                    <asp:DropDownList ID="DropUserRole" runat="server" 
        DataSourceID="SqlDataSourceRole" DataTextField='ROLE_TITLE' SelectedValue='<%# Bind("UserRole") %>'
        DataValueField="ROLE_TITLE">
    </asp:DropDownList>

    <asp:SqlDataSource ID="SqlDataSourceRole" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
        SelectCommand="SELECT [ROLE_ID], [ROLE_TITLE] FROM [ROLES]">
    </asp:SqlDataSource>
                    <%--<asp:DropDownList ID="dropUserRole" runat="server" 
        DataTextField='<%# Bind("UserRole") %>' 
        DataTextFormatString='<%# Bind("UserRole") %>'
        DataValueField='<%# Bind("UserRole") %>' 
         DataSourceID="SqlDataSourceRole" >
                    </asp:DropDownList>--%>
                    <%----%>
                    <%--<asp:SqlDataSource ID="SqlDataSourceRole" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
                        SelectCommand="SELECT [ROLE_ID], [ROLE_TITLE] FROM [ROLES]">
                    </asp:SqlDataSource>--%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtUserRole" runat="server" Text='<%# Bind("UserRole") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtUserRole" runat="server" Text='<%# Bind("UserRole") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="User Status" SortExpression="txtUserStatus">
                <ItemTemplate>
                    <asp:TextBox ID="txtUserStatus" runat="server" Text='<%# Bind("UserStatus") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtUserStatus" runat="server" Text='<%# Bind("UserStatus") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtUserStatus" runat="server" Text='<%# Bind("UserStatus") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
<%--            <asp:TemplateField HeaderText="Current Client" 
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
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="Login Date" 
                SortExpression="UserLoginDate">
                <ItemTemplate>
                    <asp:TextBox ID="txtUserLoginDate" runat="server" 
                        Text='<%# Bind("UserLoginDate") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtUserLoginDate" runat="server" 
                        Text='<%# Bind("UserLoginDate") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtUserLoginDate" runat="server" 
                        Text='<%# Bind("UserLoginDate") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total Wrong Attempts" 
                SortExpression="WrongAttempts">
                <ItemTemplate>
                    <asp:TextBox ID="txtWrongAttempts" runat="server" 
                        Text='<%# Bind("UserWrongAttempt") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtWrongAttempts" runat="server" 
                        Text='<%# Bind("UserWrongAttempt") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtWrongAttempts" runat="server" 
                        Text='<%# Bind("UserWrongAttempt") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate>
                       <asp:Button ID="btnSave" runat="server" CausesValidation="false" 
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
        
    <asp:GridView ID="GridView1" Width="100%" runat="server" DataKeyNames="UserID"
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
         <asp:TemplateField Visible="false" HeaderText="ID">
         <ItemTemplate>
                 <asp:Label ID="lblUserID" runat="server" 
                 Text='<%# Eval("UserID") %>' />                              
         </ItemTemplate>
   </asp:TemplateField>                     
    <asp:TemplateField HeaderText="User Name">
         <ItemTemplate>
                 <asp:Label ID="lblUserName" runat="server" 
                 Text='<%# Eval("UserName") %>' />                              
         </ItemTemplate>
   </asp:TemplateField>             
           <asp:TemplateField HeaderText="User Role">
         <ItemTemplate>
                 <asp:Label ID="lblUserRole" runat="server" 
                 Text='<%# Eval("UserRole") %>' />                              
         </ItemTemplate>
   </asp:TemplateField>
           <asp:TemplateField HeaderText="User Status">
             <ItemTemplate>
                 <asp:Label ID="lblUserStatus" runat="server" 
                 Text='<%# Eval("UserStatus") %>' />                              
             </ItemTemplate>
           </asp:TemplateField>
           <asp:TemplateField HeaderText="Login Date">
             <ItemTemplate>
                 <asp:Label ID="lblUserLoginDate" runat="server" 
                 Text='<%# Eval("UserLoginDate") %>' />                              
             </ItemTemplate>
           </asp:TemplateField>  
           <asp:TemplateField HeaderText="Password Wrong Attempt">
             <ItemTemplate>
                 <asp:Label ID="lblUserWrongAttempt" runat="server" 
                 Text='<%# Eval("UserWrongAttempt") %>' />                              
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
        <%--<asp:AsyncPostBackTrigger ControlID="DetailsView1" EventName="btnCancel_Click" EventName="RowCommand" />--%>
    </Triggers>
        </asp:UpdatePanel>

    </asp:Panel>

    

</asp:Content>
