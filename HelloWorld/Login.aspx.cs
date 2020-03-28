using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using HelloWorld.App_Code;
using System.Threading;
using System.Globalization;

namespace HelloWorld
{
    public partial class Login : System.Web.UI.Page
    {
        Log log = new Log();

        protected void Page_Load(object sender, EventArgs e)
        {

            #region Language

            log.DetailLog("Login.aspx.cs", "Page_Load", STATE.INITIALIZED, "Method: Page_Load in Class: Login.aspx.cs has Initialized.");
            //Debug.WriteLine(dropLanguage.SelectedItem);

            #region English_Language

            //if (dropLanguage.SelectedItem.Text == "English")
            //{
            //    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-En");
            //    btnLogin.Text = Properties.strings.Search.ToString();
            //}

            #endregion English_Language

            #region French_Language

            //else if (dropLanguage.SelectedItem.Text == "French")
            //{
            //    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("fr-FR");
            //    btnLogin.Text = Properties.strings.Search.ToString();
            //}

            #endregion French_Language

            #region Urdu_Language

            //else if (dropLanguage.SelectedItem.Text == "اردو")
            //{
            //    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ur-UR");
            //    btnLogin.Text = Properties.strings.Search.ToString();
                
            //}

            #endregion Urdu_Language

            #region Arabic_Language

            //else if (dropLanguage.SelectedItem.Text == "عربى")
            //{
            //    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ar-AR");
            //    btnLogin.Text = Properties.strings.Search.ToString();
                
            //}

            #endregion Arabic_Language

            #region Spanish_Language

            //else if (dropLanguage.SelectedItem.Text == "Spanish")
            //{
            //    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("sp-SP");
            //    btnLogin.Text = Properties.strings.Search.ToString();

            //}

            #endregion Spanish_Language

            #region Germon_Language

            //else if (dropLanguage.SelectedItem.Text == "German")
            //{
            //    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ge-GE");
            //    btnLogin.Text = Properties.strings.Search.ToString();

            //}

            #endregion Germon_Language

            #endregion Language

            try
            {
                bool rememberCheck = CheckRememberMe.Checked;
                Debug.WriteLine("Remember Me Check Status: " + rememberCheck);
                if (rememberCheck == true)
                {
                    string userid = txtLogin.Text.ToString();
                    string password = txtPassword.Text.ToString();
                    if (!userid.Equals("Select UserID")) //|| password != null
                    {
                        HttpCookie userCookie = new HttpCookie("UserID");
                        HttpCookie passCookie = new HttpCookie("Password");
                        //userCookie.Name = "UserID";
                        //passCookie.Name = "Password";
                        userCookie.Value = userid.ToString();
                        passCookie.Value = password.ToString();
                        //userCookie.HttpOnly = true;
                        //passCookie.HttpOnly = true;
                        userCookie.Expires.AddDays(3);
                        passCookie.Expires.AddDays(3);
                        Response.Cookies.Add(userCookie);
                        Response.Cookies.Add(passCookie);
                        Debug.WriteLine("Cookie Saved With ID: " + userCookie.Value.ToString() + " and Passcode: " + passCookie.Value.ToString());
                    }
                    else {
                        HttpCookie userCookie = new HttpCookie("UserID");
                        HttpCookie passCookie = new HttpCookie("Password");
                        //userCookie.Name = "UserID";
                        //passCookie.Name = "Password";
                        userCookie.Value = "";
                        passCookie.Value = "";
                        //userCookie.HttpOnly = true;
                        //passCookie.HttpOnly = true;
                        userCookie.Expires.AddDays(3);
                        passCookie.Expires.AddDays(3);
                        Response.Cookies.Add(userCookie);
                        Response.Cookies.Add(passCookie);
                        Debug.WriteLine("Cookie Saved With ID: " + userCookie.Value.ToString() + " and Passcode: " + passCookie.Value.ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Login.aspx.cs Exception: " + ex.Message);
                log.ErrorLog("Login.aspx.cs", "Page_Load", ExceptionType.Exception, ex);
                log.DetailLog("Login.aspx.cs", "Page_Load", STATE.INTERRUPTED, ex.Message);
                Response.Redirect("ErrorPages\\Error500.aspx?Param=Login.aspx&MethodName=Page_Load", true);
            }

            finally
            {
                
            }

        }

        //protected void Login_Clicked(object sender, EventArgs e)
        //{
            
        //}

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string userID = txtLogin.Text.ToString();
                string password = txtPassword.Text.ToString();
                bool loginStatus = false;
                Debug.WriteLine("UserID is: " + userID);
                Debug.WriteLine("Password is: " + password);
                if (userID != "")
                {
                    Debug.WriteLine("Checking..");
                    DatabaseConnectivity dbcon = new DatabaseConnectivity();
                    List<User> userList = dbcon.getAuthUsers();
                    foreach (var item in userList)
                    {
                        if (userID.Equals(item.UserID) && password.Equals(item.Password))
                        {
                            loginStatus = true;
                            Session["UserID"] = userID;
                            break;
                        }
                        else
                        {

                        }
                    }

                    if (loginStatus)
                    {
                        lblStatus.Text = "Response Code: 0200";
                        Response.Redirect("/ProtectedPages/Dashboard.aspx", false);
                    }
                    else
                    {
                        lblStatus.Text = "Response Code: 0401";
                    }

                }
                else
                {
                    lblStatus.Text = "Response Code: 0401";
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Login.aspx.cs Exception: " + ex.Message);
                log.ErrorLog("Login.aspx.cs", "Login_Clicked", ExceptionType.Exception, ex);
                log.DetailLog("Login.aspx.cs", "Login_Clicked", STATE.INTERRUPTED, ex.Message);
                Response.Redirect("ErrorPages\\Error500.aspx?Param=Login.aspx&MethodName=Login_Clicked", true);
            }

            finally
            {
                //Response.Redirect("ErrorPages\\Error500.aspx?Param=Login.aspx&MethodName=Login_Clicked", true);
            }
        }
    }
}