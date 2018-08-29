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
    public class SkillController : ApiController
    {
        #region Properties

        private ISkillService _skillService;

        #endregion

        #region Constructors

        public SkillController()
        {

        }

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        #endregion
        // GET: Get all skills
        [Route("Skills")]
        [HttpGet]
        public IEnumerable<Skill> Get()
        {
            return _skillService.GetAllSkills();
        }

        // GET: Get skill by id
        [Route("Skill/{Id}")]
        [HttpGet]
        public Skill Get(int id)
        {
            return _skillService.GetSkillById(id);
        }

        // POST: Add new skill
        [Route("Skills")]
        [HttpPost]
        public int Post([FromBody]Skill skill)
        {
            return _skillService.AddSkill(skill);
        }

        // PUT: Update existing skill
        [Route("Skill/{skill}")]
        [HttpPut]
        public void Put(int id, [FromBody]Skill skill)
        {
            _skillService.UpdateSkill(skill);
        }

        // DELETE: Delete existing skill
        [Route("Skill/{skill}")]
        [HttpDelete]
        public void Delete([FromBody]Skill skill)
        {
            _skillService.DeleteSkill(skill);
        }
    }
}
