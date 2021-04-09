using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Model;
using BLL;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private ITaskManager _taskManager;

        public TaskController(ITaskManager taskManager)
        {
            _taskManager = taskManager;
        }

        [HttpGet]
        public ActionResult<List<Task>> Get()
        {
            return _taskManager.getAllTasks();
         
        }
        
        [HttpPost]
        public Task Post(Task task)
        {
            return _taskManager.createNewTask(task);
        }
        
        [HttpPut]
        public void Put(Task task)
        {
            _taskManager.updateTask(task);
        }
        
        
        [HttpDelete]
        public void Delete(int id)
        {
            _taskManager.deleteTask(id);
        }
    }
}