using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using HelloWorld.App_Code;

namespace HelloWorld
{
    public partial class Login : System.Web.UI.Page
    {
        Log log = new Log();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                bool rememberCheck = checkRemember.Checked;
                Debug.WriteLine("Remember Me Check Status: " + rememberCheck);
                if (rememberCheck == true)
                {
                    string userid = dropUserId.Text.ToString();
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
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Login.aspx.cs Exception: " + ex.Message);
                log.ErrorLog("Login.aspx.cs", "Page_Load", ExceptionType.Exception, ex);
                log.DetailLog("Login.aspx.cs", "Page_Load", STATE.INTERRUPTED, ex.Message);
            }

            finally {
                Response.Redirect("ErrorPages\\Error500.aspx?Param=Login.aspx&MethodName=Page_Load", true);
            }

        }

        protected void Login_Clicked(object sender, EventArgs e)
        {
            try
            {
                string userID = dropUserId.Text.ToString();
                string password = txtPassword.Text.ToString();
                bool loginStatus = false;
                Debug.WriteLine("UserID is: " + userID);
                Debug.WriteLine("Password is: " + password);
                if (userID != "Select UserID" && userID != "")
                {
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
                        lblStatus.Text = "Response Code: ";
                        lblStatusCode.Text = "0200";
                        Response.Redirect("~/ProtectedPages/Dashboard.aspx");
                    }
                    else
                    {
                        lblStatus.Text = "Response Code: ";
                        lblStatusCode.Text = "0401";
                    }

                }
                else
                {
                    lblStatus.Text = "Response Code: ";
                    lblStatusCode.Text = "0401";
                }
            
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Login.aspx.cs Exception: " + ex.Message);
                log.ErrorLog("Login.aspx.cs", "Login_Clicked", ExceptionType.Exception, ex);
                log.DetailLog("Login.aspx.cs", "Login_Clicked", STATE.INTERRUPTED, ex.Message);
            }

            finally {
                Response.Redirect("ErrorPages\\Error500.aspx?Param=Login.aspx&MethodName=Login_Clicked", true);
            }
        }
    }
}