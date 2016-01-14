namespace App
{
    using System.Data.SqlClient;
    using System.Globalization;

    internal class Program
    {
        private static void Main()
        {
            var connectionString = @"Data Source=(LocalDb)\v11.0;Initial Catalog=InvisiblyCachedDatabase;Integrated Security=True";
            var queryString = "SELECT ActualData FROM TableOfData;";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(queryString, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        System.Console.WriteLine(string.Format(CultureInfo.CurrentCulture, "{0}", reader[0]));
                    }
                }
            }

            System.Console.ReadKey();
        }
    }
}
