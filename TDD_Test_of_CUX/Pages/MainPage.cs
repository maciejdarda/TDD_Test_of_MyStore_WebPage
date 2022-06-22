using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace TDD_Test_of_MyStore.Pages
{
    internal class MainPage : BaseClass
    {
        //constructor with reference to BaseClass
        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        private static Logger LoggerObj = LogManager.GetCurrentClassLogger();

        //main url to tested page 
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
