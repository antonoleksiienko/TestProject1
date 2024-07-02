using OpenQA.Selenium;

namespace TestProject1.Pages
{
    public class LoginPage
    {
        private readonly By _userNameFieldSelector = By.XPath("//input[@name='username']");
        private readonly By _passwordFieldSelector = By.XPath("//input[@name='password']");
        private readonly By _loginButtonSelector = By.XPath("//button[@name='login']");
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement UserNameField => _driver.WaitForElementToBeVisible(drv => drv.FindElement(_userNameFieldSelector));
        private IWebElement PasswordField => _driver.WaitForElementToBeVisible(drv => drv.FindElement(_passwordFieldSelector));
        public IWebElement LoginButton => _driver.WaitForElementToBeVisible(drv => drv.FindElement(_loginButtonSelector));

        public void EnterCredentials(string userName, string password)
        {
            UserNameField.Clear();
            UserNameField.Click();
            UserNameField.SendKeys(userName);
            
            PasswordField.Clear();
            PasswordField.SendKeys(password);
            PasswordField.Click();
        }
    }
}
