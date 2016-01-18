namespace Cache.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture, Category("NonInvalidatingCache")]
    public class NonInvalidatingCacheTests
    {
        [Test]
        public void Ctor_GivenNullStorage_ThrowsException()
        {
            // assert
            Assert.Throws<ArgumentNullException>(() => new NonInvalidatingCache(null));
        }
    }
}
