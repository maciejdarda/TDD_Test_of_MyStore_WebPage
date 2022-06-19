using AventStack.ExtentReports;
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
            //MainPageObj intialized in the BaseTest
            MainPageObj.AssertThatPageIsOpen(Driver, Logo);
            LoggerObj.Debug("TCID1 - stopped");
        }

        [Description("POPULAR and BESTSELLERS - test switching between tabs")]
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

        [Description("HomepageSlaider - test switching ads")]
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

        [Description("Newsletter - test the behavior when providing incorrect data or the lack")]
        [Property("Author", "Maciej Darda")]
        [Test]
        public void TCID4()
        {
            LoggerObj.Debug("TCID4 - started");

            //MainPageObj intialized in the BaseTest
            //case 1 - submit incorrect email
            MainPageObj.Newsletter.SendKeysToNewsLetter("bad_mail");
            MainPageObj.Newsletter.SubmitNewsletter();
            MainPageObj.Newsletter.AssertIncorrectNewsletterSubmission();

            //caes 2 - submit empty emial
            MainPageObj.MoveToElement(NewsletterElement);
            Reporter.LogTestStepForBugLogger(Status.Info, "MoveTo - Newsletter");
            Reporter.LogTestStepForBugLogger(Status.Info, "SendKeys - To Newsletter empty string");
            
            //Newsletter input should be empty after first invalid submit
            MainPageObj.Newsletter.SubmitNewsletter();
            MainPageObj.Newsletter.AssertIncorrectNewsletterSubmission();

            LoggerObj.Debug("TCID4 - stopped");
        }

        [Description("Newsletter - test the behavior when providing valid email")]
        [Property("Author", "Maciej Darda")]
        [Test]
        public void TCID5()
        {
            LoggerObj.Debug("TCID5 - started");

            //MainPageObj intialized in the BaseTest
            MainPageObj.Newsletter.SendKeysToNewsLetter("goodmail@gmail.com");
            MainPageObj.Newsletter.SubmitNewsletter();
            MainPageObj.Newsletter.AssertProvidingValidEmail();

            LoggerObj.Debug("TCID5 - stopped");
        }

        [Description("TopMemu - test unfold content after hover on WOMEN item")]
        [Property("Author", "Maciej Darda")]
        [Test]
        public void TCID6()
        {
            LoggerObj.Debug("TCID6 - started");

            //MainPageObj intialized in the BaseTest
            MainPageObj.TopMenu.MoveMouseOverWomenItem();

            LoggerObj.Debug("TCID6 - stopped");
        }
    }
}
