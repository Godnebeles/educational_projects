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
            var result = _context.TodoLists
                        .Include(x => x.TodoItems)
                        .Select(x => new TodoListDto(x))
                        .ToList();

            return result;
        }

        public TodoList GetTodoListById(int id)
        {
            return _context.TodoLists.Where(i => i.Id == id).Include(i => i.TodoItems).Single();
        }

        public List<TodoItemDto> GetAllItems()
        {
            return _context.TodoItems.Include(l => l.TodoList).Select(l => new TodoItemDto(l)).ToList();
        }

        public List<TodoItem> GetAllOpenTasks()
        {
            return _context.TodoItems.ToList<TodoItem>();
        }

        public List<TodoItemDto> GetAllTodoItemsByListId(int listId)
        {
            return _context.TodoItems
                    .Include(l => l.TodoList)
                    .Where(l => l.TodoListId == listId)
                    .Select(l => new TodoItemDto(l)).ToList();
        }

        public List<TodoItemDto> GetOpenTodoItemsByListId(int listId)
        {
            return _context.TodoItems
                    .Include(l => l.TodoList)
                    .Where(l => l.TodoListId == listId && l.Done == false)
                    .Select(l => new TodoItemDto(l)).ToList();
        }

        public List<TodoItemDto> GetCollectionTodoItemsToday()
        {
            return _context.TodoItems
                    .Include(l => l.TodoList)
                    .Where(l => l.DueDate.Value.Date.Equals(DateTime.Today.Date))
                    .Select(l => new TodoItemDto(l)).ToList();
        }

        // DASHBOARD
        public Dashboard GetDashboard()
        {

            // SELECT todo_lists.Id, todo_lists.title, COUNT(todo_items.done) FROM todo_lists
            // LEFT JOIN todo_items ON todo_items.todo_list_id = todo_lists.id
            // WHERE todo_items IS Null OR todo_items.done = 'false'
            // GROUP BY todo_lists.Id
            // ORDER BY todo_lists.Id;

            var countOpenTasksToday = _context.TodoItems
                                            .Where(t => t.DueDate.Value.Date
                                            .Equals(DateTime.Today.Date) && t.Done == (false))
                                            .Count();

            var result = _context.TodoLists
                        .Include(l => l.TodoItems)
                        .Select(l => new TodoListDto()
                        {
                            Id = l.Id,
                            Title = l.Title,
                            CountOpenTasks = l.TodoItems.Where(t => t.Done.Equals(false)).Count()
                        })
                        .OrderBy(l => l.Id)
                        .ToList();

            return new Dashboard() { CountTasksToday = countOpenTasksToday, TodoLists = result };
        }

        // COLLECTION TODAY
    }
}