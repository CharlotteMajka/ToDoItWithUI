using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace BLL
{
    public class TaskManager: ITaskManager
    {
        private readonly ITaskManagerRepository _taskManagerRepository;

        public TaskManager(ITaskManagerRepository taskManagerRepository)
        {
            _taskManagerRepository = taskManagerRepository;
        }
        public List<Task> getAllTasks()
        {
            return _taskManagerRepository.getAllTasks();
        }

        public Task createNewTask(Task task)
        {
            return _taskManagerRepository.createNewTask(task);
        }

        public void updateTask(Task task)
        {
            _taskManagerRepository.updateTask(task);
        }

        public void deleteTask(int id)
        {
            _taskManagerRepository.deleteTask(id);
        }


    }
}
