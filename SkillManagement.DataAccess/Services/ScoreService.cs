using SkillManagement.DataAccess.Entities;
using SkillManagement.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.DataAccess.Services
{
    public class ScoreService : IScoreService
    {
        IUnitOfWork _unitOfWork;
        public ScoreService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int AddScore(Score score)
        {
            return _unitOfWork.ScoreRepository.Add(score);
        }

        public void DeleteScore(Score score)
        {
            _unitOfWork.ScoreRepository.Delete(score);
        }

        public IEnumerable<Score> GetAllScores()
        {
            return _unitOfWork.ScoreRepository.GetAll();
        }

        public Score GetScoreById(int Id)
        {
            return _unitOfWork.ScoreRepository.Get(Id);
        }

        public void UpdateScore(Score score)
        {
            _unitOfWork.ScoreRepository.Update(score);
        }
    }
}
