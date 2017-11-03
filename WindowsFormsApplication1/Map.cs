using System.Drawing;

namespace TicTacToe
{
    public class Map
    {
        private Point location;
        private int value;

        public void SetLocation(Point p)
        {
            location = p;
        }
        public Point GetLocation()
        {
            return location;
        }
        public void SetValue(int v)
        {
            value = v;
        }
        public int GetValue()
        {
            return value;
        }
    }
}
