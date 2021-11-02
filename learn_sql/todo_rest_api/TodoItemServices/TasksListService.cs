using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace todo_rest_api
{
    // old
    public class TasksListService
    {
        private List<TodoList> todoList = new List<TodoList>
            {
                new TodoList() {
                    Id = 1, Title = "First standart data",
                    TodoItems = new List<TodoItem>()
                        {
                           new TodoItem() {Id = 1, Title = "Task 1, List 1"},
                        }},
                new TodoList() {
                    Id = 2, Title = "Second standart data",
                    TodoItems = new List<TodoItem>()
                        {
                           new TodoItem() {Id = 2, Title = "Task 2, List 2"},
                        }}
            };


        private int lastListId = 2;
        private int lastTaskId = 2;


        // main to do list
        public List<TodoList> GetAllLists()
        {
            return todoList;
        }


        public TodoList GetTodoListById(int id)
        {
            return todoList.Find(x => x.Id == id);
        }


        public TodoList CreateTodoList(TodoList item)
        {
            item.Id = ++lastListId;
            todoList.Add(item);
            return item;
        }


        public void DeleteTodoListById(int id)
        {
            foreach (var todo in todoList)
            {
                if (todo.Id == id)
                {
                    todoList.Remove(todo);
                }
            }
        }


        // For tasks
        public TodoItem GetTaskById(int taskId)
        {
            TodoItem task = FindTask(taskId);

            return task;
        }


        public List<TodoItem> GetAllTasks()
        {
            List<TodoItem> tasks = new List<TodoItem>();

            foreach (var todo in todoList)
            {
                foreach (var task in todo.TodoItems)
                {
                    tasks.Add(task);
                }
            }

            return tasks;
        }


        public List<TodoItem> GetTasksByListId(int listId)
        {
            return todoList.Find(x => x.Id == listId).TodoItems;
        }


        public void CreateTaskInList(int listId, TodoItem item)
        {
            var listForAddTask = GetTodoListById(listId);
            item.Id = ++lastTaskId;
            listForAddTask.TodoItems.Add(item);
        }


        public void PutTaskById(int taskId, TodoItem task)
        {
            var currentTodoList = FindTodoByTaskId(taskId);

            for (int j = 0; j < currentTodoList.TodoItems.Count; ++j)
            {
                if (currentTodoList.TodoItems[j].Id == taskId)
                {
                    task.Id = taskId;
                    currentTodoList.TodoItems[j] = task;
                    break;
                }
            }
        }


        public void PatchTask(int taskId, TodoItem task)
        {
            var editableTask = FindTask(taskId);

            editableTask.Title = task?.Title;
            editableTask.DueDate = task?.DueDate;
            editableTask.Description = task?.Description;
            editableTask.Done = task?.Done;
        }
  
        
        public void DeleteTask(int taskId)
        {
            var editListTask = FindTodoByTaskId(taskId).TodoItems;

            var removableTask = editListTask.Find(x => x.Id == taskId);

            editListTask.Remove(removableTask);
        }


        public TodoList FindTodoByTaskId(int taskId)
        {
            foreach(var todo in todoList)
            {
                foreach(var task in todo.TodoItems)
                {
                    if (task.Id == taskId)
                        return todo;
                }
            }
            return null;
        }


        public TodoItem FindTask(int taskId)
        {
            foreach(var todo in todoList)
            {
                foreach(var task in todo.TodoItems)
                {
                    if (task.Id == taskId)
                        return task;
                }
            }
            return null;
        }


    }
}