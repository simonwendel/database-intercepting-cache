namespace Cache
{
    using System;
    using System.Data.SqlClient;

    internal interface ICache
    {
        object CacheSqlDataReader(SqlCommand command, Func<object> fallback);
    }
}
