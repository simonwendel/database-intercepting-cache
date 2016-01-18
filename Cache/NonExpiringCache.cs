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

        public object CacheSqlDataReader(SqlCommand command, Func<object> fallback)
        {
            throw new NotImplementedException();
        }
    }
}
