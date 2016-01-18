namespace Cache
{
    using System;
    using System.Data.SqlClient;

    internal class NonInvalidatingCache : ICache
    {
        private IKeyValueStore storage;

        public NonInvalidatingCache(IKeyValueStore storage)
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
