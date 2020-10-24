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
    class clsGetIp
    {
        public clsGetIp()
        {

        }
        public void Run()
        {
            GetIP();
        }
        public static void GetIP()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://whatismyip.host/");

            try
            {
                HttpWebRequest r = request;
                r.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/29.0.1547.2 Safari/537.36";
                r.Timeout = 10000;
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
                if (pg.Contains("<title>What is My IP | View IPv4 and IPv6 Address</title>"))
                {
                    foreach (string l in Regex.Split(pg, Environment.NewLine))
                    {
                        if (l.Contains("p class=\"ipaddress\">"))
                        {

                            Globals.sIP = Regex.Split(Regex.Split(l, "<p class=\"ipaddress\">")[1], "</p>")[0];
                            return;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
