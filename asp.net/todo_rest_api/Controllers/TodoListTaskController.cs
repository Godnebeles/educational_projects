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
    public class TodoListTaskController : ControllerBase
    {
        private TasksListService service;


        public TodoListTaskController(TasksListService service)
        {
            this.service = service;
        }


        [HttpGet("lists")]
        public ActionResult<IEnumerable<TodoList>> GetTodoItems()
        {
            return service.GetAllLists();
        }


        [HttpGet("list")]
        public ActionResult<TodoList> GetTodoListById(int listId)
        {
            return service.GetTodoListById(listId);
        }


        [HttpPost("list")]
        public ActionResult<TodoList> CreateTodoList(TodoList todoItem)
        {
            service.CreateTodoList(todoItem);

            return Created($"api/todolist/{todoItem.Id}", todoItem);
        }


        [HttpDelete("list")]
        public ActionResult<TodoList> DeleteTodoItemById(int listId)
        {
            service.DeleteTodoListById(listId);

            return Ok();
        }


        // TASKS QUERY
        [HttpGet("tasks")]
        public ActionResult<IEnumerable<Task>> GetTasks()
        {
            return service.GetAllTasks();
        }


        [HttpGet("task")]
        public ActionResult<Task> GetTaskById(int taskId)
        {
            return service.GetTaskById(taskId);
        }


        [HttpPost("listId")]
        public ActionResult<Task> PostTask(int listId, Task task)
        {
            service.CreateTaskInList(listId, task);

            return Ok();
        }


        [HttpPut("task")]
        public IActionResult PutTask(int taskId, Task task)
        {
            service.PutTaskById(taskId, task);

            return Ok();
        }


        [HttpPatch("task")]
        public IActionResult PatchTask(int taskId, Task task)
        {
            service.PatchTask(taskId, task);

            return Ok();
        }


        [HttpDelete("task")]
        public ActionResult<Task> DeleteTaskById(int taskId)
        {
            service.DeleteTask(taskId);

            return Ok();
        }

    }
}