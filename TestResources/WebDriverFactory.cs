using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;

namespace TestResources
{
    public class WebDriverFactory
    {
        public IWebDriver Create(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    return GetChromeDriver();
                default:
                    throw new ArgumentOutOfRangeException("No such browser exists");
            }
        }

        //different types of drivers can be added in a similar way
        private IWebDriver GetChromeDriver()
        {
            //return driver
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }
    }
}
