using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SteamAccCreator.File.MainUI.Classes.Proxy
{
    class clsCheckProxy
    {
        string _ip = "";
        static int _port, _timeout = 0;
        string execute = "";
        public clsCheckProxy(string ip, int port, int timeout)
        {
            _ip = ip;
            _port = port;
            _timeout = timeout;
        }
        public void Run()
        {
            TestProxies(_ip, _port);
        }
        public static bool checkAnonyLevel(string proxyIP, int proxyPort)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://whatismyip.host/");
            WebProxy myproxy = new WebProxy(proxyIP, proxyPort);

            try
            {
                WebProxy myProxy = default(WebProxy);
                myProxy = new WebProxy(proxyIP, proxyPort);
                HttpWebRequest r = request;
                r.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/29.0.1547.2 Safari/537.36";
                r.Timeout = _timeout;
                r.Proxy = myProxy;
                HttpWebResponse re = (HttpWebResponse)r.GetResponse();
                //System.IO.File.AppendAllText(@"text.txt", proxyIP + ":" + proxyPort + Environment.NewLine);
                Stream s = re.GetResponseStream();
                string pg = "";
                using (var reader = new StreamReader(s))
                {

                    while (!reader.EndOfStream)
                    {

                        //We are ready to read the stream
                        pg += reader.ReadLine() + Environment.NewLine;
                    }
                }
                if (pg.Contains("<title>What is My IP | View IPv4 and IPv6 Address</title>"))
                {

                    foreach (string l in Regex.Split(pg, Environment.NewLine))
                    {
                        if (l.Contains("p class=\"ipaddress\">"))
                        {
                            var ip = Regex.Split(Regex.Split(l, "<p class=\"ipaddress\">")[1], "</p>")[0];

                            if (ip != Globals.sIP)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            return false;
        }
        public static void TestProxies(string proxyIP, int proxyPort)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://store.steampowered.com/");
            WebProxy myproxy = new WebProxy(proxyIP, proxyPort);

            try
            {
                WebProxy myProxy = default(WebProxy);
                myProxy = new WebProxy(proxyIP, proxyPort);
                HttpWebRequest r = request;
                r.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/29.0.1547.2 Safari/537.36";
                r.Timeout = _timeout;
                r.Proxy = myProxy;
                HttpWebResponse re = (HttpWebResponse)r.GetResponse();
                Stream s = re.GetResponseStream();
                string pg = "";
                using (var reader = new StreamReader(s))
                {

                    while (!reader.EndOfStream)
                    {

                        //We are ready to read the stream
                        pg += reader.ReadLine() + Environment.NewLine;
                    }
                }
                if (pg.Contains("<title>Welcome to Steam</title>"))
                {

                    if (checkAnonyLevel(proxyIP, proxyPort))
                    {
                        Globals.sGood += proxyIP + ":" + proxyPort + Environment.NewLine;
                        Globals.sStatus = proxyIP + ":" + proxyPort + " (Working)";
                        Globals.cStatus = System.Drawing.Color.Lime;
                        Globals.lGood.Add(proxyIP + ":" + proxyPort);
                    }
                }
            }
            catch (Exception)
            {
                try
                {
                    Globals.sBad += proxyIP + ":" + proxyPort + Environment.NewLine;
                    Globals.sStatus = proxyIP + ":" + proxyPort + " (Bad)";
                    Globals.cStatus = System.Drawing.Color.Red;
                    Globals.lBad.Add(proxyIP + ":" + proxyPort);
                }
                catch 
                {

                }

            }
            try
            {
                Globals.lPending.RemoveAt(0);
            }
            catch (Exception d)
            {

            }
        }
    }
}
