namespace SteamAccCreator.Gui
{
    partial class MainUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUI));
            this.button1 = new System.Windows.Forms.Button();
            this.Bar = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.l_version = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btn_minimize = new System.Windows.Forms.PictureBox();
            this.btn_exit = new System.Windows.Forms.PictureBox();
            this.Logo = new System.Windows.Forms.Label();
            this.LeftBrowserWindow = new System.Windows.Forms.Panel();
            this.Key_Listen = new System.Windows.Forms.Timer(this.components);
            this.Updater = new System.ComponentModel.BackgroundWorker();
            this.AdSpace = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.RightBrowserWindow = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.l_verified = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.b_panel = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Bar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_minimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_exit)).BeginInit();
            this.AdSpace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.b_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1024, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Bar
            // 
            this.Bar.AutoSize = true;
            this.Bar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Bar.Controls.Add(this.button4);
            this.Bar.Controls.Add(this.button3);
            this.Bar.Controls.Add(this.l_version);
            this.Bar.Controls.Add(this.label1);
            this.Bar.Controls.Add(this.button2);
            this.Bar.Controls.Add(this.button5);
            this.Bar.Controls.Add(this.button1);
            this.Bar.Controls.Add(this.btn_minimize);
            this.Bar.Controls.Add(this.btn_exit);
            this.Bar.Controls.Add(this.Logo);
            this.Bar.Cursor = System.Windows.Forms.Cursors.Default;
            this.Bar.Dock = System.Windows.Forms.DockStyle.Top;
            this.Bar.Location = new System.Drawing.Point(0, 0);
            this.Bar.Name = "Bar";
            this.Bar.Size = new System.Drawing.Size(1246, 29);
            this.Bar.TabIndex = 2;
            this.Bar.Paint += new System.Windows.Forms.PaintEventHandler(this.Bar_Paint);
            this.Bar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(289, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(638, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_2);
            // 
            // l_version
            // 
            this.l_version.AutoSize = true;
            this.l_version.BackColor = System.Drawing.Color.Transparent;
            this.l_version.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.l_version.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_version.ForeColor = System.Drawing.Color.Lime;
            this.l_version.Location = new System.Drawing.Point(107, 5);
            this.l_version.Name = "l_version";
            this.l_version.Size = new System.Drawing.Size(53, 19);
            this.l_version.TabIndex = 10;
            this.l_version.Text = "v1.0.2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(61, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 19);
            this.label1.TabIndex = 9;
            this.label1.Text = "Gen";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(482, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_2);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(943, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 7;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btn_minimize
            // 
            this.btn_minimize.BackColor = System.Drawing.Color.Transparent;
            this.btn_minimize.BackgroundImage = global::SteamAccCreator.Properties.Resources.MINIMIZEBUTTON;
            this.btn_minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_minimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_minimize.Location = new System.Drawing.Point(1182, 0);
            this.btn_minimize.Name = "btn_minimize";
            this.btn_minimize.Size = new System.Drawing.Size(32, 29);
            this.btn_minimize.TabIndex = 4;
            this.btn_minimize.TabStop = false;
            this.btn_minimize.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_minimize_MouseClick);
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.Transparent;
            this.btn_exit.BackgroundImage = global::SteamAccCreator.Properties.Resources.EXITBUTTON;
            this.btn_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_exit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_exit.Location = new System.Drawing.Point(1214, 0);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(32, 29);
            this.btn_exit.TabIndex = 2;
            this.btn_exit.TabStop = false;
            this.btn_exit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_exit_MouseClick);
            // 
            // Logo
            // 
            this.Logo.BackColor = System.Drawing.Color.Transparent;
            this.Logo.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.Logo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Logo.Location = new System.Drawing.Point(3, 5);
            this.Logo.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(63, 19);
            this.Logo.TabIndex = 0;
            this.Logo.Text = "Lothos";
            // 
            // LeftBrowserWindow
            // 
            this.LeftBrowserWindow.AutoSize = true;
            this.LeftBrowserWindow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.LeftBrowserWindow.Location = new System.Drawing.Point(0, 29);
            this.LeftBrowserWindow.Name = "LeftBrowserWindow";
            this.LeftBrowserWindow.Size = new System.Drawing.Size(520, 625);
            this.LeftBrowserWindow.TabIndex = 3;
            this.LeftBrowserWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.BrowserWindow_Paint);
            // 
            // Key_Listen
            // 
            this.Key_Listen.Enabled = true;
            this.Key_Listen.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // Updater
            // 
            this.Updater.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // AdSpace
            // 
            this.AdSpace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.AdSpace.Controls.Add(this.pictureBox2);
            this.AdSpace.Controls.Add(this.pictureBox1);
            this.AdSpace.Location = new System.Drawing.Point(1246, 29);
            this.AdSpace.Name = "AdSpace";
            this.AdSpace.Size = new System.Drawing.Size(220, 625);
            this.AdSpace.TabIndex = 7;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::SteamAccCreator.Properties.Resources._8JIRYZc;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(0, 313);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(220, 312);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::SteamAccCreator.Properties.Resources._0_m_OPa661lY02bOWo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 312);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // RightBrowserWindow
            // 
            this.RightBrowserWindow.AutoSize = true;
            this.RightBrowserWindow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.RightBrowserWindow.Location = new System.Drawing.Point(519, 29);
            this.RightBrowserWindow.Name = "RightBrowserWindow";
            this.RightBrowserWindow.Size = new System.Drawing.Size(729, 625);
            this.RightBrowserWindow.TabIndex = 4;
            this.RightBrowserWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.RightBrowserWindow_Paint);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImage = global::SteamAccCreator.Properties.Resources.patreonLogo;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Location = new System.Drawing.Point(10, 8);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(40, 38);
            this.pictureBox4.TabIndex = 8;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox4_MouseClick);
            // 
            // l_verified
            // 
            this.l_verified.AutoSize = true;
            this.l_verified.BackColor = System.Drawing.Color.Transparent;
            this.l_verified.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_verified.ForeColor = System.Drawing.Color.Orange;
            this.l_verified.Location = new System.Drawing.Point(239, 16);
            this.l_verified.Name = "l_verified";
            this.l_verified.Size = new System.Drawing.Size(126, 25);
            this.l_verified.TabIndex = 152;
            this.l_verified.Text = "Not Checked";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label5.Location = new System.Drawing.Point(57, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 25);
            this.label5.TabIndex = 153;
            this.label5.Text = "Premium Member  - ";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = global::SteamAccCreator.Properties.Resources.discord_512;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Location = new System.Drawing.Point(1203, 9);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(40, 38);
            this.pictureBox3.TabIndex = 154;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click_1);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.BackgroundImage = global::SteamAccCreator.Properties.Resources.patreonWhite;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox5.Location = new System.Drawing.Point(1157, 9);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(40, 38);
            this.pictureBox5.TabIndex = 155;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.BackgroundImage = global::SteamAccCreator.Properties.Resources.logon;
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox6.Location = new System.Drawing.Point(1111, 9);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(40, 38);
            this.pictureBox6.TabIndex = 156;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "Bitch";
            this.notifyIcon1.Visible = true;
            // 
            // b_panel
            // 
            this.b_panel.Controls.Add(this.button6);
            this.b_panel.Controls.Add(this.pictureBox5);
            this.b_panel.Controls.Add(this.label5);
            this.b_panel.Controls.Add(this.l_verified);
            this.b_panel.Controls.Add(this.pictureBox6);
            this.b_panel.Controls.Add(this.pictureBox4);
            this.b_panel.Controls.Add(this.pictureBox3);
            this.b_panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.b_panel.Location = new System.Drawing.Point(0, 651);
            this.b_panel.Name = "b_panel";
            this.b_panel.Size = new System.Drawing.Size(1246, 53);
            this.b_panel.TabIndex = 157;
            this.b_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.b_panel_Paint);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(161)))), ((int)(((byte)(49)))));
            this.button6.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(161)))), ((int)(((byte)(49)))));
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(824, 11);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(274, 33);
            this.button6.TabIndex = 157;
            this.button6.Text = "Premium Member Benefits";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click_2);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1246, 704);
            this.Controls.Add(this.b_panel);
            this.Controls.Add(this.RightBrowserWindow);
            this.Controls.Add(this.AdSpace);
            this.Controls.Add(this.LeftBrowserWindow);
            this.Controls.Add(this.Bar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainUI";
            this.Text = "MainUI";
            this.Load += new System.EventHandler(this.MainUI_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainUI_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainUI_KeyPress);
            this.Bar.ResumeLayout(false);
            this.Bar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_minimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_exit)).EndInit();
            this.AdSpace.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.b_panel.ResumeLayout(false);
            this.b_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel LeftBrowserWindow;
        private System.Windows.Forms.Label Logo;
        private System.Windows.Forms.PictureBox btn_minimize;
        private System.Windows.Forms.PictureBox btn_exit;
        private System.Windows.Forms.Timer Key_Listen;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button2;
        private System.ComponentModel.BackgroundWorker Updater;
        private System.Windows.Forms.Panel AdSpace;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel RightBrowserWindow;
        public System.Windows.Forms.Panel Bar;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label l_verified;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label l_version;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Panel b_panel;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Timer timer1;
        //private System.Windows.Forms.Timer timer1;
    }
}