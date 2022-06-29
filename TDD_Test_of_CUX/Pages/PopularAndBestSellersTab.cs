using NLog;
using OpenQA.Selenium;
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

        //TODO reduce to one method
        internal void SwitchToPopularTab()
        {
            try
            {
                ClickElement(PopularTab, "PopularTab");
            }
            catch (NoSuchElementException ex)
            {
                //TODO check error in logs, how it look
                LoggerObj.Error(ex.Message);
            }
        }

        internal void SwitchToBestSellersTab()
        {
            try
            {
                ClickElement(BestSellersTab, "BestSellersTab");
            }
            catch (NoSuchElementException ex)
            {
                //TODO check error in logs, how it look
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
