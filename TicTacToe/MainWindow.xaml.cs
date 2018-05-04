using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe
{
    public partial class MainWindow : Window
    {
        char[,] rects;
        bool player1X, gameModeComputer, isPlayer1Turn, canPlay;
        int drawCount;

        public MainWindow()
        {
            InitializeComponent();

            InitGameboard();

            startBtn.IsEnabled = true;
            radioCompPlay.IsEnabled = false;
            radio2Play.IsEnabled = false;
            menu2Play.IsEnabled = false;
            menuCompPlay.IsEnabled = false;

            player1X = false;
            isPlayer1Turn = false;
            gameModeComputer = true;
            canPlay = false;

            rects = new char[3, 3];
            drawCount = 0;
        }

        private void InitGameboard()
        {
            Line l = new Line();
            l.Stroke = Brushes.Black;
            l.X1 = 100;
            l.X2 = 100;
            l.Y1 = 0;
            l.Y2 = 300;
            l.StrokeThickness = 2;
            mainCanvas.Children.Add(l);

            l = new Line();
            l.Stroke = Brushes.Black;
            l.X1 = 200;
            l.X2 = 200;
            l.Y1 = 0;
            l.Y2 = 300;
            l.StrokeThickness = 2;
            mainCanvas.Children.Add(l);

            l = new Line();
            l.Stroke = Brushes.Black;
            l.X1 = 0;
            l.X2 = 300;
            l.Y1 = 100;
            l.Y2 = 100;
            l.StrokeThickness = 2;
            mainCanvas.Children.Add(l);

            l = new Line();
            l.Stroke = Brushes.Black;
            l.X1 = 0;
            l.X2 = 300;
            l.Y1 = 200;
            l.Y2 = 200;
            l.StrokeThickness = 2;
            mainCanvas.Children.Add(l);
        }

        private void DrawO(double x, double y)
        {
            Ellipse el = new Ellipse();
            el.Stroke = Brushes.Aquamarine;
            el.StrokeThickness = 10;

            el.Width = 85;
            el.Height = 85;

            Canvas.SetTop(el, y);
            Canvas.SetLeft(el, x);

            mainCanvas.Children.Add(el);
        }

        private void DrawX(double x, double y)
        {
            Line l;

            double j = 0, k = 80;

            for (int i = 0; i < 2; i++)
            {
                l = new Line();
                l.Stroke = Brushes.Blue;
                l.X1 = 0;
                l.X2 = 80;
                l.Y1 = j;
                l.Y2 = k;
                l.StrokeThickness = 10;
                mainCanvas.Children.Add(l);
                Canvas.SetTop(l, y);
                Canvas.SetLeft(l, x);
                j = 80;
                k = 0;
            }
            
        }

        private bool CheckIfWon(int x, int y)
        {
            if (CheckRow(x, y) || CheckColumn(x, y) || CheckDiagonalOne(x, y) || CheckDiagonalTwo(x, y))
                return true;

            return false;
        }

        private bool CheckRow(int x, int y)
        {
            char symbol = rects[x, y];

            bool won = false;

            //check row
            for(int i = 0; i < 3; i++)
            {
                if (rects[x, i].Equals(symbol))
                {
                    won = true;
                }
                else
                    return false;
            }

            return won;
        }

        private bool CheckColumn(int x, int y)
        {
            char symbol = rects[x, y];

            bool won = false;

            //check column
            for (int i = 0; i < 3; i++)
            {
                if (rects[i, y].Equals(symbol))
                {
                    won = true;
                }
                else
                    return false;
            }

            return won;
        }

        private bool CheckDiagonalOne(int x, int y)
        {
            char symbol = rects[x, y];

            bool won = false;

            //check diagonal
            for (int i = 0; i < 3; i++)
            {
                if (rects[i, i].Equals(symbol))
                {
                    won = true;
                }
                else
                    return false;
            }

            return won;
        }

        private bool CheckDiagonalTwo(int x, int y)
        {
            char symbol = rects[x, y];

            bool won = false;

            //check diagonal
            for (int i = 0, j = 2; i < 3; i++, j--)
            {
                if (rects[i, j].Equals(symbol))
                {
                    won = true;
                }
                else
                    return false;
            }

            return won;
        }

        private void startBtn_Click(object sender, RoutedEventArgs e)
        {
            canPlay = true;

            startBtn.IsEnabled = false;
            radioCompPlay.IsEnabled = true;
            radio2Play.IsEnabled = true;
            menu2Play.IsEnabled = true;
            menuCompPlay.IsEnabled = true;

            Random r = new Random();
            int randNum = r.Next(0, 2);

            if (randNum == 0)
            {
                player1X = true;
                player1.Content = "Player 1 = X";
                player2.Content = "Player 2 = O";
            }

            else
            {
                player1X = false;
                player1.Content = "Player 1 = O";
                player2.Content = "Player 2 = X";
            }

            isPlayer1Turn = true;
        }

        private void onMouse_click(object sender, MouseButtonEventArgs e)
        {
            if (canPlay)
            {
                Point p = Mouse.GetPosition(mainCanvas);

                for (int x = 100, i = 0; x <= 300; x += 100, i++)
                {
                    if (p.X < x && p.X > 0 && p.X > x - 100)
                    {
                        for (int y = 100, j = 0; y <= 300; y += 100, j++)
                        {
                            if (p.Y < y && p.Y > 0 && rects[j, i].Equals('\0') && p.Y > y - 100)
                            {
                                if(drawCount == 8)
                                {
                                    if (player1X)
                                        DrawX(x - 90, y - 90);
                                    else
                                        DrawO(x - 92.5, y - 92.5);

                                    Player1Tie();
                                }
                                if (isPlayer1Turn)
                                {
                                    if (player1X)
                                    {
                                        DrawX(x - 90, y - 90);
                                        rects[j, i] = 'x';
                                    }
                                    else
                                    {
                                        DrawO(x - 92.5, y - 92.5);
                                        rects[j, i] = 'o';
                                    }

                                    drawCount++;

                                    if (!gameModeComputer)
                                        isPlayer1Turn = false;

                                    if (CheckIfWon(j, i))
                                    {
                                        Player1Wins();
                                        return;
                                    }

                                    if (gameModeComputer)
                                    {
                                        //draw opposite symbol in a random spot >:)
                                        int m, n;
                                        do
                                        {
                                            Random r = new Random();
                                            m = r.Next(0, 3);
                                            n = r.Next(0, 3);
                                        }
                                        while (!rects[m, n].Equals('\0'));

                                        if (player1X)
                                        {
                                            DrawO((n * 100) + 7.5, (m * 100) + 7.5);
                                            rects[m, n] = 'o';
                                        }
                                        else
                                        {
                                            DrawX((n * 100) + 10, (m * 100) + 10);
                                            rects[m, n] = 'x';
                                        }

                                        drawCount++;

                                        if (CheckIfWon(m, n))
                                        {
                                            Player1Lose();
                                            return;
                                        }
                                    }

                                    return;
                                }
                                else
                                {
                                    if (player1X)
                                    {
                                        DrawO(x - 92.5, y - 92.5);
                                        rects[j, i] = 'o';
                                    }
                                    else
                                    {
                                        DrawX(x - 90, y - 90);
                                        rects[j, i] = 'x';
                                    }

                                    drawCount++;

                                    if (CheckIfWon(j, i))
                                    {
                                        Player1Lose();
                                        return;
                                    }

                                    isPlayer1Turn = true;

                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }//end onMouse_click

        public void Player1Wins()
        {
            winLoseLabel.Content = "PLAYER 1 WINS!";
            canPlay = false;
        }

        public void Player1Lose()
        {
            if (gameModeComputer)
            {
                winLoseLabel.Content = "YOU LOSE:(";
            }
            else
            {
                winLoseLabel.Content = "PLAYER 2 WINS!";
            }
            canPlay = false;
        }

        public void Player1Tie()
        {
            winLoseLabel.Content = "TIE!";
        }

        private void Reset(object sender, RoutedEventArgs e)
        {
            rects = new char[3, 3];
            mainCanvas.Children.Clear();
            InitGameboard();
            drawCount = 0;

            startBtn.IsEnabled = true;
            radioCompPlay.IsEnabled = false;
            radio2Play.IsEnabled = false;
            menu2Play.IsEnabled = false;
            menuCompPlay.IsEnabled = false;
            winLoseLabel.Content = "";
            menuCompPlay.IsChecked = true;

            player1X = false;
            isPlayer1Turn = false;
            gameModeComputer = true;
            canPlay = false;
        }

        private void About_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is a simple game of tic tac toe -- get 3 in a row, and you win! Can be played with two players, or you against a computer!");
        }

        private void Rules_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Press start, choose whether or not you are playing with 2 players, or against the computer! If you get 3 in a row, you win!");
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TwoPlayer_checked(object sender, RoutedEventArgs e)
        {
            gameModeComputer = false;
            radioCompPlay.IsEnabled = false;
            radio2Play.IsEnabled = false;
            menu2Play.IsEnabled = false;
            menuCompPlay.IsEnabled = false;
        }

        private void ComputerMode_checked(object sender, RoutedEventArgs e)
        {
            gameModeComputer = true;
            radioCompPlay.IsEnabled = false;
            radio2Play.IsEnabled = false;
            menu2Play.IsEnabled = false;
            menuCompPlay.IsEnabled = false;

        }
    }
}
