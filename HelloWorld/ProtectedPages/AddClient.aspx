<%@ Page Title="Portal - Add Client" Language="C#" MasterPageFile="~/MasterPages/SimpleLogin.Master" AutoEventWireup="true" CodeBehind="AddClient.aspx.cs" Inherits="HelloWorld.ProtectedPages.AddCompany" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Styles/bootstrap.min.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" GroupingText=" Add Client " Font-Names="Arial" ForeColor="Navy" Font-Size="Large">
                <div class="container-fluid">
                  <div class="row" id="rowClientName" style="margin-bottom:5px;">
                    <div class="col-sm-4">
                        <asp:Label ID="lblClientName" runat="server" Text="Client Name" Font-Size="Medium" Font-Italic="true" ForeColor="navy"></asp:Label>
                    </div>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txtClientName" runat="server" Width="250px" Height="27px" ForeColor="Black" Font-Size="Medium" Font-Names="Arial" style="border: 1px solid darkgray;background-color:ButtonFace;padding:2px;"></asp:TextBox>
                    </div>
                    <div class="col-sm-3">
                        <asp:RequiredFieldValidator ID="ReqClientName" runat="server" ControlToValidate="txtClientName" ErrorMessage="Enter Client Name." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                    </div>
                  </div>
                  <div class="row" id="rowCLientType" style="margin-bottom:5px;">
                    <div class="col-sm-4">
                        <asp:Label ID="lblClientType" runat="server" Text="Client Type" Font-Size="Medium" Font-Italic="true" ForeColor="navy"></asp:Label>
                    </div>
                    <div class="col-sm-5">
                        <asp:DropDownList ID="dropClientType" runat="server" Width="250px" 
                            Height="27px" BorderStyle="None" 
                            style="border: 1px solid darkgray;background-color:ButtonFace;padding:2px;" Font-Size="Medium"
                            DataSourceID="SqlDataSourceCType" DataTextField="CTYPE_TITLE" AppendDataBoundItems="true"
                            DataValueField="CTYPE_ID">
                                              <asp:ListItem>Select..</asp:ListItem>
                                        </asp:DropDownList>

                        <asp:SqlDataSource ID="SqlDataSourceCType" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
                            SelectCommand="SELECT [CTYPE_ID], [CTYPE_TITLE] FROM [CLIENT_TYPE]">
                        </asp:SqlDataSource>
                    </div>
                    <div class="col-sm-3">
                        <asp:RequiredFieldValidator ID="ReqClientType" runat="server" ControlToValidate="dropClientType" ErrorMessage="Enter Client Type." InitialValue="Select.." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                    </div>
                  </div>
                  <div class="row" id="rowCLientDesc" style="margin-bottom:5px;">
                    <div class="col-sm-4">
                        <asp:Label ID="lblClientDesc" runat="server" Text="Description" Font-Italic="true" ForeColor="Navy" Font-Size="Medium"></asp:Label>
                    </div>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txtClientDesc" CausesValidation="true" runat="server" Width="250px" Height="50px" ForeColor="Black" Font-Names="Arial" Font-Size="Medium" style="border: 1px solid darkgray;background-color:ButtonFace;padding:2px;" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="col-sm-3">
                        <asp:RequiredFieldValidator ID="ReqClientDesc" runat="server" ErrorMessage="Please Enter Client Description" InitialValue="*" Text="*" Display="Dynamic" ControlToValidate="txtClientDesc"></asp:RequiredFieldValidator>
                    </div>
                  </div>
                  <div class="row" id="rowPOCName" style="margin-bottom:5px;">
                    <div class="col-sm-4">
                        <asp:Label ID="lblPOCName" runat="server" Text="Contact Person Name" Font-Italic="true" ForeColor="Navy" Font-Size="Medium"></asp:Label>
                    </div>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txtPOCName" runat="server" Width="250px" Height="27px" ForeColor="Black" Font-Names="Arial" Font-Size="Medium" style="border: 1px solid darkgray;background-color:ButtonFace;padding:2px;" ></asp:TextBox>
                    </div>
                    <div class="col-sm-3">
                        <%--<asp:RequiredFieldValidator ID="ReqPOCName" runat="server" InitialValue="*" ControlToValidate="txtPOCName" Display="Static" EnableClientScript="true" Text="Please Enter POC Name"></asp:RequiredFieldValidator>--%>
                    </div>
                  </div>
                  <div class="row" id="rowPOCEmail" style="margin-bottom:5px;">
                    <div class="col-sm-4">
                        <asp:Label ID="lblPOCEmail" runat="server" Text="Email Address" Font-Italic="true" ForeColor="Navy" Font-Size="Medium"></asp:Label>
                    </div>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txtPOCEmail" runat="server" Width="250px" Height="27px" ForeColor="Black" Font-Names="Arial" Font-Size="Medium" style="border: 1px solid darkgray;background-color:ButtonFace;padding:2px;" TextMode="Email"></asp:TextBox>
                    </div>
                    <div class="col-sm-3">
                        <asp:RequiredFieldValidator ID="ReqPOCEmail" runat="server" InitialValue="*" ControlToValidate="txtPOCEmail" Display="Dynamic" EnableClientScript="true" Text="Please Enter Client Name"></asp:RequiredFieldValidator>
                    </div>
                  </div>
                  <div class="row" id="rowPOCPhone" style="margin-bottom:5px;">
                    <div class="col-sm-4">
                        <asp:Label ID="lblPOCPhone" runat="server" Text="Contact Number" Font-Italic="true" ForeColor="Navy" Font-Size="Medium"></asp:Label>
                    </div>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txtPOCPhone" runat="server" TextMode="Number" Width="250px" Height="27px" ForeColor="Black" Font-Size="Medium" Font-Names="Arial" style="border: 1px solid darkgray;background-color:ButtonFace;padding:2px;"></asp:TextBox>
                    </div>
                    <div class="col-sm-3">
                        <asp:RequiredFieldValidator ID="ReqPOCPhone" runat="server" InitialValue="*" ControlToValidate="txtPOCPhone" Display="Dynamic" EnableClientScript="true" Text="Please Enter Client POC Phone Number"></asp:RequiredFieldValidator>
                    </div>
                  </div>
                  <div class="row" id="rowSubmit" style="margin-bottom:5px;">
                    <div class="col-sm-4">
                        <%--<asp:Label ID="Label2" runat="server" Text="Contact Number" Font-Italic="true" ForeColor="Navy" Font-Size="Medium"></asp:Label>--%>
                    </div>
                    <div class="col-sm-5" style="float:right;">
                        <asp:Button ID="btnSave" class="btn-danger" runat="server" Text="SAVE" onclick="btnSave_Click" Width="100px" Height="30px" style="margin:5px;padding-bottom:15px;" />
                        <asp:Button ID="btnClear" class="btn-danger" runat="server" Text="CLEAR" onclick="btnClear_Click" Width="100px" Height="30px" style="margin:5px;padding-bottom:15px;" />
                    </div>
                    <div class="col-sm-3">
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="*" ControlToValidate="txtPOCPhone" Display="Dynamic" EnableClientScript="true" Text="Please Enter Client POC Phone Number"></asp:RequiredFieldValidator>--%>
                    </div>
                  </div>
                </div>
                <br />
                <br />
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
        <%--<asp:AsyncPostBackTrigger ControlID="DetailsView1" EventName="btnCancel_Click" EventName="RowCommand" />--%>
        </Triggers>
     </asp:UpdatePanel>

</asp:Content>
