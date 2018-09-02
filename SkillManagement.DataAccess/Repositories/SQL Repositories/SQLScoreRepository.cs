using SkillManagement.DataAccess.Core;
using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLRepositories;

namespace SkillManagement.DataAccess.Repositories
{
    public class SQLScoreRepository : GenericRepository<SQLScore, int>, ISQLScoreRepository
    {
        public SQLScoreRepository(IConnectionFactory connectionFactory) : base(connectionFactory, "Scores", false)
        {

        }
    }
}
