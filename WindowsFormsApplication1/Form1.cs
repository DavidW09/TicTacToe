using System;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        private GameGraphics engine;
        Board gameBoard;

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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            engine = new GameGraphics(panel1.CreateGraphics());
            gameBoard = new Board(this);
            RefreshLabel();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Point mouse = Cursor.Position;
            mouse = panel1.PointToClient(mouse);
            gameBoard.DetectHit(mouse);
            RefreshLabel();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            gameBoard.Reset();
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
        
        private void RefreshLabel()
        {
            String info = "It is ";
            info += gameBoard.getPlayer();
            info += "'s turn \n";
            info += "X has won " + gameBoard.getXWins() + " times.\n";
            info += "O has won " + gameBoard.getOWins() + " times.\n";
            info += "Cat has won " + gameBoard.getCatWins() + " times.\n";
            label1.Text = info;
        }
    }
}
