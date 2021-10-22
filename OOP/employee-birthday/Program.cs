using System;
using System.Collections.Generic;
using System.Collections;

namespace employee_birthday
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Ваня Иванов", new DateTime(2003, 11, 24)));
            employees.Add(new Employee("Petr Иванов", new DateTime(2004, 10, 23)));
            employees.Add(new Employee("Vasiliy Иванов", new DateTime(2001, 12, 22)));
            employees.Add(new Employee("Ivanov Иванов", new DateTime(2001, 9, 22)));
            employees.Add(new Employee("Liza Иванов", new DateTime(2001, 1, 22)));
            employees.Add(new Employee("Kisana Иванов", new DateTime(2001, 1, 27)));
            employees.Add(new Employee("Asuna Иванов", new DateTime(2001, 2, 22)));

            Dictionary<int, List<Employee>> sortedEmployes = GetEmployeesMonthes(employees, 3);

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

        public static Dictionary<int, List<Employee>> GetSortedMonthesEmptyDict(List<Employee> employees, int monthCount)
        {
            
            employees.Sort();
            Dictionary<int, List<Employee>> dictionarySetMonthes = new Dictionary<int, List<Employee>>();

            DateTime currentMonth = DateTime.Now;
            for(int i = 0; i <= monthCount; i++)
            {
                dictionarySetMonthes.Add(currentMonth.AddMonths(i).Month, new List<Employee>());
            }
        
            return dictionarySetMonthes;
        }

        public static Dictionary<int, List<Employee>> GetEmployeesMonthes(List<Employee> employees, int monthCount)
        {
            Dictionary<int, List<Employee>> sortedEmployes = GetSortedMonthesEmptyDict(employees, monthCount);      

            foreach (var employee in employees)
            {
                int currentMonth = employee.Birthday.Month;
                if(sortedEmployes.ContainsKey(currentMonth))
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
