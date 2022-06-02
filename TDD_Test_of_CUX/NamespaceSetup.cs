using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDD_Test_of_MyStore
{
    [SetUpFixture]
    public static class NamespaceSetup
    {
        [OneTimeSetUp]
        public static void ExecuteForCreatingReportNamespace(TestContext testContext)
        {
            Reporter.StartReporter();
        }
    }
}
