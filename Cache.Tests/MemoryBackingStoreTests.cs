namespace Cache.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
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
        public void ContainsKey_GivenNonExistingKey_ReturnsFalse()
        {
            // arrange
            var sut = new MemoryBackingStore();

            // act
            var containsKey = sut.ContainsKey("someKeyThatDoesn'tExist");

            // assert
            Assert.That(containsKey, Is.False);
        }

        [Test] // silently tests MemoryBackingStore.Add as well
        public void ContainsKey_GivenExistingKey_ReturnsTrue()
        {
            // arrange
            var sut = new MemoryBackingStore();
            sut.Add("ThisKeyExists", new object());

            // act
            var containsKey = sut.ContainsKey("ThisKeyExists");

            // assert
            Assert.That(containsKey, Is.True);
        }

        [Test]
        public void Add_GivenNullKey_ThrowsException()
        {
            // arrange
            var sut = new MemoryBackingStore();

            // assert
            Assert.Throws<ArgumentNullException>(() => sut.Add(null, new object()));
        }

        [Test]
        public void Get_GivenNullKey_ThrowsException()
        {
            // arrange
            var sut = new MemoryBackingStore();

            // assert
            Assert.Throws<ArgumentNullException>(() => sut.Get(null));
        }

        [Test]
        public void Get_GivenNonExistingKey_ThrowsException()
        {
            // arrange
            var sut = new MemoryBackingStore();

            // assert
            Assert.Throws<KeyNotFoundException>(() => sut.Get("someKeyThatDoesn'tExist"));
        }

        [Test] // silently tests MemoryBackingStore.Add as well
        public void Get_GivenExistingKey_ReturnsValue()
        {
            // arrange
            var sut = new MemoryBackingStore();
            var expected = new object();

            sut.Add("ThisKeyExists", expected);

            // act
            var actual = sut.Get("ThisKeyExists");

            // assert
            Assert.That(actual, Is.SameAs(expected));
        }
    }
}
