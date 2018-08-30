using SkillManagement.DataAccess.Entities;
using SkillManagement.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SkillManagement.WebAPI.Controllers
{
    public class ScoreController : ApiController
    {
        IScoreService _scoreService;
        public ScoreController(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }
        // GET: Get all Scores
        [Route("Scores")]
        [HttpGet]
        public IEnumerable<Score> Get()
        {
            return _scoreService.GetAllScores();
        }

        // GET: Get score by id
        [Route("Score/{Id}")]
        [HttpGet]
        public Score Get(int id)
        {
            return _scoreService.GetScoreById(id);
        }

        // POST: Add new score
        [Route("Scores")]
        [HttpPost]
        public int Post([FromBody]Score score)
        {
            return _scoreService.AddScore(score);
        }

        // PUT: Update existing score
        [Route("Score/{score}")]
        [HttpPut]
        public void Put(int id, [FromBody]Score score)
        {
            _scoreService.UpdateScore(score);
        }

        // DELETE: Delete existing score
        [Route("Score/{score}")]
        [HttpDelete]
        public void Delete(Score score)
        {
            _scoreService.DeleteScore(score);
        }
    }
}
