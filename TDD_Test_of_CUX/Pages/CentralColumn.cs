using AventStack.ExtentReports;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;

namespace TDD_Test_of_MyStore.Pages
{
    internal class CentralColumn : BaseClass
    {
        /// <summary>
        /// constructor with reference to BaseClass
        /// </summary>
        /// <param name="driver"></param>
        public CentralColumn(IWebDriver driver) : base(driver)
        {
        }

        IList<IWebElement> FadedShortsAddToCartButton => _driver.FindElements(By.XPath("//a[@title='Add to cart' and @data-id-product='1']"));
        IList<IWebElement> FirstItemInCentralColumn => _driver.FindElements(By.XPath("//li[@class='ajax_block_product col-xs-12 col-sm-4 col-md-3 first-in-line first-item-of-tablet-line first-item-of-mobile-line']"));
        IList<IWebElement> ImgForFirstItemInCentralColumn => _driver.FindElements(By.XPath("//img[@title='Faded Short Sleeve T-shirts' and @class='replace-2x img-responsive']"));

        internal void AddItemToCart()
        {
            MoveToElement(FirstItemInCentralColumn[0], "FirstItemInCentralColumn");
            MoveMouseOverElemnet(ImgForFirstItemInCentralColumn[0], "ImgForFirstItemInCentralColumn");
            Thread.Sleep(500);
            ClickElement(FadedShortsAddToCartButton[0], "FadedShortsAddToCartButton");
        }
    }
}
