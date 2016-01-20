namespace Cache.Tests
{
    using System;
    using System.Data.Common;
    using System.Data.SqlClient;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
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
            Assert.Throws<ArgumentNullException>(() => sut.GetDataReader(null, () => new MockDataReader()));
        }

        [Test]
        public void GetSqlDataReader_GivenNullQuery_ThrowsException()
        {
            // arrange
            var sut = new NonExpiringCache(Mock.Of<IBackingStore>());

            // assert
            Assert.Throws<ArgumentNullException>(() => sut.GetDataReader(new SqlCommand(), null));
        }

        [Test]
        public void GetSqlDataReader_GivenCommand_ChecksBackingStore()
        {
            // arrange
            var storeMock = new Mock<IBackingStore>();
            storeMock
                .Setup(x => x.ContainsKey(It.IsAny<string>()))
                .Returns(true);

            var sut = new NonExpiringCache(storeMock.Object);

            // act
            sut.GetDataReader(new SqlCommand(), () => new MockDataReader());

            // assert
            storeMock.Verify(
                x => x.ContainsKey(It.IsAny<string>()), 
                Times.Once());
        }

        [Test]
        public void GetSqlDataReader_GivenCachedCommand_ReturnsCachedResult()
        {
            // arrange
            var expected = new MockDataReader();

            var storeMock = new Mock<IBackingStore>();
            storeMock
                .Setup(x => x.ContainsKey(It.IsAny<string>()))
                .Returns(true);

            storeMock
                .Setup(x => x.Get(It.IsAny<string>()))
                .Returns(expected);

            var sut = new NonExpiringCache(storeMock.Object);

            // act
            var actual = sut.GetDataReader(new SqlCommand(), () => new MockDataReader());

            // assert
            Assert.That(actual, Is.SameAs(expected));

            storeMock.Verify(
                x => x.Get(It.IsAny<string>()),
                Times.Once());
        }

        [Test]
        public void GetSqlDataReader_GivenNonCachedCommand_CallsQueryAndReturnsResult()
        {
            // arrange
            var queryWasCalled = false;
            var expected = new MockDataReader();

            Func<DbDataReader> query = () => { queryWasCalled = true; return expected; };

            var storeMock = new Mock<IBackingStore>();
            storeMock
                .Setup(x => x.ContainsKey(It.IsAny<string>()))
                .Returns(false);

            storeMock
                .Setup(x => x.Add(It.IsAny<string>(), It.IsAny<DbDataReader>()));

            var sut = new NonExpiringCache(storeMock.Object);

            // act
            var actual = sut.GetDataReader(new SqlCommand(), query);

            // assert
            Assert.That(actual, Is.InstanceOf<CacheableDataReader>());
            Assert.That(queryWasCalled, Is.True);
        }

        [Test]
        public void GetSqlDataReader_GivenNonCachedCommand_StoresResult()
        {
            // arrange
            var expected = new MockDataReader();
            Func<DbDataReader> query = () => expected;

            var storeMock = new Mock<IBackingStore>();
            storeMock
                .Setup(x => x.ContainsKey(It.IsAny<string>()))
                .Returns(false);

            storeMock
                .Setup(x => x.Add(It.IsAny<string>(), It.IsAny<DbDataReader>()));

            var sut = new NonExpiringCache(storeMock.Object);

            // act
            var actual = sut.GetDataReader(new SqlCommand(), query);

            // assert
            storeMock.Verify(
                x => x.Add(It.IsAny<string>(), It.IsAny<DbDataReader>()),
                Times.Once());
        }

        [Test]
        public void GetSqlDataReader_WhenBackingStoreThrows_ReThrowsException()
        {
            // arrange
            var expected = new ApplicationException();

            var storeMock = new Mock<IBackingStore>();
            storeMock
                .Setup(x => x.ContainsKey(It.IsAny<string>()))
                .Returns(false);

            storeMock
                .Setup(x => x.Add(It.IsAny<string>(), It.IsAny<DbDataReader>())).Throws(expected);

            var sut = new NonExpiringCache(storeMock.Object);

            // assert
            Assert.Throws(Is.SameAs(expected), () => sut.GetDataReader(new SqlCommand(), () => new MockDataReader()));
        }
    }
}
