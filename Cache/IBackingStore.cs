namespace Cache
{
    internal interface IBackingStore
    {
        bool ContainsKey(string key);
    }
}
