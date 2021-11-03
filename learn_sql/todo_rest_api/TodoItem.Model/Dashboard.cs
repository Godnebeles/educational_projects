using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo_rest_api
{
    public class Dashboard
    {
        public int CountOpenTasksToday { get; set; }
        public List<TodoListDto> TodoListOpen { get; set; }
        //public List<DashboardTodoListDto> TodoListClose { get; set; }
    }
}