using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TDD_Test_of_MyStore.Pages;
using TestResources;

namespace TDD_Test_of_MyStore.Tests
{
    public class BaseTest
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public IWebDriver Driver { get; set; }
        internal PageObejcts PageObejcts { get; set; } 
        private ScreenshotTaker ScreenshotTaker { get; set; }

        /// <summary>
        /// a method evoked only once during object's creation from this namespace
        /// </summary>
        [OneTimeSetUp]
        public static void ExecuteForCreatingReportNamespace()
        {
            Reporter.StartReporter();
        }

        /// <summary>
        /// a method evoked every single time when a test starts 
        /// </summary>
        [SetUp]
        public void Setup()
        {
            Logger.Debug("************************ TEST STARTED");
            Logger.Debug("************************ TEST STARTED");

            //set up test data for Reporter
            Reporter.AddTestCaseMetadataToHtmlReport();
            var factory = new WebDriverFactory();

            //defining the browser type
            Driver = factory.Create(BrowserType.Chrome);

            //an object can be accessed in all derived classes
            PageObejcts = new PageObejcts(Driver);
            GoToURL();

            //an object can be accessed in all derived classes
            ScreenshotTaker = new ScreenshotTaker(Driver, TestContext.CurrentContext);
        }

        /// <summary>
        /// a method evoked every single time at the end of a test
        /// </summary>
        [TearDown]
        public void TearDownTest()
        {
            Logger.Debug(GetType().FullName + " started a method tear down");
            try
            {
                TakeScreenshotForTestFailure();
            }
            catch (Exception e)
            {
                Logger.Error(e.Source);
                Logger.Error(e.StackTrace);
                Logger.Error(e.InnerException);
                Logger.Error(e.Message);
            }
            finally
            {
                StopBrowser();
                Logger.Debug(TestContext.CurrentContext.Test.FullName);
                Logger.Debug("************************ TEST STOPPED");
                Logger.Debug("************************ TEST STOPPED");
            }
        }

        private void TakeScreenshotForTestFailure()
        {
            if (ScreenshotTaker != null)
            {
                //take screenshot if test failed 
                ScreenshotTaker.CreateScreenshotIfTestFailed();

                //if test outcome differs from Inconclusive/Failed - ScreenshotTaker.ScreenshotFilePath will be empty string 
                Reporter.ReportTestOutcome(ScreenshotTaker.ScreenshotFilePath);
            }
            else
            {
                //in case ScreenshotTaker is not initialized, it will not break [TearDownTest] method
                Reporter.ReportTestOutcome("");
            }
        }

        private void StopBrowser()
        {
            Driver?.Quit();
            Driver = null;
            Logger.Trace("Browser stopped successfully.");
        }

        /// <summary>
        /// if you want tests for a given [TestFixture] to start in another URL, override this method
        /// </summary>
        virtual internal void GoToURL()
        {
            PageObejcts.MainPage.GoTo();
        }
    }
}
