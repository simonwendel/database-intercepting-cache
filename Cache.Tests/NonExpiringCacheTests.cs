namespace Cache.Tests
{
    using System;
    using System.Data.SqlClient;
    using Moq;
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

        [Test]
        public void GetSqlDataReader_GivenNullCommand_ThrowsException()
        {
            // arrange
            var sut = new NonExpiringCache(Mock.Of<IBackingStore>());

            // assert
            Assert.Throws<ArgumentNullException>(() => sut.GetSqlDataReader(null, () => new object()));
        }

        [Test]
        public void GetSqlDataReader_GivenNullQuery_ThrowsException()
        {
            // arrange
            var sut = new NonExpiringCache(Mock.Of<IBackingStore>());

            // assert
            Assert.Throws<ArgumentNullException>(() => sut.GetSqlDataReader(new SqlCommand(), null));
        }
    }
}
