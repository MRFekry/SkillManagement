using SkillManagement.DataAccess.Entities;
using SkillManagement.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.DataAccess.Services
{
    public class SkillService : ISkillService
    {
        IUnitOfWork _unitOfWork;
        public SkillService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int AddSkill(Skill skill)
        {
            return _unitOfWork.SkillRepository.Add(skill);
        }

        public void DeleteSkill(Skill skill)
        {
            _unitOfWork.SkillRepository.Delete(skill);
        }

        public IEnumerable<Skill> GetAllSkills()
        {
            return _unitOfWork.SkillRepository.GetAll();
        }

        public Skill GetSkillById(int Id)
        {
            return _unitOfWork.SkillRepository.Get(Id);
        }

        public void UpdateSkill(Skill skill)
        {
            _unitOfWork.SkillRepository.Update(skill);
        }
    }
}
