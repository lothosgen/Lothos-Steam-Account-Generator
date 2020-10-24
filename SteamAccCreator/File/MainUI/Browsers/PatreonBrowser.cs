using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamAccCreator.File.MainUI.Browsers
{
    class PatreonBrowser
    {
        public static ChromiumWebBrowser browser;

        public static void StartBrowser(Panel panel)
        {
            browser = new ChromiumWebBrowser("https://www.patreon.com/login");
            browser.MenuHandler = new CustomMenuHandler();

            panel.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;




        }
        public static string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string specificFolder = Path.Combine(folder, "LothosGen");
        public static string getSource()
        {
            string fileName = "123123asdSDUGB23423434123buoert";
            string dtml = string.Empty;
            try
            {
                System.IO.File.Delete(specificFolder + "\\" + fileName);
            }
            catch { }
            if(!System.IO.File.Exists(specificFolder + "\\" + fileName)) { System.IO.File.Create(specificFolder + "\\" + fileName).Close(); }
            try
            {
                browser.GetSourceAsync().ContinueWith(taskHtml =>
                {
                    try
                    {
                        dtml = System.IO.File.ReadAllText(specificFolder + "\\" + fileName);
                        if (!dtml.Contains("href"))
                        {
                            var html = taskHtml.Result;
                            System.IO.File.AppendAllText(specificFolder + "\\" + fileName, html);
                        }
                    }
                    catch { MessageBox.Show("D"); }
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
        public static string getSourceVR()
        {
            string dtml = string.Empty;
            try
            {
                browser.GetSourceAsync().ContinueWith(taskHtml =>
                {
                    dtml = taskHtml.Result;
                });
                return dtml;
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
        public static JavascriptResponse EvaluateScript(string script, TimeSpan timeout)
        {
            try
            {
              
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
