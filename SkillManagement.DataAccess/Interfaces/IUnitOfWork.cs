using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IEmployeeRepository EmployeeRepository { get; }
        ISkillRepository SkillRepository { get; }
        IScoreRepository ScoreRepository { get; }

        void Complete();
    }
}
