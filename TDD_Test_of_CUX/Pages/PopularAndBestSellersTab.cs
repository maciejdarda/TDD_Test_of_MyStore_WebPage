using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TDD_Test_of_CUX;

namespace TDD_Test_of_MyStore.Pages
{
    internal class PopularAndBestSellersTab : BaseClass
    {
        public PopularAndBestSellersTab(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement popularTab => _driver.FindElement(By.XPath(@"//a[@href='#homefeatured']"));
        public IWebElement bestSellersTab => _driver.FindElement(By.XPath(@"//a[@href='#blockbestsellers']"));

        internal void SwitchToPopularTab()
        {
            popularTab.Click();
        }

        internal void SwitchToBestSellersTab()
        {
            bestSellersTab.Click();
        }
    }
}
