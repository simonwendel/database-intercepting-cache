namespace Cache
{
    using CodeCop.Core;
    using CodeCop.Core.Contracts;

    public static class Injector
    {
        /// <summary>
        /// Starts the injection of cache objects to intercept database calls. Will take some time on the 
        /// first run on a new machine, due to downloading symbols from the Microsoft symbol servers.
        /// </summary>
        public static void Start()
        {
            var resolver = new TypeResolver();
            Cop.Intercept(resolver.ResolveAll<ICopIntercept>());
        }
    }
}
