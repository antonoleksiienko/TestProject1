using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProject1
{
    public class LoginAutomation
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://qa.sorted.com/newtrack");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TestCase("john_smith@sorted.com", "Pa55w0rd!", "https://qa.sorted.com/newtrack/loginSuccess")]
        public void VerifyThatUserCanLogin(string userName, string password, string expectedUrl)
        {
            IWebElement userNameField = _driver.FindElement(By.XPath("//form[@id='loginForm']/input[1]"));
            IWebElement passwordField = _driver.FindElement(By.XPath("//form[@id='loginForm']/input[2]"));
            IWebElement loginButton = _driver.FindElement(By.Id("submit"));

            userNameField.Clear();
            userNameField.SendKeys(userName);

            passwordField.Clear();
            passwordField.SendKeys(password);

            loginButton.Click();

            string actualUrl = _driver.Url;
            Assert.That(actualUrl, Is.EqualTo(expectedUrl));
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
        }
    }
}
