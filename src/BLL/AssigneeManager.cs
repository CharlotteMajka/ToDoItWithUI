using System.Collections;
using System.Collections.Generic;
using DAL;
using Model;

namespace BLL
{
    public class AssigneeManager : IAssigneeManager
    {
        private IAssigneeRepository _assigneeRepository;

        public AssigneeManager(IAssigneeRepository assigneeManager)
        {
            _assigneeRepository = assigneeManager;
        }

        public List<Assignee> GetAllAssignees()
        {
            return _assigneeRepository.GetAllAssignees();
        }

        public Assignee createAssignee(Assignee assignee)
        {
            return _assigneeRepository.CreateAssignee(assignee);
        }

        public Assignee deleteAssignee(int id)
        {
            return _assigneeRepository.deleteAssignee(id);
        }
    }
}