using SkillManagement.DataAccess.Interfaces;
using System;

namespace SkillManagement.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ISkillRepository _skillRepository;
        public UnitOfWork(IEmployeeRepository employeeRepository, ISkillRepository skillRepository)
        {
            _employeeRepository = employeeRepository;
            _skillRepository = skillRepository;
        }
        public IEmployeeRepository EmployeeRepository
        {
            get
            {
                return _employeeRepository;
            }
        }

        public ISkillRepository SkillRepository
        {
            get
            {
                return _skillRepository;
            }
        }

        public void Complete()
        {
            throw new NotImplementedException();
        }
    }
}
