<%@ Page Title="Portal - Add Release" Language="C#" MasterPageFile="~/SiteLogout.Master" AutoEventWireup="true" CodeBehind="AddRelease.aspx.cs" ViewStateMode="Enabled" Inherits="HelloWorld.ProtectedPages.AddPatch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
<meta name='viewport' content='width=device-width, initial-scale=1'>
<script src='https://kit.fontawesome.com/a076d05399.js'></script>

<link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="/resources/demos/style.css">
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

  <script type="text/javascript">
      $(function () {
          var availableTags = [
      "ActionScript",
      "AppleScript",
      "Asp",
      "BASIC",
      "C",
      "C++",
      "Clojure",
      "COBOL",
      "ColdFusion",
      "Erlang",
      "Fortran",
      "Groovy",
      "Haskell",
      "Java",
      "JavaScript",
      "Lisp",
      "Perl",
      "PHP",
      "Python",
      "Ruby",
      "Scala",
      "Scheme"
    ];
          $("#txtPatchDeployedBy").autocomplete({
              source: availableTags
          });
      });
  </script>

<style type="text/css">
    .sd-container {
  position: relative;
  float: left;
}

.sd {
  border: 1px solid #1cbaa5;
  padding: 5px 10px;
  height: 30px;
  width: 150px;
}

.open-button {
  position: absolute;
  top: 10px;
  right: 3px;
  width: 25px;
  height: 25px;
  background: #fff;
  pointer-events: none;
}

