using System.Collections.Generic;
using Model;

namespace BLL
{
    public interface IAssigneeManager
    {
        IEnumerable<Assignee> GetAllAssignees();
        Assignee createAssignee(Assignee assignee);
        Assignee deleteAssignee(int id);
    }
}