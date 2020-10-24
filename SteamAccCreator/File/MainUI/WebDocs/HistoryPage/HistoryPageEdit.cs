using CefSharp.WinForms;
using SteamAccCreator.File.MainUI.WebDocs.GridPage;
using SteamAccCreator.File.MainUI.WebDocs.HistoryPage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google;
using SteamAccCreator.File.MainUI.Browsers;

namespace SteamAccCreator.File.MainUI.WebDocs.HistoryPage
{
    class HistoryPageEdit
    {
        public static string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string specificFolder = Path.Combine(folder, "LothosGen");

        public static string HTMLFileCode = "ioABSDOUASBDAKSJDBk418165165regsfAFSDFubuiasd8";
        public static string HTMLFileCodeExtension = ".html";
        public static string HTMLFileLocation = (specificFolder + "\\" + HTMLFileCode + HTMLFileCodeExtension);

        public static string CSSFileCode = "ASUDBAKSJDBsadkjbaskjd4875g4785jkbdakjsDBkjbgjkbdfg";
        public static string CSSFileCodeExtension = ".css";
        public static string CSSFileLocation = (specificFolder + "\\" + CSSFileCode + CSSFileCodeExtension);
        
        public static string JSFileCode = "qasdNLAJSSDUBASUId0954jh609546nASLDFBNDSF";
        public static string JSFileCodeExtension = ".js";
        public static string JSFileLocation = (specificFolder + "\\" + JSFileCode + JSFileCodeExtension);

        static string CurrentDirectory = Directory.GetCurrentDirectory();

        public string URL = "about:blank";
        public static ChromiumWebBrowser browser = RightBrowser.browser;

        public static void Default()
        {
            
            browser.Load(new Uri(String.Format(HTMLFileLocation)).ToString());

        }
        public static void Startup()
        {
            if (!System.IO.Directory.Exists(FileManager.FolderLocation)) { System.IO.Directory.CreateDirectory(FileManager.FolderLocation); }
            if (!System.IO.File.Exists(FileManager.FileLocation)) { System.IO.File.Create(FileManager.FileLocation).Close(); ; }
            HPGlobals.History += System.IO.File.ReadAllText(FileManager.FileLocation);
        }
        public static void LoadHistory()
        {

        }
        public static void AddToTable(string text)
        {
            HPGlobals.History += text;
           // RightBrowser.LoadHistoryPage();
        }
        public static void Reload()
        {
            RightBrowser.LoadHistoryPage();
        }
        public static void AddAccountToTable(string mail, string alias, string password, int indexID)
        {
            HistoryPageEdit.AddToTable(@"<!--- (s) Start " + indexID.ToString() + @"--->
    <div name='StartNewRow' id=" + indexID.ToString() + @" class='row'>
      <div name='StartCell1' class='cell' data-title='Username'>
        <p name='Cell1Text'>" + alias + @"</p>
      </div name='EndCell1'>
      <div name='StartCell2' class='cell' data-title='Email'>
        <p name='Cell2Text' style='font-size: 11px;'>" + mail + @"</p>
      </div name='EndCell2'>
      <div name='StartCell3' class='cell' data-title='Password' >
        <p name='Cell3Text' style='font-size: 11px;' >" + password + @"</p>
      </div name='EndCell3'>
      <div name='StartCell4' class='cell' data-title='Status' >
        <p id='" + indexID.ToString() + @"' name='Cell4Text' style='font-size: 11px;'>Finished</p>
      </div name='EndCell4'>
    </div name='EndOfRow'> <!--- (e) End " + indexID.ToString() + @"--->
            ");
            using (var writer = new StreamWriter(FileManager.FileLocation, true))
            {
                writer.WriteLine(@"<!--- (s) Start " + indexID.ToString() + @"--->
    <div name='StartNewRow' id=" + indexID.ToString() + @" class='row'>
      <div name='StartCell1' class='cell' data-title='Username'>
        <p name='Cell1Text'>" + alias + @"</p>
      </div name='EndCell1'>
      <div name='StartCell2' class='cell' data-title='Email'>
        <p name='Cell2Text' style='font-size: 11px;'>" + mail + @"</p>
      </div name='EndCell2'>
      <div name='StartCell3' class='cell' data-title='Password' >
        <p name='Cell3Text' style='font-size: 11px;' >" + password + @"</p>
      </div name='EndCell3'>
      <div name='StartCell4' class='cell' data-title='Status' >
        <p id='" + indexID.ToString() + @"' name='Cell4Text' style='font-size: 11px;'>Finished</p>
      </div name='EndCell4'>
    </div name='EndOfRow'> <!--- (e) End " + indexID.ToString() + @"--->
            ");

            }
        }
    }
}

