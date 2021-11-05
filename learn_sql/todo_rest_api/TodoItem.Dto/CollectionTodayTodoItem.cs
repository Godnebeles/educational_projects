using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo_rest_api
{
    public class CollectionTodayTodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool? Done { get; set; }
        public CollectionTodayTodoList TodoList {get;set;}

        public CollectionTodayTodoItem()
        {

        }

        public CollectionTodayTodoItem(TodoItem todoItem)
        {
            this.Id = todoItem.Id;
            this.Title = todoItem.Title;
            this.Description = todoItem.Description;
            this.DueDate = todoItem.DueDate;
            this.Done = todoItem.Done;
            this.TodoList = new CollectionTodayTodoList(todoItem.TodoList);
        }

        internal static CollectionTodayTodoItem FromEntity(TodoItem item)
        {
            return new CollectionTodayTodoItem(item);
        }
    }
}