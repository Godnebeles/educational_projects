using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


namespace todo_rest_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private TodoItemService service;


        public ListController(TodoItemService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<List<TodoListDto>> GetAllLists()
        {
            return service.GetAllLists();;
        }

        [HttpGet("{listId}")]
        public ActionResult<TodoList> GetTodoListByid(int listId)
        {
            return service.GetTodoListById(listId);
        }

        [HttpGet("items")]
        public ActionResult<List<TodoItem>> GetAllItems(int listId)
        {
            return service.GetTodoItemsByListId(listId);
        }

        [HttpPost]
        public ActionResult AddTodoList(NewTodoListDto todoList)
        {
            service.AddTodoList(todoList);

            return Ok();
        }

        

        
    }
}