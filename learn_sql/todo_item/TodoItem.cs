using System;

namespace todo_item
{
    public class TodoItem
    {
        private int identifier;
        private string title;
        private string desc;
        private bool? done;
        private DateTime? dueDate;


        public TodoItem(int identifier, string title, string desc, bool? done, DateTime? date)
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

            string date = this.dueDate != DateTime.MinValue ? " (" + this.dueDate?.ToString("MMMM dd") + ") " : "";
            string desc = this.desc != "" ? "\n   " + this.desc : "";
            string title = this.title != "" ? this.title : "No title";

            return $"{this.identifier}. {done} {title} {date} {desc}";

        }
    }
}
