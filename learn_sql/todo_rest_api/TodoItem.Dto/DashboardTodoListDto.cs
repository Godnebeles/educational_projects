using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo_rest_api
{
    public class DashboardTodoListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CountTasks { get; set; }
        public List<TodoItem> TodoItems { get; set; }
    }
}