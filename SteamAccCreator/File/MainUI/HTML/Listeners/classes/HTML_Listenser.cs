using SteamAccCreator.File.MainUI.Browsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamAccCreator.File.MainUI.HTML.Listeners.classes
{
    class HTML_Listenser
    {
        public static string _source = String.Empty;
        public static string _sourceRight = String.Empty;


        public static bool clicked(string state)
        {
            if(state == "true")
            {
                return true;
            }else { return false; }
        }
        public HTML_Listenser()
        {
            
        }
        public void Run()
        {
            
            while (true)
            {
                _source = MainBrowser.getSource();
                _sourceRight = RightBrowser.getSource();

                List<String> lines = Regex.Split(_source, "<button ").ToList();
                List<String> linesCB = Regex.Split(_sourceRight, "<select ").ToList();
                List<String> linesBtn = Regex.Split(_sourceRight, "<button ").ToList();
                foreach (string l in lines)
                {

                    string h = l.ToLower();
                    if (h.Contains("id=\""))
                    {
                        string btn = Regex.Split(Regex.Split(h, "id=\"")[1], "\"")[0];
                        if (h.Contains("name=\"") && btn.Contains("btn_"))
                        {
                            string name = Regex.Split(Regex.Split(h, "name=\"")[1], "\"")[0];
                            if (clicked(name))
                            {
                                MainBrowser.EvaluateScript("document.getElementById('" + btn + "').setAttribute('name', 'false')", TimeSpan.FromMilliseconds(1));
                                buttons btnT = new buttons(btn);
                                Thread exe = new Thread(buttons.Initalize);
                                exe.Start();
                            }
                        }

                        string chk = Regex.Split(Regex.Split(h, "id=\"")[1], "\"")[0];
                        if (h.Contains("name=\"") && chk.Contains("chk_"))
                        {
                            string name = Regex.Split(Regex.Split(h, "name=\"")[1], "\"")[0];

                            chks chkT = new chks(chk, name);
                            Thread exe = new Thread(chks.Initalize);
                            exe.Start();

                        }
                    }
                }
                foreach(string a in linesCB)
                {
                    string h = a.ToLower();
                    if (h.Contains("id=\""))
                    {
                        string cb = Regex.Split(Regex.Split(h, "id=\"")[1], "\"")[0];
                        if (h.Contains("value=\"") && cb.Contains("cb_"))
                        {
                            string value = Regex.Split(Regex.Split(h, "value=\"")[1], "\"")[0];

                            cbs cbT = new cbs(cb, value);
                            Thread exe = new Thread(cbs.Initalize);
                            exe.Start();

                        }
                        string btn = Regex.Split(Regex.Split(h, "id=\"")[1], "\"")[0];
                        if (h.Contains("value=\"") && btn.Contains("btn_"))
                        {
                            string value = Regex.Split(Regex.Split(h, "value=\"")[1], "\"")[0];

                            buttons btnT = new buttons(btn);
                            Thread exe = new Thread(buttons.Initalize);
                            exe.Start();

                        }
                    }
                }
                foreach (string a in linesBtn)
                {
                    string h = a.ToLower();
                    if (h.Contains("id=\""))
                    {
                        string btn = Regex.Split(Regex.Split(h, "id=\"")[1], "\"")[0];
                        if (h.Contains("name=\"") && btn.Contains("btn_"))
                        {
                            string name = Regex.Split(Regex.Split(h, "name=\"")[1], "\"")[0];
                            if (clicked(name))
                            {
                                RightBrowser.EvaluateScript("document.getElementById('" + btn + "').setAttribute('name', 'false')", TimeSpan.FromMilliseconds(1));
                                buttons btnT = new buttons(btn);
                                Thread exe = new Thread(buttons.Initalize);
                                exe.Start();
                            }
                        }
                    }
                }
                Thread.Sleep(5);
            }
        }
    }
}
