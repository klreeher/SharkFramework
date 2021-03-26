namespace Rocket.SystemTests.Pages.MainPage
{
    using Rocket.SystemTests.Configuration;
    using Shark.Configuration;
    using Shark.Web.Components;
    using Shark.Web.Pages;
    using Shark.Web.Services;

    public class MainPage : WebPage<Map, Assertions>
    {
        public override string Url => ConfigurationService.Instance.GetSiteSettings().DemoSite;

        public void AddItemToCart(string productName) => this.Map.ProductAddButton(productName).Click();
    }
}