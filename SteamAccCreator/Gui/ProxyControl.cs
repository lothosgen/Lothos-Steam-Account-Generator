using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteamAccCreator.File.MainUI.Classes.Proxy;
using SteamAccCreator.File;
using System.Threading;
using System.Diagnostics;

namespace SteamAccCreator.Gui
{
    public partial class ProxyControl : UserControl
    {
        public ProxyControl()
        {
            InitializeComponent();
        }
        Thread t;
        private void btnStart_Click(object sender, EventArgs e)
        {
            clsProxy clsP = new clsProxy(Int32.Parse("" + numericUpDown1.Value), Int32.Parse("" + numericUpDown2.Value), Int32.Parse("" + numericUpDown3.Value));
            t = new Thread(clsP.Run);
            t.Start();
            Globals.sStatus = "Running...";
            Globals.cStatus = System.Drawing.Color.Green;
            Globals.bStart = false;
            Globals.bPause = true;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            t.Abort();
            Globals.sStatus = "Idle";
            Globals.cStatus = System.Drawing.Color.Orange;
            Globals.bPause = false;
            Globals.bStart = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            System.IO.File.AppendAllText(@"proxies\Working.txt", Globals.sGood);
            System.IO.File.AppendAllText(@"proxies\Bad.txt", Globals.sBad);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (lbActions.SelectedIndex < 0)
            {
                MessageBox.Show("You have not selection an action to be completed");
            }
            switch (lbActions.SelectedIndex)
            {
                case 0: // Save Proxies
                    System.IO.File.AppendAllText(@"proxies\Working.txt", Globals.sGood);
                    System.IO.File.AppendAllText(@"proxies\Bad.txt", Globals.sBad);
                    break;
                case 1: // Delete Working Proxies;
                    System.IO.File.WriteAllText(@"proxies\Working.txt", "");
                    break;
                case 2: // Delete Bad Proxies
                    System.IO.File.WriteAllText(@"proxies\Bad.txt", "");
                    break;
                case 3: // Reload Proxies
                    if (!System.IO.File.Exists(@"untested.txt"))
                    {
                        MessageBox.Show("You do not currently have a untested.txt");
                        System.IO.File.Create(@"untested.txt").Close();
                    }
                    if (System.IO.File.ReadAllText(@"untested.txt") == string.Empty)
                    {
                        MessageBox.Show("There are no proxies located in the 'untested.txt' file");
                        //Process.GetCurrentProcess().Kill();
                    }
                    Globals.lUntested.Clear();
                    foreach (String p in System.IO.File.ReadAllLines(@"untested.txt"))
                    {
                        try
                        {
                            Globals.lUntested.Add(p);
                        }
                        catch
                        {

                        }

                    }
                    t.Abort();
                    Globals.bStart = true;
                    Globals.bPause = false;
                    break;

            }
        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            lblUntested.Text = Globals.lUntested.Count() + "";
            lblGood.Text = Globals.lGood.Count() + "";
            lblBad.Text = Globals.lBad.Count() + "";
            lblPending.Text = Globals.lPending.Count() + "";


            lblStatus.Text = Globals.sStatus;
            lblStatus.ForeColor = Globals.cStatus;

            btnStart.Enabled = Globals.bStart;
            btnPause.Enabled = Globals.bPause;
        }

        private void ProxyControl_Load(object sender, EventArgs e)
        {

        }
    }
}
