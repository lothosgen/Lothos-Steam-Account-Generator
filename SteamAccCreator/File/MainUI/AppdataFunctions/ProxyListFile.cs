using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAccCreator.File.MainUI.AppdataFunctions
{
    class ProxyListFile
    {
        public static string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string specificFolder = Path.Combine(folder, "LothosGen");

        public static string FileCode = "GuasdbasSDASDASDhbu43b597345bASDASDVjhv932423";
        public static string FileCodeExtension = ".ASDIOAUSBDIASBd97g874g5ASHDV";
        public static string FileLocation = (specificFolder + "\\" + FileCode + FileCodeExtension);

        public static void check()
        {
            if(!System.IO.File.Exists(FileLocation)) { System.IO.File.Create(FileLocation).Close(); }
        }
        public static void write(string text)
        {
            using (var writer = new StreamWriter(FileLocation, true))
            {
                writer.WriteLine(text);
                writer.Close();
            }
            
        }
    }
}
