//----------------------------------------------------------------------------------------------------------------
// <copyright file="MainForm.cs" company="MarcusMedinapro">
// Copyright (c) MarcusMedinaPro. All rights reserved.
// </copyright>
//----------------------------------------------------------------------------------------------------------------
// This file is subject to the terms and conditions defined in file 'license.txt', which is part of this project.
// For more information visit http://MarcusMedina.Pro
//----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Reflection;
using TopWinPrio.Properties;

namespace TopWinPrio;

/// <summary>
/// Main form for TopWinPrio application
/// </summary>
public partial class MainForm : Form
{
    private readonly string assemblyLocation;
    private readonly string keyName;
    private bool isFirstRun;
    private int lastHandle;
    private ProcessData oldProc;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainForm"/> class.
    /// </summary>
    public MainForm()
    {
        oldProc = new() { LastPrio = ProcessPriorityClass.Normal, ProcessID = 0 };
        isFirstRun = true;
        keyName = "MarcusMedinaPro (formerly LunaWorX.net) TopWinPrio";
        assemblyLocation = Assembly.GetExecutingAssembly().Location;
        InitializeComponent();
    }

        /// <summary>
        /// Sets process priority
        /// </summary>
        private static bool SetProcessPrio(ProcessData theProc, ProcessPriorityClass processPriorityClass)
        {
            // Validate priority class (must be a valid enum value, not default 0)
            if (theProc.ProcessID <= 0 || !Enum.IsDefined(typeof(ProcessPriorityClass), processPriorityClass))
            {
                return false;
            }

            Process process;

            try
            {
                process = Process.GetProcessById(theProc.ProcessID);
            }
            catch (ArgumentException ex)
            {
                // Process ID is invalid or process has exited
                Debug.WriteLine(ex.Message);
                return false;
            }
            catch (InvalidOperationException ex)
            {
                // Process has not been started or has exited
                Debug.WriteLine(ex.Message);
                return false;
            }

            if (process == null)
            {
                return false;
            }

            try
            {
                process.PriorityClass = processPriorityClass;
                return true;
            }
            catch (Win32Exception ex)
            {
                // Insufficient privileges or process has exited
                Debug.WriteLine(ex.Message);
                return false;
            }
            catch (InvalidOperationException ex)
            {
                // Process has exited
                Debug.WriteLine(ex.Message);
                return false;
            }
            catch (NotSupportedException ex)
            {
                // Process is on a remote machine
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Visible = false;
            trayIcon.BalloonTipIcon = ToolTipIcon.Info;
            trayIcon.BalloonTipText = "The program is running in the background";
            trayIcon.BalloonTipTitle = "MarcusMedinaPro (formerly LunaWorX.net) TopWinPrio";
            trayIcon.ShowBalloonTip(3000);
        }

        private void BtnExit_Click(object sender, EventArgs e) => Application.Exit();

        private void ChkAutostart_CheckedChanged(object sender, EventArgs e)
        {
            if (RegistryTools.IsAutoStartEnabled(keyName, assemblyLocation))
            {
                RegistryTools.RemoveAutoStart(keyName);
                return;
            }

            RegistryTools.SetAutoStart(keyName, assemblyLocation);
        }

    private void FrmPrio_Activated(object sender, EventArgs e)
    {
        if (isFirstRun)
        {
            isFirstRun = false;
            Visible = !startHiddenOption.Checked;
            if (!Visible)
            {
                ClientSize = new(0, 0);
                var i1 = Top;
                var i2 = Left;
                Top = -100;
                Left = -100;
                trayIcon.BalloonTipIcon = ToolTipIcon.Info;
                trayIcon.BalloonTipText = "The program is running in the background";
                trayIcon.BalloonTipTitle = "MarcusMedinaPro (formerly LunaWorX.net) TopWinPrio";
                trayIcon.ShowBalloonTip(3000);
                var processPriorityClass = Enum.Parse<ProcessPriorityClass>(applicationPriorityList.Text);
                Process.GetCurrentProcess().PriorityClass = processPriorityClass;
                ClientSize = new(310, 396);
                Top = i1;
                Left = i2;
            }
        }
    }

        private void FrmPrio_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.BoostExplorer = boostExplorerOption.Checked;
            Settings.Default.RefreshTime = timerSlider.Value;
            Settings.Default.InactiveWinPrio = inactiveList.SelectedIndex;
            Settings.Default.ActiveWinPrio = activeList.SelectedIndex;
            Settings.Default.BalloonHidden = showPopupOption.Checked;
            Settings.Default.BalloonStart = startBalloonOption.Checked;
            Settings.Default.StartHidden = startHiddenOption.Checked;
            Settings.Default.ApplicationPrio = applicationPriorityList.SelectedIndex;
            Settings.Default.Save();
            _ = SetProcessPrio(oldProc, oldProc.LastPrio);
        }

