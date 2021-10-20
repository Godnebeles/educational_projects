using System;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(new Task(1, "somth task", false));
            System.Console.WriteLine();
            System.Console.WriteLine(new Task(1, "somth task two", false));
            System.Console.WriteLine();
            System.Console.WriteLine(new Task(1, "GOOD TASk", true, "Big Discription", DateTime.Now));
        }
    }
}
