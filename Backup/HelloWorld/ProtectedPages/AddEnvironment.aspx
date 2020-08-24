<%@ Page Title="Portal - Add Environment" Language="C#" MasterPageFile="~/SiteLogout.Master" AutoEventWireup="true" CodeBehind="AddEnvironment.aspx.cs" Inherits="HelloWorld.ProtectedPages.AddClientEnvironment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="../Scripts/bootstrap.min.js" type="text/javascript"></script>
    <link href="../Styles/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-3.5.1.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server">

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

            <%--<!-- start affix -->
        <div class="col-md-6 js-content">--%>

                <asp:Panel ID="pnlEnvironment" runat="server" GroupingText="Add Environment" BorderColor="Navy" Font-Size="Large" Font-Names="Arial" ForeColor="Navy">
        <div class="container-fluid">
        
          <div class="row" id="rowClientName" style="margin-bottom:5px;">
            <div class="col-sm-5">
                <asp:Label ID="lblClientName" runat="server" Text="Client Name" Font-Size="Medium" Font-Italic="true" ForeColor="navy"></asp:Label>
            </div>
            <div class="col-sm-5">
                <asp:DropDownList ID="dropClientName" runat="server" BackColor="ButtonFace" Width="250px" Height="27px" Font-Italic="true" Font-Size="Medium" Font-Names="Arial" ForeColor="black" DataSourceID="SqlDataSource4" DataTextField="ClientName" DataValueField="ClientID" AutoPostBack="true" ViewStateMode="Enabled" AppendDataBoundItems="True" style="text-align:center;">
                        <asp:ListItem>Select..</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" SelectCommand="SELECT [ClientID],[ClientName] FROM [ClientDetail]"></asp:SqlDataSource>
            </div>
            <div class="col-sm-2">
                <asp:RequiredFieldValidator ID="ReqClientName" runat="server" InitialValue="Select.." ControlToValidate="dropClientName" ErrorMessage="Select Client Name." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
            </div>
          </div>
          <div class="row" id="rowProductName" style="margin-bottom:5px;">
            <div class="col-sm-5">
                <asp:Label ID="lblProductName" runat="server" Text="Product Name" Font-Size="Medium" Font-Italic="true" ForeColor="navy"></asp:Label>
            </div>
            <div class="col-sm-5">
                <asp:DropDownList ID="dropProductName" runat="server" BackColor="ButtonFace" Width="250px" Height="27px" Font-Italic="true" Font-Size="Medium" Font-Names="Arial" ForeColor="black" DataSourceID="ProductSource" DataTextField="ProductName" DataValueField="ProductID" AutoPostBack="true" ViewStateMode="Enabled" AppendDataBoundItems="True" style="text-align:center;">
                        <asp:ListItem>Select..</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="ProductSource" runat="server" ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" SelectCommand="SELECT [ProductID],[ProductName] FROM [Products]"></asp:SqlDataSource>
            </div>
            <div class="col-sm-2">
                <asp:RequiredFieldValidator ID="ReqProductName" runat="server" InitialValue="Select.." ControlToValidate="dropProductName" Display="Dynamic" EnableClientScript="true" Text="(Required)" ForeColor="Red" Font-Bold="true" ErrorMessage="Select Product Name."></asp:RequiredFieldValidator>
            </div>
          </div>
          <div class="row" id="rowAppEnvType" style="margin-bottom:5px;">
            <div class="col-sm-5">
                <asp:Label ID="lblAppEnvType" runat="server" Text="Environment Type" Font-Size="Medium" Font-Italic="true" ForeColor="navy"></asp:Label>
            </div>
            <div class="col-sm-5">
                <asp:DropDownList ID="dropAppEnvType" runat="server" BackColor="ButtonFace" Width="250px" Height="27px" Font-Italic="true" Font-Size="Medium" Font-Names="Arial" ForeColor="black" DataSourceID="SqlDataSource2" DataTextField="EnvTitle" DataValueField="EnvID" AutoPostBack="true" ViewStateMode="Enabled" AppendDataBoundItems="True" style="text-align:center;">
                        <asp:ListItem>Select..</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" SelectCommand="SELECT [EnvID],[EnvTitle] FROM [EnvironmentType]"></asp:SqlDataSource>
            </div>
            <div class="col-sm-2">
                <asp:RequiredFieldValidator ID="ReqAppEnvType" runat="server" InitialValue="Select.." ControlToValidate="dropAppEnvType" ErrorMessage="Select Application Environment Type." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
            </div>
          </div>
          <div class="row" id="rowDBEnvType" style="margin-bottom:5px;">
            <div class="col-sm-5">
                <asp:Label ID="lblDBEnvType" runat="server" Text="Database Environment Type" Font-Size="Medium" Font-Italic="true" ForeColor="navy"></asp:Label>
            </div>
            <div class="col-sm-5">
                <asp:DropDownList ID="dropDBEnvType" runat="server" BackColor="ButtonFace" Width="250px" Height="27px" Font-Italic="true" Font-Size="Medium" Font-Names="Arial" ForeColor="black" DataSourceID="SqlDataSource2" DataTextField="EnvTitle" DataValueField="EnvID" AutoPostBack="true" ViewStateMode="Enabled" AppendDataBoundItems="True" style="text-align:center;">
                        <asp:ListItem>Select..</asp:ListItem>
                    </asp:DropDownList>
            </div>
            <div class="col-sm-2">
                <asp:RequiredFieldValidator ID="ReqDBEnvType" runat="server" InitialValue="Select.." ControlToValidate="dropDBEnvType" ErrorMessage="Select Database Environment Type." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
            </div>
          </div>
          <div class="row" id="rowAppServerName" style="margin-bottom:5px;">
            <div class="col-sm-5">
                <asp:Label ID="lblAppServerName" runat="server" Text="Application Server Name" Font-Size="Medium" Font-Italic="true" ForeColor="navy"></asp:Label>
            </div>
            <div class="col-sm-5">
                <asp:TextBox ID="txtAppServerName" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border: 1px solid darkgray;background-color:ButtonFace;padding:2px;" ForeColor="Black" Font-Names="Arial"></asp:TextBox>
            </div>
            <div class="col-sm-2">
                <asp:RequiredFieldValidator ID="ReqAppServerName" runat="server" ControlToValidate="txtAppServerName" ErrorMessage="Enter Application Server Name." Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
            </div>
          </div>
          <div class="row" id="rowAppServerOS" style="margin-bottom:5px;">
            <div class="col-sm-5">
                <asp:Label ID="lblAppServerOS" runat="server" Text="Application Server OS" Font-Size="Medium" Font-Italic="true" ForeColor="navy"></asp:Label>
            </div>
            <div class="col-sm-5">
                <asp:TextBox ID="txtAppServerOS" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border: 1px solid darkgray;background-color:ButtonFace;padding:2px;" ForeColor="Black" Font-Names="Arial"></asp:TextBox>
            </div>
            <div class="col-sm-2">
                
            </div>
          </div>
          <div class="row" id="rowAppServerOSBuild" style="margin-bottom:15px;">
            <div class="col-sm-5">
                <asp:Label ID="lblAppServerOSBuild" runat="server" Text="Application Server OS Build" Font-Size="Medium" Font-Italic="true" ForeColor="navy"></asp:Label>
            </div>
            <div class="col-sm-5">
                <asp:DropDownList ID="dropAppServerOSBuild" runat="server" BackColor="ButtonFace" Width="250px" Height="27px" Font-Italic="true" Font-Size="Medium" Font-Names="Arial" ForeColor="black" ViewStateMode="Enabled" AppendDataBoundItems="True" style="text-align:center;">
                            <asp:ListItem>Select..</asp:ListItem>
                            <asp:ListItem>	511	</asp:ListItem>
                            <asp:ListItem>	528	</asp:ListItem>
                            <asp:ListItem>	807	</asp:ListItem>
                            <asp:ListItem>	950	</asp:ListItem>
                            <asp:ListItem>	1057	</asp:ListItem>
                            <asp:ListItem>	1106	</asp:ListItem>
                            <asp:ListItem>	1381	</asp:ListItem>
                            <asp:ListItem>	1998	</asp:ListItem>
                            <asp:ListItem>	2195	</asp:ListItem>
                            <asp:ListItem>	2222	</asp:ListItem>
                            <asp:ListItem>	2600	</asp:ListItem>
                            <asp:ListItem>	2600	</asp:ListItem>
                            <asp:ListItem>	3000	</asp:ListItem>
                            <asp:ListItem>	3790	</asp:ListItem>
                            <asp:ListItem>	3790	</asp:ListItem>
                            <asp:ListItem>	3790	</asp:ListItem>
                            <asp:ListItem>	4500	</asp:ListItem>
                            <asp:ListItem>	6000	</asp:ListItem>
                            <asp:ListItem>	6001	</asp:ListItem>
                            <asp:ListItem>	6001	</asp:ListItem>
                            <asp:ListItem>	6002	</asp:ListItem>
                            <asp:ListItem>	6002	</asp:ListItem>
                            <asp:ListItem>	6003	</asp:ListItem>
                            <asp:ListItem>	7600	</asp:ListItem>
                            <asp:ListItem>	7600	</asp:ListItem>
                            <asp:ListItem>	7601	</asp:ListItem>
                            <asp:ListItem>	7601	</asp:ListItem>
                            <asp:ListItem>	8400	</asp:ListItem>
                            <asp:ListItem>	9200	</asp:ListItem>
                            <asp:ListItem>	9200	</asp:ListItem>
                            <asp:ListItem>	9600	</asp:ListItem>
                            <asp:ListItem>	9600	</asp:ListItem>
                            <asp:ListItem>	10240	</asp:ListItem>
                            <asp:ListItem>	10586	</asp:ListItem>
                            <asp:ListItem>	14393	</asp:ListItem>
                            <asp:ListItem>	14393	</asp:ListItem>
                            <asp:ListItem>	15063	</asp:ListItem>
                            <asp:ListItem>	16299	</asp:ListItem>
                            <asp:ListItem>	16299	</asp:ListItem>
                            <asp:ListItem>	17134	</asp:ListItem>
                            <asp:ListItem>	17763	</asp:ListItem>
                            <asp:ListItem>	17763	</asp:ListItem>
                            <asp:ListItem>	18362	</asp:ListItem>
                            <asp:ListItem>	18363	</asp:ListItem>
                    </asp:DropDownList>
            </div>
            <div class="col-sm-2">
                
            </div>
          </div>
          <div class="row" id="rowAppServerIsX86" style="margin-bottom:15px;">
            <div class="col-sm-5">
                <asp:Label ID="lblAppServerIsX86" runat="server" Text="App Server Version" Font-Size="Medium" Font-Italic="true" ForeColor="navy"></asp:Label>
            </div>
            <div class="col-sm-5">
                <asp:RadioButtonList ID="radAppServerIsX86" runat="server" ForeColor="black" Font-Size="Small">
                        <asp:ListItem Value="1">x86 Bit</asp:ListItem>
                        <asp:ListItem Value="0" Selected="True">x64 Bit</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="col-sm-2">
                
            </div>
          </div>
          <div class="row" id="rowAppServerIsVirtual" style="margin-bottom:5px;">
            <div class="col-sm-5">
                <asp:Label ID="lblAppServerIsVirtual" runat="server" Text="App Server Environment" Font-Size="Medium" Font-Italic="true" ForeColor="navy"></asp:Label>
            </div>
            <div class="col-sm-5">
                <asp:RadioButtonList ID="radAppServerIsVirtual" runat="server" AppendDataBoundItems="true" ForeColor="black" Font-Size="Small">
                        <asp:ListItem Value="0">Physical Machine</asp:ListItem>
                        <asp:ListItem Value="1" Selected="True">Virtual Machine</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="col-sm-2">
                
            </div>
          </div>
          <div class="row" id="rowAppServerProcessor" style="margin-bottom:5px;">
            <div class="col-sm-5">
                <asp:Label ID="lblAppServerProcessor" runat="server" Text="App Server Processor" Font-Size="Medium" Font-Italic="true" ForeColor="navy"></asp:Label>
            </div>
            <div class="col-sm-5">
                <asp:TextBox ID="txtAppServerProcessor" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border: 1px solid darkgray;background-color:ButtonFace;padding:2px;" ForeColor="Black" Font-Names="Arial"></asp:TextBox>
            </div>
            <div class="col-sm-2">
                
            </div>
          </div>
          <div class="row" id="rowAppServerMemory" style="margin-bottom:5px;">
            <div class="col-sm-5">
                <asp:Label ID="lblAppServerMemory" runat="server" Text="App Server Memory" Font-Size="Medium" Font-Italic="true" ForeColor="navy"></asp:Label>
            </div>
            <div class="col-sm-5">
                <asp:DropDownList ID="dropAppServerMemory" runat="server" BackColor="ButtonFace" Width="250px" Height="27px" Font-Italic="true" Font-Size="Medium" Font-Names="Arial" ForeColor="black" AutoPostBack="true" ViewStateMode="Enabled" AppendDataBoundItems="True" style="text-align:center;">
                        <asp:ListItem>Select..</asp:ListItem>
                        <asp:ListItem Value="1">1 GB</asp:ListItem>
                        <asp:ListItem Value="2">2 GB</asp:ListItem>
                        <asp:ListItem Value="4">4 GB</asp:ListItem>
                        <asp:ListItem Value="6">6 GB</asp:ListItem>
                        <asp:ListItem Value="8">8 GB</asp:ListItem>
                        <asp:ListItem Value="10">10 GB</asp:ListItem>
                        <asp:ListItem Value="12">12 GB</asp:ListItem>
                        <asp:ListItem Value="16">16 GB</asp:ListItem>
                        <asp:ListItem Value="32">32 GB</asp:ListItem>
                        <asp:ListItem Value="64">64 GB</asp:ListItem>
                        <asp:ListItem Value="128">128 GB</asp:ListItem>
                        <asp:ListItem Value="256">256 GB</asp:ListItem>
                        <asp:ListItem Value="512">512 GB</asp:ListItem>
                        <asp:ListItem Value="1024">1 TB</asp:ListItem>
                    </asp:DropDownList>
            </div>
            <div class="col-sm-2">
                
            </div>
          </div>
          <div class="row" id="rowAppServerWebBrowser" style="margin-bottom:5px;">
            <div class="col-sm-5">
                <asp:Label ID="lblAppServerWebBrowser" runat="server" Text="App Server Web Browser" Font-Size="Medium" Font-Italic="true" ForeColor="navy"></asp:Label>
            </div>
            <div class="col-sm-5">
                <asp:DropDownList ID="dropAppServerWebBrowser" runat="server" BackColor="ButtonFace" Width="250px" Height="27px" Font-Italic="true" Font-Size="Medium" Font-Names="Arial" ForeColor="black" AutoPostBack="true" ViewStateMode="Enabled" AppendDataBoundItems="True" style="text-align:center;">
                        <asp:ListItem>Select..</asp:ListItem>
                        <asp:ListItem>	AOLserver	</asp:ListItem>
                        <asp:ListItem>	Apache HTTP Server	</asp:ListItem>
                        <asp:ListItem>	Apache Tomcat	</asp:ListItem>
                        <asp:ListItem>	Boa	</asp:ListItem>
                        <asp:ListItem>	Caddy	</asp:ListItem>
                        <asp:ListItem>	Caudium	</asp:ListItem>
                        <asp:ListItem>	Cherokee HTTP Server	</asp:ListItem>
                        <asp:ListItem>	GlassFish	</asp:ListItem>
                        <asp:ListItem>	Hiawatha	</asp:ListItem>
                        <asp:ListItem>	HFS	</asp:ListItem>
                        <asp:ListItem>	IBM HTTP Server	</asp:ListItem>
                        <asp:ListItem>Internet Information Services</asp:ListItem>
                        <asp:ListItem>	Jetty	</asp:ListItem>
                        <asp:ListItem>	Jexus	</asp:ListItem>
                        <asp:ListItem>	lighttpd	</asp:ListItem>
                        <asp:ListItem>	LiteSpeed Web Server	</asp:ListItem>
                        <asp:ListItem>	Mongoose	</asp:ListItem>
                        <asp:ListItem>	Monkey HTTP Server	</asp:ListItem>
                        <asp:ListItem>	NaviServer	</asp:ListItem>
                        <asp:ListItem>	NCSA HTTPd	</asp:ListItem>
                        <asp:ListItem>	Nginx	</asp:ListItem>
                        <asp:ListItem>	OpenLink Virtuoso	</asp:ListItem>
                        <asp:ListItem>	Oracle HTTP Server	</asp:ListItem>
                        <asp:ListItem>	Oracle iPlanet Web Server	</asp:ListItem>
                        <asp:ListItem>	Oracle WebLogic Server	</asp:ListItem>
                        <asp:ListItem>	Resin Open Source	</asp:ListItem>
                        <asp:ListItem>	Resin Professional	</asp:ListItem>
                        <asp:ListItem>	thttpd	</asp:ListItem>
                        <asp:ListItem>	TUX web server	</asp:ListItem>
                        <asp:ListItem>	Wakanda Server	</asp:ListItem>
                        <asp:ListItem>	WEBrick	</asp:ListItem>
                        <asp:ListItem>	Xitami	</asp:ListItem>
                        <asp:ListItem>	Yaws	</asp:ListItem>
                        <asp:ListItem>	Zeus Web Server	</asp:ListItem>
                        <asp:ListItem>	Zope	</asp:ListItem>
                    </asp:DropDownList>
            </div>
            <div class="col-sm-2">
                
            </div>
          </div>
          <div class="row" id="rowAppServerWebBrowserVersion" style="margin-bottom:5px;">
            <div class="col-sm-5">
                <asp:Label ID="lblAppServerWebBrowserVersion" runat="server" Text="App Server Web Browser Version" Font-Size="Medium" Font-Italic="true" ForeColor="navy"></asp:Label>
            </div>
            <div class="col-sm-5">
                <asp:TextBox ID="txtAppServerWebBrowserVersion" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border: 1px solid darkgray;background-color:ButtonFace;padding:2px;" ForeColor="Black" Font-Names="Arial"></asp:TextBox>
            </div>
            <div class="col-sm-2">
                
            </div>
          </div>
          <div class="row" id="rowAppServerWorkingDirectoryLocation" style="margin-bottom:5px;">
            <div class="col-sm-5">
                <asp:Label ID="lblAppServerWorkingDirectoryLocation" runat="server" Text="App Working Directory Location" Font-Size="Medium" Font-Italic="true" ForeColor="navy"></asp:Label>
            </div>
            <div class="col-sm-5">
                <asp:TextBox ID="txtAppServerWorkingDirectoryLocation" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border: 1px solid darkgray;background-color:ButtonFace;padding:2px;" ForeColor="Black" Font-Names="Arial"></asp:TextBox>
            </div>
            <div class="col-sm-2">
                
            </div>
          </div>
          <div class="row" id="rowAppHyperLink" style="margin-bottom:5px;">
            <div class="col-sm-5">
                <asp:Label ID="lblAppHyperLink" runat="server" Text="App Hyper Link" Font-Size="Medium" Font-Italic="true" ForeColor="navy"></asp:Label>
            </div>
            <div class="col-sm-5">
                <asp:TextBox ID="txtAppHyperLink" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border: 1px solid darkgray;background-color:ButtonFace;padding:2px;" ForeColor="Black" Font-Names="Arial"></asp:TextBox>
            </div>
            <div class="col-sm-2">
                
            </div>
          </div>
          <div class="row" id="rowAppServerIP" style="margin-bottom:5px;">
            <div class="col-sm-5">
                <asp:Label ID="lblAppServerIP" runat="server" Text="App Server IP" Font-Size="Medium" Font-Italic="true" ForeColor="navy"></asp:Label>
            </div>
            <div class="col-sm-5">
                <asp:TextBox ID="txtAppServerIP" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border: 1px solid darkgray;background-color:ButtonFace;padding:2px;" ForeColor="Black" Font-Names="Arial"></asp:TextBox>
            </div>
            <div class="col-sm-2">
                
            </div>
          </div>
          <div class="row" id="rowAppServerPort" style="margin-bottom:5px;">
            <div class="col-sm-5">
                <asp:Label ID="lblAppServerPort" runat="server" Text="App Running Port" Font-Size="Medium" Font-Italic="true" ForeColor="navy"></asp:Label>
            </div>
            <div class="col-sm-5">
                <asp:TextBox ID="txtAppServerPort" TextMode="Number" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border: 1px solid darkgray;background-color:ButtonFace;padding:2px;" ForeColor="Black" Font-Names="Arial"></asp:TextBox>
            </div>
            <div class="col-sm-2">
                
            </div>
          </div>
          <div class="row" id="rowAppServerDependency" style="margin-bottom:5px;">
            <div class="col-sm-5">
                <asp:Label ID="lblAppServerDependency" runat="server" Text="App Server Dependency" Font-Size="Medium" Font-Italic="true" ForeColor="navy"></asp:Label>
            </div>
            <div class="col-sm-5">
                <asp:TextBox ID="txtAppServerDependency" runat="server" Width="250px" Height="27px" BorderStyle="None" style="border: 1px solid darkgray;background-color:ButtonFace;padding:2px;" ForeColor="Black" Font-Names="Arial"></asp:TextBox>
            </div>
            <div class="col-sm-2">
                
            </div>
          </div>
          <div class="row" id="rowButton" style="margin-bottom:5px;margin-Top:15px;">
            <div class="col-sm-5">
            </div>
            <div class="col-sm-5">
