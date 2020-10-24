using CefSharp;
using CefSharp.WinForms;
using SteamAccCreator.File.MainUI.Classes;
using SteamAccCreator.File.MainUI.HTML.DocumentFiles.Classes;
using SteamAccCreator.File.MainUI.WebDocs.GridPage;
using SteamAccCreator.File.MainUI.WebDocs.HistoryPage;
using SteamAccCreator.File.MainUI.WebDocs.SettingsPage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Panel = System.Windows.Forms.Panel;

namespace SteamAccCreator.File.MainUI.Browsers
{
    class RightBrowser
    {
        public static string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string specificFolder = Path.Combine(folder, "LothosGen");
        public static bool test = false;
        public static ChromiumWebBrowser browser;

        public static void StartBrowser(Panel panel)
        {
            browser = new ChromiumWebBrowser("about:blank");
            browser.MenuHandler = new CustomMenuHandler();
            
            panel.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;
            //browser.Width = 730;
            HistoryPageEdit.Startup();
            if(test == false)
            {
                SPGlobals.startup();
                test = true;
            }
            




        }
        public static void Hide()
        {
            RightBrowser.browser.Hide();
        }
        public static void LoadSettingsPage()
        {
            string[] split = DF_Getter.get("SteamAccCreator.File.MainUI.HTML.DocumentFiles.HTML.SettingsPage.html").Split('\n');
            string html = DF_Getter.get("SteamAccCreator.File.MainUI.HTML.DocumentFiles.HTML.SettingsPage.html");
            string newHTML = "";
            foreach (string n in split)
            {
                if (n.Contains("cb_email"))
                {
                    string add = n + SPGlobals.EmailProvidersHTML;
                    string x = html.Replace(n, add);
                    newHTML = x;
                }
                if (n.Contains("cb_proxy"))
                {
                    string add = n + SPGlobals.ProxyHTML;
                    string x = newHTML.Replace(n, add);
                    newHTML = x;
                }
            }
            browser.LoadHtml(newHTML + "<script>" + DF_Getter.get("SteamAccCreator.File.MainUI.HTML.DocumentFiles.JS.SettingsPage.js") + "</script>" + "<style>" + DF_Getter.get("SteamAccCreator.File.MainUI.HTML.DocumentFiles.CSS.SettingsPage.css") + "</style>");
            AutoHide.Hide();
        }
        public static void LoadGridPage()
        {
            string[] split = DF_Getter.get("SteamAccCreator.File.MainUI.HTML.DocumentFiles.HTML.GridPage.html").Split('\n');
            string html = DF_Getter.get("SteamAccCreator.File.MainUI.HTML.DocumentFiles.HTML.GridPage.html");
            string newHTML = "";
            foreach (string n in split)
            {
                if (n.Contains("add"))
                {
                    string add = n + GPGlobals.History;
                    string x = html.Replace(n, add);
                    newHTML = x;
                }
            }
            try
            {
                browser.LoadHtml(newHTML + "<script>" + DF_Getter.get("SteamAccCreator.File.MainUI.HTML.DocumentFiles.JS.GridPage.js") + "</script>" + "<style>" + DF_Getter.get("SteamAccCreator.File.MainUI.HTML.DocumentFiles.CSS.GridPage.css") + "</style>");
            }
            catch
            {
                browser.LoadHtml(newHTML + "<script>" + DF_Getter.get("SteamAccCreator.File.MainUI.HTML.DocumentFiles.JS.GridPage.js") + "</script>" + "<style>" + DF_Getter.get("SteamAccCreator.File.MainUI.HTML.DocumentFiles.CSS.GridPage.css") + "</style>", true);
            }
            
            AutoHide.Hide();
        }
        public static void LoadUpdatesPage()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://pastebin.com/raw/V2y2WWeu");

                HttpWebRequest r = request;
                r.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/29.0.1547.2 Safari/537.36";
                r.Timeout = 3000;
                HttpWebResponse re = (HttpWebResponse)r.GetResponse();
                Stream s = re.GetResponseStream();
                string pg = "";

