<%@ Page Title="Portal - Add Product" Language="C#" MasterPageFile="~/MasterPages/SimpleLogin.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="HelloWorld.ProtectedPages.AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server" GroupingText="Add Product">
       <%-- <asp:Label ID="Label1" runat="server" Text="Add Environment Type"></asp:Label>--%>

       <asp:Table ID="Table1" runat="server" Width="100%" BackColor="Menu" BorderStyle="Solid" BorderColor="DarkGray" BorderWidth="2px" HorizontalAlign="Center" CellSpacing="5" CellPadding="5" style="margin:5px;padding:5px;">
            <asp:TableHeaderRow Height="40px">
                <asp:TableHeaderCell ColumnSpan="3" HorizontalAlign="Left" style="margin:5px;padding:5px;">
                    <asp:Label ID="Label1" runat="server" Text="Add A Product.." Font-Italic="true" ForeColor="Black" Font-Names="Arial" Font-Size="Large"></asp:Label>
                    <asp:ValidationSummary ID="ValidationSummary1" EnableClientScript="true" DisplayMode="BulletList" HeaderText="Please Enter Following Fields: " ShowMessageBox="true" runat="server" ForeColor="Red" ShowSummary="False" />
                    <br />
                    <br />
                    <asp:Label ID="lblSubmission" runat="server" Text="Product is successfully added." Font-Italic="true" ForeColor="Navy" Font-Names="Arial" Font-Size="Medium" Visible="false"></asp:Label>
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow ID="rowProductName" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblProductName" runat="server" Text="Product Name" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtProductName" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" placeholder=" Enter Product Name Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:RequiredFieldValidator ID="ReqProductName" runat="server" ControlToValidate="txtProductName" ErrorMessage="Enter Product Name." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
           
            <asp:TableRow ID="rowProductDesc" runat="server">
                <asp:TableCell>
                    <asp:Label ID="lblProductDesc" runat="server" Text="Product Description" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtProductDesc" CausesValidation="true" runat="server" Width="246px" Height="50px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;font-family:Arial;" TextMode="MultiLine" placeholder=" Enter Product Description Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="ReqProductDesc" runat="server" ControlToValidate="txtProductDesc" ErrorMessage="Enter Product Desciption." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowProductVersion" runat="server">
                <asp:TableCell>
                    <asp:Label ID="lblProductVersion" runat="server" Text="Product Version" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtProductVersion" runat="server" TextMode="Number" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" placeholder=" Enter Product Version Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="ReqProductVersion" runat="server" ControlToValidate="txtProductVersion" ErrorMessage="Enter Product Version." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowProductType" runat="server">
                <asp:TableCell>
                    <asp:Label ID="lblProductType" runat="server" Text="Product Type" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtProductType" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" placeholder=" Enter Product Type Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="ReqProductType" runat="server" ControlToValidate="txtProductType" ErrorMessage="Enter Product Type." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowProductCategory" runat="server">
                <asp:TableCell>
                    <asp:Label ID="lblProductCategory" runat="server" Text="Product Category" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtProductCategory" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" placeholder=" Enter Product Category Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="ReqProductCategory" runat="server" ControlToValidate="txtProductCategory" ErrorMessage="Enter Product Category." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowProductRating" runat="server">
                <asp:TableCell>
                    <asp:Label ID="lblProductRating" runat="server" Text="Product Rating" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtProductRating" runat="server" TextMode="Number" MaxLength="1" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" placeholder=" Enter Product Rating Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="ReqProductRating" runat="server" ControlToValidate="txtProductRating" ErrorMessage="Enter Product Rating." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowProductUserID" runat="server">
                <asp:TableCell>
                    <asp:Label ID="lblProductUserID" runat="server" Text="Product User ID" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtProductUserID" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" placeholder=" Enter Product Demo User ID Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="ReqProductUserID" runat="server" ControlToValidate="txtProductUserID" ErrorMessage="Enter Product User ID." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowProductPassword" runat="server">
                <asp:TableCell>
                    <asp:Label ID="lblProductPassword" runat="server" Text="Product Password" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtProductPassword" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" placeholder=" Enter Product Demo Password Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="ReqProductPassword" runat="server" ControlToValidate="txtProductPassword" ErrorMessage="Enter Product Password." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowProductPOC" runat="server">
                <asp:TableCell>
                    <asp:Label ID="lblProductPOC" runat="server" Text="Product POC" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtProductPOC" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" placeholder=" Enter Product POC Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="ReqProductPOC" runat="server" ControlToValidate="txtProductPOC" ErrorMessage="Enter Product POC." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowProductSupportEmail" runat="server">
                <asp:TableCell>
                    <asp:Label ID="lblProductSupportEmail" runat="server" Text="Product Support Eamil" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtProductSupportEmail" runat="server" TextMode="Email" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" placeholder=" Enter Product Support Email"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="ReqProductSupportEmail" runat="server" ControlToValidate="txtProductSupportEmail" ErrorMessage="Enter Product Support Email." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowProductComments" runat="server">
                <asp:TableCell>
                    <asp:Label ID="lblProductComments" runat="server" Text="Product Comments" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtProductComments" runat="server" TextMode="MultiLine" Width="250px" Height="46px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;font-family:Arial;" placeholder=" Enter Product Comments"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="ReqProductComments" runat="server" ControlToValidate="txtProductComments" ErrorMessage="Enter Product Comments." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
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
