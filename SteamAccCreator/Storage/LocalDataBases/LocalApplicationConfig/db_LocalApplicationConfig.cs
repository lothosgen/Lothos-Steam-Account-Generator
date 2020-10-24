using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAccCreator.Storage.LocalDataBases.LocalApplicationConfig
{
    class db_LocalApplicationConfig
    {
        public static void Startup()
        {
            if (!System.IO.Directory.Exists(@"Storage")) { System.IO.Directory.CreateDirectory(@"Storage"); }
            if (!System.IO.Directory.Exists(@"Storage\db_db_LocalApplicationConfig")) { System.IO.Directory.CreateDirectory(@"Storage\db_LocalApplicationConfig"); }
            if (!System.IO.File.Exists(@"Storage\db_LocalApplicationConfig\Config.conf")) { System.IO.File.Create(@"Storage\db_LocalApplicationConfig\Config.conf"); }


        }

        public static void Write(string Identifier, string value)
        {
            List<string> RecentData = new List<string>();

            if (!System.IO.Directory.Exists(@"Storage")) { System.IO.Directory.CreateDirectory(@"Storage"); }
            if (!System.IO.Directory.Exists(@"Storage\db_LocalApplicationConfig")) { System.IO.Directory.CreateDirectory(@"Storage\db_LocalApplicationConfig"); }
            if (!System.IO.File.Exists(@"Storage\db_LocalApplicationConfig\Config.conf")) { System.IO.File.Create(@"Storage\db_LocalApplicationConfig\Config.conf").Close(); }

            foreach (string line in System.IO.File.ReadLines(@"Storage\\db_LocalApplicationConfig\\Config.conf"))
            {
                string[] array = line.Split(':');
                if (array[0] == Identifier)
                {
                }
                else { RecentData.Add(line); }
            }
            System.IO.File.Delete(@"Storage\db_LocalApplicationConfig\Config.conf");
            System.IO.File.Create(@"Storage\db_LocalApplicationConfig\Config.conf").Close(); ;

            RecentData.Add(Identifier + ":" + value);

            string all = string.Join(Environment.NewLine, RecentData.ToArray());

            using (StreamWriter file = System.IO.File.AppendText(@"Storage\db_LocalApplicationConfig\Config.conf"))
            {
                file.WriteLine(all);
                file.Close();
            }
        }
        public static string Read(string Identifier)
        {
            Dictionary<string, string> CurrentData = new Dictionary<string, string>();

            if (!System.IO.Directory.Exists(@"Storage")) { System.IO.Directory.CreateDirectory(@"Storage"); }
            if (!System.IO.Directory.Exists(@"Storage\db_LocalApplicationConfig")) { System.IO.Directory.CreateDirectory(@"Storage\db_LocalApplicationConfig"); }
            if (!System.IO.File.Exists(@"Storage\db_LocalApplicationConfig\Config.conf")) { System.IO.File.Create(@"Storage\db_LocalApplicationConfig\Config.conf"); }

            foreach (string line in System.IO.File.ReadLines(@"Storage\\db_LocalApplicationConfig\\Config.conf"))
            {
                string[] ArrayLine = line.Split(':');
                if (ArrayLine[0] == Identifier)
                {
                    return ArrayLine[1];
                }
            }
            return "None";
        }
    }
}
