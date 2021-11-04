using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


namespace todo_rest_api.Controllers
{
    [Route("api/lists")]
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

        [HttpPost]
        public ActionResult AddTodoList(NewTodoListDto todoList)
        {
            service.AddTodoList(todoList);

            return Ok();
        }
  
    }
}