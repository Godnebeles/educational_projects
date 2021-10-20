using System;

namespace linked_list
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }
            
            System.Console.WriteLine("Before edit");

            foreach (var item in list)
            {
                System.Console.WriteLine(item);
            }

            list[0] = 1000;

            list[8] = 1100;

            list.RemoveAt(1);
            System.Console.WriteLine("After edit");
            foreach (var item in list)
            {
                System.Console.WriteLine(item);
            }


            System.Console.WriteLine("-------------\n0: " + list[0]);
            System.Console.WriteLine("8s: " + list[8]);
            
            System.Console.WriteLine("Last: " + list.GetLast());

        }
    }
}
