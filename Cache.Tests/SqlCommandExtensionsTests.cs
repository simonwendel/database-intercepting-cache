namespace Cache.Tests
{
    using System;
    using System.Data.SqlClient;
    using Cache;
    using NUnit.Framework;

    [TestFixture]
    public class SqlCommandExtensionsTests
    {
        [Test]
        public void GetCacheKey_InvokedOnSqlCommandWithParameters_ReturnsKey()
        {
            // arrange
            var command = new SqlCommand();
            command.CommandText = "SELECT * FROM table WHERE Column1 = @Parameter1 AND Column2 = @Parameter2";

            command.Parameters.Add(new SqlParameter("@Parameter1", "AStringValue"));
            command.Parameters.Add(new SqlParameter("@Parameter2", 12));

            var expected = "SELECT * FROM table WHERE Column1 = @Parameter1 AND Column2 = @Parameter2 -- {@Parameter1: AStringValue} {@Parameter2: 12}";

            // act
            var key = command.GetCacheKey();

            // assert
            Assert.That(key, Is.EqualTo(expected));
        }

        [Test]
        public void GetCacheKey_InvokedOnSqlCommandWithoutParameters_ReturnsKey()
        {
            // arrange
            var command = new SqlCommand();
            command.CommandText = "SELECT * FROM table WHERE Column1 = 'AStringValue'";

            // act
            var key = command.GetCacheKey();

            // assert
            Assert.That(key, Is.EqualTo(command.CommandText));
        }

        [Test]
        public void GetCacheKey_GivenNullCommand_ThrowsArgumentNullException()
        {
            // assert
            Assert.Throws<ArgumentNullException>(() => SqlCommandExtensions.GetCacheKey(null));
        }
    }
}