                using (var reader = new StreamReader(s))
                {

                    while (!reader.EndOfStream)
                    {
                        pg += reader.ReadLine() + Environment.NewLine;
                    }
                }
                browser.LoadHtml(pg + "<script>" + DF_Getter.get("SteamAccCreator.File.MainUI.HTML.DocumentFiles.JS.UpdatePage.js") + "</script>" + "<style>" + DF_Getter.get("SteamAccCreator.File.MainUI.HTML.DocumentFiles.CSS.UpdatePage.css") + "</style>");

            }
            catch (Exception es) { MessageBox.Show(es.Message); }

            AutoHide.Hide();
        }
        public static void LoadHistoryPage()
        {
            string[] split = DF_Getter.get("SteamAccCreator.File.MainUI.HTML.DocumentFiles.HTML.HistoryPage.html").Split('\n');
            string html = DF_Getter.get("SteamAccCreator.File.MainUI.HTML.DocumentFiles.HTML.HistoryPage.html");
            string newHTML = "";
            foreach (string n in split)
            {
                if (n.Contains("add"))
                {
                    string add = n + HPGlobals.History;
                    string x = html.Replace(n, add);
                    newHTML = x;
                }
            }
            try
            {
                browser.LoadHtml(newHTML + "<script>" + DF_Getter.get("SteamAccCreator.File.MainUI.HTML.DocumentFiles.JS.HistoryPage.js") + "</script>" + "<style>" + DF_Getter.get("SteamAccCreator.File.MainUI.HTML.DocumentFiles.CSS.HistoryPage.css") + "</style>");
            }
            catch
            {
                browser.LoadHtml(newHTML + "<script>" + DF_Getter.get("SteamAccCreator.File.MainUI.HTML.DocumentFiles.JS.HistoryPage.js") + "</script>" + "<style>" + DF_Getter.get("SteamAccCreator.File.MainUI.HTML.DocumentFiles.CSS.HistoryPage.css") + "</style>", true);
            }
            
            AutoHide.Hide();
        }
        public static JavascriptResponse EvaluateScript(string script, TimeSpan timeout)
        {
            try
            {
                var browser = RightBrowser.browser;
                JavascriptResponse result = new JavascriptResponse();
                var task = browser.EvaluateScriptAsync(script, timeout);
                var complete = task.ContinueWith(t =>
                {
                    if (!t.IsFaulted)
                    {
                        try
                        {
                            JavascriptResponse response = t.Result;
                            result = response;
                        }
                        catch { }
                    }
                }, TaskScheduler.Default);
                complete.Wait();
                return result;
            }
            catch 
            {

            }

            return new JavascriptResponse();
        }
        public static string getSource()
        {
            string fileName = "ASDUGBASUDBAS16581KDJbuoert";
            string dtml = string.Empty;
            try
            {
                System.IO.File.Delete(specificFolder + "\\" + fileName);
            }catch { }
            
            try
            {
                RightBrowser.browser.GetSourceAsync().ContinueWith(taskHtml =>
                {
                    try
                    {
                        System.IO.File.Create(specificFolder + "\\" + fileName).Close();
                        dtml = System.IO.File.ReadAllText(specificFolder + "\\" + fileName);
                        if (!dtml.Contains("href"))
                        {
                            var html = taskHtml.Result;
                            System.IO.File.AppendAllText(specificFolder + "\\" + fileName, html);
                        }
                    }
                    catch { }
                });
            }
            catch { }
            delay(100);
            try
            {
                return System.IO.File.ReadAllText(specificFolder + "\\" + fileName);
            }
            catch (Exception ee)
            {
                return ee.Message;
            }

        }
        public static void delay(int delay)
        {
            int i = 0;
            while (i < delay)
            {
                Application.DoEvents();
                Thread.Sleep(1);
                i += 1;
            }
        }
    }
}

