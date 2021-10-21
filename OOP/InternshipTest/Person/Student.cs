namespace InternshipTest.Person
{
    public class Student
    {
        public string Name  { get; set; }
        public Knowledge Knowledge  { get; set; }

        

        public Student(string name)
        {
            this.Name = name;
        }

        public void SetKnowledge(Knowledge knowledge)
        {
            this.Knowledge = knowledge;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Knowledge: {Knowledge.Level}";
        }
    }
}