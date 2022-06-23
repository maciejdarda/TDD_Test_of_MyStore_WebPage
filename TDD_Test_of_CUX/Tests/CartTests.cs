using NUnit.Framework;
using NLog;

namespace TDD_Test_of_MyStore.Tests
{
    [TestFixture]
    [Category("Cart funcionality and navigation")]
    class CartTests : BaseTest
    {
        private static Logger LoggerObj = LogManager.GetCurrentClassLogger();

        [Description("Cart - test opening of the cart page")]
        [Property("Author", "Maciej Darda")]
        [Test]
        public void TCID1()
        {
            LoggerObj.Debug("TCID1 - started");

            PageObejcts.CartOnMainPage.OpenCartPage();
            PageObejcts.CartOnMainPage.AssertThatCartPageIsOpen();

            LoggerObj.Debug("TCID1 - stopped");
        }

    }
}
