namespace Cache.Tests
{
    using System;
    using System.Data;
    using System.Linq;
    using NUnit.Framework;

    /*
     * I wanted to test the getters on the CacheableDataReader class, but there are too many of them to fit 
     * all tests in one file. Therefore I made it partial and put the getter tests here. Please don't judge.
     */
    [TestFixture]
    public partial class CacheableDataReaderTests
    {
        private static readonly DateTime DateTimeData = DateTime.Now;

        private static readonly Guid GuidData = Guid.NewGuid();

        private static readonly object ObjectData = new object();

        [Test]
        public void GetBoolean_GivenOrdinal_ReturnsCorrectly()
        {
            // arrange
            var sut = new CacheableDataReader(actualDataReader);
            sut.Read();

            // act
            var val = sut.GetBoolean(sut.GetOrdinal("BooleanColumn"));

            // assert
            Assert.That(val, Is.EqualTo(true));
        }

        [Test]
        public void GetByte_GivenOrdinal_ReturnsCorrectly()
        {
            // arrange
            var sut = new CacheableDataReader(actualDataReader);
            sut.Read();

            // act
            var val = sut.GetByte(sut.GetOrdinal("ByteColumn"));

            // assert
            Assert.That(val, Is.EqualTo(5));
        }

        [Test]
        public void GetBytes_GivenOrdinal_ReturnsCorrectly()
        {
            // arrange
            var sut = new CacheableDataReader(actualDataReader);
            var buffer = new byte[2];
            sut.Read();

            // act
            sut.GetBytes(sut.GetOrdinal("BytesColumn"), 0, buffer, 0, 2);

            // assert
            Assert.That(buffer, Is.EquivalentTo(new byte[] { 13, 37 }));
        }

        [Test]
        public void GetChar_GivenOrdinal_ReturnsCorrectly()
        {
            // arrange
            var sut = new CacheableDataReader(actualDataReader);
            sut.Read();

            // act
            var val = sut.GetChar(sut.GetOrdinal("CharColumn"));

            // assert
            Assert.That(val, Is.EqualTo('!'));
        }

        [Test]
        public void GetChars_GivenOrdinal_ReturnsCorrectly()
        {
            // arrange
            var sut = new CacheableDataReader(actualDataReader);
            var buffer = new char[2];
            sut.Read();

            // act
            sut.GetChars(sut.GetOrdinal("CharsColumn"), 0, buffer, 0, 2);

            // assert
            Assert.That(buffer, Is.EquivalentTo(new char[] { '!', '#' }));
        }

        [Test]
        public void GetDataTypeName_GivenOrdinal_ReturnsCorrectly()
        {
            // arrange
            var sut = new CacheableDataReader(actualDataReader);
            sut.Read();

            // act
            var val = sut.GetDataTypeName(sut.GetOrdinal("BytesColumn"));

            // assert
            Assert.That(val, Is.EqualTo("Byte[]"));
        }

        [Test]
        public void GetDateTime_GivenOrdinal_ReturnsCorrectly()
        {
            // arrange
            var sut = new CacheableDataReader(actualDataReader);
            sut.Read();

            // act
            var val = sut.GetDateTime(sut.GetOrdinal("DateTimeColumn"));

            // assert
            Assert.That(val, Is.EqualTo(DateTimeData));
        }

        [Test]
        public void GetDecimal_GivenOrdinal_ReturnsCorrectly()
        {
            // arrange
            var sut = new CacheableDataReader(actualDataReader);
            sut.Read();

            // act
            var val = sut.GetDecimal(sut.GetOrdinal("DecimalColumn"));

            // assert
            Assert.That(val, Is.EqualTo(210));
        }

        [Test]
        public void GetDouble_GivenOrdinal_ReturnsCorrectly()
        {
            // arrange
            var sut = new CacheableDataReader(actualDataReader);
            sut.Read();

            // act
            var val = sut.GetDouble(sut.GetOrdinal("DoubleColumn"));

            // assert
            Assert.That(val, Is.EqualTo(1790.0));
        }

        [Test]
        public void GetFieldType_GivenOrdinal_ReturnsCorrectly()
        {
            // arrange
            var sut = new CacheableDataReader(actualDataReader);
            sut.Read();

            // act
            var val = sut.GetFieldType(sut.GetOrdinal("BytesColumn"));

            // assert
            Assert.That(val, Is.EqualTo(typeof(byte[])));
        }

        [Test]
        public void GetFloat_GivenOrdinal_ReturnsCorrectly()
        {
            // arrange
            var sut = new CacheableDataReader(actualDataReader);
            sut.Read();

            // act
            var val = sut.GetFloat(sut.GetOrdinal("FloatColumn"));

            // assert
            Assert.That(val, Is.EqualTo(1790.0));
        }

