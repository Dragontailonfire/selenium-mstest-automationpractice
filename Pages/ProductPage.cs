using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Pages
{
    public class ProductPage : Page
    {
        public ProductPage(IWebDriver driver) : base(driver)
        {
        }
        public ProductPage VerifyPageIsDisplayed(string product)
        {
            By locator = By.XPath("//h1[@itemprop='name']");
            IWebElement element = Driver.FindElement(locator);
            return this;
        }
        public ProductPage GiveProductQuantity(string quantity)
        {
            By locator = By.Id("quantity_wanted");
            EnterTextInThisField(locator, quantity);
            return this;
        }
        public ProductPage SelectProductSize(string size)
        {
            By locator = By.Id("group_1");
            MakeDropDownSelectionUsingText(locator, size);
            return this;
        }

        public void ClickAddToCart()
        {
            WebDriverWait wait = new WebDriverWait(Driver, new System.TimeSpan(0, 0, 30));
            By locator = By.XPath("//*[text()[contains(.,'Add to cart')]]");
            wait.Until(e => e.FindElement(locator));
            IWebElement element = Driver.FindElement(locator);
            Actions builder = new Actions(Driver);
            builder.MoveToElement(element).Click();
            IAction ClickAddToCart = builder.Build();
            ClickAddToCart.Perform();
        }
    }
}
