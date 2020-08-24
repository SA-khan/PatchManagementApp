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
    public partial class SiteLogout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["USR_LOGIN_ID"] != null)
                {
                    Char[] charUserId = Session["USR_LOGIN_ID"].ToString().ToCharArray();
                    int length = charUserId.Count();
                    Debug.Write("UserID Character Count: " + length);

                    if (length < 12)
                        lblLoginIDResult.Text = Session["USR_LOGIN_ID"].ToString();
                    else
                        lblLoginIDResult.Text = Session["USR_LOGIN_ID"].ToString().Substring(0, 10) + "..";

                    try
                    {
                        //Session["USR_CURRENT_PASSCODE"];
                        DatabaseConnectivity dbcon = new DatabaseConnectivity();
                        int deptid = Convert.ToInt32(Session["USR_DEPT_ID"]);
                        int desgid = Convert.ToInt32(Session["USR_DESIGNATION"].ToString());
                        lblDepartmentResult.Text = dbcon.getDepartmentNameByID(Session["USR_DEPT_ID"].ToString());
                        lblDesignationResult.Text = dbcon.getDesignationNameByID(Session["USR_DESIGNATION"].ToString());
                        string[] a = Session["USR_LAST_LOGIN_DATE"].ToString().Split(' ');
                        lblLoginDateResult.Text = a[0];
                        lblLanguageResult.Text = Session["USR_PREF_LANG"].ToString();
                        lblThemeResult.Text = Session["USR_PREF_THEME"].ToString();
                        lblRegionResult.Text = Session["USR_REGION"].ToString();
                    }
                    catch (Exception ex) {
                        Debug.WriteLine("Exception 13/7/2: " + ex.Message);
                    }
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