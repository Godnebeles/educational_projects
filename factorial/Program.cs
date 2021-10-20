using System;

namespace factorial
{
    class Program
    {
        static void Main(string[] args)
        {

            System.Console.WriteLine(Factorial(2));
            System.Console.WriteLine(Factorial(3));
            System.Console.WriteLine(Factorial(4));
        }

        static ulong Factorial(int number)
        {
            ulong resultFactorial = 1;
            if (number == 0)
                return resultFactorial;
            for (int i = number; i > 1; i--)
            {
                resultFactorial *= (ulong)i;
            }
            return resultFactorial;
        }
    }
}
