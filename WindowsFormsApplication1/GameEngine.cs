using System.Drawing;

namespace TicTacToe
{
    public class GameEngine
    {
        private GameBoard gameBoard;
        private ScoreBoard scoreBoard;
        private GameController gameController;
        private Form1 form;

        public GameEngine(Form1 form)
        {
            this.form = form;
            gameBoard = new GameBoard();
            scoreBoard = new ScoreBoard();
            gameController = new GameController(this, gameBoard, scoreBoard);
            form.SetScoreBoard(scoreBoard);

        }
   
        public void PlaceMove(Point point)
        {
            int x = ConvertPoint(point.X);
            int y = ConvertPoint(point.Y);
            gameController.PlaceMove(x, y);
        }

        public void DrawX(int x, int y)
        {
            form.DrawX(new Point(x, y));
        }

        public void DrawO(int x, int y)
        {
            form.DrawO(new Point(x, y));
        }

        public void Reset()
        {
            gameBoard.Reset();
            gameController.Reset();
        }

        private int ConvertPoint(int p)
        {
            if (p < 167)
                return 0;
            else if (p > 167 && p < 334)
                return 1;
            else
                return 2;
        }

    }
}
