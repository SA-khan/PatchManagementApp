﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using HelloWorld.App_Code;

namespace HelloWorld.ProtectedPages
{
    public partial class Dashboard : System.Web.UI.Page
    {
        //protected string[] clientList;
        static DatabaseConnectivity dbgraph = new DatabaseConnectivity();
        //public string[] clientList = { "BAFL", "HBL", "HBL AMC", "PMRC", "ABL" };
        public string[] clientList = dbgraph.getClientListString();
        public int[] numberOfBuild = dbgraph.getClientListInt();

        protected System.Web.Script.Serialization.JavaScriptSerializer serializer;

        protected void Page_Load(object sender, EventArgs e)
        {
            serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

            if (Request.Cookies["UserID"] != null) // && Request.Cookies["Password"] != null
            {
                //String[] cookies = Request.Cookies.AllKeys;
                String userid = Request.Cookies.Get("UserID").Value;
                String password = Request.Cookies.Get("Password").Value;
                Debug.WriteLine("User Loggedin with UserID: " + userid + " and Pwd: " + password);

                DatabaseConnectivity dbcon = new DatabaseConnectivity();
                //string[] clientList = dbcon.getClientList();
                //clientList = new[] {"BAFL", "HBL", "HBL AMC", "PMRC", "ABL"};
                

            }
            //if()
            //try
            //{
            //    if (Session["UserID"] != null)
            //    {
            //        lblUser.Text = "Hi " + Session["UserID"];
            //    }
            //    else
            //    {
            //        Response.Redirect("~/Default.aspx", true);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(ex.Message);
            //}
        }
    }
}