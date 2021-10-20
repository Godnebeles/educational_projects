using System;

namespace Task
{
    public struct Task
    {
        private int identifier;
        private string title;
        private string desc;
        private bool done;
        private DateTime dueDate;


        public Task(int identifier, string title, bool done)
        {
            this.identifier = identifier;
            this.title = title;
            this.desc = "";
            this.done = done;
            this.dueDate = new DateTime();
        }

        public Task(int identifier, string title, bool done, string desc, DateTime date)
        {
            this.identifier = identifier;
            this.title = title;
            this.desc = desc;
            this.done = done;
            this.dueDate = date;
        }

        public override string ToString()
        {
            string done = "";

            if (this.done == true)
                done = "[X]";
            else
                done = "[ ]";

            string date = this.dueDate != DateTime.MinValue ? " (" + this.dueDate.ToString("MMMM dd") + ") " : "";
            string desc = this.desc != "" ? "\n   " + this.desc : "";
            string title = this.title != "" ? this.title : "No title";

            return $"{this.identifier}. {done} {title} {date} {desc}";

        }
    }
}