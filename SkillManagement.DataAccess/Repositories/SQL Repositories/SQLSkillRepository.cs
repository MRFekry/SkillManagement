using SkillManagement.DataAccess.Core;
using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLRepositories;
using System.Configuration;

namespace SkillManagement.DataAccess.Repositories
{
    public class SQLSkillRepository : GenericRepository<SQLSkill, int>, ISQLSkillRepository
    {
        public SQLSkillRepository(IConnectionFactory connectionFactory, bool IsTest) : base(connectionFactory, "Skills", false)
        {
            if (!IsTest)
                connectionFactory.SetConnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString);
        }
    }
}
