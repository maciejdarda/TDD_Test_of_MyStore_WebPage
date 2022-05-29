using NUnit.Framework;
using OpenQA.Selenium;
using TDD_Test_of_CUX.Pages;

namespace TDD_Test_of_CUX.Tests
{
    [TestFixture]
    [Category("Main Page funcionality and navigation")]
    internal class MainPageTests : BaseTest
    {
        [Description("Test if Page can be open")]
        [Property("Author", "Maciej Darda")]
        [Test]
        public void TCID1()
        {
            Assert.IsTrue(Driver.Title == "My Store" && Driver.FindElement(By.XPath(@"//img[@class='logo img-responsive']")).Displayed);
        }

        [Description("Test swiching between POPULAR and BEST SELLERS tabs")]
        [Property("Author", "Maciej Darda")]
        [Test]
        public void TCID2()
        {
            var mp = new MainPage(Driver);
            mp.popularAndBestSellersTab.SwitchToPopularTab();
            mp.popularAndBestSellersTab.SwitchToBestSellersTab();

        }
    }
}
