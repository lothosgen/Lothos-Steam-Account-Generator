using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using SteamAccCreator.File.MainUI.Classes;
using SteamAccCreator.File.MainUI.HTML.DocumentFiles.Classes;
using SteamAccCreator.Web;

namespace SteamAccCreator.File.MainUI.Browsers
{
    class MainBrowser
    {
        public static string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string specificFolder = Path.Combine(folder, "LothosGen");

         public static ChromiumWebBrowser browser;

        public static void StartBrowser(Panel panel)
        {
            CefSharp.Cef.Initialize(new CefSettings());
            browser = new ChromiumWebBrowser("about:blank");
            browser.MenuHandler = new CustomMenuHandler();
            
            panel.Controls.Add(browser);
            browser.Dock = DockStyle.Left;
            browser.Width = 519;

            browser.FrameLoadEnd += WebBrowserFrameLoadEnded;
            
           

        }
        public static void LoadStartPage()
        {
            
            browser.Load("about:blank");
            browser.LoadHtml(DF_Getter.get("SteamAccCreator.File.MainUI.HTML.DocumentFiles.HTML.StartPage.html") + "<script>" + DF_Getter.get("SteamAccCreator.File.MainUI.HTML.DocumentFiles.JS.StartPage.js") + "</script>" + "<style>" + DF_Getter.get("SteamAccCreator.File.MainUI.HTML.DocumentFiles.CSS.StartPage.css") + "</style>");
            AutoHide.Hide();
        }
        private static void WebBrowserFrameLoadEnded(object sender, FrameLoadEndEventArgs e)
        {
            if (e.Frame.IsMain)
            {
                e
                    .Browser
                    .MainFrame
                    .ExecuteJavaScriptAsync(
                    "document.body.style.overflow = 'hidden'");
            }

            browser.SetZoomLevel((Convert.ToDouble(browser.Tag) - 50) / 100000.0);
        }
        public static string getSource()
        {
            string fileName = "y3475g345ghbhasd8y943875.jkfbgkjas";
            string dtml = string.Empty;
            try
            {
                System.IO.File.Delete(specificFolder + "\\" + fileName);
            }catch { }
            
            try
            {
                MainBrowser.browser.GetSourceAsync().ContinueWith(taskHtml =>
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
                    }catch { }
                });
            }catch {  }
            delay(100);
            try
            {
                return System.IO.File.ReadAllText(specificFolder + "\\" + fileName);
            }catch(Exception ee)
            {
                return ee.Message;
            }
            
        }
        public static string GetElementsById(string source, string id, string value, string type)
        {
            List<String> s = Regex.Split(source, Environment.NewLine).ToList();
            foreach(string a in s)
            {
                if (a.Contains(value + @"=""" + id + @"""")) // value="id"
                {
                    switch (type.ToLower())
                    {
                        case "id":
                            if (a.Contains(@"id="""))
                            {
                                string v = Regex.Split(Regex.Split(a, @"id=""")[1], @"""")[0];
                                return v;

                            } else
                            {
                                return string.Empty;
                            }
                        case "name":
                            if (a.Contains(@"name="""))
                            {
                                string v = Regex.Split(Regex.Split(a, @"name=""")[1], @"""")[0];
                                return v;

                            }
                            else
                            {
                                return string.Empty;
                            }
                    }
                } 
            }
            return string.Empty;
        }
        public static JavascriptResponse EvaluateScript(string script, TimeSpan timeout)
        {
            var browser = MainBrowser.browser;
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
                    }catch { }
                }
            }, TaskScheduler.Default);
            complete.Wait();

            return result;
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
    public class CustomMenuHandler : CefSharp.IContextMenuHandler
    {
        public void OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
        {
            model.Clear();
        }

        public bool OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
        {

            return false;
        }

        public void OnContextMenuDismissed(IWebBrowser browserControl, IBrowser browser, IFrame frame)
        {

        }

        public bool RunContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
        {
            return false;
        }
    }

}
