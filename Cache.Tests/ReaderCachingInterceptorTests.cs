namespace Cache.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Data.SqlClient;
    using CodeCop.Core;
    using Moq;
    using NUnit.Framework;

    [TestFixture, Category("ReaderCachingInterceptor")]
    public class ReaderCachingInterceptorTests
    {
        [Test]
        public void Ctor_InvokedWithNullCache_ThrowsException()
        {
            // assert
            Assert.Throws<ArgumentNullException>(() => new ReaderCachingInterceptor(null));
        }

        [Test]
        public void OnBeforeExecute_Invoked_DoesNothing()
        {
            // arrange
            var sut = new ReaderCachingInterceptor(Mock.Of<ICache>());

            // act
            sut.OnBeforeExecute(null);
        }

        [Test]
        public void OnAfterExecute_Invoked_DoesNothing()
        {
            // arrange
            var sut = new ReaderCachingInterceptor(Mock.Of<ICache>());

            // act
            sut.OnAfterExecute(null);
        }

        [Test] // might be integration testing CodeCop, whatever...
        public void OnOverride_InvokedOnNull_ThrowsException()
        {
            // arrange
            var sut = new ReaderCachingInterceptor(Mock.Of<ICache>());

            // assert
            Assert.Throws<ArgumentNullException>(() => sut.OnOverride(null));
        }

        [Test]
        public void OnOverride_GivenContext_CallsCache()
        {
            // arrange
            var context = new InterceptionContext();
            context.Parameters = new List<Parameter>(new[] { new Parameter { Value = 2 } });

            var cacheMock = new Mock<ICache>();
            var expectedReturn = new MockDataReader();

            cacheMock
                .Setup(x => x.GetDataReader(It.IsAny<SqlCommand>(), It.IsAny<Func<DbDataReader>>()))
                .Returns(expectedReturn);

            var sut = new ReaderCachingInterceptor(cacheMock.Object);

            // act
            var actualReturn = sut.OnOverride(context);

            // assert
            Assert.That(actualReturn, Is.SameAs(expectedReturn));

            cacheMock.Verify(
                x => x.GetDataReader(It.IsAny<SqlCommand>(), It.IsAny<Func<DbDataReader>>()),
                Times.Once());
        }
    }
}
