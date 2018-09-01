using System.Collections.Generic;
using SkillManagement.DataAccess.Core;
using SkillManagement.DataAccess.Entities;
using SkillManagement.DataAccess.Interfaces;

namespace SkillManagement.DataAccess.Repositories
{
    public class EmployeeSQLRepository : GenericRepository<Employee, long>, IEmployeeRepository<string>
    {


    }


    public class EmployeeRepository : GenericRepository<Employee, long>, IEmployeeRepository<long>
    {
        public EmployeeRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public int Add(IEntity<long> entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(IEntity<long> entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(IEntity<long> entity)
        {
            throw new System.NotImplementedException();
        }

        IEntity<long> IGenericRepository<IEntity<long>, long>.Get(long Id)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<IEntity<long>> IGenericRepository<IEntity<long>, long>.GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
