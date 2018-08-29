using Dapper;
using SkillManagement.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace SkillManagement.DataAccess.Core
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected IConnectionFactory _connectionFactory;
        public GenericRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public int Add(TEntity entity)
        {
            var columns = GetColumns();
            var stringOfColumns = string.Join(", ", columns);
            var stringOfProperties = string.Join(", ", columns.Select(e => "@" + e));
            var query = "SP_InsertRecordToTable";

            using (var db = _connectionFactory.GetSqlConnection)
            {
                var InsertedEntityId = db.Execute(
                    sql: query,
                    param: new { P_tableName = typeof(TEntity).Name, P_columnsString = stringOfColumns, P_propertiesString = stringOfProperties },
                    commandType: CommandType.StoredProcedure);

                return InsertedEntityId;
            }

            #region another way to get result using static query statement // commented
            //var query = "insert into " + typeof(TEntity).Name + "s (" + stringOfColumns + ") values (" + stringOfProperties + "); select cast(scope_Identity() as int)";
            //var InsertedEntityId = db.Query<int>(query, entity).First();
            #endregion
        }

        public void Update(TEntity entity)
        {
            var columns = GetColumns();
            var stringOfColumns = string.Join(", ", columns.Select(e => $"{e} = @{e}"));
            var query = $"update {typeof(TEntity).Name}s set {stringOfColumns} where Id = @Id";

            using (var db = _connectionFactory.GetSqlConnection)
            {
                db.Execute(query, entity);
            }

            #region another way to delete record using Stored Procedure, but need to pass Id as a parameter //commented
            //var query = "SP_UpdateRecordInTable";
            //var UpdatedEntityId = db.Execute(
            //    sql: query,
            //    param: new { P_tableName = typeof(TEntity).Name, P_columnsString = stringOfColumns },
            //    commandType: CommandType.StoredProcedure);
            #endregion
        }

        public void Delete(TEntity entity)
        {
            // applying soft delete
            var columns = GetColumns();
            var isActiveColumnUpdateString = columns.Where(e => e == "IsActive").Select(e => $"{e} = 0");
            var query = $"update {typeof(TEntity).Name}s set {isActiveColumnUpdateString} where Id = @Id";

            using (var db = _connectionFactory.GetSqlConnection)
            {
                db.Execute(query, entity);
            }

            #region Actual record deleting // commented
            //var query = $"delete from {typeof(TEntity).Name}s where Id = @Id";

            //using (var db = _connectionFactory.GetSqlConnection)
            //{
            //    db.Execute(query, entity);
            //}
            #endregion

            #region another way to delete record using Stored Procedure, but need to pass Id as a parameter //commented
            //using (var db = _connectionFactory.GetSqlConnection)
            //{
            //    var query = "SP_DeleteRecordFromTable";
            //    var result = db.Execute(
            //        sql: query,
            //        param: new { P_tableName = typeof(TEntity).Name, P_Id = entity.Id },
            //        commandType: CommandType.StoredProcedure);
            //}
            #endregion
        }

        public TEntity Get(long Id)
        {
            var query = $"select * from {typeof(TEntity).Name}s where Id = @Id";

            using (var db = _connectionFactory.GetSqlConnection)
            {
                return db.Query<TEntity>(query, new { Id }).FirstOrDefault();
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            var query = $"select * from {typeof(TEntity).Name}s";

            using (var db = _connectionFactory.GetSqlConnection)
            {
                return db.Query<TEntity>(query).ToList();
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
