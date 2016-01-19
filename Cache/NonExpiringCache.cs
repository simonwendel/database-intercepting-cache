namespace Cache
{
    using System;
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

        public object GetSqlDataReader(SqlCommand command, Func<object> query)
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
                return storage.Get(key);
            }

            var results = query();
            storage.Add(key, results);
            return results;
        }
    }
}
