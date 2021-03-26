﻿namespace Shark.Configuration
{
    using Microsoft.Extensions.Configuration;

    public sealed class ConfigurationService
    {
        private static ConfigurationService _instance;

        private ConfigurationService()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile(GetConfigFile(), optional: false, reloadOnChange: true);
            Root = builder.Build();
        }

        public static ConfigurationService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ConfigurationService();
                }

                return _instance;
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
