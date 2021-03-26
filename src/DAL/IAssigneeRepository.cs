using System.Collections.Generic;
using Model;

namespace DAL
{
    public interface IAssigneeRepository
    {
        IEnumerable<Assignee> GetAllAssignees();
        Assignee CreateAssignee(Assignee assignee);
        Assignee deleteAssignee(int id);
    }
}