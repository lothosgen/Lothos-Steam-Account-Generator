using SteamAccCreator.Storage.LocalDataBases.LocalApplicationConfig;
using SteamAccCreator.Storage.LocalDataBases.LocalSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAccCreator.File
{
    class db_Startups
    {
        public static void Startup()
        {
            //db_LocalConfig.Startup();
            //db_LocalApplicationConfig.Startup();

            //db_LocalApplicationConfig_VersionSetter();
        }
        public static void db_LocalApplicationConfig_VersionSetter()
        {
            db_LocalApplicationConfig.Write("Version", "1.0");
        }
    }
}
