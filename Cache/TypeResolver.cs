namespace Cache
{
    using System.Collections.Generic;
    using Ninject;

    internal class TypeResolver
    {
        private static TypeResolver instance;

        private IKernel kernel;

        public TypeResolver()
        {
            kernel = new StandardKernel();
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
