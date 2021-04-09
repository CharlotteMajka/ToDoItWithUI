using DAL;
using System;
using System.Collections.Generic;
using Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BLL
{
    public class TaskManagerRepository: ITaskManagerRepository
    {
        private readonly TodoContext _todoContext;

        public TaskManagerRepository(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        public List<Task> getAllTasks()
        {
            return _todoContext.Task.Include(t => t.Assignee).ToList();
        }

        public Task createNewTask(Task task)
        {
            var newTask = _todoContext.Task.Add(task).Entity;
            _todoContext.SaveChanges();
            return newTask;
        }

        public void updateTask(Task task)
        {
            var updatedTask = _todoContext.Task.Update(task).Entity;
            _todoContext.SaveChanges();
        }

        public void deleteTask(int id)
        {
            var deletedTask = getTaskByID(id);
            _todoContext.Task.Remove(deletedTask);
            _todoContext.SaveChanges();
        }

        public Task getTaskByID(int id)
        {
            return _todoContext.Task
                .AsNoTracking()
                .Include(t => t.Assignee)
                .FirstOrDefault(t => t.TaskId == id);
        }
    }
}