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
    public partial class AddClientType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string title = txtCTypeTitle.Text.ToString();
            string desc = txtCTypeDesc.Text.ToString();
            if (title != null)
            {
                Debug.WriteLine("");
                Debug.WriteLine("User CType Title: " + title);
                Debug.WriteLine("User CType Description: " + desc);
                DatabaseConnectivity dbcon = new DatabaseConnectivity();
                int res = dbcon.insertClientType(title, desc);
                Debug.WriteLine("Query Status: " + res);
                if (res == 1)
                {
                    lblSubmission.Visible = true;
                    rowCTypeTitle.Visible = false;
                    rowCTypeDesc.Visible = false;
                    rowSubmit.Visible = false;
                }
            }
            else
            {
                Debug.WriteLine("alert(Please Enter User Role Title.)");
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtCTypeTitle.Text = "";
            txtCTypeDesc.Text = "";
        }
    }
}