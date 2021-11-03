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
    public class DashboardController
    {
        private TodoItemService service;

        public DashboardController(TodoItemService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<List<Dashboard>> GetDashboard()
        {
            return service.GetDashboard();
        }
    }
}