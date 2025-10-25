//----------------------------------------------------------------------------------------------------------------
// File header copyright text should match
// <copyright file="RegistryTools.cs" company="MarcusMedinapro">
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
    using Microsoft.Win32;

    /// <summary>
    /// Defines the <see cref="RegistryTools"/>.
    /// </summary>
    public static class RegistryTools
    {
        /// <summary>
        /// Defines the HKCVRUNLOCATION.
        /// </summary>
        private const string HKCVRUNLOCATION = "Software\\Microsoft\\Windows\\CurrentVersion\\Run";

        /// <summary>
        /// The IsAutoStartEnabled.
        /// </summary>
        /// <param name="keyName">The keyName <see cref="string"/>.</param>
        /// <param name="assemblyLocation">The assemblyLocation <see cref="string"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool IsAutoStartEnabled(string keyName, string assemblyLocation)
        {
            if (string.IsNullOrEmpty(keyName) || string.IsNullOrEmpty(assemblyLocation))
            {
                return false;
            }

            try
            {
                using (var registryKey = Registry.CurrentUser.OpenSubKey(HKCVRUNLOCATION))
                {
                    return registryKey?.GetValue(keyName) is string value &&
                           value.Equals(assemblyLocation, StringComparison.OrdinalIgnoreCase);
                }
            }
            catch (System.Security.SecurityException)
            {
                // Registry access denied
                return false;
            }
            catch (System.UnauthorizedAccessException)
            {
                // Registry access denied
                return false;
            }
        }

        /// <summary>
        /// The SetAutoStart.
        /// </summary>
        /// <param name="keyName">The keyName <see cref="string"/>.</param>
        /// <param name="assemblyLocation">The assemblyLocation <see cref="string"/>.</param>
        public static void SetAutoStart(string keyName, string assemblyLocation)
        {
            if (string.IsNullOrEmpty(keyName) || string.IsNullOrEmpty(assemblyLocation))
            {
                throw new ArgumentException("Key name and assembly location cannot be null or empty.");
            }

            try
            {
                using (var registryKey = Registry.CurrentUser.CreateSubKey(HKCVRUNLOCATION))
                {
                    registryKey?.SetValue(keyName, assemblyLocation);
                }
            }
            catch (System.Security.SecurityException ex)
            {
                throw new InvalidOperationException("Unable to access registry for auto-start configuration.", ex);
            }
            catch (System.UnauthorizedAccessException ex)
            {
                throw new InvalidOperationException("Insufficient permissions to modify registry auto-start settings.", ex);
            }
        }

        /// <summary>
        /// The RemoveAutoStart.
        /// </summary>
        /// <param name="keyName">The keyName <see cref="string"/>.</param>
        public static void RemoveAutoStart(string keyName)
        {
            if (string.IsNullOrEmpty(keyName))
            {
                throw new ArgumentException("Key name cannot be null or empty.", nameof(keyName));
            }

            try
            {
                using (var registryKey = Registry.CurrentUser.CreateSubKey(HKCVRUNLOCATION))
                {
                    if (registryKey?.GetValue(keyName) != null)
                    {
                        registryKey.DeleteValue(keyName, false); // false = don't throw if key doesn't exist
                    }
                }
            }
            catch (System.Security.SecurityException ex)
            {
                throw new InvalidOperationException("Unable to access registry for auto-start removal.", ex);
            }
            catch (System.UnauthorizedAccessException ex)
            {
                throw new InvalidOperationException("Insufficient permissions to modify registry auto-start settings.", ex);
            }
        }
    }
}