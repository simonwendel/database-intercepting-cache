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
            // act
            var registeredAspects = TypeResolver.ResolveAll<ICopIntercept>();

            // assert
            Assert.That(registeredAspects.Count(), Is.EqualTo(2));
        }

        [Test]
        public void Instance_WhenInvoked_ShouldReturnSingleton()
        {
            // act
            var firstInstance = TypeResolver.Instance;
            var secondInstance = TypeResolver.Instance;

            // assert
            Assert.That(firstInstance, Is.SameAs(secondInstance));
        }
    }
}
