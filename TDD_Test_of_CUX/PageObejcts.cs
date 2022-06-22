using OpenQA.Selenium;
using TDD_Test_of_MyStore.Pages;

namespace TDD_Test_of_MyStore
{
    class PageObejcts : BaseClass
    {
        public PageObejcts(IWebDriver driver) : base(driver)
        {
            //subpages' objects inicialization
            PopularAndBestSellersTab = new PopularAndBestSellersTab(driver);
            HomepageSlider = new HomepageSlider(driver);
            Newsletter = new Newsletter(driver);
            TopMenu = new TopMenu(driver);
        }

        //subpages' objects
        public MainPage MyProperty { get; set; }
        internal PopularAndBestSellersTab PopularAndBestSellersTab { get; set; }
        internal HomepageSlider HomepageSlider { get; set; }
        internal Newsletter Newsletter { get; set; }
        public TopMenu TopMenu { get; set; }
    }
}
