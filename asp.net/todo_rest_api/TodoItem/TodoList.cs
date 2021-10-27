using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo_rest_api
{
    public class TodoList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Task> Tasks = new List<Task>();
    }
}