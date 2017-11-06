using System.Drawing;

namespace TicTacToe
{
    public enum BoardValue
    {
        X = 0,
        O = 1,
        C = -1,
    };
    
    public class GameBoard
    {
        private Tile[,] coordinates = new Tile[3, 3];

        public GameBoard()
        {
            InitializeBoard();
        }

        public void SetValue(int x, int y, BoardValue value)
        {
            coordinates[x, y].SetValue(value);
        }

        public void Reset()
        {
            InitializeBoard();
        }

        public bool IsWinner(BoardValue value)
        {
            for (int x = 0; x < 3; x++)
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

        public bool IsValidMove(int x, int y)
        {
            if (coordinates[x, y].GetValue() == BoardValue.C)
                return true;
            return false;
        }

        private void InitializeBoard()
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    coordinates[x, y] = new Tile();
                    coordinates[x, y].SetLocation(new Point(x, y));
                    coordinates[x, y].SetValue(BoardValue.C);
                }
            }
        }

    }
}
