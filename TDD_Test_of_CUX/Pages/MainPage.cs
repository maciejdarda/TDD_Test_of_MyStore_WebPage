using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TDD_Test_of_MyStore;
using TDD_Test_of_MyStore.Pages;

namespace TDD_Test_of_CUX.Pages
{
    internal class MainPage : BaseClass
    {
        //constructor with reference to BaseClass
        public MainPage(IWebDriver driver) : base(driver)
        {
            //subpages' objects 
            PopularAndBestSellersTab = new PopularAndBestSellersTab(driver);
            HomepageSlider = new HomepageSlider(driver);
        }

        private static Logger LoggerObj = LogManager.GetCurrentClassLogger();
        internal PopularAndBestSellersTab PopularAndBestSellersTab { get; set; }
        internal HomepageSlider HomepageSlider { get; set; }

        string url = "http://automationpractice.com";

        internal void GoTo()
        {
            try
            {
                _driver.Navigate().GoToUrl(@url);
                Reporter.LogPassingTestStepToBugLogger($"Load: Page {@url}");
                _driver.Manage().Window.Maximize();
            }
            catch (Exception ex)
            {
                LoggerObj.Error(ex.Message);
            }  
        }

        internal void AssertThatPageIsOpen(IWebDriver webDriver, IWebElement webElement)
        {
            Assert.IsTrue(webDriver.Title == "My Store" && webElement.Displayed);
            Reporter.LogPassingTestStepToBugLogger("Assert: 'Main Window Displayed'");
        }
    }
}
