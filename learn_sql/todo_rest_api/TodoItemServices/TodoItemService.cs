using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace todo_rest_api
{
    public class TodoItemService
    {
        private TodoListContext _context;

        public TodoItemService(TodoListContext context)
        {
            _context = context;
        }

        public void AddTodoItem(NewTodoItemDto newTodoItemDto)
        {
            _context.TodoItems.Add(new TodoItem(newTodoItemDto));
            _context.SaveChanges();
        }

        public void AddTodoList(NewTodoListDto newTodoListDto)
        {
            _context.TodoLists.Add(new TodoList(newTodoListDto));
            _context.SaveChanges();
        }

        public List<TodoListDto> GetAllLists()
        {
            List<TodoListDto> listDto = new List<TodoListDto>();

            foreach (var todo in _context.TodoLists.Include(x => x.TodoItems))
            {
                listDto.Add(new TodoListDto(todo));
            }

            return listDto;
        }

        public TodoList GetTodoListById(int id)
        {
            return _context.TodoLists.Where(i => i.Id == id).Include(i => i.TodoItems).Single();
        }

        public List<TodoItem> GetAllItems()
        {
            return _context.TodoItems.ToList<TodoItem>();
        }

        public List<TodoItem> GetTodoItemsByListId(int id)
        {
            return _context.TodoLists.Where(l => l.Id == id).Include(l => l.TodoItems).Single().TodoItems;
        }


        // DASHBOARD

        public List<Dashboard> GetDashboard()
        {
            // SELECT COUNT(todo_items.done) FROM todo_lists 
            // RIGHT OUTER JOIN todo_items on todo_items.todo_list_id=todo_lists.id
            // WHERE todo_items.done='false' or todo_items.done=NULL;

            // Dashboard dashboard = new Dashboard();

            // dashboard.CountOpenTasksToday = _context.TodoItems.Where(t => t.DueDate.Equals(DateTime.Today)).Count();
            
            // dashboard.TodoListOpen = new List<TodoListDto>();//_context.TodoLists.Include(x => new List<TodoItemDto>(x.TodoItems));
            
            // foreach (var todo in _context.TodoLists.Include(x => x.TodoItems))
            // {
            //     dashboard.TodoListOpen.Add(new TodoListDto(todo));
            // }

            // List<TodoList> lists = _context.TodoLists.Include(x => x.TodoItems).ToList();
            // List<TodoItem> items = _context.TodoItems.ToList();

            // _context.TodoLists.GroupJoin

            var result = from l in _context.TodoLists
                         join c in _context.TodoItems on l.Id equals c.TodoListId into g
                         select _context.TodoItems;

            return result;
        }      

       
    }
}