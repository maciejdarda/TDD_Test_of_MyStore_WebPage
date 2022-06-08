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
                //zobaczyc co z tymi errorami w logach
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
                //zobaczyc co z tymi errorami w logach
                LoggerObj.Error(ex.Message);
            }
        }
    }
}
