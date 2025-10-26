//----------------------------------------------------------------------------------------------------------------
// <copyright file="RegistryTools.cs" company="MarcusMedinapro">
// Copyright (c) MarcusMedinaPro. All rights reserved.
// </copyright>
//----------------------------------------------------------------------------------------------------------------
// This file is subject to the terms and conditions defined in file 'license.txt', which is part of this project.
// For more information visit http://MarcusMedina.Pro
//----------------------------------------------------------------------------------------------------------------

using System;
using System.Security;
using Microsoft.Win32;

namespace TopWinPrio;

/// <summary>
/// Registry utility methods for Windows autostart configuration
/// </summary>
public static class RegistryTools
{
    private const string HKCVRUNLOCATION = "Software\\Microsoft\\Windows\\CurrentVersion\\Run";

    /// <summary>
    /// Checks if autostart is enabled for the application
    /// </summary>
    public static bool IsAutoStartEnabled(string keyName, string assemblyLocation)
    {
        if (string.IsNullOrEmpty(keyName) || string.IsNullOrEmpty(assemblyLocation))
        {
            return false;
        }

        try
        {
            using var registryKey = Registry.CurrentUser.OpenSubKey(HKCVRUNLOCATION);
            return registryKey?.GetValue(keyName) is string value &&
                   value.Equals(assemblyLocation, StringComparison.OrdinalIgnoreCase);
        }
        catch (SecurityException)
        {
            // Registry access denied
            return false;
        }
        catch (UnauthorizedAccessException)
        {
            // Registry access denied
            return false;
        }
    }

    /// <summary>
    /// Enables autostart for the application
    /// </summary>
    public static void SetAutoStart(string keyName, string assemblyLocation)
    {
        if (string.IsNullOrEmpty(keyName) || string.IsNullOrEmpty(assemblyLocation))
        {
            throw new ArgumentException("Key name and assembly location cannot be null or empty.");
        }

        try
        {
            using var registryKey = Registry.CurrentUser.CreateSubKey(HKCVRUNLOCATION);
            registryKey?.SetValue(keyName, assemblyLocation);
        }
        catch (SecurityException ex)
        {
            throw new InvalidOperationException("Unable to access registry for auto-start configuration.", ex);
        }
        catch (UnauthorizedAccessException ex)
        {
            throw new InvalidOperationException("Insufficient permissions to modify registry auto-start settings.", ex);
        }
    }

    /// <summary>
    /// Disables autostart for the application
    /// </summary>
    public static void RemoveAutoStart(string keyName)
    {
        if (string.IsNullOrEmpty(keyName))
        {
            throw new ArgumentException("Key name cannot be null or empty.", nameof(keyName));
        }

        try
        {
            using var registryKey = Registry.CurrentUser.CreateSubKey(HKCVRUNLOCATION);
            if (registryKey?.GetValue(keyName) != null)
            {
                registryKey.DeleteValue(keyName, false); // false = don't throw if key doesn't exist
            }
        }
        catch (SecurityException ex)
        {
            throw new InvalidOperationException("Unable to access registry for auto-start removal.", ex);
        }
        catch (UnauthorizedAccessException ex)
        {
            throw new InvalidOperationException("Insufficient permissions to modify registry auto-start settings.", ex);
        }
    }
}
