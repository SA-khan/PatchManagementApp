using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelloWorld.App_Code;
using System.Threading;
using System.Globalization;
using System.Diagnostics;

namespace HelloWorld
{
    public partial class Default : MyBasePage
    {
        Log log = new Log();
        protected void Page_Load(object sender, EventArgs e)
        {

            log.DetailLog("Default.aspx.cs", "Page_Load", STATE.INITIALIZED, "Method: Page_Load in Class: Default.aspx.cs has Initialized.");
            #region Cookies

            #region Read_Cookie

            if (!Page.IsPostBack) {
                string selectedTheme = Page.Theme;
                HttpCookie Get_Theme_Cookie = Request.Cookies.Get("Theme");
                //string selectedRegion = Request.Cookies.Get("Region").Value;
                //HttpCookie Get_Region_Cookie = Request.Cookies.Get("Region");
                //string selectedLanguage = Request.Cookies.Get("Langauge").Value;
                //HttpCookie Get_Language_Cookie = Request.Cookies.Get("Langauge");
                if (Get_Theme_Cookie != null) {
                    selectedTheme = Get_Theme_Cookie.Value;
                }
                if (!string.IsNullOrEmpty(selectedTheme)) {
                    ListItem item = dropTheme.Items.FindByValue(selectedTheme);
                    if (item != null) {
                        item.Selected = true;
                        Debug.WriteLine(Get_Theme_Cookie.Name + ": " + Get_Theme_Cookie.Value);
                    }
                }

                //if (Get_Region_Cookie != null)
                //{
                //    selectedRegion = Get_Region_Cookie.Value;
                //}
                //if (!string.IsNullOrEmpty(selectedRegion))
                //{
                //    ListItem item = dropRegion.Items.FindByValue(selectedRegion);
                //    if (item != null)
                //    {
                //        item.Selected = true;
                //        Debug.WriteLine(Get_Region_Cookie.Name + ": " + Get_Region_Cookie.Value);
                //    }
                //}

                //if (Get_Language_Cookie != null)
                //{
                //    selectedLanguage = Get_Language_Cookie.Value;
                //}
                //if (!string.IsNullOrEmpty(selectedLanguage))
                //{
                //    ListItem item = dropLanguage.Items.FindByValue(selectedLanguage);
                //    if (item != null)
                //    {
                //        item.Selected = true;
                //        Debug.WriteLine(Get_Language_Cookie.Name + ": " + Get_Language_Cookie.Value);
                //    }
                //}

            }


            #endregion

            #region Theme_Cookie
            //if (Response.Cookies.Get("Theme") != null)
            //{
                
            //}
            #endregion
            #region Region_Cookie
            //if (Response.Cookies.Get("Region") == null)
            //{
            //    HttpCookie _regionCookie = new HttpCookie("Region");
            //    _regionCookie.Expires = DateTime.Now.AddMonths(3);
            //    //_regionCookie.Value = dropRegion.SelectedItem.ToString().ToLower();
            //    _regionCookie.Value = "pakistan";
            //    Response.Cookies.Add(_regionCookie);
            //}
            #endregion
            #region Language_Cookie
            //if (Response.Cookies.Get("Language") == null)
            //{
            //    HttpCookie _languageCookie = new HttpCookie("Language");
            //    _languageCookie.Expires = DateTime.Now.AddMonths(3);
            //    _languageCookie.Value = dropLanguage.SelectedItem.ToString();
            //    Response.Cookies.Add(_languageCookie);
            //}
            #endregion

            #endregion
            #region Languages

            #region English_Language

            if (dropLanguage.SelectedItem.Text =="English")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-En");
                Localize1.Text = Properties.strings.Hello.ToString();
                LocalHeading.Text = Properties.strings.Release_Management_Portal.ToString();
                LocalSubheading.Text = Properties.strings.Reshaping_the_way_we_do_things.ToString();
                LocalLoginPanel.Text = Properties.strings.Login_Panel.ToString();
                LocalLoginPanelSubHeading.Text = Properties.strings.View_Add_Edit_And_Delete_Release_Environment_Client.ToString();
                LocalLoginPanelButton.Text = Properties.strings.Goto.ToString() + " " + Properties.strings.Login.ToString();
                LocalAppOverview.Text = Properties.strings.App_Overview.ToString();
                LocalAppOverviewSubHeading.Text = Properties.strings.View_the_latest_Application_Overview.ToString();
                LocalAppOverviewButton.Text = Properties.strings.View.ToString();
                LocalEnvironmentOverview.Text = Properties.strings.Environment_Overview.ToString();
                LocalEnvironmentOverviewSubHeading.Text = Properties.strings.View_the_latest_Environments_Overview.ToString();
                LocalEnvironmentOverviewButton.Text = Properties.strings.View.ToString();
                LocalReferencesAndDocuments.Text = Properties.strings.References_And_Documents.ToString();
                LocalReferencesAndDocumentsSubHeading.Text = Properties.strings.View_and_Download_the_authentic_References.ToString();
                LocalReferencesAndDocumentsButton.Text = Properties.strings.View.ToString();
                LocalSearch.Text = Properties.strings.Search.ToString();
                LocalSearch.Text = Properties.strings.Search.ToString();
                LocalClassic.Text = Properties.strings.Classic.ToString();
                LocalDark.Text = Properties.strings.Dark.ToString();
                LocalPakistan.Text = Properties.strings.Pakistan.ToString();
                LocalUAE.Text = Properties.strings.United_Arab_Emirates.ToString();
                LocalUK.Text = Properties.strings.United_Kingdom.ToString();
            }

