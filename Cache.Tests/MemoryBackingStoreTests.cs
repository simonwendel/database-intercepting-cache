namespace Cache.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture, Category("MemoryBackingStore")]
    public class MemoryBackingStoreTests
    {
        [Test]
        public void ContainsKey_GivenNullKey_ThrowsException()
        {
            // arrange
            var sut = new MemoryBackingStore();

            // assert
            Assert.Throws<ArgumentNullException>(() => sut.ContainsKey(null));
        }

        [Test]
        public void ContainsKey_GivenNonExistantKey_ReturnsFalse()
        {
            // arrange
            var sut = new MemoryBackingStore();

            // act
            var containsKey = sut.ContainsKey("someKeyThatDoesn'tExist");

            // assert
            Assert.That(containsKey, Is.False);
        }
    }
}
