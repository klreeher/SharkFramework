namespace Rocket.SystemTests.Pages.MainPage
{
    using NUnit.Framework;

#pragma warning disable SA1600 // Elements should be documented
    public class Assertions : Shark.Web.Pages.WebAssertions<Map>
#pragma warning restore SA1600 // Elements should be documented
    {

        public void AssertViewCartIsVisible()
        {
            Assert.IsTrue(this.Map.ViewCart.IsVisible);
        }

        public void AssertSearchIsVisible()
        {
            Assert.IsTrue(this.Map.SearchInput.IsVisible);
        }
    }
}
