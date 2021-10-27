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
    public class TodoListController : ControllerBase
    {
        private TasksListService todoItemService;

        public TodoListController(TasksListService service)
        {
            this.todoItemService = service;
        }

        [HttpGet("lists")]
        public ActionResult<IEnumerable<TodoList>> GetTodoItems()
        {
            return todoItemService.GetAllLists();
        }

        [HttpGet("lists/{listId}/tasks")]
        public ActionResult<TodoList> GetTodoItemById(int id)
        {       
            return todoItemService.GetById(id);
        }

        [HttpPost("")]
        public ActionResult<TodoList> CreateTodoItem(TodoList todoItem)
        {
            todoItemService.Create(todoItem);

            return Created($"api/todoitem/{todoItem.Id}", todoItem);
        }

        [HttpPut("{id}")]
        public IActionResult PutTodoItem(int id, TodoList todoItem)
        {
            todoItemService.PutById(id, todoItem);

            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchTodoItem(int id, TodoList todoItem)
        {
            todoItemService.PatchTaskById(id, todoItem);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<TodoList> DeleteTodoItemById(int id)
        {
            todoItemService.DeleteById(id);

            return Ok();
        }
    }
}