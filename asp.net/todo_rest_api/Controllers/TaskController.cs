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


        [HttpGet]
        public ActionResult<IEnumerable<Task>> GetTasks()
        {
            return service.GetAllTasks();
        }


        [HttpGet("{taskId}")]
        public ActionResult<Task> GetTaskById(int taskId)
        {
            return service.GetTaskById(taskId);
        }


        [HttpPost("{listId}")]
        public ActionResult<Task> PostTask(int listId, Task task)
        {
            service.CreateTaskInList(listId, task);

            return Ok();
        }


        [HttpPut("{taskId}")]
        public IActionResult PutTask(int taskId, Task task)
        {
            service.PutTaskById(taskId, task);

            return Ok();
        }


        [HttpPatch("{taskId}")]
        public IActionResult PatchTask(int taskId, Task task)
        {
            service.PatchTask(taskId, task);

            return Ok();
        }


        [HttpDelete("{taskId}")]
        public ActionResult<Task> DeleteTaskById(int taskId)
        {
            service.DeleteTask(taskId);

            return Ok();
        }
    }
}