            #endregion English_Language

            #region French_Language

            else if (dropLanguage.SelectedItem.Text == "French")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("fr-FR");
                Localize1.Text = Properties.strings.Hello.ToString();
                LocalHeading.Text = Properties.strings.Release_Management_Portal.ToString();
                LocalSubheading.Text = Properties.strings.Reshaping_the_way_we_do_things.ToString();
                LocalLoginPanel.Text = Properties.strings.Login_Panel.ToString();
                LocalLoginPanelSubHeading.Text = Properties.strings.View_Add_Edit_And_Delete_Release_Environment_Client.ToString();
                LocalLoginPanelButton.Text = Properties.strings.Goto.ToString() + " " + Properties.strings.Login.ToString();
                LocalAppOverview.Text = Properties.strings.App_Overview.ToString();
                LocalAppOverviewSubHeading.Text = Properties.strings.View_the_latest_Application_Overview.ToString();
                LocalAppOverviewButton.Text = Properties.strings.View.ToString();
                LocalEnvironmentOverview.Text = Properties.strings.Environment_Overview.ToString();
                LocalEnvironmentOverviewSubHeading.Text = Properties.strings.View_the_latest_Environments_Overview.ToString();
                LocalEnvironmentOverviewButton.Text = Properties.strings.View.ToString();
                LocalReferencesAndDocuments.Text = Properties.strings.References_And_Documents.ToString();
                LocalReferencesAndDocumentsSubHeading.Text = Properties.strings.View_and_Download_the_authentic_References.ToString();
                LocalReferencesAndDocumentsButton.Text = Properties.strings.View.ToString();
                LocalSearch.Text = Properties.strings.Search.ToString();
                LocalSearch.Text = Properties.strings.Search.ToString();
                LocalClassic.Text = Properties.strings.Classic.ToString();
                LocalDark.Text = Properties.strings.Dark.ToString();
                LocalPakistan.Text = Properties.strings.Pakistan.ToString();
                LocalUAE.Text = Properties.strings.United_Arab_Emirates.ToString();
                LocalUK.Text = Properties.strings.United_Kingdom.ToString();

            }

            #endregion French_Language

            #region Urdu_Language

