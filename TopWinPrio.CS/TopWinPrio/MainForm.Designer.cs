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
        components = new System.ComponentModel.Container();
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        timerTopWindowCheck = new Timer(components);
        closeButton = new Button();
        exitButton = new Button();
        allTabs = new TabControl();
        prioList = new TabPage();
        logList = new ListView();
        clmTime = new ColumnHeader();
        clmWindow = new ColumnHeader();
        infoLabel = new Label();
        logoPic = new PictureBox();
        boostSettings = new TabPage();
        boostFrame = new GroupBox();
        inactiveList = new ComboBox();
        inactiveLabel = new Label();
        activeList = new ComboBox();
        activeLabel = new Label();
        timerSlider = new HScrollBar();
        refreshLabel = new Label();
        boostExplorerOption = new CheckBox();
        settingsInfoText = new Label();
        toolsPic = new PictureBox();
        applicationSettings = new TabPage();
        applicationFrame = new GroupBox();
        applicationPriorityList = new ComboBox();
        applicationPriorityLabel = new Label();
        startHiddenOption = new CheckBox();
        startBalloonOption = new CheckBox();
        showPopupOption = new CheckBox();
        autostartOption = new CheckBox();
        applicationInfo = new Label();
        settingsPic = new PictureBox();
        trayIcon = new NotifyIcon(components);
        checkBox5 = new CheckBox();
        checkBox6 = new CheckBox();
        checkBox7 = new CheckBox();
        checkBox8 = new CheckBox();
        comboBox1 = new ComboBox();
        label5 = new Label();
        comboBox2 = new ComboBox();
        label6 = new Label();
        hScrollBar1 = new HScrollBar();
        label7 = new Label();
        checkBox9 = new CheckBox();
        allTabs.SuspendLayout();
        prioList.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)logoPic).BeginInit();
        boostSettings.SuspendLayout();
        boostFrame.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)toolsPic).BeginInit();
        applicationSettings.SuspendLayout();
        applicationFrame.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)settingsPic).BeginInit();
        SuspendLayout();
        // 
        // timerTopWindowCheck
        // 
        timerTopWindowCheck.Enabled = true;
        timerTopWindowCheck.Interval = 1000;
        timerTopWindowCheck.Tick += TimerTopWindowCheck_Tick;
        // 
        // closeButton
        // 
        closeButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        closeButton.DialogResult = DialogResult.Cancel;
        closeButton.Location = new Point(305, 576);
        closeButton.Margin = new Padding(4, 5, 4, 5);
        closeButton.Name = "closeButton";
        closeButton.Size = new Size(100, 35);
        closeButton.TabIndex = 0;
        closeButton.Text = "&Close";
        closeButton.UseVisualStyleBackColor = true;
        closeButton.Click += BtnClose_Click;
        // 
        // exitButton
        // 
        exitButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        exitButton.Location = new Point(0, 576);
        exitButton.Margin = new Padding(4, 5, 4, 5);
        exitButton.Name = "exitButton";
        exitButton.Size = new Size(100, 35);
        exitButton.TabIndex = 0;
        exitButton.Text = "&Exit";
        exitButton.UseVisualStyleBackColor = true;
        exitButton.Click += BtnExit_Click;
        // 
        // allTabs
        // 
        allTabs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        allTabs.Controls.Add(prioList);
        allTabs.Controls.Add(boostSettings);
        allTabs.Controls.Add(applicationSettings);
        allTabs.Location = new Point(0, 0);
        allTabs.Margin = new Padding(4, 5, 4, 5);
        allTabs.Name = "allTabs";
        allTabs.SelectedIndex = 0;
        allTabs.Size = new Size(413, 559);
        allTabs.TabIndex = 0;
        // 
        // prioList
        // 
        prioList.Controls.Add(logList);
        prioList.Controls.Add(infoLabel);
        prioList.Controls.Add(logoPic);
        prioList.Location = new Point(4, 29);
        prioList.Margin = new Padding(4, 5, 4, 5);
        prioList.Name = "prioList";
        prioList.Padding = new Padding(4, 5, 4, 5);
        prioList.Size = new Size(405, 526);
        prioList.TabIndex = 0;
        prioList.Text = "prioList";
        prioList.UseVisualStyleBackColor = true;
        // 
        // logList
        // 
        logList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        logList.Columns.AddRange(new ColumnHeader[] { clmTime, clmWindow });
        logList.Location = new Point(4, 105);
        logList.Margin = new Padding(4, 5, 4, 5);
        logList.Name = "logList";
        logList.Size = new Size(397, 432);
        logList.TabIndex = 0;
        logList.UseCompatibleStateImageBehavior = false;
        logList.View = View.Details;
        // 
        // clmTime
        // 
        clmTime.Text = "Time";
        clmTime.Width = 48;
        // 
        // clmWindow
        // 
        clmWindow.Text = "Window title";
        clmWindow.Width = 242;
        // 
        // infoLabel
        // 
        infoLabel.Location = new Point(103, 25);
        infoLabel.Margin = new Padding(4, 0, 4, 0);
        infoLabel.Name = "infoLabel";
        infoLabel.Size = new Size(289, 75);
        infoLabel.TabIndex = 0;
        infoLabel.Text = "List of applications boosted with higher prio, when having focus.";
        // 
        // logoPic
        // 
        logoPic.Image = (Image)resources.GetObject("logoPic.Image");
        logoPic.Location = new Point(11, 25);
        logoPic.Margin = new Padding(4, 5, 4, 5);
        logoPic.Name = "logoPic";
        logoPic.Size = new Size(64, 64);
        logoPic.SizeMode = PictureBoxSizeMode.AutoSize;
        logoPic.TabIndex = 0;
        logoPic.TabStop = false;
        // 
        // boostSettings
        // 
        boostSettings.Controls.Add(boostFrame);
        boostSettings.Controls.Add(settingsInfoText);
        boostSettings.Controls.Add(toolsPic);
        boostSettings.Location = new Point(4, 29);
        boostSettings.Margin = new Padding(4, 5, 4, 5);
        boostSettings.Name = "boostSettings";
        boostSettings.Padding = new Padding(4, 5, 4, 5);
        boostSettings.Size = new Size(405, 526);
        boostSettings.TabIndex = 1;
        boostSettings.Text = "Boost settings";
        boostSettings.UseVisualStyleBackColor = true;
        // 
        // boostFrame
        // 
        boostFrame.Controls.Add(inactiveList);
        boostFrame.Controls.Add(inactiveLabel);
        boostFrame.Controls.Add(activeList);
        boostFrame.Controls.Add(activeLabel);
        boostFrame.Controls.Add(timerSlider);
        boostFrame.Controls.Add(refreshLabel);
        boostFrame.Controls.Add(boostExplorerOption);
        boostFrame.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        boostFrame.Location = new Point(12, 134);
        boostFrame.Margin = new Padding(4, 5, 4, 5);
        boostFrame.Name = "boostFrame";
        boostFrame.Padding = new Padding(4, 5, 4, 5);
        boostFrame.Size = new Size(380, 377);
        boostFrame.TabIndex = 1;
        boostFrame.TabStop = false;
        boostFrame.Text = "Boost settings";
        boostFrame.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        // 
        // inactiveList
        // 
        inactiveList.DropDownStyle = ComboBoxStyle.DropDownList;
        inactiveList.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        inactiveList.FormattingEnabled = true;
        inactiveList.Items.AddRange(new object[] { "Default", "Normal", "BelowNormal", "Idle (not a good idea)" });
        inactiveList.Location = new Point(179, 146);
        inactiveList.Margin = new Padding(4, 5, 4, 5);
        inactiveList.Name = "inactiveList";
        inactiveList.Size = new Size(189, 25);
        inactiveList.TabIndex = 6;
        // 
        // inactiveLabel
        // 
        inactiveLabel.AutoSize = true;
        inactiveLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        inactiveLabel.Location = new Point(4, 151);
        inactiveLabel.Margin = new Padding(4, 0, 4, 0);
        inactiveLabel.Name = "inactiveLabel";
        inactiveLabel.Size = new Size(161, 17);
        inactiveLabel.TabIndex = 5;
        inactiveLabel.Text = "Force inactive window to";
        // 
        // activeList
        // 
        activeList.DropDownStyle = ComboBoxStyle.DropDownList;
        activeList.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        activeList.FormattingEnabled = true;
        activeList.Items.AddRange(new object[] { "AboveNormal", "High", "RealTime (dangerous)" });
        activeList.Location = new Point(179, 105);
        activeList.Margin = new Padding(4, 5, 4, 5);
        activeList.Name = "activeList";
        activeList.Size = new Size(189, 25);
        activeList.TabIndex = 4;
        // 
        // activeLabel
        // 
        activeLabel.AutoSize = true;
        activeLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        activeLabel.Location = new Point(4, 109);
        activeLabel.Margin = new Padding(4, 0, 4, 0);
        activeLabel.Name = "activeLabel";
        activeLabel.Size = new Size(135, 17);
        activeLabel.TabIndex = 3;
        activeLabel.Text = "Set active window to";
        // 
        // timerSlider
        // 
        timerSlider.Location = new Point(159, 60);
        timerSlider.Maximum = 69;
        timerSlider.Minimum = 1;
        timerSlider.Name = "timerSlider";
        timerSlider.Size = new Size(217, 23);
        timerSlider.TabIndex = 2;
        timerSlider.TabStop = true;
        timerSlider.Value = 1;
        timerSlider.Scroll += HsbTimer_Scroll;
        // 
        // refreshLabel
        // 
        refreshLabel.AutoSize = true;
        refreshLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        refreshLabel.Location = new Point(4, 66);
        refreshLabel.Margin = new Padding(4, 0, 4, 0);
        refreshLabel.Name = "refreshLabel";
        refreshLabel.Size = new Size(146, 17);
        refreshLabel.TabIndex = 1;
        refreshLabel.Text = "Refresh every 5 secs.";
        // 
        // boostExplorerOption
        // 
        boostExplorerOption.AutoSize = true;
        boostExplorerOption.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        boostExplorerOption.Location = new Point(8, 29);
        boostExplorerOption.Margin = new Padding(4, 5, 4, 5);
        boostExplorerOption.Name = "boostExplorerOption";
        boostExplorerOption.Size = new Size(121, 21);
        boostExplorerOption.TabIndex = 0;
        boostExplorerOption.Text = "Boost explorer";
        boostExplorerOption.UseVisualStyleBackColor = true;
        // 
        // settingsInfoText
        // 
        settingsInfoText.Location = new Point(103, 25);
        settingsInfoText.Margin = new Padding(4, 0, 4, 0);
        settingsInfoText.Name = "settingsInfoText";
        settingsInfoText.Size = new Size(259, 98);
        settingsInfoText.TabIndex = 0;
        settingsInfoText.Text = "Boost settings:\r\nHere you can configure \r\nhow the program will boost \r\nyour applications.\r\n";
        // 
        // toolsPic
        // 
        toolsPic.Image = (Image)resources.GetObject("toolsPic.Image");
        toolsPic.Location = new Point(11, 25);
        toolsPic.Margin = new Padding(4, 5, 4, 5);
        toolsPic.Name = "toolsPic";
        toolsPic.Size = new Size(64, 64);
        toolsPic.SizeMode = PictureBoxSizeMode.AutoSize;
        toolsPic.TabIndex = 2;
        toolsPic.TabStop = false;
        // 
        // applicationSettings
        // 
        applicationSettings.Controls.Add(applicationFrame);
        applicationSettings.Controls.Add(applicationInfo);
        applicationSettings.Controls.Add(settingsPic);
        applicationSettings.Location = new Point(4, 29);
        applicationSettings.Margin = new Padding(4, 5, 4, 5);
        applicationSettings.Name = "applicationSettings";
        applicationSettings.Size = new Size(405, 526);
        applicationSettings.TabIndex = 2;
        applicationSettings.Text = "Application settings";
        applicationSettings.UseVisualStyleBackColor = true;
        // 
        // applicationFrame
        // 
        applicationFrame.Controls.Add(applicationPriorityList);
        applicationFrame.Controls.Add(applicationPriorityLabel);
        applicationFrame.Controls.Add(startHiddenOption);
        applicationFrame.Controls.Add(startBalloonOption);
        applicationFrame.Controls.Add(showPopupOption);
        applicationFrame.Controls.Add(autostartOption);
        applicationFrame.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        applicationFrame.Location = new Point(12, 135);
        applicationFrame.Margin = new Padding(4, 5, 4, 5);
        applicationFrame.Name = "applicationFrame";
        applicationFrame.Padding = new Padding(4, 5, 4, 5);
        applicationFrame.Size = new Size(380, 355);
        applicationFrame.TabIndex = 1;
        applicationFrame.TabStop = false;
        applicationFrame.Text = "Application settings";
        applicationFrame.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        // 
        // applicationPriorityList
        // 
        applicationPriorityList.DropDownStyle = ComboBoxStyle.DropDownList;
        applicationPriorityList.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        applicationPriorityList.FormattingEnabled = true;
        applicationPriorityList.Items.AddRange(new object[] { "Normal", "BelowNormal" });
        applicationPriorityList.Location = new Point(181, 168);
        applicationPriorityList.Margin = new Padding(4, 5, 4, 5);
        applicationPriorityList.Name = "applicationPriorityList";
        applicationPriorityList.Size = new Size(189, 25);
        applicationPriorityList.TabIndex = 8;
        // 
        // applicationPriorityLabel
        // 
        applicationPriorityLabel.AutoSize = true;
        applicationPriorityLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        applicationPriorityLabel.Location = new Point(7, 172);
        applicationPriorityLabel.Margin = new Padding(4, 0, 4, 0);
        applicationPriorityLabel.Name = "applicationPriorityLabel";
        applicationPriorityLabel.Size = new Size(124, 17);
        applicationPriorityLabel.TabIndex = 7;
        applicationPriorityLabel.Text = "Application priority";
        // 
        // startHiddenOption
        // 
        startHiddenOption.AutoSize = true;
        startHiddenOption.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        startHiddenOption.Location = new Point(8, 65);
        startHiddenOption.Margin = new Padding(4, 5, 4, 5);
        startHiddenOption.Name = "startHiddenOption";
        startHiddenOption.Size = new Size(107, 21);
        startHiddenOption.TabIndex = 1;
        startHiddenOption.Text = "Start hidden";
        startHiddenOption.UseVisualStyleBackColor = true;
        // 
        // startBalloonOption
        // 
        startBalloonOption.AutoSize = true;
        startBalloonOption.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        startBalloonOption.Location = new Point(29, 100);
        startBalloonOption.Margin = new Padding(4, 5, 4, 5);
        startBalloonOption.Name = "startBalloonOption";
        startBalloonOption.Size = new Size(162, 21);
        startBalloonOption.TabIndex = 2;
        startBalloonOption.Text = "Show balloon at start";
        startBalloonOption.UseVisualStyleBackColor = true;
        // 
        // showPopupOption
        // 
        showPopupOption.AutoSize = true;
        showPopupOption.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        showPopupOption.Location = new Point(8, 135);
        showPopupOption.Margin = new Padding(4, 5, 4, 5);
        showPopupOption.Name = "showPopupOption";
        showPopupOption.Size = new Size(198, 21);
        showPopupOption.TabIndex = 3;
        showPopupOption.Text = "Show balloon when hidden";
        showPopupOption.UseVisualStyleBackColor = true;
        // 
        // autostartOption
        // 
        autostartOption.AutoSize = true;
        autostartOption.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        autostartOption.Location = new Point(8, 28);
        autostartOption.Margin = new Padding(4, 5, 4, 5);
        autostartOption.Name = "autostartOption";
        autostartOption.Size = new Size(144, 21);
        autostartOption.TabIndex = 0;
        autostartOption.Text = "Start with windows";
        autostartOption.UseVisualStyleBackColor = true;
        autostartOption.CheckedChanged += ChkAutostart_CheckedChanged;
        // 
        // applicationInfo
        // 
        applicationInfo.Location = new Point(103, 25);
        applicationInfo.Margin = new Padding(4, 0, 4, 0);
        applicationInfo.Name = "applicationInfo";
        applicationInfo.Size = new Size(259, 98);
        applicationInfo.TabIndex = 0;
        applicationInfo.Text = "Application settings:\r\nHere you can configure \r\nhow the program will behave.";
        // 
        // settingsPic
        // 
        settingsPic.Image = (Image)resources.GetObject("settingsPic.Image");
        settingsPic.Location = new Point(11, 25);
        settingsPic.Margin = new Padding(4, 5, 4, 5);
        settingsPic.Name = "settingsPic";
        settingsPic.Size = new Size(64, 64);
        settingsPic.SizeMode = PictureBoxSizeMode.AutoSize;
        settingsPic.TabIndex = 6;
        settingsPic.TabStop = false;
        // 
        // trayIcon
        // 
        trayIcon.BalloonTipIcon = ToolTipIcon.Info;
        trayIcon.Icon = (Icon)resources.GetObject("trayIcon.Icon");
        trayIcon.Text = "MarcusMedinaPro (formerly LunaWorX.net) TopWinPrio";
        trayIcon.Visible = true;
        trayIcon.BalloonTipClicked += TrayIcon_BalloonTipClicked;
        trayIcon.MouseClick += TrayIcon_MouseClick;
        // 
        // checkBox5
        // 
        checkBox5.AutoSize = true;
        checkBox5.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        checkBox5.Location = new Point(137, 19);
        checkBox5.Name = "checkBox5";
        checkBox5.Size = new Size(83, 17);
        checkBox5.TabIndex = 9;
        checkBox5.Text = "Start hidden";
        checkBox5.UseVisualStyleBackColor = true;
        // 
        // checkBox6
        // 
        checkBox6.AutoSize = true;
        checkBox6.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        checkBox6.Location = new Point(137, 38);
        checkBox6.Name = "checkBox6";
        checkBox6.Size = new Size(125, 17);
        checkBox6.TabIndex = 8;
        checkBox6.Text = "Show balloon at start";
        checkBox6.UseVisualStyleBackColor = true;
        // 
        // checkBox7
        // 
        checkBox7.AutoSize = true;
        checkBox7.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        checkBox7.Location = new Point(6, 38);
        checkBox7.Name = "checkBox7";
        checkBox7.Size = new Size(154, 17);
        checkBox7.TabIndex = 7;
        checkBox7.Text = "Show balloon when hidden";
        checkBox7.UseVisualStyleBackColor = true;
        // 
        // checkBox8
        // 
        checkBox8.AutoSize = true;
        checkBox8.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        checkBox8.Location = new Point(7, 19);
        checkBox8.Name = "checkBox8";
        checkBox8.Size = new Size(114, 17);
        checkBox8.TabIndex = 6;
        checkBox8.Text = "Start with windows";
        checkBox8.UseVisualStyleBackColor = true;
        // 
        // comboBox1
        // 
        comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        comboBox1.FormattingEnabled = true;
        comboBox1.Items.AddRange(new object[] { "Default", "Normal", "BelowNormal", "Idle (not a good idea)" });
        comboBox1.Location = new Point(134, 95);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new Size(143, 25);
        comboBox1.TabIndex = 11;
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label5.Location = new Point(3, 98);
        label5.Name = "label5";
        label5.Size = new Size(125, 13);
        label5.TabIndex = 10;
        label5.Text = "Force inactive window to";
        // 
        // comboBox2
        // 
        comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        comboBox2.FormattingEnabled = true;
        comboBox2.Items.AddRange(new object[] { "AboveNormal", "High", "RealTime (dangerous)" });
        comboBox2.Location = new Point(134, 68);
        comboBox2.Name = "comboBox2";
        comboBox2.Size = new Size(143, 25);
        comboBox2.TabIndex = 9;
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label6.Location = new Point(3, 71);
        label6.Name = "label6";
        label6.Size = new Size(106, 13);
        label6.TabIndex = 8;
        label6.Text = "Set active window to";
        // 
        // hScrollBar1
        // 
        hScrollBar1.Location = new Point(119, 39);
        hScrollBar1.Maximum = 69;
        hScrollBar1.Minimum = 1;
        hScrollBar1.Name = "hScrollBar1";
        hScrollBar1.Size = new Size(163, 17);
        hScrollBar1.TabIndex = 7;
        hScrollBar1.Value = 1;
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label7.Location = new Point(3, 43);
        label7.Name = "label7";
        label7.Size = new Size(110, 13);
        label7.TabIndex = 6;
        label7.Text = "Refresh every 5 secs.";
        // 
        // checkBox9
        // 
        checkBox9.AutoSize = true;
        checkBox9.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        checkBox9.Location = new Point(6, 19);
        checkBox9.Name = "checkBox9";
        checkBox9.Size = new Size(93, 17);
        checkBox9.TabIndex = 5;
        checkBox9.Text = "Boost explorer";
        checkBox9.UseVisualStyleBackColor = true;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(120F, 120F);
        AutoScaleMode = AutoScaleMode.Dpi;
        CancelButton = closeButton;
        ClientSize = new Size(413, 625);
        ControlBox = false;
        Controls.Add(exitButton);
        Controls.Add(closeButton);
        Controls.Add(allTabs);
        Margin = new Padding(4, 5, 4, 5);
        Name = "MainForm";
        Text = "MarcusMedinaPro (formerly LunaWorX.net) TopWinPrio";
        Activated += FrmPrio_Activated;
        FormClosed += FrmPrio_FormClosed;
        Load += FrmPrio_Load;
        allTabs.ResumeLayout(false);
        prioList.ResumeLayout(false);
        prioList.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)logoPic).EndInit();
        boostSettings.ResumeLayout(false);
        boostSettings.PerformLayout();
        boostFrame.ResumeLayout(false);
        boostFrame.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)toolsPic).EndInit();
        applicationSettings.ResumeLayout(false);
        applicationSettings.PerformLayout();
        applicationFrame.ResumeLayout(false);
        applicationFrame.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)settingsPic).EndInit();
        ResumeLayout(false);
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
