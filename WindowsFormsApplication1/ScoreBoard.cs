using System.Windows.Forms;

namespace TicTacToe
{
    public class ScoreBoard
    {
        private int xWins;
        private int oWins;
        private int catWins;
        private string currentPlayer;

        public ScoreBoard()
        {
            xWins = 0;
            oWins = 0;
            catWins = 0;
            currentPlayer = "X";
        }
        
        public int GetXWins()
        {
            return xWins;
        }
        public int GetOWins()
        {
            return oWins;
        }
        public int GetCatWins()
        {
            return catWins;
        }
        public string GetCurrentPlayer()
        {
            return currentPlayer;
        }

        public void SetCurrentPlayer(string player)
        {
            currentPlayer = player;
        }
        public void IncrementCatWins()
        {
            MessageBox.Show("Cat's Game!");
            catWins++;
        }
        public void IncrementOWins()
        {
            MessageBox.Show("O has won!");
            oWins++;
        }
        public void IncrementXWins()
        {
            MessageBox.Show("X has won!");
            xWins++;
        }

    }
}
