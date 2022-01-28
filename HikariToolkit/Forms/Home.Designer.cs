namespace Hikari_Android_Toolkit
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txt_DevicesAdb = new System.Windows.Forms.TextBox();
            this.tsb_AlwaysClearConsole = new System.Windows.Forms.ToolStripButton();
            this.tsb_AdbUnroot = new System.Windows.Forms.ToolStripButton();
            this.tsb_AdbRoot = new System.Windows.Forms.ToolStripButton();
            this.tsb_OpenShell = new System.Windows.Forms.ToolStripButton();
            this.tsb_KillServer = new System.Windows.Forms.ToolStripButton();
            this.tsm_WirelessDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_WirelessConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.tst_IpAdress = new System.Windows.Forms.ToolStripTextBox();
            this.tsd_WirelessAdb = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsc_ConnectedDevices = new System.Windows.Forms.ToolStripComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.cbx_DualAppsPackageUninstall = new System.Windows.Forms.ComboBox();
            this.btn_DualAppsUninstall = new System.Windows.Forms.Button();
            this.btn_DualAppsRefreshApps = new System.Windows.Forms.Button();
            this.btn_DualAppsInstall = new System.Windows.Forms.Button();
            this.txt_DualAppsPackageInstall = new System.Windows.Forms.TextBox();
            this.btn_DualAppsBrowse = new System.Windows.Forms.Button();
            this.rtb_console = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_DevicesAdb
            // 
            this.txt_DevicesAdb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_DevicesAdb.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DevicesAdb.Location = new System.Drawing.Point(266, -3);
            this.txt_DevicesAdb.Multiline = true;
            this.txt_DevicesAdb.Name = "txt_DevicesAdb";
            this.txt_DevicesAdb.ReadOnly = true;
            this.txt_DevicesAdb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_DevicesAdb.Size = new System.Drawing.Size(0, 86);
            this.txt_DevicesAdb.TabIndex = 30;
            // 
            // tsb_AlwaysClearConsole
            // 
            this.tsb_AlwaysClearConsole.AutoToolTip = false;
            this.tsb_AlwaysClearConsole.Checked = true;
            this.tsb_AlwaysClearConsole.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsb_AlwaysClearConsole.Image = global::AyraDualApps.Properties.Resources.eraser;
            this.tsb_AlwaysClearConsole.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_AlwaysClearConsole.Margin = new System.Windows.Forms.Padding(1, 1, 0, 2);
            this.tsb_AlwaysClearConsole.Name = "tsb_AlwaysClearConsole";
            this.tsb_AlwaysClearConsole.Size = new System.Drawing.Size(123, 20);
            this.tsb_AlwaysClearConsole.Text = "Alway Clear Console";
            this.tsb_AlwaysClearConsole.Click += new System.EventHandler(this.Tsb_AlwaysClearConsole_Click);
            // 
            // tsb_AdbUnroot
            // 
            this.tsb_AdbUnroot.AutoToolTip = false;
            this.tsb_AdbUnroot.Image = global::AyraDualApps.Properties.Resources.unroot;
            this.tsb_AdbUnroot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_AdbUnroot.Margin = new System.Windows.Forms.Padding(1, 1, 0, 2);
            this.tsb_AdbUnroot.Name = "tsb_AdbUnroot";
            this.tsb_AdbUnroot.Size = new System.Drawing.Size(84, 20);
            this.tsb_AdbUnroot.Text = "ADB Unroot";
            this.tsb_AdbUnroot.Click += new System.EventHandler(this.Tsb_AdbUnroot_Click);
            // 
            // tsb_AdbRoot
            // 
            this.tsb_AdbRoot.AutoToolTip = false;
            this.tsb_AdbRoot.Image = global::AyraDualApps.Properties.Resources.hash;
            this.tsb_AdbRoot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_AdbRoot.Margin = new System.Windows.Forms.Padding(1, 1, 0, 2);
            this.tsb_AdbRoot.Name = "tsb_AdbRoot";
            this.tsb_AdbRoot.Size = new System.Drawing.Size(75, 20);
            this.tsb_AdbRoot.Text = "ADB Root";
            this.tsb_AdbRoot.Click += new System.EventHandler(this.Tsb_AdbRoot_Click);
            // 
            // tsb_OpenShell
            // 
            this.tsb_OpenShell.AutoToolTip = false;
            this.tsb_OpenShell.Image = ((System.Drawing.Image)(resources.GetObject("tsb_OpenShell.Image")));
            this.tsb_OpenShell.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_OpenShell.Margin = new System.Windows.Forms.Padding(1, 1, 0, 2);
            this.tsb_OpenShell.Name = "tsb_OpenShell";
            this.tsb_OpenShell.Size = new System.Drawing.Size(79, 20);
            this.tsb_OpenShell.Text = "Open Shell";
            this.tsb_OpenShell.Click += new System.EventHandler(this.Tsb_OpenShell_Click);
            // 
            // tsb_KillServer
            // 
            this.tsb_KillServer.AutoToolTip = false;
            this.tsb_KillServer.Image = ((System.Drawing.Image)(resources.GetObject("tsb_KillServer.Image")));
            this.tsb_KillServer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_KillServer.Margin = new System.Windows.Forms.Padding(1, 1, 0, 2);
            this.tsb_KillServer.Name = "tsb_KillServer";
            this.tsb_KillServer.Size = new System.Drawing.Size(74, 20);
            this.tsb_KillServer.Text = "Kill Server";
            this.tsb_KillServer.Click += new System.EventHandler(this.Tsb_KillServer_Click);
            // 
            // tsm_WirelessDisconnect
            // 
            this.tsm_WirelessDisconnect.Name = "tsm_WirelessDisconnect";
            this.tsm_WirelessDisconnect.Size = new System.Drawing.Size(183, 22);
            this.tsm_WirelessDisconnect.Text = "Disconnect All";
            this.tsm_WirelessDisconnect.Click += new System.EventHandler(this.Tsm_WirelessDisconnect_Click);
            // 
            // tsm_WirelessConnect
            // 
            this.tsm_WirelessConnect.Name = "tsm_WirelessConnect";
            this.tsm_WirelessConnect.Size = new System.Drawing.Size(183, 22);
            this.tsm_WirelessConnect.Text = "Connect Device";
            this.tsm_WirelessConnect.Click += new System.EventHandler(this.Tsm_WirelessConnect_Click);
            // 
            // tst_IpAdress
            // 
            this.tst_IpAdress.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tst_IpAdress.Name = "tst_IpAdress";
            this.tst_IpAdress.Size = new System.Drawing.Size(123, 18);
            this.tst_IpAdress.Text = "192.168.0.44:5555";
            // 
            // tsd_WirelessAdb
            // 
            this.tsd_WirelessAdb.AutoToolTip = false;
            this.tsd_WirelessAdb.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tst_IpAdress,
            this.tsm_WirelessConnect,
            this.tsm_WirelessDisconnect});
            this.tsd_WirelessAdb.Image = global::AyraDualApps.Properties.Resources.wifi;
            this.tsd_WirelessAdb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsd_WirelessAdb.Margin = new System.Windows.Forms.Padding(1, 1, 0, 2);
            this.tsd_WirelessAdb.Name = "tsd_WirelessAdb";
            this.tsd_WirelessAdb.Size = new System.Drawing.Size(101, 20);
            this.tsd_WirelessAdb.Text = "Wireless ADB";
            this.tsd_WirelessAdb.Click += new System.EventHandler(this.tsd_WirelessAdb_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(107, 20);
            this.toolStripLabel1.Text = "Connected Devices: ";
            // 
            // tsc_ConnectedDevices
            // 
            this.tsc_ConnectedDevices.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsc_ConnectedDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tsc_ConnectedDevices.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.tsc_ConnectedDevices.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsc_ConnectedDevices.Name = "tsc_ConnectedDevices";
            this.tsc_ConnectedDevices.Size = new System.Drawing.Size(150, 23);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(418, 21);
            this.comboBox1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(459, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Uninstall";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsc_ConnectedDevices,
            this.toolStripLabel1,
            this.tsd_WirelessAdb,
            this.tsb_KillServer,
            this.tsb_OpenShell,
            this.tsb_AdbRoot,
            this.tsb_AdbUnroot,
            this.tsb_AlwaysClearConsole});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(12, 10, 11, 3);
            this.toolStrip1.Size = new System.Drawing.Size(564, 36);
            this.toolStrip1.TabIndex = 28;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackgroundImage = global::AyraDualApps.Properties.Resources.refresh;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Location = new System.Drawing.Point(430, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(23, 23);
            this.button2.TabIndex = 5;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboBox1);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Location = new System.Drawing.Point(12, 151);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(540, 51);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Uninstall";
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(6, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(183, 35);
            this.button3.TabIndex = 0;
            this.button3.Text = "Install SAI to dual apps";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Location = new System.Drawing.Point(12, 208);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(198, 63);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Inject";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // cbx_DualAppsPackageUninstall
            // 
            this.cbx_DualAppsPackageUninstall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_DualAppsPackageUninstall.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbx_DualAppsPackageUninstall.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_DualAppsPackageUninstall.FormattingEnabled = true;
            this.cbx_DualAppsPackageUninstall.Location = new System.Drawing.Point(6, 20);
            this.cbx_DualAppsPackageUninstall.Name = "cbx_DualAppsPackageUninstall";
            this.cbx_DualAppsPackageUninstall.Size = new System.Drawing.Size(418, 21);
            this.cbx_DualAppsPackageUninstall.TabIndex = 6;
            // 
            // btn_DualAppsUninstall
            // 
            this.btn_DualAppsUninstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_DualAppsUninstall.Location = new System.Drawing.Point(459, 19);
            this.btn_DualAppsUninstall.Name = "btn_DualAppsUninstall";
            this.btn_DualAppsUninstall.Size = new System.Drawing.Size(75, 23);
            this.btn_DualAppsUninstall.TabIndex = 5;
            this.btn_DualAppsUninstall.Text = "Clone";
            this.btn_DualAppsUninstall.UseVisualStyleBackColor = true;
            this.btn_DualAppsUninstall.Click += new System.EventHandler(this.btn_DualAppsUninstall_Click);
            // 
            // btn_DualAppsRefreshApps
            // 
            this.btn_DualAppsRefreshApps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_DualAppsRefreshApps.BackgroundImage = global::AyraDualApps.Properties.Resources.refresh;
            this.btn_DualAppsRefreshApps.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_DualAppsRefreshApps.Location = new System.Drawing.Point(430, 19);
            this.btn_DualAppsRefreshApps.Name = "btn_DualAppsRefreshApps";
            this.btn_DualAppsRefreshApps.Size = new System.Drawing.Size(23, 23);
            this.btn_DualAppsRefreshApps.TabIndex = 5;
            this.btn_DualAppsRefreshApps.UseVisualStyleBackColor = true;
            this.btn_DualAppsRefreshApps.Click += new System.EventHandler(this.btn_DualAppsRefreshApps_Click);
            // 
            // btn_DualAppsInstall
            // 
            this.btn_DualAppsInstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_DualAppsInstall.Location = new System.Drawing.Point(459, 19);
            this.btn_DualAppsInstall.Name = "btn_DualAppsInstall";
            this.btn_DualAppsInstall.Size = new System.Drawing.Size(75, 23);
            this.btn_DualAppsInstall.TabIndex = 2;
            this.btn_DualAppsInstall.Text = "Install";
            this.btn_DualAppsInstall.UseVisualStyleBackColor = true;
            this.btn_DualAppsInstall.Click += new System.EventHandler(this.btn_DualAppsInstall_Click);
            // 
            // txt_DualAppsPackageInstall
            // 
            this.txt_DualAppsPackageInstall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_DualAppsPackageInstall.Location = new System.Drawing.Point(6, 21);
            this.txt_DualAppsPackageInstall.Name = "txt_DualAppsPackageInstall";
            this.txt_DualAppsPackageInstall.Size = new System.Drawing.Size(366, 20);
            this.txt_DualAppsPackageInstall.TabIndex = 0;
            // 
            // btn_DualAppsBrowse
            // 
            this.btn_DualAppsBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_DualAppsBrowse.Location = new System.Drawing.Point(378, 19);
            this.btn_DualAppsBrowse.Name = "btn_DualAppsBrowse";
            this.btn_DualAppsBrowse.Size = new System.Drawing.Size(75, 23);
            this.btn_DualAppsBrowse.TabIndex = 1;
            this.btn_DualAppsBrowse.Text = "Browse...";
            this.btn_DualAppsBrowse.UseVisualStyleBackColor = true;
            this.btn_DualAppsBrowse.Click += new System.EventHandler(this.btn_DualAppsBrowse_Click);
            // 
            // rtb_console
            // 
            this.rtb_console.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_console.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb_console.HideSelection = false;
            this.rtb_console.Location = new System.Drawing.Point(12, 277);
            this.rtb_console.Name = "rtb_console";
            this.rtb_console.ReadOnly = true;
            this.rtb_console.Size = new System.Drawing.Size(540, 86);
            this.rtb_console.TabIndex = 29;
            this.rtb_console.Text = "";
            this.rtb_console.WordWrap = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbx_DualAppsPackageUninstall);
            this.groupBox1.Controls.Add(this.btn_DualAppsUninstall);
            this.groupBox1.Controls.Add(this.btn_DualAppsRefreshApps);
            this.groupBox1.Location = new System.Drawing.Point(12, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(540, 51);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Clone";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_DualAppsInstall);
            this.groupBox3.Controls.Add(this.txt_DualAppsPackageInstall);
            this.groupBox3.Controls.Add(this.btn_DualAppsBrowse);
            this.groupBox3.Location = new System.Drawing.Point(12, 39);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(540, 49);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Install to Dual Apps";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button6);
            this.groupBox5.Controls.Add(this.button5);
            this.groupBox5.Controls.Add(this.button4);
            this.groupBox5.Location = new System.Drawing.Point(216, 208);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(336, 63);
            this.groupBox5.TabIndex = 28;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "About";
            // 
            // button6
            // 
            this.button6.Enabled = false;
            this.button6.Location = new System.Drawing.Point(119, 19);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(98, 35);
            this.button6.TabIndex = 2;
            this.button6.Text = "Tips";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(223, 19);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(107, 35);
            this.button5.TabIndex = 1;
            this.button5.Text = "Source Code";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(107, 35);
            this.button4.TabIndex = 0;
            this.button4.Text = "Update";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 381);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.txt_DevicesAdb);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.rtb_console);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ayra\'s Dual Apps";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txt_DevicesAdb;
        internal System.Windows.Forms.ToolStripButton tsb_AlwaysClearConsole;
        private System.Windows.Forms.ToolStripButton tsb_AdbUnroot;
        private System.Windows.Forms.ToolStripButton tsb_AdbRoot;
        private System.Windows.Forms.ToolStripButton tsb_OpenShell;
        private System.Windows.Forms.ToolStripButton tsb_KillServer;
        private System.Windows.Forms.ToolStripMenuItem tsm_WirelessDisconnect;
        private System.Windows.Forms.ToolStripMenuItem tsm_WirelessConnect;
        private System.Windows.Forms.ToolStripTextBox tst_IpAdress;
        private System.Windows.Forms.ToolStripDropDownButton tsd_WirelessAdb;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        internal System.Windows.Forms.ToolStripComboBox tsc_ConnectedDevices;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ComboBox cbx_DualAppsPackageUninstall;
        private System.Windows.Forms.Button btn_DualAppsUninstall;
        private System.Windows.Forms.Button btn_DualAppsRefreshApps;
        private System.Windows.Forms.Button btn_DualAppsInstall;
        private System.Windows.Forms.TextBox txt_DualAppsPackageInstall;
        private System.Windows.Forms.Button btn_DualAppsBrowse;
        private System.Windows.Forms.RichTextBox rtb_console;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
    }
}