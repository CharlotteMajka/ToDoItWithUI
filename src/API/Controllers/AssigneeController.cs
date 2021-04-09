using System;
using System.Collections.Generic;
using BLL;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssigneeController : ControllerBase
    {
        private readonly IAssigneeManager _assigneeManager;

        public AssigneeController(IAssigneeManager assigneeManager)
        {
            _assigneeManager = assigneeManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Assignee>> Get()
        {
            try
            {
                return Ok(_assigneeManager.GetAllAssignees());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost]
        public ActionResult<Assignee> Post(Assignee assignee)
        {
            try
            {
                return Ok(_assigneeManager.createAssignee(assignee));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                return Ok(_assigneeManager.deleteAssignee(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}