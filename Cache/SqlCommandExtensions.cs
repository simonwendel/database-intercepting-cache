namespace Cache
{
    using System;
    using System.Data.SqlClient;
    using System.Text;

    public static class SqlCommandExtensions
    {
        // a naïve implementation
        public static string GetCacheKey(this SqlCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            if (command.Parameters.Count == 0)
            {
                return command.CommandText;
            }

            var sb = new StringBuilder();
            foreach (SqlParameter parameter in command.Parameters)
            {
                sb.Append($" {{{parameter.ParameterName}: {parameter.Value}}}");
            }

            return $"{command.CommandText} --{sb.ToString()}";
        }
    }
}
