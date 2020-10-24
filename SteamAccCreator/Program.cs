using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteamAccCreator.File;
using SteamAccCreator.Gui;

namespace SteamAccCreator
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThreadAttribute]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                try
                {
                    Application.Run(new MainUI());
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }

                //MainForm = Globals.MainUIForm;

                }
            catch 
            {
                
            }
        }
    }
}
