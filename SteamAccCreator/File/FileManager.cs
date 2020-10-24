using SteamAccCreator.File.MainUI.WebDocs.HistoryPage;
using SteamAccCreator.File.MainUI.WebDocs.StartPage;
using System;
using System.Collections.Generic;
using System.IO;

namespace SteamAccCreator.File
{
    public class FileManager
    {
        public static string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string specificFolder = Path.Combine(folder, "LothosGen");

        public static string FileCode = "ASDUBASJDJASBD79ta78sdgGASDHASDVA78f8634fruASVDJH";
        public static string FileCodeExtension = ".ASBDOAJSDB7astgd78aDGSHKASVDouiasgd97asdg";
        public static string FileLocation = (specificFolder + "\\" + FileCode + FileCodeExtension);
        public static string FolderLocation = specificFolder;

        private const string PathA = @"accounts.txt";
        private const string PathB = @"advanced_accounts.txt";

        public void WriteIntoFile(string mail, string alias, string pass, string index)
        {
            using (var writer = new StreamWriter(PathB, true))
            {
                writer.WriteLine("Mail: \t\t" + mail);
                writer.WriteLine("Alias: \t\t" + alias);
                writer.WriteLine("Pass: \t\t" + pass);
                writer.WriteLine("Creation: \t" + DateTime.Now);
                writer.WriteLine("###########################");
            }
            using (var writer = new StreamWriter(PathA, true))
            {
                writer.WriteLine(alias + ":" + pass);
            }
            HistoryPageEdit.AddAccountToTable(mail, alias, pass, Convert.ToInt32(index));
        }
    }
}