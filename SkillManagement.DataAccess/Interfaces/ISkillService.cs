using SkillManagement.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.DataAccess.Interfaces
{
    public interface ISkillService
    {
        int AddSkill(Skill skill);

        void UpdateSkill(Skill skill);

        void DeleteSkill(Skill skill);

        Skill GetSkillById(int Id);

        IEnumerable<Skill> GetAllSkills();
    }
}
