using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo_rest_api
{
    public class CollectionTodayTodoList
    {
        public int Id {get;set;}
        public string Title {get;set;}

        public CollectionTodayTodoList()
        {

        }

        public CollectionTodayTodoList(TodoList todoList)
        {
            this.Id = todoList.Id;
            this.Title = todoList.Title;
        }
    }
}