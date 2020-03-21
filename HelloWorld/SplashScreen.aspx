<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SplashScreen.aspx.cs" Inherits="HelloWorld.SplashScreen" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <title>Starting Portal</title>
</head>
<body style="background-color:#212121;">
<script>
    $(document).ready(function () {
        setTimeout(myFunction, 500);
        setTimeout(myFunction1, 1000);
        setTimeout(myFunction2, 1500);
        setTimeout(myFunction3, 2000);
        setTimeout(myFunction4, 2500);
        setTimeout(myFunction5, 3000);
        setTimeout(myFunction6, 3500);
        setTimeout(myFunction7, 4000);
        setTimeout(myFunction8, 4500);
        setTimeout(myFunction9, 4700);
        setTimeout(myFunction10, 5000);
        setTimeout(myFunction11, 5100);
    });
</script>
<script>
    function myFunction() {
        document.getElementById("movingBar").style.width = "25%";
    }
    function myFunction1() {
        document.getElementById("movingBar").style.width = "50%";
    }
    function myFunction2() {
        document.getElementById("movingBar").style.width = "52%";
    }
    function myFunction3() {
        document.getElementById("movingBar").style.width = "70%";
    }
    function myFunction4() {
        document.getElementById("movingBar").style.width = "90%";
    }
    function myFunction5() {
        document.getElementById("movingBar").style.width = "100%";
    }
    function myFunction6() {
        document.getElementById("movingBar").style.width = "110%";
    }
    function myFunction7() {
        document.getElementById("movingBar").style.width = "150%";
    }
    function myFunction8() {
        document.getElementById("movingBar").style.width = "700%";
    }
    function myFunction9() {
        document.getElementById("movingBar").style.width = "10000%";
    }
    function myFunction10() {
        document.getElementById("movingBar").style.width = "12000%";
    }
    function myFunction11() {
        var url = "Default.aspx";
        window.location = url;
    }
</script>
    <script>
        var myVar = setInterval(myTimer, 5000);
        function myTimer() {
            var d = new Date();
            document.getElementById("demo").innerHTML = d.toLocaleTimeString();
        }
    </script>
    <form id="form1" runat="server">
    <div>

    <div class="jumbotron text-center">
             <div class="card bg-light text-dark">
               <div class="card-body">
                <img src="Images/rms.jpg" class="rounded-circle" alt="Cinque Terre" width="304" height="236"> 
                <h1 style="color:Black;">Release Management Portal</h1>
                <p><i><kbd>Reshaping the way we do things!</kbd></i></p>
                <br />
                <div style="max-width:40%;margin:auto;">
                    <div class="progress" style="height:4px;">
                        <div id="movingBar" class="progress-bar" style="width:0%;background-color:#455A64;">
                        </div>
                        <div class="progress-bar" style="width:100%;background-color:#CFD8DC;">
                        </div>
                    </div>
                </div>
                <p style="color:Gray;"><i>Initializing Application</i></p>
                </div>
            </div>
    </div>
    </div>
    </form>
</body>
</html>
