namespace Cache.Tests
{
    using System.Linq;
    using CodeCop.Core.Contracts;
    using NUnit.Framework;

    [TestFixture]
    public class TypeResolverTests
    {
        [Test]
        public void ResolveAllOfT_GivenICopIntercept_ReturnsRegisteredInterceptorAspects()
        {
            // arrange
            var sut = new TypeResolver();

            // act
            var registeredAspects = sut.ResolveAll<ICopIntercept>();

            // assert
            Assert.That(registeredAspects.Count(), Is.EqualTo(1));
        }

        [Test]
        public void ResolveAllOfT_GivenICache_ReturnsRegisteredCacheImplementation()
        {
            // arrange
            var sut = new TypeResolver();

            // act
            var registeredCaches = sut.ResolveAll<ICache>();

            // assert
            Assert.That(registeredCaches.Count(), Is.EqualTo(1));
        }

        [Test]
        public void Dispose_CalledTwice_ShouldNotThrow()
        {
            // arrange
            var sut = new TypeResolver();

            // act
            sut.Dispose();

            // assert
            Assert.DoesNotThrow(() => sut.Dispose());
        }
    }
}
