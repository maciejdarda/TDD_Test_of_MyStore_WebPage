using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDD_Test_of_MyStore
{
    [TestFixture]
    public static class NamespaceSetup
    {
        [TestAssemblyDirectoryResolve]
        public static void ExecuteForCreatingReportNamespace(TestContext testContext)
        {
            Reporter.StartReporter();
        }
    }
}
