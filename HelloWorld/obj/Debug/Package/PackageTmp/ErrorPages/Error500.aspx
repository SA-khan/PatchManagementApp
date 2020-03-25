<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error500.aspx.cs" Inherits="HelloWorld.ErrorPages.Error500" %>
<!DOCTYPE html>
<html lang="ur">
<head>
  <title>Error 500</title>
    <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
</head>
<body style="background-color:#343A40">
    <form id="form1" runat="server">
    <div>
        <div class="card bg-dark text-white">
            <div class="card-body" style="height:100%;">Error 500</div>
                <div class="card bg-light text-dark" style="margin-right:20%;margin-left:20%;margin-bottom:20%;padding:2%;">
                <div class="card-body"><b>Server Error:</b> The Network related issue has occured at Server Level. Check Database Connecctivity Issue. For further information contact your system adminitrator or the product vendor.</div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
