using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamAccCreator.File.MainUI.Classes.Proxy
{
    class clsProxy
    {
        int _threads, _wait, _timeout = 0;
        public clsProxy(int threads, int wait, int timeout)
        {
            _threads = threads;
            _wait = wait;
            _timeout = timeout;
        }
        public void Run()
        {
            string getRawProxies = System.IO.File.ReadAllText(@"untested.txt");
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
                var s = Regex.Split(n, "\r\n?|\n")[0];
                string address = s.Split(':')[0];
                string pport = "";
                try { pport = s.Split(':')[1]; } catch { }
                if (threads > _threads)
                {
                    delay(_wait);
                    threads = 0;
                }
                try
                {
                    Globals.lUntested.RemoveAt(0);
                    Globals.lPending.Add(address + ":" + pport);
                    Globals.sPending = Globals.lPending.Count + "";
                    clsCheckProxy ptt = new clsCheckProxy(address, Int32.Parse(pport), _timeout);
                    Thread t = new Thread(ptt.Run);
                    t.Start();
                    Globals.sStatus = "Testing (" + address + ":" + pport + ")...";
                    Globals.cStatus = System.Drawing.Color.Orange;
                }
                catch
                {
                }

                threads += 1;
            }
            Globals.sStatus = "Testing Complete!";
            Globals.bStart = true;
            Globals.bPause = false;
            Globals.cStatus = System.Drawing.Color.Lime;
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
    }
}
