using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo_rest_api
{
    public class Dashboard
    {
        public int CountTasksToday { get; set; }
        public List<TodoListDto> TodoLists { get; set; } 
    }
}