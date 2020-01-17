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
        protected void Page_Load(object sender, EventArgs e)
        {
            bool rememberCheck = checkRemember.Checked;
            Debug.WriteLine("Remember Me Check Status: " + rememberCheck);
            if (rememberCheck == true)
            {
                //string userid = dropUserId.Text.ToString();
                //string password = txtPassword.Text.ToString();
                //HttpCookie userCookie = new HttpCookie();
                //HttpCookie passCookie = new HttpCookie();
                //userCookie.Name = "UserID";
                //passCookie.Name = "Password";
                //userCookie.Value = userid;
                //passCookie.Value = password;
                //userCookie.HttpOnly = true;
                //passCookie.HttpOnly = true;
                //userCookie.Expires.AddDays(3);
                //passCookie.Expires.AddDays(3);
            }
            //try
            //{
            //    if (Session["name"] != null)
            //        lblName.Text = Session["name"].ToString();
            //    else
            //        //Server.Transfer("Default.aspx");
            //        Response.Redirect("Default.aspx");
            //}
            //catch (Exception ex) {
            //    lblName.Text = ex.Message;
            //}
        }

        protected void Login_Clicked(object sender, EventArgs e)
        {
            string userID = dropUserId.Text.ToString();
            string password = txtPassword.Text.ToString();
            bool loginStatus = false;
            Debug.WriteLine("UserID is: " + userID);
            Debug.WriteLine("Password is: " + password);
            if(userID != "Select UserID" && userID != ""){
                DatabaseConnectivity dbcon = new DatabaseConnectivity();
                List<User> userList = dbcon.getAuthUsers();
                foreach (var item in userList) {
                    if (userID.Equals(item.UserID) && password.Equals(item.Password))
                    {
                        loginStatus = true;
                        Session["UserID"] = userID;
                        break;
                    }
                    else { 
                    
                    }
                }

                if (loginStatus)
                {
                    lblStatus.Text = "Response Code: ";
                    lblStatusCode.Text = "0200";
                    Response.Redirect("~/ProtectedPages/Dashboard.aspx");
                }
                else {
                    lblStatus.Text = "Response Code: ";
                    lblStatusCode.Text = "0401";
                }

            }
            else {
                lblStatus.Text = "Response Code: ";
                lblStatusCode.Text = "0401";
            }
        }
    }
}