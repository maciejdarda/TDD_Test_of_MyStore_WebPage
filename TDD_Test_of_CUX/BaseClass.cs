using OpenQA.Selenium;
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

        public void HighlightElement(IWebElement elementToHL)
        {
            var jsDriver = (IJavaScriptExecutor)_driver;
            string highlightJavascript = @"$(arguments[0]).css({ ""border-width"" : ""2px"", ""border-style"" : ""solid"", ""border-color"" : ""red"" });";
            jsDriver.ExecuteScript(highlightJavascript, new object[] { elementToHL }); ;
        }
    }
}
