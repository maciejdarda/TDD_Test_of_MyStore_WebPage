using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;

namespace TDD_Test_of_CUX
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

        //accessible in all derived classes
        public void HighlightElement(IWebElement elementToHL)
        {
            var jsDriver = (IJavaScriptExecutor)_driver;
            string highlightJavascript = @"$(arguments[0]).css({ ""border-width"" : ""2px"", ""border-style"" : ""solid"", ""border-color"" : ""red"" });";
            jsDriver.ExecuteScript(highlightJavascript, new object[] { elementToHL }); ;
        }

        //accessible in all derived classes
        public void MoveToElement(IWebElement element)
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(element);
            actions.Perform();
        }

        //accessible in all derived classes
        public void SendKeysToElement(IWebElement element, string text)
        {
            Actions actions = new Actions(_driver);
            actions.SendKeys(element, text);
            actions.Perform();
        }

        //accessible in all derived classes
        public bool CheckIfElementIsDisplayed(IWebElement element)
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

            return isDisplayed;
        }

        //accessible in all derived classes
        public void MoveMouseOverElemnet(IWebElement element)
        {
            Actions action = new Actions(_driver);
            action.MoveToElement(element).Perform();
        }
    }
}
