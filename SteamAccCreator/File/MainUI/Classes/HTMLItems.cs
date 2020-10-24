using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAccCreator.File.MainUI.Classes
{
    class HTMLItems
    {
        public static string GenerateButton()
        {
            return "<button id='btn_generate' name='false' onclick='buttonHandler_generate(this.id);' class='cusbutton cusradius'><b style='position: relative; bottom: 3px; left: -1px; '>Generate</b></button>";
        }
    }
}
