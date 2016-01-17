namespace Cache
{
    using CodeCop.Core;

    public class Injector
    {
        public static void Start()
        {
            Cop.Intercept();
        }
    }
}
