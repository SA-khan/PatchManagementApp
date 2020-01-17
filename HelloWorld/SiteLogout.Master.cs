using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace HelloWorld
{
    public partial class SiteLogout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] != null)
                {
                    Char[] charUserId = Session["UserID"].ToString().ToCharArray();
                    int length = charUserId.Count();
                    Debug.Write("UserID Character Count: " + length);

                    if (length < 12)
                        lblUser.Text = Session["UserID"].ToString();
                    else
                        lblUser.Text = Session["UserID"].ToString().Substring(0, 10) + "..";
                }
                else
                {
                    Response.Redirect("~/Default.aspx", true);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        protected void linkLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("~/Default.aspx?ResponseCode=01&Remarks=Logout", true);
        }
    }
}