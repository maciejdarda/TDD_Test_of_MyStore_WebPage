using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

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
    }
}