        [Test]
        public void GetGuid_GivenOrdinal_ReturnsCorrectly()
        {
            // arrange
            var sut = new CacheableDataReader(actualDataReader);
            sut.Read();

            // act
            var val = sut.GetGuid(sut.GetOrdinal("GuidColumn"));

            // assert
            Assert.That(val, Is.EqualTo(GuidData));
        }

        [Test]
        public void GetInt16_GivenOrdinal_ReturnsCorrectly()
        {
            // arrange
            var sut = new CacheableDataReader(actualDataReader);
            sut.Read();

            // act
            var val = sut.GetInt16(sut.GetOrdinal("Int16Column"));

            // assert
            Assert.That(val, Is.EqualTo(13));
        }

        [Test]
        public void GetInt32_GivenOrdinal_ReturnsCorrectly()
        {
            // arrange
            var sut = new CacheableDataReader(actualDataReader);
            sut.Read();

            // act
            var val = sut.GetInt32(sut.GetOrdinal("Int32Column"));

            // assert
            Assert.That(val, Is.EqualTo(14));
        }

        [Test]
        public void GetInt64_GivenOrdinal_ReturnsCorrectly()
        {
            // arrange
            var sut = new CacheableDataReader(actualDataReader);
            sut.Read();

            // act
            var val = sut.GetInt64(sut.GetOrdinal("Int64Column"));

            // assert
            Assert.That(val, Is.EqualTo(15));
        }

        [Test]
        public void GetName_GivenOrdinal_ReturnsCorrectly()
        {
            // arrange
            var sut = new CacheableDataReader(actualDataReader);
            sut.Read();

            // act
            var val = sut.GetName(sut.GetOrdinal("Int64Column"));

            // assert
            Assert.That(val, Is.EqualTo("Int64Column"));
        }

        [Test]
        public void GetOrdinal_GivenName_ReturnsCorrectly()
        {
            // arrange
            var sut = new CacheableDataReader(actualDataReader);

            // act
            var index = sut.GetOrdinal("GuidColumn");

            // assert
            Assert.That(index, Is.EqualTo(1));
        }

        [Test]
        public void GetString_GivenOrdinal_ReturnsCorrectly()
        {
            // arrange
            var sut = new CacheableDataReader(actualDataReader);
            sut.Read();

            // act
            var val = sut.GetString(sut.GetOrdinal("StringColumn"));

            // assert
            Assert.That(val, Is.EqualTo("AStringValue"));
        }

        [Test]
        public void GetValue_GivenOrdinal_ReturnsCorrectly()
        {
            // arrange
            var sut = new CacheableDataReader(actualDataReader);
            sut.Read();

            // act
            var val = sut.GetValue(sut.GetOrdinal("ObjectColumn"));

            // assert
            Assert.That(val, Is.EqualTo(ObjectData));
        }

        [Test]
        public void GetValues_GivenOrdinal_ReturnsCorrectly()
        {
            // arrange
            var sut = new CacheableDataReader(actualDataReader);
            sut.Read();

            var expectedData = new object[]
            {
                "AStringValue",             // StringColumn
                GuidData,                   // GuidColumn
                13,                         // Int16Column
                14,                         // Int32Column
                15,                         // Int64Column
                DBNull.Value,               // NullColumn
                true,                       // BooleanColumn
                5,                          // ByteColumn
                new byte[] { 13, 37 },      // BytesColumn
                '!',                        // CharColumn
                new char[] { '!', '#' },    // CharsColumn
                DateTimeData,               // DateTimeColumn
                210,                        // DecimalColumn
                1790,                       // DoubleColumn
                1790,                       // FloatColumn
                ObjectData
            };

            var actualData = new object[100];

            // act
            var numberOfResults = sut.GetValues(actualData);

            // assert
            Assert.That(numberOfResults, Is.EqualTo(expectedData.Length));
            Assert.That(actualData.Take(numberOfResults).ToArray(), Is.EquivalentTo(expectedData));
        }

        [Test]
        public void Indexer_GivenName_ReturnsCorrectly()
        {
            // arrange
            var sut = new CacheableDataReader(actualDataReader);
            sut.Read();

            // act
            var val = sut["GuidColumn"];

            // assert
            Assert.That(val, Is.EqualTo(GuidData));
        }

        [Test]
        public void Indexer_GivenOrdinal_ReturnsCorrectly()
        {
            // arrange
            var sut = new CacheableDataReader(actualDataReader);
            sut.Read();

            // act
            var val = sut[sut.GetOrdinal("GuidColumn")];

            // assert
            Assert.That(val, Is.EqualTo(GuidData));
        }

