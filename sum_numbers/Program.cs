using System;

namespace sum_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SumNumbers(1, 5));
            Console.WriteLine(SumNumbers(3, 5));
        }

        static int SumNumbers(int start, int end)
        {
            int sum = 0;
            for(int i = start; i <= end; i++)
            {
                sum += i;
            }
            return sum;
        }
    }
}
