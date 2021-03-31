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
        [TestCase("Falcon Heavy")]
        [TestCase("Proton Rocket")]
        [TestCase("Saturn V")]
        public void CanAddProductToCart(string productName)
        {
            this.mainPage.AddItemToCart(productName);
            this.mainPage.Assertions.AssertViewCartIsVisible();
        }

        [Test]
        public void VerifyProductsInCart()
        {
            this.mainPage.AddItemToCart("Falcon Heavy");
            this.mainPage.Assertions.AssertViewCartIsVisible();
            
         
        }
    }
}