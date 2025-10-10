//----------------------------------------------------------------------------------------------------------------
// <copyright file="RegistryToolsTests.cs" company="MarcusMedina">
// Copyright (c) Marcus Ackre Medina. All rights reserved.
// </copyright>
//----------------------------------------------------------------------------------------------------------------

namespace TopWinPrio.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.Win32;
    using TopWinPrio;

    [TestClass]
    public class RegistryToolsTests
    {
        private const string TestKeyName = "TopWinPrio.Tests.AutoStart";
        private static readonly string DummyPath = typeof(RegistryToolsTests).Assembly.Location;

        [TestCleanup]
        public void Cleanup()
        {
            try
            {
                RegistryTools.RemoveAutoStart(TestKeyName);
            }
            catch (System.ArgumentException)
            {
                // Ignore missing value removal in cleanup.
            }
        }

        [TestMethod]
        public void AutoStart_IsDisabled_WhenValueNotPresent()
        {
            Cleanup();
            Assert.IsFalse(RegistryTools.IsAutoStartEnabled(TestKeyName, DummyPath));
        }

        [TestMethod]
        public void AutoStart_CanBeEnabledAndDisabled()
        {
            RegistryTools.SetAutoStart(TestKeyName, DummyPath);
            Assert.IsTrue(RegistryTools.IsAutoStartEnabled(TestKeyName, DummyPath));

            RegistryTools.RemoveAutoStart(TestKeyName);
            Assert.IsFalse(RegistryTools.IsAutoStartEnabled(TestKeyName, DummyPath));
        }
    }
}