            else if (dropLanguage.SelectedItem.Text == "اردو") {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ur-UR");
                Localize1.Text = Properties.strings.Hello.ToString();
                LocalHeading.Text = Properties.strings.Release_Management_Portal.ToString();
                //LocalSubheading.Text = Properties.strings.Reshaping + " " + Properties.strings.the + " " + Properties.strings.way + " " + Properties.strings.we + " " + Properties.strings._do + " " + Properties.strings.things;
                LocalSubheading.Text = Properties.strings.Reshaping_the_way_we_do_things;
                LocalLoginPanel.Text = Properties.strings.Login_Panel.ToString();
                LocalLoginPanelSubHeading.Text = Properties.strings.View_Add_Edit_And_Delete_Release_Environment_Client.ToString();
                LocalLoginPanelButton.Text = Properties.strings.Goto.ToString() + " " + Properties.strings.Login.ToString();
                LocalAppOverview.Text = Properties.strings.App_Overview.ToString();
                LocalAppOverviewSubHeading.Text = Properties.strings.View_the_latest_Application_Overview.ToString();
                LocalAppOverviewButton.Text = Properties.strings.View.ToString();
                LocalEnvironmentOverview.Text = Properties.strings.Environment_Overview.ToString();
                LocalEnvironmentOverviewSubHeading.Text = Properties.strings.View_the_latest_Environments_Overview.ToString();
                LocalEnvironmentOverviewButton.Text = Properties.strings.View.ToString();
                LocalReferencesAndDocuments.Text = Properties.strings.References_And_Documents.ToString();
                LocalReferencesAndDocumentsSubHeading.Text = Properties.strings.View_and_Download_the_authentic_References.ToString();
                LocalReferencesAndDocumentsButton.Text = Properties.strings.View.ToString();
                //localSearchText.Text = Properties.strings.Search.ToString() + "..";
                LocalSearch.Text = Properties.strings.Search.ToString();
                LocalClassic.Text = Properties.strings.Classic.ToString();
                LocalDark.Text = Properties.strings.Dark.ToString();
                LocalPakistan.Text = Properties.strings.Pakistan.ToString();
                LocalUAE.Text = Properties.strings.United_Arab_Emirates.ToString();
                LocalUK.Text = Properties.strings.United_Kingdom.ToString();
            }

            #endregion Urdu_Language

            #region Arabic_Language

