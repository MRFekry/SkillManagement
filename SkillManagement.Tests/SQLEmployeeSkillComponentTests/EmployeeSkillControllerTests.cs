using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLServices;
using SkillManagement.WebAPI.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace SkillManagement.Tests.SQLEmployeeSkillComponentTests
{
    [TestClass]
    public class EmployeeSkillControllerTests
    {
        private Mock<ISQLEmployeeSkillService> _sqlEmployeeSkillServiceMock;
        EmployeeSkillController _employeeSkillController;
        List<SQLEmployees_Skill> _sqlEmployeeSkillList;

        [TestInitialize]
        public void Initialize()
        {
            _sqlEmployeeSkillServiceMock = new Mock<ISQLEmployeeSkillService>();
            _employeeSkillController = new EmployeeSkillController(_sqlEmployeeSkillServiceMock.Object);
            _sqlEmployeeSkillList = new List<SQLEmployees_Skill>
            {
                new SQLEmployees_Skill {
                    Id = 1,
                    Employee_Id = 1,
                    Skill_Id = 1,
                    Score_Id = 1
                },
                new SQLEmployees_Skill {
                    Id = 2,
                    Employee_Id = 2,
                    Skill_Id = 2,
                    Score_Id = 2
                },
                new SQLEmployees_Skill {
                    Id = 3,
                    Employee_Id = 2,
                    Skill_Id = 1,
                    Score_Id = 2
                }
            };
        }

        [TestMethod]
        public void Test_Get_Returns_All_EmployeesSkills()
        {
            //Arrange
            _sqlEmployeeSkillServiceMock.Setup(e => e.GetAllEmployeeSkills()).Returns(_sqlEmployeeSkillList);

            //Act
            var result = _employeeSkillController.Get() as List<SQLEmployees_Skill>;

            //Assert
            Assert.AreEqual(result.Count, _sqlEmployeeSkillList.Count);
        }

        [TestMethod]
        public void Test_Get_By_Id_Returns_Employee()
        {
            //Arrange
            _sqlEmployeeSkillServiceMock.Setup(e => e.GetEmployeeSkillById(1)).Returns(
                new SQLEmployees_Skill
                {
                    Id = 1,
                    Employee_Id = 1,
                    Skill_Id = 1,
                    Score_Id = 1
                });

            //Act
            var result = _employeeSkillController.Get(1);

            //Assert
            Assert.AreEqual(result.Id,
                new SQLEmployees_Skill
                {
                    Id = 1,
                    Employee_Id = 1,
                    Skill_Id = 1,
                    Score_Id = 1
                }.Id);
        }

        [TestMethod]
        public void Test_Success_Add_New_EmployeeSkill()
        {
            //Arrange
            var employeeSkill = new SQLEmployees_Skill
            {
                Id = 4,
                Employee_Id = 1,
                Skill_Id = 3,
                Score_Id = 2
            };
            _sqlEmployeeSkillServiceMock.Setup(s => s.AddEmployeeSkill(employeeSkill)).Returns(employeeSkill.Id);

            //Act
            var result = _employeeSkillController.Post(employeeSkill);

            //Assert
            _sqlEmployeeSkillServiceMock.Verify(e => e.AddEmployeeSkill(employeeSkill), Times.Once);
            Assert.AreEqual(result, employeeSkill.Id);
        }

        [TestMethod]
        public void Test_Fail_Add_New_EmployeeSkill()
        {
            //Arrange


            //Act


            //Assert
        }

        [TestMethod]
        public void Test_Success_Update_Existing_EmployeeSkill()
        {
            //Arrange
            var employeeSkill = _sqlEmployeeSkillList.Where(e => e.Id == 1).FirstOrDefault();
            _sqlEmployeeSkillServiceMock.Setup(e => e.UpdateEmployeeSkill(employeeSkill));

            //Act
            _employeeSkillController.Put(employeeSkill);

            //Assert
            _sqlEmployeeSkillServiceMock.Verify(e => e.UpdateEmployeeSkill(employeeSkill), Times.Once);
        }

        [TestMethod]
        public void Test_Success_Delete_Existing_EmployeeSkill()
        {
            //Arrange
            var employeeSkill = _sqlEmployeeSkillList.Where(e => e.Id == 1).FirstOrDefault();

            //Act
            _employeeSkillController.Delete(employeeSkill);

            //Assert
            _sqlEmployeeSkillServiceMock.Verify(e => e.DeleteEmployeeSkill(employeeSkill), Times.Once);
        }
    }
}
