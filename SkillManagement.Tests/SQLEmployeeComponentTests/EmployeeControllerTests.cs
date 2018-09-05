using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.WebAPI.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace SkillManagement.Tests.SQLEmployeeComponentTests
{
    [TestClass]
    public class EmployeeControllerTests
    {
        private Mock<ISQLEmployeeService> _sqlEmployeeServiceMock;
        EmployeeController _employeeController;
        List<SQLEmployee> _sqlEmployeeList;

        [TestInitialize]
        public void Initialize()
        {
            _sqlEmployeeServiceMock = new Mock<ISQLEmployeeService>();
            _employeeController = new EmployeeController(_sqlEmployeeServiceMock.Object);
            _sqlEmployeeList = new List<SQLEmployee>
            {
                new SQLEmployee {
                    Id = 1,
                    FirstName = "Mohamed",
                    LastName = "Fekry",
                    Email = "MohamedFekry@mail.com",
                    IsActive = true
                },
                new SQLEmployee {
                    Id = 2,
                    FirstName = "Ahmed",
                    LastName = "Hamdy",
                    Email = "AhmedHamdy@mail.com",
                    IsActive = true
                },
                new SQLEmployee {
                    Id = 3,
                    FirstName = "Mohamed",
                    LastName = "Shahin",
                    Email = "MohamedShahin@mail.com",
                    IsActive = true
                },
                new SQLEmployee {
                    Id = 4,
                    FirstName = "Noaman",
                    LastName = "Maher",
                    Email = "NoamanMaher@mail.com",
                    IsActive = true
                },
                new SQLEmployee {
                    Id = 5,
                    FirstName = "Hady",
                    LastName = "Allam",
                    Email = "HadyAllam@mail.com",
                    IsActive = true
                }
            };
        }

        [TestMethod]
        public void Test_Get_Returns_All_Employees()
        {
            //Arrange
            _sqlEmployeeServiceMock.Setup(e => e.GetAllEmployees()).Returns(_sqlEmployeeList);

            //Act
            var result = _employeeController.Get() as List<SQLEmployee>;

            //Assert
            Assert.AreEqual(result.Count, _sqlEmployeeList.Count);
            Assert.AreEqual(result[0].FirstName, _sqlEmployeeList[0].FirstName);
            Assert.AreEqual(result[1].LastName, _sqlEmployeeList[1].LastName);
            Assert.AreEqual(result[2].Email, _sqlEmployeeList[2].Email);
        }

        [TestMethod]
        public void Test_Get_By_Id_Returns_Employee()
        {
            //Arrange
            _sqlEmployeeServiceMock.Setup(e => e.GetEmployeeById(5)).Returns(new SQLEmployee
            {
                Id = 5,
                FirstName = "Hady",
                LastName = "Allam",
                Email = "HadyAllam@mail.com",
                IsActive = true
            });

            //Act
            var result = _employeeController.Get(5);

            //Assert
            Assert.AreEqual(result.FirstName, new SQLEmployee
            {
                Id = 5,
                FirstName = "Hady",
                LastName = "Allam",
                Email = "HadyAllam@mail.com",
                IsActive = true
            }.FirstName);
            Assert.AreEqual(result.LastName, new SQLEmployee
            {
                Id = 5,
                FirstName = "Hady",
                LastName = "Allam",
                Email = "HadyAllam@mail.com",
                IsActive = true
            }.LastName);
            Assert.AreEqual(result.Email, new SQLEmployee
            {
                Id = 5,
                FirstName = "Hady",
                LastName = "Allam",
                Email = "HadyAllam@mail.com",
                IsActive = true
            }.Email);
            Assert.AreEqual(result.IsActive, new SQLEmployee
            {
                Id = 5,
                FirstName = "Hady",
                LastName = "Allam",
                Email = "HadyAllam@mail.com",
                IsActive = true
            }.IsActive);
        }

        [TestMethod]
        public void Test_Success_Add_New_Employee()
        {
            //Arrange
            var employee = new SQLEmployee
            {
                Id = 6,
                FirstName = "Abdullah",
                LastName = "Mohamed",
                Email = "AbdullahMohamed@mail.com",
                IsActive = true
            };
            _sqlEmployeeServiceMock.Setup(s => s.AddEmployee(employee)).Returns(employee.Id);

            //Act
            var result = _employeeController.Post(employee);

            //Assert
            _sqlEmployeeServiceMock.Verify(e => e.AddEmployee(employee), Times.Once);
            Assert.AreEqual(result, employee.Id);
        }

        [TestMethod]
        public void Test_Fail_Add_New_Employee()
        {
            //Arrange


            //Act


            //Assert
        }

        [TestMethod]
        public void Test_Success_Update_Existing_Employee()
        {
            //Arrange
            var employee = _sqlEmployeeList.Where(e => e.Id == 1).FirstOrDefault();
            //var updatedFirstName = employee.FirstName + "_Updated";
            //var updatedLastName = employee.LastName + "_Updated";
            //var updatedEmail = employee.Email + "_Updated";
            _sqlEmployeeServiceMock.Setup(e => e.UpdateEmployee(employee));

            //Act
            _employeeController.Put(employee);

            //Assert
            _sqlEmployeeServiceMock.Verify(e => e.UpdateEmployee(employee), Times.Once);
            //Assert.AreEqual(employee.FirstName, updatedFirstName);
            //Assert.AreEqual(employee.LastName, updatedLastName);
            //Assert.AreEqual(employee.Email, updatedEmail);
        }

        [TestMethod]
        public void Test_Success_Delete_Existing_Employee()
        {
            //Arrange
            var employee = _sqlEmployeeList.Where(e => e.Id == 1).FirstOrDefault();

            //Act
            _employeeController.Delete(employee);

            //Assert
            _sqlEmployeeServiceMock.Verify(e => e.DeleteEmployee(employee), Times.Once);
        }
    }
}
