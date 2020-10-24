using CefSharp;
using CefSharp.WinForms;
using SteamAccCreator.File.MainUI.Browsers;
using SteamAccCreator.File.MainUI.HTML.DocumentFiles.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAccCreator.File.MainUI.Classes
{
    class AutoHide
    {
        public static void Hide()
        {
            //HideItem(MainBrowser.browser, "Start", "chk_CaptchaSolutions,chk_TwoCaptcha");
            Globals.iMaxAccountsToGenerate = 10;
            Globals.imaxThreads = 10;
            Globals.iMaxThreadCooldown = 999;
            Globals.iMaxAccountsPerProxy = 999;
            Globals.emailaddAllowed = false;
            Globals.gameaddAllowed = false;
        }
        public static void ShowPremiumItems()
        {
            Globals.iMaxAccountsToGenerate = 999999999;
            Globals.imaxThreads = 999999999;
            Globals.iMaxThreadCooldown = 999999999;
            Globals.iMaxAccountsPerProxy = 999999999;
            Globals.emailaddAllowed = true;
            Globals.gameaddAllowed = true;
        }
        public static void HideItem(ChromiumWebBrowser browser, string Page, string HtmlID)
        {
            string[] amount = HtmlID.Split(',');
            string ReplacedHtml = "";
            foreach (string id in amount)
            {
                string Html = DF_Getter.get("SteamAccCreator.File.MainUI.HTML.DocumentFiles.HTML." + Page + "Page.html");
                string[] split = Html.Split('\n');
                
                foreach (string a in split)
                {
                    if (a.Contains(id))
                    {
                        if(ReplacedHtml == "")
                        {
                            string newHtml = Html.Replace(a, "<!--" + a + "-->");
                            ReplacedHtml = newHtml;
                        }
                        else
                        {
                            string n = ReplacedHtml.Replace(a, "<!--" + a + "-->");
                            ReplacedHtml = n;
                        }
                    }
                }
            }
            browser.LoadHtml(ReplacedHtml + "<script>" + DF_Getter.get("SteamAccCreator.File.MainUI.HTML.DocumentFiles.JS." + Page + "Page.js") + "</script>" + "<style>" + DF_Getter.get("SteamAccCreator.File.MainUI.HTML.DocumentFiles.CSS." + Page + "Page.css") + "</style>");
        }
        public static void ShowItem(ChromiumWebBrowser browser, string Page, string HtmlID)
        {
            string[] amount = HtmlID.Split(',');
            string ReplacedHtml = "";
            foreach (string id in amount)
            {
                string Html = DF_Getter.get("SteamAccCreator.File.MainUI.HTML.DocumentFiles.HTML." + Page + "Page.html");
                string[] split = Html.Split('\n');

                foreach (string a in split)
                {
                    if (a.Contains(id))
                    {
                        string k = a.Replace("<!--", string.Empty).Replace("-->", string.Empty);
                        if (ReplacedHtml == "")
                        {
                            string newHtml = Html.Replace(a, k);
                            ReplacedHtml = newHtml;
                        }
                        else
                        {
                            string n = ReplacedHtml.Replace(a, k);
                            ReplacedHtml = n;
                        }
                    }
                }
            }
            browser.LoadHtml(ReplacedHtml + "<script>" + DF_Getter.get("SteamAccCreator.File.MainUI.HTML.DocumentFiles.JS." + Page + "Page.js") + "</script>" + "<style>" + DF_Getter.get("SteamAccCreator.File.MainUI.HTML.DocumentFiles.CSS." + Page + "Page.css") + "</style>");
        }
    }
}
