namespace Rocket.SystemTests.Configuration
{
    using Microsoft.Extensions.Configuration;
    using Shark.Configuration;

    public static class SiteSettingsConfigurationExtensions
    {
        public static SiteSettings GetSiteSettings(this ConfigurationService configurationService)
        {
            return configurationService.Root.GetSection("siteSettings").Get<SiteSettings>();
        }
    }
}
