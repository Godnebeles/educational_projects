using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace todo_rest_api
{
    public class TasksListService
    {
        private List<TodoList> todoList = new List<TodoList>
            {
                new TodoList() {
                    Id = 1, Title = "First standart data",
                    Tasks = new List<Task>()
                        {
                           new Task() {Id = 1, Title = "Task 1, List 1"},
                        }},
                new TodoList() {
                    Id = 2, Title = "Second standart data",
                    Tasks = new List<Task>()
                        {
                           new Task() {Id = 2, Title = "Task 2, List 2"},
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
        public Task GetTaskById(int taskId)
        {
            Task task = FindTask(taskId);

            return task;
        }


        public List<Task> GetAllTasks()
        {
            List<Task> tasks = new List<Task>();

            foreach (var todo in todoList)
            {
                foreach (var task in todo.Tasks)
                {
                    tasks.Add(task);
                }
            }

            return tasks;
        }


        public List<Task> GetTasksByListId(int listId)
        {
            return todoList.Find(x => x.Id == listId).Tasks;
        }


        public void CreateTaskInList(int listId, Task item)
        {
            var listForAddTask = GetTodoListById(listId);
            item.Id = ++lastTaskId;
            listForAddTask.Tasks.Add(item);
        }


        public void PutTaskById(int taskId, Task task)
        {
            var currentTodoList = FindTodoByTaskId(taskId);

            for (int j = 0; j < currentTodoList.Tasks.Count; ++j)
            {
                if (currentTodoList.Tasks[j].Id == taskId)
                {
                    task.Id = taskId;
                    currentTodoList.Tasks[j] = task;
                    break;
                }
            }
        }


        public void PatchTask(int taskId, Task task)
        {
            var editableTask = FindTask(taskId);

            editableTask.Title = task?.Title;
            editableTask.DueDate = task?.DueDate;
            editableTask.Description = task?.Description;
            editableTask.Done = task?.Done;
        }
  
        
        public void DeleteTask(int taskId)
        {
            var editListTask = FindTodoByTaskId(taskId).Tasks;

            var removableTask = editListTask.Find(x => x.Id == taskId);

            editListTask.Remove(removableTask);
        }


        public TodoList FindTodoByTaskId(int taskId)
        {
            foreach(var todo in todoList)
            {
                foreach(var task in todo.Tasks)
                {
                    if (task.Id == taskId)
                        return todo;
                }
            }
            return null;
        }


        public Task FindTask(int taskId)
        {
            foreach(var todo in todoList)
            {
                foreach(var task in todo.Tasks)
                {
                    if (task.Id == taskId)
                        return task;
                }
            }
            return null;
        }


    }
}