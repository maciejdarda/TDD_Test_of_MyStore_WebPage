using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;

namespace TestResources
{
    public class WebDriverFactory
    {
        //in this method you can define type of the browser
        public IWebDriver Create(BrowserType browserType)
        {
            return browserType switch
            {
                BrowserType.Chrome => GetChromeDriver(),
                _ => throw new ArgumentOutOfRangeException("No such browser exists"),
            };
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
