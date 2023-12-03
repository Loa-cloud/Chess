using Xunit;
using Chess;
using System;


namespace TestProject
{
    public class ChessOnBoardTest : IDisposable
    {
        ChessOnBoard testCase;

        public ChessOnBoardTest()
        {
            testCase = new ChessOnBoard();
            //testCase.GameName = "Test";
        }

        public void Dispose()
        {
            //close
        }

        

        [Fact]
        public void TestGetKingMoves1()
        {
            int expected = 0;
            // перенести в другой файл. это уже функция проверки шахмат
            testCase.Board = new int[,]
            {
            { 15,14,13,12,11,13,14,15 },
            { 16,16,16,16,16,16,16,16 },
            { 0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0 },
            { 26,26,26,26,26,26,26,26 },
            { 25,24,23,22,21,23,24,25 },
            };

            List<List<int>> actual = testCase.GetKingMoves(0, 4);

            Assert.Empty(actual);
        }

        [Fact]
        public void TestGetKingMoves2()
        {
            int expected = 3;
            // перенести в другой файл. это уже функция проверки шахмат
            testCase.Board = new int[,]
            {
            { 11,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0 },
            };

            List<List<int>> actual = testCase.GetKingMoves(0, 0);

            Assert.Equal(expected, actual.Count);
        }


        [Fact]
        public void TestGetQueenMoves1()
        {
            
            List<List<int>> expected = new List<List<int>>();
            expected.Add(new List<int> { 2, 0 });
            expected.Add(new List<int> { 1, 0 });
            // перенести в другой файл. это уже функция проверки шахмат
            testCase.Board = new int[,]
            {
            { 21,0,0,0,0,0,0,0 },
            { 21,0,0,0,0,0,0,0 },
            { 11,0,0,11,11,0,0,0 },
            { 11,0, 0, 12 ,0,21,0,0 },
            { 11,0,0,11,0,0,0,0 },
            { 0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0 },
            };

            
            testCase.CurrentPlayer = 1;
            List<List<int>> actual = testCase.GetQueenMoves(3, 3);

            //Assert.Equal(false, testCase.IsEnemy(1, 0));
            Assert.Equal(expected, actual);
        }
        // 


