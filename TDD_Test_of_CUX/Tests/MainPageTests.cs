﻿using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using TDD_Test_of_MyStore;

namespace TDD_Test_of_CUX.Tests
{
    [TestFixture]
    [Category("Main Page funcionality and navigation")]
    internal class MainPageTests : BaseTest
    {
        private static Logger LoggerObj = LogManager.GetCurrentClassLogger();

        public IWebElement Logo => Driver.FindElement(By.XPath(@"//img[@class='logo img-responsive']"));
        public IWebElement PopularTab => Driver.FindElement(By.XPath(@"//a[@href='#homefeatured']"));
        public IWebElement BestSellersTab => Driver.FindElement(By.XPath(@"//a[@href='#blockbestsellers']"));
        IWebElement BestSellersTabParent => BestSellersTab.FindElement(By.XPath("./.."));
        IWebElement PopularTabParent => PopularTab.FindElement(By.XPath("./.."));



        [Description("Test if Page can be open")]
        [Property("Author", "Maciej Darda")]
        [Test]
        public void TCID1()
        {
            LoggerObj.Debug("TCID1 - started");
            Assert.IsTrue(Driver.Title == "My Store" && Logo.Displayed);
            Reporter.LogPassingTestStepToBugLogger("Assert: 'Main Window Displayed'");
            LoggerObj.Debug("TCID1 - stopped");
        }

        [Description("Test switching between POPULAR and BESTSELLERS tabs")]
        [Property("Author", "Maciej Darda")]
        [Test]
        public void TCID2()
        {
            LoggerObj.Debug("TCID2 - started");
            MainPageObj.popularAndBestSellersTab.SwitchToBestSellersTab();
            Assert.IsTrue(BestSellersTabParent.GetAttribute("class") == "active");
            Reporter.LogPassingTestStepToBugLogger("Assert: 'BestSeller Tab is active'");
            MainPageObj.popularAndBestSellersTab.SwitchToPopularTab();
            Assert.IsTrue(PopularTabParent.GetAttribute("class") == "active");
            Reporter.LogPassingTestStepToBugLogger("Assert: 'Popular Tab is active'");
            LoggerObj.Debug("TCID2 - stopped");
        }
    }
}
