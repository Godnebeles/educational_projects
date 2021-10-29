using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using todo_rest_api.Models;

namespace todo_rest_api.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private TasksListService service;


        public TasksController(TasksListService service)
        {
            this.service = service;
        }


        [HttpGet]
        public ActionResult<Task> GetAllTasks(int taskId, int listId)
        {
            return service.GetTaskById(taskId);
        }


        [HttpGet("{taskId}")]
        public ActionResult<Task> GetTaskById(int taskId, int listId)
        {
            return service.GetTaskById(taskId);
        }


        [HttpPost]
        public ActionResult<Task> PostTask(int listId, Task task)
        {
            service.CreateTaskInList(listId, task);

            return Ok();
        }


        [HttpPut("{taskId}")]
        public IActionResult PutTask(int taskId, [FromQuery]int listId, [FromBody]Task task)
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