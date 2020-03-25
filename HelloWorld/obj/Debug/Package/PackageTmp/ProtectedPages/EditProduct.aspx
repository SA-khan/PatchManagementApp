<%@ Page Title="Portal - Edit Product" Language="C#" MasterPageFile="~/SiteLogout.Master" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="HelloWorld.ProtectedPages.EditProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server" GroupingText="Edit Product" ScrollBars="Both" Height="470px">
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
            <asp:TemplateField HeaderText="Product ID" SortExpression="ProductID">
                <ItemTemplate>
                    <asp:TextBox ID="txtProductID" runat="server" disabled Text='<%# Bind("ProductID") %>' EnableViewState=true ViewStateMode="Enabled"></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtProductID" runat="server" Text='<%# Bind("ProductID") %>'></asp:TextBox>
                </EditItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtProductID" runat="server" Text='<%# Bind("ProductID") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtProductID" runat="server" Text='<%# Bind("ProductID") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Product Name" SortExpression="ProductName">
                <ItemTemplate>
                    <asp:TextBox ID="txtProductName" runat="server" Text='<%# Bind("ProductName") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtProductName" runat="server" Text='<%# Bind("ProductName") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtProductName" runat="server" Text='<%# Bind("ProductName") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Product Description" SortExpression="ProductDesc">
                <ItemTemplate>
                    <asp:TextBox ID="txtProductDesc" runat="server" Text='<%# Bind("ProductDesc") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtProductDesc" runat="server" Text='<%# Bind("ProductDesc") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtProductDesc" runat="server" Text='<%# Bind("ProductDesc") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Product Version" SortExpression="ProductVersion">
                <ItemTemplate>
                    <asp:TextBox ID="txtProductVersion" runat="server" Text='<%# Bind("ProductVersion") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtProductVersion" runat="server" Text='<%# Bind("ProductVersion") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtProductVersion" runat="server" Text='<%# Bind("ProductVersion") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Product Type" 
                SortExpression="ProductType">
                <ItemTemplate>
                    <asp:TextBox ID="txtProductType" runat="server" 
                        Text='<%# Bind("ProductType") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtProductType" runat="server" 
                        Text='<%# Bind("ProductType") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtProductType" runat="server" 
                        Text='<%# Bind("ProductType") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Product Category" 
                SortExpression="ProductCategory">
                <ItemTemplate>
                    <asp:TextBox ID="txtProductCategory" runat="server" 
                        Text='<%# Bind("ProductCategory") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtProductCategory" runat="server" 
                        Text='<%# Bind("ProductCategory") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtProductCategory" runat="server" 
                        Text='<%# Bind("ProductCategory") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Product Rating" 
                SortExpression="ProductRating">
                <ItemTemplate>
                    <asp:TextBox ID="txtProductRating" runat="server" 
                        Text='<%# Bind("ProductRating") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtProductRating" runat="server" 
                        Text='<%# Bind("ProductRating") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtProductRating" runat="server" 
                        Text='<%# Bind("ProductRating") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Product User ID" 
                SortExpression="ProductUserID">
                <ItemTemplate>
                    <asp:TextBox ID="txtProductUserID" runat="server" 
                        Text='<%# Bind("ProductDemoUserID") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtProductUserID" runat="server" 
                        Text='<%# Bind("ProductDemoUserID") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtProductUserID" runat="server" 
                        Text='<%# Bind("ProductDemoUserID") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Product Password" 
                SortExpression="ProductPassword">
                <ItemTemplate>
                    <asp:TextBox ID="txtProductPassword" runat="server" 
                        Text='<%# Bind("ProductDemoPasscode") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtProductPassword" runat="server" 
                        Text='<%# Bind("ProductDemoPasscode") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtProductPassword" runat="server" 
                        Text='<%# Bind("ProductDemoPasscode") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Product POC" 
                SortExpression="ProductPOC">
                <ItemTemplate>
                    <asp:TextBox ID="txtProductPOC" runat="server" 
                        Text='<%# Bind("ProductPOC") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtProductPOC" runat="server" 
                        Text='<%# Bind("ProductPOC") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtProductPOC" runat="server" 
                        Text='<%# Bind("ProductPOC") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Product Email" 
                SortExpression="ProductEmail">
                <ItemTemplate>
                    <asp:TextBox ID="txtProductEmail" runat="server" 
                        Text='<%# Bind("ProductPOCEmail") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtProductEmail" runat="server" 
                        Text='<%# Bind("ProductPOCEmail") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtProductEmail" runat="server" 
                        Text='<%# Bind("ProductPOCEmail") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Product Dependency" 
                SortExpression="ProductComment">
                <ItemTemplate>
                    <asp:TextBox ID="txtProductComment" runat="server" 
                        Text='<%# Bind("ProductDependency") %>'></asp:TextBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtProductRating" runat="server" 
                        Text='<%# Bind("ProductDependency") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtProductRating" runat="server" 
                        Text='<%# Bind("ProductDependency") %>'></asp:TextBox>
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
        
    <asp:GridView ID="GridView1" Width="100%" runat="server" DataKeyNames="ProductID"
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
                 <asp:Label ID="lblProductID" runat="server" 
                 Text='<%# Eval("ProductID") %>' />                              
         </ItemTemplate>
   </asp:TemplateField>                     
    <asp:TemplateField HeaderText="Name">
         <ItemTemplate>
                 <asp:Label ID="lblProductName" runat="server" 
                 Text='<%# Eval("ProductName") %>' />                              
         </ItemTemplate>
   </asp:TemplateField>             
           <asp:TemplateField HeaderText="Description">
         <ItemTemplate>
                 <asp:Label ID="lblProductDesc" runat="server" 
                 Text='<%# Eval("ProductDesc") %>' />                              
         </ItemTemplate>
   </asp:TemplateField>
           <asp:TemplateField HeaderText="Version">
             <ItemTemplate>
                 <asp:Label ID="lblProductVersion" runat="server" 
                 Text='<%# Eval("ProductVersion") %>' />                              
             </ItemTemplate>
           </asp:TemplateField>
           <asp:TemplateField HeaderText="Type">
             <ItemTemplate>
                 <asp:Label ID="lblProductType" runat="server" 
                 Text='<%# Eval("ProductType") %>' />                              
             </ItemTemplate>
           </asp:TemplateField>  
           <asp:TemplateField HeaderText="Category">
             <ItemTemplate>
                 <asp:Label ID="lblProductCategory" runat="server" 
                 Text='<%# Eval("ProductCategory") %>' />                              
             </ItemTemplate>
           </asp:TemplateField>  
           <asp:TemplateField HeaderText="Rating">
             <ItemTemplate>
                 <asp:Label ID="lblProductRating" runat="server" 
                 Text='<%# Eval("ProductRating") %>' />                              
             </ItemTemplate>
           </asp:TemplateField>
           <asp:TemplateField HeaderText="Demo User ID">
             <ItemTemplate>
                 <asp:Label ID="lblProductUserID" runat="server" 
                 Text='<%# Eval("ProductDemoUserId") %>' />                              
             </ItemTemplate>
           </asp:TemplateField>   
           <asp:TemplateField HeaderText="Demo Password">
             <ItemTemplate>
                 <asp:Label ID="lblProductPassword" runat="server" 
                 Text='<%# Eval("ProductDemoPasscode") %>' />                              
             </ItemTemplate>
           </asp:TemplateField> 
           <asp:TemplateField HeaderText="Person of Contact(POC)">
             <ItemTemplate>
                 <asp:Label ID="lblProductPOC" runat="server" 
                 Text='<%# Eval("ProductPOC") %>' />                              
             </ItemTemplate>
           </asp:TemplateField> 
           <asp:TemplateField HeaderText="POC Email">
             <ItemTemplate>
                 <asp:Label ID="lblPOCEmail" runat="server" 
                 Text='<%# Eval("ProductSupportEmail") %>' />                              
             </ItemTemplate>
           </asp:TemplateField> 
           <asp:TemplateField HeaderText="Product Dependency">
             <ItemTemplate>
                 <asp:Label ID="lblProductDependency" runat="server" 
                 Text='<%# Eval("ProductComments") %>' />                              
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
