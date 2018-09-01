using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.DataAccess.Entities
{
    public class Employees_Skill
    {
        public Employee Employee { get; set; }
        public long Employee_Id { get; set; }
        public Skill Skill { get; set; }
        public int Skill_Id { get; set; }
        public Score Score { get; set; }
        public int Score_Id { get; set; }
    }
}
