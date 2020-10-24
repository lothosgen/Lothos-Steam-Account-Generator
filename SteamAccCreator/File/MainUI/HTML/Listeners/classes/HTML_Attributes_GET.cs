using SteamAccCreator.File.MainUI.Browsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamAccCreator.File.MainUI.HTML.Listeners.classes
{
    class HTML_Attributes_GET
    {
        public static string get(string ID, string Method)
        {
            int c = 0;
            if (Method == "name")
            {
                string _source = "";
                _source = MainBrowser.getSource();

                List<String> lines = Regex.Split(_source, "\n").ToList();

                foreach (string l in lines)
                {
                    string h = l.ToLower();
                    if (l.Contains(ID))
                    {
                        string name = Regex.Split(Regex.Split(h, "name=\"")[1], "\"")[0];

                        return name;
                    }
                }
            }
            return "Not Found";
        }

        public static string get_settings(string ID, string Method)
        {
            if (Method == "name")
            {
                string _source = "";
                _source = RightBrowser.getSource();

                List<String> lines = Regex.Split(_source, "\n").ToList();

                foreach (string l in lines)
                {
                    string h = l.ToLower();
                    if (l.Contains(ID))
                    {
                        string name = Regex.Split(Regex.Split(h, "name=\"")[1], "\"")[0];

                        return name;
                    }
                }
            }
            if (Method == "value")
            {
                string _source = "";
                _source = RightBrowser.getSource();

                List<String> lines = Regex.Split(_source, "\n").ToList();

                foreach (string l in lines)
                {
                    string h = l.ToLower();
                    if (l.Contains(ID))
                    {
                        string name = Regex.Split(Regex.Split(h, "value=\"")[1], "\"")[0];

                        return name;
                    }
                }
            }
            return "Not Found";
        }
    }
}
