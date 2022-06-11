using NLog;
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
        public IWebElement Homeslider => Driver.FindElement(By.Id("homeslider"));



        [Description("Page opening test")]
        [Property("Author", "Maciej Darda")]
        [Test]
        public void TCID1()
        {
            LoggerObj.Debug("TCID1 - started");

            //page opening evoked in the [SetUp] from the BaseTest class
            Assert.IsTrue(Driver.Title == "My Store" && Logo.Displayed);
            Reporter.LogPassingTestStepToBugLogger("Assert: 'Main Window Displayed'");
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
            Assert.IsTrue(BestSellersTabParent.GetAttribute("class") == "active");
            Reporter.LogPassingTestStepToBugLogger("Assert: 'BestSeller Tab is active'");
            MainPageObj.PopularAndBestSellersTab.SwitchToPopularTab();
            Assert.IsTrue(PopularTabParent.GetAttribute("class") == "active");
            Reporter.LogPassingTestStepToBugLogger("Assert: 'Popular Tab is active'");
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

            //MainPageObj intialized in BaseTest
            MainPageObj.HomepageSlider.SwitchAdverToNext();
            var nextHomeslider = Homeslider.GetAttribute("style");
            Assert.AreNotEqual(currentHomeslider, nextHomeslider);
            Reporter.LogPassingTestStepToBugLogger("Assert: 'Ad has changed'");

            //NextButton functionality test #2
            currentHomeslider = Homeslider.GetAttribute("style");
            MainPageObj.HomepageSlider.SwitchAdverToNext();
            nextHomeslider = Homeslider.GetAttribute("style");
            Assert.AreNotEqual(currentHomeslider, nextHomeslider);
            Reporter.LogPassingTestStepToBugLogger("Assert: 'Ad has changed'");

            //PrevButton functionality test #1
            currentHomeslider = Homeslider.GetAttribute("style");
            MainPageObj.HomepageSlider.SwitchAdverToPrev();
            nextHomeslider = Homeslider.GetAttribute("style");
            Assert.AreNotEqual(currentHomeslider, nextHomeslider);
            Reporter.LogPassingTestStepToBugLogger("Assert: 'Ad has changed'");

            //PrevButton functionality test #2
            currentHomeslider = Homeslider.GetAttribute("style");
            MainPageObj.HomepageSlider.SwitchAdverToPrev();
            nextHomeslider = Homeslider.GetAttribute("style");
            Assert.AreNotEqual(currentHomeslider, nextHomeslider);
            Reporter.LogPassingTestStepToBugLogger("Assert: 'Ad has changed'");

            LoggerObj.Debug("TCID3 - stopped");
        }
    }
}
