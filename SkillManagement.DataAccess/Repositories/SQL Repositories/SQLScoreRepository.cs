﻿using SkillManagement.DataAccess.Core;
using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLRepositories;
using System.Configuration;

namespace SkillManagement.DataAccess.Repositories
{
    public class SQLScoreRepository : GenericRepository<SQLScore, int>, ISQLScoreRepository
    {
        public SQLScoreRepository(IConnectionFactory connectionFactory, bool IsTest) : base(connectionFactory, "Scores", false)
        {
            if (!IsTest)
                connectionFactory.SetConnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString);
        }
    }
}
