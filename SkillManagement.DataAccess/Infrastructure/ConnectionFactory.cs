using SkillManagement.DataAccess.Interfaces;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace SkillManagement.DataAccess.Infrastructure
{
    public class ConnectionFactory : IConnectionFactory
    {
        private static readonly string _connectionString;
        //private readonly string sqlConnectionString = ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString;
        //private readonly string sqlTestConnectionString = ConfigurationManager.ConnectionStrings["SQLTestConnection"].ConnectionString;
        
        public IDbConnection GetSqlConnection
        {
            get
            {
                SqlConnection connection;

                if (!string.IsNullOrEmpty(_connectionString))
                    connection = new SqlConnection(_connectionString);
                else
                    connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLTestConnection"].ConnectionString);

                connection.Open();

                return connection;
            }
        }
    }
}
