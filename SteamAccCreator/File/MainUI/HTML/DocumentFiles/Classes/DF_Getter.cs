using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SteamAccCreator.File.MainUI.HTML.DocumentFiles.Classes
{
    class DF_Getter
    {
        public static string get(string ResourceName)
        {

            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = ResourceName;

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();
                return result;
            }
        }
        public static void write(string ResourceName, string text)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = ResourceName;

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.WriteLine(text);
                writer.Close();
            }
        }
    }
}
