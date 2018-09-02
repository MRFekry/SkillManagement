using SkillManagement.DataAccess.Core;
using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLRepositories;

namespace SkillManagement.DataAccess.Repositories
{
    public class SQLSkillRepository : GenericRepository<SQLSkill, int>, ISQLSkillRepository
    {
        public SQLSkillRepository(IConnectionFactory connectionFactory) : base(connectionFactory, "Skills", false)
        {
        }
    }
}
