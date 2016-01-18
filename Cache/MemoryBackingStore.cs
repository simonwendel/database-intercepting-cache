namespace Cache
{
    using System.Collections.Generic;

    internal class MemoryBackingStore : IBackingStore
    {
        private IDictionary<string, object> storage;

        public MemoryBackingStore()
        {
            storage = new Dictionary<string, object>();
        }

        public bool ContainsKey(string key)
        {
            return storage.ContainsKey(key);
        }
    }
}
