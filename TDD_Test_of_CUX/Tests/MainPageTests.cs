using NLog;
using NUnit.Framework;
using OpenQA.Selenium;

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
        public IWebElement Homeslider => Driver.FindElement(By.Id("homeslider"));



        [Description("Page opening test")]
        [Property("Author", "Maciej Darda")]
        [Test]
        public void TCID1()
        {
            LoggerObj.Debug("TCID1 - started");

            //page opening evoked in the [SetUp] from the BaseTest class
            //MainPageObj intialized in the BaseTest
            MainPageObj.AssertThatPageIsOpen(Driver, Logo);
            LoggerObj.Debug("TCID1 - stopped");
        }

        [Description("Switching between POPULAR and BESTSELLERS tabs test")]
        [Property("Author", "Maciej Darda")]
        [Test]
        public void TCID2()
        {
            LoggerObj.Debug("TCID2 - started");

            //MainPageObj intialized in the BaseTest
            MainPageObj.PopularAndBestSellersTab.SwitchToBestSellersTab();
            MainPageObj.PopularAndBestSellersTab.AssertThatElementIsActive(BestSellersTabParent);
            MainPageObj.PopularAndBestSellersTab.SwitchToPopularTab();
            MainPageObj.PopularAndBestSellersTab.AssertThatElementIsActive(PopularTabParent);
            LoggerObj.Debug("TCID2 - stopped");
        }

        [Description("HomepageSlaider test")]
        [Property("Author", "Maciej Darda")]
        [Test]
        public void TCID3()
        {
            LoggerObj.Debug("TCID3 - started");

            //NextButton functionality test #1
            var currentHomeslider = Homeslider.GetAttribute("style");

            //MainPageObj intialized in the BaseTest
            MainPageObj.HomepageSlider.SwitchAdverToNext();
            var nextHomeslider = Homeslider.GetAttribute("style");
            MainPageObj.HomepageSlider.AssertThatAdHasChange(currentHomeslider, nextHomeslider);

            //NextButton functionality test #2
            currentHomeslider = Homeslider.GetAttribute("style");
            MainPageObj.HomepageSlider.SwitchAdverToNext();
            nextHomeslider = Homeslider.GetAttribute("style");
            MainPageObj.HomepageSlider.AssertThatAdHasChange(currentHomeslider, nextHomeslider);

            //PrevButton functionality test #1
            currentHomeslider = Homeslider.GetAttribute("style");
            MainPageObj.HomepageSlider.SwitchAdverToPrev();
            nextHomeslider = Homeslider.GetAttribute("style"); 
            MainPageObj.HomepageSlider.AssertThatAdHasChange(currentHomeslider, nextHomeslider);

            //PrevButton functionality test #2
            currentHomeslider = Homeslider.GetAttribute("style");
            MainPageObj.HomepageSlider.SwitchAdverToPrev();
            nextHomeslider = Homeslider.GetAttribute("style");
            MainPageObj.HomepageSlider.AssertThatAdHasChange(currentHomeslider, nextHomeslider);

            LoggerObj.Debug("TCID3 - stopped");
        }
    }
}
