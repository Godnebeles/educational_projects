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

            foreach(var todo in _context.TodoLists.Include(x => x.TodoItems))
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
        
    }
}