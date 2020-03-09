<%@ Page Title="Portal - Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="HelloWorld._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="Images/icon.ico" rel="Shortcut Icon" />
        <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
  <nav class="navbar navbar-expand-sm bg-dark navbar-dark">
  <form class="form-inline" action="Search.aspx">
    <input id="txtSearch" class="form-control mr-sm-2" type="text" placeholder="Search" />
    <button id="btnSearch" class="btn btn-success" type="button" onclick="mySearchFunction()">Search</button>
  </form>
  <script type="text/javascript">
      function mySearchFunction () {
          window.location = 'Search.aspx?param=' + document.getElementById('txtSearch').value;
          return false;
      }
</script>
</nav>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <div class="alert alert-dark alert-dismissible">
    <button type="button" class="close" data-dismiss="alert">&times;</button>
    <strong>Warning!</strong> This website saves cookies.
  </div>
    <div class="jumbotron text-center">
                <img src="Images/release3.jfif" class="rounded-circle" alt="Cinque Terre" width="304" height="236"> 
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
                    
                    <%--<h3>Login Panel</h3>
                    <p> </p>
                    <p> </p>
                    <p>You can login to manage the portal...</p>
                    <p>Add, Edit & Delete Release, Environment, Client...</p>
                    <button type="button" class="btn btn-primary">
                      Goto Login <span class="badge badge-light">4</span>
                    </button> <br />
                    [ <a href="~/Login.aspx" ID="HeadLoginStatus" runat="server">Log In</a> ]--%>
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
                    <%--<h3>Environment Overview</h3>        
                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit...</p>
                    <p>Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris...</p>
                    <button type="button" class="btn btn-primary">
                        View Environment <span class="badge badge-light">4</span>
                    </button>--%>
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

                    <%--<h3>References & Docs</h3>        
                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit...</p>
                    <p>Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris...</p>
                    <button type="button" class="btn btn-primary">
                      View <span class="badge badge-light">4</span>
                    </button>--%>
                </div>
                </div>
            </div>
            </div>
<p>
        <asp:Button ID="Button1" Visible="false" runat="server" onclick="Button1_Click" Text="Goto Login" />
    </p>

</asp:Content>
