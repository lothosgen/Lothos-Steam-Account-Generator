using SteamAccCreator.File.MainUI.Browsers;
using SteamAccCreator.File.MainUI.WebDocs.GridPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SteamAccCreator.File.MainUI.HTML.Generator
{
    class GenerateFunctions
    {
        public static void AddAccountToTable(string mail, string alias, string password, int indexID)
        {
            GridPageEdit.AddToTable(@"<!--- (s) Start " + indexID.ToString() + @"--->
    <div name='StartNewRow' id=" + indexID.ToString() + @" class='row'>
      <div name='StartCell1' class='cell' data-title='Username'>
        <p name='Cell1Text'>" + alias + @"</p>
      </div name='EndCell1'>
      <div name='StartCell2' class='cell' data-title='Email'>
        <p name='Cell2Text' style='font-size: 11px;'>" + mail + @"</p>
      </div name='EndCell2'>
      <div name='StartCell3' class='cell' data-title='Password' >
        <p name='Cell3Text' style='font-size: 11px;' >" + password + @"</p>
      </div name='EndCell3'>
      <div name='StartCell4' class='cell' data-title='Status' >
        <p id='" + indexID.ToString() + @"' name='Cell4Text' style='font-size: 11px;'>Creating account...</p>
      </div name='EndCell4'>
    </div name='EndOfRow'> <!--- (e) End " + indexID.ToString() + @"--->
            ");
        }
        public static int newIndexID()
        {
            var Random = new Random();
            var numberR = Random.Next(34672, 999999999);
            return numberR;
        }
        public static void EditStatus(int indexID, string Newstatus)
        {
            string edit = GridPageEdit.getHistory();
            string[] split = Regex.Split(edit, "\n");
            foreach (string a in split)
            {
                if (a.Contains("Cell4Text"))
                {
                    if (a.Contains(indexID.ToString()))
                    {
                        string[] g = a.Split('>');
                        string[] status = g[1].Split('<');
                        string neww = a.Replace(status[0], Newstatus);
                        string now = edit.Replace(a, neww);
                        GPGlobals.History = now;
                        if (RightBrowser.getSource().Contains("gridpage"))
                        {
                            RightBrowser.LoadGridPage();
                        }
                    }
                }
            }
        }
    }
}
