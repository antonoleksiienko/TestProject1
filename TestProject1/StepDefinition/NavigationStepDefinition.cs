using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace TestProject1.StepDefinition
{
    [Binding]
    public class NavigationStepDefinition
    {
        private readonly IWebDriver _driver;
        private readonly Config _config;

        public NavigationStepDefinition(IWebDriver driver, Config config)
        {
            _driver = driver;
            _config = config;
        }

        [Given(@"User opens '(.*)' page")]
        [When(@"User opens '(.*)' page")]
        public void UserOpenPage(string pageName)
        {
            string url = GetPageUrl(pageName);
            _driver.Navigate().GoToUrl(url);
        }

        private string GetPageUrl(string pageName)
        {
            return pageName switch
            {
                "Main" => $"{_config.Url}",
                "Login" => $"{_config.Url}/login",
                "SomePage" => $"{_config.Url}/somePage",
                _ => throw new Exception($"Page with name {pageName} not found")
            };
        }
    }
}
