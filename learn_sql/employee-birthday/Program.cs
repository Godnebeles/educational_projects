using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading.Tasks;

using Npgsql;

namespace employee_birthday
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();
        }

        static async Task MainAsync()
        {
            List<Employee> employees = await GetEmployees();


            Dictionary<int, List<Employee>> sortedEmployes = GetEmployeesMonthes(employees, 1);

            foreach (KeyValuePair<int, List<Employee>> keyValue in sortedEmployes)
            {
                int i = 0;
                foreach (var employee in keyValue.Value)
                {
                    if (i == 0)
                    {
                        System.Console.WriteLine(employee.Birthday.ToString("Y"));
                        i++;
                    }
                    System.Console.WriteLine(employee);
                }

            }
        }

        private static async Task<List<Employee>> GetEmployees()
        {
            var connString = "Host=127.0.0.1;Username=todolist_app;Password=secret;Database=todolist";

            await using var conn = new NpgsqlConnection(connString);
            await conn.OpenAsync();

            List<Employee> employees = new List<Employee>();

            await using (var cmd = new NpgsqlCommand("SELECT Name, Birthday FROM workers", conn))
            await using (var reader = await cmd.ExecuteReaderAsync())
                while (await reader.ReadAsync())
                {
                    employees.Add(new Employee(reader.GetString(0), DateTime.Parse(reader.GetDate(1).ToString())));
                }

            return employees;
        }

        public static Dictionary<int, List<Employee>> GetSortedMonthesEmptyDict(int monthCount)
        {  
            Dictionary<int, List<Employee>> dictionarySetMonthes = new Dictionary<int, List<Employee>>();

            DateTime currentMonth = DateTime.Now;
            for (int i = 0; i <= monthCount; i++)
            {
                dictionarySetMonthes.Add(currentMonth.AddMonths(i).Month, new List<Employee>());
            }

            return dictionarySetMonthes;
        }

        public static Dictionary<int, List<Employee>> GetEmployeesMonthes(List<Employee> employees, int monthCount)
        {
            Dictionary<int, List<Employee>> sortedEmployes = GetSortedMonthesEmptyDict(monthCount);

            foreach (var employee in employees)
            {
                int currentMonth = employee.Birthday.Month;
                if (sortedEmployes.ContainsKey(currentMonth))
                    sortedEmployes[currentMonth].Add(employee);
            }

            return sortedEmployes;
        }
    }


    class Employee : IComparable<Employee>
    {
        private string name;
        private DateTime birthday;


        public Employee(string name, DateTime birthday)
        {
            this.name = name;
            this.birthday = birthday;
        }


        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }

        }
        public DateTime Birthday
        {
            get
            {
                return birthday;
            }
            set
            {
                birthday = value;
            }

        }

        private string Pulorize_BirthYear(int yearOld)
        {
            if (yearOld % 10 == 1)
            {
                return $"{yearOld} год";
            }
            else if (yearOld % 10 > 1 && yearOld % 12 < 5)
            {
                return $"{yearOld} года";
            }
            else
            {
                return $"{yearOld} лет";
            }
        }

        public override string ToString()
        {
            int yearOld = DateTime.Now.Year - birthday.Year;
            return $"({birthday.Day}) - {name} ({Pulorize_BirthYear(yearOld)})";
        }


        public int CompareTo(Employee obj)
        {
            return this.birthday.CompareTo(obj.birthday);
        }
    }
}
