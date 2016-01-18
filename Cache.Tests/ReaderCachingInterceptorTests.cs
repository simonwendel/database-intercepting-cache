namespace Cache.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class ReaderCachingInterceptorTests
    {
        [Test]
        public void OnBeforeExecute_WhenInvoked_ShouldDoNothing()
        {
            // arrange
            var sut = new ReaderCachingInterceptor();

            // act
            sut.OnBeforeExecute(null);
        }

        [Test]
        public void OnAfterExecute_WhenInvoked_ShouldDoNothing()
        {
            // arrange
            var sut = new ReaderCachingInterceptor();

            // act
            sut.OnAfterExecute(null);
        }

        [Test] // might be integration testing CodeCop, whatever...
        public void OnOverride_WhenInvokedOnNull_ShouldThrowException()
        {
            // arrange
            var sut = new ReaderCachingInterceptor();

            // assert
            Assert.Throws<ArgumentNullException>(() => sut.OnOverride(null));
        }
    }
}
