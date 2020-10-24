using SteamAccCreator.File.MainUI.WebDocs.StartPage;
using SteamAccCreator.Gui;
using SteamAccCreator.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamAccCreator.File.MainUI.HTML.Generator
{
    class Generate
    {
        public static void delay(int delay)
        {
            int i = 0;
            while (i < delay)
            {
                Application.DoEvents();
                Thread.Sleep(1);
                i += 1;
            }
        }
        public static void GenerateAccount(Gui.MainUI UI, string _provider)
        {
            
            string txtEmail = "";
            string txtAlias = "";
            string txtPass = "";
            int t = 0;
            int c = 0;
            for (var i = 0; i < Globals.iAccountsToGenerate; i++)
            {
                Globals.bGenCooldown = true;
                Globals.iGenCooldown += 15000;
                if (t == Globals.iThreads)
                {
                    delay(Globals.iThreadCooldwon*1000);
                    t = 0;
                }
                t += 1;
                var Random = new Random();
                var numberR = Random.Next(300, 800);
                //MessageBox.Show(Globals.iAccountsToGenerate.ToString());
                try
                {
                    Thread.Sleep(numberR); //prevents things
                    int _index = GenerateFunctions.newIndexID();
                    //HTMLObjects.sProxy
                    if (Globals.SelectedGame == "")
                    {
                        var accCreator = new GenerateThread(UI, txtEmail, txtAlias, txtPass, _index, HTMLObjects.sProxy, _provider, -1, HTMLObjects.bGameAdd, HTMLObjects.bSteamGuard, HTMLObjects.bUseProxy);
                        //MessageBox.Show(-1 + "");
                        var thread = new Thread(accCreator.Run);
                        thread.Start();
                    }
                     else
                    {
                        int d = Int32.Parse(Regex.Split(Globals.SelectedGame, ",")[1]);
                        //MessageBox.Show(d + "");
                        var accCreator = new GenerateThread(UI, txtEmail, txtAlias, txtPass, _index, HTMLObjects.sProxy, _provider, d, HTMLObjects.bGameAdd, HTMLObjects.bSteamGuard, HTMLObjects.bUseProxy);
                        var thread = new Thread(accCreator.Run);
                        thread.Start();
                    }
                    

                }
                catch (Exception d) { MessageBox.Show(d.InnerException.Message + Environment.NewLine + d.InnerException.StackTrace); return; }
            }
        }
    }
}
