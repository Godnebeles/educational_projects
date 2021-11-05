using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using todo_rest_api.Models;

namespace todo_rest_api
{
    [Route("api/[controller]/today")]
    [ApiController]
    public class CollectionController
    {
        private TodoItemService service;

        public CollectionController(TodoItemService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<List<CollectionTodayTodoItem>> GetCollectionTodoItemsToday()
        {
            return service.GetCollectionTodoItemsToday();
        }
    }
}