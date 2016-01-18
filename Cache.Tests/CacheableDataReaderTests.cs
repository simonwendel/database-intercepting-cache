namespace Cache.Tests
{
    using System;
    using System.Data;
    using System.Globalization;
    using Moq;
    using NUnit.Framework;

    /*
     * I wanted to test the getters on the CacheableDataReader class, but there are too many of them to fit 
     * all tests in one file. Therefore I made it partial and put the getter tests in the file 
     * CacheableDataReaderTests.Getters.cs
     */
    [TestFixture, Category("CacheableDataReader")]
    public partial class CacheableDataReaderTests : IDisposable
    {
        private DataTableReader actualDataReader;

        private Mock<IDataReader> mockDataReader;

        [SetUp]
        public void Setup()
        {
            var schemaTable = new DataTable();
            schemaTable.Locale = CultureInfo.InvariantCulture;

            mockDataReader = new Mock<IDataReader>();
            mockDataReader.Setup(r => r.GetSchemaTable()).Returns(schemaTable);

            actualDataReader = new DataTableReader(BuildDataTable());
        }

        [Test]
        public void Ctor_GivenNullReader_ThrowsException()
        {
            // assert
            Assert.Throws<ArgumentNullException>(() => new CacheableDataReader(null));
        }

        [Test]
        public void Ctor_GivenReader_SetsDataTableLocale()
        {
            // act
            new CacheableDataReader(mockDataReader.Object);

            // assert
            mockDataReader.Verify(r => r.GetSchemaTable(), Times.Once());
        }

        [Test]
        public void IsClosed_Always_ReturnsFalse()
        {
            // arrange
            var sut = new CacheableDataReader(mockDataReader.Object);
            var isClosed = sut.IsClosed;

            // act
            sut.Close();
            isClosed |= sut.IsClosed;

            // assert
            Assert.That(isClosed, Is.False);
        }

        [Test]
        public void Read_CalledAfterClose_ShouldAlwaysWork()
        {
            // arrange
            var sut = new CacheableDataReader(actualDataReader);
            var reads = sut.Read();

            // act
            sut.Close();
            reads &= sut.Read();

            // assert
            Assert.That(reads, Is.True);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && actualDataReader != null)
            {
                actualDataReader.Dispose();
            }
        }
    }
}
