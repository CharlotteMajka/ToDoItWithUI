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

        public IEnumerable<Task> getAllTasks()
        {
            return _todoContext.Tasks;
        }

        public Task createNewTask(Task task)
        {
            var newTask = _todoContext.Tasks.Add(task).Entity;
            _todoContext.SaveChanges();
            return newTask;
        }

        public void updateTask(Task task)
        {
            var updatedTask = _todoContext.Tasks.Update(task).Entity;
            _todoContext.SaveChanges();
        }

        public void deleteTask(int id)
        {
            var deletedTask = getTaskByID(id);
            _todoContext.Tasks.Remove(deletedTask);
            _todoContext.SaveChanges();
        }

        public Task getTaskByID(int id)
        {
            return _todoContext.Tasks
                .AsNoTracking()
                .Include(t => t.Assignee)
                .FirstOrDefault(t => t.Id == id);
        }
    }
}