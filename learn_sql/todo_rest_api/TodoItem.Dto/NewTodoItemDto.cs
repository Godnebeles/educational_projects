using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo_rest_api
{
    public class NewTodoItemDto
    {
        public int TodoListId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool? Done { get; set; }
    }
}