        private void FrmPrio_Load(object sender, EventArgs e)
        {
            boostExplorerOption.Checked = Settings.Default.BoostExplorer;
            timerSlider.Value = Settings.Default.RefreshTime;
            inactiveList.SelectedIndex = Settings.Default.InactiveWinPrio;
            activeList.SelectedIndex = Settings.Default.ActiveWinPrio;
            startHiddenOption.Checked = Settings.Default.StartHidden;
            startBalloonOption.Checked = Settings.Default.BalloonStart;
            showPopupOption.Checked = Settings.Default.BalloonHidden;
            applicationPriorityList.SelectedIndex = Settings.Default.ApplicationPrio;
            autostartOption.Checked = RegistryTools.IsAutoStartEnabled(keyName, assemblyLocation);
            HsbTimer_Scroll(null!, null!);
        }

        private void HsbTimer_Scroll(object? sender, ScrollEventArgs? e)
        {
            var i = timerSlider.Value;
            refreshLabel.Text = $"Refresh every {i} secs";
            timerTopWindowCheck.Interval = i * 1000;
        }

        private void TimerTopWindowCheck_Tick(object sender, EventArgs e)
        {
            timerTopWindowCheck.Enabled = false;
            var currentHandle = NativeMethods.GetTopWindowHandle;

            if (currentHandle != lastHandle)
            {
                ProcessWindowChange(currentHandle);
            }

            timerTopWindowCheck.Enabled = true;
        }

        /// <summary>
        /// Processes window change and updates priority
        /// </summary>
        private void ProcessWindowChange(int newHandle)
        {
            _ = SetProcessPrio(oldProc, oldProc.LastPrio);
            lastHandle = newHandle;

            var process = Process.GetProcessById(NativeMethods.GetTopWindowProcessID);

            if (!ShouldBoostProcess(process))
            {
                return;
            }

            var processData = CreateProcessData(process);
            if (processData != null)
            {
                UpdateProcessPriority(processData, process);
            }
        }

        /// <summary>
        /// Determines if process should be boosted
        /// </summary>
        private bool ShouldBoostProcess(Process process) =>
            process is { Id: > 0 } &&
            (boostExplorerOption.Checked || process.ProcessName != "explorer") &&
            process.Id != Environment.ProcessId;

    /// <summary>
    /// Creates ProcessData from process
    /// </summary>
    private static ProcessData? CreateProcessData(Process process)
    {
        try
        {
            return new()
            {
                ProcessID = process.Id,
                LastPrio = process.PriorityClass,
            };
        }
        catch (Win32Exception ex)
        {
            // Access denied or process has exited
            Debug.WriteLine(ex.Message);
            return null;
        }
        catch (InvalidOperationException ex)
        {
            // Process has exited
            Debug.WriteLine(ex.Message);
            return null;
        }
        catch (NotSupportedException ex)
        {
            // Process is on a remote machine
            Debug.WriteLine(ex.Message);
            return null;
        }
    }

    /// <summary>
    /// Updates process priority and logs the change
    /// </summary>
    private void UpdateProcessPriority(ProcessData processData, Process process)
    {
        if (inactiveList.Text != "Default")
        {
            processData = processData with
            {
                LastPrio = Enum.Parse<ProcessPriorityClass>(inactiveList.Text)
            };
        }

        var targetPriority = Enum.Parse<ProcessPriorityClass>(activeList.Text);

        if (SetProcessPrio(processData, targetPriority))
        {
            LogPriorityChange(process);
        }

        oldProc = processData;
    }

    /// <summary>
    /// Logs priority change to list
    /// </summary>
    private void LogPriorityChange(Process process)
    {
        var timestamp = DateTime.Now;
        ListViewItem listItem = new(timestamp.ToShortTimeString());

        var windowTitle = !string.IsNullOrEmpty(NativeMethods.GetTopWindowText)
            ? NativeMethods.GetTopWindowText
            : process.ProcessName;

        _ = listItem.SubItems.Add(windowTitle);
        _ = logList.Items.Insert(0, listItem);

        const int MaxLogEntries = 13;
        if (logList.Items.Count > MaxLogEntries)
        {
            logList.Items.RemoveAt(MaxLogEntries);
        }
    }

        private void TrayIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            Visible = false;
            TrayIcon_MouseClick(null!, null!);
        }

        private void TrayIcon_MouseClick(object? sender, MouseEventArgs? e)
        {
            Visible = !Visible;
            if (Visible)
            {
                TopMost = true;
                Application.DoEvents();
                TopMost = false;
                _ = Focus();
            }
        }

    /// <summary>
    /// Process data container
    /// </summary>
    private sealed record ProcessData
    {
        public ProcessPriorityClass LastPrio { get; init; }
        public int ProcessID { get; init; }
    }
}
