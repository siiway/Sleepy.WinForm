namespace Sleepy.WinForm
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tbURL = new TextBox();
            btnOffline = new Button();
            tbDelay = new TextBox();
            tbAPI = new TextBox();
            tbShowPassword = new Button();
            btnOnlineRequest = new Button();
            tbFakeAppName = new TextBox();
            cbOffline = new CheckBox();
            cbFakeApp = new CheckBox();
            tbDeviceID = new TextBox();
            tbDeviceName = new TextBox();
            btnOnlineRequestLoop = new Button();
            llConsole = new LinkLabel();
            label1 = new Label();
            menuStrip = new MenuStrip();
            toolStripMenuItemFile = new ToolStripMenuItem();
            saveConfigToolStripMenuItem = new ToolStripMenuItem();
            loadConfigToolStripMenuItem = new ToolStripMenuItem();
            restartToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            startNewToolStripMenuItem = new ToolStripMenuItem();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // tbURL
            // 
            tbURL.Location = new Point(25, 115);
            tbURL.Name = "tbURL";
            tbURL.PlaceholderText = "http://127.0.0.1:9010";
            tbURL.Size = new Size(492, 38);
            tbURL.TabIndex = 0;
            // 
            // btnOffline
            // 
            btnOffline.Location = new Point(1005, 279);
            btnOffline.Name = "btnOffline";
            btnOffline.Size = new Size(182, 96);
            btnOffline.TabIndex = 2;
            btnOffline.Text = "Offline";
            btnOffline.UseVisualStyleBackColor = true;
            btnOffline.Click += btnOffline_Click;
            // 
            // tbDelay
            // 
            tbDelay.Location = new Point(24, 169);
            tbDelay.Name = "tbDelay";
            tbDelay.PlaceholderText = "2 [milliseconds] [int only]";
            tbDelay.Size = new Size(493, 38);
            tbDelay.TabIndex = 4;
            tbDelay.KeyPress += tb_Delay_KeyPress;
            // 
            // tbAPI
            // 
            tbAPI.Location = new Point(24, 223);
            tbAPI.Name = "tbAPI";
            tbAPI.PasswordChar = '*';
            tbAPI.PlaceholderText = "API secret";
            tbAPI.Size = new Size(445, 38);
            tbAPI.TabIndex = 5;
            // 
            // tbShowPassword
            // 
            tbShowPassword.Font = new Font("Segoe Fluent Icons", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbShowPassword.Location = new Point(475, 220);
            tbShowPassword.Name = "tbShowPassword";
            tbShowPassword.Size = new Size(42, 38);
            tbShowPassword.TabIndex = 6;
            tbShowPassword.Text = "";
            tbShowPassword.UseVisualStyleBackColor = true;
            tbShowPassword.Click += button3_Click;
            // 
            // btnOnlineRequest
            // 
            btnOnlineRequest.Location = new Point(533, 278);
            btnOnlineRequest.Name = "btnOnlineRequest";
            btnOnlineRequest.Size = new Size(444, 97);
            btnOnlineRequest.TabIndex = 7;
            btnOnlineRequest.Text = "Send Online Request Once";
            btnOnlineRequest.UseVisualStyleBackColor = true;
            btnOnlineRequest.Click += btnOnlineRequest_Click;
            // 
            // tbFakeAppName
            // 
            tbFakeAppName.Location = new Point(533, 220);
            tbFakeAppName.Name = "tbFakeAppName";
            tbFakeAppName.PlaceholderText = "Ur fake application";
            tbFakeAppName.Size = new Size(444, 38);
            tbFakeAppName.TabIndex = 8;
            // 
            // cbOffline
            // 
            cbOffline.Location = new Point(1005, 52);
            cbOffline.Name = "cbOffline";
            cbOffline.Size = new Size(182, 210);
            cbOffline.TabIndex = 9;
            cbOffline.Text = "I'm really offline or my friends agree with these pranks.";
            cbOffline.UseCompatibleTextRendering = true;
            cbOffline.UseVisualStyleBackColor = true;
            // 
            // cbFakeApp
            // 
            cbFakeApp.Location = new Point(533, 163);
            cbFakeApp.Name = "cbFakeApp";
            cbFakeApp.Size = new Size(428, 44);
            cbFakeApp.TabIndex = 10;
            cbFakeApp.Text = "My friends are OK with this.";
            cbFakeApp.UseCompatibleTextRendering = true;
            cbFakeApp.UseVisualStyleBackColor = true;
            // 
            // tbDeviceID
            // 
            tbDeviceID.Location = new Point(533, 52);
            tbDeviceID.Name = "tbDeviceID";
            tbDeviceID.PlaceholderText = "DEVICE_ID";
            tbDeviceID.Size = new Size(444, 38);
            tbDeviceID.TabIndex = 11;
            // 
            // tbDeviceName
            // 
            tbDeviceName.Location = new Point(533, 106);
            tbDeviceName.Name = "tbDeviceName";
            tbDeviceName.PlaceholderText = "Device Name";
            tbDeviceName.Size = new Size(444, 38);
            tbDeviceName.TabIndex = 12;
            // 
            // btnOnlineRequestLoop
            // 
            btnOnlineRequestLoop.Location = new Point(25, 279);
            btnOnlineRequestLoop.Name = "btnOnlineRequestLoop";
            btnOnlineRequestLoop.Size = new Size(492, 97);
            btnOnlineRequestLoop.TabIndex = 13;
            btnOnlineRequestLoop.Text = "[START/STOP]\r\nSend Online Request Loop";
            btnOnlineRequestLoop.UseVisualStyleBackColor = true;
            btnOnlineRequestLoop.Click += btnOnlineRequestLoop_Click;
            // 
            // llConsole
            // 
            llConsole.AutoSize = true;
            llConsole.Location = new Point(411, 81);
            llConsole.Name = "llConsole";
            llConsole.Size = new Size(106, 31);
            llConsole.TabIndex = 14;
            llConsole.TabStop = true;
            llConsole.Text = "Console";
            llConsole.LinkClicked += llConsole_LinkClicked;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cascadia Code", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 39);
            label1.Name = "label1";
            label1.Size = new Size(419, 63);
            label1.TabIndex = 1;
            label1.Text = "Sleepy.WinForm";
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(32, 32);
            menuStrip.Items.AddRange(new ToolStripItem[] { toolStripMenuItemFile });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1209, 39);
            menuStrip.TabIndex = 15;
            menuStrip.Text = "Main Menu";
            // 
            // toolStripMenuItemFile
            // 
            toolStripMenuItemFile.DropDownItems.AddRange(new ToolStripItem[] { saveConfigToolStripMenuItem, loadConfigToolStripMenuItem, restartToolStripMenuItem, exitToolStripMenuItem, startNewToolStripMenuItem });
            toolStripMenuItemFile.Name = "toolStripMenuItemFile";
            toolStripMenuItemFile.Size = new Size(73, 35);
            toolStripMenuItemFile.Text = "File";
            // 
            // saveConfigToolStripMenuItem
            // 
            saveConfigToolStripMenuItem.Name = "saveConfigToolStripMenuItem";
            saveConfigToolStripMenuItem.Size = new Size(359, 44);
            saveConfigToolStripMenuItem.Text = "Save config...";
            saveConfigToolStripMenuItem.Click += saveConfigToolStripMenuItem_Click;
            // 
            // loadConfigToolStripMenuItem
            // 
            loadConfigToolStripMenuItem.Name = "loadConfigToolStripMenuItem";
            loadConfigToolStripMenuItem.Size = new Size(359, 44);
            loadConfigToolStripMenuItem.Text = "Load config...";
            loadConfigToolStripMenuItem.Click += loadConfigToolStripMenuItem_Click;
            // 
            // restartToolStripMenuItem
            // 
            restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            restartToolStripMenuItem.Size = new Size(359, 44);
            restartToolStripMenuItem.Text = "Restart";
            restartToolStripMenuItem.Click += restartToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(359, 44);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // startNewToolStripMenuItem
            // 
            startNewToolStripMenuItem.Name = "startNewToolStripMenuItem";
            startNewToolStripMenuItem.Size = new Size(359, 44);
            startNewToolStripMenuItem.Text = "Start new instance";
            startNewToolStripMenuItem.Click += startNewToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1209, 403);
            Controls.Add(llConsole);
            Controls.Add(btnOnlineRequestLoop);
            Controls.Add(tbDeviceName);
            Controls.Add(tbDeviceID);
            Controls.Add(cbFakeApp);
            Controls.Add(cbOffline);
            Controls.Add(tbFakeAppName);
            Controls.Add(btnOnlineRequest);
            Controls.Add(tbShowPassword);
            Controls.Add(tbAPI);
            Controls.Add(tbDelay);
            Controls.Add(btnOffline);
            Controls.Add(label1);
            Controls.Add(tbURL);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "MainForm";
            Text = "Sleepy WinForm Client";
            FormClosing += MainForm_FormClosing;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbURL;
        private Button btnOffline;
        private TextBox tbDelay;
        private TextBox tbAPI;
        private Button tbShowPassword;
        private Button btnOnlineRequest;
        private TextBox tbFakeAppName;
        private CheckBox cbOffline;
        private CheckBox cbFakeApp;
        private TextBox tbDeviceID;
        private TextBox tbDeviceName;
        private Button btnOnlineRequestLoop;
        private LinkLabel llConsole;
        private Label label1;
        private MenuStrip menuStrip;
        private ToolStripMenuItem toolStripMenuItemFile;
        private ToolStripMenuItem saveConfigToolStripMenuItem;
        private ToolStripMenuItem loadConfigToolStripMenuItem;
        private ToolStripMenuItem restartToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem startNewToolStripMenuItem;
    }
}
