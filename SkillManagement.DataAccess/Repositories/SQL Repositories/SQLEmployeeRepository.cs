using System.Collections.Generic;
using System.Configuration;
using SkillManagement.DataAccess.Core;
using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLRepositories;

namespace SkillManagement.DataAccess.Repositories
{
    public class SQLEmployeeRepository : GenericRepository<SQLEmployee, long>, ISQLEmployeeRepository
    {
        private static readonly string _tableName = "Employees";
        private static readonly bool _isSoftDelete = true;
        public SQLEmployeeRepository(IConnectionFactory connectionFactory, bool IsTest) : base(connectionFactory, _tableName, _isSoftDelete)
        {
            if(!IsTest)
                connectionFactory.SetConnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString);
        }
    }
}
