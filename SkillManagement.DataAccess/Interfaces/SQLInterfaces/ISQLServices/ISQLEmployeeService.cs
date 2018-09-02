using SkillManagement.DataAccess.Entities.SQLEntities;
using System.Collections.Generic;

namespace SkillManagement.DataAccess.Interfaces
{
    public interface ISQLEmployeeService
    {
        int AddEmployee(SQLEmployee employee);

        void UpdateEmployee(SQLEmployee employee);

        void DeleteEmployee(SQLEmployee employee);
        SQLEmployee GetEmployeeById(long Id);
        IEnumerable<SQLEmployee> GetAllEmployees();
    }
}
