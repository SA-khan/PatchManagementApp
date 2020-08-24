<%@ Page Title="Portal - Add Client Type" Language="C#" MasterPageFile="~/MasterPages/SimpleLogin.Master" AutoEventWireup="true" CodeBehind="AddClientType.aspx.cs" Inherits="HelloWorld.ProtectedPages.AddClientType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Styles/bootstrap.min.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" GroupingText=" Add Client Type " ForeColor="Navy" Font-Size="Large">
                <div class="container-fluid">
                  <div class="row" id="rowCTypeTitle" style="margin-bottom:5px;">
                    <div class="col-sm-4">
                        <asp:Label ID="lblCTypeTitle" runat="server" Text="Client Type Title" Font-Italic="true" ForeColor="Navy" Font-Size="Medium"></asp:Label>
                    </div>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txtCTypeTitle" runat="server" Width="250px" Height="27px"  ForeColor="Black" Font-Size="Medium" Font-Names="Arial" style="border: 1px solid darkgray;background-color:ButtonFace;padding:2px;"></asp:TextBox>
                    </div>
                    <div class="col-sm-3">
                        <asp:RequiredFieldValidator ID="ReqCTypeTitle" runat="server" ControlToValidate="txtCTypeTitle" ErrorMessage="Enter Client Type Title." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                    </div>
                  </div>
                  <div class="row" id="rowCTypeDesc" style="margin-bottom:5px;">
                    <div class="col-sm-4">
                        <asp:Label ID="lblCTypeDesc" runat="server" Text="User Client Type Description" Font-Italic="true" ForeColor="Navy" Font-Size="Medium"></asp:Label>
                    </div>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txtCTypeDesc" CausesValidation="true" runat="server" Width="250px" Height="50px" style="border: 1px solid darkgray;background-color:ButtonFace;padding:2px;" TextMode="MultiLine" ForeColor="Black" Font-Names="Arial" Font-Size="Medium"></asp:TextBox>
                    </div>
                    <div class="col-sm-3">
                        <asp:RequiredFieldValidator ID="ReqCTypeDesc" runat="server" ControlToValidate="txtCTypeDesc" ErrorMessage="Enter Client Type Description." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                    </div>
                  </div>
                  <div class="row" id="rowSubmit" style="margin-bottom:5px;">
                    <div class="col-sm-4">
                        <%--<asp:Label ID="Label2" runat="server" Text="Contact Number" Font-Italic="true" ForeColor="Navy" Font-Size="Medium"></asp:Label>--%>
                    </div>
                    <div class="col-sm-5" style="float:right;">
                        <asp:Button ID="btnSave" CssClass="btn-danger" runat="server" Text="SAVE" Width="100px" Height="35px" onclick="btnSave_Click" />
                        <asp:Button ID="btnClear" CssClass="btn-danger" runat="server" Text="CLEAR" Width="100px" Height="35px" onclick="btnClear_Click" />
                    </div>
                    <div class="col-sm-3">
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="*" ControlToValidate="txtPOCPhone" Display="Dynamic" EnableClientScript="true" Text="Please Enter Client POC Phone Number"></asp:RequiredFieldValidator>--%>
                    </div>
                  </div>
                </div>
                <br />
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
        <%--<asp:AsyncPostBackTrigger ControlID="DetailsView1" EventName="btnCancel_Click" EventName="RowCommand" />--%>
        </Triggers>
    </asp:UpdatePanel>   
</asp:Content>
