using SkillManagement.DataAccess.Core;

namespace SkillManagement.DataAccess.Entities
{
    public class Employee : AuditBase
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
