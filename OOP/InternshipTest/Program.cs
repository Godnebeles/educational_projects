using System;
using System.Collections.Generic;
using InternshipTest.Person;
using InternshipTest.Institution;
using InternshipTest.Institution.InterLink;

namespace InternshipTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var s1 = new Student("Andrew");
            s1.SetKnowledge(new Knowledge(5));
            var s2 = new Student("Sonya");
            s2.SetKnowledge(new Knowledge(2));
            var s3 = new Student("Viсtoria");
            s3.SetKnowledge(new Knowledge(4));
            var s4 = new Student("Liza");
            s4.SetKnowledge(new Knowledge(4));

            University university = new University("CH.U.I.");
            university.AddStudent(s1);
            university.AddStudent(s2);
            university.AddStudent(s3);
            university.AddStudent(s4);

            Internship internship = new Internship("Interlink");
            internship.SetConditionLevel(NecessaryLevel.middle);
            internship.AddStudents(university);

            Console.WriteLine("List of internship's students: ");
            List<Student> students = internship.GetStudents();
            foreach(var student in students)
            {
                Console.WriteLine(student);
            }
           

            
        }
    }
}
