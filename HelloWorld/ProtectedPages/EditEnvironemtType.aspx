<%@ Page Title="" Language="C#" MasterPageFile="~/SiteLogout.Master" AutoEventWireup="true" CodeBehind="EditEnvironemtType.aspx.cs" Inherits="HelloWorld.ProtectedPages.EditEnvironemtType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server" GroupingText="Edit Environment Type">
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
            <asp:TemplateField HeaderText="Environment Type ID" SortExpression="ClientID">
                <ItemTemplate>
                    <asp:TextBox ID="txtClientID" runat="server" disabled Text='<%# Bind("Environment_ID") %>' EnableViewState=true ViewStateMode="Enabled"></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtClientID" runat="server" Text='<%# Bind("Environment_ID") %>'></asp:TextBox>
                </EditItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtClientID" runat="server" Text='<%# Bind("Environment_ID") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtClientID" runat="server" Text='<%# Bind("Environment_ID") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Environment Title" SortExpression="EnvironmentTitle">
                <ItemTemplate>
                    <asp:TextBox ID="txtClientName" runat="server" Text='<%# Bind("Environment_Title") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtClientName" runat="server" Text='<%# Bind("Environment_Title") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtClientName" runat="server" Text='<%# Bind("Environment_Title") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Environment Description" SortExpression="EnvironmentDescription">
                <ItemTemplate>
                    <asp:TextBox ID="txtClientDesc" runat="server" Text='<%# Bind("Environment_Desc") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtClientDesc" runat="server" Text='<%# Bind("Environment_Desc") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtClientDesc" runat="server" Text='<%# Bind("Environment_Desc") %>'></asp:TextBox>
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
        
    <asp:GridView ID="GridView1" Width="100%" runat="server" DataKeyNames="Environment_ID"
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
         <asp:TemplateField Visible="false" HeaderText="Environment ID">
         <ItemTemplate>
                 <asp:Label ID="lblClientID" runat="server" 
                 Text='<%# Eval("Environment_ID") %>' />                              
         </ItemTemplate>
   </asp:TemplateField>                     
    <asp:TemplateField HeaderText="Environment Name">
         <ItemTemplate>
                 <asp:Label ID="lblClientName" runat="server" 
                 Text='<%# Eval("Environment_Title") %>' />                              
         </ItemTemplate>
   </asp:TemplateField>             
           <asp:TemplateField HeaderText="Environment Description">
         <ItemTemplate>
                 <asp:Label ID="lblClientDesc" runat="server" 
                 Text='<%# Eval("Environment_Desc") %>' />                              
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
