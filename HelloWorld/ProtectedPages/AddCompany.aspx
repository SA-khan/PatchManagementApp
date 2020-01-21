<%@ Page Title="" Language="C#" MasterPageFile="~/SiteLogout.Master" AutoEventWireup="true" CodeBehind="AddCompany.aspx.cs" Inherits="HelloWorld.ProtectedPages.AddCompany" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <asp:Table ID="Table1" runat="server" Width="100%" BackColor="Menu" BorderStyle="Solid" BorderColor="DarkGray" BorderWidth="2px" HorizontalAlign="Center" CellSpacing="5" CellPadding="5" style="margin:5px;padding:5px;">
            <asp:TableHeaderRow Height="40px">
                <asp:TableHeaderCell ColumnSpan="3" HorizontalAlign="Left" style="margin:5px;padding:5px;">
                    <asp:Label ID="Label1" runat="server" Text="Add A Client.." Font-Italic="true" ForeColor="Black" Font-Names="Arial" Font-Size="Large"></asp:Label>
                    <asp:ValidationSummary ID="ValidationSummary1" EnableClientScript="true" DisplayMode="BulletList" HeaderText="Please Enter Following Fields: " ShowMessageBox="true" runat="server" ForeColor="Red" ShowSummary="False" />
                    <br />
                    <br />
                    <asp:Label ID="lblSubmission" runat="server" Text="Client is successfully added." Font-Italic="true" ForeColor="Navy" Font-Names="Arial" Font-Size="Medium" Visible="false"></asp:Label>
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow ID="rowCLientName" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="Label2" runat="server" Text="Client Name" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtClientName" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" placeholder="Enter Client Name Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:RequiredFieldValidator ID="ReqClientName" runat="server" ControlToValidate="txtClientName" ErrorMessage="Enter Client Name." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowCLientType" runat="server">
                <asp:TableCell>
                    <asp:Label ID="Label3" runat="server" Text="Client Type" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="dropClientType" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;">
                          <asp:ListItem>Select Client Type..</asp:ListItem>
                          <asp:ListItem>AMC</asp:ListItem>
                          <asp:ListItem>Insurance</asp:ListItem>
                          <asp:ListItem>Bank</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="ReqClientType" runat="server" ControlToValidate="dropClientType" ErrorMessage="Enter Client Type." InitialValue="Select Client Type.." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowCLientDesc" runat="server">
                <asp:TableCell>
                    <asp:Label ID="lblClientDesc" runat="server" Text="Client Description" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtClientDesc" CausesValidation="true" runat="server" Width="250px" Height="50px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" TextMode="MultiLine" placeholder="Enter Client Description Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Client Description" InitialValue="*" Text="*" Display="Dynamic" ControlToValidate="txtClientDesc"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowPOCName" runat="server">
                <asp:TableCell>
                    <asp:Label ID="lblPOCName" runat="server" Text="Client Person of Contact Name" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtPOCName" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" placeholder="Enter Client POC Name"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" InitialValue="*" ControlToValidate="txtPOCName" Display="Static" EnableClientScript="true" Text="Please Enter POC Name"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowPOCEmail" runat="server">
                <asp:TableCell>
                    <asp:Label ID="lblPOCEmail" runat="server" Text="Client Person of Contact Email" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtPOCEmail" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" TextMode="Email" placeholder="Enter Client POC Email"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" InitialValue="*" ControlToValidate="txtPOCEmail" Display="Dynamic" EnableClientScript="true" Text="Please Enter Client Name"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowPOCPhone" runat="server">
                <asp:TableCell>
                    <asp:Label ID="Label7" runat="server" Text="Client Person of Contact Phone" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtPOCPhone" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" TextMode="Phone" placeholder="Enter Client POC Phone"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" InitialValue="*" ControlToValidate="txtPOCPhone" Display="Dynamic" EnableClientScript="true" Text="Please Enter Client POC Phone Number"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowSubmit" runat="server">
                <asp:TableCell>
                    
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="btnSave" runat="server" Text="SAVE" onclick="btnSave_Click" Width="70px" Height="30px" style="margin:5px;padding:5px;" />
                    <asp:Button ID="btnClear" runat="server" Text="CLEAR" onclick="btnClear_Click" Width="70px" Height="30px" style="margin:5px;padding:5px;" />
                </asp:TableCell>
                <asp:TableCell>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" InitialValue="*" ControlToValidate="txtClientName" Display="Dynamic" EnableClientScript="true" Text="Please Enter Client Name"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <br />
    </asp:Panel>
 <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
    <ContentTemplate>
        
    </ContentTemplate>
    <Triggers>
        <%--<asp:AsyncPostBackTrigger ControlID="DetailsView1" EventName="btnCancel_Click" EventName="RowCommand" />--%>
    </Triggers>
        </asp:UpdatePanel>

        

</asp:Content>
