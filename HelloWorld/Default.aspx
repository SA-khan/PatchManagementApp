<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HelloWorld.Default" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Portal - Home</title>
    <link href="Images/icon.ico" rel="Shortcut Icon" />
    <script src="Scripts/bootstrap.min.js" type="text/javascript"></script>
    <link href="Styles/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-3.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui.js" type="text/javascript"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script src="Scripts/jquery.js" type="text/javascript"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <style>  
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

     <script>
         $(function () {
             var availableTags = ["Alfalah Investments", "Habib Bank Limited", "HBL AMC",
                                "PMRC", "PAK IRAN", "State Life", "BAFL AMC", "Asset Management Company"];
             $("#txtSearch").autocomplete({
                 source: availableTags
             });
         });
    </script>

    <nav class="navbar navbar-expand-sm bg-dark navbar-dark fixed-top">
      <div style="overflow:auto;width:100%;">
        <form class="form-inline" style="float:left;" action="#">
            <div class="ui-widget">
                <input style="margin-right:3px;width:250px;float:left;" id="txtSearch" class="form-control mr-sm-2" placeholder=" Search.." />
            </div>
            <button id="btnSearch" class="btn btn-success" type="button" onclick="mySearchFunction()">Search</button>
        </form>
      </div>
      <div style="float:right;padding-top:2px;margin-right:3px;">
        <select name="speed" id="SelectTheme">
           <option selected="selected">Classic</option>
           <option>Dark</option>
        </select>
      </div>
      <div style="float:right;padding-top:2px;margin-right:3px;">
        <select name="speed" id="SelectCountry">
           <option selected="selected">Pakistan</option>
           <option>Dubai</option>
           <option>UK</option>
        </select>
      </div>
      <div style="float:right;padding-top:2px">
        <select name="speed" id="selectLanguage">
           <option>Arabic</option>
           <option selected="selected">English</option>
           <option>Urdu</option>
        </select>
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
          <img src="Images\release.jpg" alt="Chicago" width="100%" height="500">
          <div class="carousel-caption">
            <h3>Multiple Environments</h3>
            <p>Test Quality Assurance Live And Custom Created!</p>
          </div>   
        </div>
        <div class="carousel-item">
          <img src="Images\rms.jpg" alt="New York" width="100%" height="300">
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
                <img src="Images/release.png" class="rounded-circle" alt="Cinque Terre" width="304" height="236"> 
                <h1 style="color:Black;">Release Management Portal</h1>
                <p><i><kbd>Reshaping the way we do things!</kbd></i></p>
                <%--<p></p>--%> 
                <div class="container pt-3">
                <div class="row">
                <div class="col-sm-3">

                <div class="card" style="width:100%">
                    <img class="card-img-top" src="Images/member_login_1.png" alt="Card image" style="width:100%" />
                    <div class="card-body">
                        <h4 class="card-title">Login Panel</h4>
                        <p class="card-text">View, Add, Edit & Delete Release, Environment, Client...</p>
                        <a href="Login.aspx" class="btn btn-primary stretched-link" style="color:White;">Goto Login</a>
                    </div>
                </div>
                    
                </div>
                <div class="col-sm-3">

                <div class="card" style="width:100%">
                    <br />
                    <img class="card-img-top" src="Images/application.png" alt="Card image" style="width:100%" />
                    <div class="card-body">
                        <h4 class="card-title">App Overview</h4>
                        <p class="card-text">View the latest Application Overview</p>
                        <a href="AppOverview.aspx" class="btn btn-primary stretched-link" style="color:White;">View</a>
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
                    
                    <div class="card" style="width:100%">
                    <br />
                    <img class="card-img-top" src="Images/environment.png" alt="Card image" style="width:100%" />
                    <div class="card-body">
                        <h4 class="card-title">Environment Overview</h4>
                        <p class="card-text">View the latest Environments Overview</p>
                        <a href="EnvironmentInfo.aspx" class="btn btn-primary stretched-link" style="color:White;">View</a>
                    </div>
                    </div>
                </div>
                <div class="col-sm-3">

                <div class="card" style="width:100%">
                    <br />
                    <br />
                    <br />
                    <img class="card-img-top" src="Images/references.png" alt="Card image" style="width:100%" />
                    <br />
                    <br />
                    <div class="card-body">
                        <h4 class="card-title">References & Docs</h4>
                        <p class="card-text">View and Download the authentic References...</p>
                        <a href="References.aspx" class="btn btn-primary stretched-link" style="color:White;">View</a>
                    </div>
                </div>

     <%--Ending Index--%>

    </div>
    </form>
</body>
</html>
