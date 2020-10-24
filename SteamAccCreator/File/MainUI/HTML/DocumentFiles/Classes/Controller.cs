using CefSharp;
using CefSharp.WinForms;
using SteamAccCreator.File.MainUI.Browsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamAccCreator.File.MainUI.HTML.DocumentFiles.Classes
{
    class Controller
    {
        
        public static void Visibility(ChromiumWebBrowser browser, string Browser, string Page, string Start, int End, bool Visible)
        {
            if(Browser == "Right")
            {
                string html = DF_Getter.get("SteamAccCreator.File.MainUI.HTML.DocumentFiles.HTML." + Page + "Page.html");

                string[] lines = html.Split('\n');

                string FoundLine = "";

                List<string> AdditionalLines = new List<string>();
                string UploadHtml = "";

                int currentLine = 0;

                bool Found = false;

                string FinalHtml = "";

                foreach(string line in lines)
                {
                    if(Found == true)
                    {
                        if(currentLine != End)
                        {
                            AdditionalLines.Add(line);
                            currentLine += 1;
                        }
                        
                    }
                    else
                    {
                        if (line.Contains(Start))
                        {
                            FoundLine = line;
                            Found = true;
                        }
                    }
                }
                if(Visible == false)
                {
                    string newHtml = html.Replace(FoundLine, "<!--1" + FoundLine);
                    UploadHtml = newHtml;
                }
                foreach(string k in AdditionalLines)
                {
                    if(k == "\n" || k == string.Empty || k == " ")
                    {

                    }
                    else
                    {
                        FinalHtml = UploadHtml.Replace(k, "<!--2 -->");
                    }
                    
                }
                string[] split = FinalHtml.Split('\n');
                int nline = 0;
                foreach(string line in split)
                {
                    if (line.Contains("<!--1"))
                    {

                    }
                    nline += 1;
                }
                browser.LoadHtml(FinalHtml + "<script>" + DF_Getter.get("SteamAccCreator.File.MainUI.HTML.DocumentFiles.JS." + Page + "Page.js") + "</script>" + "<style>" + DF_Getter.get("SteamAccCreator.File.MainUI.HTML.DocumentFiles.CSS." + Page + "Page.css") + "</style>");
            }
        }
    }
}
