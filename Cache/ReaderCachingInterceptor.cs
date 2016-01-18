namespace Cache
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;
    using CodeCop.Core;
    using CodeCop.Core.Contracts;
    using CodeCop.Core.Extensions;

    internal class ReaderCachingInterceptor : ICopIntercept, ICopOverride
    {
        private ICache cache;

        public ReaderCachingInterceptor(ICache cache)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }

            this.cache = cache;
        }

        public void OnAfterExecute(InterceptionContext context)
        {
        }

        public void OnBeforeExecute(InterceptionContext context)
        {
        }

        public object OnOverride(InterceptionContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var command = context.Sender as SqlCommand;
            var parameters = context.Parameters.Select(x => x.Value).ToArray();

            // query to run if we actually want to hit the database
            Func<object> query = () => context.InterceptedMethod.Execute(command, parameters);

            return cache.GetSqlDataReader(command, query);
        }
    }
}
