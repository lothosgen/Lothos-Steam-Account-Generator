using SteamAccCreator.File.MainUI.Browsers;
using SteamAccCreator.File.MainUI.WebDocs.SettingsPage;
using SteamAccCreator.File.MainUI.WebDocs.StartPage;
using SteamAccCreator.Gui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamAccCreator.File.MainUI.HTML.Listeners.classes
{
    class cbs
    {
        static string cb = "";
        static string value = "";
        public cbs(string cb1, string value1)
        {
            cb = cb1;
            value = value1;
        }

        public static void Initalize()
        {
            
            switch (cb)
            {

                case "cb_emaila":
                    if(value == "none")
                    {

                    }
                    else
                    {
                        string[] split = value.Split('|');
                        HTMLObjects.EmailProvider = split[0];
                        try { HTMLObjects.EmailProviderURL = split[1]; }catch { }
                        
                    }
                    break;
                case "cb_proxy":
                    if (value == "none")
                    {

                    }
                    else
                    {
                        if(value.Contains("+"))
                        {
                            new AddProxies().ShowDialog();
                            RightBrowser.EvaluateScript("document.getElementById('cb_proxy').setAttribute('value', '');", TimeSpan.FromMilliseconds(1));
                        }
                        else
                        {
                            try { HTMLObjects.sProxy = value; } catch { }
                        }
                        

                    }

                    break;

            }
        }
    }
}
