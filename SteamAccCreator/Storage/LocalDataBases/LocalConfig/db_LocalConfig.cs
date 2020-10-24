using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SteamAccCreator.Storage.LocalDataBases.LocalSettings
{
    public static class db_LocalConfig
    {
        public static void Startup()
        {
            if (!System.IO.Directory.Exists(@"Storage")) { System.IO.Directory.CreateDirectory(@"Storage"); }
            if (!System.IO.Directory.Exists(@"Storage\db_LocalConfig")) { System.IO.Directory.CreateDirectory(@"Storage\db_LocalConfig"); }
            if (!System.IO.File.Exists(@"Storage\db_LocalConfig\Config.conf")) { System.IO.File.Create(@"Storage\db_LocalConfig\Config.conf"); }

            if(Read("genTotal") == "None")
            {
                Write("genTotal", "0");
            }
            
        }

        public static void Write(string Identifier, string value)
        {
            List<string> RecentData = new List<string>();

            if (!System.IO.Directory.Exists(@"Storage")) { System.IO.Directory.CreateDirectory(@"Storage"); }
            if (!System.IO.Directory.Exists(@"Storage\db_LocalConfig")) { System.IO.Directory.CreateDirectory(@"Storage\db_LocalConfig"); }
            if (!System.IO.File.Exists(@"Storage\db_LocalConfig\Config.conf")) { System.IO.File.Create(@"Storage\db_LocalConfig\Config.conf"); }

            foreach (string line in System.IO.File.ReadLines(@"Storage\\db_LocalConfig\\Config.conf"))
            {
                string[] array = line.Split(':');
                if(array[0] == Identifier)
                {
                } else { RecentData.Add(line); }
            }
            System.IO.File.Delete(@"Storage\db_LocalConfig\Config.conf");
            System.IO.File.Create(@"Storage\db_LocalConfig\Config.conf").Close(); ;

            RecentData.Add(Identifier + ":" + value);

            string all = string.Join(Environment.NewLine, RecentData.ToArray());

            using (StreamWriter file = System.IO.File.AppendText(@"Storage\db_LocalConfig\Config.conf"))
            {
                file.WriteLine(all);
                file.Close();
            }
        }
        public static string Read(string Identifier)
        {
            Dictionary<string, string> CurrentData = new Dictionary<string, string>();

            if (!System.IO.Directory.Exists(@"Storage")) { System.IO.Directory.CreateDirectory(@"Storage"); }
            if (!System.IO.Directory.Exists(@"Storage\db_LocalConfig")) { System.IO.Directory.CreateDirectory(@"Storage\db_LocalConfig"); }
            if (!System.IO.File.Exists(@"Storage\db_LocalConfig\Config.conf")) { System.IO.File.Create(@"Storage\db_LocalConfig\Config.conf"); }

            foreach (string line in System.IO.File.ReadLines(@"Storage\\db_LocalConfig\\Config.conf"))
            {
                string[] ArrayLine = line.Split(':');
                if(ArrayLine[0] == Identifier)
                {
                    return ArrayLine[1];
                }
            }
            return "None";
        }
    }
}
