using BoDi;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace TestProject1.StepDefinition
{
    [Binding]
    public sealed class Hooks
    {
        private static readonly Config _config = new();
        private readonly IObjectContainer _container;

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {            
            IConfiguration configurationRoot = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
            configurationRoot.Bind(_config);
        }

        [BeforeScenario]
        public void SetUpBase()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            _container.RegisterInstanceAs<IWebDriver>(driver);
            _container.RegisterInstanceAs<Config>(_config);
        }


        [AfterScenario]
        public void TearDown()
        {
            IWebDriver driver = _container.Resolve<IWebDriver>();

            driver.Quit();
        }
    }
}