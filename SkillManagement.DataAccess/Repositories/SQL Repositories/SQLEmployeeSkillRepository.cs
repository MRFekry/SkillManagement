﻿using Dapper;
using SkillManagement.DataAccess.Core;
using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLRepositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.DataAccess.Repositories.SQL_Repositories
{
    public class SQLEmployeeSkillRepository : GenericRepository<SQLEmployees_Skill, long>, ISQLEmployeeSkillRepository
    {
        private static readonly string _tableName = "Employees_Skills";
        public SQLEmployeeSkillRepository(IConnectionFactory connectionFactory, bool IsTest) : base(connectionFactory, _tableName, false)
        {
            if (!IsTest)
                connectionFactory.SetConnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString);
        }

        public IEnumerable<SQLEmployees_Skill> GetAllEmployeeSkillsByEmployeeId(long employeeId)
        {
            var query = "SP_GetAllEmployeeSkillsByEmployeeId";

            using (var db = _connectionFactory.GetSqlConnection)
            {
                return db.Query<SQLEmployees_Skill>(query,
                    new { P_Id = employeeId },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
