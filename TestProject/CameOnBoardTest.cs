using Xunit;
using Chess;
using System;


namespace TestProject
{
    public class CameOnBoardTest : IDisposable
    {
        GameOnBoard testCase;

        public CameOnBoardTest() 
        {
            testCase = new GameOnBoard();
            testCase.GameName = "Test";
        }

        public void Dispose()
        {
            //close
        }

        [Fact]
        public void TestChangePlayerFromFalse()
        {
            //Arrange
            //Act
            testCase.CurrentPlayer = 2;
            testCase.ChangePlayer();
            //Assert
            Assert.Equal(1,testCase.CurrentPlayer);
        }
        [Fact]
        public void TestChangePlayerFromTrue()
        {
            //Arrange
            //Act
            testCase.CurrentPlayer = 2;
            testCase.ChangePlayer();
            //Assert
            Assert.Equal(1,testCase.CurrentPlayer);
        }

        
    }
}