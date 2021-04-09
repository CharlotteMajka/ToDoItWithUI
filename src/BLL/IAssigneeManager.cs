using System.Collections.Generic;
using Model;

namespace BLL
{
    public interface IAssigneeManager
    {
        List<Assignee> GetAllAssignees();
        Assignee createAssignee(Assignee assignee);
        Assignee deleteAssignee(int id);
    }
}