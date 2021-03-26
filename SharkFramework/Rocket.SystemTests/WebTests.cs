namespace Rocket.SystemTests
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using Rocket.SystemTests.Configuration;
    using Shark.Web;
    using Shark.Web.Components;

    public class WebTests : WebTest
    {
        private string baseURL = "http://demos.bellatrix.solutions/";

        [Test]
        public void BrowserServiceShouldBeExposed()
        {
            this.Navigation.GoTo(this.baseURL);
            StringAssert.Contains("Bellatrix Demos", this.Browser.Title);
        }

        [Test]
        public void CanGetImageSourceUrl()
        {
            // act
            this.Navigation.GoTo(this.baseURL);
            By imageLocator = By.XPath("//h2[text()='Proton Rocket']/preceding-sibling::img");
            var protonRocket = this.Component.Create<Image>(imageLocator);

            // assert
            string expectedUrl =
                            "http://demos.bellatrix.solutions/wp-content/uploads/2018/04/640px-Proton_Zvezda_crop-324x324.jpg";

            Assert.AreEqual(expectedUrl, protonRocket.Src);
        }

        [Test]
        public void CanGetProtonRocketHref()
        {
            this.Navigation.GoTo(this.baseURL);
            By locator = By.XPath("//h2[text()='Proton Rocket']/parent::a");
            var protonRocket = this.Component.Create<Anchor>(locator);

            string expectedHref = "http://demos.bellatrix.solutions/product/proton-rocket/";
            Assert.AreEqual(expectedHref, protonRocket.Href);
        }

        [Test]
        public void CanGetImageSourceUrlByXpath()
        {
            // act
            this.Navigation.GoTo(this.baseURL);
            string imageLocator = "//h2[text()='Proton Rocket']/preceding-sibling::img";
            var protonRocket = this.Component.CreateByXpath<Image>(imageLocator);

            // assert
            string expectedUrl =
                "http://demos.bellatrix.solutions/wp-content/uploads/2018/04/640px-Proton_Zvezda_crop-324x324.jpg";

            Assert.AreEqual(expectedUrl, protonRocket.Src);
        }

        [Test]
        public void CanGetProtonRocketHrefByXpath()
        {
            this.Navigation.GoTo(this.baseURL);
            var locator = "//h2[text()='Proton Rocket']/parent::a";
            var protonRocket = this.Component.CreateByXpath<Anchor>(locator);

            string expectedHref = "http://demos.bellatrix.solutions/product/proton-rocket/";
            Assert.AreEqual(expectedHref, protonRocket.Href);
        }

        [Test]
        public void CanGetCorrectTimeoutSettingFromJsonFile()
        {
            var timeoutSetting = this.Configuration.GetTimeoutSettings();
            Assert.AreEqual(10, timeoutSetting.WaitForElementTimeout);
        }

        [Test]
        public void CanGetCorrectSiteUrlSettingFromJsonFile()
        {
            var siteUrls = this.Configuration.GetSiteSettings();
            Assert.AreEqual(this.baseURL, siteUrls.DemoSite);
#if QA
      Assert.AreEqual("https://stackoverflow.com/", siteUrls.GoogleSite);
#endif
#if DEV
            Assert.AreEqual("https://google.com/", siteUrls.GoogleSite);
#endif
        }
    }
}