        [Fact]
        public void TestGetBishopMoves1()
        {

            List<List<int>> expected = new List<List<int>>();
            expected.Add(new List<int> { 2, 0 });
            expected.Add(new List<int> { 1, 0 });
            // перенести в другой файл. это уже функция проверки шахмат
            testCase.Board = new int[,]
            {
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 11, 0, 0, 0,11, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0,11, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0,21, 0, 0, 0,11, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            };


            testCase.CurrentPlayer = 1;
            List<List<int>> actual = testCase.GetBishopMoves(3, 3);

            //Assert.Equal(false, testCase.IsEnemy(1, 0));
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetKnightMoves1()
        {

            List<List<int>> expected = new List<List<int>>();
            expected.Add(new List<int> { 2, 0 });
            expected.Add(new List<int> { 1, 0 });
            // перенести в другой файл. это уже функция проверки шахмат
            testCase.Board = new int[,]
            {
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0,21, 0,21, 0, 0, 0},
            { 0,21, 0, 0, 0,21, 0, 0},
            { 0, 0, 0,11, 0, 0, 0, 0},
            { 0,21, 0, 0, 0,21, 0, 0},
            { 0, 0,21, 0,21, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            };


            testCase.CurrentPlayer = 1;
            List<List<int>> actual = testCase.GetKnightMoves(3, 3);

            //Assert.Equal(false, testCase.IsEnemy(1, 0));
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void TestGetPawnMovesWhite()
        {

            List<List<int>> expected = new List<List<int>>();
            expected.Add(new List<int> { 2, 0 });
            expected.Add(new List<int> { 1, 0 });
            // перенести в другой файл. это уже функция проверки шахмат
            testCase.Board = new int[,]
            {
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            {11, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            };


            testCase.CurrentPlayer = 1;
            List<List<int>> actual = testCase.GetPawnMoves(6, 0);

            //Assert.Equal(false, testCase.IsEnemy(1, 0));
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetPawnMovesBlack()
        {

            List<List<int>> expected = new List<List<int>>();
            expected.Add(new List<int> { 2, 0 });
            expected.Add(new List<int> { 1, 0 });
            // перенести в другой файл. это уже функция проверки шахмат
            testCase.Board = new int[,]
            {
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0,21, 0, 0, 0, 0, 0, 0},
            {11, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            };


            testCase.CurrentPlayer = 2;
            List<List<int>> actual = testCase.GetPawnMoves(1, 1);

            //Assert.Equal(false, testCase.IsEnemy(1, 0));
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetMovesCurrentPlayer()
        {

            Dictionary<List<int>, List<List<int>>> expected = new Dictionary<List<int>, List<List<int>>>();
            //expected.Add(new List<int> { 2, 0 });
            //expected.Add(new List<int> { 1, 0 });
            // перенести в другой файл. это уже функция проверки шахмат
            testCase.Board = new int[,]
            {
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0,21, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0,14, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            };


            testCase.CurrentPlayer = 1;
            Dictionary<List<int>, List<List<int>>> actual = testCase.GetMovesCurrentPlayer();

            //Assert.Equal(false, testCase.IsEnemy(1, 0));
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetBestMove()
        {

            Dictionary<List<int>, List<List<int>>> expected = new Dictionary<List<int>, List<List<int>>>();
            //expected.Add(new List<int> { 2, 0 });
            //expected.Add(new List<int> { 1, 0 });
            // перенести в другой файл. это уже функция проверки шахмат
            testCase.Board = new int[,]
            {
            {21,11, 0, 0, 0, 0, 0, 0},
            { 0,11, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0,11, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            };


            testCase.CurrentPlayer = 1;
            Dictionary<List<int>, List<List<int>>> actual = testCase.GetBestMove();

            //Assert.Equal(false, testCase.IsEnemy(1, 0));
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetBestMove1()
        {

            Dictionary<List<int>, List<List<int>>> expected = new Dictionary<List<int>, List<List<int>>>();
            //expected.Add(new List<int> { 2, 0 });
            //expected.Add(new List<int> { 1, 0 });
            // перенести в другой файл. это уже функция проверки шахмат
            testCase.Board = new int[,]
            {
            {25,24,23,22,21,23,24,25},
            {26,26,26,26,26,26,26,26},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            {16,16,16,16,16,16,16,16},
            {15,14,13,12,11,13,14,15},
            };


            testCase.CurrentPlayer = 1;
            Dictionary<List<int>, List<List<int>>> actual = testCase.GetBestMove();

            //Assert.Equal(false, testCase.IsEnemy(1, 0));
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestIsCheck1()
        {

            //Dictionary<List<int>, List<List<int>>> expected = new Dictionary<List<int>, List<List<int>>>();
            //expected.Add(new List<int> { 2, 0 });
            //expected.Add(new List<int> { 1, 0 });
            // перенести в другой файл. это уже функция проверки шахмат
            bool expected = true;
            testCase.Board = new int[,]
            {
            {11, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0,21, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            };


            testCase.CurrentPlayer = 1;
            bool actual = testCase.IsCheck();

            //Assert.Equal(false, testCase.IsEnemy(1, 0));
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestIsMate1()
        {            
            bool expected = true;
            testCase.Board = new int[,]
            {
            {15, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0,21, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            };


            testCase.CurrentPlayer = 1;
            bool actual = testCase.IsMate();

            //Assert.Equal(false, testCase.IsEnemy(1, 0));
            Assert.Equal(expected, actual);
        }



        [Fact]
        public void TestGetMovesCurrentPlayer2()
        {

            Dictionary<List<int>, List<List<int>>> expected = new Dictionary<List<int>, List<List<int>>>();
            //expected.Add(new List<int> { 2, 0 });
            //expected.Add(new List<int> { 1, 0 });
            // перенести в другой файл. это уже функция проверки шахмат
            testCase.Board = new int[,]
            {
            {11, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0,21, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            };


            testCase.CurrentPlayer = 2;
            Dictionary<List<int>, List<List<int>>> actual = testCase.GetMovesCurrentPlayer();

            //Assert.Equal(false, testCase.IsEnemy(1, 0));
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void TestReset()
        {
            int[,] expected = new int[,]
            {
            {25,24,23,22,21,23,24,25 },
            {26,26,26,26,26,26,26,26 },
            {0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0 },
            {16,16,16,16,16,16,16,16 },
            {15,14,13,12,11,13,14,15 },
            };

            testCase.Board = new int[,]
            {
            {11, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0,21, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            };


            testCase.CurrentPlayer = 2;
            testCase.Reset();
            int[,] actual = testCase.Board;

            //Assert.Equal(false, testCase.IsEnemy(1, 0));
            Assert.Equal(expected, actual);
        }

    }
}
