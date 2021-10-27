using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo_rest_api
{
    public class TasksListService
    {

        private List<TodoList> todoList = new List<TodoList>
            {
                new TodoList() { Id = 1, Title = "First standart data"},
                new TodoList() { Id = 2, Title = "Second standart data" }
            };

        private int lastId = 2;

        public List<TodoList> GetAllLists()
        {
            return todoList;
        }

        public List<Task> GetAllTasksByListId(int listId)
        {
            return todoList.Find(x => x.Id == listId).Tasks;
        }

        public TodoList GetById(int id)
        {
            return todoList.Find(x => x.Id == id);
        }

        public TodoList Create(TodoList item)
        {
            item.Id = ++lastId;
            todoList.Add(item);
            return item;
        }

        public void PutById(int id, Task item)
        {
            for (int i = 0; i < todoList.Count; ++i)
            {
                if (todoList[i].Id == id)
                {
                    item.Id = id;
                    todoList[i] = item;
                    break;
                }
            }
        }

        public void PatchTaskById(int listid, int taskId, Task task)
        {
            
            var listEditableTasks = todoList.Find(x => x.Id == listid).Tasks;
            var editableTask = listEditableTasks.Find(x => x.Id == taskId);

            editableTask.Title = task?.Title;
            editableTask.DueDate = task?.DueDate;
            editableTask.Description = task?.Description;
            editableTask.Done = task?.Done;
        }

        public void DeleteById(int id)
        {
            foreach(var item in todoList)
            {
                if(item.Id == id)
                {
                    todoList.Remove(item);
                }
            }
        }
    }
}