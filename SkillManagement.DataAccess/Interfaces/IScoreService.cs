using SkillManagement.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.DataAccess.Interfaces
{
    public interface IScoreService
    {
        int AddScore(Score score);
        void UpdateScore(Score score);
        void DeleteScore(Score score);
        Score GetScoreById(int Id);
        IEnumerable<Score> GetAllScores();
    }
}
