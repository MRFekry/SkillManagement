using SkillManagement.DataAccess.Interfaces;

namespace SkillManagement.DataAccess.Entities.SQLEntities
{
    public class SQLEmployees_Skill : IEntity<long>
    {
        public long Id { get; set; }
        public SQLEmployee Employee { get; set; }
        public long Employee_Id { get; set; }
        public SQLSkill Skill { get; set; }
        public int Skill_Id { get; set; }
        public SQLScore Score { get; set; }
        public int Score_Id { get; set; }
    }
}
