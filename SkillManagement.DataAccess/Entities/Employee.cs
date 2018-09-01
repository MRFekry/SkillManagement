using SkillManagement.DataAccess.Core;

namespace SkillManagement.DataAccess.Entities
{
    public class Employee : ISQLDBEntity  //IEntity<long>//  AuditBase
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }

    public interface IEntity<T>
    {
        T Id { get; set; }
    }

    public interface IMongoDBEntity : IEntity<string>
    {
        //T Id { get; set; }
    }

    public interface ISQLDBEntity : IEntity<long>
    {
        //T Id { get; set; }
    }
}
