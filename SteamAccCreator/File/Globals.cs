
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamAccCreator.File
{
    class Globals
    {

        // Booleans
        public static bool bCaptcha = false;
        public static bool bAutoFail = true;
        public static bool bRetryCaptcha = false;
        public static bool bProxyEnabled = false;
        public static bool bProxyTest = false;
        public static bool bLoadKey = false;
        public static bool bDisableSteamGuard = false;

        public static bool chkAutoVerify = false;
        public static bool chkRandomAlias = false;
        public static bool chkRandomPass = false;
        public static bool chkRandomName = false;
        public static bool chkRandomMail = false;

        public static bool bGenCooldown = false;

        // Strings
        public static string s2Captcha = "";
        public static string sCaptchaGuru = "";
        public static string sEmailService = "";
        public static string sProvider = "";
        public static string sVersionNumber = "v1.1 Free";
        public static string temp = "";

        // Integers
        public static int iMaxRetry = 1;
        public static int iMaxIp = 1;
        public static int iGenerated = 0;
        public static int iMaxThreads = 1;
        public static int iThreadDelay = 1;
        public static int iGenCooldown = 0;

        //gen
        public static int iAccountsToGenerate = 1;
        public static int iThreads = 1;
        public static int iThreadCooldwon = 1;
        public static int iAccountsPerProxy = 1;

        public static string SelectedGame = "";

        public static int iMaxAccountsToGenerate = 10;
        public static int imaxThreads = 10;
        public static int iMaxThreadCooldown = 999;
        public static int iMaxAccountsPerProxy = 10;

        //ui
        public static bool emailaddAllowed = false;
        public static bool gameaddAllowed = false;

        // List
        public static List<String> lProxies = new List<String>();

        public static List<String> e1 = new List<string>(); // https://tempmail.linux.pizza/?
        public static List<String> e2 = new List<string>(); // https://freemailzone.com/?
        public static List<String> e3 = new List<string>(); // https://www.tempmailbox.us/?
        public static List<String> e4 = new List<string>(); //  https://www.mailbox2go.de/?
        public static List<String> e5 = new List<string>(); //  https://www.spam-mail.net/?
        public static List<String> e6 = new List<string>(); // https://www.jessy.tk/?
        public static List<String> e7 = new List<string>(); //  https://www.wreck.ml/?
        public static List<String> e8 = new List<string>(); // http://freddymail.com/?

        public static string sStatus = "Idle";
        public static string sGood = "";
        public static string sBad = "";
        public static string sPending = "";
        public static string sIP = "";

        public static List<String> lUntested = new List<string>();
        public static List<String> lPending = new List<string>();
        public static List<String> lGood = new List<string>();
        public static List<String> lBad = new List<string>();

        public static Color cStatus = Color.White;

        public static bool bStart = true;
        public static bool bPause = false;

        public static string sTest = "";

        public static string returnURL(string email)
        {
            if (e1.Contains(email.ToLower()))
            {
                return "https://tempmail.linux.pizza/?";
            }
            else if (e2.Contains(email.ToLower()))
            {
                return "https://freemailzone.com/?";
            }
            else if (e3.Contains(email.ToLower()))
            {
                return "https://www.tempmailbox.us/?";
            }
            else if (e4.Contains(email.ToLower()))
            {
                return "https://www.mailbox2go.de/?";
            }
            else if (e5.Contains(email.ToLower()))
            {
                return "https://www.spam-mail.net/?";
            }
            else if (e6.Contains(email.ToLower()))
            {
                return "https://www.jessy.tk/?";
            }
            else if (e7.Contains(email.ToLower()))
            {
                return "https://www.wreck.ml/?";
            }
            else if (e8.Contains(email.ToLower()))
            {
                return "http://freddymail.com/?";
            }
            else
            {
                return "";
            }
        }

        public static void popLists()
        {
            e1.Add("@temporary-mail.xyz");
            e2.Add("@freemailzone.com");
            e3.Add("@tempmail.tw");
            e3.Add("@temp-mail.tw");
            e4.Add("@mailbox2go.de");
            e5.Add("@nomail.win");
            e5.Add("@fuckthis.win");
            e5.Add("@kappa.pw");
            e6.Add("@upandrun.tk");
            e6.Add("@routingpro.tk");
            e6.Add("@loveletter.tk");
            e6.Add("@fastestresult.tk");
            e6.Add("@fastestpost.tk");
            e6.Add("@pilotpointer.tk");
            e7.Add("@woohah.ga");
            e7.Add("@woohah.ml");
            e7.Add("@woohah.cf");
            e7.Add("@woohah.tk");
            e7.Add("@noneed.ml");
            e7.Add("@masafa.ga");
            e7.Add("@masafag.ga");
            e7.Add("@dumpthis.ml");
            e8.Add("@freddymail.com");
        }

        

        /*
        @temporary-mail.xyz: https://tempmail.linux.pizza/?fay68@temporary-mail.xyz
        @freemailzone.com:   https://freemailzone.com/?rasso71@freemailzone.com
        @tempmail.tw:        https://www.tempmailbox.us/?leadods67@tempmail.tw
        @temp-mail.tw:       https://www.tempmailbox.us/?leadods67@temp-mail.tw

        @mailbox2go.de:      https://www.mailbox2go.de/?sdfasdrasrasd@mailbox2go.de
        @nomail.win:         https://www.spam-mail.net/?vavagoor57@nomail.win
        @fuckthis.win:       https://www.spam-mail.net/?igsuel72@fuckthis.win
        @kappa.pw:           https://www.spam-mail.net/?igsuel72@kappa.pw

        @upandrun.tk:        https://www.jessy.tk/?kan66@upandrun.tk
        @parislife.tk:       https://www.jessy.tk/?kan66@parislife.tk
        @routingpro.tk:      https://www.jessy.tk/?kan66@routingpro.tk
        @loveletter.tk:      https://www.jessy.tk/?kan66@loveletter.tk
        @fastestresult.tk:   https://www.jessy.tk/?kan66@fastestresult.tk
        @fastestpost.tk:     https://www.jessy.tk/?kan66@fastestpost.tk
        @pilotpointer.tk:    https://www.jessy.tk/?kan66@pilotpointer.tk
        @woohah.ga:          https://www.wreck.ml/?ovnext59@woohah.ga
        @noneed.ml:          https://www.wreck.ml/?ovnext59@noneed.ml
        @dumpthis.ml:        https://www.wreck.ml/?ovnext59@dumpthis.ml
        @masafa.ga:          https://www.wreck.ml/?ovnext59@masafa.ga
        @masafag.ga:         https://www.wreck.ml/?ovnext59@masafag.ga
        @woohah.ml:          https://www.wreck.ml/?ovnext59@woohah.ml
        @woohah.cf           https://www.wreck.ml/?ovnext59@woohah.cf
        @woohah.ga:          https://www.wreck.ml/?ovnext59@woohah.ga
        @woohah.tk:          https://www.wreck.ml/?ovnext59@woohah.tk
        @freddymail.com:     http://freddymail.com/?nythubl53@freddymail.com
        @lolxd.wtf:          http://lolxd.wtf/#/misuse86
        */
        
    }
}
