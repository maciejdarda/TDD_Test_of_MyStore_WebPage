﻿using OpenQA.Selenium;
using System;
using NUnit.Framework;
using System.Threading;

namespace TDD_Test_of_MyStore.Pages
{
    internal class Newsletter : BaseClass
    {
        /// <summary>
        /// constructor with reference to BaseClass
        /// </summary>
        /// <param name="driver"></param>
        public Newsletter(IWebDriver driver) : base(driver)
        {
        }

        IWebElement NewsletterElement => _driver.FindElement(By.Id("newsletter_block_left"));
        IWebElement NewsletterSubmitButton => _driver.FindElement(By.XPath(@"//button[@name='submitNewsletter']"));
        IWebElement AlertInvalidNewsletterSubmit => _driver.FindElement(By.XPath(@"//p[@class='alert alert-danger']"));
        IWebElement NewsletterInput => _driver.FindElement(By.Id("newsletter-input"));

        internal void SendKeysToNewsLetter(string text)
        {
            //TODO check that try statement 
            try
            {
                //method from BaseClass
                MoveToElement(NewsletterElement, "NewsletterElement");

                //method from BaseClass
                SendKeysToElement(NewsletterElement, text, "NewsletterElement");
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal void SubmitNewsletter()
        {
            try
            {
                ClickElement(NewsletterSubmitButton, "NewsletterSubmitButton");
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal void AssertIncorrectNewsletterSubmission()
        {
            try
            {
                Thread.Sleep(500);
                Assert.IsTrue(AlertInvalidNewsletterSubmit.Displayed);
                Reporter.LogPassingTestStepToBugLogger("Assert: alert displayed");
                MoveToElement(NewsletterElement, "NewsletterElement");
                Thread.Sleep(500);
                Assert.IsTrue(NewsletterInput.GetAttribute("value") == "Invalid email address.");
                Reporter.LogPassingTestStepToBugLogger("Assert: Newsleter Input value change to 'Invalid email address.'");
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal void AssertProvidingValidEmail()
        {
            //TODO add comments
            IWebElement elem;
            try
            {
                elem = _driver.FindElement(By.XPath(@"//p[@class='alert alert-success']"));
            }
            catch (Exception)
            {
                elem = _driver.FindElement(By.XPath(@"//p[@class='alert alert-danger']"));
            }

            try
            {
                Thread.Sleep(500);
                Assert.IsTrue(elem.Displayed);
                Reporter.LogPassingTestStepToBugLogger("Assert: alert displayed");
                MoveToElement(NewsletterElement, "NewsletterElement");
                Thread.Sleep(500);
                Assert.IsTrue(NewsletterInput.GetAttribute("value") == "You have successfully subscribed to this newsletter." || NewsletterInput.GetAttribute("value") == "This email address is already registered.");
                Reporter.LogPassingTestStepToBugLogger("Assert: Newsleter Input value change to 'You have successfully subscribed to this newsletter.'");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
