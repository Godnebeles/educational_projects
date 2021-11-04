using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo_rest_api
{
    public class TodoItemDto
    {
        //public int TodoListId { get; set; }
        public string TodoListTitle { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool? Done { get; set; }

        public TodoItemDto()
        {

        }

        public TodoItemDto(TodoItem todoItem)
        {
            this.TodoListTitle = todoItem?.TodoList.Title;
            this.Title = todoItem.Title;
            this.Description = todoItem.Description;
            this.DueDate = todoItem.DueDate;
            this.Done = todoItem.Done;
        }
    }
}