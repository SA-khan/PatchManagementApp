﻿using System;
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
    public partial class Default : System.Web.UI.Page
    {
        Log log = new Log();
        protected void Page_Load(object sender, EventArgs e)
        {

            log.DetailLog("Default.aspx.cs", "Page_Load", STATE.INITIALIZED, "Method: Page_Load in Class: Default.aspx.cs has Initialized.");
            Debug.WriteLine(dropLanguage.SelectedItem);

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

        }
    }
}