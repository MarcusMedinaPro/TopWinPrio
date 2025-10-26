//----------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="MarcusMedinapro">
// Copyright (c) MarcusMedinaPro. All rights reserved.
// </copyright>
//----------------------------------------------------------------------------------------------------------------
// This file is subject to the terms and conditions defined in file 'license.txt', which is part of this project.
// For more information visit http://MarcusMedina.Pro
//----------------------------------------------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;
using System.Threading;

namespace TopWinPrio;

/// <summary>
/// Entry point for TopWinPrio application
/// </summary>
internal sealed class Program
{
    /// <summary>
    /// Prevents a default instance of the <see cref="Program"/> class from being created.
    /// </summary>
    private Program()
    {
    }

    /// <summary>
    /// Application entry point
    /// </summary>
    [STAThread]
    [SuppressMessage("CodeQL", "cs/useless-assignment-to-local", Justification = "Mutex must remain in scope during entire Application.Run() to prevent multiple instances - using declaration is intentional")]
    public static void Main()
    {
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        Application.ThreadException += (sender, e) =>
        {
            MessageBox.Show(
                $"Thread Exception: {e.Exception.Message}\n\n{e.Exception.StackTrace}",
                "TopWinPrio Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        };

        AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
        {
            var ex = e.ExceptionObject as Exception;
            MessageBox.Show(
                $"Unhandled Exception: {ex?.Message}\n\n{ex?.StackTrace}",
                "TopWinPrio Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        };

        try
        {
            using var mutex = new Mutex(true, "MarcusMedinaPro TopWinPrio", out bool isNewInstance);
            if (isNewInstance)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                using var frmPrio = new MainForm { Visible = false };
                Application.Run(frmPrio);
            }
            else
            {
                MessageBox.Show(
                    "TopWinPrio is already running.",
                    "TopWinPrio",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
        [SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Top-level exception handler - must catch all exceptions to prevent application crash")]
        [SuppressMessage("CodeQL", "cs/catch-of-all-exceptions", Justification = "Top-level exception handler in Main() - intentionally catches all exceptions for user-friendly error reporting")]
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Fatal error: {ex.Message}\n\nStack trace:\n{ex.StackTrace}",
                "TopWinPrio Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
