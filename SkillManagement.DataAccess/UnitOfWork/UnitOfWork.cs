using SkillManagement.DataAccess.Interfaces;
using System;

namespace SkillManagement.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IEmployeeRepository _employeeRepository;
        public UnitOfWork(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IEmployeeRepository EmployeeRepository
        {
            get
            {
                return _employeeRepository;
            }
        }

        public void Complete()
        {
            throw new NotImplementedException();
        }
    }
}
