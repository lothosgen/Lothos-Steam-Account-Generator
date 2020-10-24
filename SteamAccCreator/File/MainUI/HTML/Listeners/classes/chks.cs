using SteamAccCreator.File.MainUI.Browsers;
using SteamAccCreator.File.MainUI.WebDocs.StartPage;
using SteamAccCreator.Gui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamAccCreator.File.MainUI.HTML.Listeners.classes
{
    class chks
    {
        static string chk = "";
        static string value = "";
        public chks(string chk1, string value1)
        {
            chk = chk1;
            value = value1;
        }

        public static void Initalize()
        {
            bool chked = bool.Parse(value);
            switch (chk)
            {
                
                case "chk_steamguard":
                    HTMLObjects.bSteamGuard = chked;
                    break;
                case "chk_proxy":
                    HTMLObjects.bUseProxy = chked;
                    break;
                case "chk_twocaptcha":
                    HTMLObjects.b2Captcha = chked;
                    break;
                case "chk_captchasolutions":
                    HTMLObjects.bCaptchaSolutions = chked;
                    //new TextInsertDialog("solutions").ShowDialog();
                    break;
                case "chk_gameadd":
                    HTMLObjects.bGameAdd = chked;
                    break;
            }
        }
        public static void TwoCaptcha()
        {
            if (HTMLObjects.b2Captcha == true && HTMLObjects.s2Captcha == string.Empty)
            {
                new TextInsertDialog("two").ShowDialog();
            }
        }
    }
}
