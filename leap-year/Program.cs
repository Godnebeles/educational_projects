using System;

namespace leap_year
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsLeapYear(2100));
            Console.WriteLine(IsLeapYear(2104));
            Console.WriteLine(IsLeapYear(2115));
            Console.WriteLine(IsLeapYear(2400));
        }

        static string IsLeapYear(int year)
        {
            if ((year % 4 != 0 || year % 100 == 0) && year % 400 != 0)
            {
                return year + " year is not leap";
            }
            else
            {
                return year + " year is leap";
            }
        }
    }
}
