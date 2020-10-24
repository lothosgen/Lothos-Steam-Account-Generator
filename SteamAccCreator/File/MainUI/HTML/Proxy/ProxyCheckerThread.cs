using RestSharp;
using SteamAccCreator.File.MainUI.Browsers;
using SteamAccCreator.File.MainUI.WebDocs.SettingsPage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamAccCreator.File.MainUI.HTML.Proxy
{
    class ProxyCheckerThread
    {
        public ProxyCheckerThread()
        {

        }
        /*
        public void Run()
        {
            while (true)
            {
                string getRawProxies = SPGlobals.getAllProxies();
                string[] proxies = getRawProxies.Split('\n');
                List<string> pList = new List<string>();
                string prList = "";
                foreach (string l in proxies)
                {
                    string neww = l.Replace(" ", string.Empty).Replace("\n", string.Empty);
                    pList.Add(neww);
                    prList += neww + Environment.NewLine;
                }
                string execute = "";
                foreach (string n in pList)
                {
                    var s = Regex.Split(n, "\r\n?|\n")[0];
                    string address = s.Split(':')[0];
                    string pport = "";
                    try { pport = s.Split(':')[1]; } catch { }
                    try
                    {

                        if (PingHost(address, Convert.ToInt16(pport)) == true)
                        {
                            execute += "document.getElementById('" + s + "').style.backgroundColor = '" + "lime" + "'; " + "\n";
                        }
                        else
                        {
                            execute += "document.getElementById('" + s + "').style.backgroundColor = '" + "#fc5b53" + "'; " + "\n";
                        }
                    }
                    catch { }
                    string[] split = execute.Split('\n');
                    foreach (string o in split)
                    {

                        try
                        {
                            RightBrowser.EvaluateScript(o, TimeSpan.FromMilliseconds(1));
                        }
                        catch (Exception k) { MessageBox.Show(k.Message); }

                    }

                }
                Thread.Sleep(5000);
            }
        }
        */
        /*public void Run()
        {
            while (true)
            {
                string getRawProxies = SPGlobals.getAllProxies();
                string[] proxies = getRawProxies.Split('\n');
                List<string> pList = new List<string>();
                string prList = "";
                foreach (string l in proxies)
                {
                    string neww = l.Replace(" ", string.Empty).Replace("\n", string.Empty);
                    pList.Add(neww);
                    prList += neww + Environment.NewLine;
                }
                foreach (string n in pList)
                {
                    var s = Regex.Split(n, "\r\n?|\n")[0];
                    string address = s.Split(':')[0];
                    string pport = "";
                    try { pport = s.Split(':')[1]; } catch { }
                    try
                    {

                        TestProxies(address, Int16.Parse(pport));
                    }
                    catch { }

                }
                delay(5000);
            }
        }*/

        public void Run()
        {
            while (true)
            {
                string getRawProxies = SPGlobals.getAllProxies();
                string[] proxies = getRawProxies.Split('\n');
                List<string> pList = new List<string>();
                string prList = "";
                foreach (string l in proxies)
                {
                    string neww = l.Replace(" ", string.Empty).Replace("\n", string.Empty);
                    pList.Add(neww);
                    prList += neww + Environment.NewLine;
                }
                int threads = 0;
                foreach (string n in pList)
                {
                    if (n == "Select A Proxy...")
                    {
                        continue;
                    }
                    var s = Regex.Split(n, "\r\n?|\n")[0];
                    string address = s.Split(':')[0];
                    string pport = "";
                    try { pport = s.Split(':')[1]; } catch { }
                    if (threads > Globals.iMaxThreads)
                    {
                        delay(Globals.iThreadDelay);
                        threads = 0;
                    }
                    try
                    {
                        ProxyTestThread ptt = new ProxyTestThread(address, Int32.Parse(pport));
                        Thread t = new Thread(ptt.Run);
                        t.Start();
                    } catch
                    {
                    }
                    
                    threads += 1;
                }
                delay(5000);
            }
        }

        public void delay(int delay)
        {
            int i = 0;
            while (i < delay)
            {
                Application.DoEvents();
                Thread.Sleep(1);
                i += 1;
            }
        }
        public static bool PingHost(string strIP, int intPort)
        {
            bool blProxy = false;
            try
            {
                TcpClient client = new TcpClient(strIP, intPort);

                blProxy = true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error pinging host:'" + strIP + ":" + intPort.ToString() + "'");
                return false;
            }
            return blProxy;
        }

        public static void TestProxies(string proxyIP, int proxyPort)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://google.com/");
            WebProxy myproxy = new WebProxy(proxyIP, proxyPort);

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

        public static void TestProxies_old(string proxy, int port)
        {
            var lowp = new List<WebProxy> { new WebProxy(proxy, port) };

            Parallel.ForEach(lowp, wp => {
                var success = false;
                var errorMsg = "";
                var sw = new Stopwatch();
                try
                {
                    sw.Start();
                    var response = new RestClient
                    {
                        BaseUrl = new Uri("https://google.com/"),
                        Proxy = wp
                    }.Execute(new RestRequest
                    {
                        Resource = "api/ip",
                        Method = Method.GET,
                        Timeout = 3,
                        RequestFormat = DataFormat.Json
                    });
                    if (response.ErrorException != null)
                    {
                        throw response.ErrorException;
                    }
                    success = (response.Content == wp.Address.Host);
                }
                catch (Exception ex)
                {
                    errorMsg = ex.Message;
                }
                finally
                {
                    sw.Stop();
                    MessageBox.Show("Success:" + success.ToString() + "|Connection Time:" + sw.Elapsed.TotalSeconds + "|ErrorMsg" + errorMsg);
                }
            });
        }
    }
}
