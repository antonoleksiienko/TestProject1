using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestProject1.Pages;

namespace TestProject1.StepDefinition
{
    [Binding]
    public class LoginStepDefinition
    {
        private readonly IWebDriver _driver;
        private readonly Config _config;
        private LoginPage _loginPage;

        private string LoginPageUrl => $"{_config.Url}/login";

        public LoginStepDefinition(IWebDriver driver, Config config)
        {
            _driver = driver;
            _config = config;
        }

        [BeforeScenario]
        public void SetUp()
        {
            _loginPage = new LoginPage(_driver);
        }

        [Given(@"I’m not logged in with a genuine user")]
        public void GivenIMNotLoggedInWithAGenuineUser_()
        {
        }

        [Given(@"valid user credentials are already registered")]
        public void GivenValidUserCredentialsAreAlreadyRegistered()
        {
        }

        [When(@"User logs in with username '(.*)' and password '(.*)'")]
        public void UserLogsIn(string username, string password)
        {
            _loginPage.EnterCredentials(username, password);
            _loginPage.LoginButton.Click();
        }

        [Then(@"User checks that login page is opened")]
        public void UserChecksLoginPageIsOpened()
        {
            Assert.That(_driver.Url, Is.EqualTo(LoginPageUrl));
        }

        [Then(@"User checks that he is logged in successfully and page '(.*)' is opened")]
        public void UserChecksThatHeIsLoggedInSuccessfullyAndIsOpened(string url)
        {
            UserProfilePage userProfilePage = new (_driver);
            Assert.True(userProfilePage.IsSuccessfulLoginMessageDisplayed(), "Successful Login Message is not visible");
            Assert.That(_driver.Url, Is.EqualTo(url));
        }
    }
}
