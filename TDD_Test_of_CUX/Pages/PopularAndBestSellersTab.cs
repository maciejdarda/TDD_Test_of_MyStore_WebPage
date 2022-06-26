using NLog;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using NUnit.Framework;

namespace TDD_Test_of_MyStore.Pages
{
    internal class PopularAndBestSellersTab : BaseClass
    {
        /// <summary>
        /// constructor with reference to BaseClass
        /// </summary>
        /// <param name="driver"></param>
        public PopularAndBestSellersTab(IWebDriver driver) : base(driver)
        {
        }

        private static Logger LoggerObj = LogManager.GetCurrentClassLogger();
        public IWebElement PopularTab => _driver.FindElement(By.XPath(@"//a[@href='#homefeatured']"));
        public IWebElement BestSellersTab => _driver.FindElement(By.XPath(@"//a[@href='#blockbestsellers']"));

        internal void SwitchToPopularTab()
        {
            try
            {
                PopularTab.Click();
                Reporter.LogTestStepForBugLogger(Status.Info, "Click: Popular tab");
            }
            catch (NoSuchElementException ex)
            {
                //TODO zobaczyc co z tymi errorami w logach
                LoggerObj.Error(ex.Message);
            }
        }

        internal void SwitchToBestSellersTab()
        {
            try
            {
                BestSellersTab.Click();
                Reporter.LogTestStepForBugLogger(Status.Info, "Click: BestSeller tab");
            }
            catch (NoSuchElementException ex)
            {
                //TODO zobaczyc co z tymi errorami w logach
                LoggerObj.Error(ex.Message);
            }
        }

        internal void AssertThatElementIsActive(IWebElement tab)
        {
            Assert.IsTrue(tab.GetAttribute("class") == "active");
            Reporter.LogPassingTestStepToBugLogger("Assert: 'Tab is active'");
        }
    }
}
