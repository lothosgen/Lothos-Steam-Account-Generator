using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using SteamAccCreator.File;
using SteamAccCreator.File.MainUI;
using SteamAccCreator.File.MainUI.AppdataFunctions;
using SteamAccCreator.File.MainUI.Browsers;
using SteamAccCreator.File.MainUI.Classes;
using SteamAccCreator.File.MainUI.HTML.DocumentFiles.Classes;
using SteamAccCreator.File.MainUI.HTML.Generator;
using SteamAccCreator.File.MainUI.HTML.Listeners;
using SteamAccCreator.File.MainUI.HTML.Listeners.classes;
using SteamAccCreator.File.MainUI.HTML.Proxy;
using SteamAccCreator.File.MainUI.WebDocs;
using SteamAccCreator.File.MainUI.WebDocs.GridPage;
using SteamAccCreator.File.MainUI.WebDocs.SettingsPage;
using SteamAccCreator.File.MainUI.WebDocs.StartPage;

namespace SteamAccCreator.Gui
{
    public partial class MainUI : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public ChromiumWebBrowser browser;
        public MainUI()
        {
            InitializeComponent();
            MainBrowser.StartBrowser(LeftBrowserWindow);
            RightBrowser.StartBrowser(RightBrowserWindow);


        }
        private void UpdateCheck()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://pastebin.com/raw/1iRv7X4p");

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
                string version = pg.Replace(" ", "").Replace("\n", "");

