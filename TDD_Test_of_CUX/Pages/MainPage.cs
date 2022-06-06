using NLog;
using OpenQA.Selenium;
using System;
using TDD_Test_of_MyStore;
using TDD_Test_of_MyStore.Pages;

namespace TDD_Test_of_CUX.Pages
{
    internal class MainPage : BaseClass
    {
        public MainPage(IWebDriver driver) : base(driver)
        {
            popularAndBestSellersTab = new PopularAndBestSellersTab(driver);
        }

        private static Logger LoggerObj = LogManager.GetCurrentClassLogger();
        internal PopularAndBestSellersTab popularAndBestSellersTab { get; set; }

        string url = "http://automationpractice.com";

        internal void GoTo()
        {
            try
            {
                _driver.Navigate().GoToUrl(@url);
                Reporter.LogPassingTestStepToBugLogger($"Page {@url} - Loaded");
                _driver.Manage().Window.Maximize();
            }
            catch (Exception ex)
            {
                LoggerObj.Error(ex.Message);
            }  
        }
    }
}
