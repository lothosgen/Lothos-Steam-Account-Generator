using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamAccCreator.File.MainUI.Browsers
{
    class VersionBrowser
    {
        public static ChromiumWebBrowser browser;

        public static void StartBrowser(Panel panel)
        {
            browser = new ChromiumWebBrowser("about:blank");
            browser.MenuHandler = new CustomMenuHandler();

            panel.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;
            browser.Load("https://i.imgur.com/PTxB3pS.gif");
            browser.FrameLoadEnd += OnBrowserFrameLoadEnd;
            browser.LoadHtml("<style> body { background-color: #202020; } </style><img style='width: 60%; height: 65%; -webkit-user-select: none;' src='https://i.imgur.com/PTxB3pS.gif'>");

        }
        private static void OnBrowserFrameLoadEnd(object sender, FrameLoadEndEventArgs args)
        {
            if (args.Frame.IsMain)
            {
                EvaluateScript("document.body.style.overflow = 'hidden'", TimeSpan.FromMilliseconds(1));
                args
                    .Browser
                    .MainFrame
                    .ExecuteJavaScriptAsync(
                    "document.body.style.overflow = 'hidden'");
            }
        }
        public static JavascriptResponse EvaluateScript(string script, TimeSpan timeout)
        {
            try
            {
                var browser = VersionBrowser.browser;
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
            catch (Exception e)
            {

            }

            return new JavascriptResponse();
        }
    }
}