                if (!version.Contains(l_version.Text))
                {
                    var notification = new System.Windows.Forms.NotifyIcon()
                    {
                        
                        Visible = true,
                        Icon = System.Drawing.SystemIcons.Information,
                        BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Warning,
                        BalloonTipTitle = "LothosGen Update Available",
                        BalloonTipText = "Your current version is " + l_version.Text + Environment.NewLine + "Updatable version is " + version,
                    };
                    notification.Click += new System.EventHandler(NotifyIcon1_Click);
                    notification.ShowBalloonTip(10000);
                    notification.Dispose();
                    
                }
                else
                {

                }

            }
            catch (Exception es) { MessageBox.Show(es.Message); }

        }
        private void NotifyIcon1_Click(object sender, System.EventArgs e)
        {
            System.Diagnostics.Process.Start("http://lothosgen.org/Forum/forumdisplay.php?fid=2");

        }
        private void MainUI_Load(object sender, EventArgs e)
        {
            UpdateCheck();
            GlobalCreation.LoadAllFIles();
            Updater.RunWorkerAsync();
            HTML_Listenser t = new HTML_Listenser();
            Thread html = new Thread(t.Run);
            html.Start();
            l_verified.Text = User.Status;
        }

        private void MainUI_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void ButtonChecks_DoWork(object sender, DoWorkEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

            RightBrowser.browser.ShowDevTools();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("AAA" + MainBrowser.getSource() + "SSS");


        }

        private void MainUI_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show(e.KeyChar.ToString());
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { ReleaseCapture(); SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0); }
        }

        private void btn_exit_MouseClick(object sender, MouseEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }
        int max = 0;
        private void btn_maximize_MouseClick(object sender, MouseEventArgs e)
        {
            if (max == 0)
            {
                this.WindowState = FormWindowState.Maximized;
                max = 1;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                max = 0;
            }
        }

        private void btn_minimize_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if(Key_Listener.Listen(Convert.ToInt32(Keys.Divide)) == true)
            {
                MainBrowser.browser.ShowDevTools();

            }
        }

        private void BrowserWindow_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            new PatreonLogin().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            var Random = new Random();
            var numberR = Random.Next(34672, 999999999);
            int number = numberR;
            GridPageEdit.AddToTable (@"<!--- (s) Start " + number.ToString() + @"--->
    <div name='StartNewRow' id=" + number + @" class='row'>
      <div name='StartCell1' class='cell' data-title='Username'>
        <p name='Cell1Text'>champy</p>
      </div name='EndCell1'>
      <div name='StartCell2' class='cell' data-title='Email'>
        <p name='Cell2Text'>champy999@hotmail.com</p>
      </div name='EndCell2'>
      <div name='StartCell3' class='cell' data-title='Password' >
        <p name='Cell3Text'>00000000884984</p>
      </div name='EndCell3'>
      <div name='StartCell4' class='cell' data-title='Status' >
        <p id='" + number.ToString() + @"' name='Cell4Text'>Done</p>
      </div name='EndCell4'>
    </div name='EndOfRow'> <!--- (e) End " + number.ToString() + @"--->
            ");




           
        }
        private void Bar_Paint(object sender, PaintEventArgs e)
        {

        }
        private void alert(string msg)
        {
            MessageBox.Show(msg);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainBrowser.browser.ShowDevTools();
            //System.IO.File.WriteAllText(ProxyListFile.FileLocation, "");
        }

        private void button6_Click(object sender, EventArgs e)
        {
        }

        private void button7_Click(object sender, EventArgs e)
        {
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            //Globals.sEmailService = Globals.returnURL("@kappa.pw");
            //Globals.sProvider = "@kappa.pw";

            Generate.GenerateAccount(this, Globals.sProvider);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            MessageBox.Show(HTMLObjects.EmailProvider + Environment.NewLine + HTMLObjects.EmailProviderURL);
            //Controller.Visibility(RightBrowser.browser, "Right", "Update", "release2", 15, false);
        }
        public void delay(int delay)
        {
            int i = 0;
            while (i < delay)
            {
                Application.DoEvents();
                Thread.Sleep(1);
                i += 1;
            }
        }
        public static bool PingHost(string strIP, int intPort)
        {
            bool blProxy = false;
            try
            {
                TcpClient client = new TcpClient(strIP, intPort);

                blProxy = true;
            }
            catch
            {
                //MessageBox.Show("Error pinging host:'" + strIP + ":" + intPort.ToString() + "'");
                return false;
            }
            return blProxy;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int checkedVerified = 0;
            int checkedNotVerified = 0;
            while (true)
            {
                if(User.Status == "Not Verified")
                {
                    if (checkedNotVerified == 0)
                    {
                        AutoHide.Hide();
                        checkedNotVerified += 1;
                        checkedVerified = 0;
                        
                    }
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        l_verified.Text = User.Status;
                        l_verified.ForeColor = Color.Red;
                    }); 
                }
                else if(User.Status == "Verified")
                {
                    if(checkedVerified == 0)
                    {
                        AutoHide.ShowPremiumItems();
                        checkedVerified += 1;
                        checkedNotVerified = 0;
                    }
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        l_verified.Text = User.Status;
                        l_verified.ForeColor = Color.Green;
                    });
                }
                Thread.Sleep(200);
            }
        }

        private void version_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            Form a = new PatreonLogin();
            
            a.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void RightBrowserWindow_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_MouseClick(object sender, MouseEventArgs e)
        {
            Form a = new PatreonLogin();

            a.ShowDialog();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discordapp.com/invite/Y5dGPkA");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.patreon.com/LothosGen");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://lothosgen.org/Forum/");
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            notifyIcon1.ShowBalloonTip(1000, "Important", "LOL", ToolTipIcon.Info);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Bitmap BottomPanel = Crop(System.IO.Directory.GetCurrentDirectory() + "\\RainbowTemplate.bmp", 1466, 53, 0, 651);
            Bitmap TopPanel = Crop(System.IO.Directory.GetCurrentDirectory() + "\\RainbowTemplate.bmp", 1466, 29, 0, 0);
            Bitmap RightSidePanel = Crop(System.IO.Directory.GetCurrentDirectory() + "\\RainbowTemplate.bmp", 220, 624, 0, 313);
            Bitmap LeftBrowserPanel = Crop(System.IO.Directory.GetCurrentDirectory() + "\\RainbowTemplate.bmp", 520, 625, 0, 29);
            Bitmap RightBrowserPanel = Crop(System.IO.Directory.GetCurrentDirectory() + "\\RainbowTemplate.bmp", 729, 625, 519, 29);

            LeftBrowserPanel.Save(@"LBP.bmp");
            RightBrowserPanel.Save(@"RBP.bmp");
            MainBrowser.EvaluateScript("document.getElementById('booty').style.backgroundImage = 'url(https://i.imgur.com/ZFi2bAs.png)';", TimeSpan.FromMilliseconds(1));
            MainBrowser.EvaluateScript("document.getElementById('cons').style.backgroundColor = 'transparent';", TimeSpan.FromMilliseconds(1));
            MainBrowser.EvaluateScript("document.getElementById('sb').style.backgroundColor = 'transparent';", TimeSpan.FromMilliseconds(1));
            RightBrowser.EvaluateScript("document.getElementById('bootys').style.backgroundImage = 'url(https://i.imgur.com/iaNeUAu.png)';", TimeSpan.FromMilliseconds(1));
            b_panel.BackgroundImage = BottomPanel;
            Bar.BackgroundImage = TopPanel;

        }
        public Bitmap Crop(string img, int width, int height, int x, int y)
        {
            try
            {
                Image image = Image.FromFile(img);
                Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);
                bmp .SetResolution(80, 60);

                Graphics gfx = Graphics.FromImage(bmp);
                gfx.SmoothingMode = SmoothingMode.AntiAlias;
                gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gfx.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gfx.DrawImage(image, new Rectangle(0, 0, width, height), x, y, width, height, GraphicsUnit.Pixel);
                // Dispose to free up resources
                image.Dispose();
                gfx.Dispose();

                return bmp;
            }
            catch (Exception ex)
            {
                MessageBox.Show("a" + ex.Message);
                return null;
            }
        }

        private void button6_Click_2(object sender, EventArgs e)
        {
            new PremiumBenefits().Show();
        }

        private void b_panel_Paint(object sender, PaintEventArgs e)
        {

        }
        bool hid = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Globals.bGenCooldown)
            {
                if (Globals.iGenCooldown > 0 && !hid)
                {
                    //AutoHide.HideItem(MainBrowser.browser, "Start", "btn_generate");
                    hid = true;
                }
                else if (Globals.iGenCooldown <= 0)
                {
                    hid = false;
                    //AutoHide.ShowItem(MainBrowser.browser, "Start", "btn_generate");
                    Globals.bGenCooldown = false;
                }
                Globals.iGenCooldown -= 1;
            }
            
        }
    }
}
