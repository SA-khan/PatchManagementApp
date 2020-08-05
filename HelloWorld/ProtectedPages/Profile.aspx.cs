using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloWorld.ProtectedPages
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count > 0)
            {
                if (Session["USR_LOGIN_ID"] != null)
                {
                    localUserLoginID.Text = Session["USR_LOGIN_ID"].ToString();
                    if (Session["USR_DEPT_ID"] != null)
                    {
                        localUserDepartment.Text = Session["USR_DEPT_ID"].ToString();
                        if (Session["USR_DESIGNATION"] != null)
                        {
                            localUserDesignation.Text = Session["USR_DESIGNATION"].ToString();
                            if (Session["USR_PREF_LANG"] != null)
                            {
                                localUserLanguage.Text = Session["USR_PREF_LANG"].ToString();
                                if (Session["USR_PREF_THEME"] != null)
                                {
                                    localUserTheme.Text = Session["USR_PREF_THEME"].ToString();
                                    if (Session["USR_REGION"] != null)
                                    {
                                        localUserRegion.Text = Session["USR_REGION"].ToString();
                                        if (Session["USR_LAST_LOGIN_DATE"] != null) {
                                            localUserLastLoginDate.Text = Session["USR_LAST_LOGIN_DATE"].ToString();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                localUserPasscode.Text = "*******";
            }
        }
    }
}