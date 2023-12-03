using Xunit;
using Chess;
using System;
using System.Collections.Generic;

namespace TestProject
{
    public class СheckersOnBoardTest : IDisposable
    {
        СheckersOnBoard testCase;

        public СheckersOnBoardTest()
        {
            testCase = new СheckersOnBoard();
            //testCase.GameName = "Test";
        }

        public void Dispose()
        {
            //close
        }



        [Fact]
        public void TestTryEat()
        {
            int expected = 1;
            // перенести в другой файл. это уже функция проверки шахмат
            testCase.Board = new int[8, 8]
            {
            {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 },
            {0 ,11,0 , 0,0 ,0, 0 ,0 },
            {0 ,0 ,22, 0,0 ,0 ,0 ,0 },
            {0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0 },
            {0,22,0,22,0,22,0,22 },
            {22,0,22,0,22,0,22,0},
            };

            List<List<int>> actual = testCase.TryEat(2, 2);

            Assert.Equal(expected, actual.Count);
        }


        [Fact]
        public void TryEatLeftUpTest()
        {
            List<int> expected = new List<int> { 0, 0 };
            // перенести в другой файл. это уже функция проверки шахмат
            testCase.Board = new int[8, 8]
            {
            {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 },
            {0 ,11,0 , 0,0 ,0, 0 ,0 },
            {0 ,0 ,22, 0,0 ,0 ,0 ,0 },
            {0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0 },
            {0,22,0,22,0,22,0,22 },
            {22,0,22,0,22,0,22,0},
            };

            List<int> actual = testCase.TryEatLeftUp(2, 2);

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void GetСheckersMovesTest2()
        {
            List<List<int>> expected = new List<List<int>>();
            expected.Add(new List<int> { 1, 3 });
            expected.Add(new List<int> { 3, 1 });
            expected.Add(new List<int> { 3, 3 });
            expected.Add(new List<int> { 0, 0 });
            // перенести в другой файл. это уже функция проверки шахмат
            testCase.Board = new int[8, 8]
            {
            {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 },
            {0 ,11,0 , 0,0 ,0, 0 ,0 },
            {0 ,0 ,22, 0,0 ,0 ,0 ,0 },
            {0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0 },
            {0,22,0,22,0,22,0,22 },
            {22,0,22,0,22,0,22,0},
            };

            List<List<int>> actual = testCase.GetСheckersMoves(2, 2);

            Assert.Equal(expected, actual);
        }



    }
}
