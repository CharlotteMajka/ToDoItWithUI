using DAL;
using System;
using System.Collections.Generic;
using Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BLL
{
    public class TaskManagerRepository
    {
        readonly TodoContext _ctx = new TodoContext();

        public TaskManagerRepository()
        {
        }

        public IEnumerable<Task> getAllTasks()
        {
            return _ctx.Tasks;
        }

        public Task createNewTask(Task task)
        {
            var newTask = _ctx.Tasks.Add(task).Entity;
            _ctx.SaveChanges();
            return newTask;
        }

        public void updateTask(Task task)
        {
            var updatedTask = _ctx.Tasks.Update(task).Entity;
            _ctx.SaveChanges();
        }

        public void deleteTask(int id)
        {
            var deletedTask = getTaskByID(id);
            _ctx.Tasks.Remove(deletedTask);
            _ctx.SaveChanges();
        }

        private Task getTaskByID(int id)
        {
            return _ctx.Tasks
                .AsNoTracking()
                .Include(t => t.Assignee)
                .FirstOrDefault(t => t.Id == id);
        }
    }
}