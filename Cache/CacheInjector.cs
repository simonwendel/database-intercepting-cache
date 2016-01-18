namespace Cache
{
    using CodeCop.Core;
    using CodeCop.Core.Contracts;

    public class Injector
    {
        public static void Start()
        {
            Cop.Intercept(TypeResolver.ResolveAll<ICopIntercept>());
        }
    }
}
