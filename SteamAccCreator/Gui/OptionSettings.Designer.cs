namespace SteamAccCreator.Gui
{
    partial class OptionSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionSettings));
            this.Bar = new System.Windows.Forms.Panel();
            this.btn_minimize = new System.Windows.Forms.PictureBox();
            this.btn_exit = new System.Windows.Forms.PictureBox();
            this.Logo = new System.Windows.Forms.Label();
            this.ground = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.b_games = new System.Windows.Forms.Button();
            this.l_game = new System.Windows.Forms.Label();
            this.cb_games = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cb_AutoUpdate = new System.Windows.Forms.ComboBox();
            this.btn_emailAdd = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.l_email = new System.Windows.Forms.Label();
            this.cb_email = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.AccountsPerProxy = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.cooldown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.ThreadsUse = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.accountsGen = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_proxy = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.txtCaptchaSolutionsKey = new System.Windows.Forms.TextBox();
            this.txt2Captchakey = new System.Windows.Forms.TextBox();
            this.Updater = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Bar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_minimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_exit)).BeginInit();
            this.ground.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AccountsPerProxy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cooldown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThreadsUse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountsGen)).BeginInit();
            this.SuspendLayout();
            // 
            // Bar
            // 
            this.Bar.AutoSize = true;
            this.Bar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Bar.Controls.Add(this.btn_minimize);
            this.Bar.Controls.Add(this.btn_exit);
            this.Bar.Controls.Add(this.Logo);
            this.Bar.Dock = System.Windows.Forms.DockStyle.Top;
            this.Bar.Location = new System.Drawing.Point(0, 0);
            this.Bar.Name = "Bar";
            this.Bar.Size = new System.Drawing.Size(931, 24);
            this.Bar.TabIndex = 126;
            this.Bar.Paint += new System.Windows.Forms.PaintEventHandler(this.Bar_Paint);
            this.Bar.MouseLeave += new System.EventHandler(this.Bar_MouseLeave);
            this.Bar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Bar_MouseMove);
            // 
            // btn_minimize
            // 
            this.btn_minimize.BackgroundImage = global::SteamAccCreator.Properties.Resources.MINIMIZEBUTTON;
            this.btn_minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_minimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_minimize.Location = new System.Drawing.Point(867, 0);
            this.btn_minimize.Name = "btn_minimize";
            this.btn_minimize.Size = new System.Drawing.Size(32, 24);
            this.btn_minimize.TabIndex = 4;
            this.btn_minimize.TabStop = false;
            this.btn_minimize.Click += new System.EventHandler(this.btn_minimize_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.BackgroundImage = global::SteamAccCreator.Properties.Resources.EXITBUTTON;
            this.btn_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_exit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_exit.Location = new System.Drawing.Point(899, 0);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(32, 24);
            this.btn_exit.TabIndex = 2;
            this.btn_exit.TabStop = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // Logo
            // 
            this.Logo.AutoSize = true;
            this.Logo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(167)))), ((int)(((byte)(168)))));
            this.Logo.Location = new System.Drawing.Point(3, 5);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(225, 19);
            this.Logo.TabIndex = 0;
            this.Logo.Text = "LothosGen - Option Settings";
            // 
            // ground
            // 
            this.ground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(161)))), ((int)(((byte)(49)))));
            this.ground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ground.Controls.Add(this.panel1);
            this.ground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ground.Location = new System.Drawing.Point(0, 24);
            this.ground.Name = "ground";
            this.ground.Size = new System.Drawing.Size(931, 546);
            this.ground.TabIndex = 127;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel1.Controls.Add(this.b_games);
            this.panel1.Controls.Add(this.l_game);
            this.panel1.Controls.Add(this.cb_games);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cb_AutoUpdate);
            this.panel1.Controls.Add(this.btn_emailAdd);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.l_email);
            this.panel1.Controls.Add(this.cb_email);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.AccountsPerProxy);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cooldown);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.ThreadsUse);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.accountsGen);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cb_proxy);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Controls.Add(this.txtCaptchaSolutionsKey);
            this.panel1.Controls.Add(this.txt2Captchakey);
            this.panel1.Location = new System.Drawing.Point(3, -22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(923, 563);
            this.panel1.TabIndex = 128;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // b_games
            // 
            this.b_games.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(161)))), ((int)(((byte)(49)))));
            this.b_games.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(161)))), ((int)(((byte)(49)))));
            this.b_games.FlatAppearance.BorderSize = 0;
            this.b_games.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_games.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_games.ForeColor = System.Drawing.Color.White;
            this.b_games.Location = new System.Drawing.Point(309, 509);
            this.b_games.Name = "b_games";
            this.b_games.Size = new System.Drawing.Size(39, 33);
            this.b_games.TabIndex = 159;
            this.b_games.Text = "+";
            this.b_games.UseVisualStyleBackColor = false;
            this.b_games.Click += new System.EventHandler(this.b_games_Click);
            // 
            // l_game
            // 
            this.l_game.AutoSize = true;
            this.l_game.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_game.ForeColor = System.Drawing.Color.White;
            this.l_game.Location = new System.Drawing.Point(360, 512);
            this.l_game.Name = "l_game";
            this.l_game.Size = new System.Drawing.Size(75, 25);
            this.l_game.TabIndex = 158;
            this.l_game.Text = "Games";
            // 
            // cb_games
            // 
            this.cb_games.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.cb_games.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_games.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_games.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(161)))), ((int)(((byte)(49)))));
            this.cb_games.FormattingEnabled = true;
            this.cb_games.Location = new System.Drawing.Point(17, 509);
            this.cb_games.Name = "cb_games";
            this.cb_games.Size = new System.Drawing.Size(272, 33);
            this.cb_games.TabIndex = 157;
            this.cb_games.SelectedIndexChanged += new System.EventHandler(this.cb_games_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(774, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 25);
            this.label8.TabIndex = 156;
            this.label8.Text = "Auto Update";
            // 
            // cb_AutoUpdate
            // 
            this.cb_AutoUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.cb_AutoUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_AutoUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_AutoUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(161)))), ((int)(((byte)(49)))));
            this.cb_AutoUpdate.FormattingEnabled = true;
            this.cb_AutoUpdate.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cb_AutoUpdate.Location = new System.Drawing.Point(641, 39);
            this.cb_AutoUpdate.Name = "cb_AutoUpdate";
            this.cb_AutoUpdate.Size = new System.Drawing.Size(127, 33);
            this.cb_AutoUpdate.TabIndex = 155;
            this.cb_AutoUpdate.SelectedIndexChanged += new System.EventHandler(this.cb_AutoUpdate_SelectedIndexChanged);
            // 
            // btn_emailAdd
            // 
            this.btn_emailAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(161)))), ((int)(((byte)(49)))));
            this.btn_emailAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(161)))), ((int)(((byte)(49)))));
            this.btn_emailAdd.FlatAppearance.BorderSize = 0;
            this.btn_emailAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_emailAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_emailAdd.ForeColor = System.Drawing.Color.White;
            this.btn_emailAdd.Location = new System.Drawing.Point(309, 102);
            this.btn_emailAdd.Name = "btn_emailAdd";
            this.btn_emailAdd.Size = new System.Drawing.Size(39, 33);
            this.btn_emailAdd.TabIndex = 154;
            this.btn_emailAdd.Text = "+";
            this.btn_emailAdd.UseVisualStyleBackColor = false;
            this.btn_emailAdd.Visible = false;
            this.btn_emailAdd.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(161)))), ((int)(((byte)(49)))));
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(161)))), ((int)(((byte)(49)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(657, 463);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 33);
            this.button3.TabIndex = 153;
            this.button3.Text = "Load";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // l_email
            // 
            this.l_email.AutoSize = true;
            this.l_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_email.ForeColor = System.Drawing.Color.White;
            this.l_email.Location = new System.Drawing.Point(360, 104);
            this.l_email.Name = "l_email";
            this.l_email.Size = new System.Drawing.Size(131, 25);
            this.l_email.TabIndex = 152;
            this.l_email.Text = "Email Service";
            // 
            // cb_email
            // 
            this.cb_email.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.cb_email.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_email.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(161)))), ((int)(((byte)(49)))));
            this.cb_email.FormattingEnabled = true;
            this.cb_email.Location = new System.Drawing.Point(17, 101);
            this.cb_email.Name = "cb_email";
            this.cb_email.Size = new System.Drawing.Size(272, 33);
            this.cb_email.TabIndex = 151;
            this.cb_email.SelectedIndexChanged += new System.EventHandler(this.cb_email_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(304, 337);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(184, 25);
            this.label7.TabIndex = 150;
            this.label7.Text = "Accounts Per Proxy";
            this.label7.Visible = false;
            // 
            // AccountsPerProxy
            // 
            this.AccountsPerProxy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.AccountsPerProxy.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountsPerProxy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(161)))), ((int)(((byte)(49)))));
            this.AccountsPerProxy.Location = new System.Drawing.Point(17, 337);
            this.AccountsPerProxy.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.AccountsPerProxy.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AccountsPerProxy.Name = "AccountsPerProxy";
            this.AccountsPerProxy.Size = new System.Drawing.Size(272, 30);
            this.AccountsPerProxy.TabIndex = 149;
            this.AccountsPerProxy.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AccountsPerProxy.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(304, 455);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 25);
            this.label6.TabIndex = 148;
            this.label6.Text = "Cooldown";
            // 
            // cooldown
            // 
            this.cooldown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.cooldown.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cooldown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(161)))), ((int)(((byte)(49)))));
            this.cooldown.Location = new System.Drawing.Point(17, 455);
            this.cooldown.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.cooldown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cooldown.Name = "cooldown";
            this.cooldown.Size = new System.Drawing.Size(272, 30);
            this.cooldown.TabIndex = 147;
            this.cooldown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(304, 396);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 25);
            this.label5.TabIndex = 146;
            this.label5.Text = "Threads";
            // 
            // ThreadsUse
            // 
            this.ThreadsUse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.ThreadsUse.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThreadsUse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(161)))), ((int)(((byte)(49)))));
            this.ThreadsUse.Location = new System.Drawing.Point(17, 396);
            this.ThreadsUse.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ThreadsUse.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ThreadsUse.Name = "ThreadsUse";
            this.ThreadsUse.Size = new System.Drawing.Size(272, 30);
            this.ThreadsUse.TabIndex = 145;
            this.ThreadsUse.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(304, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 25);
            this.label4.TabIndex = 144;
            this.label4.Text = "Accounts To Create";
            // 
            // accountsGen
            // 
            this.accountsGen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.accountsGen.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountsGen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(161)))), ((int)(((byte)(49)))));
            this.accountsGen.Location = new System.Drawing.Point(17, 42);
            this.accountsGen.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.accountsGen.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.accountsGen.Name = "accountsGen";
            this.accountsGen.Size = new System.Drawing.Size(272, 30);
            this.accountsGen.TabIndex = 143;
            this.accountsGen.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(161)))), ((int)(((byte)(49)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(161)))), ((int)(((byte)(49)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(309, 278);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(39, 33);
            this.button2.TabIndex = 142;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(360, 281);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 25);
            this.label3.TabIndex = 141;
            this.label3.Text = "Proxy";
            // 
            // cb_proxy
            // 
            this.cb_proxy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.cb_proxy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_proxy.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_proxy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(161)))), ((int)(((byte)(49)))));
            this.cb_proxy.FormattingEnabled = true;
            this.cb_proxy.Location = new System.Drawing.Point(17, 278);
            this.cb_proxy.Name = "cb_proxy";
            this.cb_proxy.Size = new System.Drawing.Size(272, 33);
            this.cb_proxy.TabIndex = 140;
            this.cb_proxy.SelectedIndexChanged += new System.EventHandler(this.cb_proxy_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(-19, -18);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 139;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(161)))), ((int)(((byte)(49)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(161)))), ((int)(((byte)(49)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(657, 512);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 33);
            this.button1.TabIndex = 137;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(304, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 25);
            this.label2.TabIndex = 136;
            this.label2.Text = "Captcha Guru API KEY";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(304, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 25);
            this.label1.TabIndex = 135;
            this.label1.Text = "2Captcha API KEY";
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(161)))), ((int)(((byte)(49)))));
            this.btnConfirm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(161)))), ((int)(((byte)(49)))));
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(793, 512);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(102, 33);
            this.btnConfirm.TabIndex = 134;
            this.btnConfirm.Text = "Update";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // txtCaptchaSolutionsKey
            // 
            this.txtCaptchaSolutionsKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.txtCaptchaSolutionsKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCaptchaSolutionsKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCaptchaSolutionsKey.ForeColor = System.Drawing.Color.White;
            this.txtCaptchaSolutionsKey.Location = new System.Drawing.Point(17, 219);
            this.txtCaptchaSolutionsKey.Name = "txtCaptchaSolutionsKey";
            this.txtCaptchaSolutionsKey.Size = new System.Drawing.Size(272, 30);
            this.txtCaptchaSolutionsKey.TabIndex = 133;
            this.txtCaptchaSolutionsKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt2Captchakey
            // 
            this.txt2Captchakey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.txt2Captchakey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt2Captchakey.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt2Captchakey.ForeColor = System.Drawing.Color.White;
            this.txt2Captchakey.Location = new System.Drawing.Point(17, 160);
            this.txt2Captchakey.Name = "txt2Captchakey";
            this.txt2Captchakey.Size = new System.Drawing.Size(272, 30);
            this.txt2Captchakey.TabIndex = 132;
            this.txt2Captchakey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Updater
            // 
            this.Updater.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Updater_DoWork);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // OptionSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(931, 570);
            this.Controls.Add(this.ground);
            this.Controls.Add(this.Bar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OptionSettings";
            this.Text = "OptionSettings";
            this.Load += new System.EventHandler(this.OptionSettings_Load);
            this.Bar.ResumeLayout(false);
            this.Bar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_minimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_exit)).EndInit();
            this.ground.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AccountsPerProxy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cooldown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThreadsUse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountsGen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Bar;
        private System.Windows.Forms.PictureBox btn_minimize;
        private System.Windows.Forms.PictureBox btn_exit;
        private System.Windows.Forms.Label Logo;
        private System.Windows.Forms.Panel ground;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtCaptchaSolutionsKey;
        private System.Windows.Forms.TextBox txt2Captchakey;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_proxy;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.ComponentModel.BackgroundWorker Updater;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown ThreadsUse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown accountsGen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown cooldown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown AccountsPerProxy;
        private System.Windows.Forms.Label l_email;
        private System.Windows.Forms.ComboBox cb_email;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btn_emailAdd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cb_AutoUpdate;
        private System.Windows.Forms.Button b_games;
        private System.Windows.Forms.Label l_game;
        private System.Windows.Forms.ComboBox cb_games;
        private System.Windows.Forms.Timer timer1;
    }
}