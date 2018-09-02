using SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLRepositories;

namespace SkillManagement.DataAccess.Interfaces
{
    public interface ISQLunitOfWork
    {
        ISQLEmployeeRepository SQLEmployeeRepository { get; }
        ISQLSkillRepository SQLSkillRepository { get; }
        ISQLScoreRepository SQLScoreRepository { get; }

        void Complete();
    }
}
