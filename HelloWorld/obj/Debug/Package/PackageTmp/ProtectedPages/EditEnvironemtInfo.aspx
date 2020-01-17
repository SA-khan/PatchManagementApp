<%@ Page Title="" Language="C#" MasterPageFile="~/SiteLogout.Master" AutoEventWireup="true" CodeBehind="EditEnvironemtInfo.aspx.cs" Inherits="HelloWorld.ProtectedPages.EditEnvironemtInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<style>
    .accordionView 
    {
       <%--Display: none; --%>
    }
</style>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        //ACCORDION BUTTON ACTION
        $('.accordionView').click(function () {
            alert("HERE!");
            $(this).next().slideToggle();
        });
        $('.accordionButton').click(function () {
//            $('.accordionView').css.Display('none');
        });
    });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
    <ContentTemplate>
    <asp:Label ID="lblUser" runat="server" Text=""></asp:Label>
   
   <asp:DetailsView ID="DetailsView1" CssClass="accordionView" runat="server" 
        Height="50px" Width="50%" 
        AutoGenerateRows="False" BackColor="White" BorderColor="#CCCCCC" OnRowCommand="GridView1_RowCommand"
        BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        onpageindexchanging="DetailsView1_PageIndexChanging" 
        ondatabound="DetailsView1_DataBound">
        <EditRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <Fields>
            <asp:TemplateField HeaderText="Client Name" SortExpression="ClientName">
                <ItemTemplate>
                    <asp:TextBox ID="lblClientName" runat="server" disabled Text='<%# Bind("ClientName") %>' EnableViewState=true ViewStateMode="Enabled"></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="lblClientName" runat="server" Text='<%# Bind("ClientName") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="lblClientName" runat="server" Text='<%# Bind("ClientName") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Client Type" SortExpression="PatchDesc">
                <ItemTemplate>
                    <asp:TextBox ID="lblClientType" runat="server" Text='<%# Bind("ClientType") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="lblClientType" runat="server" Text='<%# Bind("ClientType") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="lblClientType" runat="server" Text='<%# Bind("ClientType") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="TotalPatches" SortExpression="TotalPatches">
                <ItemTemplate>
                    <asp:TextBox ID="txtTotalPatches" runat="server" Text='<%# Bind("TotalPatches") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtTotalPatches" runat="server" Text='<%# Bind("TotalPatches") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtTotalPatches" runat="server" Text='<%# Bind("TotalPatches") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PatchHotNumber" SortExpression="PatchHotNumber">
                <ItemTemplate>
                    <asp:TextBox ID="txtPatchHotNumber" runat="server" Text='<%# Bind("LatestHotPatch") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtPatchHotNumber" runat="server" Text='<%# Bind("LatestHotPatch") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtPatchHotNumber" runat="server" Text='<%# Bind("LatestHotPatch") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PatchDeployedDate" 
                SortExpression="PatchDeployedDate">
                <ItemTemplate>
                    <asp:TextBox ID="txtPatchDeployedDate" runat="server" 
                        Text='<%# Bind("PatchDeployedDate") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtPatchDeployedDate" runat="server" 
                        Text='<%# Bind("PatchDeployedDate") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtPatchDeployedDate" runat="server" 
                        Text='<%# Bind("PatchDeployedDate") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Button ID="btnSave" runat="server" CausesValidation="false" 
                        Text="Save" onclick="btnSave_Click" />
                    <asp:Button ID="btnCancel" runat="server" CssClass="accordionButton" CausesValidation="false" 
                        CommandName="Cancel" Text="Cancel" 
        onclick="btnCancel_Click" />
                </ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:TemplateField>
        </Fields>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
    </asp:DetailsView>

    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
        SelectCommand="SELECT [PatchTitle], [PatchDesc], [PatchHotNumber], [PatchDeployedBy], [PatchCreatedDate], [PatchDeployedDate], [IsQAPassed], [Remarks_Dependencies], [ClientID] FROM [PatchDetail]">
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" Width="100%" runat="server" DataKeyNames="ClientName"
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
    <asp:TemplateField HeaderText="Client Name">
         <ItemTemplate>
                 <asp:Label ID="lblClientName" runat="server" 
                 Text='<%# Eval("ClientName") %>' />                              
         </ItemTemplate>
   </asp:TemplateField>             
           <asp:TemplateField HeaderText="Client Type">
         <ItemTemplate>
                 <asp:Label ID="lblClientType" runat="server" 
                 Text='<%# Eval("ClientType") %>' />                              
         </ItemTemplate>
   </asp:TemplateField>
           <asp:TemplateField HeaderText="Total Patches">
             <ItemTemplate>
                 <asp:Label ID="lblTotalPatches" runat="server" 
                 Text='<%# Eval("clientPOCName") %>' />                              
             </ItemTemplate>
           </asp:TemplateField>
           <asp:TemplateField HeaderText="Latest Patch">
             <ItemTemplate>
                 <asp:Label ID="lblLatestPatch" runat="server" 
                 Text='<%# Eval("patchHotNumber") %>' />                              
             </ItemTemplate>
           </asp:TemplateField>  
           <asp:TemplateField HeaderText="Patch Deployed On">
             <ItemTemplate>
                 <asp:Label ID="lblPatchDeployed" runat="server" 
                 Text='<%# Eval("patchDeployedDate") %>' />                              
             </ItemTemplate>
           </asp:TemplateField>  
           <asp:TemplateField ShowHeader="true" HeaderText="Select">
             <ItemTemplate>                     
                    <asp:LinkButton ID="LnkSelect" runat="server" Text="Select"                           
                     CommandName="Select" />&nbsp;           
             </ItemTemplate>
           </asp:TemplateField>                          
           <asp:TemplateField ShowHeader="true" HeaderText="Edit">
             <ItemTemplate>  
                  <%--<asp:CommandField ShowEditButton="true" /> --%>    
                  <asp:LinkButton ID="LnkEdit" runat="server" Text="Update"                           
                     CommandName="Update" />&nbsp;          
             </ItemTemplate>
           </asp:TemplateField>             
   </Columns>
    </asp:GridView>
    </ContentTemplate>
    <Triggers>
        <%--<asp:AsyncPostBackTrigger ControlID="DetailsView1" EventName="btnCancel_Click" EventName="RowCommand" />--%>
    </Triggers>
        </asp:UpdatePanel>
      
       

</asp:Content>
