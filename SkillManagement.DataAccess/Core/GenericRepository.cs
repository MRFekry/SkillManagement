using Dapper;
using SkillManagement.DataAccess.Entities;
using SkillManagement.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace SkillManagement.DataAccess.Core
{
    public class GenericRepository<TEntity, TId> : IGenericRepository<TEntity, TId> where TEntity : IEntity<TId>
    {
        protected IConnectionFactory _connectionFactory;
        private readonly string _tableName;
        private readonly bool _isSoftDelete;

        public GenericRepository(IConnectionFactory connectionFactory, string tableName, bool isSoftDelete)
        {
            _connectionFactory = connectionFactory;
            _tableName = tableName;
            _isSoftDelete = isSoftDelete;
        }

        public long Add(TEntity entity)
        {
            var columns = GetColumns();
            var stringOfColumns = string.Join(", ", columns);
            var stringOfProperties = string.Join(", ", columns.Select(e => "@" + e));
            var query = "SP_InsertRecordToTable";

            using (var db = _connectionFactory.GetSqlConnection)
            {
                var InsertedEntityId = db.Execute(
                    sql: query,
                    param: new { P_tableName = _tableName, P_columnsString = stringOfColumns, P_propertiesString = stringOfProperties },
                    commandType: CommandType.StoredProcedure);

                return InsertedEntityId;
            }
        }

        public void Update(TEntity entity)
        {
            var columns = GetColumns();
            var stringOfColumns = string.Join(", ", columns.Select(e => $"{e} = @{e}"));
            
            using (var db = _connectionFactory.GetSqlConnection)
            {
                var query = "SP_UpdateRecordInTable";
                var UpdatedEntityId = db.Execute(
                    sql: query,
                    param: new { P_tableName = _tableName, P_columnsString = stringOfColumns, P_Id = entity.Id },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(TEntity entity)
        {
            if (_isSoftDelete) // applying soft delete
            {
                var columns = GetColumns();
                var isActiveColumnUpdateString = columns.Where(e => e == "IsActive").Select(e => $"{e} = 0");

                using (var db = _connectionFactory.GetSqlConnection)
                {
                    var query = "SP_UnActivateRecordInTable";
                    var result = db.Execute(
                        sql: query,
                        param: new { P_tableName = _tableName, P_columnsString = isActiveColumnUpdateString, P_Id = entity.Id },
                        commandType: CommandType.StoredProcedure);
                }
            }
            else // delete directly
            {
                using (var db = _connectionFactory.GetSqlConnection)
                {
                    var query = "SP_DeleteRecordFromTable";
                    var result = db.Execute(
                        sql: query,
                        param: new { P_tableName = _tableName, P_Id = entity.Id },
                        commandType: CommandType.StoredProcedure);
                }
            }
        }

        public TEntity Get(TId Id)
        {
            var query = "SP_InsertRecordToTable";

            using (var db = _connectionFactory.GetSqlConnection)
            {
                return db.Query<TEntity>(query,
                    new { P_tableName = _tableName, P_Id = Id },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            var query = "SP_GetAllRecordsFromTable";

            using (var db = _connectionFactory.GetSqlConnection)
            {
                return db.Query<TEntity>(query,
                    new { P_tableName = _tableName },
                    commandType: CommandType.StoredProcedure);
            }
        }

        private IEnumerable<string> GetColumns()
        {
            return typeof(TEntity)
                    .GetProperties()
                    .Where(e => e.Name != "Id" && !e.PropertyType.GetTypeInfo().IsGenericType)
                    .Select(e => e.Name);
        }
    }
}
