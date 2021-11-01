using System;
using Npgsql;

namespace first_connect_psql
{
    class Program
    {
        static async void Main(string[] args)
        {
            var connString = "Host=127.0.0.1 ;Username=todolist_app;Password=secret;Database=todolist";

            await using var conn = new NpgsqlConnection(connString);

            await using (var cmd = new NpgsqlCommand("SELECT some_field FROM data", conn))
            await using (var reader = await cmd.ExecuteReaderAsync())
                while (await reader.ReadAsync())
                    Console.WriteLine(reader.GetString(0));
        }
    }
}
