using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using todo_rest_api.Models;

namespace todo_rest_api.Controllers
{
    [Route("api/lists/{listId}/tasks")]
    [ApiController]
    public class ListsTasksController : ControllerBase
    {
        private TodoItemService service;


        public ListsTasksController(TodoItemService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<List<TodoItemDto>> GetTodoItems(int listId, bool all)
        {   
            return all ? service.GetAllTodoItemsByListId(listId) : service.GetOpenTodoItemsByListId(listId);
        } 
    }
}