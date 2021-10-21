using System.Collections.Generic;

using InternshipTest.Person;



namespace InternshipTest.Institution
{
    public class University
    {
        private string name;
        private List<Student> students = new List<Student>();

        public University(string name)
        {
            this.name = name;
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public int AverageRate()
        {
            int averageRate = 0;
            foreach (var student in students)
            {
                averageRate += student.Knowledge.Level;
            }
            return averageRate /= students.Count;
        }

        public List<Student> GetStudents()
        {
            return students;
        }
    }
}
