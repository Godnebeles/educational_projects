using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using todo_rest_api.Models;

namespace todo_rest_api.Controllers
{
    [Route("api/lists/{id}/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        
        public TaskController()
        {
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<Task>> GetTasks()
        {
            return new List<Task> { };
        }

        [HttpGet("{id}")]
        public ActionResult<Task> GetTaskById(int id)
        {
            return null;
        }

        [HttpPost("")]
        public ActionResult<Task> PostTask(Task model)
        {
            return null;
        }

        [HttpPut("{id}")]
        public IActionResult PutTask(int id, Task model)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Task> DeleteTaskById(int id)
        {
            return null;
        }
    }
}