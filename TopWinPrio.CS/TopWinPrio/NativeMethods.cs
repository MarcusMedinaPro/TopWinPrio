//----------------------------------------------------------------------------------------------------------------
// <copyright file="NativeMethods.cs" company="MarcusMedinapro">
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
    using System.Runtime.InteropServices;
    using System.Text;

    /// <summary>
    /// Defines the <see cref="NativeMethods"/>.
    /// </summary>
    internal static class NativeMethods
    {
        /// <summary>
        /// Gets the GetTopWindowHandle.
        /// </summary>
        public static int GetTopWindowHandle => (int)GetForegroundWindow();

        /// <summary>
        /// Gets the GetTopWindowProcessID.
        /// </summary>
        public static int GetTopWindowProcessID
        {
            get
            {
                var windowHandle = GetForegroundWindow();
                if (windowHandle == IntPtr.Zero)
                {
                    return 0;
                }

                try
                {
                    _ = GetWindowThreadProcessId(windowHandle, out var processId);
                    return (int)processId;
                }
                catch (System.ComponentModel.Win32Exception)
                {
                    // Handle Win32 API errors gracefully
                    return 0;
                }
            }
        }

        /// <summary>
        /// Gets the GetTopWindowText.
        /// </summary>
        public static string GetTopWindowText
        {
            get
            {
                const int maxLength = 256;
                var stringBuilder = new StringBuilder(maxLength);
                var windowHandle = GetForegroundWindow();

                if (windowHandle == IntPtr.Zero)
                {
                    return string.Empty;
                }

                try
                {
                    var result = GetWindowText(windowHandle, stringBuilder, maxLength);
                    return result > 0 ? stringBuilder.ToString() : string.Empty;
                }
                catch (System.ComponentModel.Win32Exception)
                {
                    // Handle Win32 API errors gracefully
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// The GetForegroundWindow.
        /// </summary>
        /// <returns>The <see cref="IntPtr"/>.</returns>
        [System.Security.SecurityCritical]
        [PreserveSig]
        [DllImport("user32.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode)]
        private static extern IntPtr GetForegroundWindow();

        /// <summary>
        /// The GetWindowText.
        /// </summary>
        /// <param name="hWnd">The hWnd <see cref="IntPtr"/>.</param>
        /// <param name="text">The text <see cref="StringBuilder"/>.</param>
        /// <param name="count">The count <see cref="int"/>.</param>
        /// <returns>The <see cref="int"/>.</returns>
        [PreserveSig]
        [DllImport("user32.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode)]
        [System.Security.SecurityCritical]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        /// <summary>
        /// The GetWindowThreadProcessId.
        /// </summary>
        /// <param name="hWnd">The hWnd <see cref="IntPtr"/>.</param>
        /// <param name="lpdwProcessId">The lpdwProcessId <see cref="uint"/>.</param>
        /// <returns>The <see cref="int"/>.</returns>
        [PreserveSig]
        [DllImport("user32.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode)]
        [System.Security.SecurityCritical]
        private static extern int GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
    }
}