using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;

namespace TestResources
{
    public class WebDriverFactory
    {
        /// <summary>
        /// in this method you can define type of the browser
        /// </summary>
        /// <param name="browserType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public IWebDriver Create(BrowserType browserType)
        {
            return browserType switch
            {
                BrowserType.Chrome => GetChromeDriver(),
                _ => throw new ArgumentOutOfRangeException("No such browser exists"),
            };
        }

        /// <summary>
        /// different types of drivers can be added in a similar way
        /// </summary>
        /// <returns></returns>
        private IWebDriver GetChromeDriver()
        {
            //return driver
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }
    }
}
