using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;

namespace TestProject2.StepDefinition
{
    [Binding]
    public class BaseStepDefinition
    {
        protected static Config Config = new();

        [BeforeTestRun]
        public static void BeforeAll()
        {
            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
            configurationRoot.Bind(Config);
        }
    }
}