.open-button button {
  border: none;
  background: transparent;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server" class="container">
    <asp:Panel ID="Panel1" runat="server" class="border">
        <asp:Table ID="Table1" runat="server" Width="100%" BackColor="Menu" BorderStyle="Solid" BorderColor="DarkGray" BorderWidth="2px" HorizontalAlign="Center" CellSpacing="5" CellPadding="5" style="margin:5px;padding:5px;">
            <asp:TableHeaderRow Height="40px">
                <asp:TableHeaderCell ColumnSpan="3" HorizontalAlign="Left" style="margin:5px;padding:5px;">
                    <asp:Label ID="Label1" runat="server" Text="Add A Release.." Font-Italic="true" ForeColor="Black" Font-Names="Arial" Font-Size="Large"></asp:Label>
                    <asp:ValidationSummary ID="ValidationSummary1" EnableClientScript="true" DisplayMode="BulletList" HeaderText="Please Enter Following Fields: " ShowMessageBox="true" runat="server" ForeColor="Red" ShowSummary="False" />
                    <br />
                    <br />
                    <asp:Label ID="lblSubmission" runat="server" Text="Release is successfully added." Font-Italic="true" ForeColor="Navy" Font-Names="Arial" Font-Size="Medium" Visible="false"></asp:Label>
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow ID="rowPatchTitle" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="Label2" runat="server" Text="Release Title" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtPatchTitle" class="sd" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter Patch Title Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:RequiredFieldValidator ID="ReqPatchTitle" runat="server" ControlToValidate="txtPatchTitle" ErrorMessage="Enter Patch Title." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowPatchDesc" runat="server">
                <asp:TableCell VerticalAlign="Top">
                    <asp:Label ID="lblPatchDesc" runat="server" Text="Release Description" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtPatchDesc" class="sd" CausesValidation="true" runat="server" Width="250px" Height="50px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" TextMode="MultiLine" placeholder="Enter Patch Description Here" Font-Names="Arial"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="ReqPatchDesc" runat="server" ErrorMessage="Please Enter Patch Description" Text="(Required)" ControlToValidate="txtPatchDesc" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowPatchNumber" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblPatchNumber" runat="server" Text="Release Number" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtPatchNumber" class="sd" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter Patch Number Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:RequiredFieldValidator ID="ReqPatchNumber" runat="server" ControlToValidate="txtPatchNumber" ErrorMessage="Enter Patch Number." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowPatchDeployedBy" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblPatchDeployedBy" runat="server" Text="Deployed By" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <%--<asp:TextBox ID="txtPatchDeployedBy"  class="sd" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter Patch Deployed By Here"></asp:TextBox>--%>
                    <asp:TextBox ID="txtPatchDeployedBy"  class="sd" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter Patch Deployed By Here" AutoCompleteType="Search"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:RequiredFieldValidator ID="ReqPatchDeployedBy" runat="server" ControlToValidate="txtPatchDeployedBy" ErrorMessage="Enter Patch Deployed By Field." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowPatchCreatedDate" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblPatchCreatedDate" runat="server" Text="Created Date" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <form>
                        <div class="sd-container">
                            <asp:TextBox ID="txtPatchCreatedDate" class="sd" name="selected_date" type="date" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter Patch Deployed Date Here"></asp:TextBox>
                                <span class="open-button">
                                    <button type="button">📅</button>
                                </span>
                        </div>
                    </form>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:RequiredFieldValidator ID="ReqPatchCreatedDate" runat="server" ControlToValidate="txtPatchDeployedBy" ErrorMessage="Enter Patch Created Date." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowPatchDeployedDate" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblPatchDeployedDate" runat="server" Text="Deployed Date" Font-Italic="true" ForeColor="Black" ViewStateMode="Enabled"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <%--<asp:TextBox ID="txtPatchDeployedDate" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter Patch Deployed Date Here"></asp:TextBox>--%>
                    <form>
                        <div class="sd-container" runat="server">
                            <%--<asp:TextBox ID="txtPatchDeployedDate" class="sd" name="selected_date" type="date" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter Patch Deployed Date Here" ViewStateMode="Enabled"></asp:TextBox>--%>
                            <asp:TextBox ID="txtPatchDeployedDate" class="sd" name="selected_date" type="date" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter Patch Deployed Date Here" ViewStateMode="Enabled" EnableViewState="true"></asp:TextBox>
                                
                                <span class="open-button">
                                    <button type="button">📅</button>
                                </span>
                        </div>
                    </form>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:RequiredFieldValidator ID="ReqPatchDeployedDate" runat="server" ControlToValidate="txtPatchDeployedDate" ErrorMessage="Enter Patch Deployed Date." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowPatchIsQAPassed" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblPatchIsQAPassed" runat="server" Text="Is Patch QA Passed" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <%--<asp:TextBox ID="txtPatchIsQAPassed" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter Patch Is QA Passed Here"></asp:TextBox>--%>
                    <%--<asp:CheckBoxList runat="server" AutoPostBack="true">--%>
                    <asp:CheckBox ID="checkIsQAPassedYes" runat="server" TextAlign="Right" Text="Passed" ForeColor="black" Font-Size="Medium" />
                    <asp:CheckBox ID="checkIsQAPassedNo" runat="server" TextAlign="Right" Text="Failed" ForeColor="black" Font-Size="Medium" />
                    <asp:CheckBox ID="checkIsQAPassedNotTested" runat="server" TextAlign="Right" Text="Not Tested" ForeColor="black" Font-Size="Medium" />
                    <%--</asp:CheckBoxList>--%>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <%--<asp:RequiredFieldValidator ID="ReqPatchIsQAPassed" runat="server" ControlToValidate="txtPatchIsQAPassed" ErrorMessage="Please Check Patch Is QA Passed" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowPatchDependency" runat="server">
                <asp:TableCell Width="30%">
                    <asp:Label ID="lblPatchDependency" runat="server" Text="Release Dependency" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtPatchDependency" class="sd" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" Font-Names="Arial" placeholder="Enter Enter Patch Dependency Here"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:RequiredFieldValidator ID="ReqPatchDependency" runat="server" ControlToValidate="txtPatchDependency" ErrorMessage="Please enter Patch Dependency" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowPatchClientName" runat="server">
                <asp:TableCell>
                    <asp:Label ID="lblPatchClientName" runat="server" Text="Client Name" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <%--<asp:TextBox ID="txtPatchClientName" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" placeholder="Enter Patch Client Name Here"></asp:TextBox>--%>
                    <asp:DropDownList ID="dropPatchClientName" class="sd" runat="server" BackColor="ButtonFace"
        Width="250px" Height="27px" Font-Italic="true" Font-Size="Medium" 
            Font-Names="Arial" ForeColor="black"
        DataSourceID="SqlDataSource2" DataTextField="ClientName" style="text-align=center"
        DataValueField="ClientID" AutoPostBack="true" ViewStateMode="Enabled" 
        AppendDataBoundItems="True" 
            onselectedindexchanged="dropPatchClientName_SelectedIndexChanged">
        <asp:ListItem>Select..</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
        SelectCommand="SELECT [ClientID],[ClientName] FROM [ClientDetail]"></asp:SqlDataSource>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="ReqPatchClientName" runat="server" InitialValue="Select.." ControlToValidate="dropPatchClientName"  ErrorMessage="Please Select Client Name" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowProductName" runat="server" Visible="false">
                <asp:TableCell>
                    <asp:Label ID="lblProductName" runat="server" Text="Product Name" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <%--<asp:TextBox ID="txtProductName" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" TextMode="Email" placeholder="Enter Product Name Here"></asp:TextBox>--%>
                    <asp:DropDownList ID="dropProductName" class="sd" runat="server" BackColor="ButtonFace"
        Width="250px" Height="27px" Font-Italic="true" Font-Size="Medium" 
            Font-Names="Arial" ForeColor="black"
        DataSourceID="SqlDataSource1" DataTextField="ProductName" style="text-align=center"
        DataValueField="ProductID" AutoPostBack="true" ViewStateMode="Enabled" 
        AppendDataBoundItems="True" 
            onselectedindexchanged="dropProductName_SelectedIndexChanged">
        <asp:ListItem>SELECT..</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
        SelectCommand="SELECT [ProductID],[ProductName] FROM [Products] P INNER JOIN ENVIRONMENT E ON P.ProductID = E.AppServerEnvType"></asp:SqlDataSource>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="ReqProductName" runat="server" InitialValue="SELECT.." ControlToValidate="dropProductName" Display="Dynamic" EnableClientScript="true" Text="(Required)" ForeColor="Red" Font-Bold="true" ErrorMessage="Please Select Product Name"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowEnvironmentType" runat="server" Visible="false">
                <asp:TableCell>
                    <asp:Label ID="lblEnvironmentType" runat="server" Text="Environment Type" Font-Italic="true" ForeColor="Black"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <%--<asp:TextBox ID="txtEnvironmentType" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border-bottom: 2px solid navy;background-color:white;" TextMode="Phone" placeholder="Enter Environment Type Here"></asp:TextBox>--%>
                    <asp:DropDownList ID="dropEnvironmentType" runat="server" BackColor="ButtonFace"
        Width="250px" Font-Italic="true" Font-Size="Medium" Font-Names="Arial" ForeColor="black"
        DataSourceID="SqlDataSource3" DataTextField="ENV_TITLE" style="border: 1px solid #1cbaa5;padding: 5px 10px;height: 30px;text-align=center" ondatabinding="DropDownList1_DataBinding"
        DataValueField="ENV_ID" AutoPostBack="false" ViewStateMode="Enabled" ondatabound="DropDownList1_DataBound"
        AppendDataBoundItems="True">
        <asp:ListItem>SELECT..</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ApplicationServices %>"></asp:SqlDataSource>
        <%--SelectCommand="SELECT E.ENV_ID,CONCAT('Client: ',C.ClientName,', Product: ',P.ProductName,', Environment: ',ET.EnvTitle, '') As Env_Title from (((Environment E Inner Join ClientDetail C on E.ENV_Client_ID = C.ClientID) INNER JOIN Products P On E.ENV_Product_ID = P.ProductID ) INNER JOIN EnvironmentType ET ON ET.EnvID = E.ENV_AppServerEnvironmentType)"--%>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="ReqEnvironmentType" runat="server" ControlToValidate="dropEnvironmentType" ErrorMessage="Please Select Environment Type" InitialValue="SELECT.." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
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
