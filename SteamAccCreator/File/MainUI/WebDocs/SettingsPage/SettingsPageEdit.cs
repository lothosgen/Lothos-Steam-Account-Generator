using CefSharp.WinForms;
using SteamAccCreator.File.MainUI.Browsers;
using SteamAccCreator.File.MainUI.WebDocs.GridPage;
using SteamAccCreator.File.MainUI.WebDocs.SettingsPage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamAccCreator.File.MainUI.WebDocs.SettingsPage
{
    class SettingsPageEdit
    {
        public static ChromiumWebBrowser browser = RightBrowser.browser;

        public static void AddToTable(string text)
        {
            GPGlobals.History += text;
            //WriteHTML();
            GridPageEdit.Default();
        }
        public static string getHistory()
        {
            return GPGlobals.History;
        }
    }
}

