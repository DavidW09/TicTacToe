using System;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        private GameGraphics engine;
        private GameEngine game;
        private ScoreBoard scoreBoard;

        public Form1()
        {
            InitializeComponent();
        }

        public void DrawX(Point p)
        {
            engine.DrawX(p);
        }
        public void DrawO(Point p)
        {
            engine.DrawO(p);
        }

        public void SetScoreBoard(ScoreBoard s)
        {
            scoreBoard = s;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            engine = new GameGraphics(panel1.CreateGraphics());
            game = new GameEngine(this);
            RefreshLabel();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Point mouse = Cursor.Position;
            mouse = panel1.PointToClient(mouse);
            if (IsMove(mouse))
                game.PlaceMove(mouse);
            RefreshLabel();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            game.Reset();
            engine.InitializeCanvas();
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Meow \n Meow Meow Meow");
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aiButton_Click(object sender, EventArgs e)
        {
            game.toggleAI();
        }
        
        private void RefreshLabel()
        {
            String info = "It is ";
            info += scoreBoard.GetCurrentPlayer();
            info += "'s turn \n";
            info += "Ai is currently turned " + scoreBoard.getAiStatus() + " \n";
            info += "X has won " + scoreBoard.GetXWins() + " times.\n";
            info += "O has won " + scoreBoard.GetOWins() + " times.\n";
            info += "Cat has won " + scoreBoard.GetCatWins() + " times.\n";
            label1.Text = info;
        }
        private bool IsMove(Point p)
        {
            if(p.Y <= 500)
                return true;
            return false;            
        }
    }
}
