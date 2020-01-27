<%@ Page Title="Portal - Edit Company" Language="C#" MasterPageFile="~/SiteLogout.Master" AutoEventWireup="true" CodeBehind="EditCompany.aspx.cs" Inherits="HelloWorld.ProtectedPages.EditCompanyInfo" %>
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
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
             <asp:GridView ID="GridView1" runat="server">

             </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>--%>
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
            <asp:TemplateField HeaderText="Client ID" SortExpression="ClientID">
                <ItemTemplate>
                    <asp:TextBox ID="txtClientID" runat="server" disabled Text='<%# Bind("ClientID") %>' EnableViewState=true ViewStateMode="Enabled"></asp:TextBox>
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
                    <asp:DropDownList ID="dropClientType" runat="server" AppendDataBoundItems="true" DataTextField='<%# Bind("ClientType") %>' DataTextFormatString='<%# Bind("ClientType") %>' DataValueField='<%# Bind("ClientType") %>' >
                        <asp:ListItem Value="Insurance">Insurance</asp:ListItem>
                        <asp:ListItem Value="Bank">Bank</asp:ListItem>
                        <asp:ListItem Value="AMC">AMC</asp:ListItem>
                    </asp:DropDownList>

                </ItemTemplate>
                <%--<EditItemTemplate>
                    <asp:TextBox ID="txtClientType" runat="server" Text='<%# Bind("ClientType") %>'></asp:TextBox>
                </EditItemTemplate>--%>
<%--                <InsertItemTemplate>
                    <asp:TextBox ID="txtClientType" runat="server" Text='<%# Bind("ClientType") %>'></asp:TextBox>
                </InsertItemTemplate>--%>
            </asp:TemplateField>
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

    <br/>
        
    <asp:GridView ID="GridView1" Width="100%" runat="server" DataKeyNames="_clientName"
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
         <asp:TemplateField Visible="false" HeaderText="Client ID">
         <ItemTemplate>
                 <asp:Label ID="lblClientID" runat="server" 
                 Text='<%# Eval("_clientID") %>' />                              
         </ItemTemplate>
   </asp:TemplateField>                     
    <asp:TemplateField HeaderText="Client Name">
         <ItemTemplate>
                 <asp:Label ID="lblClientName" runat="server" 
                 Text='<%# Eval("_clientName") %>' />                              
         </ItemTemplate>
   </asp:TemplateField>             
           <asp:TemplateField HeaderText="Client Type">
         <ItemTemplate>
                 <asp:Label ID="lblClientType" runat="server" 
                 Text='<%# Eval("_clientType") %>' />                              
         </ItemTemplate>
   </asp:TemplateField>
           <asp:TemplateField HeaderText="Total Patches">
             <ItemTemplate>
                 <asp:Label ID="lblClientDesc" runat="server" 
                 Text='<%# Eval("_clientDesc") %>' />                              
             </ItemTemplate>
           </asp:TemplateField>
           <asp:TemplateField HeaderText="Current Client">
             <ItemTemplate>
                 <asp:Label ID="lblClientStill" runat="server" 
                 Text='<%# Eval("_clientStill") %>' />                              
             </ItemTemplate>
           </asp:TemplateField>  
           <asp:TemplateField HeaderText="Client POC Name">
             <ItemTemplate>
                 <asp:Label ID="lblPOCName" runat="server" 
                 Text='<%# Eval("_clientPOCName") %>' />                              
             </ItemTemplate>
           </asp:TemplateField>  
           <asp:TemplateField HeaderText="ClientPOCEmail">
             <ItemTemplate>
                 <asp:Label ID="lblPOCEmail" runat="server" 
                 Text='<%# Eval("_clientPOCEmail") %>' />                              
             </ItemTemplate>
           </asp:TemplateField>
           <asp:TemplateField HeaderText="ClientPOCPhone">
             <ItemTemplate>
                 <asp:Label ID="lblPOCPhone" runat="server" 
                 Text='<%# Eval("_clientPOCPhone") %>' />                              
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

    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>

</asp:Content>
