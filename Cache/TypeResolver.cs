namespace Cache
{
    using System.Collections.Generic;
    using CodeCop.Core.Contracts;
    using Ninject;

    internal class TypeResolver
    {
        private static TypeResolver instance;

        private IKernel kernel;

        public TypeResolver()
        {
            kernel = new StandardKernel();
            kernel.Bind<ICopIntercept>().To<ScalarCachingInterceptor>();
            kernel.Bind<ICopIntercept>().To<ReaderCachingInterceptor>();
        }

        public static TypeResolver Instance
        {
            get
            {
                return instance ?? (instance = new TypeResolver());
            }
        }

        public static IEnumerable<T> ResolveAll<T>()
        {
            return Instance.kernel.GetAll<T>();
        }
    }
}
