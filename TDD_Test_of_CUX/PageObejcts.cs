using OpenQA.Selenium;
using TDD_Test_of_MyStore.Pages;

namespace TDD_Test_of_MyStore
{
    class PageObejcts : BaseClass
    {
        public PageObejcts(IWebDriver driver) : base(driver)
        {
            //subpages' objects inicialization
            MainPage = new MainPage(driver);
            PopularAndBestSellersTab = new PopularAndBestSellersTab(driver);
            HomepageSlider = new HomepageSlider(driver);
            Newsletter = new Newsletter(driver);
            TopMenu = new TopMenu(driver);
            CartOnMainPage = new CartOnMainPage(driver);
        }

        //subpages' objects
        public MainPage MainPage { get; set; }
        internal PopularAndBestSellersTab PopularAndBestSellersTab { get; set; }
        internal HomepageSlider HomepageSlider { get; set; }
        internal Newsletter Newsletter { get; set; }
        public TopMenu TopMenu { get; set; }
        public CartOnMainPage CartOnMainPage { get; set; }
    }
}
