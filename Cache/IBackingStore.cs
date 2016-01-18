namespace Cache
{
    internal interface IBackingStore
    {
        bool ContainsKey(string key);

        void Add(string key, object value);

        object Get(string key);
    }
}
