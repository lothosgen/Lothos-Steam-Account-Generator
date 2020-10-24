using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAccCreator.Storage.LocalDataBases.LocalSettings
{
    class db_LocalSettings
    {
        public static void Write()
        {
            if(!System.IO.Directory.Exists(@"\\Storage")) { System.IO.Directory.CreateDirectory(@"\\Storage"); }
            if (!System.IO.Directory.Exists(@"\\Storage\\db_LocalSettings")) { System.IO.Directory.CreateDirectory(@"\\Storage\\db_LocalSettings"); }



        }
        public static void Read()
        {

        }
    }
}
