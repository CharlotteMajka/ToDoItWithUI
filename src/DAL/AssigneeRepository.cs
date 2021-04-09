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

        public List<Assignee> GetAllAssignees()
        {
            return _ctx.Assignee.ToList();
        }

        public Assignee CreateAssignee(Assignee assignee)
        {
            var newAssignee = _ctx.Assignee.Add(assignee).Entity;
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
            return _ctx.Assignee.AsNoTracking().FirstOrDefault(a => a.Id == id);
        }
    }
}