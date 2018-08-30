using SkillManagement.DataAccess.Interfaces;
using System;

namespace SkillManagement.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly IScoreRepository _scoreRepository;
        public UnitOfWork(IEmployeeRepository employeeRepository, ISkillRepository skillRepository, IScoreRepository scoreRepository)
        {
            _employeeRepository = employeeRepository;
            _skillRepository = skillRepository;
            _scoreRepository = scoreRepository;
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

        public IScoreRepository ScoreRepository
        {
            get
            {
                return _scoreRepository;
            }
        }

        public void Complete()
        {
            throw new NotImplementedException();
        }
    }
}
