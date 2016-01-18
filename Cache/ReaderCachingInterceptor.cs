namespace Cache
{
    using System;
    using System.Linq;
    using CodeCop.Core;
    using CodeCop.Core.Contracts;
    using CodeCop.Core.Extensions;

    internal class ReaderCachingInterceptor : ICopIntercept, ICopOverride
    {
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

            return context.InterceptedMethod.Execute(context.Sender, context.Parameters.Select(x => x.Value).ToArray());
        }
    }
}
