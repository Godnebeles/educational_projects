using System.Collections.Generic;
using InternshipTest.Person;

namespace InternshipTest.Institution.InterLink
{
    public enum NecessaryLevel
    {
        junior,
        middle,
        senior
    }

    public class Internship
    {
        private List<Student> interns = new List<Student>();
        private NecessaryLevel condition = NecessaryLevel.junior;
        private string Name { get; set; }

        public Internship(string name)
        {
            this.Name = name;
        }

        public List<Student> GetStudents()
        {
            return interns;
        }

        public void AddStudents(University university)
        {
            if (condition == NecessaryLevel.middle)
            {
                AddMiddles(university);
            }
        }

        public void SetConditionLevel(NecessaryLevel necessaryLevel)
        {
            this.condition = necessaryLevel;
        }

        private void AddMiddles(University university)
        {
            int averageRate = university.AverageRate();
            List<Student> students = university.GetStudents();

            foreach (var student in students)
            {
                if(student.Knowledge.Level > averageRate)
                {
                    interns.Add(student);
                }
            }
        }

    }
}
