namespace Cache.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture, Category("NonExpiringCache")]
    public class NonExpiringCacheTests
    {
        [Test]
        public void Ctor_GivenNullStorage_ThrowsException()
        {
            // assert
            Assert.Throws<ArgumentNullException>(() => new NonExpiringCache(null));
        }
    }
}
