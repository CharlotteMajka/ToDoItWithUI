using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Model;
using BLL;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : Controller
    {
        private TaskManager taskManager = new TaskManager();

        [HttpGet]
        public IEnumerable<Task> Get(string searchTerm)
        {
            return taskManager.getAllTasks();
        }
        
        [HttpPost]
        public Task Post(Task task)
        {
            return taskManager.createNewTask(task);
        }
        
        [HttpPut]
        public void Put(Task task)
        {
            taskManager.updateTask(task);
        }
        
        
        [HttpDelete]
        public void Delete(int id)
        {
            taskManager.deleteTask(id);
        }
    }
}