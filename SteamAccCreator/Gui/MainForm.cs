using System;
using System.Text;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using SteamAccCreator.File;
using SteamAccCreator.Web;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using SteamAccCreator.Storage.LocalDataBases.LocalSettings;
using SteamAccCreator.Storage.LocalDataBases;

namespace SteamAccCreator.Gui
{
    public partial class MainForm : Form
    {
        public bool RandomMail { get; private set; }
        public bool RandomAlias { get; private set; }
        public bool RandomPass { get; private set; }
        public bool WriteIntoFile { get; private set; }
        public bool UseProxy { get; private set; }
        public bool AutoMailVerify { get; private set; }
        public bool UseCaptchaService { get; private set; }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private int _index = 0;
        public MainForm() { InitializeComponent(); }
        //List<string> proxies = Regex.Split(System.IO.File.ReadAllText(@"proxies.txt"), Environment.NewLine).ToList();
        //List<string> origproxies = Regex.Split(System.IO.File.ReadAllText(@"proxies.txt"), Environment.NewLine).ToList();
        int proxyI = 0;

        private void BtnCreateAccount_Click(object sender, EventArgs e)
        {
            /*
            if (proxies.Count < Globals.iMaxIp * Convert.ToInt32(nmbrAmountAccounts._TextBox.Text) && chkAuto.Checked)
            {
                proxies = Regex.Split(System.IO.File.ReadAllText(@"proxies.txt"), Environment.NewLine).ToList();
                origproxies = Regex.Split(System.IO.File.ReadAllText(@"proxies.txt"), Environment.NewLine).ToList();
            }
            lblProxies.Text = (origproxies.Count - proxies.Count) + "/" + origproxies.Count;
            for (var i = 0; i < Convert.ToInt32(nmbrAmountAccounts._TextBox.Text); i++)
            {
                try
                {
                    if (proxyI + 1 > Globals.iMaxIp && Globals.bProxyEnabled)
                    {
                        proxyI = 1;
                        proxies.RemoveAt(0);
                    lblProxies.Text = (origproxies.Count - proxies.Count) + "/" + origproxies.Count;
                    }
                    lblProxy.Text = proxies[0];
                    var accCreator = new AccountCreator(this, txtEmail.Text, txtAlias.Text, txtPass.Text, _index, proxies[0]);
                    var thread = new Thread(accCreator.Run);
                    thread.Start();
                    _index++;
                    proxyI++;
                }
                catch { MessageBox.Show("It appears you have run out of proxies.", "No Proxies"); return; }
            }
            */
        }

        public void AddToTable(string mail, string alias, string pass)
        {
            BeginInvoke(new Action(() =>
            {
                dataAccounts.Rows.Add(new DataGridViewRow
                {
                    Cells =
                    {
                        new DataGridViewTextBoxCell {Value = mail},
                        new DataGridViewTextBoxCell {Value = alias},
                        new DataGridViewTextBoxCell {Value = pass},
                        new DataGridViewTextBoxCell {Value = "Ready"}
                    }
                });
            }));
        }

        public void UpdateStatus(int i, string status) { try { BeginInvoke(new Action(() => { try { dataAccounts.Rows[i].Cells[3].Value = status; } catch { } })); } catch { } }

        private void ChkAutoVerifyMail_CheckedChanged(object sender, EventArgs e) { AutoMailVerify = chkAutoVerifyMail.Checked; }

        private void ChkWriteIntoFile_CheckedChanged(object sender, EventArgs e) { WriteIntoFile = chkWriteIntoFile.Checked; }

        private void ChkAutoCaptcha_CheckedChanged(object sender, EventArgs e) { UseCaptchaService = chkAutoCaptcha.Checked; }

        private void ChkRandomMail_CheckedChanged(object sender, EventArgs e) { var state = chkRandomMail.Checked; chkAutoVerifyMail.Enabled = state; chkAutoVerifyMail.Checked = state; RandomMail = state; txtEmail.Enabled = !state; ToggleForceWriteIntoFile(); }

        private void ChkRandomPass_CheckedChanged(object sender, EventArgs e) { var state = chkRandomPass.Checked; txtPass.Enabled = !state; RandomPass = state; ToggleForceWriteIntoFile(); }

        private void ChkRandomAlias_CheckedChanged(object sender, EventArgs e) { var state = chkRandomAlias.Checked; txtAlias.Enabled = !state; RandomAlias = state; ToggleForceWriteIntoFile(); }

