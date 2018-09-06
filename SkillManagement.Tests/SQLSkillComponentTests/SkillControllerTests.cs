using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.WebAPI.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace SkillManagement.Tests.SQLSkillComponentTests
{
    [TestClass]
    public class SkillControllerTests
    {
        private Mock<ISQLSkillService> _sqlSkillServiceMock;
        SkillController _SkillController;
        List<SQLSkill> _sqlSkillList;

        [TestInitialize]
        public void Initialize()
        {
            _sqlSkillServiceMock = new Mock<ISQLSkillService>();
            _SkillController = new SkillController(_sqlSkillServiceMock.Object);
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
        public void Test_Get_Returns_All_Skills()
        {
            //Arrange
            _sqlSkillServiceMock.Setup(e => e.GetAllSkills()).Returns(_sqlSkillList);

            //Act
            var result = _SkillController.Get() as List<SQLSkill>;

            //Assert
            Assert.AreEqual(result.Count, _sqlSkillList.Count);
        }

        [TestMethod]
        public void Test_Get_By_Id_Returns_Skill()
        {
            //Arrange
            _sqlSkillServiceMock.Setup(e => e.GetSkillById(3)).Returns(new SQLSkill
            {
                Id = 3,
                Name = "C#",
                SkillParentCategory_Id = 1
            });

            //Act
            var result = _SkillController.Get(3);

            //Assert
            Assert.AreEqual(result.Id, new SQLSkill
            {
                Id = 3,
                Name = "C#",
                SkillParentCategory_Id = 1
            }.Id);            
        }

        [TestMethod]
        public void Test_Success_Add_New_Skill()
        {
            //Arrange
            var Skill = new SQLSkill
            {
                Id = 4,
                Name = "Unit Testing",
                SkillParentCategory_Id = 1
            };
            _sqlSkillServiceMock.Setup(s => s.AddSkill(Skill)).Returns(Skill.Id);

            //Act
            var result = _SkillController.Post(Skill);

            //Assert
            _sqlSkillServiceMock.Verify(e => e.AddSkill(Skill), Times.Once);
            Assert.AreEqual(result, Skill.Id);
        }

        [TestMethod]
        public void Test_Fail_Add_New_Skill()
        {
            //Arrange


            //Act


            //Assert
        }

        [TestMethod]
        public void Test_Success_Update_Existing_Skill()
        {
            //Arrange
            var Skill = _sqlSkillList.Where(e => e.Id == 1).FirstOrDefault();
            _sqlSkillServiceMock.Setup(e => e.UpdateSkill(Skill));

            //Act
            _SkillController.Put(Skill);

            //Assert
            _sqlSkillServiceMock.Verify(e => e.UpdateSkill(Skill), Times.Once);
        }

        [TestMethod]
        public void Test_Success_Delete_Existing_Skill()
        {
            //Arrange
            var Skill = _sqlSkillList.Where(e => e.Id == 1).FirstOrDefault();

            //Act
            _SkillController.Delete(Skill);

            //Assert
            _sqlSkillServiceMock.Verify(e => e.DeleteSkill(Skill), Times.Once);
        }
    }
}
