using System.Collections.Generic;


namespace todo_rest_api
{
    public class TodoList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int LastTaskId { get; set; }
        public List<Task> Tasks = new List<Task>();
    }
}