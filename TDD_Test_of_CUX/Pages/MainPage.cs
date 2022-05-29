using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using TDD_Test_of_MyStore.Pages;

namespace TDD_Test_of_CUX.Pages
{
    internal class MainPage : BaseClass
    {
        public MainPage(IWebDriver driver) : base(driver)
        {
            popularAndBestSellersTab = new PopularAndBestSellersTab(driver);
        }

        internal PopularAndBestSellersTab popularAndBestSellersTab { get; set; }

        string url = "http://automationpractice.com";

        internal void GoTo()
        {
            _driver.Navigate().GoToUrl(@url);
            _driver.Manage().Window.Maximize();
        }
    }
}
