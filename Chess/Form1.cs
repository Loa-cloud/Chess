using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Chess
{

    
    public partial class Form1 : Form
    {
        public Image chessSprites;
        public Button[,] butts = new Button[8, 8];
        ChessOnBoard Game = new ChessOnBoard();
        public Button prevButton;


        public Form1()
        {
            InitializeComponent();
            chessSprites = new Bitmap("C:\\study\\tpo2\\ChessGame-master\\Chess\\Sprites\\chess.png");
            CreateMap();
        }

        private void GameRestart()
        {
            Game.Reset();
            ReturnCollorToButton();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    switch (Game.Board[i, j] / 10)
                    {
                        case 0:
                            butts[i, j].BackgroundImage = null;
                            break;
                        case 1:
                            Image part = new Bitmap(50, 50);
                            Graphics g = Graphics.FromImage(part);
                            g.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 0 + 150 * (Game.Board[i, j] % 10 - 1), 0, 150, 150, GraphicsUnit.Pixel);
                            butts[i, j].BackgroundImage = part;
                            break;
                        case 2:
                            Image part1 = new Bitmap(50, 50);
                            Graphics g1 = Graphics.FromImage(part1);
                            g1.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 0 + 150 * (Game.Board[i, j] % 10 - 1), 150, 150, 150, GraphicsUnit.Pixel);
                            butts[i, j].BackgroundImage = part1;
                            break;
                    }
                }
            }
            ActivateAllButtons();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GameRestart();
        }

        public void CreateMap()
        {
            for(int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    butts[i, j] = new Button();
                    Button butt = new Button();
                    butt.Size = new Size(50, 50);
                    butt.Location = new Point(j*50,i*50);
                    
                    switch (Game.Board[i, j]/10)
                    {
                        case 1:
                            Image part = new Bitmap(50, 50);
                            Graphics g = Graphics.FromImage(part);
                            g.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 0+150*(Game.Board[i,j]%10-1), 0, 150, 150, GraphicsUnit.Pixel);
                            butt.BackgroundImage = part;
                            break;
                        case 2:
                            Image part1 = new Bitmap(50, 50);
                            Graphics g1 = Graphics.FromImage(part1);
                            g1.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 0 + 150 * (Game.Board[i, j] % 10-1), 150, 150, 150, GraphicsUnit.Pixel);
                            butt.BackgroundImage = part1;
                            break;
                    }
                    if ((i + j) % 2 == 1)
                    {
                      butt.BackColor = Color.FromArgb(155, 66, 34);
                      butt.BackColor = Color.Gray;
                    }
                  
                    butt.Click += new EventHandler(OnFigurePress);
                    this.panel1.Controls.Add(butt);
                    butts[i, j] = butt;
                }
            }
        }

        public void ReturnCollorToButton()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((i % 2 == 0) && (j % 2 == 1) || (i % 2 == 1) && (j % 2 == 0))                    
                        butts[i, j].BackColor = Color.Gray;
                    else butts[i, j].BackColor = Color.White;  
                }
             }
        }

        public void TryMateMassage()
        {
            if (Game.IsMate())
            {
                MessageBox.Show("Игра окончена!");
                GameRestart();
            }                
        }
        
        public void OnFigurePress(object sender, EventArgs e)
        {

            if (prevButton != null)
                ReturnCollorToButton();

            Button pressedButton = sender as Button;


            // если нажали на свою фигуру
            if (Game.Board[pressedButton.Location.Y / 50, pressedButton.Location.X / 50] != 0 && Game.Board[pressedButton.Location.Y / 50, pressedButton.Location.X / 50]/10 == Game.CurrentPlayer)
            {
                ReturnCollorToButton();
                pressedButton.BackColor = Color.Red;
                pressedButton.Enabled = true;
                ShowSteps(pressedButton.Location.Y / 50, pressedButton.Location.X / 50, Game.Board[pressedButton.Location.Y / 50, pressedButton.Location.X / 50]);

                if (Game.IsMoving)
                {
                    ReturnCollorToButton();
                    ActivateAllButtons();
                    //Game.IsMoving = false;
                    Game.ChangeMooving();
                }
                else Game.IsMoving = true;
            }
            else
            {
                if (Game.IsMoving)
                {
                    Game.Board[pressedButton.Location.Y / 50, pressedButton.Location.X / 50] = Game.Board[prevButton.Location.Y / 50, prevButton.Location.X / 50];
                    Game.Board[prevButton.Location.Y / 50, prevButton.Location.X / 50] = 0;
                    pressedButton.BackgroundImage = prevButton.BackgroundImage;
                    prevButton.BackgroundImage = null;
                    
                    //Game.IsMoving = false;
                    Game.ChangeMooving();
                    ReturnCollorToButton();
                    ActivateAllButtons();
                    Game.ChangePlayer();
                    SwitchPlayerColor();
                }
            }
           
            prevButton = pressedButton;
            TryMateMassage();
        }

        

        public void AI()
        {
            ReturnCollorToButton();
            bool repeat = true;
            Random rand = new Random();
            Dictionary<List<int>, List<List<int>>> Dict = Game.GetBestMove();
            List<int> Key = new List<int>();
            List<List<int>> Moves = new List<List<int>>();
            List<int> RandomMove = new List<int>();


            while (repeat)
            {
                int randomInt1 = rand.Next(0, Dict.Count);
                Key = Dict.ElementAt(randomInt1).Key;
                Moves = Dict.ElementAt(randomInt1).Value;
                if (Moves.Count != 0)
                {
                    int randomInt2 = rand.Next(Moves.Count);
                    RandomMove = Moves[randomInt2];
                    repeat = false;
                }
                else                
                    Dict.Remove(Key);
            }
            
  
            // походить
            butts[Key[0], Key[1]].BackColor = Color.Aqua;
            butts[RandomMove[0], RandomMove[1]].BackColor = Color.Blue;
            Game.Board[RandomMove[0], RandomMove[1]] = Game.Board[Key[0], Key[1]];
            Game.Board[Key[0], Key[1]] = 0;
            butts[RandomMove[0], RandomMove[1]].BackgroundImage = butts[Key[0], Key[1]].BackgroundImage;
            butts[Key[0], Key[1]].BackgroundImage = null;

            Game.ChangePlayer();
            SwitchPlayerColor();
            TryMateMassage();

        }



        // показывает шаги в зависимости от выбранной фигуры
        public void ShowSteps(int IcurrFigure, int JcurrFigure, int currFigure)
        {
            DeactivateAllButtons();
            butts[IcurrFigure, JcurrFigure].Enabled = true;

            switch (currFigure % 10)
            {
                case 1:
                    ShowPossibleMoves(Game.GetKingMoves(IcurrFigure, JcurrFigure));
                    break;
                case 2:
                    ShowPossibleMoves(Game.GetQueenMoves(IcurrFigure, JcurrFigure));
                    break;
                case 3:
                    ShowPossibleMoves(Game.GetBishopMoves(IcurrFigure, JcurrFigure));
                    break;
                case 4:
                    ShowPossibleMoves(Game.GetKnightMoves(IcurrFigure, JcurrFigure));
                    break;
                case 5:
                    ShowPossibleMoves(Game.GetRookMoves(IcurrFigure, JcurrFigure));
                    break;
                case 6:
                    ShowPossibleMoves(Game.GetPawnMoves(IcurrFigure, JcurrFigure));
                    break;
            }
        }



        public void ShowPossibleMoves(List<List<int>> ArrMoves)
        {
            for (int k = 0; k < ArrMoves.Count; k++)
            {
                butts[ArrMoves[k][0], ArrMoves[k][1]].Enabled = true;
                butts[ArrMoves[k][0], ArrMoves[k][1]].BackColor = Color.Yellow;
            }
        }


        public bool DeterminePath(int IcurrFigure,int j)
        {
            if (Game.Board[IcurrFigure, j] == 0)
            {
                butts[IcurrFigure, j].BackColor = Color.Yellow;
                butts[IcurrFigure, j].Enabled = true;
            }
            else
            {
                if (Game.Board[IcurrFigure, j] / 10 != Game.CurrentPlayer)
                {
                    butts[IcurrFigure, j].BackColor = Color.Yellow;
                    butts[IcurrFigure, j].Enabled = true;
                }
                return false;
            }
            return true;
        }


        public void DeactivateAllButtons()
        {
            for (int i = 0; i < 8; i++)            
                for (int j = 0; j < 8; j++)                
                    butts[i, j].Enabled = false;
        }

        public void ActivateAllButtons()
        {
            for (int i = 0; i < 8; i++)            
                for (int j = 0; j < 8; j++)                
                    butts[i, j].Enabled = true;
        }


        public void SwitchPlayerColor()
        {
            if (Game.CurrentPlayer == 1)
                this.CurrentPlayerButton.BackColor = Color.White;
            else 
                this.CurrentPlayerButton.BackColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AI();
        }

    }
}
