//----------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="MarcusMedinapro">
// Copyright (c) MarcusMedinaPro. All rights reserved.
// </copyright>
//----------------------------------------------------------------------------------------------------------------
// This file is subject to the terms and conditions defined in file 'license.txt', which is part of this project.
// For more information visit http://MarcusMedina.Pro
//----------------------------------------------------------------------------------------------------------------

#pragma warning disable ET002

namespace TopWinPrio
{
    using System;
    using System.Threading;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="Program"/>.
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
        /// The Main.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (sender, e) =>
            {
                System.Windows.Forms.MessageBox.Show($"Thread Exception: {e.Exception.Message}\n\n{e.Exception.StackTrace}", "TopWinPrio Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            };
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                var ex = e.ExceptionObject as Exception;
                System.Windows.Forms.MessageBox.Show($"Unhandled Exception: {ex?.Message}\n\n{ex?.StackTrace}", "TopWinPrio Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            };

            try
            {
                using (var mutex = new Mutex(true, "MarcusMedinaPro TopWinPrio", out bool isNewInstance))
                {
                    if (isNewInstance)
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        using (var frmPrio = new MainForm { Visible = false })
                        {
                            Application.Run(frmPrio);
                        }
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("TopWinPrio is already running.", "TopWinPrio", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Fatal error: {ex.Message}\n\nStack trace:\n{ex.StackTrace}", "TopWinPrio Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
    }
}