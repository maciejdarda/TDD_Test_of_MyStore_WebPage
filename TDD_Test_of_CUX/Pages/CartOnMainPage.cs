using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
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
        IWebElement AddToCartPanel => _driver.FindElement(By.XPath("//div[@id='layer_cart']"));
        IWebElement OkIcon => _driver.FindElement(By.XPath("//i[@class='icon-ok']"));
        IWebElement CloseWindowButton => _driver.FindElement(By.XPath("//span[@class='cross' and @title='Close window']"));
        IList<IWebElement> CartCounter => _driver.FindElements(By.XPath("//span[@class='ajax_cart_quantity']"));

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

        internal void AssertThatItemIsAddedToCart()
        {
            Thread.Sleep(500);
            Assert.IsTrue(AddToCartPanel.Displayed, "AddToCartPanel not displayed");
            Assert.IsTrue(OkIcon.Displayed, "OkIcon not displayed");
            Reporter.LogPassingTestStepToBugLogger("Assert: Cart panel is displayed");
            CloseWindowButton.Click();
            Reporter.LogTestStepForBugLogger(Status.Info, "Click: Close window button");
            MoveToElement(CartOnMain, "CartOnMain");
            Assert.IsTrue(CartCounter[0].Text == "1", "Cart counter displaying wrong number of items");
            Reporter.LogPassingTestStepToBugLogger("Assert: Cart counter displayed correct amount of items");
        }
    }
}
