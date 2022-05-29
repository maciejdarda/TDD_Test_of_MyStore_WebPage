using NUnit.Framework;
using OpenQA.Selenium;
using TDD_Test_of_CUX.Pages;

namespace TDD_Test_of_CUX.Tests
{
    [TestFixture]
    [Category("Main Page funcionality and navigation")]
    internal class MainPageTests : BaseTest
    {
        public IWebElement logo => Driver.FindElement(By.XPath(@"//img[@class='logo img-responsive']"));
        public IWebElement popularTab => Driver.FindElement(By.XPath(@"//a[@href='#homefeatured']"));
        public IWebElement bestSellersTab => Driver.FindElement(By.XPath(@"//a[@href='#blockbestsellers']"));
        IWebElement bestSellersTabParent => bestSellersTab.FindElement(By.XPath("./.."));
        IWebElement popularTabParent => popularTab.FindElement(By.XPath("./.."));

        [Description("Test if Page can be open")]
        [Property("Author", "Maciej Darda")]
        [Test]
        public void TCID1()
        {
            Assert.IsTrue(Driver.Title == "My Store" && logo.Displayed);
        }

        [Description("Test swiching between POPULAR and BEST SELLERS tabs")]
        [Property("Author", "Maciej Darda")]
        [Test]
        public void TCID2()
        {
            var mp = new MainPage(Driver);
            mp.popularAndBestSellersTab.SwitchToBestSellersTab();
            Assert.IsTrue(bestSellersTabParent.GetAttribute("class") == "active");
            mp.popularAndBestSellersTab.SwitchToPopularTab();
            Assert.IsTrue(popularTabParent.GetAttribute("class") == "active");
        }
    }
}
