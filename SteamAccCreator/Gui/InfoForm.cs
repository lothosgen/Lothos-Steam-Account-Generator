using SteamAccCreator.Storage.LocalDataBases.LocalSettings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamAccCreator.Gui
{
    public partial class InfoForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public InfoForm() { InitializeComponent(); }

        private void bunifuFlatButton7_Click(object sender, EventArgs e) { this.Hide(); }

        private void bunifuFlatButton8_Click(object sender, EventArgs e) { this.WindowState = FormWindowState.Minimized; }

        private void topBar_MouseMove(object sender, MouseEventArgs e) { if (e.Button == MouseButtons.Left) { ReleaseCapture(); SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0); } }

        private void topBar_Paint(object sender, PaintEventArgs e) {  }

        private void InfoForm_Load(object sender, EventArgs e) { Updater.RunWorkerAsync(); }

        private void Updater_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                this.Invoke(new MethodInvoker(delegate { made.Text = db_LocalConfig.Read("genTotal"); }));
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
