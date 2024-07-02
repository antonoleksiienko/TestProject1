using Microsoft.Extensions.Configuration;

namespace TestProject1.StepDefinition
{
    public class BaseStepDefinition
    {
        protected static Config Config = new();
        
        public BaseStepDefinition()
        {
            IConfiguration configurationRoot = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
            configurationRoot.Bind(Config);
        }
    }
}
