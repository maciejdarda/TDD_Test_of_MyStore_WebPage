using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;

namespace TDD_Test_of_MyStore
{
    public class BaseClass
    {
        protected IWebDriver _driver;

        public BaseClass(IWebDriver driver)
        {
            _driver = driver;

            //implicit wait 10s
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        /// <summary>
        /// accessible in all derived classes
        /// </summary>
        /// <param name="elementToHL"></param>
        /// <param name="reportMessage"></param>
        public void HighlightElement(IWebElement elementToHL, string reportMessage)
        {
            var jsDriver = (IJavaScriptExecutor)_driver;
            string highlightJavascript = @"$(arguments[0]).css({ ""border-width"" : ""2px"", ""border-style"" : ""solid"", ""border-color"" : ""red"" });";
            jsDriver.ExecuteScript(highlightJavascript, new object[] { elementToHL });
            Reporter.LogTestStepForBugLogger(Status.Info, $"Highlight: {reportMessage}");
        }

        /// <summary>
        /// accessible in all derived classes
        /// </summary>
        /// <param name="element"></param>
        /// <param name="reportMessage"></param>
        public void MoveToElement(IWebElement element, string reportMessage)
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(element);
            actions.Perform();
            Reporter.LogTestStepForBugLogger(Status.Info, $"MoveTo: {reportMessage}");
        }

        /// <summary>
        /// accessible in all derived classes
        /// </summary>
        /// <param name="element"></param>
        /// <param name="text"></param>
        /// <param name="reportMessage"></param>
        public void SendKeysToElement(IWebElement element, string text, string reportMessage)
        {
            Actions actions = new Actions(_driver);
            actions.SendKeys(element, text);
            actions.Perform();
            Reporter.LogTestStepForBugLogger(Status.Info, $"SendKeys: '{text}' to {reportMessage}");
        }

        /// <summary>
        /// accessible in all derived classes
        /// </summary>
        /// <param name="element"></param>
        /// <param name="reportMessage"></param>
        /// <returns></returns>
        public bool CheckIfElementIsDisplayed(IWebElement element, string reportMessage)
        {
            bool isDisplayed = false;

            try
            {
                if (element.Displayed)
                    isDisplayed = true;

            }
            catch (NoSuchElementException)
            {
                isDisplayed = false;
            }

            Reporter.LogTestStepForBugLogger(Status.Info, $"DisplayCheck: {reportMessage} {isDisplayed}");
            return isDisplayed;
        }

        /// <summary>
        /// accessible in all derived classes
        /// </summary>
        /// <param name="element"></param>
        /// <param name="reportMessage"></param>
        public void MoveMouseOverElemnet(IWebElement element, string reportMessage)
        {
            Actions action = new Actions(_driver);
            action.MoveToElement(element).Perform();
            Reporter.LogTestStepForBugLogger(Status.Info, $"MoveMouseAbove: {reportMessage}");
        }

        /// <summary>
        /// accessible in all derived classes
        /// </summary>
        /// <param name="element"></param>
        /// <param name="reportMessage"></param>
        public void ClickElement(IWebElement element, string reportMessage)
        {
            element.Click();
            Reporter.LogTestStepForBugLogger(Status.Info, $"Click: {reportMessage}");
        }
    }
}
