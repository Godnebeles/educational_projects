using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Npgsql;

namespace todo_item
{

    class Program
    {
        static string connString = "Host=127.0.0.1;Username=todolist_app;Password=secret;Database=todolist";
        
        static void Main(string[] args)
        {
            MainAsync().Wait();
        }


        static async Task MainAsync()
        {
            while (true)
            {
                Console.Clear();
                await using var conn = new NpgsqlConnection(connString);
                await conn.OpenAsync();

                await PrintTodoItem(conn);

                System.Console.WriteLine("What do you want to do?");
                System.Console.WriteLine("add - create new task\ned - edit post\ndel - delete post");
                string answer = Console.ReadLine();

                if (answer == "add")
                    await CreateTodoItemAsync(conn);
                else
                {
                    System.Console.WriteLine("Id todo: ");
                    int id = int.Parse(Console.ReadLine());
                    if (answer == "ed")
                    {
                        await UpdateTodoItemAsync(conn, id);
                    }
                    else if (answer == "del")
                    {
                        await DeleteTodoItemAsync(conn, id);
                    }
                }
                conn.Close();
            }

        }


        private static async Task CreateTodoItemAsync(NpgsqlConnection conn)
        {


            await using (var cmd = new NpgsqlCommand("INSERT INTO todo_item (title, \"desc\", done, due_date) VALUES " +
                                                     "(@title, @desc, @done, @due_date)", conn))
            {
                System.Console.WriteLine("Title:");
                var title = Console.ReadLine();
                cmd.Parameters.AddWithValue("title", title);

                System.Console.WriteLine("Description:");
                var desc = Console.ReadLine();
                cmd.Parameters.AddWithValue("desc", desc);

                System.Console.WriteLine("Is done:");
                var done = Convert.ToBoolean(Console.ReadLine());
                cmd.Parameters.AddWithValue("done", done);

                System.Console.WriteLine("Date:");
                var date = DateTime.Parse(Console.ReadLine());
                cmd.Parameters.AddWithValue("due_date", date);

                await cmd.ExecuteNonQueryAsync();
            }
            System.Console.WriteLine("Created, your notes: ");


        }


        private static async Task<List<TodoItem>> GetTodoItemAsync(NpgsqlConnection conn)
        {
            List<TodoItem> items = new List<TodoItem>();

            await using (var cmd = new NpgsqlCommand("SELECT * FROM todo_item", conn))
            await using (var reader = await cmd.ExecuteReaderAsync())
                while (await reader.ReadAsync())
                {
                    var tempTodoitem = new TodoItem(reader.GetInt32(0), reader.GetString(1),
                                                    reader.GetString(2), reader.GetBoolean(3),
                                                    DateTime.Parse(reader.GetDate(4).ToString()));
                    items.Add(tempTodoitem);
                }

            return items;
        }


        private static async Task UpdateTodoItemAsync(NpgsqlConnection conn, int id)
        {
            System.Console.WriteLine("Edit title(tl), desc(dc), done(dn), due date(dd)");
            string currentField = Console.ReadLine();
            if (currentField == "tl")
                currentField = "title";
            else if (currentField == "dc")
                currentField = "desc";
            else if (currentField == "dn")
                currentField = "done";
            else if (currentField == "dd")
                currentField = "due_date";
            else
                currentField = " ";

            await using (var cmd = new NpgsqlCommand("UPDATE todo_item set " + currentField + "=@data where id=" + id, conn))
            {
                System.Console.WriteLine("Your data:");
                string answer = Console.ReadLine();

                if (currentField == "due_date")
                    cmd.Parameters.AddWithValue("data", DateTime.Parse(answer));
                else if (currentField == "done")
                {
                    bool newFlag = Convert.ToBoolean(answer);
                    cmd.Parameters.AddWithValue("data", newFlag);
                }
                else
                    cmd.Parameters.AddWithValue("data", answer);

                await cmd.ExecuteNonQueryAsync();
            }

        }

        private static async Task DeleteTodoItemAsync(NpgsqlConnection conn, int id)
        {
            await using (var cmd = new NpgsqlCommand("DELETE FROM todo_item where id=" + id, conn))
            {
                await cmd.ExecuteNonQueryAsync();
            }
        }


        private static async Task PrintTodoItem(NpgsqlConnection conn)
        {
            List<TodoItem> items = await GetTodoItemAsync(conn);
            foreach (var item in items)
            {
                System.Console.WriteLine(item);
            }
        }

    }
}

