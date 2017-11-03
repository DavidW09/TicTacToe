using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe
{
    public class Board
    {
        private Map[,] coordinates = new Map[3, 3];
        private int numberOfMoves = 0;
        private int xWins;
        private int oWins;
        private int catWins;
        private Form1 form;
        private bool hasWinner;
        private bool isCat;

        private const int X = 0;
        private const int O = 1;
        private const int B = 2;

        public Board(Form1 form)
        {
            InitializeBoard();
            this.form = form;
            xWins = 0;
            oWins = 0;
            catWins = 0;
        }

        public void DetectHit(Point point)
        {
            int x = GetXCoordinate(point.X);
            int y = GetYCoordinate(point.Y);
            if (y != -1 && !hasWinner && !isCat)
            {

                if (numberOfMoves % 2 == 0)
                {
                    form.DrawX(new Point(x, y));
                    coordinates[x, y].SetValue(X);
                    if (IsWinner(X))
                    {
                        hasWinner = true;
                        MessageBox.Show("X has won!");
                        xWins++;
                    }
                }
                else
                {
                    form.DrawO(new Point(x, y));
                    coordinates[x, y].SetValue(O);
                    if (IsWinner(O))
                    {
                        hasWinner = true;
                        MessageBox.Show("O has won!");
                        oWins++;
                    }
                }
                numberOfMoves++;
                CheckCatsGame();
            }

        }

        public void Reset()
        {
            InitializeBoard();
        }

        public string getPlayer()
        {
            if (!hasWinner)
            {
                if (numberOfMoves % 2 == 0)
                    return "X";
                else
                    return "O";
            }
            else
            {
                return "";
            }
        }
        public int getXWins()
        {
            return xWins;
        }
        public int getOWins()
        {
            return oWins;
        }
        public int getCatWins()
        {
            return catWins;
        }


        private void InitializeBoard()
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    coordinates[x, y] = new Map();
                    coordinates[x, y].SetLocation(new Point(x, y));
                    coordinates[x, y].SetValue(B);
                }
            }
            hasWinner = false;
            isCat = false;
            numberOfMoves = 0;
        }

        private bool IsWinner(int value)
        {
            for(int x = 0; x < 3; x++)
            {
                if (coordinates[x, 0].GetValue() == value && coordinates[x, 1].GetValue() == value && coordinates[x, 2].GetValue() == value)
                    return true;
            }
            for (int y = 0; y < 3; y++)
            {
                if (coordinates[0, y].GetValue() == value && coordinates[1, y].GetValue() == value && coordinates[2, y].GetValue() == value)
                    return true;
            }
            if (coordinates[0, 0].GetValue() == value && coordinates[1, 1].GetValue() == value && coordinates[2, 2].GetValue() == value)
                return true;
            if (coordinates[2, 0].GetValue() == value && coordinates[1, 1].GetValue() == value && coordinates[0, 2].GetValue() == value)
                return true;
            return false;
        }

        private int GetXCoordinate(int x)
        {
            if (x < 167)
                return 0;
            else if (x > 167 && x < 334)
                return 1;
            else
                return 2;
        }
        private int GetYCoordinate(int y)
        {
            if (y < 167)
                return 0;
            else if (y > 167 && y < 334)
                return 1;
            else if (y > 334 && y < 500)
                return 2;
            else
                return -1;
        }

        private void CheckCatsGame()
        {
            if(!hasWinner && numberOfMoves >= 9)
            {
                catWins++;
                isCat = true;
            }
        }
    }
}
