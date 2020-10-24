using SteamAccCreator.File;
using SteamAccCreator.File.MainUI;
using SteamAccCreator.File.MainUI.WebDocs.StartPage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamAccCreator.Gui
{
    public partial class OptionSettings : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public OptionSettings()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Bar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { ReleaseCapture(); SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0); }
        }
        string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "LothosGen");
        private void Check()
        {
            try
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    AccountsPerProxy.Maximum = Globals.iMaxAccountsPerProxy;
                    ThreadsUse.Maximum = Globals.imaxThreads;
                    cooldown.Maximum = Globals.iMaxThreadCooldown;
                    accountsGen.Maximum = Globals.iMaxAccountsToGenerate;
                });
            }catch { }

            if (Globals.emailaddAllowed == false)
            {
                try
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        l_email.Location = new Point(304, 104);
                        btn_emailAdd.Visible = false;
                    });
                }catch { }
                
            }else if(Globals.emailaddAllowed == true)
            {
                try
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        l_email.Location = new Point(360, 104);
                        btn_emailAdd.Visible = true;
                    });
                }catch { }
                
            }
            if(Globals.gameaddAllowed == false)
            {
                try
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        l_game.Location = new Point(304, 514);
                        b_games.Visible = false;
                    });
                }catch { }
            }else if(Globals.gameaddAllowed == true)
            {
                try
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        l_game.Location = new Point(360, 512);
                        b_games.Visible = true;
                    });
                }
                catch { }
            }
        }
        private void OptionSettings_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(directory)) { Directory.CreateDirectory(directory); }
            txtCaptchaSolutionsKey.Text = HTMLObjects.sCaptchaGuru;
            txt2Captchakey.Text = HTMLObjects.s2Captcha;
            AccountsPerProxy.Value = Globals.iAccountsPerProxy;
            ThreadsUse.Value = Globals.iThreads;
            cooldown.Value = Globals.iThreadCooldwon;
            accountsGen.Value = Globals.iAccountsToGenerate;
            cb_email.Text = HTMLObjects.EmailProvider;
            cb_proxy.Text = HTMLObjects.sProxy;
            cb_games.Text = Globals.SelectedGame;
            if (!System.IO.File.Exists(@"ProgramProxies.txt"))
            {
                System.IO.File.Create(@"ProgramProxies.txt").Close();
            }
            Updater.RunWorkerAsync();
        }

        private void btnConfirm_Click(object sender, EventArgs ex)
        {
            if (txt2Captchakey.Text != "") { HTMLObjects.s2Captcha = txt2Captchakey.Text; } else { HTMLObjects.s2Captcha = ""; }
            if (txtCaptchaSolutionsKey.Text != "") { HTMLObjects.sCaptchaGuru = txtCaptchaSolutionsKey.Text; } else { HTMLObjects.sCaptchaGuru = ""; }
            Globals.iAccountsPerProxy = Convert.ToInt32(AccountsPerProxy.Value);
            Globals.iThreads = Convert.ToInt32(ThreadsUse.Value);
            Globals.iThreadCooldwon = Convert.ToInt32(cooldown.Value);
            Globals.iAccountsToGenerate = Convert.ToInt32(accountsGen.Value);
            HTMLObjects.sProxy = cb_proxy.Text.ToString();
            Globals.SelectedGame = cb_games.Text;

            if (cb_email.Text != String.Empty)
            {
                string[] emails = Regex.Split(EmailProviders, Environment.NewLine);
                foreach (string e in emails)
                {
                    if (e.Contains(cb_email.Text))
                    {
                        HTMLObjects.EmailProvider = Regex.Split(e, ",")[0];
                        HTMLObjects.EmailProviderURL = Regex.Split(e, ",")[1];
                    }
                }
            }
            /*
            if (cb_email.Text != "")
            {
                
                System.IO.File.WriteAllText(@"Emails.txt", EmailProviders);
                foreach (string a in split)
                {
                    string FullText = "@" + a;
                    if (FullText.Contains(cb_email.Text))
                    {


                        string TextNoSpace = FullText.Replace(" ", string.Empty);
                        string[] Seperated = TextNoSpace.Split('|');
                        string Email = Seperated[0];
                        string Provider = Seperated[1];

                        HTMLObjects.EmailProvider = Email;
                        HTMLObjects.EmailProviderURL = Provider;

                    }
                }
            }
            */

        }
        private void GameBoxChecker()
        {
            try
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    string items = "";
                    foreach (string n in cb_games.Items)
                    {
                        items += n + " \n";
                    }
                    if (!items.Contains(cb_games.Text))
                    {
                        cb_games.Text = "";
                    }
                    string MItems = "";
                    foreach(string n in cb_games.Items)
                    {
                        MItems += n + " ";
                    }
                });
            }
            catch { }
        }
        private void EmailBoxChecker()
        {
            try
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    string items = "";
                    foreach (string n in cb_email.Items)
                    {
                        items += n + " \n";
                    }
                    if (!items.Contains(cb_email.Text))
                    {
                        cb_email.Text = "";
                    }
                });
            }catch { }
        }
        public string Games = string.Empty;
        private void GamesUpdater()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://pastebin.com/raw/MsNnJHEF");

                HttpWebRequest r = request;
                r.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/29.0.1547.2 Safari/537.36";
                r.Timeout = 3000;
                HttpWebResponse re = (HttpWebResponse)r.GetResponse();
                Stream s = re.GetResponseStream();
                string pg = "";

                using (var reader = new StreamReader(s))
                {

                    while (!reader.EndOfStream)
                    {
                        pg += reader.ReadLine() + Environment.NewLine;
                    }
                }
                Games = pg;

            }
            catch (Exception es) { MessageBox.Show(es.Message); }
            if (User.Status == "Verified")
            {
                string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "LothosGen");
                string Sdirectory = directory + "\\Saves\\save3.file";
                if (System.IO.File.Exists(Sdirectory))
                {
                    string[] lines = System.IO.File.ReadAllLines(Sdirectory);
                    foreach (string line in lines)
                    {
                        if (!cb_games.Items.Contains(line))
                        {
                            Games += line;
                        }
                    }

                }
            }
            string[] split = Games.Split('[');
            foreach(string line in split)
            {
                if (!line.All(char.IsDigit))
                {
                    try
                    {
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            if (!cb_games.Items.Contains(line))
                            {
                                cb_games.Items.Add(line);
                            }

                        });
                    }
                    catch { }
                    
                }
                
            }
        }
        private void Updater_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                EmailBoxChecker();
                Check();
                GameBoxChecker();
                GamesUpdater();
                EmailsUpdater();
                ProxyComboBoxUpdater();
                AutoItemUpdater();
                Thread.Sleep(500);
            }
            
        }
        private void AutoItemUpdater()
        {
            string value = "";
            try
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    value = cb_AutoUpdate.Text;
                });
            }catch { }
            
            if(value == "Yes")
            {
                try
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        if (txt2Captchakey.Text != "") { HTMLObjects.s2Captcha = txt2Captchakey.Text; } else { HTMLObjects.s2Captcha = ""; }
                        if (txtCaptchaSolutionsKey.Text != "") { HTMLObjects.sCaptchaGuru = txtCaptchaSolutionsKey.Text; } else { HTMLObjects.sCaptchaGuru = ""; }
                        Globals.iAccountsPerProxy = Convert.ToInt32(AccountsPerProxy.Value);
                        Globals.iThreads = Convert.ToInt32(ThreadsUse.Value);
                        Globals.iThreadCooldwon = Convert.ToInt32(cooldown.Value);
                        Globals.iAccountsToGenerate = Convert.ToInt32(accountsGen.Value);
                        HTMLObjects.sProxy = cb_proxy.Text.ToString();

                        if (cb_email.Text != String.Empty)
                        {
                            string[] emails = Regex.Split(EmailProviders, Environment.NewLine);
                            foreach (string e in emails)
                            {
                                if (e.Contains(cb_email.Text))
                                {
                                    HTMLObjects.EmailProvider = Regex.Split(e, ",")[0];
                                    HTMLObjects.EmailProviderURL = Regex.Split(e, ",")[1];
                                }
                            }
                        }
                    });
                }
                catch { }
            }
        }
        private void cb_proxy_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        string EmailProviders = string.Empty;
        private void EmailsUpdater()
        {

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://pastebin.com/raw/DKPyVzNX");

                HttpWebRequest r = request;
                r.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/29.0.1547.2 Safari/537.36";
                r.Timeout = 3000;
                HttpWebResponse re = (HttpWebResponse)r.GetResponse();
                Stream s = re.GetResponseStream();
                string pg = "";

                using (var reader = new StreamReader(s))
                {

                    while (!reader.EndOfStream)
                    {
                        pg += reader.ReadLine() + Environment.NewLine;
                    }
                }
                EmailProviders = pg;

            }
            catch (Exception es) { MessageBox.Show(es.Message); }
            if(User.Status == "Verified")
            {
                string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "LothosGen");
                string Sdirectory = directory + "\\Saves\\save2.file";
                if (System.IO.File.Exists(Sdirectory))
                {
                    string[] lines = System.IO.File.ReadAllLines(Sdirectory);
                    foreach (string line in lines)
                    {
                        EmailProviders += Environment.NewLine + line;
                    }

                }
            }

            string[] split = EmailProviders.Split('@');

            string currentEmails = "";

            foreach (string line in cb_email.Items)
            {
                currentEmails += Environment.NewLine + line;
            }


            string[] emails = Regex.Split(EmailProviders, Environment.NewLine);
            foreach (string e in emails)
            {
                if (e.Contains("."))
                {
                    try
                    {
                        string Email = Regex.Split(e, ",")[0];
                        string Provider = Regex.Split(e, ",")[1];

                        if (!currentEmails.Contains(Email))
                        {
                            try
                            {
                                this.Invoke((MethodInvoker)delegate ()
                                {
                                    cb_email.Items.Add(Email);
                                });
                            }
                            catch { }
                        }
                    }
                    catch { }
                    //HTMLObjects.EmailProvider = 
                    //HTMLObjects.EmailProviderURL = Regex.Split(e, ",")[1];
                    //MessageBox.Show(HTMLObjects.EmailProvider + "-" + HTMLObjects.EmailProviderURL + "-" + e);
                }
            }
            /*
            foreach (string a in split)
            {
                if (a.Contains("."))
                {
                    string FullText = "@" + a;
                    string TextNoSpace = FullText.Replace(" ", string.Empty);
                    string[] Seperated = TextNoSpace.Split('|');
                    

                    

                }
            }
            */
        }
        private void ProxyComboBoxUpdater()
        {
            string[] ProxiesRaw = System.IO.File.ReadAllLines(@"ProgramProxies.txt");
            foreach(string lines in ProxiesRaw)
            {
                if (!cb_proxy.Items.Contains(lines))
                {
                    if(lines != "\n" || lines != Environment.NewLine || lines != string.Empty)
                    {
                        string ModifiedProxy = lines.Replace(" ", string.Empty).Replace("\r\n?|\n", string.Empty).Replace("\n", string.Empty);
                        try
                        {
                            this.Invoke((MethodInvoker)delegate ()
                            {
                                cb_proxy.Items.Add(ModifiedProxy);
                            });
                        }
                        catch { }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddProxies frm = new AddProxies();
            frm.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cb_email_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs ex)
        {
            if (txt2Captchakey.Text != "") { HTMLObjects.s2Captcha = txt2Captchakey.Text; } else { HTMLObjects.s2Captcha = ""; }
            if (txtCaptchaSolutionsKey.Text != "") { HTMLObjects.sCaptchaGuru = txtCaptchaSolutionsKey.Text; } else { HTMLObjects.sCaptchaGuru = ""; }
            Globals.iAccountsPerProxy = Convert.ToInt32(AccountsPerProxy.Value);
            Globals.iThreads = Convert.ToInt32(ThreadsUse.Value);
            Globals.iThreadCooldwon = Convert.ToInt32(cooldown.Value);
            Globals.iAccountsToGenerate = Convert.ToInt32(accountsGen.Value);
            HTMLObjects.sProxy = cb_proxy.Text.ToString();
            Globals.SelectedGame = cb_games.Text;

            if (cb_email.Text != "")
            {
                string[] emails = Regex.Split(EmailProviders, Environment.NewLine);
                foreach (string e in emails)
                {
                    if (e.Contains(cb_email.Text))
                    {
                        HTMLObjects.EmailProvider = Regex.Split(e, ",")[0];
                        HTMLObjects.EmailProviderURL = Regex.Split(e, ",")[1];
                        //MessageBox.Show(HTMLObjects.EmailProvider + "-" + HTMLObjects.EmailProviderURL + "-" + e);
                    }
                }
                /*
                string[] split = EmailProviders.Split('@');

                foreach (string a in split)
                {
                    string FullText = "@" + a;
                    if (FullText.Contains(cb_email.Text))
                    {


                        string TextNoSpace = FullText.Replace(" ", string.Empty);
                        string[] Seperated = TextNoSpace.Split('|');
                        string Email = Seperated[0];
                        string Provider = Seperated[1];

                        HTMLObjects.EmailProvider = Email;
                        HTMLObjects.EmailProviderURL = Provider;

                    }
                }
                */
            }

            if (!Directory.Exists(directory + "\\Saves")) { Directory.CreateDirectory(directory + "\\Saves"); }
            System.IO.File.Create(directory + "\\Saves\\save1.file").Close();

            using (var writer = new StreamWriter(directory + "\\Saves\\save1.file", true))
            {
                writer.WriteLine("txtCaptchaSolutionsKey:" + HTMLObjects.sCaptchaGuru);
                writer.WriteLine("txt2Captchakey:" + HTMLObjects.s2Captcha);
                writer.WriteLine("AccountsPerProxy:" + Globals.iAccountsPerProxy);
                writer.WriteLine("ThreadsUse:" + Globals.iThreads);
                writer.WriteLine("cooldown:" + Globals.iThreadCooldwon);
                writer.WriteLine("accountsGen:" + Globals.iAccountsToGenerate);
                writer.WriteLine("cb_email:" + HTMLObjects.EmailProvider);
                writer.WriteLine("cb_proxy-" + HTMLObjects.sProxy);
                writer.WriteLine("cb_game-" + Globals.SelectedGame);
                writer.Close();
            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(directory + "\\Saves")) { MessageBox.Show("You Have No Saves Saved."); }
            string[] text = System.IO.File.ReadAllLines(directory + "\\Saves\\save1.file");

            foreach(string line in text)
            {
                string[] news = line.Split(':');
                if (news[0].Contains("txtCaptchaSolutionsKey")) { HTMLObjects.sCaptchaGuru = news[1]; txtCaptchaSolutionsKey.Text = HTMLObjects.sCaptchaGuru; }
                if (news[0].Contains("txt2Captchakey")) { HTMLObjects.s2Captcha = news[1]; txt2Captchakey.Text = HTMLObjects.s2Captcha; }
                if (news[0].Contains("AccountsPerProxy")) { Globals.iAccountsPerProxy = int.Parse(news[1]); AccountsPerProxy.Text = Globals.iAccountsPerProxy.ToString(); }
                if (news[0].Contains("ThreadsUse")) { Globals.iThreads = int.Parse(news[1]); ThreadsUse.Text = Globals.iThreads.ToString(); }
                if (news[0].Contains("cooldown")) { Globals.iThreadCooldwon = int.Parse(news[1]); cooldown.Text = Globals.iThreadCooldwon.ToString(); }
                if (news[0].Contains("accountsGen")) { Globals.iAccountsToGenerate = int.Parse(news[1]); accountsGen.Text = Globals.iAccountsToGenerate.ToString(); }
                if (news[0].Contains("cb_email")) { HTMLObjects.EmailProvider = news[1]; cb_email.Text = HTMLObjects.EmailProvider; }
                string[] newss = line.Split('-');
                if (newss[0].Contains("cb_proxy")) { HTMLObjects.sProxy = newss[1]; cb_proxy.Text = HTMLObjects.sProxy; }
                if (newss[0].Contains("cb_game")) { Globals.SelectedGame = newss[1]; cb_games.Text = Globals.SelectedGame; }
            }
        }

        private void Bar_MouseLeave(object sender, EventArgs e)
        {

        }

        private void Bar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            new EmailServiceAdd().Show();
        }

        private void b_games_Click(object sender, EventArgs e)
        {
            new GameAdd().Show();
        }

        private void cb_games_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cb_AutoUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private byte[] key = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
        private byte[] iv = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };

        public string Crypt(string text)
        {
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateEncryptor(key, iv);
            byte[] inputbuffer = Encoding.Unicode.GetBytes(text);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            return Convert.ToBase64String(outputBuffer);
        }

        public string Decrypt(string text)
        {
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateDecryptor(key, iv);
            byte[] inputbuffer = Convert.FromBase64String(text);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            return Encoding.Unicode.GetString(outputBuffer);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            accountsGen.Maximum = 10;
            System.IO.File.WriteAllText(@"System.Data.dll", Crypt("ae5rt9-wdfkm234010awerj23450-99osdflk2340-dewrk"));
            if (Int32.Parse(Decrypt(System.IO.File.ReadAllText(@"System.Data.dll")).Replace("ae5rt9-wdfkm2340", "").Replace("awerj23450-99osdflk2340-dewrk", "")) > 10)
            {
                System.IO.File.WriteAllText(@"System.Data.dll", Crypt("ae5rt9-wdfkm234010awerj23450-99osdflk2340-dewrk"));
            } else
            {
                accountsGen.Maximum = Int32.Parse(Decrypt(System.IO.File.ReadAllText(@"System.Data.dll")).Replace("ae5rt9-wdfkm2340", "").Replace("awerj23450-99osdflk2340-dewrk", ""));
            }
            
        }
    }
}