<%--                <button type="button" runat="server" class="btn btn-info btn-lg" data-toggle="savemodal" data-target="#mySaveModal" onclick="btnSave_Click" Width="70px" Height="30px">Save</button>
                <button type="button" runat="server"  class="btn btn-info btn-lg" data-toggle="clearmodal" data-target="#myClearModal" onclick="btnClear_Click" Width="70px" Height="30px">Clear</button>--%>
                <asp:Button ID="btnSave" CssClass="btn-danger" runat="server" Text="SAVE" onclick="btnSave_Click" Width="100px" Height="30px" style="border:1px solid black;" /> &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnClear" CssClass="btn-light" runat="server" Text="CLEAR" onclick="btnClear_Click" Width="100px" Height="30px" style="border:1px solid black;"/>
            </div>
            <div class="col-sm-2">
                
            </div>
          </div>

          
        </div>
        <br />           
        <br />

                

    </asp:Panel>

    <%--</div>
          <!-- end affix -->--%>

                
            </ContentTemplate>
        </asp:UpdatePanel>

    </asp:Panel>

                    <!-- Modal -->
  <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Portal Says,</h4>
        </div>
        <div class="modal-body">
          <%--<p>Some text in the modal.</p>--%>
          <asp:Label ID="lblResponse" runat="server" Text="Environment has been created successfully."></asp:Label>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>
      
    </div>
  </div>

            
  
  <script type="text/javascript">
      function WebForm_OnSubmit() {
          if (typeof (ValidatorOnSubmit) == "function" && ValidatorOnSubmit() == false) {
              for (var i in Page_Validators) {
                  try {
                      if (!Page_Validators[i].isvalid) {
                          var control = $("#" + Page_Validators[i].controltovalidate);

                          var top = control.offset().top;
                          $('html, body').animate({ scrollTop: top - 10 }, 800);
                          control.focus();
                          return;
                      }
                  } catch (e) { }
              }
              return false;
          }
          return true;
      }
</script>

    
</asp:Content>