        [Test]
        public void IsDBNull_GivenNonNullOrdinal_ReturnsFalse()
        {
            // arrange
            var sut = new CacheableDataReader(actualDataReader);
            sut.Read();

            // act
            var isNull = sut.IsDBNull(sut.GetOrdinal("Int16Column"));

            // assert
            Assert.That(isNull, Is.False);
        }

        [Test]
        public void IsDBNull_GivenNullOrdinal_ReturnsTrue()
        {
            // arrange
            var sut = new CacheableDataReader(actualDataReader);
            sut.Read();

            // act
            var isNull = sut.IsDBNull(sut.GetOrdinal("NullColumn"));

            // assert
            Assert.That(isNull, Is.True);
        }

        [Test]
        public void Depth_Getter_ReturnsDepth()
        {
            // arrange
            var expected = actualDataReader.Depth;
            var sut = new CacheableDataReader(actualDataReader);
            sut.Read();

            // act
            var actual = sut.Depth;

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void FieldCount_Getter_ReturnsDepth()
        {
            // arrange
            var expected = actualDataReader.FieldCount;
            var sut = new CacheableDataReader(actualDataReader);
            sut.Read();

            // act
            var actual = sut.FieldCount;

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void HasRows_Getter_ReturnsDepth()
        {
            // arrange
            var expected = actualDataReader.HasRows;
            var sut = new CacheableDataReader(actualDataReader);
            sut.Read();

            // act
            var actual = sut.HasRows;

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void RecordsAffected_Getter_ReturnsDepth()
        {
            // arrange
            var expected = actualDataReader.RecordsAffected;
            var sut = new CacheableDataReader(actualDataReader);
            sut.Read();

            // act
            var actual = sut.RecordsAffected;

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetSchemaTable_WhenCalled_ReturnsCorrectly()
        {
            // arrange
            var sut = new CacheableDataReader(actualDataReader);

            // act
            var actual = sut.GetSchemaTable();

            // assert
            Assert.That(actual, Is.Not.Null); // <- only sane thing to check?
        }

        [Test]
        public void GetEnumerator_WhenCalled_ReturnsCorrectly()
        {
            // arrange
            var sut = new CacheableDataReader(actualDataReader);

            // act
            var actual = sut.GetEnumerator();

            // assert
            Assert.That(actual, Is.Not.Null);                            // <- only sane thing to check directly?
            Assert.That(sut.Cast<IDataRecord>().Count(), Is.EqualTo(1)); // <- implies GetEnumerator, probably brittle
        }

        /// <summary>
        /// For now we don't support multiple sets.
        /// </summary>
        [Test]
        public void NextResult_NotImplemented_ThrowsException()
        {
            // arrange
            var dataReader = new DataTableReader(new[] { BuildDataTable(), BuildDataTable() });
            var sut = new CacheableDataReader(dataReader);

            // assert
            Assert.Throws<NotImplementedException>(() => sut.NextResult());
        }

        [Test]
        public void GetData_WhenCalled_ThrowsException()
        {
            // arrange
            var sut = new CacheableDataReader(actualDataReader);

            // assert
            Assert.Throws<NotSupportedException>(() => sut.GetData(0)); // <- happy with this for now, super edge case I won't handle
        }

        private DataTable BuildDataTable()
        {
            var data = new DataTable();

            data.Columns.Add("StringColumn", typeof(string));
            data.Columns.Add("GuidColumn", typeof(Guid));
            data.Columns.Add("Int16Column", typeof(short));
            data.Columns.Add("Int32Column", typeof(int));
            data.Columns.Add("Int64Column", typeof(long));
            data.Columns.Add("NullColumn");
            data.Columns.Add("BooleanColumn", typeof(bool));
            data.Columns.Add("ByteColumn", typeof(byte));
            data.Columns.Add("BytesColumn", typeof(byte[]));
            data.Columns.Add("CharColumn", typeof(char));
            data.Columns.Add("CharsColumn", typeof(char[]));
            data.Columns.Add("DateTimeColumn", typeof(DateTime));
            data.Columns.Add("DecimalColumn", typeof(decimal));
            data.Columns.Add("DoubleColumn", typeof(double));
            data.Columns.Add("FloatColumn", typeof(float));
            data.Columns.Add("ObjectColumn", typeof(object));

            data.Rows.Add(
                "AStringValue",             // StringColumn
                GuidData,                   // GuidColumn
                13,                         // Int16Column
                14,                         // Int32Column
                15,                         // Int64Column
                null,                       // NullColumn
                true,                       // BooleanColumn
                5,                          // ByteColumn
                new byte[] { 13, 37 },      // BytesColumn
                '!',                        // CharColumn
                new char[] { '!', '#' },    // CharsColumn
                DateTimeData,               // DateTimeColumn
                210,                        // DecimalColumn
                1790,                       // DoubleColumn
                1790,                       // FloatColumn
                ObjectData);                // ObjectColumn

            return data;
        }
    }
}
