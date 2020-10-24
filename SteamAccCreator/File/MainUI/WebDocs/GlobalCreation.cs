using SteamAccCreator.File.MainUI.Browsers;
using SteamAccCreator.File.MainUI.WebDocs.GridPage;
using SteamAccCreator.File.MainUI.WebDocs.StartPage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamAccCreator.File.MainUI.WebDocs
{
    class GlobalCreation
    {
        public static void LoadAllFIles()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string specificFolder = Path.Combine(folder, "LothosGen");

            if (!Directory.Exists(specificFolder)) //Checks OR Makes Directory Folder
            {
                try
                {
                    Directory.CreateDirectory(specificFolder);

                }
                catch(Exception e) { MessageBox.Show(e.Message); }
            }
            MessageBox.Show("a");
            MainBrowser.LoadStartPage();
            RightBrowser.LoadUpdatesPage();
            
        }
    }
}
