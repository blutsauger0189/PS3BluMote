namespace PS3BluMote
{
    partial class MouseSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MouseSettingsForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonDump = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMinutes = new System.Windows.Forms.TextBox();
            this.txtRepeatInterval = new System.Windows.Forms.TextBox();
            this.lblRepeatInterval = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.llblOpenFolder = new System.Windows.Forms.LinkLabel();
            this.cbDebugMode = new System.Windows.Forms.CheckBox();
            this.gbAdvanced = new System.Windows.Forms.GroupBox();
            this.comboBtAddr = new System.Windows.Forms.ComboBox();
            this.lblBtAddr = new System.Windows.Forms.Label();
            this.lblRemoteCodes = new System.Windows.Forms.Label();
            this.txtVendorId = new System.Windows.Forms.TextBox();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.lblVendorId = new System.Windows.Forms.Label();
            this.lblProductId = new System.Windows.Forms.Label();
            this.cbHibernation = new System.Windows.Forms.CheckBox();
            this.cbSms = new System.Windows.Forms.CheckBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuNotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mitemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.gbAdvanced.SuspendLayout();
            this.menuNotifyIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabSettings);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 512);
            this.tabControl.TabIndex = 2;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.label2);
            this.tabSettings.Controls.Add(this.buttonDump);
            this.tabSettings.Controls.Add(this.label1);
            this.tabSettings.Controls.Add(this.txtMinutes);
            this.tabSettings.Controls.Add(this.txtRepeatInterval);
            this.tabSettings.Controls.Add(this.lblRepeatInterval);
            this.tabSettings.Controls.Add(this.lblCopyright);
            this.tabSettings.Controls.Add(this.llblOpenFolder);
            this.tabSettings.Controls.Add(this.cbDebugMode);
            this.tabSettings.Controls.Add(this.gbAdvanced);
            this.tabSettings.Controls.Add(this.cbHibernation);
            this.tabSettings.Controls.Add(this.cbSms);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(10);
            this.tabSettings.Size = new System.Drawing.Size(792, 486);
            this.tabSettings.TabIndex = 1;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Hibernate the remote after";
            // 
            // buttonDump
            // 
            this.buttonDump.Location = new System.Drawing.Point(316, 79);
            this.buttonDump.Name = "buttonDump";
            this.buttonDump.Size = new System.Drawing.Size(75, 23);
            this.buttonDump.TabIndex = 11;
            this.buttonDump.Text = "Dump";
            this.buttonDump.UseVisualStyleBackColor = true;
            this.buttonDump.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "minutes without any key press.";
            // 
            // txtMinutes
            // 
            this.txtMinutes.Location = new System.Drawing.Point(166, 57);
            this.txtMinutes.Name = "txtMinutes";
            this.txtMinutes.Size = new System.Drawing.Size(30, 20);
            this.txtMinutes.TabIndex = 9;
            this.txtMinutes.Text = "3";
            this.txtMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtRepeatInterval
            // 
            this.txtRepeatInterval.Location = new System.Drawing.Point(160, 128);
            this.txtRepeatInterval.Name = "txtRepeatInterval";
            this.txtRepeatInterval.Size = new System.Drawing.Size(95, 20);
            this.txtRepeatInterval.TabIndex = 7;
            this.txtRepeatInterval.Text = "100";
            // 
            // lblRepeatInterval
            // 
            this.lblRepeatInterval.AutoSize = true;
            this.lblRepeatInterval.Location = new System.Drawing.Point(10, 131);
            this.lblRepeatInterval.Name = "lblRepeatInterval";
            this.lblRepeatInterval.Size = new System.Drawing.Size(144, 13);
            this.lblRepeatInterval.TabIndex = 6;
            this.lblRepeatInterval.Text = "Button repeat interval (in ms):";
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Location = new System.Drawing.Point(10, 420);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(149, 39);
            this.lblCopyright.TabIndex = 5;
            this.lblCopyright.Text = "PS3BluMote v2.1.\r\nCopyright © Ben Barron 2012.\r\nHibernation by Miljbee";
            // 
            // llblOpenFolder
            // 
            this.llblOpenFolder.AutoSize = true;
            this.llblOpenFolder.Location = new System.Drawing.Point(190, 84);
            this.llblOpenFolder.Name = "llblOpenFolder";
            this.llblOpenFolder.Size = new System.Drawing.Size(120, 13);
            this.llblOpenFolder.TabIndex = 4;
            this.llblOpenFolder.TabStop = true;
            this.llblOpenFolder.Text = "Open log/settings folder";
            this.llblOpenFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.llblOpenFolder.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // cbDebugMode
            // 
            this.cbDebugMode.AutoSize = true;
            this.cbDebugMode.Location = new System.Drawing.Point(13, 83);
            this.cbDebugMode.Name = "cbDebugMode";
            this.cbDebugMode.Size = new System.Drawing.Size(171, 17);
            this.cbDebugMode.TabIndex = 3;
            this.cbDebugMode.Text = "Debug mode (logging enabled)";
            this.cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // gbAdvanced
            // 
            this.gbAdvanced.Controls.Add(this.comboBtAddr);
            this.gbAdvanced.Controls.Add(this.lblBtAddr);
            this.gbAdvanced.Controls.Add(this.lblRemoteCodes);
            this.gbAdvanced.Controls.Add(this.txtVendorId);
            this.gbAdvanced.Controls.Add(this.txtProductId);
            this.gbAdvanced.Controls.Add(this.lblVendorId);
            this.gbAdvanced.Controls.Add(this.lblProductId);
            this.gbAdvanced.Location = new System.Drawing.Point(9, 169);
            this.gbAdvanced.Name = "gbAdvanced";
            this.gbAdvanced.Padding = new System.Windows.Forms.Padding(6);
            this.gbAdvanced.Size = new System.Drawing.Size(258, 237);
            this.gbAdvanced.TabIndex = 2;
            this.gbAdvanced.TabStop = false;
            this.gbAdvanced.Text = "Advanced";
            // 
            // comboBtAddr
            // 
            this.comboBtAddr.FormattingEnabled = true;
            this.comboBtAddr.Items.AddRange(new object[] {
            "Searching ..."});
            this.comboBtAddr.Location = new System.Drawing.Point(97, 79);
            this.comboBtAddr.Name = "comboBtAddr";
            this.comboBtAddr.Size = new System.Drawing.Size(121, 21);
            this.comboBtAddr.TabIndex = 13;
            this.comboBtAddr.Text = "Searching ...";
            // 
            // lblBtAddr
            // 
            this.lblBtAddr.AutoSize = true;
            this.lblBtAddr.Location = new System.Drawing.Point(9, 82);
            this.lblBtAddr.Name = "lblBtAddr";
            this.lblBtAddr.Size = new System.Drawing.Size(65, 13);
            this.lblBtAddr.TabIndex = 4;
            this.lblBtAddr.Text = "BT Address:";
            // 
            // lblRemoteCodes
            // 
            this.lblRemoteCodes.AutoSize = true;
            this.lblRemoteCodes.Location = new System.Drawing.Point(9, 127);
            this.lblRemoteCodes.Name = "lblRemoteCodes";
            this.lblRemoteCodes.Size = new System.Drawing.Size(239, 104);
            this.lblRemoteCodes.TabIndex = 3;
            this.lblRemoteCodes.Text = resources.GetString("lblRemoteCodes.Text");
            // 
            // txtVendorId
            // 
            this.txtVendorId.Location = new System.Drawing.Point(99, 51);
            this.txtVendorId.Name = "txtVendorId";
            this.txtVendorId.Size = new System.Drawing.Size(119, 20);
            this.txtVendorId.TabIndex = 3;
            this.txtVendorId.Text = "0x054c";
            // 
            // txtProductId
            // 
            this.txtProductId.Location = new System.Drawing.Point(99, 22);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(119, 20);
            this.txtProductId.TabIndex = 2;
            this.txtProductId.Text = "0x0306";
            // 
            // lblVendorId
            // 
            this.lblVendorId.AutoSize = true;
            this.lblVendorId.Location = new System.Drawing.Point(9, 54);
            this.lblVendorId.Name = "lblVendorId";
            this.lblVendorId.Size = new System.Drawing.Size(58, 13);
            this.lblVendorId.TabIndex = 1;
            this.lblVendorId.Text = "Vendor ID:";
            // 
            // lblProductId
            // 
            this.lblProductId.AutoSize = true;
            this.lblProductId.Location = new System.Drawing.Point(9, 25);
            this.lblProductId.Name = "lblProductId";
            this.lblProductId.Size = new System.Drawing.Size(61, 13);
            this.lblProductId.TabIndex = 0;
            this.lblProductId.Text = "Product ID:";
            // 
            // cbHibernation
            // 
            this.cbHibernation.AutoSize = true;
            this.cbHibernation.Enabled = false;
            this.cbHibernation.Location = new System.Drawing.Point(13, 36);
            this.cbHibernation.Name = "cbHibernation";
            this.cbHibernation.Size = new System.Drawing.Size(175, 17);
            this.cbHibernation.TabIndex = 1;
            this.cbHibernation.Text = "Hibernation - to save battery life";
            this.cbHibernation.UseVisualStyleBackColor = true;
            // 
            // cbSms
            // 
            this.cbSms.AutoSize = true;
            this.cbSms.Location = new System.Drawing.Point(13, 13);
            this.cbSms.Name = "cbSms";
            this.cbSms.Size = new System.Drawing.Size(95, 17);
            this.cbSms.TabIndex = 0;
            this.cbSms.Text = "SMS text input";
            this.cbSms.UseVisualStyleBackColor = true;
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.menuNotifyIcon;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "PS3BluMote: Disconnected.";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // menuNotifyIcon
            // 
            this.menuNotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitemSettings,
            this.mitemExit});
            this.menuNotifyIcon.Name = "menuNotifyIcon";
            this.menuNotifyIcon.Size = new System.Drawing.Size(117, 48);
            // 
            // mitemSettings
            // 
            this.mitemSettings.Name = "mitemSettings";
            this.mitemSettings.Size = new System.Drawing.Size(116, 22);
            this.mitemSettings.Text = "Settings";
            // 
            // mitemExit
            // 
            this.mitemExit.Name = "mitemExit";
            this.mitemExit.Size = new System.Drawing.Size(116, 22);
            this.mitemExit.Text = "Exit";
            // 
            // MouseSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 512);
            this.Controls.Add(this.tabControl);
            this.Name = "MouseSettingsForm";
            this.Text = "MouseSettingsForm";
            this.tabControl.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.tabSettings.PerformLayout();
            this.gbAdvanced.ResumeLayout(false);
            this.gbAdvanced.PerformLayout();
            this.menuNotifyIcon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonDump;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMinutes;
        private System.Windows.Forms.TextBox txtRepeatInterval;
        private System.Windows.Forms.Label lblRepeatInterval;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.LinkLabel llblOpenFolder;
        private System.Windows.Forms.CheckBox cbDebugMode;
        private System.Windows.Forms.GroupBox gbAdvanced;
        private System.Windows.Forms.ComboBox comboBtAddr;
        private System.Windows.Forms.Label lblBtAddr;
        private System.Windows.Forms.Label lblRemoteCodes;
        private System.Windows.Forms.TextBox txtVendorId;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.Label lblVendorId;
        private System.Windows.Forms.Label lblProductId;
        private System.Windows.Forms.CheckBox cbHibernation;
        private System.Windows.Forms.CheckBox cbSms;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip menuNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem mitemSettings;
        private System.Windows.Forms.ToolStripMenuItem mitemExit;
    }
}