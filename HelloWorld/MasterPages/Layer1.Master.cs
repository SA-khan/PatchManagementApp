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

namespace HelloWorld.MasterPages
{
    public partial class Layer1 : System.Web.UI.MasterPage
    {
        Log log = new Log();
        protected void Page_Load(object sender, EventArgs e)
        {
            log.DetailLog("Layer1.Master.cs", "Page_Load", STATE.INITIALIZED, "Method: Page_Load in Class: Layer1.Master.cs has Initialized.");
            Debug.WriteLine(dropLanguage.SelectedItem);

            #region English_Language

            if (dropLanguage.SelectedItem.Text == "English")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-En");
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

            else if (dropLanguage.SelectedItem.Text == "اردو")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ur-UR");
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
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("sp-SP");
                LocalSearch.Text = Properties.strings.Search.ToString();
                LocalClassic.Text = Properties.strings.Classic.ToString();
                LocalDark.Text = Properties.strings.Dark.ToString();
                LocalPakistan.Text = Properties.strings.Pakistan.ToString();
                LocalUAE.Text = Properties.strings.United_Arab_Emirates.ToString();
                LocalUK.Text = Properties.strings.United_Kingdom.ToString();
            }

            #endregion Spanish_Language

            #region Germon_Language

            else if (dropLanguage.SelectedItem.Text == "German")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ge-GE");
                LocalSearch.Text = Properties.strings.Search.ToString();
                LocalClassic.Text = Properties.strings.Classic.ToString();
                LocalDark.Text = Properties.strings.Dark.ToString();
                LocalPakistan.Text = Properties.strings.Pakistan.ToString();
                LocalUAE.Text = Properties.strings.United_Arab_Emirates.ToString();
                LocalUK.Text = Properties.strings.United_Kingdom.ToString();
            }

            #endregion Germon_Language

        }
    }
}