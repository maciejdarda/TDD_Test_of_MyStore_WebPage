﻿using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;

namespace TDD_Test_of_MyStore.Pages
{
    internal class TopMenu : BaseClass
    {
        /// <summary>
        /// constructor with reference to BaseClass
        /// </summary>
        /// <param name="driver"></param>
        public TopMenu(IWebDriver driver) : base(driver)
        {
        }

        IWebElement WomenItem => _driver.FindElement(By.XPath("//a[contains(text(), 'Women') and @title='Women']"));
        IWebElement TopsHeader => _driver.FindElement(By.XPath("//a[@title='Tops']"));
        IList<IWebElement> DressesHeader => _driver.FindElements(By.XPath("//a[@title='Tops']"));


        internal void MoveMouseOverWomenItem()
        {
            MoveMouseOverElemnet(WomenItem, "WomenItem button");
            Thread.Sleep(1000);
        }

        internal void AssertWomenItemDisplayed()
        {
            Assert.IsTrue(TopsHeader.Displayed || DressesHeader[0].Displayed);
            Reporter.LogPassingTestStepToBugLogger("Assert: WomenItem's panel displayed");
        }
    }
}
