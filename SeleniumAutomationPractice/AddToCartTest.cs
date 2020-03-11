using Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Pages;
using Pages.HomePage;

namespace SeleniumAutomationPractice
{
    [TestClass]
    public class AddToCartTest
    {
        IWebDriver _webDriver;
        HomePage _homePage;
        SearchCategoryResultPage _searchCategoryResultPage;
        ProductPage _productPage;
        AddedToCartModalPage _addedToCartModalPage;
        ShoppingCartSummaryPage _shoppingCartSummaryPage;

        [TestInitialize]
        public void StartUp()
        {
            _webDriver = DriverManager.Driver;
            _homePage = new HomePage(_webDriver);
            _searchCategoryResultPage = new SearchCategoryResultPage(_webDriver);
            _productPage = new ProductPage(_webDriver);
            _addedToCartModalPage = new AddedToCartModalPage(_webDriver);
            _shoppingCartSummaryPage = new ShoppingCartSummaryPage(_webDriver);
        }

        [TestMethod]
        public void AddTshirtToCartAndVerifyCheckoutPage()
        {
            _homePage
                    .NavigateHere("http://automationpractice.com/index.php")
                    .ClickMenuItem("Women");

            _searchCategoryResultPage
                    .VerifyPageIsDisplayed("WOMEN")
                    .OpenProduct("Faded Short Sleeve T-shirts");

            _productPage
                    .VerifyPageIsDisplayed("Faded Short Sleeve T-shirts")
                    .GiveProductQuantity("2")
                    .SelectProductSize("M")
                    .ClickAddToCart();

            _addedToCartModalPage
                    .VerifyPageIsDisplayed()
                    .ClickProceedToCheckout();

            _shoppingCartSummaryPage
                    .VerifyPageIsDisplayed()
                    .VerifyProductDetails("Faded Short Sleeve T-shirts", "M", "2");
        }

        [TestCleanup]
        public void ShutDown()
        {
            DriverManager.DisposeDriver();
        }
    }
}
