using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace BLL
{
    public class TaskManager
    {
        private readonly TaskManagerRepository taskManagerRepository = new TaskManagerRepository();
        public IEnumerable<Task> getAllTasks()
        {
            return taskManagerRepository.getAllTasks();
        }

        public Task createNewTask(Task task)
        {
            return taskManagerRepository.createNewTask(task);
        }

        public void updateTask(Task task)
        {
            taskManagerRepository.updateTask(task);
        }

        public void deleteTask(int id)
        {
            taskManagerRepository.deleteTask(id);
        }


    }
}
