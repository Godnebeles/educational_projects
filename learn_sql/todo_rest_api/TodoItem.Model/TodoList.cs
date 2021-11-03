using System.Collections.Generic;


namespace todo_rest_api
{
    public class TodoList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<TodoItem> TodoItems { get; set; }

        public TodoList()
        {

        }

        public TodoList(NewTodoListDto newTodoListDto)
        {
            this.Title = newTodoListDto.Title;
        }
    }
}