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
                    Id = 1, Title = "First standart data", LastTaskId = 1,
                    Tasks = new List<Task>()
                        {
                           new Task() {Id = 1, Title = "Task 1, List 1"},
                        }},
                new TodoList() {
                    Id = 2, Title = "Second standart data", LastTaskId = 1,
                    Tasks = new List<Task>()
                        {
                           new Task() {Id = 1, Title = "Task 1, List 2"},
                        }}
            };


        private int lastId = 2;


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
            item.Id = ++lastId;
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
        public Task GetTaskById(int listId, int id)
        {
            List<Task> tasks = GetTodoListById(listId).Tasks;

            return tasks.Find(x => x.Id == id);
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
            item.Id = ++listForAddTask.LastTaskId;
            listForAddTask.Tasks.Add(item);
        }

        public void PutTaskById(int listId, int id, Task task)
        {
            var currentTodoList = GetTodoListById(listId);

            for (int j = 0; j < currentTodoList.Tasks.Count; ++j)
            {
                if (currentTodoList.Tasks[j].Id == id)
                {
                    task.Id = id;
                    currentTodoList.Tasks[j] = task;
                    break;
                }
            }
        }


        public void PatchTask(int listId, int taskId, Task task)
        {
            var editableTask = GetTaskById(listId, taskId);

            editableTask.Title = task?.Title;
            editableTask.DueDate = task?.DueDate;
            editableTask.Description = task?.Description;
            editableTask.Done = task?.Done;
        }
  
        
        public void DeleteTask(int listId, int id)
        {
            var removeTask = GetTaskById(listId, id);

            GetTodoListById(listId).Tasks.Remove(removeTask);
        }

    }
}