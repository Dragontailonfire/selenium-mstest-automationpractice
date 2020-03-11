using OpenQA.Selenium;
using System.Threading;

namespace Pages
{
    public class AddedToCartModalPage : Page
    {
        public AddedToCartModalPage(IWebDriver driver) : base(driver)
        {
        }
        public AddedToCartModalPage VerifyPageIsDisplayed()
        {

            By locator = By.XPath("//*[text()[contains(.,'Product successfully added to your shopping cart')]]");
            IWebElement element = Driver.FindElement(locator);
            return this;
        }

        public void ClickProceedToCheckout()
        {
            //TODO: The dynamic waits are not working in this case. Adding sleep as temporary workaround.
            Thread.Sleep(2000);
            By locator = By.XPath("//*[text()[contains(.,'Proceed to checkout')]]");
            ClickThisButton(locator);
        }
    }
}
