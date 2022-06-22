using AventStack.ExtentReports;
using NLog;
using NUnit.Framework;
using OpenQA.Selenium;

namespace TDD_Test_of_MyStore.Tests
{
    [TestFixture]
    [Category("Main Page funcionality and navigation")]
    internal class MainPageTests : BaseTest
    {
        private static Logger LoggerObj = LogManager.GetCurrentClassLogger();

        IWebElement Logo => Driver.FindElement(By.XPath(@"//img[@class='logo img-responsive']"));
        IWebElement PopularTab => Driver.FindElement(By.XPath(@"//a[@href='#homefeatured']"));
        IWebElement BestSellersTab => Driver.FindElement(By.XPath(@"//a[@href='#blockbestsellers']"));
        IWebElement BestSellersTabParent => BestSellersTab.FindElement(By.XPath("./.."));
        IWebElement PopularTabParent => PopularTab.FindElement(By.XPath("./.."));
        IWebElement Homeslider => Driver.FindElement(By.Id("homeslider"));
        IWebElement NewsletterElement => Driver.FindElement(By.Id("newsletter_block_left"));



        [Description("MainPage - test opening of the web page")]
        [Property("Author", "Maciej Darda")]
        [Test]
        public void TCID1()
        {
            LoggerObj.Debug("TCID1 - started");

            //page opening evoked in the [SetUp] from the BaseTest class
            //PageObejcts intialized in the BaseTest
            PageObejcts.MainPage.AssertThatPageIsOpen(Driver, Logo);
            LoggerObj.Debug("TCID1 - stopped");
        }

        [Description("POPULAR and BESTSELLERS - test switching between tabs")]
        [Property("Author", "Maciej Darda")]
        [Test]
        public void TCID2()
        {
            LoggerObj.Debug("TCID2 - started");

            //PageObejcts intialized in the BaseTest
            PageObejcts.PopularAndBestSellersTab.SwitchToBestSellersTab();
            PageObejcts.PopularAndBestSellersTab.AssertThatElementIsActive(BestSellersTabParent);
            PageObejcts.PopularAndBestSellersTab.SwitchToPopularTab();
            PageObejcts.PopularAndBestSellersTab.AssertThatElementIsActive(PopularTabParent);
            LoggerObj.Debug("TCID2 - stopped");
        }

        [Description("HomepageSlaider - test switching ads")]
        [Property("Author", "Maciej Darda")]
        [Test]
        public void TCID3()
        {
            LoggerObj.Debug("TCID3 - started");

            //NextButton functionality test #1
            var currentHomeslider = Homeslider.GetAttribute("style");

            //PageObejcts intialized in the BaseTest
            PageObejcts.HomepageSlider.SwitchAdverToNext();
            var nextHomeslider = Homeslider.GetAttribute("style");
            PageObejcts.HomepageSlider.AssertThatAdHasChange(currentHomeslider, nextHomeslider);

            //NextButton functionality test #2
            currentHomeslider = Homeslider.GetAttribute("style");
            PageObejcts.HomepageSlider.SwitchAdverToNext();
            nextHomeslider = Homeslider.GetAttribute("style");
            PageObejcts.HomepageSlider.AssertThatAdHasChange(currentHomeslider, nextHomeslider);

            //PrevButton functionality test #1
            currentHomeslider = Homeslider.GetAttribute("style");
            PageObejcts.HomepageSlider.SwitchAdverToPrev();
            nextHomeslider = Homeslider.GetAttribute("style");
            PageObejcts.HomepageSlider.AssertThatAdHasChange(currentHomeslider, nextHomeslider);

            //PrevButton functionality test #2
            currentHomeslider = Homeslider.GetAttribute("style");
            PageObejcts.HomepageSlider.SwitchAdverToPrev();
            nextHomeslider = Homeslider.GetAttribute("style");
            PageObejcts.HomepageSlider.AssertThatAdHasChange(currentHomeslider, nextHomeslider);

            LoggerObj.Debug("TCID3 - stopped");
        }

        [Description("Newsletter - test the behavior when providing incorrect data or the lack")]
        [Property("Author", "Maciej Darda")]
        [Test]
        public void TCID4()
        {
            LoggerObj.Debug("TCID4 - started");

            //PageObejcts intialized in the BaseTest
            //case 1 - submit incorrect email
            PageObejcts.Newsletter.SendKeysToNewsLetter("bad_mail");
            PageObejcts.Newsletter.SubmitNewsletter();
            PageObejcts.Newsletter.AssertIncorrectNewsletterSubmission();

            //caes 2 - submit empty emial
            PageObejcts.MoveToElement(NewsletterElement);
            Reporter.LogTestStepForBugLogger(Status.Info, "MoveTo: Newsletter");
            Reporter.LogTestStepForBugLogger(Status.Info, "SendKeys: To Newsletter empty string");

            //Newsletter input should be empty after first invalid submit
            PageObejcts.Newsletter.SubmitNewsletter();
            PageObejcts.Newsletter.AssertIncorrectNewsletterSubmission();

            LoggerObj.Debug("TCID4 - stopped");
        }

        [Description("Newsletter - test the behavior when providing valid email")]
        [Property("Author", "Maciej Darda")]
        [Test]
        public void TCID5()
        {
            LoggerObj.Debug("TCID5 - started");

            //PageObejcts intialized in the BaseTest
            PageObejcts.Newsletter.SendKeysToNewsLetter("goodmail@gmail.com");
            PageObejcts.Newsletter.SubmitNewsletter();
            PageObejcts.Newsletter.AssertProvidingValidEmail();

            LoggerObj.Debug("TCID5 - stopped");
        }

        [Description("TopMemu - test unfold context panel after hover over WOMEN item")]
        [Property("Author", "Maciej Darda")]
        [Test]
        public void TCID6()
        {
            LoggerObj.Debug("TCID6 - started");

            //PageObejcts intialized in the BaseTest
            PageObejcts.TopMenu.MoveMouseOverWomenItem();
            PageObejcts.TopMenu.AssertWomenItemDisplayed();

            LoggerObj.Debug("TCID6 - stopped");
        }
    }
}
