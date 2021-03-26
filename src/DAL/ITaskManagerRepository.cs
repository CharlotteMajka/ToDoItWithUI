using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace DAL
{
    public interface ITaskManagerRepository
    {
        public IEnumerable<Task> getAllTasks();
        public Task createNewTask(Task task);
        public void updateTask(Task task);
        public void deleteTask(int id);
        public Task getTaskByID(int id);
    }
}
