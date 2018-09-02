using System.Collections.Generic;
using SkillManagement.DataAccess.Core;
using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLRepositories;

namespace SkillManagement.DataAccess.Repositories
{
    public class SQLEmployeeRepository : GenericRepository<SQLEmployee, long>, ISQLEmployeeRepository
    {
        public SQLEmployeeRepository(IConnectionFactory connectionFactory) : base(connectionFactory, "Employees", true)
        {
        }
    }
}
