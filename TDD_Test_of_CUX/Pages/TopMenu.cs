using OpenQA.Selenium;
using System;
using System.Threading;
using TDD_Test_of_CUX;

namespace TDD_Test_of_MyStore.Pages
{
    internal class TopMenu : BaseClass
    {
        //constructor with reference to BaseClass
        public TopMenu(IWebDriver driver) : base(driver)
        {
        }

        IWebElement WomenItem => _driver.FindElement(By.XPath("//a[contains(text(), 'Women') and @title='Women']"));

        internal void MoveMouseOverWomenItem()
        {
            //TODO add report steps and try/catch
            MoveMouseOverElemnet(WomenItem);
            Thread.Sleep(5000);
        }
    }
}
