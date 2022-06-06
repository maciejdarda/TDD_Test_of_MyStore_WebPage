using NLog;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using TDD_Test_of_CUX;

namespace TDD_Test_of_MyStore.Pages
{
    internal class PopularAndBestSellersTab : BaseClass
    {
        public PopularAndBestSellersTab(IWebDriver driver) : base(driver)
        {
        }

        private static Logger LoggerObj = LogManager.GetCurrentClassLogger();
        public IWebElement popularTab => _driver.FindElement(By.XPath(@"//a[@href='#homefeatured']"));
        public IWebElement bestSellersTab => _driver.FindElement(By.XPath(@"//a[@href='#blockbestsellers']"));

        internal void SwitchToPopularTab()
        {
            try
            {
                popularTab.Click();
                Reporter.LogTestStepForBugLogger(Status.Info, "Click: Popular tab");
            }
            catch (NoSuchElementException ex)
            {
                //zobaczyc co z tymi errorami w logach
                LoggerObj.Error(ex.Message);
            }
        }

        internal void SwitchToBestSellersTab()
        {
            try
            {
                bestSellersTab.Click();
                Reporter.LogTestStepForBugLogger(Status.Info, "Click: BestSeller tab");
            }
            catch (NoSuchElementException ex)
            {
                //zobaczyc co z tymi errorami w logach
                LoggerObj.Error(ex.Message);
            }
        }
    }
}
