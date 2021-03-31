using Shark;
using Shark.Web.Infrastructure;

namespace Rocket.SystemTests
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using Rocket.SystemTests.Configuration;
    using Shark.Web;
    using Shark.Web.Components;

    public class March30Tests : WebTest
    {

        [Test]
        [TestCase(BrowserType.Chrome)]
        [TestCase(BrowserType.Firefox)]
        [TestCase(BrowserType.Edge)]
        public void RunManyBrowsers(BrowserType browserType)
        {
            var siteSettings = this.Configuration.GetSiteSettings();
            this.Navigation.GoTo(siteSettings.DemoSite);
            var locator = "//h2[text()='Proton Rocket']/parent::a";
            var protonRocket = this.Component.CreateByXpath<Anchor>(locator);

            string expectedHref = "http://demos.bellatrix.solutions/product/proton-rocket/";
            Assert.AreEqual(expectedHref, protonRocket.Href);
        }

        [Test]
        public void VerifySearchingWithinImg()
        {
            var siteSettings = this.Configuration.GetSiteSettings();
            this.Navigation.GoTo(siteSettings.DemoSite);

            var locator = "//h2[text()='Proton Rocket']/parent::a"; // the element we want to find inside the image
            var foundAnchor = this.Component.Create<Anchor>(By.XPath(locator));
            var foundImage = foundAnchor.CreateByTag<Image>("img");
            Logger.Info(foundImage.SourceElement.GetAttribute("innerHTML"));
            string expectedSrc =
                "http://demos.bellatrix.solutions/wp-content/uploads/2018/04/640px-Proton_Zvezda_crop-324x324.jpg";
           // foundImage.ValidateSrc(expectedSrc);
            var stg = foundImage.CreateByIdEndingWith("last");
        }

        [Test]
        public void VerifySearchingWithCustomSelector()
        {
            var siteSettings = this.Configuration.GetSiteSettings();
            this.Navigation.GoTo(siteSettings.DemoSite);

            var locator = "//h2[text()='Proton Rocket']/parent::a"; // the element we want to find inside the image
            var foundAnchor = this.Component.Create<Anchor>(By.XPath(locator));
            var stg = foundAnchor.CreateByIdEndingWith("last");
        }

        [Test]
        public void ChainWaits()
        {
            var siteSettings = this.Configuration.GetSiteSettings();
            this.Navigation.GoTo(siteSettings.DemoSite);

            var locator = "//h2[text()='Proton Rocket']/parent::a"; // the element we want to find inside the image
            var foundAnchor = this.Component.Create<Anchor>(By.XPath(locator)).ToBeClickable().ToBeVisible();
            var foundChild = foundAnchor.CreateByTag<Image>("img").ToBeClickable().ToBeVisible();

            string expectedSrc =
                "http://demos.bellatrix.solutions/wp-content/uploads/2018/04/640px-Proton_Zvezda_crop-324x324.jpg";
            Assert.AreEqual(expectedSrc, foundChild.Src);
        }

        [Test]
        public void SmartAssertCart()
        {
            var siteSettings = this.Configuration.GetSiteSettings();
            this.Navigation.GoTo(siteSettings.DemoSite + "cart/");

            var locator = "//h2[text()='Proton Rocket']/parent::a"; // the element we want to find inside the image
            var foundAnchor = this.Component.Create<Anchor>(By.XPath(locator)).ToBeClickable().ToBeVisible();
         //   var foundChild = foundAnchor.CreateByTag<Image>("img").ToBeClickable().ToBeVisible().validateSrc();
        }
    }
}
