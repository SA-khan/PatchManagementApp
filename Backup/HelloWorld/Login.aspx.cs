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
using System.Text;

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

            if (Session.Count != 0)
            {
                string usrIDSession = String.Empty;
                if (Session["USR_LOGIN_ID"] != null)
                {
                    usrIDSession = Session["USR_LOGIN_ID"].ToString();
                    txtLogin.Text = usrIDSession;
                }
                if (Session["USR_CURRENT_PASSCODE"] != null)
                {
                    if (usrIDSession.Equals("poweruser"))
                    {
                        txtPassword.Text = Session["USR_CURRENT_PASSCODE"].ToString();
                    }
                    else
                    {
                        //txtPassword.Text = System.Text.ASCIIEncoding.ASCII.GetString(System.Convert.FromBase64String(Session["USR_CURRENT_PASSCODE"].ToString()));
                    }
                }

            }

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

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                #region VARIABLE DECLARATION
                string userID = txtLogin.Text.ToString();
                string password = txtPassword.Text.ToString();
                int statusFlag = 0;
                bool statusLogin = false;
                string USR_LOGIN_ID = String.Empty;
                string USR_CURRENT_PASSCODE = String.Empty;
                string USR_DEPT_ID = String.Empty;
                string USR_DESIGNATION = String.Empty;
                string USR_LAST_LOGIN_DATE = String.Empty;
                string USR_PREF_LANG = String.Empty;
                string USR_PREF_THEME = String.Empty;
                string USR_REGION = String.Empty;
                #endregion
                Debug.WriteLine("Input User ID: " + userID);
                Debug.WriteLine("Input Password: " + password);
                log.DetailLog("Login.aspx.cs", "Login_Clicked", STATE.INITIALIZED, "Attempting to Login With USER_LOGIN_ID: "+ userID + "\t& USER_CURRENT_PASSCODE: " + password);
                #region IF_USER_ID_IS_NOT_NULL
                if (userID != "")
                {
                    DatabaseConnectivity dbcon = new DatabaseConnectivity();
                    List<User> userList = dbcon.getAuthUsers();
                    foreach (var item in userList)
                    {
                        Debug.WriteLine("Database User: " + item.USR_LOGIN_ID + ", Password: " + item.USR_CURRENT_PASSCODE);
                        if (userID.Equals("poweruser") && password.Equals("power"))
                        {
                            statusFlag = 0202;
                            USR_LOGIN_ID = "power user";
                            USR_CURRENT_PASSCODE = "power";
                            USR_DEPT_ID = "1";
                            USR_DESIGNATION = "1";
                            USR_LAST_LOGIN_DATE = DateTime.Now.ToString();
                            USR_PREF_LANG = "en";
                            USR_PREF_THEME = "light";
                            USR_REGION = "pk";
                            log.DetailLog("Login.aspx.cs", "Login_Clicked", STATE.INITIALIZED, "STATUS CODE: 0201 OK. \tLocal Entry Found. , \n\t\t\tDetails: { USER_LOGIN_ID: \"" + userID + "\" & USER_CURRENT_PASSCODE: \"" + password + "\"}");
                            break;
                        }
                        #region IF_USER_LOGIN_ID_AND_PASSCODE_IS_MATCHED_WITH_PLAIN_PASSCODE
                        else if (userID.Equals(item.USR_LOGIN_ID) && password.Equals(item.USR_CURRENT_PASSCODE))
                        {
                            statusFlag = 0200;
                            USR_LOGIN_ID = item.USR_LOGIN_ID;
                            USR_CURRENT_PASSCODE = item.USR_CURRENT_PASSCODE;
                            USR_DEPT_ID = item.USR_DEPT_ID;
                            USR_DESIGNATION = item.USR_DESIGNATION;
                            USR_LAST_LOGIN_DATE = item.USR_LAST_LOGIN_DATE;
                            USR_PREF_LANG = item.USR_PREF_LANG;
                            USR_PREF_THEME = item.USR_PREF_THEME;
                            USR_REGION = item.USR_REGION;
                            log.DetailLog("Login.aspx.cs", "Login_Clicked", STATE.INITIALIZED, "STATUS CODE: 0200 OK. \tDatabase Entry Found of User With Plain Passcode, \nDetails: { USER_LOGIN_ID: \"" + userID + "\"\t& USER_CURRENT_PASSCODE: \"" + password + "\"}");
                            break;
                        }
                        else if (userID.Equals(item.USR_LOGIN_ID) && password.Equals(System.Text.ASCIIEncoding.ASCII.GetString(System.Convert.FromBase64String(item.USR_CURRENT_PASSCODE))))
                        {
                            statusFlag = 0201;
                            USR_LOGIN_ID = item.USR_LOGIN_ID;
                            USR_CURRENT_PASSCODE = item.USR_CURRENT_PASSCODE;
                            USR_DEPT_ID = item.USR_DEPT_ID;
                            USR_DESIGNATION = item.USR_DESIGNATION;
                            USR_LAST_LOGIN_DATE = item.USR_LAST_LOGIN_DATE;
                            USR_PREF_LANG = item.USR_PREF_LANG;
                            USR_PREF_THEME = item.USR_PREF_THEME;
                            USR_REGION = item.USR_REGION;
                            log.DetailLog("Login.aspx.cs", "Login_Clicked", STATE.INITIALIZED, "STATUS CODE: 0200 OK. \tDatabase Entry Found of User With Plain Passcode, \nDetails: { USER_LOGIN_ID: \"" + userID + "\"\t& USER_CURRENT_PASSCODE: \"" + password + "\"}");
                            break;
                        }
                        else
                        {
                            statusFlag = 0204;

                        }
                        #endregion
                    }
                    #region STATUS_CODE_0200_01_02_OK
                    if (statusFlag == 0200 || statusFlag == 0201 || statusFlag == 0202)
                    {
                        statusLogin = true;
                        Session["USR_LOGIN_ID"] = userID;
                        Session["USR_CURRENT_PASSCODE"] = password;
                        Session["USR_DEPT_ID"] = USR_DEPT_ID;
                        Session["USR_DESIGNATION"] = USR_DESIGNATION;
                        Session["USR_LAST_LOGIN_DATE"] = USR_LAST_LOGIN_DATE;
                        Session["USR_PREF_LANG"] = USR_PREF_LANG;
                        Session["USR_PREF_THEME"] = USR_PREF_THEME;
                        Session["USR_REGION"] = USR_REGION;
                        lblStatus.Text = "STATUS CODE: 0200";
                        Debug.WriteLine("Department: "+USR_DEPT_ID);
                        if (USR_DEPT_ID == "1") {
                            Response.Redirect("ProtectedPages/Dashboard.aspx", false);
                        }
                        else if (USR_DEPT_ID == "2")
                        {
                            Response.Redirect("ProtectedPages/Dashboard.aspx", false);
                        }
                        else if (USR_DEPT_ID == "3")
                        {
                            Response.Redirect("ProtectedPages/Dashboard.aspx", false);
                        }
                        else if (USR_DEPT_ID == "4")
                        {
                            Response.Redirect("ProtectedPages/Dashboard.aspx", false);
                        }
                        else {
                            Response.Redirect("ProtectedPages/Dashboard.aspx", false);
                        }

                        
                    }
                    #endregion
                    #region STATUS_CODE_0204_NOT_FOUND
                    else if (statusFlag == 0204)
                    {
                        statusLogin = false;
                        Debug.WriteLine("Response Code: " + statusFlag + " No Database Record Found.");
                    }
                    #endregion
                    #region GENERAL_ELSE
                    else
                    {
                        lblStatus.Text = "Response Code: 0401";
                        Debug.WriteLine("Response Code: 0401");
                        Debug.WriteLine("Login Failed.");
                    }
                    #endregion

                }
                #endregion
                #region ELSE_USER_ID_IS_NULL
                else
                {
                    lblStatus.Text = "Response Code: 0401";
                    Debug.WriteLine("Response Code: 0401 Outside");
                }
                #endregion
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