        private void ChkProxy_CheckedChanged(object sender, EventArgs e) { UseProxy = chkProxy.Checked; }

        private void ToggleForceWriteIntoFile() { var shouldForce = chkRandomMail.Checked || chkRandomPass.Checked || chkRandomAlias.Checked; chkWriteIntoFile.Checked = shouldForce; chkWriteIntoFile.Enabled = !shouldForce; }

        private void MainForm_Load(object sender, EventArgs e) { db_Startups.Startup();  RPCUpdater.RunWorkerAsync();
            chkWriteIntoFile.Checked = true; WriteIntoFile = true;
            chkRandomAlias.Checked = true; RandomAlias = true;
            chkRandomMail.Checked = true; RandomMail = true;
            chkRandomPass.Checked = true; RandomPass = true;
            chkAutoVerifyMail.Checked = true; AutoMailVerify = true;
            Globals.popLists();
        }

        private void api_enable_CheckedChanged(object sender, EventArgs e) { Globals.bCaptcha = api_enable.Checked; }

        private void textBox1_TextChanged(object sender, EventArgs e) { Globals.s2Captcha = tbAPI.Text; }

        private void chkProxyEnable_CheckedChanged(object sender, EventArgs e) { Globals.bProxyEnabled = chkProxyEnable.Checked; }

        private void nudProxy_ValueChanged(object sender, EventArgs e) { Globals.iMaxIp = Int32.Parse(nudProxy.Text + ""); }

        private void chkRetry_CheckedChanged(object sender, EventArgs e) { Globals.bRetryCaptcha = chkRetry.Checked; }

        private void nudRetry_ValueChanged(object sender, EventArgs e) { Globals.iMaxRetry = Int32.Parse(nudRetry.Text + ""); }

        private void chkSteamGuard_CheckedChanged(object sender, EventArgs e) {  }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*
            if (!Globals.bLoadKey) { Globals.bLoadKey = true; tbAPI.Text = System.IO.File.ReadAllText(@"api.key"); }
            label1.Text = Gui.CaptchaDialog.GetBalance();
            this.Text = "Steam Account Creator | By: LothosGen.org | Generated: " + Globals.iGenerated;
            */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            Globals.bProxyTest = true;
            proxies = Regex.Split(System.IO.File.ReadAllText(@"proxies.txt"), Environment.NewLine).ToList();
            origproxies = Regex.Split(System.IO.File.ReadAllText(@"proxies.txt"), Environment.NewLine).ToList();
            lblProxies.Text = (origproxies.Count - proxies.Count) + "/" + origproxies.Count;
            for (var i = 0; i < origproxies.Count; i++) { try { if (proxyI + 1 > 1) { proxyI = 1; proxies.RemoveAt(0); lblProxies.Text = (origproxies.Count - proxies.Count) + "/" + origproxies.Count; } lblProxy.Text = proxies[0]; _index++; proxyI++; } catch { MessageBox.Show("It appears you have run out of proxies.", "No Proxies"); return; } }
            */
        }

        private void button2_Click(object sender, EventArgs e) { System.IO.File.AppendAllLines(@"proxies-working.txt", Globals.lProxies); }

        private void button3_Click(object sender, EventArgs e) { } //proxies = Regex.Split(System.IO.File.ReadAllText(@"proxies.txt"), Environment.NewLine).ToList(); origproxies = Regex.Split(System.IO.File.ReadAllText(@"proxies.txt"), Environment.NewLine).ToList(); }

        private void numAuto_ValueChanged(object sender, EventArgs e) { try { if (Int16.Parse(numAuto._TextBox.Text) >= 1 && chkAuto.Checked) { tmrAuto.Interval = Convert.ToInt32(Int16.Parse(numAuto._TextBox.Text)) * 1000; tmrAuto.Enabled = true; } else { tmrAuto.Enabled = false; } } catch { } }

        private void tmrAuto_Tick(object sender, EventArgs e) { btnCreateAccount_Click_1(null,null); }

        private void chkAuto_CheckedChanged(object sender, EventArgs e) { if (Int16.Parse(numAuto._TextBox.Text) >= 1 && chkAuto.Checked) { tmrAuto.Interval = Convert.ToInt32(Int16.Parse(numAuto._TextBox.Text) * 1000); tmrAuto.Enabled = true; } else { tmrAuto.Enabled = false; } }

