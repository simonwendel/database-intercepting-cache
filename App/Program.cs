namespace App
{
    using System;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Globalization;

    internal class Program
    {
        private static void Main()
        {
            Cache.Injector.Start();

            var sw = new Stopwatch();

            var repeats = 5;
            for (int i = 0; i < repeats; ++i)
            {
                sw.Restart();
                DoDatabaseStuff();
                sw.Stop();

                Console.WriteLine($"That took: {sw.ElapsedMilliseconds} milliseconds to perform.");
            }

            Console.ReadKey();
        }

        private static void DoDatabaseStuff()
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
                        Console.WriteLine(string.Format(CultureInfo.CurrentCulture, "{0}", reader[0]));
                    }
                }
            }
        }
    }
}
