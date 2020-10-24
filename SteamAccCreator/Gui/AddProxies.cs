using SteamAccCreator.File.MainUI.WebDocs.SettingsPage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamAccCreator.Gui
{
    public partial class AddProxies : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public AddProxies()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] n = tb_proxies.Text.Split('\n');
            foreach(string a in n)
            {//\r\n?|\n
                string neww = a.Replace("\r\n?|\n", string.Empty).Replace("\r", string.Empty).Replace("\n?", string.Empty).Replace("?", string.Empty).Replace("|", string.Empty).Replace("\n", string.Empty).Replace(" ", string.Empty);
                SPGlobals.addProxyToList(neww);
               
            }
            this.Hide();
            
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            System.IO.File.Delete(@"ProgramProxies.txt");
            System.IO.File.AppendAllText(@"ProgramProxies.txt", tb_proxies.Text);
            tb_proxies.Text = string.Empty;
            string[] ProxiesRaw = System.IO.File.ReadAllLines(@"ProgramProxies.txt");
            foreach (string lines in ProxiesRaw)
            {
                string ModifiedProxy = lines.Replace(" ", string.Empty).Replace("\r\n?|\n", string.Empty).Replace("\n", string.Empty);
                tb_proxies.AppendText(ModifiedProxy + Environment.NewLine);
            }
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddProxies_Load(object sender, EventArgs e)
        {



        }

        private void AddProxies_Load_1(object sender, EventArgs e)
        {
            string[] ProxiesRaw = System.IO.File.ReadAllLines(@"ProgramProxies.txt");
            foreach (string lines in ProxiesRaw)
            {
                string ModifiedProxy = lines.Replace(" ", string.Empty).Replace("\r\n?|\n", string.Empty).Replace("\n", string.Empty);
                tb_proxies.AppendText(ModifiedProxy + Environment.NewLine);
            }
        }
        [STAThread]
        private void button1_Click_1(object sender, EventArgs e)
        {
            Process.Start(Environment.ExpandEnvironmentVariables("%AppData%\\.minecraft"));




        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Bar_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
