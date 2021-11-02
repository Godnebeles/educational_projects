using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using todo_rest_api.Models;

namespace todo_rest_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private TodoItemService service;


        public ItemController(TodoItemService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<List<TodoItem>> GetAllTodoItems()
        {
            return service.GetAllItems();
        }

        [HttpPost]
        public ActionResult AddTodoItem(NewTodoItemDto todoItem)
        {
            service.AddTodoItem(todoItem);

            return Ok();
        }
    }
}