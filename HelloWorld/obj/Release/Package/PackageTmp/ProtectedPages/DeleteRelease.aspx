<%@ Page Title="Portal - Delete Release" Language="C#" MasterPageFile="~/MasterPages/SimpleLogin.Master" AutoEventWireup="true" CodeBehind="DeleteRelease.aspx.cs" Inherits="HelloWorld.ProtectedPages.DeleteRelease" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <asp:Table ID="Table1" runat="server" Width="100%" BackColor="Menu" BorderStyle="Solid" BorderColor="DarkGray" BorderWidth="2px" HorizontalAlign="Center" CellSpacing="5" CellPadding="5" style="margin:5px;padding:5px;">
            <asp:TableHeaderRow Height="40px">
                <asp:TableHeaderCell ColumnSpan="3" HorizontalAlign="Left" style="margin:5px;padding:5px;">
                    <asp:Label ID="Label1" runat="server" Text="Delete A Release.." Font-Italic="true" ForeColor="Black" Font-Names="Arial" Font-Size="Large"></asp:Label>
                    <%--<asp:ValidationSummary ID="ValidationSummary1" EnableClientScript="true" DisplayMode="BulletList" HeaderText="Please Enter Following Fields: " ShowMessageBox="true" runat="server" ForeColor="Red" ShowSummary="False" />--%>
                    <br />
                    <br />
                    <asp:Label ID="lblSubmission" runat="server" Text="Release is successfully deleted." Font-Italic="true" ForeColor="Navy" Font-Names="Arial" Font-Size="Medium" Visible="false"></asp:Label>
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow ID="rowPatchTitle" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="Label2" runat="server" Text="Patch Title" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtPatchTitle" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter Patch Title Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqPatchTitle" runat="server" ControlToValidate="txtPatchTitle" ErrorMessage="Enter Patch Title." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowPatchNumber" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblPatchNumber" runat="server" Text="Patch Number" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtPatchNumber" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter Patch Number Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                   <%-- <asp:RequiredFieldValidator ID="ReqPatchNumber" runat="server" ControlToValidate="txtPatchNumber" ErrorMessage="Enter Patch Number." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowPatchCreatedDate" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblPatchCreatedDate" runat="server" Text="Patch Created Date" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtPatchCreatedDate" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter Patch Created Date Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqPatchCreatedDate" runat="server" ControlToValidate="txtPatchDeployedBy" ErrorMessage="Enter Patch Created Date." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowPatchDeployedDate" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblPatchDeployedDate" runat="server" Text="Patch Deployed Date" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtPatchDeployedDate" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter Patch Deployed Date Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqPatchDeployedDate" runat="server" ControlToValidate="txtPatchDeployedDate" ErrorMessage="Enter Patch Deployed Date." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowPatchClientName" runat="server">
                <asp:TableCell>
                    <asp:Label ID="lblPatchClientName" runat="server" Text="Patch Client Name" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <%--<asp:TextBox ID="txtPatchClientName" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" placeholder="Enter Patch Client Name Here"></asp:TextBox>--%>
                    <asp:DropDownList ID="dropPatchClientName" runat="server" BackColor="ButtonFace"
        Width="250px" Height="27px" Font-Italic="true" Font-Size="Medium" Font-Names="Arial" ForeColor="black"
        DataSourceID="SqlDataSource2" DataTextField="ClientName" style="text-align=center"
        DataValueField="ClientID" AutoPostBack="false" ViewStateMode="Enabled" 
        AppendDataBoundItems="True">
        <asp:ListItem>Select..</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
        SelectCommand="SELECT [ClientID],[ClientName] FROM [ClientDetail]"></asp:SqlDataSource>
                </asp:TableCell>
                <asp:TableCell>
                    <%--<asp:RequiredFieldValidator ID="ReqPatchClientName" runat="server" InitialValue="Select.." ControlToValidate="dropPatchClientName"  ErrorMessage="Please Select Client Name" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowProductName" runat="server">
                <asp:TableCell>
                    <asp:Label ID="lblProductName" runat="server" Text="Product Name" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <%--<asp:TextBox ID="txtProductName" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" TextMode="Email" placeholder="Enter Product Name Here"></asp:TextBox>--%>
                    <asp:DropDownList ID="dropProductName" runat="server" BackColor="ButtonFace"
        Width="250px" Height="27px" Font-Italic="true" Font-Size="Medium" Font-Names="Arial" ForeColor="black"
        DataSourceID="SqlDataSource1" DataTextField="ProductName" style="text-align=center"
        DataValueField="ProductID" AutoPostBack="false" ViewStateMode="Enabled" 
        AppendDataBoundItems="True">
        <asp:ListItem>Select..</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
        SelectCommand="SELECT [ProductID],[ProductName] FROM [Products]"></asp:SqlDataSource>
                </asp:TableCell>
                <asp:TableCell>
                    <%--<asp:RequiredFieldValidator ID="ReqProductName" runat="server" InitialValue="Select.." ControlToValidate="dropProductName" Display="Dynamic" EnableClientScript="true" Text="(Required)" ForeColor="Red" Font-Bold="true" ErrorMessage="Please Select Product Name"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowEnvironmentType" runat="server">
                <asp:TableCell>
                    <asp:Label ID="lblEnvironmentType" runat="server" Text="Environment Type" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <%--<asp:TextBox ID="txtEnvironmentType" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" TextMode="Phone" placeholder="Enter Environment Type Here"></asp:TextBox>--%>
                    <asp:DropDownList ID="dropEnvironmentType" runat="server" BackColor="ButtonFace"
        Width="250px" Height="27px" Font-Italic="true" Font-Size="Medium" Font-Names="Arial" ForeColor="black"
        DataSourceID="SqlDataSource3" DataTextField="ENV_TITLE" style="text-align=center" ondatabinding="DropDownList1_DataBinding"
        DataValueField="ENV_ID" AutoPostBack="false" ViewStateMode="Enabled" ondatabound="DropDownList1_DataBound"
        AppendDataBoundItems="True">
        <asp:ListItem>Select..</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" SelectCommand="SELECT E.ENV_ID,CONCAT('Client: ',C.ClientName,', Product: ',P.ProductName,', Environment: ',ET.EnvTitle, '') As Env_Title from (((Environment E Inner Join ClientDetail C on E.ENV_Client_ID = C.ClientID) INNER JOIN Products P On E.ENV_Product_ID = P.ProductID ) INNER JOIN EnvironmentType ET ON ET.EnvID = E.ENV_AppServerEnvironmentType)"></asp:SqlDataSource>
                </asp:TableCell>
                <asp:TableCell>
                    <%--<asp:RequiredFieldValidator ID="ReqEnvironmentType" runat="server" ControlToValidate="dropEnvironmentType" ErrorMessage="Please Select Environment Type" InitialValue="Select.." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowSubmit" runat="server">
                <asp:TableCell>
                    
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="btnDelete" runat="server" Text="DELETE" Width="70px" Height="30px" 
            style="margin:5px;padding:5px;" onclick="btnDelete_Click"  />
                    <asp:Button ID="btnClear" runat="server" Text="CLEAR" Width="70px" 
            Height="30px" style="margin:5px;padding:5px;" onclick="btnClear_Click"  />
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
