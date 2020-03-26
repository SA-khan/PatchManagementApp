<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HelloWorld.Default" Theme="Classic" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title><asp:Localize ID="Localize1" runat="server" Mode="Transform">Portal - Home</asp:Localize></title>
    <link href="Images/icon.ico" rel="Shortcut Icon" />
    <script src="Scripts/bootstrap.min.js" type="text/javascript"></script>
    <link href="Styles/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-3.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="Scripts/jquery.js" type="text/javascript"></script>
    <style type="text/css">  
        .carousel-inner img {
        width: 100%;
        height: 50%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <script type="text/javascript">
            function mySearchFunction() {
                window.location = 'Search.aspx?param=' + document.getElementById('txtSearch').value;
                return false;
            }
        </script>

     <script type="text/javascript">
         $(function () {
             var availableTags = ["Alfalah Investments", "Habib Bank Limited", "HBL AMC",
                                "PMRC", "PAK IRAN", "State Life", "BAFL AMC", "Asset Management Company"];
             $("#txtSearch").autocomplete({
                 source: availableTags
             });
         });
    </script>

    <nav class="navbar navbar-expand-sm bg-dark navbar-dark fixed-top">
        <div class=".container-fluid" style="width:100%">
        <div class="row">
            <div class=".col-sm-2" style="margin-left:2%;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <input style="width:250px;float:left;" id="txtSearch" class="form-control mr-sm-2" placeholder="Search.." />
                 <button style="width:100px;margin-left:3px;float:left;" id="btnSearch" type="button" class="btn btn-success" onclick="mySearchFunction()"><asp:Localize ID="LocalSearch" runat="server">Search</asp:Localize></button>
            </div>
            <div class=".col-sm-1">
                <div style="float:left;width:100%;margin-right:100%">
                
                </div>
            </div>
            <div class=".col-sm-1">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </div>
            <div class=".col-sm-1">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </div>
            <div class=".col-sm-1">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </div>
            <div class=".col-sm-1">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </div>
            <div class=".col-sm-1">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </div>
            <div class=".col-sm-1">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </div>
            <div class=".col" style="float:right;">
            &nbsp;&nbsp;
                    <select name="speed" id="SelectTheme">
                        <option selected="selected"><asp:Localize ID="LocalClassic" runat="server">Classic</asp:Localize></option>
                        <option><asp:Localize ID="LocalDark" runat="server">Dark</asp:Localize></option>
                    </select>
            </div>
            <div class=".col">
            &nbsp;&nbsp;
                    <select name="region" id="SelectCountry">
                        <option selected="selected"><asp:Localize ID="LocalPakistan" runat="server">Pakistan</asp:Localize></option>
                        <option><asp:Localize ID="LocalUAE" runat="server">United Arab Emirates</asp:Localize></option>
                        <option><asp:Localize ID="LocalUK" runat="server">United Kingdom</asp:Localize></option>
                    </select>
            </div>
            <div class=".col">
            &nbsp;&nbsp;
                    <%--<select runat="server"  name="language" id="selectLanguage">
                        <option></option>
                        <option selected="selected">English</option>
                        <option>اردو</option>
                    </select>--%>
                    <asp:DropDownList ID="dropLanguage" runat="server" AutoPostBack="true">
                        <asp:ListItem>اردو</asp:ListItem>
                        <asp:ListItem Selected="True">English</asp:ListItem>
                        <asp:ListItem>Germon</asp:ListItem>
                        <asp:ListItem>French</asp:ListItem>
                        <asp:ListItem>Spanish</asp:ListItem>
                        <asp:ListItem>سنڌي</asp:ListItem>
                        <asp:ListItem>عربى</asp:ListItem>
                    </asp:DropDownList>
            &nbsp;&nbsp;
            </div>
        </div>
        </div>
     </nav>

     <%--Starting Index--%>

<%--     <div class="alert alert-dark alert-dismissible">
                <button type="button" class="close" data-dismiss="alert">&times;</button>
                <strong>Warning!</strong> This website saves cookies.
        </div>

    <div id="demo" class="carousel slide" data-ride="carousel">
      <ul class="carousel-indicators">
        <li data-target="#demo" data-slide-to="0" class="active"></li>
        <li data-target="#demo" data-slide-to="1"></li>
        <li data-target="#demo" data-slide-to="2"></li>
      </ul>
      <div class="carousel-inner">
        <div class="carousel-item active">
          <img src="Images\release.png" alt="Los Angeles" width="100%" height="500">
          <div class="carousel-caption">
            <h3>Releases Your Apps</h3>
            <p>Deploy the releases without try to remember anything. </p>
            <%--start--%>



            <%--end--%>
          </div>   
        </div>

       

        <div class="carousel-item">
          <img src="\\Images\\release.jpg" alt="Chicago" width="100%" height="500">
          <div class="carousel-caption">
            <h3>Multiple Environments</h3>
            <p>Test Quality Assurance Live And Custom Created!</p>
          </div>   
        </div>
        <div class="carousel-item">
          <img src="\\Images\\rms.jpg" alt="New York" width="100%" height="300">
          <div class="carousel-caption">
            <h3>Update Continously</h3>
            <p>Continously Improving to provide better results!</p>
          </div>   
        </div>
      </div>
      <a class="carousel-control-prev" href="#demo" data-slide="prev">
        <span class="carousel-control-prev-icon"></span>
      </a>
      <a class="carousel-control-next" href="#demo" data-slide="next">
        <span class="carousel-control-next-icon"></span>
      </a>
    </div>
--%>

    <div class="jumbotron text-center">
                <img src="/Images/release.png" class="rounded-circle" alt="Cinque Terre" width="304" height="236"> 
                <h1 style="color:Black;font-size:64px;padding:2%;">
                    <asp:Localize ID="LocalHeading" runat="server">Release Management Portal</asp:Localize></h1>
                <p style="font-size:32px;margin-bottom:3%;"><i><kbd style="padding:1%;"><asp:Localize ID="LocalSubheading" runat="server">Reshaping the way we do things!</asp:Localize></kbd></i></p>
                <%--<p></p>--%> 
                <div class="container pt-3">
                <div class="row">
                <div class="col-sm-3">

                <div class="card" style="width:100%;min-height:100%;">
                    <img class="card-img-top" src="/Images/member_login_1.png" alt="Card image" style="width:100%" />
                    <div class="card-body">
                        <h4 class="card-title" style="font-size:32px;">
                            <asp:Localize ID="LocalLoginPanel" runat="server">Login Panel</asp:Localize></h4>
                        <p class="card-text"><asp:Localize ID="LocalLoginPanelSubHeading" runat="server">View, Add, Edit & Delete Release, Environment, Client...</asp:Localize></p>
                        <a href="Login.aspx" class="btn btn-primary stretched-link" style="color:White;"><asp:Localize ID="LocalLoginPanelButton" runat="server">Goto Login</asp:Localize></a>
                    </div>
                </div>
                    
                </div>
                <div class="col-sm-3">

                <div class="card" style="width:100%;min-height:100%;">
                    <br />
                    <img class="card-img-top" src="\Images/application.png" alt="Card image" style="width:100%" />
                    <div class="card-body">
                        <br />
                        <h4 class="card-title" style="font-size:32px;"><asp:Localize ID="LocalAppOverview" runat="server">App Overview</asp:Localize></h4>
                        <p class="card-text"><asp:Localize ID="LocalAppOverviewSubHeading" runat="server">View the latest Application Overview</asp:Localize></p>
                        <a href="AppOverview.aspx" class="btn btn-primary stretched-link" style="color:White;"><asp:Localize ID="LocalAppOverviewButton" runat="server">View</asp:Localize></a>
                    </div>
                </div>

                    <%--<h3>App Overview</h3>
                    <p> </p>
                    <p> </p>
                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit...</p>
                    <p>Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris...</p>
                    <button type="button" class="btn btn-primary">
                        View Apps <span class="badge badge-light">4</span>
                    </button>--%>
                </div>
                <div class="col-sm-3">
                    
                    <div class="card" style="width:100%;min-height:100%;">
                    <br />
                    <img class="card-img-top" src="\Images/environment.png" alt="Card image" style="width:100%" />
                    <div class="card-body">
                        <h4 class="card-title" style="font-size:32px;"><asp:Localize ID="LocalEnvironmentOverview" runat="server">Environment Overview</asp:Localize></h4>
                        <p class="card-text"><asp:Localize ID="LocalEnvironmentOverviewSubHeading" runat="server">View the latest Environments Overview</asp:Localize></p>
                        <a href="EnvironmentInfo.aspx" class="btn btn-primary stretched-link" style="color:White;"><asp:Localize ID="LocalEnvironmentOverviewButton" runat="server">View</asp:Localize></a>
                    </div>
                    </div>
                </div>
                <div class="col-sm-3">

                <div class="card" style="width:100%;min-height:100%;">
                    <br />
                    <br />
                    <br />
                    <img class="card-img-top" src="\Images/references.png" alt="Card image" style="width:100%" />
                    <br />
                    <br />
                    <div class="card-body">
                        <p></p>
                        <p></p>
                        <h4 class="card-title" style="font-size:32px;"><asp:Localize ID="LocalReferencesAndDocuments" runat="server">References & Docs</asp:Localize></h4>
                        <p class="card-text"><asp:Localize ID="LocalReferencesAndDocumentsSubHeading" runat="server">View and Download the authentic References...</asp:Localize></p>
                        <a href="References.aspx" class="btn btn-primary stretched-link" style="color:White;"><asp:Localize ID="LocalReferencesAndDocumentsButton" runat="server">View</asp:Localize></a>
                    </div>
                </div>

     <%--Ending Index--%>


    </div>
    </form>
</body>
</html>
