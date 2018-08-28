using SkillManagement.DataAccess.Core;
using SkillManagement.DataAccess.Entities;
using SkillManagement.DataAccess.Interfaces;

namespace SkillManagement.DataAccess.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }
    }
}
