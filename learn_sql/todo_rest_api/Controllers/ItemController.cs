using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using todo_rest_api.Models;

namespace todo_rest_api.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private TodoItemService service;


        public ItemController(TodoItemService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<List<TodoItemDto>> GetAllTodoItems()
        {
            return service.GetAllItems();
        }

        [HttpGet("{id}")]
        public ActionResult<List<TodoItemDto>> GetTodoItem()
        {
            return null;
        }

        [HttpPost]
        public ActionResult AddTodoItem(NewTodoItemDto todoItem)
        {
            TodoItem createdTodoItem = service.AddTodoItem(todoItem);

            return CreatedAtAction("GetTodoItem", new {id = createdTodoItem.Id}, createdTodoItem);
        }
    }
}