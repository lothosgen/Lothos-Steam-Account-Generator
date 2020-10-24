using SteamAccCreator.File.MainUI.AppdataFunctions;
using SteamAccCreator.File.MainUI.Browsers;
using SteamAccCreator.File.MainUI.HTML.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamAccCreator.File.MainUI.WebDocs.SettingsPage
{
    class SPGlobals
    {
        public static string EmailProvidersHTML = "";
        public static string EmailProviders = "";
        public static string ProxyHTML = "";

        public static void addDefaultEmailProviders()
        {
            EmailProviders += @"@temporary-mail.xyz | https://tempmail.linux.pizza/?  
             @freemailzone.com | https://freemailzone.com/?
             @tempmail.tw | https://www.tempmailbox.us/?
             @temp-mail.tw | https://www.tempmailbox.us/?  
             @mailbox2go.de | https://www.mailbox2go.de/? 
             @nomail.win | https://www.spam-mail.net/?
             @fuckthis.win | https://www.spam-mail.net/?  
             @kappa.pw | https://www.spam-mail.net/?  
             @upandrun.tk | https://www.jessy.tk/? 
             @routingpro.tk | https://www.jessy.tk/? 
             @loveletter.tk | https://www.jessy.tk/?  
             @fastestresult.tk | https://www.jessy.tk/?  
             @fastestpost.tk | https://www.jessy.tk/?  
             @pilotpointer.tk | https://www.jessy.tk/? 
             @woohah.ga | https://www.wreck.ml/? 
             @woohah.ml | https://www.wreck.ml/? 
             @woohah.cf | https://www.wreck.ml/?  
             @woohah.tk | https://www.wreck.ml/?  
             @noneed.ml | https://www.wreck.ml/?  
             @masafa.ga | https://www.wreck.ml/?  
             @masafag.ga | https://www.wreck.ml/?  
             @dumpthis.ml | https://www.wreck.ml/? 
             @freddymail.com | http://freddymail.com/? 
            ";
            string current = EmailProviders;
            string[] single = current.Split('\n');
            int index = 0;
            foreach (string a in single)
            {
                string provider = a.Replace(" ", string.Empty);
                EmailProvidersHTML += "<option style='background-color: grey; font-weight: bold;' value='" + index.ToString() + "'>" + provider + "</option>";
                index += 1;
            }
            //RightBrowser.LoadSettingsPage();
        }
        public static string getEmailProviderURL(string Eprovider)
        {
            string current = EmailProviders;
            string[] single = current.Split('\n');
            foreach(string l in single)
            {
                if (l.Contains(Eprovider))
                {
                    if(l == Eprovider)
                    {
                        return l;
                    }
                    else
                    {
                        string[] split = l.Split('|');
                        string empty = split[1].Replace(" ", string.Empty);
                        return empty;
                    }
                }
            }
            return "Not Found";
        }
        public static void addListProxies()
        {
            ProxyListFile.check();
            string list = System.IO.File.ReadAllText(ProxyListFile.FileLocation);
            string[] split = list.Split('\n');
            ProxyHTML += "<option style='background-color: grey; font-weight: bold;' id='N/A'><p>Select A Proxy...</p></option>\n";
            foreach (string q in split)
            {
                if(!q.Contains(" "))
                {
                    ProxyHTML += "<option style='background-color: grey; font-weight: bold;' id=" + q + "><p>" + q + "</p></option>\n";
                }
                
            }
            //ProxyHTML += "<option style='background-color: grey; font-weight: bold;' id='Add' >" + "+ Add To List" + "</option>\n";
        }
        public static void addProxyToList(string proxy)
        {
            ProxyHTML += "<option style='background-color: grey; font-weight: bold;' id='" + proxy + "'>" + proxy + "</option>";
            ProxyListFile.write(proxy);
            RightBrowser.LoadSettingsPage();
        }
        public static void ProxyChecker()
        {
            ProxyCheckerThread t = new ProxyCheckerThread();
            Thread proxycheck = new Thread(t.Run);
            proxycheck.Start();
        }
        public static void startup()
        {
            //addDefaultEmailProviders();
            //addListProxies();
            //ProxyChecker();
        }
        
        public static void editProxyColor(string proxy, string color)
        {
            try
            {
                RightBrowser.EvaluateScript("document.getElementById('" + proxy + "').style.backgroundColor = '" + color + "';", TimeSpan.FromMilliseconds(10));
            }catch(Exception k) { MessageBox.Show(k.Message); }
            
        }
        public static string getAllProxies()
        {
            string html = ProxyHTML;
            string[] split = Regex.Split(html, "\n");
            string all = "";
            foreach (string j in split)
            {
                try
                {
                    string[] neww = Regex.Split(j, "p>");
                    string fproxy = neww[1].Replace("<", string.Empty);
                    string fproxyN = fproxy.Replace("/", string.Empty);
                    string OProxy = fproxyN.Replace("\n", string.Empty);
                    all += OProxy + "\n";
                    
                    
                }
                catch { }
                

            }
            return all;
        }
    }
}
