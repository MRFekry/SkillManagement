using SkillManagement.DataAccess.Core;
using SkillManagement.DataAccess.Entities;
using SkillManagement.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.DataAccess.Repositories
{
    public class ScoreRepository : GenericRepository<Score>, IScoreRepository
    {
        public ScoreRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
    }
}
