namespace Cache.Tests
{
    using NUnit.Framework;

    [TestFixture, Category(TestCategory.IntegrationTest)]
    public class InjectorTests
    {
        [Test]
        public void Start_WhenCalled_BootstrapsWithoutExceptions()
        {
            // assert
            Assert.DoesNotThrow(() => Injector.Start());
        }
    }
}
