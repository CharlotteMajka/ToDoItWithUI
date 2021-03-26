using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Model;

namespace DAL
{
    public class AssigneeRepository : IAssigneeRepository
    {
        private TodoContext _ctx;

        public AssigneeRepository(TodoContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Assignee> GetAllAssignees()
        {
            return _ctx.Assignees;
        }

        public Assignee CreateAssignee(Assignee assignee)
        {
            var newAssignee = _ctx.Assignees.Add(assignee).Entity;
            _ctx.SaveChanges();
            return newAssignee;
        }

        public Assignee deleteAssignee(int id)
        {
            var deleteAssignee = _ctx.Remove(new Assignee() { Id = id });
            _ctx.SaveChangesAsync();
            return deleteAssignee.Entity;
        }

        private Assignee getAssigneeById(int id)
        {
            return _ctx.Assignees.AsNoTracking().FirstOrDefault(a => a.Id == id);
        }
    }
}