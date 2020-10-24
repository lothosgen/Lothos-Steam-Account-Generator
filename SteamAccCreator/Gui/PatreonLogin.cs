using CefSharp;
using SteamAccCreator.File.MainUI;
using SteamAccCreator.File.MainUI.Browsers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamAccCreator.Gui
{
    public partial class PatreonLogin : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public PatreonLogin()
        {
            InitializeComponent();
        }

        private void DiscordLogin_Load(object sender, EventArgs e)
        {
            PatreonBrowser.StartBrowser(p_patreon);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PatreonBrowser.browser.Load("https://www.patreon.com/settings/profile");
            Thread.Sleep(1200);
            string html = PatreonBrowser.getSource();
            string[] split = html.Split('\n');
            foreach(string l in split)
            {
                if (l.Contains("stripeSessionEmail"))
                {
                    string[] emailR = l.Split(':');
                    string email = emailR[1].Replace(",", string.Empty).Replace("'", string.Empty).Replace(" ", string.Empty);
                    MessageBox.Show(email);

                }
                else
                {
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PatreonBrowser.browser.Load("https://www.patreon.com/settings/profile");
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                
                string Foundemail = "";
                PatreonBrowser.browser.Load("https://www.patreon.com/settings/profile");
                Thread.Sleep(800);
                string html = PatreonBrowser.getSource(); ;
                string[] split = html.Split('\n');
                foreach (string l in split)
                {
                    if (l.Contains("stripeSessionEmail"))
                    {
                        string[] emailR = l.Split(':');
                        string email = emailR[1].Replace(",", string.Empty).Replace("'", string.Empty).Replace(" ", string.Empty);
                        string[] es = email.Split('"');
                        Foundemail = es[1];

                    }
                    else
                    {
                        
                    }
                }
                if (!Foundemail.Contains("@")) {  }
                string s = FindEmail(Foundemail);
                if (s == "true")
                {
                    l_verified.Text = "Verified";
                    l_verified.ForeColor = System.Drawing.Color.Green;
                    User.PremiumMember = true;
                    User.Status = "Verified";

                }
                else if (s == "false")
                {
                    l_verified.Text = "Not Verified";
                    l_verified.ForeColor = System.Drawing.Color.Red;
                    User.PremiumMember = false;
                    User.Status = "Not Verified";
                }
                else if (s == "Unknown Email 456")
                {
                    l_verified.Text = "Unknown Email 456";
                    l_verified.ForeColor = System.Drawing.Color.Pink;
                    User.Status = "Not Verified";
                    User.PremiumMember = false;
                }
                else if (s == "Unknown Email 457")
                {
                    l_verified.Text = "Unknown Email 457";
                    l_verified.ForeColor = System.Drawing.Color.Pink;
                    User.Status = "Not Verified";
                    User.PremiumMember = false;
                }
                else if(s == "Unknown Error 89")
                {
                    l_verified.Text = "Unknown Error 89";
                    l_verified.ForeColor = System.Drawing.Color.Blue;
                    User.Status = "Not Verified";
                    User.PremiumMember = false;
                }
                else if (s == "404")
                {
                    l_verified.Text = "Error 404";
                    l_verified.ForeColor = System.Drawing.Color.Blue;
                    User.Status = "Not Verified";
                    User.PremiumMember = false;
                }
                else if (s == "Error 784")
                {
                    l_verified.Text = "Error 784";
                    l_verified.ForeColor = System.Drawing.Color.Blue;
                    User.Status = "Not Verified";
                    User.PremiumMember = false;
                }
                else
                {
                    User.Status = "Not Verified";
                    User.PremiumMember = false;
                }
                PatreonBrowser.browser.Hide();
                PatreonBrowser.StartBrowser(p_patreon);
            }
            catch
            {
                l_verified.Text = "Error 932";
                l_verified.ForeColor = System.Drawing.Color.Blue;
            }
        }
        public string FindEmail(string email)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://lothosgen.org/ReleAAAase/Release/Members.html");

                HttpWebRequest r = request;
                r.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/29.0.1547.2 Safari/537.36";
                r.Timeout = 5000;
                HttpWebResponse re = (HttpWebResponse)r.GetResponse();
                Stream s = re.GetResponseStream();
                string pg = "";
                using (var reader = new StreamReader(s))
                {

                    while (!reader.EndOfStream)
                    {
                        string[] splits = Regex.Split(reader.ReadLine(), "<br>");
                        foreach (string a in splits)
                        {
                            pg += a + Environment.NewLine + Environment.NewLine + "NEWP";
                        }
                    }
                }
                string[] k = Regex.Split(pg, "NEWP");
                int linecheck = 0;
                foreach (string line in k)
                {
                    Thread.Sleep(200);
                    if (!email.Contains("@"))
                    {
                        return "Unknown Email 456";
                    }
                    else
                    {
                        if (email == " " || email == Environment.NewLine || email == "\n")
                        {
                            return "Unknown Email 457";
                        }
                        else
                        {
                            if (k[linecheck].Contains(email) && k[linecheck].Contains("Active patron"))
                            {
                                return "true";

                            }
                            else
                            {
                                linecheck += 1;
                            }
                            
                        }
                    }

                }
                return "false";
            }
            catch(Exception e)
            {
                if (e.Message.Contains("404"))
                {
                    return "404";
                }
                else
                {
                    return "Unknown Error 89";
                }
            }
            return "Error 784";
        }
        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_exit_Click_1(object sender, EventArgs e)
        {
            PatreonBrowser.browser.Delete();
            PatreonBrowser.browser.Dispose();

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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (FindEmail("") == "true")
            {
                l_verified.Text = "Verified";
                l_verified.ForeColor = System.Drawing.Color.Green;

            }
            else
            {
                l_verified.Text = "Not Verified";
                l_verified.ForeColor = System.Drawing.Color.Red;

            }
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
        }
    }
}
