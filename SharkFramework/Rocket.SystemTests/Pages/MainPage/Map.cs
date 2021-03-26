namespace Rocket.SystemTests.Pages.MainPage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Shark.Web.Components;
    using Shark.Web.Services;

    public class Map : Shark.Web.Pages.WebMap
    {
        public Anchor HomeAnchor => this.ComponentService.CreateByXpath<Anchor>("//a[text()='Home']");

        public Anchor CartAnchor => this.ComponentService.CreateByXpath<Anchor>("//a[text()='Cart']");

        public Anchor ViewCart => this.ComponentService.CreateByXpath<Anchor>("//a[@title='View cart']");

        public Search SearchInput => this.ComponentService.CreateById<Search>("woocommerce-product-search-field-0");

        public Anchor ProductAddButton(string productName) =>
            this.ComponentService.CreateByXpath<Anchor>($"//a[contains(@aria-label, '{productName}')]");
    }
}
