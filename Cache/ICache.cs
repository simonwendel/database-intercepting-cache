namespace Cache
{
    using System;
    using System.Data.Common;
    using System.Data.SqlClient;

    internal interface ICache
    {
        DbDataReader GetDataReader(SqlCommand command, Func<DbDataReader> query);
    }
}
