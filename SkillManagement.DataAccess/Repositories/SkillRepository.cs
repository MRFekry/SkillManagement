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
    public class SkillRepository : GenericRepository<Skill>, ISkillRepository
    {
        public SkillRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }
    }
}
