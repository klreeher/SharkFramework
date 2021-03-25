using NUnit.Framework;
using OpenQA.Selenium;
using Shark.Web;
using Shark.Web.Components;
using Shark.Web.Services;

namespace Rocket.SystemTests
{
    public class Tests : WebTest
    {
        private string baseURL = "http://demos.bellatrix.solutions/";

        [Test]
        public void BrowserServiceShouldBeExposed()
        {
            Navigation.GoTo(baseURL);
            StringAssert.Contains("Bellatrix Demos", Browser.Title);
        }

        [Test]
        public void CanGetImageSourceUrl()
        {
            // act
            Navigation.GoTo(baseURL);
            By imageLocator = By.XPath("//h2[text()='Proton Rocket']/preceding-sibling::img");
            var protonRocket = Component.Create<Image>(imageLocator);

            // assert
            string expectedUrl =
                            "http://demos.bellatrix.solutions/wp-content/uploads/2018/04/640px-Proton_Zvezda_crop-324x324.jpg";

            Assert.AreEqual(expectedUrl, protonRocket.Src);
        }

        [Test]
        public void CanGetProtonRocketHref()
        {
            Navigation.GoTo(baseURL);
            By locator = By.XPath("//h2[text()='Proton Rocket']/parent::a");
            var protonRocket = Component.Create<Anchor>(locator);

            string expectedHref = "http://demos.bellatrix.solutions/product/proton-rocket/";
            Assert.AreEqual(expectedHref, protonRocket.Href);
        }

        [Test]
        public void CanGetImageSourceUrlByXpath()
        {
            // act
            Navigation.GoTo(baseURL);
            string imageLocator = "//h2[text()='Proton Rocket']/preceding-sibling::img";
            var protonRocket = Component.CreateByXpath<Image>(imageLocator);

            // assert
            string expectedUrl =
                "http://demos.bellatrix.solutions/wp-content/uploads/2018/04/640px-Proton_Zvezda_crop-324x324.jpg";

            Assert.AreEqual(expectedUrl, protonRocket.Src);
        }

        [Test]
        public void CanGetProtonRocketHrefByXpath()
        {
            Navigation.GoTo(baseURL);
            var locator = "//h2[text()='Proton Rocket']/parent::a";
            var protonRocket = Component.CreateByXpath<Anchor>(locator);

            string expectedHref = "http://demos.bellatrix.solutions/product/proton-rocket/";
            Assert.AreEqual(expectedHref, protonRocket.Href);
        }
    }
}