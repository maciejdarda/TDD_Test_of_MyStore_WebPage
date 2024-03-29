﻿using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace TDD_Test_of_MyStore.Pages
{
    internal class HomepageSlider : BaseClass
    {
        /// <summary>
        /// constructor with reference to BaseClass
        /// </summary>
        /// <param name="driver"></param>
        public HomepageSlider(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement PrevButton => _driver.FindElement(By.XPath(@"//a[@class='bx-prev']"));
        public IWebElement NextButton => _driver.FindElement(By.XPath(@"//a[@class='bx-next']"));

        internal void SwitchAdverToNext()
        {
            try
            {
                ClickElement(NextButton, "NextButton");

                //time to scroll the ad
                Thread.Sleep(500);
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal void SwitchAdverToPrev()
        {
            //TODO change catches
            try
            {
                ClickElement(PrevButton, "PrevButton");

                //time to scroll the ad
                Thread.Sleep(500);
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal void AssertThatAdHasChange(string currentHomeslider, string nextHomeslider)
        {
            Assert.AreNotEqual(currentHomeslider, nextHomeslider);
            Reporter.LogPassingTestStepToBugLogger("Assert: 'Ad has changed'");
        }
    }
}
