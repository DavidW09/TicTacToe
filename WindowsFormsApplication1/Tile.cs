using System.Drawing;

namespace TicTacToe
{
    public class Tile
    {
        private Point location;
        private BoardValue value;

        public void SetLocation(Point p)
        {
            location = p;
        }
        public Point GetLocation()
        {
            return location;
        }
        public void SetValue(BoardValue v)
        {
            value = v;
        }
        public BoardValue GetValue()
        {
            return value;
        }
    }
}
