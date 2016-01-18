namespace Cache
{
    using System;
    using System.Data.SqlClient;

    internal interface ICache
    {
        object GetSqlDataReader(SqlCommand command, Func<object> query);
    }
}
