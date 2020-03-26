<%@ Page Title="Portal - Login Page" Language="C#" MasterPageFile="~/MasterPages/Layer1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HelloWorld.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Images/icon.ico" rel="Shortcut Icon" />
        
<style>

/* BASIC */

html {
  background-color: #56baed;
}

body {
  font-family: "Poppins", sans-serif;
  height: 100vh;
}

a {
  color: #92badd;
  display:inline-block;
  text-decoration: none;
  font-weight: 400;
}

h2 {
  text-align: center;
  font-size: 16px;
  font-weight: 600;
  text-transform: uppercase;
  display:inline-block;
  margin: 40px 8px 10px 8px; 
  color: #cccccc;
}



/* STRUCTURE */

.wrapper 
{
  display: flex;
  align-items: center;
  flex-direction: column; 
  justify-content: center;
  width: 100%;
  min-height: 100%;
  padding: 50px;
}

#formContent {
  -webkit-border-radius: 10px 10px 10px 10px;
  border-radius: 10px 10px 10px 10px;
  background: #fff;
  padding: 30px;
  width: 90%;
  max-width: 450px;
  position: relative;
  padding: 0px;
  -webkit-box-shadow: 0 30px 60px 0 rgba(0,0,0,0.3);
  box-shadow: 0 30px 60px 0 rgba(0,0,0,0.3);
  text-align: center;
}

#formFooter {
  background-color: #f6f6f6;
  border-top: 1px solid #dce8f1;
  padding: 25px;
  text-align: center;
  -webkit-border-radius: 0 0 10px 10px;
  border-radius: 0 0 10px 10px;
}



/* TABS */

h2.inactive {
  color: #cccccc;
}

h2.active {
  color: #0d0d0d;
  border-bottom: 2px solid #5fbae9;
}



/* FORM TYPOGRAPHY*/

input[type=button], input[type=submit], input[type=reset]  {
  background-color: #56baed;
  border: none;
  color: white;
  padding: 15px 80px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  text-transform: uppercase;
  font-size: 13px;
  -webkit-box-shadow: 0 10px 30px 0 rgba(95,186,233,0.4);
  box-shadow: 0 10px 30px 0 rgba(95,186,233,0.4);
  -webkit-border-radius: 5px 5px 5px 5px;
  border-radius: 5px 5px 5px 5px;
  margin: 5px 20px 40px 20px;
  -webkit-transition: all 0.3s ease-in-out;
  -moz-transition: all 0.3s ease-in-out;
  -ms-transition: all 0.3s ease-in-out;
  -o-transition: all 0.3s ease-in-out;
  transition: all 0.3s ease-in-out;
}

input[type=button]:hover, input[type=submit]:hover, input[type=reset]:hover  {
  background-color: #39ace7;
}

input[type=button]:active, input[type=submit]:active, input[type=reset]:active  {
  -moz-transform: scale(0.95);
  -webkit-transform: scale(0.95);
  -o-transform: scale(0.95);
  -ms-transform: scale(0.95);
  transform: scale(0.95);
}

input[type=text] {
  background-color: #f6f6f6;
  border: none;
  color: #0d0d0d;
  padding: 15px 32px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
  margin: 5px;
  width: 85%;
  border: 2px solid #f6f6f6;
  -webkit-transition: all 0.5s ease-in-out;
  -moz-transition: all 0.5s ease-in-out;
  -ms-transition: all 0.5s ease-in-out;
  -o-transition: all 0.5s ease-in-out;
  transition: all 0.5s ease-in-out;
  -webkit-border-radius: 5px 5px 5px 5px;
  border-radius: 5px 5px 5px 5px;
}

input[type=text]:focus {
  background-color: #fff;
  border-bottom: 2px solid #5fbae9;
}

input[type=text]:placeholder {
  color: #cccccc;
}



/* ANIMATIONS */

/* Simple CSS3 Fade-in-down Animation */
.fadeInDown {
  -webkit-animation-name: fadeInDown;
  animation-name: fadeInDown;
  -webkit-animation-duration: 1s;
  animation-duration: 1s;
  -webkit-animation-fill-mode: both;
  animation-fill-mode: both;
}

@-webkit-keyframes fadeInDown {
  0% {
    opacity: 0;
    -webkit-transform: translate3d(0, -100%, 0);
    transform: translate3d(0, -100%, 0);
  }
  100% {
    opacity: 1;
    -webkit-transform: none;
    transform: none;
  }
}

@keyframes fadeInDown {
  0% {
    opacity: 0;
    -webkit-transform: translate3d(0, -100%, 0);
    transform: translate3d(0, -100%, 0);
  }
  100% {
    opacity: 1;
    -webkit-transform: none;
    transform: none;
  }
}

/* Simple CSS3 Fade-in Animation */
@-webkit-keyframes fadeIn { from { opacity:0; } to { opacity:1; } }
@-moz-keyframes fadeIn { from { opacity:0; } to { opacity:1; } }
@keyframes fadeIn { from { opacity:0; } to { opacity:1; } }

.fadeIn {
  opacity:0;
  -webkit-animation:fadeIn ease-in 1;
  -moz-animation:fadeIn ease-in 1;
  animation:fadeIn ease-in 1;

  -webkit-animation-fill-mode:forwards;
  -moz-animation-fill-mode:forwards;
  animation-fill-mode:forwards;

  -webkit-animation-duration:1s;
  -moz-animation-duration:1s;
  animation-duration:1s;
}

