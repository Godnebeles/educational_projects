using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using todo_rest_api.Models;

namespace todo_rest_api.Controllers
{
    [Route("api/tasks/")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private TasksListService service;
        public TaskController(TasksListService service)
        {
            this.service = service;
        }


        [HttpGet("")]
        public ActionResult<IEnumerable<Task>> GetTasks()
        {
            return service.GetAllTasks();
        }


        [HttpGet("{listId}/{id}")]
        public ActionResult<Task> GetTaskById(int listId, int id)
        {
            return service.GetTaskById(listId, id);
        }


        [HttpPost("{listId}")]
        public ActionResult<Task> PostTask(int listId, Task task)
        {
            service.CreateTaskInList(listId, task);

            return Ok();
        }


        [HttpPut("{listId}/{id}")]
        public IActionResult PutTask(int listid, int id, Task task)
        {
            service.PutTaskById(listid, id, task);

            return Ok();
        }


        [HttpPatch("{listId}/{id}")]
        public IActionResult PatchTask(int listId, int id, Task task)
        {
            service.PatchTask(listId, id, task);

            return Ok();
        }


        [HttpDelete("{listId}/{id}")]
        public ActionResult<Task> DeleteTaskById(int listId, int id)
        {
            service.DeleteTask(listId, id);

            return Ok();
        }
    }
}