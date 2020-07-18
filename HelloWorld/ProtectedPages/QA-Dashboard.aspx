<%@ Page Title="Portal - QA Dashboard" Language="C#" MasterPageFile="~/SiteLogout.Master" AutoEventWireup="true" CodeBehind="QA-Dashboard.aspx.cs" Inherits="HelloWorld.ProtectedPages.QA_Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:Wizard ID="Wizard1" runat="server">
        <WizardSteps>
            <asp:WizardStep ID="WizardStep1" runat="server" Title="New Releases Patch">
                <asp:Panel ID="Panel1" runat="server" Height="200" Width="200" BackColor="Yellow">
                    
                </asp:Panel>
            </asp:WizardStep>
            <asp:WizardStep ID="WizardStep2" runat="server" Title="Checked Releases Patch">
                <asp:Panel ID="Panel2" runat="server" Height="200" Width="200" BackColor="Blue">
                    
                </asp:Panel>
            </asp:WizardStep>
            <asp:WizardStep ID="WizardStep3" runat="server" Title="Passed Releases Patch">
                <asp:Panel ID="Panel3" runat="server" Height="200" Width="200" BackColor="Green">
                    
                </asp:Panel>
            </asp:WizardStep>
        </WizardSteps>
    </asp:Wizard>
</asp:Content>
