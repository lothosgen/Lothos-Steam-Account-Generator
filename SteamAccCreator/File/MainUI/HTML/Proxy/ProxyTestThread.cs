using SteamAccCreator.File.MainUI.Browsers;
using SteamAccCreator.File.MainUI.WebDocs.SettingsPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamAccCreator.File.MainUI.HTML.Proxy
{
    class ProxyTestThread
    {
        string _ip = "";
        int _port = 0;
        string execute = "";
        public ProxyTestThread(string ip, int port)
        {
            _ip = ip;
            _port = port;
        }
        public void Run()
        {
            TestProxies(_ip, _port);
        }
        
        public static void TestProxies(string proxyIP, int proxyPort)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://store.steampowered.com/");
            try { WebProxy myproxy = new WebProxy(proxyIP, proxyPort); } catch { }

            try
            {
                WebProxy myProxy = default(WebProxy);
                myProxy = new WebProxy(proxyIP, proxyPort);
                HttpWebRequest r = request;
                r.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/29.0.1547.2 Safari/537.36";
                r.Timeout = 3000;
                r.Proxy = myProxy;
                HttpWebResponse re = (HttpWebResponse)r.GetResponse();

                string o = "document.getElementById('" + proxyIP + ":" + proxyPort + "').style.backgroundColor = '" + "lime" + "'; " + "\n";
                RightBrowser.EvaluateScript(o, TimeSpan.FromMilliseconds(1));
            }
            catch (Exception)
            {
                string o = "document.getElementById('" + proxyIP + ":" + proxyPort + "').style.backgroundColor = '" + "#fc5b53" + "'; " + "\n";
                RightBrowser.EvaluateScript(o, TimeSpan.FromMilliseconds(1));
            }
        }
    }
}
