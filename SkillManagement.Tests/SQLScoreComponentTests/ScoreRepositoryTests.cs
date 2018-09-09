using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Infrastructure;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.DataAccess.Repositories;

namespace SkillManagement.Tests.SQLScoreComponentTests
{
    [TestClass]
    public class ScoreRepositoryTests
    {
        private IConnectionFactory _connectionFactory;
        private SQLScoreRepository _sqlScoreRepository;

        [TestInitialize]
        public void Initialize()
        {
            _connectionFactory = new ConnectionFactory();
            _sqlScoreRepository = new SQLScoreRepository(_connectionFactory, true);
        }

        [TestMethod]
        public void Test_Add_New_Score()
        {
            //Arrange
            var Score = new SQLScore
            {
                Name = "Mid",
                score = 2
            };

            //Act
            _sqlScoreRepository.Add(Score);

            //Assert
            //Check if Score had been added to test database
        }

        [TestMethod]
        public void Test_Update_Existing_Score()
        {
            //Arrange
            var Score = new SQLScore
            {
                Id = 1,
                Name = "BeginnerUpdated",
                score = 1
            };

            //Act
            _sqlScoreRepository.Update(Score);

            //Assert
            //Check if Score had been added to test database
        }

        [TestMethod]
        public void Test_Get_All_Scores()
        {
            //Arrange
            // Act 
            var result = _sqlScoreRepository.GetAll();

            //Assert
            //check if result are the same as Test DB
            var checkResult = result;
        }

        [TestMethod]
        public void Test_Get_Score_By_Id()
        {
            //Arrange
            var Score = new SQLScore
            {
                Id = 1,
                Name = "BeginnerUpdated",
                score = 1
            };

            //Act
            var result = _sqlScoreRepository.Get(1);

            //Assert
            Assert.AreEqual(Score.Id, result.Id);
            Assert.AreEqual(Score.Name, result.Name);
            Assert.AreEqual(Score.score, result.score);
        }

        [TestMethod]
        public void Test_Delete_Existing_Score()
        {
            //Arrange
            var Score = new SQLScore
            {
                Id = 1,
                Name = "BeginnerUpdated",
                score = 1
            };

            //Act
            _sqlScoreRepository.Delete(Score);

            //Assert
            //check if record had been deleted from test database
        }
    }
}
