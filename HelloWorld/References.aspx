<%@ Page Title="Portal - References" Language="C#" MasterPageFile="~/MasterPages/Layer1.Master" AutoEventWireup="true" CodeBehind="References.aspx.cs" Inherits="HelloWorld.References" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Images/icon.ico" rel="Shortcut Icon" />
    <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="card bg-light text-dark">
    <br />
    <br />
    <br />
    <div class="card-body">
        <h1  class="card-title">References & Docs</h1>


        <div id="div_upload" runat="server" class="card bg-light text-dark">
            <div class="card-body">
                <%--<h3 class="card-text">Upload A File</h3> --%>
                <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal">UPLOAD FILE</button>
                
            </div>
        </div>

        <br />

        <div id="div_view" runat="server" class="card bg-light text-dark">
            <div class="card-body">
                <%--<h3 class="card-text">View Files & Documents</h3> --%>
                <asp:Button ID="btnView" runat="server" Text="VIEW REFERENCES & DOCUMENTS" class="btn btn-primary" onclick="btnView_Click" />
            </div>
        </div>

    </div>
  </div>

   <!-- The Modal -->
  <div class="modal fade" id="myModal" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
      <div class="modal-content">
      
        <!-- Modal Header -->
        <div class="modal-header">
          <h4 class="modal-title">Upload A File</h4>
          <button type="button" class="close" data-dismiss="modal">×</button>
        </div>
        
        <!-- Modal body -->
        <div class="modal-body">
            <asp:Panel ID="Panel1" runat="server" Width="100%">
                <asp:Table ID="Table1" runat="server" Width="100%">
                    <asp:TableRow>
                        <asp:TableCell>File Name: </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtFileTitle" runat="server" Width="100%"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>File Description: </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtFileDesc" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell> </asp:TableCell>
                        <asp:TableCell>
                            <asp:FileUpload ID="FileUpload1" runat="server" Width="100%"/>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:Panel>
        </div>
        
        <!-- Modal footer -->
        <div class="modal-footer">
          <asp:Button ID="btnUpload" runat="server" class="btn btn-primary" Text="UPLOAD" onclick="btnUpload_Click" />
          <button type="button" class="btn btn-danger" data-dismiss="modal">Cancel</button>
        </div>
        
      </div>
    </div>
  </div>

  <!-- The Modal -->
  <div class="modal fade" id="Div1">
    <div class="modal-dialog">
      <div class="modal-content">
      
        <!-- Modal Header -->
        <div class="modal-header">
          <h4 class="modal-title">Upload Information</h4>
          <button type="button" class="close" data-dismiss="modal">×</button>
        </div>
        
        <!-- Modal body -->
        <div class="modal-body">
            <asp:Label ID="lblHeading" runat="server" Font-Bold="false" Text="Heading"></asp:Label>
            <asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label>
        </div>
        
        <!-- Modal footer -->
        <div class="modal-footer">
          <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
        </div>
        
      </div>
    </div>
  </div>

  <div id="div2" runat="server" class="card bg-light text-dark">
            <div class="card-body">
    <asp:Panel ID="Panel2" runat="server" ScrollBars="Auto">
    <asp:GridView ID="GridView1" runat="server" style="margin:4px;" HeaderStyle-BackColor="black" HeaderStyle-ForeColor="white" HeaderStyle-Height="45px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="250px" HeaderStyle-VerticalAlign="Middle" AlternatingRowStyle-BackColor="Gray">
    </asp:GridView>  
    </asp:Panel>
    </div>
  </div>
    
</asp:Content>
