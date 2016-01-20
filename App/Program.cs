namespace App
{
    using System;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using static System.FormattableString;

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

                Console.WriteLine(Invariant($"That took: {sw.ElapsedMilliseconds} milliseconds to perform."));
            }

            Console.ReadKey();
        }

        private static void DoDatabaseStuff()
        {
            var connectionString = @"Data Source=(LocalDb)\v11.0;Initial Catalog=InvisiblyCachedDatabase;Integrated Security=True";
            var queryString = "WAITFOR DELAY '00:00:01';SELECT ActualData FROM TableOfData;";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(queryString, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(Invariant($"{reader[0]}"));
                    }
                }
            }
        }
    }
}
