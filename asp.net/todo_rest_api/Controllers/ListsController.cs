using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


namespace todo_rest_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListsController : ControllerBase
    {
        private TasksListService service;


        public ListsController(TasksListService service)
        {
            this.service = service;
        }


        [HttpGet]
        public ActionResult<IEnumerable<TodoList>> GetTodoItems(int listId)
        {
            return service.GetAllLists();
        }


        [HttpGet("{listId}")]
        public ActionResult<TodoList> GetTodoListById(int listId)
        {       
            return service.GetTodoListById(listId);
        }


        [HttpPost]
        public ActionResult<TodoList> CreateTodoList(TodoList todoItem)
        {
            service.CreateTodoList(todoItem);

            return Created($"api/todolist/{todoItem.Id}", todoItem);
        }


        [HttpDelete("{listId}")]
        public ActionResult<TodoList> DeleteTodoItemById(int listId)
        {
            service.DeleteTodoListById(listId);

            return Ok();
        }
    }
}