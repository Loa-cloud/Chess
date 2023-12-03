using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{

    public class GameOnBoard
    {
        private int[,] board = new int[8, 8]
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


        public string GameName { get; set; }
        public int[,] Board { get => board; set => board = value; } 
        public int CurrentPlayer { get; set; } = 1; 
        public bool IsMoving { get; set; } = false;
        public string PathSprites { get; set; } = "C:\\study\\tpo2\\ChessGame-master\\Chess\\Sprites\\chess.png";


        public void ChangePlayer()
        {
            if (this.CurrentPlayer == 1)
                this.CurrentPlayer = 2;
            else this.CurrentPlayer = 1;
        }

        public void ChangeMooving()
        {
            if (this.IsMoving == true)
                this.IsMoving = false;
            else this.IsMoving = true;
        }

        public void Reset()
        {
            this.Board = new int[,]
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

            CurrentPlayer = 1;
            IsMoving = false;
        }

        public bool InsideBoard(int row, int column)
        {
            if (row >= 8 || column >= 8 || row < 0 || column < 0)
                return false;
            return true;
        }

        public bool ChekMove(int row, int column)
        {
            if (this.Board[row, column] == 0)
                return true;
            else if (this.Board[row, column] / 10 == this.CurrentPlayer)
                return false;
            else return true;
        }

        public bool IsEnemyOrNull(int row, int column)
        {
            if ((this.Board[row, column] / 10 != this.CurrentPlayer) || (this.Board[row, column] == 0))
                return true;
            else return false;
        }

        public bool IsEnemy(int row, int column)
        {
            if ((this.Board[row, column] != 0) && (this.Board[row, column] / 10 != this.CurrentPlayer))
                return true;
            else return false;
        }

        public bool IsPlayer(int row, int column)
        {
            if ((this.Board[row, column] != 0) && (this.Board[row, column] / 10 == this.CurrentPlayer))
                return true;
            else return false;
        }

        public bool IsNull(int row, int column)
        {
            if ((this.Board[row, column] == 0))
                return true;
            else return false;
        }

        public int GetTypeOfFigure(int row, int column)
        {
            return this.Board[row, column] % 10;
        }
    }


    public class СheckersOnBoard : GameOnBoard
    {
        private int[,] board = new int[8, 8]
        {
            {0,11,0,11,0,11,0,11 },
            {11,0,11,0,11,0,11,0 },
            {0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0 },
            {0,22,0,22,0,22,0,22 },
            {22,0,22,0,22,0,22,0},
        };

        // простой ход в пустоту -> только вперед
        // попытка съесть -> в любую сторону
        // если попытка съесть увенчалась успехом, то пытаемся съесть еще
        // запихиваем это все в массив массивов

        // пытаемся сделать ход
        // если ход пуст то добавляем его
        // если можем съесть врага, то добавляем этот ход и смотрим можем ли мы съесть кого то еще

        public bool GetMove(int row, int column)
        {
            
            return true;
        }

        List<int> TryEat2(int row, int column)
        {
            // если на клетке стоит враг, а следующая пуста


            for (int i = row - 1; i <= row + 1; i+=2)
            {
                for (int j = column - 1; j <= column + 1; j+=2)
                {
                    // если следующая клетка вражеская
                    if ((this.InsideBoard(i, j) && (IsEnemy(i, j))))
                    {
                        // и если следующая свободна
                        for (int ii = row - 1; ii <= i + 1; ii += 2)
                        {
                            for (int jj = j - 1; jj <= j + 1; jj += 2)
                            {
                                if ((this.InsideBoard(ii, jj) && (IsEnemy(ii, jj) == false)))
                                {
                                    return new List<int> { ii, jj };
                                }
                            }
                        }
                    }
                } 
            }
                    //if (IsEnemy(row, j)
            return new List<int> { };
        }


        public List<List<int>> TryEat(int row, int column)
        {
            // сделаем вид что у нас одиночные шахматы
            // еще нужно посомтреть как объединять листы

            List<List<int>> t = new List<List<int>>();
            List<int> tt = new List<int>();


            // если на клетке стоит враг, а следующая пуста, то добавляем клетку и идем есть дальше
            // левый верх
            if ((this.InsideBoard(row - 1, column - 1) && this.InsideBoard(row - 2, column - 2)))
            {
                tt.Append(row - 2);
                tt.Append(column - 2);
                t.Append(tt);
            }
            tt.Append(row - 1);
            tt.Append(column - 1);
            t.Append(tt);





            return t; // return t.Append(new List<int> { row - 2, column - 2 });
        }



        public List<int> TryEatLeftUp(int row, int column)
        {
            // если на клетке стоит враг, а следующая пуста, то добавляем клетку и идем есть дальше
            if ((this.InsideBoard(row - 1, column - 1) && this.InsideBoard(row - 2, column - 2) &&
            IsEnemy(row - 1, column - 1) && this.Board[row - 2, column - 2] == 0))
                return new List<int> { row - 2, column - 2 };
            return null;
        }

        public List<int> TryEatRightUp(int row, int column)
        {
            // если на клетке стоит враг, а следующая пуста, то добавляем клетку и идем есть дальше
            if ((this.InsideBoard(row - 1, column + 1) && this.InsideBoard(row - 2, column + 2) &&
            IsEnemy(row - 1, column + 1) && this.Board[row - 2, column + 2] == 0))
                return new List<int> { row - 2, column + 2 };
            return null;
        }

        public List<int> TryEatLeftDown(int row, int column)
        {
            // если на клетке стоит враг, а следующая пуста, то добавляем клетку и идем есть дальше
            if ((this.InsideBoard(row + 1, column - 1) && this.InsideBoard(row + 2, column - 2) &&
            IsEnemy(row + 1, column - 1) && this.Board[row + 2, column - 2] == 0))
                return new List<int> { row + 2, column - 2 };
            return null;
        }

        public List<int> TryEatRightDown(int row, int column)
        {
            // если на клетке стоит враг, а следующая пуста, то добавляем клетку и идем есть дальше
            if ((this.InsideBoard(row + 1, column + 1) && this.InsideBoard(row + 2, column + 2) &&
            IsEnemy(row + 1, column + 1) && this.Board[row + 2, column + 2] == 0))
                return new List<int> { row + 2, column + 2 };
            return null;
        }

        public List<List<int>> GetСheckersMoves(int row, int column)
        {
            List<List<int>> Moves = new List<List<int>>();
            List<List<int>> per = new List<List<int>>();
            List<int> coord = new List<int>();

            // обычный ход. надо как то ограничить чтобы было только в одну сторону
            for (int i = row - 1; i <= row + 1; i+=2)
            {
                for (int j = column - 1; j <= column + 1; j+=2)
                {
                    // если клетка пустая
                    if (this.InsideBoard(i, j) && IsEnemy(i,j) == false)
                    {
                        if (ChekMove(i, j))
                        {
                            Moves.Add(new List<int> { i, j });
                        }
                    }
                    
                }
            }


            coord = TryEatLeftUp(row, column);
            if (coord != null) Moves.Add(coord);

            coord = TryEatRightUp(row, column);
            if (coord != null) Moves.Add(coord);

            coord = TryEatLeftDown(row, column);
            if (coord != null) Moves.Add(coord);

            coord = TryEatRightDown(row, column);
            if (coord != null) Moves.Add(coord);



            return Moves;
        }

        public bool GameOver(int row, int column)
        {
            return false;
        }


        public bool CanEat(int row, int column)
        {
            return false;
        }

        public bool UnderAttack(int row, int column)
        {
            return false;
        }

        // возвращает массив с лучшими ходами
        // лучший ход 1 - съесть кого нибудь
        // лучший ход 2 - не попасть под удар другой фигуры
        // лучший ход 3 - съесть, но попасть под удар
        // лучший ход 4 - попасть под удар
        public List<List<int>> BestMove(int row, int column)
        {
            List<List<int>> Moves = new List<List<int>>();

            // узнать какая фигура стоит на этом месте
            // узнать куда она может сходить и получить массив возможных ходов
            return Moves;
        }

    }


        public class ChessOnBoard : GameOnBoard
        {

        public List<List<int>> GetKingMoves(int row, int column)
        {
            List<List<int>> Moves = new List<List<int>>();

            for (int i = row - 1; i <= row + 1; i++)            
                for (int j = column - 1; j <= column + 1; j++)                
                    if (this.InsideBoard(i, j) && ChekMove(i, j))
                        Moves.Add(new List<int> { i, j });

            return Moves;
        }

        public List<List<int>> GetQueenMoves(int row, int column)
        {
            List<List<int>> Moves = new List<List<int>>();


            // нужно знать когда останавливаться.
            // сначала найти не мешают ли фигуры
            //int startI = 0;
            //int startJ = 8;

            // вверх до препятствия
            bool enemyCanBeEaten = true;
            for (int i = row - 1; i >= 0; i--)           
                if (this.InsideBoard(i, column) && enemyCanBeEaten)
                {
                    if (IsPlayer(i, column))
                        enemyCanBeEaten = false;
                    else if (IsEnemy(i, column))
                    {
                        enemyCanBeEaten = false;
                        Moves.Add(new List<int> { i, column });
                    }
                    else Moves.Add(new List<int> { i, column });
                }
                else break;
            // вниз до препятствия
            enemyCanBeEaten = true;
            for (int i = row + 1; i < 8; i++)
                if (this.InsideBoard(i, column) && enemyCanBeEaten)
                {
                    if (IsPlayer(i, column))
                        enemyCanBeEaten = false;
                    else if (IsEnemy(i, column))
                    {
                        enemyCanBeEaten = false;
                        Moves.Add(new List<int> { i, column });
                    }
                    else Moves.Add(new List<int> { i, column });
                }
                else break;

            // вправо до препятствия
            enemyCanBeEaten = true;
            for (int j = column + 1; j < 8; j++)
                if (this.InsideBoard(row, j) && enemyCanBeEaten)
                {
                    if (IsPlayer(row, j))
                        enemyCanBeEaten = false;
                    else if (IsEnemy(row, j))
                    {
                        enemyCanBeEaten = false;
                        Moves.Add(new List<int> { row, j });
                    }
                    else Moves.Add(new List<int> { row, j });
                }
                else break;

            // влево до препятствия
            enemyCanBeEaten = true;
            for (int j = column - 1; j >= 0; j--)
                if (this.InsideBoard(row, j) && enemyCanBeEaten)
                {
                    if (IsPlayer(row, j))
                        enemyCanBeEaten = false;
                    else if (IsEnemy(row, j))
                    {
                        enemyCanBeEaten = false;
                        Moves.Add(new List<int> { row, j });
                    }
                    else Moves.Add(new List<int> { row, j });
                }
                else break;

            // лево вверх
            enemyCanBeEaten = true;
            for (int i = row - 1, j = column - 1; i + j >= 0; i--, j--)
                if (this.InsideBoard(i, j) && enemyCanBeEaten)
                {
                    if (IsPlayer(i, j))
                        enemyCanBeEaten = false;
                    else if (IsEnemy(i, j))
                    {
                        enemyCanBeEaten = false;
                        Moves.Add(new List<int> { i, j });
                    }
                    else Moves.Add(new List<int> { i, j });
                }
                else break;

            // лево низ
            enemyCanBeEaten = true;
            for (int i = row + 1, j = column - 1; i + j >= 0; i++, j--)
                if (this.InsideBoard(i, j) && enemyCanBeEaten)
                {
                    if (IsPlayer(i, j))
                        enemyCanBeEaten = false;
                    else if (IsEnemy(i, j))
                    {
                        enemyCanBeEaten = false;
                        Moves.Add(new List<int> { i, j });
                    }
                    else Moves.Add(new List<int> { i, j });
                }
                else break;

            // право низ
            enemyCanBeEaten = true;
            for (int i = row + 1, j = column + 1; i + j >= 0; i++, j++)
                if (this.InsideBoard(i, j) && enemyCanBeEaten)
                {
                    if (IsPlayer(i, j))
                        enemyCanBeEaten = false;
                    else if (IsEnemy(i, j))
                    {
                        enemyCanBeEaten = false;
                        Moves.Add(new List<int> { i, j });
                    }
                    else Moves.Add(new List<int> { i, j });
                }
                else break;

            // право верх
            enemyCanBeEaten = true;
            for (int i = row - 1, j = column + 1; i + j >= 0; i--, j++)
                if (this.InsideBoard(i, j) && enemyCanBeEaten)
                {
                    if (IsPlayer(i, j))
                        enemyCanBeEaten = false;
                    else if (IsEnemy(i, j))
                    {
                        enemyCanBeEaten = false;
                        Moves.Add(new List<int> { i, j });
                    }
                    else Moves.Add(new List<int> { i, j });
                }
                else break;

            return Moves;
        }

        public List<List<int>> GetBasicCellChecks(List<List<int>> moves, int row, int column)
        {

            return moves;
        }

        public List<List<int>> GetRookMoves(int row, int column)
        {
            List<List<int>> Moves = new List<List<int>>();
            // вверх до препятствия
            bool enemyCanBeEaten = true;
            for (int i = row - 1; i >= 0; i--)
                if (this.InsideBoard(i, column) && enemyCanBeEaten)
                {
                    if (IsPlayer(i, column))
                        enemyCanBeEaten = false;
                    else if (IsEnemy(i, column))
                    {
                        enemyCanBeEaten = false;
                        Moves.Add(new List<int> { i, column });
                    }
                    else Moves.Add(new List<int> { i, column });
                }
                else break;
            // вниз до препятствия
            enemyCanBeEaten = true;
            for (int i = row + 1; i < 8; i++)
                if (this.InsideBoard(i, column) && enemyCanBeEaten)
                {
                    if (IsPlayer(i, column))
                        enemyCanBeEaten = false;
                    else if (IsEnemy(i, column))
                    {
                        enemyCanBeEaten = false;
                        Moves.Add(new List<int> { i, column });
                    }
                    else Moves.Add(new List<int> { i, column });
                }
                else break;

            // вправо до препятствия
            enemyCanBeEaten = true;
            for (int j = column + 1; j < 8; j++)
                if (this.InsideBoard(row, j) && enemyCanBeEaten)
                {
                    if (IsPlayer(row, j))
                        enemyCanBeEaten = false;
                    else if (IsEnemy(row, j))
                    {
                        enemyCanBeEaten = false;
                        Moves.Add(new List<int> { row, j });
                    }
                    else Moves.Add(new List<int> { row, j });
                }
                else break;

            // влево до препятствия
            enemyCanBeEaten = true;
            for (int j = column - 1; j >= 0; j--)
                if (this.InsideBoard(row, j) && enemyCanBeEaten)
                {
                    if (IsPlayer(row, j))
                        enemyCanBeEaten = false;
                    else if (IsEnemy(row, j))
                    {
                        enemyCanBeEaten = false;
                        Moves.Add(new List<int> { row, j });
                    }
                    else Moves.Add(new List<int> { row, j });
                }
                else break;
            return Moves;
        }

        public List<List<int>> GetBishopMoves(int row, int column)
        {
            List<List<int>> Moves = new List<List<int>>();

            // лево вверх
            bool enemyCanBeEaten = true;
            for (int i = row - 1, j = column - 1; i+j >= 0; i--, j--)
                if (this.InsideBoard(i, j) && enemyCanBeEaten)
                {
                    if (IsPlayer(i, j))
                        enemyCanBeEaten = false;
                    else if (IsEnemy(i, j))
                    {
                        enemyCanBeEaten = false;
                        Moves.Add(new List<int> { i, j });
                    }
                    else Moves.Add(new List<int> { i, j });
                }
                else break;

            // лево низ
            enemyCanBeEaten = true;
            for (int i = row + 1, j = column - 1; i + j >= 0; i++, j--)
                if (this.InsideBoard(i, j) && enemyCanBeEaten)
                {
                    if (IsPlayer(i, j))
                        enemyCanBeEaten = false;
                    else if (IsEnemy(i, j))
                    {
                        enemyCanBeEaten = false;
                        Moves.Add(new List<int> { i, j });
                    }
                    else Moves.Add(new List<int> { i, j });
                }
                else break;

            // право низ
            enemyCanBeEaten = true;
            for (int i = row + 1, j = column + 1; i + j >= 0; i++, j++)
                if (this.InsideBoard(i, j) && enemyCanBeEaten)
                {
                    if (IsPlayer(i, j))
                        enemyCanBeEaten = false;
                    else if (IsEnemy(i, j))
                    {
                        enemyCanBeEaten = false;
                        Moves.Add(new List<int> { i, j });
                    }
                    else Moves.Add(new List<int> { i, j });
                }
                else break;

            // право верх
            enemyCanBeEaten = true;
            for (int i = row - 1, j = column + 1; i + j >= 0; i--, j++)
                if (this.InsideBoard(i, j) && enemyCanBeEaten)
                {
                    if (IsPlayer(i, j))
                        enemyCanBeEaten = false;
                    else if (IsEnemy(i, j))
                    {
                        enemyCanBeEaten = false;
                        Moves.Add(new List<int> { i, j });
                    }
                    else Moves.Add(new List<int> { i, j });
                }
                else break;



            return Moves;
        }

        public List<List<int>> GetKnightMoves(int row, int column)
        {
            List<List<int>> Moves = new List<List<int>>();

            for (int i = row - 1; i <= row + 1; i += 2)
                for (int j = column - 2; j <= column + 2; j += 4)
                    if (this.InsideBoard(i, j) && IsEnemyOrNull(i, j))
                        Moves.Add(new List<int> { i, j });

            for (int i = row - 2; i <= row + 2; i += 4)            
                for (int j = column - 1; j <= column + 1; j+=2)                
                    if (this.InsideBoard(i, j) && IsEnemyOrNull(i, j))                                       
                        Moves.Add(new List<int> { i, j });
                        
            return Moves;
        }

        public List<List<int>> GetPawnMoves(int row, int column)
        {
            List<List<int>> Moves = new List<List<int>>();

            int direction = -1;
            if (this.CurrentPlayer == 2)
                direction = 1;
            
            // обычный ход на 1
            if (this.InsideBoard(row + direction, column) && IsNull(row + direction, column))
                Moves.Add(new List<int> { row + direction, column });

            // первый ход на 2
            if ( ((this.CurrentPlayer == 2 && row == 1) || (this.CurrentPlayer == 1 && row == 6)) &&
                (this.InsideBoard(row + (direction * 2), column) && IsNull(row + (direction * 2), column) &&
                (IsNull(row + direction, column)) ) )
                Moves.Add(new List<int> { row + (direction * 2), column });

            // попытка съесть фигуру
            if (this.InsideBoard(row + direction, column + 1) && IsEnemy(row + direction, column + 1))
                Moves.Add(new List<int> { row + direction, column + 1});
            if (this.InsideBoard(row + direction, column - 1) && IsEnemy(row + direction, column - 1))
                Moves.Add(new List<int> { row + direction, column - 1 });

            return Moves;
        }

        public bool IsCheck()
        {
            List<List<int>> Moves = new List<List<int>>();

            // проверить под ударом ли король и вывести соответствующее сообщение
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (IsEnemy(i, j))
                    {
                        
                        switch (GetTypeOfFigure(i, j)) // получаем все ходы
                        {
                            case 1:
                                Moves = GetKingMoves(i, j);
                                break;
                            case 2:
                                Moves = GetQueenMoves(i, j);
                                break;
                            case 3:
                                Moves = GetBishopMoves(i, j);
                                break;
                            case 4:
                                Moves = GetKnightMoves(i, j);
                                break;
                            case 5:
                                Moves = GetRookMoves(i, j);
                                break;
                            case 6:
                                Moves = GetPawnMoves(i, j);
                                break;
                        }
                        foreach (var move in Moves) // проверяем задевают ли они короля
                        {
                            if (GetTypeOfFigure(move[0], move[1]) == 1)
                                return true;
                        }
                    }
                }
            }

            return false;
        }

        public bool IsMate()
        {
            int countKings = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (GetTypeOfFigure(i, j) == 1)
                        countKings += 1;
                }
            }

            if (countKings == 2)
                return false;
            else return true;
        }


        public bool IsDraw(int row, int column)
        {
            return false;
        }



        public Dictionary<List<int>, List<List<int>>> GetMovesCurrentPlayer()
        {
            List<List<int>> Moves = new List<List<int>>();
            Dictionary<List<int>, List<List<int>>> CellsAndMoves = new Dictionary<List<int>, List<List<int>>>();

            // обходим доску
            // если фигура нужная нам то запускаем необходимую функцию
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (IsPlayer(i, j)) 
                    {
                        switch (GetTypeOfFigure(i, j)) // получаем все ходы
                        {
                            case 1:
                                Moves = GetKingMoves(i, j);
                                break;
                            case 2:
                                Moves = GetQueenMoves(i, j);
                                break;
                            case 3:
                                Moves = GetBishopMoves(i, j);
                                break;
                            case 4:
                                Moves = GetKnightMoves(i, j);
                                break;
                            case 5:
                                Moves = GetRookMoves(i, j);
                                break;
                            case 6:
                                Moves = GetPawnMoves(i, j);
                                break;
                        }
                        CellsAndMoves[new List<int> { i, j }] = Moves;
                    }
                }
            }

            return CellsAndMoves;
        }

        // возвращает массив с лучшими ходами
        // лучший ход 1 - съесть кого нибудь
        // лучший ход 2 - не попасть под удар другой фигуры
        // лучший ход 3 - съесть, но попасть под удар
        // лучший ход 4 - попасть под удар
        public Dictionary<List<int>, List<List<int>>> GetBestMove()
        {

            //List<List<int>> MovesCanEat = new List<List<int>>();
            //List<List<int>> MovesCanNothing = new List<List<int>>();
            //List<List<int>> MovesCanDie = new List<List<int>>();
            //List<List<int>> MovesCanEatAndDie = new List<List<int>>();
            
            List<List<int>> Moves = new List<List<int>>();
            //List<List<int>> Temp = new List<List<int>>();
            Dictionary<List<int>, List<List<int>>> CellsAndMoves = GetMovesCurrentPlayer();
            Dictionary<List<int>, List<List<int>>> FilterCellsAndMoves = new Dictionary<List<int>, List<List<int>>>();

            // берем только те ходы которые кого то едят
            foreach (List<int> key in CellsAndMoves.Keys)
            {                
                List<List<int>> FilterCoord = new List<List<int>>();
                foreach (List<int> coord in CellsAndMoves[key])
                {
                    if (IsEnemy(coord[0], coord[1]))                    
                        FilterCoord.Add(new List<int> { coord[0], coord[1] });                    
                }
                if (FilterCoord.Count > 0)
                    FilterCellsAndMoves[key] = FilterCoord;
            }
            // если по итогу новый словарь пуст, то берем оригинальный
            if (FilterCellsAndMoves.Count > 0)
                return FilterCellsAndMoves;
            else return CellsAndMoves;
        }


    }

}
