namespace Rocket.SystemTests
{
    using NUnit.Framework;
    using Rocket.SystemTests.Pages.MainPage;
    using Shark.Web;

    public class MainPageTests : WebTest
    {
        private readonly MainPage mainPage = new MainPage();

        [SetUp]
        public void SetUp()
        {
            this.mainPage.Open();
        }

        [Test]
        public void PageTitleIsCorrect()
        {
            Assert.AreEqual(this.mainPage.Title, this.Browser.Title);
        }

        [Test]
        public void SearchIsVisible()
        {
            this.mainPage.Assertions.AssertSearchIsVisible();
        }

        [Test]
        public void CanAddProductToCart()
        {
            this.mainPage.AddItemToCart("Falcon Heavy");
            this.mainPage.Assertions.AssertViewCartIsVisible();
        }
    }
}