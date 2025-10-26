//----------------------------------------------------------------------------------------------------------------
// <copyright file="MainForm.Designer.cs" company="MarcusMedinapro">
// Copyright (c) MarcusMedinaPro. All rights reserved.
// </copyright>
//----------------------------------------------------------------------------------------------------------------
// This file is subject to the terms and conditions defined in file 'license.txt', which is part of this project.
// For more information visit http://MarcusMedina.Pro
//----------------------------------------------------------------------------------------------------------------

namespace TopWinPrio;

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
            if (disposing)
            {
                components?.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timerTopWindowCheck = new System.Windows.Forms.Timer(this.components);
            this.closeButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.allTabs = new System.Windows.Forms.TabControl();
            this.prioList = new System.Windows.Forms.TabPage();
            this.logList = new System.Windows.Forms.ListView();
            this.clmTime = new System.Windows.Forms.ColumnHeader();
            this.clmWindow = new System.Windows.Forms.ColumnHeader();
            this.infoLabel = new System.Windows.Forms.Label();
            this.logoPic = new System.Windows.Forms.PictureBox();
            this.boostSettings = new System.Windows.Forms.TabPage();
            this.boostFrame = new System.Windows.Forms.GroupBox();
            this.inactiveList = new System.Windows.Forms.ComboBox();
            this.inactiveLabel = new System.Windows.Forms.Label();
            this.activeList = new System.Windows.Forms.ComboBox();
            this.activeLabel = new System.Windows.Forms.Label();
            this.timerSlider = new System.Windows.Forms.HScrollBar();
            this.refreshLabel = new System.Windows.Forms.Label();
            this.boostExplorerOption = new System.Windows.Forms.CheckBox();
            this.settingsInfoText = new System.Windows.Forms.Label();
            this.toolsPic = new System.Windows.Forms.PictureBox();
            this.applicationSettings = new System.Windows.Forms.TabPage();
            this.applicationFrame = new System.Windows.Forms.GroupBox();
            this.applicationPriorityList = new System.Windows.Forms.ComboBox();
            this.applicationPriorityLabel = new System.Windows.Forms.Label();
            this.startHiddenOption = new System.Windows.Forms.CheckBox();
            this.startBalloonOption = new System.Windows.Forms.CheckBox();
            this.showPopupOption = new System.Windows.Forms.CheckBox();
            this.autostartOption = new System.Windows.Forms.CheckBox();
            this.applicationInfo = new System.Windows.Forms.Label();
            this.settingsPic = new System.Windows.Forms.PictureBox();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.allTabs.SuspendLayout();
            this.prioList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPic)).BeginInit();
            this.boostSettings.SuspendLayout();
            this.boostFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toolsPic)).BeginInit();
            this.applicationSettings.SuspendLayout();
            this.applicationFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settingsPic)).BeginInit();
            this.SuspendLayout();
            //
            // timerTopWindowCheck
            //
            this.timerTopWindowCheck.Enabled = true;
            this.timerTopWindowCheck.Interval = 1000;
            this.timerTopWindowCheck.Tick += new System.EventHandler(this.TimerTopWindowCheck_Tick);
            //
            // closeButton
            //
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(231, 370);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "&Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.BtnClose_Click);
            //
            // exitButton
            //
            this.exitButton.Location = new System.Drawing.Point(4, 370);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 0;
            this.exitButton.Text = "&Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.BtnExit_Click);
            //
            // allTabs
            //
            this.allTabs.Controls.Add(this.prioList);
            this.allTabs.Controls.Add(this.boostSettings);
            this.allTabs.Controls.Add(this.applicationSettings);
            this.allTabs.Dock = System.Windows.Forms.DockStyle.Top;
            this.allTabs.Location = new System.Drawing.Point(0, 0);
            this.allTabs.Name = "allTabs";
            this.allTabs.SelectedIndex = 0;
            this.allTabs.Size = new System.Drawing.Size(310, 364);
            this.allTabs.TabIndex = 0;
            //
            // prioList
            //
            this.prioList.Controls.Add(this.logList);
            this.prioList.Controls.Add(this.infoLabel);
            this.prioList.Controls.Add(this.logoPic);
            this.prioList.Location = new System.Drawing.Point(4, 22);
            this.prioList.Name = "prioList";
            this.prioList.Padding = new System.Windows.Forms.Padding(3);
            this.prioList.Size = new System.Drawing.Size(302, 338);
            this.prioList.TabIndex = 0;
            this.prioList.Text = "prioList";
            this.prioList.UseVisualStyleBackColor = true;
            //
            // logList
            //
            this.logList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmTime,
            this.clmWindow});
            this.logList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logList.Location = new System.Drawing.Point(3, 80);
            this.logList.Name = "logList";
            this.logList.Size = new System.Drawing.Size(296, 255);
            this.logList.TabIndex = 0;
            this.logList.UseCompatibleStateImageBehavior = false;
            this.logList.View = System.Windows.Forms.View.Details;
            //
            // clmTime
            //
            this.clmTime.Text = "Time";
            this.clmTime.Width = 48;
            //
            // clmWindow
            //
            this.clmWindow.Text = "Window title";
            this.clmWindow.Width = 242;
            //
            // infoLabel
            //
            this.infoLabel.Location = new System.Drawing.Point(77, 16);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(217, 49);
            this.infoLabel.TabIndex = 0;
            this.infoLabel.Text = "List of applications boosted with higher prio, when having focus.";
            //
            // logoPic
            //
            this.logoPic.Image = global::TopWinPrio.Properties.Resources.GameIcon;
            this.logoPic.Location = new System.Drawing.Point(8, 16);
            this.logoPic.Name = "logoPic";
            this.logoPic.Size = new System.Drawing.Size(64, 64);
            this.logoPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.logoPic.TabIndex = 0;
            this.logoPic.TabStop = false;
            //
            // boostSettings
            //
            this.boostSettings.Controls.Add(this.boostFrame);
            this.boostSettings.Controls.Add(this.settingsInfoText);
            this.boostSettings.Controls.Add(this.toolsPic);
            this.boostSettings.Location = new System.Drawing.Point(4, 22);
            this.boostSettings.Name = "boostSettings";
            this.boostSettings.Padding = new System.Windows.Forms.Padding(3);
            this.boostSettings.Size = new System.Drawing.Size(302, 338);
            this.boostSettings.TabIndex = 1;
            this.boostSettings.Text = "Boost settings";
            this.boostSettings.UseVisualStyleBackColor = true;
            //
            // boostFrame
            //
            this.boostFrame.Controls.Add(this.inactiveList);
            this.boostFrame.Controls.Add(this.inactiveLabel);
            this.boostFrame.Controls.Add(this.activeList);
            this.boostFrame.Controls.Add(this.activeLabel);
            this.boostFrame.Controls.Add(this.timerSlider);
            this.boostFrame.Controls.Add(this.refreshLabel);
            this.boostFrame.Controls.Add(this.boostExplorerOption);
            this.boostFrame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boostFrame.Location = new System.Drawing.Point(9, 87);
            this.boostFrame.Name = "boostFrame";
            this.boostFrame.Size = new System.Drawing.Size(285, 245);
            this.boostFrame.TabIndex = 1;
            this.boostFrame.TabStop = false;
            this.boostFrame.Text = "Boost settings";
            //
            // inactiveList
            //
            this.inactiveList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inactiveList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inactiveList.FormattingEnabled = true;
            this.inactiveList.Items.AddRange(new object[] {
            "Default",
            "Normal",
            "BelowNormal",
            "Idle (not a good idea)"});
            this.inactiveList.Location = new System.Drawing.Point(134, 95);
            this.inactiveList.Name = "inactiveList";
            this.inactiveList.Size = new System.Drawing.Size(143, 21);
            this.inactiveList.TabIndex = 6;
            //
            // inactiveLabel
            //
            this.inactiveLabel.AutoSize = true;
            this.inactiveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inactiveLabel.Location = new System.Drawing.Point(3, 98);
            this.inactiveLabel.Name = "inactiveLabel";
            this.inactiveLabel.Size = new System.Drawing.Size(125, 13);
            this.inactiveLabel.TabIndex = 5;
            this.inactiveLabel.Text = "Force inactive window to";
            //
            // activeList
            //
            this.activeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.activeList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activeList.FormattingEnabled = true;
            this.activeList.Items.AddRange(new object[] {
            "AboveNormal",
            "High",
            "RealTime (dangerous)"});
            this.activeList.Location = new System.Drawing.Point(134, 68);
            this.activeList.Name = "activeList";
            this.activeList.Size = new System.Drawing.Size(143, 21);
            this.activeList.TabIndex = 4;
            //
            // activeLabel
            //
            this.activeLabel.AutoSize = true;
            this.activeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activeLabel.Location = new System.Drawing.Point(3, 71);
            this.activeLabel.Name = "activeLabel";
            this.activeLabel.Size = new System.Drawing.Size(106, 13);
            this.activeLabel.TabIndex = 3;
            this.activeLabel.Text = "Set active window to";
            //
            // timerSlider
            //
            this.timerSlider.Location = new System.Drawing.Point(119, 39);
            this.timerSlider.Maximum = 69;
            this.timerSlider.Minimum = 1;
            this.timerSlider.Name = "timerSlider";
            this.timerSlider.Size = new System.Drawing.Size(163, 17);
            this.timerSlider.TabIndex = 2;
            this.timerSlider.TabStop = true;
            this.timerSlider.Value = 1;
            this.timerSlider.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HsbTimer_Scroll);
            //
            // refreshLabel
            //
            this.refreshLabel.AutoSize = true;
            this.refreshLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshLabel.Location = new System.Drawing.Point(3, 43);
            this.refreshLabel.Name = "refreshLabel";
            this.refreshLabel.Size = new System.Drawing.Size(110, 13);
            this.refreshLabel.TabIndex = 1;
            this.refreshLabel.Text = "Refresh every 5 secs.";
            //
            // boostExplorerOption
            //
            this.boostExplorerOption.AutoSize = true;
            this.boostExplorerOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boostExplorerOption.Location = new System.Drawing.Point(6, 19);
            this.boostExplorerOption.Name = "boostExplorerOption";
            this.boostExplorerOption.Size = new System.Drawing.Size(93, 17);
            this.boostExplorerOption.TabIndex = 0;
            this.boostExplorerOption.Text = "Boost explorer";
            this.boostExplorerOption.UseVisualStyleBackColor = true;
            //
            // settingsInfoText
            //
            this.settingsInfoText.Location = new System.Drawing.Point(77, 16);
            this.settingsInfoText.Name = "settingsInfoText";
            this.settingsInfoText.Size = new System.Drawing.Size(194, 64);
            this.settingsInfoText.TabIndex = 0;
            this.settingsInfoText.Text = "Boost settings:\r\nHere you can configure \r\nhow the program will boost \r\nyour appli" +
    "cations.\r\n";
            //
            // toolsPic
            //
            this.toolsPic.Image = global::TopWinPrio.Properties.Resources.ThemeSettingsIcon;
            this.toolsPic.Location = new System.Drawing.Point(8, 16);
            this.toolsPic.Name = "toolsPic";
            this.toolsPic.Size = new System.Drawing.Size(64, 64);
            this.toolsPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.toolsPic.TabIndex = 2;
            this.toolsPic.TabStop = false;
            //
            // applicationSettings
            //
            this.applicationSettings.Controls.Add(this.applicationFrame);
            this.applicationSettings.Controls.Add(this.applicationInfo);
            this.applicationSettings.Controls.Add(this.settingsPic);
            this.applicationSettings.Location = new System.Drawing.Point(4, 22);
            this.applicationSettings.Name = "applicationSettings";
            this.applicationSettings.Size = new System.Drawing.Size(302, 338);
            this.applicationSettings.TabIndex = 2;
            this.applicationSettings.Text = "Application settings";
            this.applicationSettings.UseVisualStyleBackColor = true;
            //
            // applicationFrame
            //
            this.applicationFrame.Controls.Add(this.applicationPriorityList);
            this.applicationFrame.Controls.Add(this.applicationPriorityLabel);
            this.applicationFrame.Controls.Add(this.startHiddenOption);
            this.applicationFrame.Controls.Add(this.startBalloonOption);
            this.applicationFrame.Controls.Add(this.showPopupOption);
            this.applicationFrame.Controls.Add(this.autostartOption);
            this.applicationFrame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applicationFrame.Location = new System.Drawing.Point(9, 88);
            this.applicationFrame.Name = "applicationFrame";
            this.applicationFrame.Size = new System.Drawing.Size(285, 231);
            this.applicationFrame.TabIndex = 1;
            this.applicationFrame.TabStop = false;
            this.applicationFrame.Text = "Application settings";
            //
            // applicationPriorityList
            //
            this.applicationPriorityList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.applicationPriorityList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applicationPriorityList.FormattingEnabled = true;
            this.applicationPriorityList.Items.AddRange(new object[] {
            "Normal",
            "BelowNormal"});
            this.applicationPriorityList.Location = new System.Drawing.Point(136, 109);
            this.applicationPriorityList.Name = "applicationPriorityList";
            this.applicationPriorityList.Size = new System.Drawing.Size(143, 21);
            this.applicationPriorityList.TabIndex = 8;
            //
            // applicationPriorityLabel
            //
            this.applicationPriorityLabel.AutoSize = true;
            this.applicationPriorityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applicationPriorityLabel.Location = new System.Drawing.Point(5, 112);
            this.applicationPriorityLabel.Name = "applicationPriorityLabel";
            this.applicationPriorityLabel.Size = new System.Drawing.Size(92, 13);
            this.applicationPriorityLabel.TabIndex = 7;
            this.applicationPriorityLabel.Text = "Application priority";
            //
            // startHiddenOption
            //
            this.startHiddenOption.AutoSize = true;
            this.startHiddenOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startHiddenOption.Location = new System.Drawing.Point(6, 42);
            this.startHiddenOption.Name = "startHiddenOption";
            this.startHiddenOption.Size = new System.Drawing.Size(83, 17);
            this.startHiddenOption.TabIndex = 1;
            this.startHiddenOption.Text = "Start hidden";
            this.startHiddenOption.UseVisualStyleBackColor = true;
            //
            // startBalloonOption
            //
            this.startBalloonOption.AutoSize = true;
            this.startBalloonOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startBalloonOption.Location = new System.Drawing.Point(22, 65);
            this.startBalloonOption.Name = "startBalloonOption";
            this.startBalloonOption.Size = new System.Drawing.Size(125, 17);
            this.startBalloonOption.TabIndex = 2;
            this.startBalloonOption.Text = "Show balloon at start";
            this.startBalloonOption.UseVisualStyleBackColor = true;
            //
            // showPopupOption
            //
            this.showPopupOption.AutoSize = true;
            this.showPopupOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showPopupOption.Location = new System.Drawing.Point(6, 88);
            this.showPopupOption.Name = "showPopupOption";
            this.showPopupOption.Size = new System.Drawing.Size(154, 17);
            this.showPopupOption.TabIndex = 3;
            this.showPopupOption.Text = "Show balloon when hidden";
            this.showPopupOption.UseVisualStyleBackColor = true;
            //
            // autostartOption
            //
            this.autostartOption.AutoSize = true;
            this.autostartOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autostartOption.Location = new System.Drawing.Point(6, 18);
            this.autostartOption.Name = "autostartOption";
            this.autostartOption.Size = new System.Drawing.Size(114, 17);
            this.autostartOption.TabIndex = 0;
            this.autostartOption.Text = "Start with windows";
            this.autostartOption.UseVisualStyleBackColor = true;
            this.autostartOption.CheckedChanged += new System.EventHandler(this.ChkAutostart_CheckedChanged);
            //
            // applicationInfo
            //
            this.applicationInfo.Location = new System.Drawing.Point(77, 16);
            this.applicationInfo.Name = "applicationInfo";
            this.applicationInfo.Size = new System.Drawing.Size(194, 64);
            this.applicationInfo.TabIndex = 0;
            this.applicationInfo.Text = "Application settings:\r\nHere you can configure \r\nhow the program will behave.";
            //
            // settingsPic
            //
            this.settingsPic.Image = global::TopWinPrio.Properties.Resources.SettingsIcon;
            this.settingsPic.Location = new System.Drawing.Point(8, 16);
            this.settingsPic.Name = "settingsPic";
            this.settingsPic.Size = new System.Drawing.Size(64, 64);
            this.settingsPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.settingsPic.TabIndex = 6;
            this.settingsPic.TabStop = false;
            //
            // trayIcon
            //
            this.trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "MarcusMedinaPro (formerly LunaWorX.net) TopWinPrio";
            this.trayIcon.Visible = true;
            this.trayIcon.BalloonTipClicked += new System.EventHandler(this.TrayIcon_BalloonTipClicked);
            this.trayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseClick);
            //
            // checkBox5
            //
            this.checkBox5.AutoSize = true;
            this.checkBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox5.Location = new System.Drawing.Point(137, 19);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(83, 17);
            this.checkBox5.TabIndex = 9;
            this.checkBox5.Text = "Start hidden";
            this.checkBox5.UseVisualStyleBackColor = true;
            //
            // checkBox6
            //
            this.checkBox6.AutoSize = true;
            this.checkBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox6.Location = new System.Drawing.Point(137, 38);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(125, 17);
            this.checkBox6.TabIndex = 8;
            this.checkBox6.Text = "Show balloon at start";
            this.checkBox6.UseVisualStyleBackColor = true;
            //
            // checkBox7
            //
            this.checkBox7.AutoSize = true;
            this.checkBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox7.Location = new System.Drawing.Point(6, 38);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(154, 17);
            this.checkBox7.TabIndex = 7;
            this.checkBox7.Text = "Show balloon when hidden";
            this.checkBox7.UseVisualStyleBackColor = true;
            //
            // checkBox8
            //
            this.checkBox8.AutoSize = true;
            this.checkBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox8.Location = new System.Drawing.Point(7, 19);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(114, 17);
            this.checkBox8.TabIndex = 6;
            this.checkBox8.Text = "Start with windows";
            this.checkBox8.UseVisualStyleBackColor = true;
            //
            // comboBox1
            //
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Default",
            "Normal",
            "BelowNormal",
            "Idle (not a good idea)"});
            this.comboBox1.Location = new System.Drawing.Point(134, 95);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(143, 21);
            this.comboBox1.TabIndex = 11;
            //
            // label5
            //
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Force inactive window to";
            //
            // comboBox2
            //
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "AboveNormal",
            "High",
            "RealTime (dangerous)"});
            this.comboBox2.Location = new System.Drawing.Point(134, 68);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(143, 21);
            this.comboBox2.TabIndex = 9;
            //
            // label6
            //
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Set active window to";
            //
            // hScrollBar1
            //
            this.hScrollBar1.Location = new System.Drawing.Point(119, 39);
            this.hScrollBar1.Maximum = 69;
            this.hScrollBar1.Minimum = 1;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(163, 17);
            this.hScrollBar1.TabIndex = 7;
            this.hScrollBar1.Value = 1;
            //
            // label7
            //
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Refresh every 5 secs.";
            //
            // checkBox9
            //
            this.checkBox9.AutoSize = true;
            this.checkBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox9.Location = new System.Drawing.Point(6, 19);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(93, 17);
            this.checkBox9.TabIndex = 5;
            this.checkBox9.Text = "Boost explorer";
            this.checkBox9.UseVisualStyleBackColor = true;
            //
            // MainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(310, 396);
            this.ControlBox = false;
            this.Controls.Add(this.allTabs);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.closeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MainForm";
            this.Text = "MarcusMedinaPro (formerly LunaWorX.net) TopWinPrio";
            this.Activated += new System.EventHandler(this.FrmPrio_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPrio_FormClosed);
            this.Load += new System.EventHandler(this.FrmPrio_Load);
            this.allTabs.ResumeLayout(false);
            this.prioList.ResumeLayout(false);
            this.prioList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPic)).EndInit();
            this.boostSettings.ResumeLayout(false);
            this.boostSettings.PerformLayout();
            this.boostFrame.ResumeLayout(false);
            this.boostFrame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toolsPic)).EndInit();
            this.applicationSettings.ResumeLayout(false);
            this.applicationSettings.PerformLayout();
            this.applicationFrame.ResumeLayout(false);
            this.applicationFrame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settingsPic)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label activeLabel;
        private System.Windows.Forms.ComboBox activeList;
        private System.Windows.Forms.TabControl allTabs;
        private System.Windows.Forms.GroupBox applicationFrame;
        private System.Windows.Forms.Label applicationInfo;
        private System.Windows.Forms.Label applicationPriorityLabel;
        private System.Windows.Forms.ComboBox applicationPriorityList;
        private System.Windows.Forms.TabPage applicationSettings;
        private System.Windows.Forms.CheckBox autostartOption;
        private System.Windows.Forms.CheckBox boostExplorerOption;
        private System.Windows.Forms.GroupBox boostFrame;
        private System.Windows.Forms.TabPage boostSettings;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.ColumnHeader clmTime;
        private System.Windows.Forms.ColumnHeader clmWindow;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Label inactiveLabel;
        private System.Windows.Forms.ComboBox inactiveList;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView logList;
        private System.Windows.Forms.PictureBox logoPic;
        private System.Windows.Forms.TabPage prioList;
        private System.Windows.Forms.Label refreshLabel;
        private System.Windows.Forms.Label settingsInfoText;
        private System.Windows.Forms.PictureBox settingsPic;
        private System.Windows.Forms.CheckBox showPopupOption;
        private System.Windows.Forms.CheckBox startBalloonOption;
        private System.Windows.Forms.CheckBox startHiddenOption;
        private System.Windows.Forms.HScrollBar timerSlider;
        private System.Windows.Forms.Timer timerTopWindowCheck;
        private System.Windows.Forms.PictureBox toolsPic;
        private System.Windows.Forms.NotifyIcon trayIcon;
    }
