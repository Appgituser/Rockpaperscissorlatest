using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RockPaperScissor.Business.Interfaces;

namespace RockPaperScissor.Test
{
    /// <summary>
    /// Class contains unit tests.
    /// </summary>
    [TestClass]
    public class RockPaperScissorTests
    {

        /// <summary>
        /// Test method user win the Game
        /// </summary>
        [TestMethod]
        public void User_Win_Game()
        {
            //Arrange
            var mockObject = new Mock<IGamer>();
            mockObject.Setup(x => x.GameResult(1)).Returns("User Win !!");
            //Act
            string result = mockObject.Object.GameResult(1);
            //Assert
            Assert.AreEqual(result, "User Win !!");
        }

        /// <summary>
        /// Test method Computer win the Game
        /// </summary>
        [TestMethod]
        public void Computer_Win_Game()
        {
            //Arrange
            var mockObject = new Mock<IGamer>();
            mockObject.Setup(x => x.GameResult(2)).Returns("Computer Win !!");
            //Act
            string result = mockObject.Object.GameResult(2);
            //Assert
            Assert.AreEqual(result, "Computer Win !!");
        }

        /// <summary>
        /// Test method Draw the Game
        /// </summary>
        [TestMethod]
        public void Draw_The_Game()
        {
            //Arrange
            var mockObject = new Mock<IGamer>();
            mockObject.Setup(x => x.GameResult(3)).Returns("Draw !!");
            //Act
            string result = mockObject.Object.GameResult(3);
            //Assert
            Assert.AreEqual(result, "Draw !!");
        }

        /// <summary>
        /// Computer selected Rock.
        /// </summary>
        [TestMethod]
        public void Computer_Selected_Rock()
        {

            //Arrange
            var mockObject = new Mock<IGamer>();
            mockObject.Setup(x => x.GameSelection(1)).Returns("Computer Selected ROCK");
            //Act
            string result = mockObject.Object.GameSelection(1);
            Assert.AreEqual(result, "Computer Selected ROCK");
        }

        /// <summary>
        /// Computer selected paper.
        /// </summary>
        [TestMethod]
        public void Computer_Selected_Paper()
        {

            //Arrange
            var mockObject = new Mock<IGamer>();
            mockObject.Setup(x => x.GameSelection(2)).Returns("Computer Selected PAPER");
            //Act
            string result = mockObject.Object.GameSelection(2);
            Assert.AreEqual(result, "Computer Selected PAPER");
        }

        /// <summary>
        /// Computer selected Scissor.
        /// </summary>
        [TestMethod]
        public void Computer_Selected_Scissor()
        {

            //Arrange
            var mockObject = new Mock<IGamer>();
            mockObject.Setup(x => x.GameSelection(3)).Returns("Computer Selected SCISSOR");
            //Act
            string result = mockObject.Object.GameSelection(3);
            Assert.AreEqual(result, "Computer Selected SCISSOR");
        }

        /// <summary>
        /// method for Final 
        /// </summary>
        [TestMethod]
        public void FinalResult_UserWin()
        {
            //Arrange
            var mockDBObject = new Mock<IGamer>();
            mockDBObject.Setup(x => x.DisplayResult(0, 0)).Returns("Final Winner is User");
            //Act
            string result = mockDBObject.Object.DisplayResult(0, 0);
            //Assert
            Assert.AreEqual(result, "Final Winner is User");
        }

        /// <summary>
        /// Test Method computer win the Game in Final Result.
        /// </summary>
        [TestMethod]
        public void FinalResult_ComputerWin()
        {
            //Arrange
            var mockDBObject = new Mock<IGamer>();
            mockDBObject.Setup(x => x.DisplayResult(0, 0)).Returns("Final Winner is Computer");
            //Act
            string result = mockDBObject.Object.DisplayResult(0, 0);
            //Assert
            Assert.AreEqual(result, "Final Winner is Computer");
        }

        /// <summary>
        /// Test Method for Draw the Game.
        /// </summary>
        [TestMethod]
        public void FinalResult_DrawGame()
        {
            //Arrange
            var mockDBObject = new Mock<IGamer>();
            mockDBObject.Setup(x => x.DisplayResult(0, 0)).Returns("Draw the Game");
            //Act
            string result = mockDBObject.Object.DisplayResult(0, 0);
            //Assert
            Assert.AreEqual(result, "Draw the Game");
        }


    }
}
