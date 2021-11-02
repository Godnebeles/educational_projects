using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo_rest_api
{
    public class TodoListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CountOpenTasks { get; set; }

        public TodoListDto()
        {

        }

        public TodoListDto(TodoList todoList)
        {
            this.Id = todoList.Id;
            this.Title = todoList.Title;
            this.CountOpenTasks = todoList.TodoItems.Where(x => x.Done == false).Count();
        }
    }
}