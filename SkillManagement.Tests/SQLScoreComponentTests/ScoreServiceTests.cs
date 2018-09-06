using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.DataAccess.Services;
using System.Collections.Generic;
using System.Linq;

namespace SkillManagement.Tests.SQLScoreComponentTests
{
    [TestClass]
    public class ScoreServiceTests
    {
        private Mock<ISQLunitOfWork> _sqlUnitOfWorkMock;
        private SQLScoreService _sqlScoreService;
        List<SQLScore> _sqlScoreList;

        [TestInitialize]
        public void Initialize()
        {
            _sqlUnitOfWorkMock = new Mock<ISQLunitOfWork>();
            _sqlScoreService = new SQLScoreService(_sqlUnitOfWorkMock.Object);
            _sqlScoreList = new List<SQLScore>
            {
                new SQLScore {
                    Id = 1,
                    Name = "Begginer",
                    score = 1
                },
                new SQLScore {
                    Id = 2,
                    Name = "Mid",
                    score = 2
                },new SQLScore {
                    Id = 3,
                    Name = "Experienced",
                    score = 3
                }
            };
        }

        [TestMethod]
        public void Test_Add_New_Score()
        {
            //Arrange
            var Score = new SQLScore
            {
                Id = 4,
                Name = "Managerial",
                score = 4
            };

            _sqlUnitOfWorkMock.Setup(s => s.SQLScoreRepository.Add(Score)).Returns(Score.Id);

            //Act
            var result = _sqlScoreService.AddScore(Score);

            //Assert
            Assert.AreEqual(result, Score.Id);
        }

        [TestMethod]
        public void Test_Delete_Existing_Score()
        {
            //Arrange
            var Score = new SQLScore
            {
                Id = 3,
                Name = "Experienced",
                score = 3
            };

            _sqlUnitOfWorkMock.Setup(s => s.SQLScoreRepository.Delete(Score));

            //Act
            _sqlScoreService.DeleteScore(Score);

            //Assert
            _sqlUnitOfWorkMock.Verify(v => v.SQLScoreRepository.Delete(Score), Times.Once);
        }

        [TestMethod]
        public void Test_Get_All_Score()
        {
            //Arrange
            _sqlUnitOfWorkMock.Setup(s => s.SQLScoreRepository.GetAll()).Returns(_sqlScoreList);

            //Act
            var result = _sqlScoreService.GetAllScores().ToList();

            //Assert
            _sqlUnitOfWorkMock.Verify(v => v.SQLScoreRepository.GetAll(), Times.Once);
            Assert.AreEqual(result.Count, _sqlScoreList.Count);
        }

        [TestMethod]
        public void Test_Get_Score_By_Id()
        {
            var Score = _sqlScoreList.Where(e => e.Id == 1).FirstOrDefault();
            //Arrange
            _sqlUnitOfWorkMock.Setup(s => s.SQLScoreRepository.Get(1))
                .Returns(Score);

            //Act
            var result = _sqlScoreService.GetScoreById(1);

            //Assert
            _sqlUnitOfWorkMock.Verify(v => v.SQLScoreRepository.Get(1), Times.Once);
            Assert.AreEqual(result.Id, Score.Id);
        }

        [TestMethod]
        public void Test_Get_Score_By_Wrong_Id()
        {
            var Score = _sqlScoreList.Where(e => e.Id == 1).FirstOrDefault();
            //Arrange
            _sqlUnitOfWorkMock.Setup(s => s.SQLScoreRepository.Get(1))
                .Returns(Score);

            //Act
            var result = _sqlScoreService.GetScoreById(2);

            //Assert
            _sqlUnitOfWorkMock.Verify(v => v.SQLScoreRepository.Get(2), Times.Once);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Test_Update_Existing_Score()
        {
            //Arrange
            var Score = _sqlScoreList.Where(e => e.Id == 1).FirstOrDefault();
            _sqlUnitOfWorkMock.Setup(e => e.SQLScoreRepository.Update(Score));

            //Act
            _sqlScoreService.UpdateScore(Score);

            //Assert
            _sqlUnitOfWorkMock.Verify(e => e.SQLScoreRepository.Update(Score), Times.Once);
        }
    }
}
