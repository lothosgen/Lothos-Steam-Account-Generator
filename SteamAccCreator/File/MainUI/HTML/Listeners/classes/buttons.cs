using SteamAccCreator.File.MainUI.Browsers;
using SteamAccCreator.File.MainUI.Classes.Proxy;
using SteamAccCreator.File.MainUI.WebDocs.GridPage;
using SteamAccCreator.File.MainUI.WebDocs.HistoryPage;
using SteamAccCreator.File.MainUI.WebDocs.StartPage;
using SteamAccCreator.Gui;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamAccCreator.File.MainUI.HTML.Listeners.classes
{
    class buttons
    {
        static string button = "";
        public buttons(string btn)
        {
            button = btn;
        }
        public static void Initalize()
        {
           switch (button)
            {
                case "btn_generate":
                    Generate();
                    break;
                case "btn_option":
                    optionSettings();
                    break;
                case "btn_settings":
                    Settings();
                    break;
                case "btn_dashboard":
                    Dashboard();
                    break;
                case "btn_history":
                    History();
                    break;
                case "btn_updates":
                    Updates();
                    break;
                case "btn_add":
                    Add();
                    break;
                case "btn_proxy":
                    Proxy();
                    break;
            }
        }
        public static void optionSettings()
        {
            //RightBrowser.EvaluateScript("prompt('aaa', 'sass');", TimeSpan.FromMilliseconds(1));
            new OptionSettings().ShowDialog();

        }
        static readonly Gui.MainUI _mainForm;
        public static void Generate()
        {
            if(HTMLObjects.EmailProvider == "")
            {
                MessageBox.Show("'Please Select A Email Provider" + Environment.NewLine + "Settings -> Email Provider");
                
            }
            else
            {
                SteamAccCreator.File.MainUI.HTML.Generator.Generate.GenerateAccount(_mainForm, HTMLObjects.EmailProvider);
            }
            
        }
        public static void Updates()
        {
            RightBrowser.browser.Invoke(new MethodInvoker(delegate { RightBrowser.browser.Visible = true; }));
            RightBrowser.LoadUpdatesPage();
        }
        public static void Settings()
        {
            RightBrowser.browser.Invoke(new MethodInvoker(delegate { RightBrowser.browser.Visible = true; }));
            RightBrowser.LoadSettingsPage();

        }
        public static void Proxy()
        {
            RightBrowser.browser.Invoke(new MethodInvoker(delegate { RightBrowser.browser.Visible = false; }));
            Panel t = Application.OpenForms["MainUI"].Controls["RightBrowserWindow"] as Panel;
            Form j = new Form();
            t.Invoke(new MethodInvoker(delegate { t.Controls.Add(new ProxyControl()); }));
            if (!System.IO.File.Exists(@"untested.txt"))
            {
                System.IO.File.Create(@"untested.txt").Close();
            }
            if (!System.IO.Directory.Exists(@"proxies"))
            {
                System.IO.Directory.CreateDirectory(@"proxies");
            }
            if (!System.IO.File.Exists(@"proxies\Working.txt"))
            {
                System.IO.File.Create(@"proxies\Working.txt").Close();
            }
            if (!System.IO.File.Exists(@"proxies\Bad.txt"))
            {
                System.IO.File.Create(@"proxies\Bad.txt").Close();
            }
            if (System.IO.File.ReadAllText(@"untested.txt") == string.Empty)
            {
                MessageBox.Show("There are no proxies located in the 'untested.txt' file");
                //Process.GetCurrentProcess().Kill();
            }
            foreach (String p in System.IO.File.ReadAllLines(@"untested.txt"))
            {
                try
                {
                    Globals.lUntested.Add(p);
                }
                catch
                {

                }

            }
            clsGetIp clsGI = new clsGetIp();
            Thread ts = new Thread(clsGI.Run);
            ts.Start();




        }
        public static void Dashboard()
        {
            RightBrowser.browser.Invoke(new MethodInvoker(delegate { RightBrowser.browser.Visible = true; }));
            RightBrowser.LoadGridPage();
        }
        public static void History()
        {
            RightBrowser.browser.Invoke(new MethodInvoker(delegate { RightBrowser.browser.Visible = true; }));
            RightBrowser.LoadHistoryPage();
        }
        public static void Add()
        {
            new AddProxies().ShowDialog();
        }

    }
}
