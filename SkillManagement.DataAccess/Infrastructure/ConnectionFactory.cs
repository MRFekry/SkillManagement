using SkillManagement.DataAccess.Interfaces;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace SkillManagement.DataAccess.Infrastructure
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly string sqlConnectionString = ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString;
        
        public IDbConnection GetSqlConnection
        {
            get
            {
                var connection = new SqlConnection(sqlConnectionString);
                connection.Open();

                return connection;
            }
        }
    }
}
