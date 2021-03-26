namespace Shark.Configuration
{
    using Microsoft.Extensions.Configuration;

    public sealed class ConfigurationService
    {
        private static ConfigurationService instance;

        private ConfigurationService()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile(this.GetConfigFile(), optional: false, reloadOnChange: true);
            this.Root = builder.Build();
        }

        public static ConfigurationService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConfigurationService();
                }

                return instance;
            }
        }

        public IConfigurationRoot Root { get; }

        private string GetConfigFile()
        {
#if DEV
            return "FrameworkSettings.dev.json";
#endif
#if QA
            return "FrameworkSettings.qa.json";
#endif
#if PROD
            return "FrameworkSettings.prod.json";
#endif
        }
    }
}
