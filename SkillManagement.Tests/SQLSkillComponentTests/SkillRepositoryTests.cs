using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Infrastructure;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.DataAccess.Repositories;

namespace SkillManagement.Tests.SQLSkillComponentTests
{
    [TestClass]
    public class SkillRepositoryTests
    {
        private IConnectionFactory _connectionFactory;
        private SQLSkillRepository _sqlSkillRepository;

        [TestInitialize]
        public void Initialize()
        {
            _connectionFactory = new ConnectionFactory();
            _sqlSkillRepository = new SQLSkillRepository(_connectionFactory, true);
        }

        [TestMethod]
        public void Test_Add_New_Skill()
        {
            //Arrange
            var Skill = new SQLSkill
            {
                Name = "Soft Skills"
            };

            //Act
            _sqlSkillRepository.Add(Skill);

            //Assert
            //Check if Skill had been added to test database
        }

        [TestMethod]
        public void Test_Update_Existing_Skill()
        {
            //Arrange
            var Skill = new SQLSkill
            {
                Id = 1,
                Name = "Tech Skills"
            };

            //Act
            _sqlSkillRepository.Update(Skill);

            //Assert
            //Check if Skill had been added to test database
        }

        [TestMethod]
        public void Test_Get_All_Skills()
        {
            //Arrange
            // Act 
            var result = _sqlSkillRepository.GetAll();

            //Assert
            //check if result are the same as Test DB
            var checkResult = result;
        }

        [TestMethod]
        public void Test_Get_Skill_By_Id()
        {
            //Arrange
            var Skill = new SQLSkill
            {
                Id = 1,
                Name = "Tech Skills"
            };

            //Act
            var result = _sqlSkillRepository.Get(1);

            //Assert
            Assert.AreEqual(Skill.Id, result.Id);
            Assert.AreEqual(Skill.Name, result.Name);
            Assert.AreEqual(Skill.SkillParentCategory_Id, result.SkillParentCategory_Id);
        }

        [TestMethod]
        public void Test_Delete_Existing_Skill()
        {
            //Arrange
            var Skill = new SQLSkill
            {
                Id = 1,
                Name = "Tech Skills"
            };

            //Act
            _sqlSkillRepository.Delete(Skill);

            //Assert
            //check if record had been deleted from test database
        }
    }
}
