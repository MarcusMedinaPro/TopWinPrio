//----------------------------------------------------------------------------------------------------------------
// <copyright file="NativeMethods.cs" company="MarcusMedinapro">
// Copyright (c) MarcusMedinaPro. All rights reserved.
// </copyright>
//----------------------------------------------------------------------------------------------------------------
// This file is subject to the terms and conditions defined in file 'license.txt', which is part of this project.
// For more information visit http://MarcusMedina.Pro
//----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;

namespace TopWinPrio;

/// <summary>
/// Native Windows API methods
/// </summary>
internal static class NativeMethods
{
    /// <summary>
    /// Gets the handle of the foreground window
    /// </summary>
    public static int GetTopWindowHandle => (int)GetForegroundWindow();

    /// <summary>
    /// Gets the process ID of the foreground window
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
            catch (Win32Exception)
            {
                // Handle Win32 API errors gracefully
                return 0;
            }
        }
    }

    /// <summary>
    /// Gets the title text of the foreground window
    /// </summary>
    public static string GetTopWindowText
    {
        get
        {
            const int maxLength = 256;
            StringBuilder stringBuilder = new(maxLength);
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
            catch (Win32Exception)
            {
                // Handle Win32 API errors gracefully
                return string.Empty;
            }
        }
    }

    [System.Security.SecurityCritical]
    [PreserveSig]
    [DllImport("user32.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode)]
    private static extern IntPtr GetForegroundWindow();

    [PreserveSig]
    [DllImport("user32.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode)]
    [System.Security.SecurityCritical]
    private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

    [PreserveSig]
    [DllImport("user32.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode)]
    [System.Security.SecurityCritical]
    private static extern int GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
}
