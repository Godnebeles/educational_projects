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
        private TasksListService service;


        public ListsTasksController(TasksListService service)
        {
            this.service = service;
        }

        // TASKS NO QUERY
        [HttpGet]
        public ActionResult<List<Task>> GetTaskById(int listId)
        {
            return service.GetTasksByListId(listId);
        }

        [HttpGet("{taskId}")]
        public ActionResult<List<Task>> GetTaskById(int listId, int taskId)
        {
            return service.GetTasksByListId(listId);
        }


        [HttpPost]
        public ActionResult<Task> PostTask(int listId, Task task)
        {
            service.CreateTaskInList(listId, task);

            return Ok();
        }


        [HttpPut("{taskId}")]
        public IActionResult PutTask(int listId, int taskId, Task task)
        {
            service.PutTaskById(taskId, task);

            return Ok();
        }


        [HttpPatch("{taskId}")]
        public IActionResult PatchTask(int listId, int taskId, Task task)
        {
            service.PatchTask(taskId, task);

            return Ok();
        }


        [HttpDelete("{taskId}")]
        public ActionResult<Task> DeleteTaskById(int listId, int taskId)
        {
            service.DeleteTask(taskId);

            return Ok();
        }
    }
}