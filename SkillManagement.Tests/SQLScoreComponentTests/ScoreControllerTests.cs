using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.WebAPI.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace SkillManagement.Tests.SQLScoreComponentTests
{
    [TestClass]
    public class ScoreControllerTests
    {
        private Mock<ISQLScoreService> _sqlScoreServiceMock;
        ScoreController _ScoreController;
        List<SQLScore> _sqlScoreList;

        [TestInitialize]
        public void Initialize()
        {
            _sqlScoreServiceMock = new Mock<ISQLScoreService>();
            _ScoreController = new ScoreController(_sqlScoreServiceMock.Object);
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
        public void Test_Get_Returns_All_Scores()
        {
            //Arrange
            _sqlScoreServiceMock.Setup(e => e.GetAllScores()).Returns(_sqlScoreList);

            //Act
            var result = _ScoreController.Get() as List<SQLScore>;

            //Assert
            Assert.AreEqual(result.Count, _sqlScoreList.Count);
        }

        [TestMethod]
        public void Test_Get_By_Id_Returns_Score()
        {
            //Arrange
            _sqlScoreServiceMock.Setup(e => e.GetScoreById(3)).Returns(new SQLScore
            {
                Id = 3,
                Name = "Experienced",
                score = 3
            });

            //Act
            var result = _ScoreController.Get(3);

            //Assert
            Assert.AreEqual(result.Id, new SQLScore
            {
                Id = 3,
                Name = "Experienced",
                score = 3
            }.Id);            
        }

        [TestMethod]
        public void Test_Success_Add_New_Score()
        {
            //Arrange
            var Score = new SQLScore
            {
                Id = 4,
                Name = "Managerial",
                score = 4
            };
            _sqlScoreServiceMock.Setup(s => s.AddScore(Score)).Returns(Score.Id);

            //Act
            var result = _ScoreController.Post(Score);

            //Assert
            _sqlScoreServiceMock.Verify(e => e.AddScore(Score), Times.Once);
            Assert.AreEqual(result, Score.Id);
        }

        [TestMethod]
        public void Test_Fail_Add_New_Score()
        {
            //Arrange


            //Act


            //Assert
        }

        [TestMethod]
        public void Test_Success_Update_Existing_Score()
        {
            //Arrange
            var Score = _sqlScoreList.Where(e => e.Id == 1).FirstOrDefault();
            _sqlScoreServiceMock.Setup(e => e.UpdateScore(Score));

            //Act
            _ScoreController.Put(Score);

            //Assert
            _sqlScoreServiceMock.Verify(e => e.UpdateScore(Score), Times.Once);
        }

        [TestMethod]
        public void Test_Success_Delete_Existing_Score()
        {
            //Arrange
            var Score = _sqlScoreList.Where(e => e.Id == 1).FirstOrDefault();

            //Act
            _ScoreController.Delete(Score);

            //Assert
            _sqlScoreServiceMock.Verify(e => e.DeleteScore(Score), Times.Once);
        }
    }
}
