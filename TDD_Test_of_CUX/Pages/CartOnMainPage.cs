using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace TDD_Test_of_MyStore.Pages
{
    class CartOnMainPage : BaseClass
    {
        public CartOnMainPage(IWebDriver driver) : base(driver)
        {         
        }

        IWebElement CartOnMain => _driver.FindElement(By.XPath("//a[@title='View my shopping cart']"));
        IWebElement CartTitle => _driver.FindElement(By.XPath("//h1[@id='cart_title']"));

        internal void OpenCartPage()
        {
            CartOnMain.Click();
            Reporter.LogTestStepForBugLogger(Status.Info, "Click: Cart button"); 
        }

        internal void AssertThatCartPageIsOpen()
        {
            Thread.Sleep(3000);
            Assert.IsTrue(_driver.Title == "Order - My Store" && CartTitle.Displayed);
            Reporter.LogPassingTestStepToBugLogger("Assert: 'Cart page Displayed'");
        }
    }
}
