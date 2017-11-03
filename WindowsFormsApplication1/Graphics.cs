using System.Drawing;

namespace TicTacToe
{
    class GameGraphics
    {
        private Graphics graphics;

        public GameGraphics(Graphics g)
        {
            graphics = g;
            InitializeCanvas();
        }
        public void DrawX(Point location)
        {
            Pen xPen = new Pen(Color.LimeGreen, 5);
            int x = GetLocationValue(location.X);
            int y = GetLocationValue(location.Y);

            graphics.DrawLine(xPen, x + 10, y + 10, x + 157, y + 157);
            graphics.DrawLine(xPen, x + 157, y + 10, x + 10, y + 157);
        }

        public void DrawO(Point location)
        {
            Pen oPen = new Pen(Color.HotPink, 5);
            int x = GetLocationValue(location.X);
            int y = GetLocationValue(location.Y);

            graphics.DrawEllipse(oPen, x + 10, y + 10, 147, 147);
        }

        public void InitializeCanvas()
        {
            Brush backgroundBrush = new SolidBrush(Color.Black);
            Pen linesPen = new Pen(Color.White, 5);
            graphics.FillRectangle(backgroundBrush, new Rectangle(0, 0, 500, 599));
            graphics.DrawLine(linesPen, new Point(167, 0), new Point(167, 500));
            graphics.DrawLine(linesPen, new Point(334, 0), new Point(334, 500));
            graphics.DrawLine(linesPen, new Point(0, 167), new Point(500, 167));
            graphics.DrawLine(linesPen, new Point(0, 334), new Point(500, 334));

            graphics.DrawLine(linesPen, new Point(0, 500), new Point(500, 500));
        }
        private int GetLocationValue(int location)
        {
            return location * 167;
        }
    }
}
