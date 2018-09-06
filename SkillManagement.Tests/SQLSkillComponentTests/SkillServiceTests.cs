using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.DataAccess.Services;
using System.Collections.Generic;
using System.Linq;

namespace SkillManagement.Tests.SQLSkillComponentTests
{
    [TestClass]
    public class SkillServiceTests
    {
        private Mock<ISQLunitOfWork> _sqlUnitOfWorkMock;
        private SQLSkillService _sqlSkillService;
        List<SQLSkill> _sqlSkillList;

        [TestInitialize]
        public void Initialize()
        {
            _sqlUnitOfWorkMock = new Mock<ISQLunitOfWork>();
            _sqlSkillService = new SQLSkillService(_sqlUnitOfWorkMock.Object);
            _sqlSkillList = new List<SQLSkill>
            {
                new SQLSkill {
                    Id = 1,
                    Name = "Technical Skills",
                    SkillParentCategory_Id = null
                },
                new SQLSkill {
                    Id = 2,
                    Name = "Soft Skills",
                    SkillParentCategory_Id = null
                },new SQLSkill {
                    Id = 3,
                    Name = "C#",
                    SkillParentCategory_Id = 1
                }
            };
        }

        [TestMethod]
        public void Test_Add_New_Skill()
        {
            //Arrange
            var Skill = new SQLSkill
            {
                Id = 4,
                Name = "Unit Testing",
                SkillParentCategory_Id = 1
            };

            _sqlUnitOfWorkMock.Setup(s => s.SQLSkillRepository.Add(Skill)).Returns(Skill.Id);

            //Act
            var result = _sqlSkillService.AddSkill(Skill);

            //Assert
            Assert.AreEqual(result, Skill.Id);
        }

        [TestMethod]
        public void Test_Delete_Existing_Skill()
        {
            //Arrange
            SQLSkill Skill = new SQLSkill
            {
                Id = 3,
                Name = "C#",
                SkillParentCategory_Id = 1
            };

            _sqlUnitOfWorkMock.Setup(s => s.SQLSkillRepository.Delete(Skill));

            //Act
            _sqlSkillService.DeleteSkill(Skill);

            //Assert
            _sqlUnitOfWorkMock.Verify(v => v.SQLSkillRepository.Delete(Skill), Times.Once);
        }

        [TestMethod]
        public void Test_Get_All_Skill()
        {
            //Arrange
            _sqlUnitOfWorkMock.Setup(s => s.SQLSkillRepository.GetAll()).Returns(_sqlSkillList);

            //Act
            var result = _sqlSkillService.GetAllSkills().ToList();

            //Assert
            _sqlUnitOfWorkMock.Verify(v => v.SQLSkillRepository.GetAll(), Times.Once);
            Assert.AreEqual(result.Count, _sqlSkillList.Count);
        }

        [TestMethod]
        public void Test_Get_Skill_By_Id()
        {
            var Skill = _sqlSkillList.Where(e => e.Id == 1).FirstOrDefault();
            //Arrange
            _sqlUnitOfWorkMock.Setup(s => s.SQLSkillRepository.Get(1))
                .Returns(Skill);

            //Act
            var result = _sqlSkillService.GetSkillById(1);

            //Assert
            _sqlUnitOfWorkMock.Verify(v => v.SQLSkillRepository.Get(1), Times.Once);
            Assert.AreEqual(result.Id, Skill.Id);
        }

        [TestMethod]
        public void Test_Get_Skill_By_Wrong_Id()
        {
            var Skill = _sqlSkillList.Where(e => e.Id == 1).FirstOrDefault();
            //Arrange
            _sqlUnitOfWorkMock.Setup(s => s.SQLSkillRepository.Get(1))
                .Returns(Skill);

            //Act
            var result = _sqlSkillService.GetSkillById(2);

            //Assert
            _sqlUnitOfWorkMock.Verify(v => v.SQLSkillRepository.Get(2), Times.Once);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Test_Update_Existing_Skill()
        {
            //Arrange
            var Skill = _sqlSkillList.Where(e => e.Id == 1).FirstOrDefault();
            _sqlUnitOfWorkMock.Setup(e => e.SQLSkillRepository.Update(Skill));

            //Act
            _sqlSkillService.UpdateSkill(Skill);

            //Assert
            _sqlUnitOfWorkMock.Verify(e => e.SQLSkillRepository.Update(Skill), Times.Once);
        }
    }
}
