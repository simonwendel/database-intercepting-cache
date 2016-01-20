namespace Cache.Tests
{
    using System.Linq;
    using CodeCop.Core.Contracts;
    using NUnit.Framework;

    [TestFixture, Category("TypeResolver")]
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
        public void Instance_Invoked_ShouldReturnSingleton()
        {
            // act
            var firstInstance = TypeResolver.Instance;
            var secondInstance = TypeResolver.Instance;

            // assert
            Assert.That(firstInstance, Is.SameAs(secondInstance));
        }

        [Test]
        public void Dispose_InvokedTwice_ShouldNotThrow()
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
