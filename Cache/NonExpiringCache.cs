namespace Cache
{
    using System;
    using System.Data.Common;
    using System.Data.SqlClient;

    internal class NonExpiringCache : ICache
    {
        private IBackingStore storage;

        public NonExpiringCache(IBackingStore storage)
        {
            if (storage == null)
            {
                throw new ArgumentNullException(nameof(storage));
            }

            this.storage = storage;
        }

        public DbDataReader GetDataReader(SqlCommand command, Func<DbDataReader> query)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            var key = command.GetCacheKey();
            if (storage.ContainsKey(key))
            {
                return (DbDataReader)storage.Get(key);
            }

            var results = query();
            var cacheableReader = new CacheableDataReader(results);
            storage.Add(key, cacheableReader);

            return cacheableReader;
        }
    }
}
