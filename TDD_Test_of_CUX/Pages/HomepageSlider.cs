using AventStack.ExtentReports;
using NLog;
using OpenQA.Selenium;
using System;
using TDD_Test_of_CUX;

namespace TDD_Test_of_MyStore.Pages
{
    internal class HomepageSlider : BaseClass
    {
        //constructor with reference to BaseClass
        public HomepageSlider(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement PrevButton => _driver.FindElement(By.XPath(@"//a[@class='bx-prev']"));
        public IWebElement NextButton => _driver.FindElement(By.XPath(@"//a[@class='bx-next']"));

        internal void SwitchAdverToNext()
        {
            try
            {
                NextButton.Click();
                Reporter.LogTestStepForBugLogger(Status.Info, "Click: NextAdvers button");
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal void SwitchAdverToPrev()
        {
            try
            {
                PrevButton.Click();
                Reporter.LogTestStepForBugLogger(Status.Info, "Click: NextAdvers button");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
