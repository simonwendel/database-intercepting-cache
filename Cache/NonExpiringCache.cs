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

        public object CacheSqlDataReader(SqlCommand command, Func<object> query)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            throw new NotImplementedException();
        }
    }
}
