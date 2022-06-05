using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TDD_Test_of_CUX.Pages;
using TDD_Test_of_MyStore;
using TestResources;

namespace TDD_Test_of_CUX.Tests
{
    public class BaseTest
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public IWebDriver Driver { get; set; }
        internal MainPage MainPageObj { get; set; }
        private ScreenshotTaker ScreenshotTaker { get; set; }

        [OneTimeSetUp]
        public static void ExecuteForCreatingReportNamespace()
        {
            Reporter.StartReporter();
        }

        [SetUp]
        public void Setup()
        {
            Logger.Debug("************************ TEST STARTED");
            Logger.Debug("************************ TEST STARTED");
            Reporter.AddTestCaseMetadataToHtmlReport();
            var factory = new WebDriverFactory();
            Driver = factory.Create(BrowserType.Chrome);
            MainPageObj = new MainPage(Driver);
            MainPageObj.GoTo();
            ScreenshotTaker = new ScreenshotTaker(Driver, TestContext.CurrentContext);
        }

        //private IWebDriver GetChromeDriver()
        //{
        //    var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        //    return new ChromeDriver(outPutDirectory);
        //}

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
                Logger.Debug("*************************************** TEST STOPPED");
                Logger.Debug("*************************************** TEST STOPPED");
            }
        }

        private void TakeScreenshotForTestFailure()
        {
            if (ScreenshotTaker != null)
            {
                ScreenshotTaker.CreateScreenshotIfTestFailed();
                Reporter.ReportTestOutcome(ScreenshotTaker.ScreenshotFilePath);
            }
            else
            {
                Reporter.ReportTestOutcome("");
            }
        }

        private void StopBrowser()
        {
            if (Driver == null)
                return;
            Driver.Quit();
            Driver = null;
            Logger.Trace("Browser stopped successfully.");
        }
    }
}
