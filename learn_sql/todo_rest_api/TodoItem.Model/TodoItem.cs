using System;


namespace todo_rest_api
{
    public class TodoItem
    {
        public int Id { get; set; }
        public int TodoListId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool? Done { get; set; }
        //public TodoList TodoList { get; set; }

        public TodoItem()
        {

        }

        public TodoItem(NewTodoItemDto newTodoItemDto)
        {
            this.TodoListId = newTodoItemDto.TodoListId;
            this.Title = newTodoItemDto.Title;
            this.Description = newTodoItemDto.Description;
            this.DueDate = newTodoItemDto.DueDate;
            this.Done = newTodoItemDto.Done;
        }
    }
}