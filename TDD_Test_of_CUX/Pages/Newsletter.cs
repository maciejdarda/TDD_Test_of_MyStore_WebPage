using OpenQA.Selenium;
using TDD_Test_of_CUX;

namespace TDD_Test_of_MyStore.Pages
{
    internal class Newsletter : BaseClass
    {
        //constructor with reference to BaseClass
        public Newsletter(IWebDriver driver) : base(driver)
        {
        }

        IWebElement NewsletterElement => _driver.FindElement(By.Id("newsletter_block_left"));

        internal void SendKeysToNewsLetter(string text)
        {
            //method from BaseClass
            MoveToElement(NewsletterElement);   

            //method from BaseClass

        }
    }
}