.fadeIn.first {
  -webkit-animation-delay: 0.4s;
  -moz-animation-delay: 0.4s;
  animation-delay: 0.4s;
}

.fadeIn.second {
  -webkit-animation-delay: 0.6s;
  -moz-animation-delay: 0.6s;
  animation-delay: 0.6s;
}

.fadeIn.third {
  -webkit-animation-delay: 0.8s;
  -moz-animation-delay: 0.8s;
  animation-delay: 0.8s;
}

.fadeIn.fourth {
  -webkit-animation-delay: 1s;
  -moz-animation-delay: 1s;
  animation-delay: 1s;
}

/* Simple CSS3 Fade-in Animation */
.underlineHover:after {
  display: block;
  left: 0;
  bottom: -10px;
  width: 0;
  height: 2px;
  background-color: #56baed;
  content: "";
  transition: width 0.2s;
}

.underlineHover:hover {
  color: #0d0d0d;
}

.underlineHover:hover:after{
  width: 100%;
}



/* OTHERS */

*:focus {
    outline: none;
} 

#icon {
  width:60%;
}


</style>
<%--<style>
.btn {
  background-color: DodgerBlue;
  border: none;
  color: white;
  padding: 12px 16px;
  font-size: 16px;
  cursor: pointer;
}--%>

/* Darker background on mouse-over */
.btn:hover {
  background-color: RoyalBlue;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%--    
    <div runat="server" style="min-width:100%;height:100%;min-height:300px;margin:auto;border:1px solid gray;width:100%;float:inherit;background-image:url('\\Images\\loginBG.jpg');">
    <div runat="server" style="min-width:100%;height:100%;min-height:300px;margin:auto;border:1px solid gray;width:100%;opacity:0.8;padding-top:105px;">
    <asp:Table ID="Table1" runat="server" HorizontalAlign="Center" BackColor="Control" BorderColor="ControlDark" BorderStyle="Solid" BorderWidth="1" syle="width:100%;height:100%;min-height:100%;min-width:100%;margin:auto;HorizontalAlign:center;opacity:0.8;margin-top:50px;VerticalAlign:center;">
    <asp:TableHeaderRow BackColor="ActiveCaption" Height="30px">
        <asp:TableHeaderCell ColumnSpan="2" Font-Size="Larger" Font-Names="Arial" ForeColor="Black">
            LOGIN PANEL
        </asp:TableHeaderCell>
    </asp:TableHeaderRow>
    <asp:TableRow>
        <asp:TableCell>
            <label id="lblUserId" title="User ID:" ForeColor="Black" style="Width:200px;font-family:@Arial Unicode MS;font-size:medium;color:Black;">User ID:</label>
        </asp:TableCell>
        <asp:TableCell>
        
        <asp:DropDownList ID="dropUserId" runat="server" Width="200px" 
        Height="28px" DataSourceID="SqlDataSource1" DataTextField="UserID" DataValueField="UserID" AppendDataBoundItems=true>
                   <asp:ListItem>Select UserID</asp:ListItem>
            </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
        SelectCommand="SELECT [UserID] FROM [UsersAuth]"></asp:SqlDataSource> 

        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <label id="lblPassword" title="Password:" ForeColor="Black" style="Width:200px;font-family:@Arial Unicode MS;font-size:medium;color:Black;">Password:</label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="txtPassword" runat="server" Width="196px" Height="25px" TextMode="Password" Font-Size="Large"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
        <asp:TableRow>
        <asp:TableCell>
        </asp:TableCell>
        <asp:TableCell style="margin-top:15px;margin-bottom:15px;">
            <asp:CheckBox ID="checkRemember" runat="server" TextAlign="Right" ForeColor="Black" Font-Italic="true" Text="Remember Me" Font-Size="Small" AutoPostBack="true" Font-Names="Arial" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
            <asp:Button ID="btnSubmit" CssClass=".btn" runat="server" Text="LOGIN" Width="260px" BackColor="#009688" BorderStyle="None" BorderWidth="0" Height="40px" OnClick="Login_Clicked" style="border-radius: 50px;" /><span style="font-size:x-large" class="glyphicon glyphicon-log-in"></span>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server">
        <asp:TableCell>
            <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label ID="lblStatusCode" runat="server" Text=""></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    </asp:Table>
    </div>
    </div>
     --%>          
             <div class="wrapper fadeInDown">
  <div id="formContent">
    <!-- Tabs Titles -->

    <!-- Icon -->
    <div class="fadeIn first">
        <br />
      <img src="\Images\user.png" class="rounded-circle" id="icon" alt="User Icon"  width="400" height="150" />
    </div>

    <!-- Login Form -->
    <form>
      <asp:TextBox ID="txtLogin" runat="server" class="fadeIn second" name="login" placeholder="login"></asp:TextBox>
      <asp:TextBox ID="txtPassword" runat="server" class="fadeIn third" name="login" placeholder="password"></asp:TextBox>
      <asp:Button ID="btnLogin" runat="server" class="fadeIn fourth" Text="Log In" />
    </form>

    <!-- Remind Passowrd -->
    <div id="formFooter">
      <a class="underlineHover" href="#">Forgot Password?</a>
    </div>

  </div>
</div>         
                
</asp:Content>
