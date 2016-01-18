namespace Cache
{
    using System;
    using System.Data.SqlClient;

    internal class NonInvalidatingCache : ICache
    {
        public object CacheSqlDataReader(SqlCommand command, Func<object> fallback)
        {
            throw new NotImplementedException();
        }
    }
}
