using System.Windows.Forms;

namespace TicTacToe
{
    public class ScoreBoard
    {
        private int xWins;
        private int oWins;
        private int catWins;
        private bool isAI;
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

        public string getAiStatus()
        {
            if (isAI)
            {
                return "On";
            }
            else
            {
                return "Off";
            }
        }

        public void SetCurrentPlayer(string player)
        {
            currentPlayer = player;
        }

        public void updatePlayerInfo(bool isAI)
        {
            this.isAI = isAI;   
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
