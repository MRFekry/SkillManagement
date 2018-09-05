using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.DataAccess.Services;
using System.Collections.Generic;
using System.Linq;

namespace SkillManagement.Tests.SQLEmployeeComponentTests
{
    [TestClass]
    public class EmployeeServiceTests
    {
        private Mock<ISQLunitOfWork> _sqlUnitOfWorkMock;
        private SQLEmployeeService _sqlEmployeeService;
        List<SQLEmployee> _sqlEmployeeList;

        [TestInitialize]
        public void Initialize()
        {
            _sqlUnitOfWorkMock = new Mock<ISQLunitOfWork>();
            _sqlEmployeeService = new SQLEmployeeService(_sqlUnitOfWorkMock.Object);
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
        public void Test_Add_New_Employee()
        {
            //Arrange
            SQLEmployee employee = new SQLEmployee
            {
                Id = 6,
                FirstName = "Mahmoud",
                LastName = "Ahmed",
                Email = "MahmoudAhmed@mail.com",
                IsActive = true
            };

            _sqlUnitOfWorkMock.Setup(s => s.SQLEmployeeRepository.Add(employee)).Returns(employee.Id);

            //Act
            var result = _sqlEmployeeService.AddEmployee(employee);

            //Assert
            Assert.AreEqual(result, employee.Id);
        }

        [TestMethod]
        public void Test_Delete_Existing_Employee()
        {
            //Arrange
            SQLEmployee employee = new SQLEmployee
            {
                Id = 6,
                FirstName = "Mahmoud",
                LastName = "Ahmed",
                Email = "MahmoudAhmed@mail.com",
                IsActive = true
            };

            _sqlUnitOfWorkMock.Setup(s => s.SQLEmployeeRepository.Delete(employee));

            //Act
            _sqlEmployeeService.DeleteEmployee(employee);

            //Assert
            _sqlUnitOfWorkMock.Verify(v => v.SQLEmployeeRepository.Delete(employee), Times.Once);
        }

        [TestMethod]
        public void Test_Get_All_Employee()
        {
            //Arrange
            _sqlUnitOfWorkMock.Setup(s => s.SQLEmployeeRepository.GetAll()).Returns(_sqlEmployeeList);

            //Act
            var result = _sqlEmployeeService.GetAllEmployees().ToList();

            //Assert
            _sqlUnitOfWorkMock.Verify(v => v.SQLEmployeeRepository.GetAll(), Times.Once);
            Assert.AreEqual(result.Count, _sqlEmployeeList.Count);
            Assert.AreEqual(result[0].FirstName, _sqlEmployeeList[0].FirstName);
            Assert.AreEqual(result[1].LastName, _sqlEmployeeList[1].LastName);
            Assert.AreEqual(result[2].Email, _sqlEmployeeList[2].Email);
        }

        [TestMethod]
        public void Test_Get_Employee_By_Id()
        {
            var employee = _sqlEmployeeList.Where(e => e.Id == 5).FirstOrDefault();
            //Arrange
            _sqlUnitOfWorkMock.Setup(s => s.SQLEmployeeRepository.Get(5))
                .Returns(employee);

            //Act
            var result = _sqlEmployeeService.GetEmployeeById(5);

            //Assert
            _sqlUnitOfWorkMock.Verify(v => v.SQLEmployeeRepository.Get(5), Times.Once);
            Assert.AreEqual(result.Id, employee.Id);
        }

        [TestMethod]
        public void Test_Get_Employee_By_Wrong_Id()
        {
            var employee = _sqlEmployeeList.Where(e => e.Id == 5).FirstOrDefault();
            //Arrange
            _sqlUnitOfWorkMock.Setup(s => s.SQLEmployeeRepository.Get(5))
                .Returns(employee);

            //Act
            var result = _sqlEmployeeService.GetEmployeeById(4);

            //Assert
            _sqlUnitOfWorkMock.Verify(v => v.SQLEmployeeRepository.Get(4), Times.Once);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Test_Update_Existing_Employee()
        {
            //Arrange
            var employee = _sqlEmployeeList.Where(e => e.Id == 1).FirstOrDefault();
            _sqlUnitOfWorkMock.Setup(e => e.SQLEmployeeRepository.Update(employee));

            //Act
            _sqlEmployeeService.UpdateEmployee(employee);

            //Assert
            _sqlUnitOfWorkMock.Verify(e => e.SQLEmployeeRepository.Update(employee), Times.Once);
        }
    }
}
