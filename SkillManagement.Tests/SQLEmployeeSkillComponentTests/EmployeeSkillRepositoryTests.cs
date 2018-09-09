using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Infrastructure;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.DataAccess.Repositories.SQL_Repositories;

namespace SkillManagement.Tests.SQLEmployeeSkillComponentTests
{
    [TestClass]
    public class EmployeeSkillRepositoryTests
    {
        private IConnectionFactory _connectionFactory;
        private SQLEmployeeSkillRepository _sqlEmployeeSkillRepository;

        [TestInitialize]
        public void Initialize()
        {
            _connectionFactory = new ConnectionFactory();
            _sqlEmployeeSkillRepository = new SQLEmployeeSkillRepository(_connectionFactory, true);
        }

        [TestMethod]
        public void Test_Add_New_EmployeeSkill()
        {
            //Arrange
            SQLEmployees_Skill EmployeeSkill = new SQLEmployees_Skill
            {
                Id = 1,
                Employee_Id = 2,
                Skill_Id = 1,
                Score_Id = 1
            };

            //Act
            _sqlEmployeeSkillRepository.Add(EmployeeSkill);

            //Assert
            //Check if EmployeeSkill had been added to test database
        }

        [TestMethod]
        public void Test_Update_Existing_EmployeeSkill()
        {
            //Arrange
            SQLEmployees_Skill EmployeeSkill = new SQLEmployees_Skill
            {
                Id = 1,
                Employee_Id = 1,
                Skill_Id = 2,
                Score_Id = 2
            };

            //Act
            _sqlEmployeeSkillRepository.Update(EmployeeSkill);

            //Assert
            //Check if EmployeeSkill had been added to test database
        }

        [TestMethod]
        public void Test_Get_All_EmployeeSkills()
        {
            //Arrange
            // Act 
            var result = _sqlEmployeeSkillRepository.GetAll();

            //Assert
            //check if result are the same as Test DB
            var checkResult = result;
        }

        [TestMethod]
        public void Test_Get_EmployeeSkill_By_Id()
        {
            //Arrange
            SQLEmployees_Skill EmployeeSkill = new SQLEmployees_Skill
            {
                Id = 1,
                Employee_Id = 1,
                Skill_Id = 1,
                Score_Id = 2
            };

            //Act
            var result = _sqlEmployeeSkillRepository.Get(1);

            //Assert
            Assert.AreEqual(EmployeeSkill.Id, result.Id);
            Assert.AreEqual(EmployeeSkill.Employee_Id, result.Employee_Id);
            Assert.AreEqual(EmployeeSkill.Skill_Id, result.Skill_Id);
            Assert.AreEqual(EmployeeSkill.Score_Id, result.Score_Id);
        }

        [TestMethod]
        public void Test_Delete_Existing_EmployeeSkill()
        {
            //Arrange
            SQLEmployees_Skill EmployeeSkill = new SQLEmployees_Skill
            {
                Id = 2,
                Employee_Id = 2,
                Skill_Id = 1,
                Score_Id = 1
            };

            //Act
            _sqlEmployeeSkillRepository.Delete(EmployeeSkill);

            //Assert
            //check if record had been deleted from test database
        }
    }
}
