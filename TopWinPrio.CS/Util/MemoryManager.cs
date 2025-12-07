//----------------------------------------------------------------------------------------------------------------
// <copyright file="MemoryManager.cs" company="MarcusMedinapro">
// Copyright (c) MarcusMedinaPro. All rights reserved.
// </copyright>
//----------------------------------------------------------------------------------------------------------------
// This file is subject to the terms and conditions defined in file 'license.txt', which is part of this project.
// For more information visit http://MarcusMedina.Pro
//----------------------------------------------------------------------------------------------------------------

using System.Diagnostics;

namespace TopWinPrio;

/// <summary>
/// Memory management utilities for process memory optimization
/// </summary>
public static class MemoryManager
{
    /// <summary>
    /// Compresses memory across all processes by forcing them to trim their working sets
    /// </summary>
    /// <returns>Number of megabytes freed, or -1 if operation failed</returns>
    public static long CompressMemory()
    {
        try
        {
            using var performanceCounter = new PerformanceCounter("Memory", "Available MBytes");
            var memoryBeforeMB = Convert.ToInt64(performanceCounter.NextValue());

            var processesCompressed = 0;
            var processesFailed = 0;

            foreach (var process in Process.GetProcesses())
            {
                if (TrimProcessMemory(process))
                {
                    processesCompressed++;
                }
                else
                {
                    processesFailed++;
                }
            }

            // Give system time to reclaim memory
            System.Threading.Thread.Sleep(100);

            var memoryAfterMB = Convert.ToInt64(performanceCounter.NextValue());
            var memoryFreedMB = memoryAfterMB - memoryBeforeMB;

            Debug.WriteLine($"Memory compression: {processesCompressed} processes trimmed, {processesFailed} failed, {memoryFreedMB} MB freed");

            return memoryFreedMB;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Memory compression failed: {ex.Message}");
            return -1;
        }
    }

    /// <summary>
    /// Trims memory for a specific process
    /// </summary>
    /// <param name="process">The process to trim</param>
    /// <returns>True if successful, false otherwise</returns>
    public static bool TrimProcessMemory(Process process)
    {
        ArgumentNullException.ThrowIfNull(process);

        try
        {
            // SetProcessWorkingSetSize with -1, -1 tells Windows to trim the working set
            return NativeMethods.SetProcessWorkingSetSize(
                process.Handle,
                -1,
                -1);
        }
        catch (Exception ex) when (
            ex is System.ComponentModel.Win32Exception ||
            ex is InvalidOperationException ||
            ex is NotSupportedException)
        {
            // Access denied, process exited, or remote process
            Debug.WriteLine($"Failed to trim memory for {process.ProcessName}: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// Trims memory for a specific process by ID
    /// </summary>
    /// <param name="processId">The process ID</param>
    /// <returns>True if successful, false otherwise</returns>
    public static bool TrimProcessMemory(int processId)
    {
        try
        {
            using var process = Process.GetProcessById(processId);
            return TrimProcessMemory(process);
        }
        catch (ArgumentException)
        {
            // Process not found
            return false;
        }
    }
}
