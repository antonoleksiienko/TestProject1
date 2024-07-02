using OpenQA.Selenium;

namespace TestProject1.Pages
{
    public class UserProfilePage
    {
        private readonly By _successfulLoginMessageSelector = By.XPath("//h1[@id='SuccessfulLoginMessage']");
        private readonly IWebDriver _driver;

        public UserProfilePage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement SuccessfulLoginMessage => _driver.WaitForElementToBeVisible(drv => drv.FindElement(_successfulLoginMessageSelector));

        public bool IsSuccessfulLoginMessageDisplayed()
        {
            return SuccessfulLoginMessage != null;
        }

    }
}
