namespace Cache
{
    using System.Collections.Generic;

    /*
     * Exciting wrapper around an IDictionary to simulate a caching store. ;-)
     */
    internal class MemoryBackingStore : IBackingStore
    {
        private IDictionary<string, object> storage;

        public MemoryBackingStore()
        {
            storage = new Dictionary<string, object>();
        }

        public void Add(string key, object value)
        {
            storage.Add(key, value);
        }

        public bool ContainsKey(string key)
        {
            return storage.ContainsKey(key);
        }

        public object Get(string key)
        {
            return storage[key];
        }
    }
}
