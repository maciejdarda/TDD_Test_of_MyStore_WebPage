using NUnit.Framework;
using NLog;

namespace TDD_Test_of_MyStore.Tests
{
    [TestFixture]
    [Category("Cart funcionality and navigation")]
    class CartTests : BaseTest
    {
        [Description("Cart - test opening of the cart page")]
        [Property("Author", "Maciej Darda")]
        [Test]
        public void TestCase_1_CartPageShouldOpen()
        {
            PageObejcts.CartOnMainPage.OpenCartPage();
            PageObejcts.CartOnMainPage.AssertThatCartPageIsOpen();
        }

        [Description("Cart - test add item to the cart")]
        [Property("Author", "Maciej Darda")]
        [Test]
        public void TestCase_2_AddItemToCartShouldBePosible()
        {
            PageObejcts.CentralColumn.AddItemToCart();
            PageObejcts.CartOnMainPage.AssertThatItemIsAddedToCart();
        }
    }
}