        private void btnCreateAccount_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.Text == "") { MessageBox.Show("Please choose and email service before generating accounts.", "ERROR"); return; }
            //MessageBox.Show(Globals.sEmailService + "   " + Globals.sProvider);
            int a = Convert.ToInt16(nmbrAmountAccounts._TextBox.Text);
            //if (proxies.Count < Globals.iMaxIp * a && chkAuto.Checked) { proxies = Regex.Split(System.IO.File.ReadAllText(@"proxies.txt"), Environment.NewLine).ToList(); origproxies = Regex.Split(System.IO.File.ReadAllText(@"proxies.txt"), Environment.NewLine).ToList(); }
            //lblProxies.Text = (origproxies.Count - proxies.Count) + "/" + origproxies.Count;
            for (var i = 0; i < a; i++)
            {
                try
                {
                    //if (proxyI + 1 > Globals.iMaxIp && Globals.bProxyEnabled) { proxyI = 1; proxies.RemoveAt(0); lblProxies.Text = (origproxies.Count - proxies.Count) + "/" + origproxies.Count; }
                    //lblProxy.Text = proxies[0];
                    //var accCreator = new AccountCreator(this, txtEmail.Text, txtAlias.Text, txtPass.Text, _index, proxies[0]);\
                    //MessageBox.Show(Globals.sEmailService + "  " + Globals.sProvider);

                    /*
                    var accCreator = new AccountCreator(this, txtEmail.Text, txtAlias.Text, txtPass.Text, _index, "", comboBox1.Text);
                    var thread = new Thread(accCreator.Run);
                    thread.Start();
                    _index++;
                    proxyI++;
                    */

                }catch (Exception d){ MessageBox.Show(d.InnerException.Message + Environment.NewLine + d.InnerException.StackTrace); return; }
            }
            int q = Convert.ToInt32(db_LocalConfig.Read("genTotal"));
            int k = q += 1;
            db_LocalConfig.Write("genTotal", k.ToString());
        }

        private void chkRandomMail_OnChange(object sender, EventArgs e) { var state = chkRandomMail.Checked; chkAutoVerifyMail.Enabled = state; chkAutoVerifyMail.Checked = state; RandomMail = state; txtEmail.Enabled = !state; ToggleForceWriteIntoFile(); AutoMailVerify = state; RandomMail = state; }

        private void chkRandomPass_OnChange(object sender, EventArgs e) { var state = chkRandomPass.Checked; txtPass.Enabled = !state; RandomPass = state; ToggleForceWriteIntoFile(); }

        private void chkRandomAlias_OnChange(object sender, EventArgs e) { var state = chkRandomAlias.Checked; txtAlias.Enabled = !state; RandomAlias = state; ToggleForceWriteIntoFile(); }

        private void chkAutoVerifyMail_OnChange(object sender, EventArgs e) { AutoMailVerify = chkAutoVerifyMail.Checked; }

        private void bunifuCheckbox2_OnChange(object sender, EventArgs e) { if (api_enable.Checked == true) { tbAPI.Visible = true; } else { tbAPI.Visible = false; } Globals.bCaptcha = api_enable.Checked; label14.Visible = api_enable.Checked; label1.Visible = api_enable.Checked; }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e) { UseCaptchaService = chkAutoCaptcha.Checked; }

        private void topBar_MouseMove(object sender, MouseEventArgs e) { if (e.Button == MouseButtons.Left) { ReleaseCapture(); SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0); } }

        private void topBar_Paint(object sender, PaintEventArgs e) {  }

        private void bunifuFlatButton7_Click(object sender, EventArgs e) { this.Close(); }

        private void bunifuFlatButton9_Click(object sender, EventArgs e) { this.WindowState = FormWindowState.Maximized; }

        private void bunifuFlatButton8_Click(object sender, EventArgs e) { this.WindowState = FormWindowState.Minimized; }

        private void button3_Click_1(object sender, EventArgs e) { } //proxies = Regex.Split(System.IO.File.ReadAllText(@"proxies.txt"), Environment.NewLine).ToList(); origproxies = Regex.Split(System.IO.File.ReadAllText(@"proxies.txt"), Environment.NewLine).ToList(); }

        private void button2_Click_1(object sender, EventArgs e) { System.IO.File.AppendAllLines(@"proxies-working.txt", Globals.lProxies); }

        private void button1_Click_1(object sender, EventArgs e)
        {
            /*
            Globals.bProxyTest = true;
            proxies = Regex.Split(System.IO.File.ReadAllText(@"proxies.txt"), Environment.NewLine).ToList();
            origproxies = Regex.Split(System.IO.File.ReadAllText(@"proxies.txt"), Environment.NewLine).ToList();
            lblProxies.Text = (origproxies.Count - proxies.Count) + "/" + origproxies.Count;
            for (var i = 0; i < origproxies.Count; i++)
            {
                try
                {
                    if (proxyI + 1 > 1) { proxyI = 1; proxies.RemoveAt(0); lblProxies.Text = (origproxies.Count - proxies.Count) + "/" + origproxies.Count; }
                    lblProxy.Text = proxies[0];
                    var accCreator = new AccountCreator(this, txtEmail.Text, txtAlias.Text, txtPass.Text, _index, proxies[0]);
                    var thread = new Thread(accCreator.Run);
                    thread.Start();
                    _index++;
                    proxyI++;
                }
                catch { MessageBox.Show("It appears you have run out of proxies.", "No Proxies"); return; }
            }
            */
        }

        private void chkProxyEnable_OnChange(object sender, EventArgs e) { Globals.bProxyEnabled = chkProxyEnable.Checked; lblProxy.Visible = chkProxyEnable.Checked; lblProxies.Visible = chkProxyEnable.Checked; }

        private void chk_auto_captcha_OnChange(object sender, EventArgs e) {  }

        private void bunifuCheckbox1_OnChange_1(object sender, EventArgs e) { UseProxy = chkProxy.Checked; }

        private void bunifuCheckbox1_OnChange_2(object sender, EventArgs e) { WriteIntoFile = chkWriteIntoFile.Checked; }

        private void bunifuCheckbox1_OnChange_3(object sender, EventArgs e) { Globals.bRetryCaptcha = chkRetry.Checked; }

        private void bunifuTextbox1_OnTextChange(object sender, EventArgs e) { Globals.iMaxRetry = Int32.Parse(nudRetry._TextBox.Text + ""); }

        private void nmbrAmountAccounts_ValueChanged(object sender, EventArgs e) {  }

        private void bunifuCheckbox1_OnChange_4(object sender, EventArgs e) { if (Int32.Parse(numAuto._TextBox.Text) >= 1 && chkAuto.Checked) { tmrAuto.Interval = Convert.ToInt32(Int32.Parse(numAuto._TextBox.Text)) * 1000; tmrAuto.Enabled = true; } else { tmrAuto.Enabled = false; } }

        private void bunifuTextbox1_OnTextChange_1(object sender, EventArgs e) { try { if (Int16.Parse(numAuto._TextBox.Text) >= 1 && chkAuto.Checked) { tmrAuto.Interval = Convert.ToInt32(Int16.Parse(numAuto._TextBox.Text)) * 1000; tmrAuto.Enabled = true; } else { tmrAuto.Enabled = false; } } catch { } }

        private void bunifuTextbox1_OnTextChange_2(object sender, EventArgs e) { Globals.iMaxIp = Int32.Parse(nudProxy._TextBox.Text + ""); }

        private void button4_Click(object sender, EventArgs e) { int a = Convert.ToInt32(db_LocalConfig.Read("genTotal")); int k = a += 1; db_LocalConfig.Write("genTotal", k.ToString()); }

        private void bunifuFlatButton1_Click(object sender, EventArgs e) {  }

        private void button5_Click(object sender, EventArgs e) {  }

        private void RPCUpdater_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e) {  }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e) { new InfoForm().Show(); }

        private void bunifuFlatButton4_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("http://lothosgen.org/forum");
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.patreon.com/LothosGen");
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("----------------------------------------------------------------------------" + Environment.NewLine +
                "Graphic Developer:  GameChamp#6666 (Discord)" + Environment.NewLine +
                "Head Developer:      agentsix1#8457 (Discord)" + Environment.NewLine +
                "----------------------------------------------------------------------------", "LothosGenerator ~ Credits");
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://lothosgen.org/");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "") { MessageBox.Show("Please choose and email service before generating accounts.", "ERROR"); return; }
            Globals.sEmailService = Globals.returnURL(comboBox1.Text);
            Globals.sProvider = comboBox1.Text;
            comboBox1.Enabled = false;
        }

        private void chkSteamGuard_OnChange(object sender, EventArgs e)
        {
            Globals.bDisableSteamGuard = chkSteamGuard.Checked;
        }

        private void dataAccounts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            new MainUI().Show();
        }
    }
}
