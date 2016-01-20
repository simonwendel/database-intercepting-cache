namespace Cache
{
    using System;
    using System.Collections.Generic;
    using CodeCop.Core.Contracts;
    using Ninject;

    internal class TypeResolver : IDisposable
    {
        private static TypeResolver instance;

        private IKernel kernel;

        public TypeResolver()
        {
            kernel = new StandardKernel();
            kernel.Bind<ICopIntercept>().To<ReaderCachingInterceptor>();
            kernel.Bind<ICache>().To<NonExpiringCache>().InSingletonScope();
            kernel.Bind<IBackingStore>().To<MemoryBackingStore>().InSingletonScope();
        }

        public static TypeResolver Instance
        {
            get
            {
                return instance ?? (instance = new TypeResolver());
            }
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return kernel.GetAll<T>();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && kernel != null)
            {
                kernel.Dispose();
            }
        }
    }
}
