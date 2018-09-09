using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Infrastructure;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.DataAccess.Repositories;

namespace SkillManagement.Tests.SQLEmployeeComponentTests
{
    [TestClass]
    public class EmployeeRepositoryTests
    {
        private IConnectionFactory _connectionFactory;
        private SQLEmployeeRepository _sqlEmployeeRepository;

        [TestInitialize]
        public void Initialize()
        {
            _connectionFactory = new ConnectionFactory();
            _sqlEmployeeRepository = new SQLEmployeeRepository(_connectionFactory, true);
        }

        [TestMethod]
        public void Test_Add_New_Employee()
        {
            //Arrange
            SQLEmployee employee = new SQLEmployee
            {
                FirstName = "Mohamed",
                LastName = "Ramadan",
                Email = "MohamedRamadan@mail.com",
                IsActive = true
            };

            //Act
            _sqlEmployeeRepository.Add(employee);

            //Assert
            //Check if employee had been added to test database
        }

        [TestMethod]
        public void Test_Update_Existing_Employee()
        {
            //Arrange
            SQLEmployee employee = new SQLEmployee
            {
                Id = 1,
                FirstName = "MohamedUpdated",
                LastName = "RamadanUpdated",
                Email = "MohamedRamadan@mail.com",
                IsActive = true
            };

            //Act
            _sqlEmployeeRepository.Update(employee);

            //Assert
            //Check if employee had been added to test database
        }

        [TestMethod]
        public void Test_Get_All_Employees()
        {
            //Arrange
            // Act 
            var result = _sqlEmployeeRepository.GetAll();

            //Assert
            //check if result are the same as Test DB
            var checkResult = result;
        }

        [TestMethod]
        public void Test_Get_Employee_By_Id()
        {
            //Arrange
            SQLEmployee employee = new SQLEmployee
            {
                Id = 1,
                FirstName = "MohamedUpdated",
                LastName = "RamadanUpdated",
                Email = "MohamedRamadan@mail.com",
                IsActive = true
            };

            //Act
            var result = _sqlEmployeeRepository.Get(1);

            //Assert
            Assert.AreEqual(employee.FirstName, result.FirstName);
            Assert.AreEqual(employee.LastName, result.LastName);
            Assert.AreEqual(employee.Email, result.Email);
            Assert.AreEqual(employee.IsActive, result.IsActive);
        }

        [TestMethod]
        public void Test_Delete_Existing_Employee()
        {
            //Arrange
            SQLEmployee employee = new SQLEmployee
            {
                Id = 1,
                FirstName = "MohamedUpdated",
                LastName = "RamadanUpdated",
                Email = "MohamedRamadan@mail.com",
                IsActive = true
            };

            //Act
            _sqlEmployeeRepository.Delete(employee);

            //Assert
            //check if record had been deleted from test database
        }
    }
}