            else if (dropLanguage.SelectedItem.Text == "عربى")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ar-AR");
                Localize1.Text = Properties.strings.Hello.ToString();
                LocalHeading.Text = Properties.strings.Release_Management_Portal.ToString();
                //LocalSubheading.Text = Properties.strings.Reshaping + " " + Properties.strings.the + " " + Properties.strings.way + " " + Properties.strings.we + " " + Properties.strings._do + " " + Properties.strings.things;
                LocalSubheading.Text = Properties.strings.Reshaping_the_way_we_do_things;
                LocalLoginPanel.Text = Properties.strings.Login_Panel.ToString();
                LocalLoginPanelSubHeading.Text = Properties.strings.View_Add_Edit_And_Delete_Release_Environment_Client.ToString();
                LocalLoginPanelButton.Text = Properties.strings.Goto.ToString() + " " + Properties.strings.Login.ToString();
                LocalAppOverview.Text = Properties.strings.App_Overview.ToString();
                LocalAppOverviewSubHeading.Text = Properties.strings.View_the_latest_Application_Overview.ToString();
                LocalAppOverviewButton.Text = Properties.strings.View.ToString();
                LocalEnvironmentOverview.Text = Properties.strings.Environment_Overview.ToString();
                LocalEnvironmentOverviewSubHeading.Text = Properties.strings.View_the_latest_Environments_Overview.ToString();
                LocalEnvironmentOverviewButton.Text = Properties.strings.View.ToString();
                LocalReferencesAndDocuments.Text = Properties.strings.References_And_Documents.ToString();
                LocalReferencesAndDocumentsSubHeading.Text = Properties.strings.View_and_Download_the_authentic_References.ToString();
                LocalReferencesAndDocumentsButton.Text = Properties.strings.View.ToString();
                //localSearchText.Text = Properties.strings.Search.ToString() + "..";
                LocalSearch.Text = Properties.strings.Search.ToString();
                LocalClassic.Text = Properties.strings.Classic.ToString();
                LocalDark.Text = Properties.strings.Dark.ToString();
                LocalPakistan.Text = Properties.strings.Pakistan.ToString();
                LocalUAE.Text = Properties.strings.United_Arab_Emirates.ToString();
                LocalUK.Text = Properties.strings.United_Kingdom.ToString();
            }

            #endregion Arabic_Language

            #region Spanish_Language

            else if (dropLanguage.SelectedItem.Text == "Spanish")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("sk-SK");
                Localize1.Text = Properties.strings.Hello.ToString();
                LocalHeading.Text = Properties.strings.Release_Management_Portal.ToString();
                //LocalSubheading.Text = Properties.strings.Reshaping + " " + Properties.strings.the + " " + Properties.strings.way + " " + Properties.strings.we + " " + Properties.strings._do + " " + Properties.strings.things;
                LocalSubheading.Text = Properties.strings.Reshaping_the_way_we_do_things;
                LocalLoginPanel.Text = Properties.strings.Login_Panel.ToString();
                LocalLoginPanelSubHeading.Text = Properties.strings.View_Add_Edit_And_Delete_Release_Environment_Client.ToString();
                LocalLoginPanelButton.Text = Properties.strings.Goto.ToString() + " " + Properties.strings.Login.ToString();
                LocalAppOverview.Text = Properties.strings.App_Overview.ToString();
                LocalAppOverviewSubHeading.Text = Properties.strings.View_the_latest_Application_Overview.ToString();
                LocalAppOverviewButton.Text = Properties.strings.View.ToString();
                LocalEnvironmentOverview.Text = Properties.strings.Environment_Overview.ToString();
                LocalEnvironmentOverviewSubHeading.Text = Properties.strings.View_the_latest_Environments_Overview.ToString();
                LocalEnvironmentOverviewButton.Text = Properties.strings.View.ToString();
                LocalReferencesAndDocuments.Text = Properties.strings.References_And_Documents.ToString();
                LocalReferencesAndDocumentsSubHeading.Text = Properties.strings.View_and_Download_the_authentic_References.ToString();
                LocalReferencesAndDocumentsButton.Text = Properties.strings.View.ToString();
                //localSearchText.Text = Properties.strings.Search.ToString() + "..";
                LocalSearch.Text = Properties.strings.Search.ToString();
                LocalClassic.Text = Properties.strings.Classic.ToString();
                LocalDark.Text = Properties.strings.Dark.ToString();
                LocalPakistan.Text = Properties.strings.Pakistan.ToString();
                LocalUAE.Text = Properties.strings.United_Arab_Emirates.ToString();
                LocalUK.Text = Properties.strings.United_Kingdom.ToString();
            }

            #endregion Spanish_Language

            #region Germon_Language

            else if (dropLanguage.SelectedItem.Text == "Germon")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");
                Localize1.Text = Properties.strings.Hello.ToString();
                LocalHeading.Text = Properties.strings.Release_Management_Portal.ToString();
                LocalSubheading.Text = Properties.strings.Reshaping_the_way_we_do_things;
                LocalLoginPanel.Text = Properties.strings.Login_Panel.ToString();
                LocalLoginPanelSubHeading.Text = Properties.strings.View_Add_Edit_And_Delete_Release_Environment_Client.ToString();
                LocalLoginPanelButton.Text = Properties.strings.Goto.ToString() + " " + Properties.strings.Login.ToString();
                LocalAppOverview.Text = Properties.strings.App_Overview.ToString();
                LocalAppOverviewSubHeading.Text = Properties.strings.View_the_latest_Application_Overview.ToString();
                LocalAppOverviewButton.Text = Properties.strings.View.ToString();
                LocalEnvironmentOverview.Text = Properties.strings.Environment_Overview.ToString();
                LocalEnvironmentOverviewSubHeading.Text = Properties.strings.View_the_latest_Environments_Overview.ToString();
                LocalEnvironmentOverviewButton.Text = Properties.strings.View.ToString();
                LocalReferencesAndDocuments.Text = Properties.strings.References_And_Documents.ToString();
                LocalReferencesAndDocumentsSubHeading.Text = Properties.strings.View_and_Download_the_authentic_References.ToString();
                LocalReferencesAndDocumentsButton.Text = Properties.strings.View.ToString();
                LocalSearch.Text = Properties.strings.Search.ToString();
                LocalClassic.Text = Properties.strings.Classic.ToString();
                LocalDark.Text = Properties.strings.Dark.ToString();
                LocalPakistan.Text = Properties.strings.Pakistan.ToString();
                LocalUAE.Text = Properties.strings.United_Arab_Emirates.ToString();
                LocalUK.Text = Properties.strings.United_Kingdom.ToString();
            }

            #endregion Germon_Language

            #region Sindhi_Language

            else if (dropLanguage.SelectedItem.Text == "سنڌي")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("sn-SN");
                Localize1.Text = Properties.strings.Hello.ToString();
                LocalHeading.Text = Properties.strings.Release_Management_Portal.ToString();
                LocalSubheading.Text = Properties.strings.Reshaping_the_way_we_do_things;
                LocalLoginPanel.Text = Properties.strings.Login_Panel.ToString();
                LocalLoginPanelSubHeading.Text = Properties.strings.View_Add_Edit_And_Delete_Release_Environment_Client.ToString();
                LocalLoginPanelButton.Text = Properties.strings.Goto.ToString() + " " + Properties.strings.Login.ToString();
                LocalAppOverview.Text = Properties.strings.App_Overview.ToString();
                LocalAppOverviewSubHeading.Text = Properties.strings.View_the_latest_Application_Overview.ToString();
                LocalAppOverviewButton.Text = Properties.strings.View.ToString();
                LocalEnvironmentOverview.Text = Properties.strings.Environment_Overview.ToString();
                LocalEnvironmentOverviewSubHeading.Text = Properties.strings.View_the_latest_Environments_Overview.ToString();
                LocalEnvironmentOverviewButton.Text = Properties.strings.View.ToString();
                LocalReferencesAndDocuments.Text = Properties.strings.References_And_Documents.ToString();
                LocalReferencesAndDocumentsSubHeading.Text = Properties.strings.View_and_Download_the_authentic_References.ToString();
                LocalReferencesAndDocumentsButton.Text = Properties.strings.View.ToString();
                LocalSearch.Text = Properties.strings.Search.ToString();
                LocalClassic.Text = Properties.strings.Classic.ToString();
                LocalDark.Text = Properties.strings.Dark.ToString();
                LocalPakistan.Text = Properties.strings.Pakistan.ToString();
                LocalUAE.Text = Properties.strings.United_Arab_Emirates.ToString();
                LocalUK.Text = Properties.strings.United_Kingdom.ToString();
            }

            #endregion Sindhi_Language

            #endregion

        }

        protected void dropLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Language

            #region Language_Cookie
            HttpCookie _languageCookie = new HttpCookie("Language");
            _languageCookie.Expires = DateTime.Now.AddMonths(3);
            _languageCookie.Value = dropLanguage.SelectedItem.ToString().ToLower();
            Response.Cookies.Add(_languageCookie);
            #endregion

            #endregion
        }

        protected void dropTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Debug.WriteLine("Selected Theme: " + dropTheme.SelectedItem.ToString());
            //HttpCookie cookie = Request.Cookies.Get("Theme");
            //if (cookie.Value.ToString() == "Dark")
            //{
            //    dropTheme.SelectedIndex = 1;
            //}
            //else
            //{
            //    dropTheme.SelectedIndex = 0;
            //}
            HttpCookie _themeCookie = new HttpCookie("Theme");
            _themeCookie.Expires = DateTime.Now.AddMonths(3);
            _themeCookie.Value = dropTheme.SelectedValue;
            Response.Cookies.Add(_themeCookie);
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
            //Response.Redirect(Server.MapPath("~/Default.aspx"));
        }

        protected void dropRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("Region: " + "");
            HttpCookie _regionCookie = new HttpCookie("Region");
            _regionCookie.Expires = DateTime.Now.AddMonths(3);
            //_regionCookie.Value = dropRegion.SelectedItem.ToString().ToLower();
            Response.Cookies.Add(_regionCookie);
        }


    }
}