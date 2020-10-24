using CefSharp.WinForms;
using SteamAccCreator.File.MainUI.Browsers;
using SteamAccCreator.File.MainUI.WebDocs.GridPage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamAccCreator.File.MainUI.WebDocs.GridPage
{
    class GridPageEdit
    {
        public static string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string specificFolder = Path.Combine(folder, "LothosGen");

        public static string HTMLFileCode = "ASDUISA9845bh948bASIDbASBDg798456bAFABSJ";
        public static string HTMLFileCodeExtension = ".html";
        public static string HTMLFileLocation = (specificFolder + "\\" + HTMLFileCode + HTMLFileCodeExtension);

        public static string CSSFileCode = "bh49yu5vbiasdSAIDAVSDasd6984as186s1f6s5g135gh1321xf";
        public static string CSSFileCodeExtension = ".css";
        public static string CSSFileLocation = (specificFolder + "\\" + CSSFileCode + CSSFileCodeExtension);

        public static string JSFileCode = "aRBGYBASBDbKASJb45u6534f5g165jiu1k56h165df1s56f15s6d1fad";
        public static string JSFileCodeExtension = ".js";
        public static string JSFileLocation = (specificFolder + "\\" + JSFileCode + JSFileCodeExtension);

        static string CurrentDirectory = Directory.GetCurrentDirectory();

        public string URL = "about:blank";
        public static ChromiumWebBrowser browser = RightBrowser.browser;

        public static void Default()
        {
            browser.Load(new Uri(String.Format(HTMLFileLocation)).ToString());

        }
        public static void Reload()
        {
            RightBrowser.LoadGridPage();
        }
        public static void ReloadTable()
        {
            RightBrowser.LoadGridPage();
        }
        public static void AddToTable(string text)
        {
            GPGlobals.History += text;
            //RightBrowser.LoadGridPage();
        }
        public static string getHistory()
        {
            return GPGlobals.History;
        }
    }
}

