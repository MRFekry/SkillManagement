using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.DataAccess.Services;
using SkillManagement.DataAccess.Services.SQL_Services;
using System.Collections.Generic;
using System.Linq;

namespace SkillManagement.Tests.SQLEmployeeSkillSkillComponentTests
{
    [TestClass]
    public class EmployeeSkillSkillServiceTests
    {
        private Mock<ISQLunitOfWork> _sqlUnitOfWorkMock;
        private SQLEmployeeSkillService _sqlEmployeeSkillService;
        List<SQLEmployees_Skill> _sqlEmployeeSkillList;

        [TestInitialize]
        public void Initialize()
        {
            _sqlUnitOfWorkMock = new Mock<ISQLunitOfWork>();
            _sqlEmployeeSkillService = new SQLEmployeeSkillService(_sqlUnitOfWorkMock.Object);
            _sqlEmployeeSkillList = new List<SQLEmployees_Skill>
            {
                new SQLEmployees_Skill {
                    Id = 1,
                    Employee = new SQLEmployee
                    {
                        Id = 1,
                        FirstName = "Mohamed",
                        LastName = "Fekry",
                        Email = "MohamedFekry@mail.com",
                        IsActive = true
                    },
                    Employee_Id = 1,
                    Skill = new SQLSkill
                    {
                    },
                    Skill_Id = 1,
                    Score = new SQLScore
                    {
                    },
                    Score_Id = 1
                },
                new SQLEmployees_Skill {
                    Id = 2,
                    Employee = new SQLEmployee
                    {
                        Id = 2,
                        FirstName = "Ahmed",
                        LastName = "Hamdy",
                        Email = "AhmedHamdy@mail.com",
                        IsActive = true
                    },
                    Employee_Id = 2,
                    Skill = new SQLSkill
                    {
                    },
                    Skill_Id = 2,
                    Score = new SQLScore
                    {
                    },
                    Score_Id = 2
                },
                new SQLEmployees_Skill {
                    Id = 3,
                    Employee = new SQLEmployee
                    {
                        Id = 2,
                        FirstName = "Ahmed",
                        LastName = "Hamdy",
                        Email = "AhmedHamdy@mail.com",
                        IsActive = true
                    },
                    Employee_Id = 2,
                    Skill = new SQLSkill
                    {
                    },
                    Skill_Id = 1,
                    Score = new SQLScore
                    {
                    },
                    Score_Id = 2
                }
            };
        }

        [TestMethod]
        public void Test_Add_New_EmployeeSkill()
        {
            //Arrange
            SQLEmployees_Skill EmployeeSkill = new SQLEmployees_Skill
            {
                Id = 4,
                Employee = new SQLEmployee
                {
                    Id = 1,
                    FirstName = "Mohamed",
                    LastName = "Fekry",
                    Email = "MohamedFekry@mail.com",
                    IsActive = true
                },
                Employee_Id = 1,
                Skill = new SQLSkill
                {
                },
                Skill_Id = 3,
                Score = new SQLScore
                {
                },
                Score_Id = 2
            };

            _sqlUnitOfWorkMock.Setup(s => s.SQLEmployeeSkillRepository.Add(EmployeeSkill)).Returns(EmployeeSkill.Id);

            //Act
            var result = _sqlEmployeeSkillService.AddEmployeeSkill(EmployeeSkill);

            //Assert
            Assert.AreEqual(result, EmployeeSkill.Id);
        }

        [TestMethod]
        public void Test_Delete_Existing_EmployeeSkill()
        {
            //Arrange
            SQLEmployees_Skill EmployeeSkill = new SQLEmployees_Skill
            {
                Id = 4,
                Employee = new SQLEmployee
                {
                    Id = 1,
                    FirstName = "Mohamed",
                    LastName = "Fekry",
                    Email = "MohamedFekry@mail.com",
                    IsActive = true
                },
                Employee_Id = 1,
                Skill = new SQLSkill
                {
                },
                Skill_Id = 3,
                Score = new SQLScore
                {
                },
                Score_Id = 2
            };

            _sqlUnitOfWorkMock.Setup(s => s.SQLEmployeeSkillRepository.Delete(EmployeeSkill));

            //Act
            _sqlEmployeeSkillService.DeleteEmployeeSkill(EmployeeSkill);

            //Assert
            _sqlUnitOfWorkMock.Verify(v => v.SQLEmployeeSkillRepository.Delete(EmployeeSkill), Times.Once);
        }

        [TestMethod]
        public void Test_Get_All_EmployeeSkill()
        {
            //Arrange
            _sqlUnitOfWorkMock.Setup(s => s.SQLEmployeeSkillRepository.GetAll()).Returns(_sqlEmployeeSkillList);

            //Act
            var result = _sqlEmployeeSkillService.GetAllEmployeeSkills().ToList();

            //Assert
            _sqlUnitOfWorkMock.Verify(v => v.SQLEmployeeSkillRepository.GetAll(), Times.Once);
            Assert.AreEqual(result.Count, _sqlEmployeeSkillList.Count);
        }

        [TestMethod]
        public void Test_Get_EmployeeSkill_By_Id()
        {
            var EmployeeSkill = _sqlEmployeeSkillList.Where(e => e.Id == 1).FirstOrDefault();
            //Arrange
            _sqlUnitOfWorkMock.Setup(s => s.SQLEmployeeSkillRepository.Get(1))
                .Returns(EmployeeSkill);

            //Act
            var result = _sqlEmployeeSkillService.GetEmployeeSkillById(1);

            //Assert
            _sqlUnitOfWorkMock.Verify(v => v.SQLEmployeeSkillRepository.Get(1), Times.Once);
            Assert.AreEqual(result.Id, EmployeeSkill.Id);
        }

        [TestMethod]
        public void Test_Get_EmployeeSkill_By_Wrong_Id()
        {
            var EmployeeSkill = _sqlEmployeeSkillList.Where(e => e.Id == 1).FirstOrDefault();
            //Arrange
            _sqlUnitOfWorkMock.Setup(s => s.SQLEmployeeSkillRepository.Get(1))
                .Returns(EmployeeSkill);

            //Act
            var result = _sqlEmployeeSkillService.GetEmployeeSkillById(2);

            //Assert
            _sqlUnitOfWorkMock.Verify(v => v.SQLEmployeeSkillRepository.Get(2), Times.Once);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Test_Update_Existing_EmployeeSkill()
        {
            //Arrange
            var EmployeeSkill = _sqlEmployeeSkillList.Where(e => e.Id == 1).FirstOrDefault();
            _sqlUnitOfWorkMock.Setup(e => e.SQLEmployeeSkillRepository.Update(EmployeeSkill));

            //Act
            _sqlEmployeeSkillService.UpdateEmployeeSkill(EmployeeSkill);

            //Assert
            _sqlUnitOfWorkMock.Verify(e => e.SQLEmployeeSkillRepository.Update(EmployeeSkill), Times.Once);
        }
    }
}
