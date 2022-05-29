using NUnit.Framework;
using OpenQA.Selenium;
using TDD_Test_of_CUX.Pages;
using TestResources;

namespace TDD_Test_of_CUX.Tests
{
    public class BaseTest
    {
        public IWebDriver Driver { get; set; }

        [SetUp]
        public void Setup()
        {
            var factory = new WebDriverFactory();
            Driver = factory.Create(BrowserType.Chrome);
            var mainPage = new MainPage(Driver);
            mainPage.GoTo();
        }

        //private IWebDriver GetChromeDriver()
        //{
        //    var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        //    return new ChromeDriver(outPutDirectory);
        //}

        [TearDown]
        public void TearDownTest()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}