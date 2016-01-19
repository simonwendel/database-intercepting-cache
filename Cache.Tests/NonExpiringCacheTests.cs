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
            sut.GetSqlDataReader(new SqlCommand(), () => new object());

            // assert
            storeMock.Verify(
                x => x.ContainsKey(It.IsAny<string>()), 
                Times.Once());
        }

        [Test]
        public void GetSqlDataReader_GivenCachedCommand_ReturnsCachedResult()
        {
            // arrange
            var expected = new object();

            var storeMock = new Mock<IBackingStore>();
            storeMock
                .Setup(x => x.ContainsKey(It.IsAny<string>()))
                .Returns(true);

            storeMock
                .Setup(x => x.Get(It.IsAny<string>()))
                .Returns(expected);

            var sut = new NonExpiringCache(storeMock.Object);

            // act
            var actual = sut.GetSqlDataReader(new SqlCommand(), () => new object());

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
            var expected = new object();

            Func<object> query = () => { queryWasCalled = true; return expected; };

            var storeMock = new Mock<IBackingStore>();
            storeMock
                .Setup(x => x.ContainsKey(It.IsAny<string>()))
                .Returns(false);

            storeMock
                .Setup(x => x.Add(It.IsAny<string>(), It.IsAny<object>()));

            var sut = new NonExpiringCache(storeMock.Object);

            // act
            var actual = sut.GetSqlDataReader(new SqlCommand(), query);

            // assert
            Assert.That(actual, Is.SameAs(expected));
            Assert.That(queryWasCalled, Is.True);
        }

        [Test]
        public void GetSqlDataReader_GivenNonCachedCommand_StoresResult()
        {
            // arrange
            var expected = new object();

            Func<object> query = () => expected;

            var storeMock = new Mock<IBackingStore>();
            storeMock
                .Setup(x => x.ContainsKey(It.IsAny<string>()))
                .Returns(false);

            storeMock
                .Setup(x => x.Add(It.IsAny<string>(), It.IsAny<object>()));

            var sut = new NonExpiringCache(storeMock.Object);

            // act
            var actual = sut.GetSqlDataReader(new SqlCommand(), query);

            // assert
            storeMock.Verify(
                x => x.Add(It.IsAny<string>(), It.Is<object>(o => o.Equals(expected))),
                Times.Once());
        }
    }
}
