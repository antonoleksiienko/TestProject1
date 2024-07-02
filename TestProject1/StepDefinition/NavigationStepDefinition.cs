using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace TestProject1.StepDefinition
{
    [Binding]
    public class NavigationStepDefinition : BaseStepDefinition
    {
        private readonly IWebDriver _driver;

        public NavigationStepDefinition(IWebDriver driver)
        {
            _driver = driver;
        }

        [Given(@"User opens '(.*)' page")]
        [When(@"User opens '(.*)' page")]
        public void UserOpenPage(string pageName)
        {
            string url = GetPageUrl(pageName);
            _driver.Navigate().GoToUrl(url);
        }

        private static string GetPageUrl(string pageName)
        {
            return pageName switch
            {
                "Main" => $"{Config.Url}",
                "Login" => $"{Config.Url}/login",
                "SomePage" => $"{Config.Url}/somePage",
                _ => throw new Exception($"Page with name {pageName} not found")
            };
        }
    }
}
