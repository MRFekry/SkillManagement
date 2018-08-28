using SkillManagement.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.DataAccess.Interfaces
{
    public interface IEmployeeService
    {
        int AddEmployee(Employee employee);

        void UpdateEmployee(Employee employee);

        void DeleteEmployee(Employee employee);
        Employee GetEmployeeById(long Id);
        IEnumerable<Employee> GetAllEmployees();
    }
}
