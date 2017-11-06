using System.Collections.Generic;
using System.Drawing;

namespace TicTacToe
{
    public class ComputerPlayer
    {
        private GameController gameController;
        private Tile[,] tiles;
        private List<Point> xLocations;
        private List<Point> cLocations;

        public ComputerPlayer(GameController gc)
        {
            gameController = gc;
        }

        public void PlaceMove(Tile[,] t)
        {
            tiles = t;
            int remainingMoves = CountEmptySlots();
            if (remainingMoves >= 8)
                DoStartingStrategy();
            else if (remainingMoves >= 2)
                EnsureCatsGame();
            else
                PlaceLastPiece();
            

        }

        private int CountEmptySlots()
        {
            int counter = 0;
            foreach(Tile t in tiles)
            {
                if (t.GetValue() == BoardValue.C)
                    counter++;
            }
            return counter;
        }

        private void DoStartingStrategy()
        {
            if (tiles[1, 1].GetValue() == BoardValue.C)
                gameController.PlaceMove(1, 1);
            else
                gameController.PlaceMove(0, 0);
        }

        private void EnsureCatsGame()
        {
            FindXs();
            BlockHorizontalMoves();
        }
        private void FindXs()
        {
            xLocations = new List<Point>();
            cLocations = new List<Point>();
            for (int x = 0; x < 3; x++)
            {
                for(int y = 0; y < 3; y++)
                {
                    if(tiles[x,y].GetValue() == BoardValue.X)
                    {
                        xLocations.Add(new Point(x, y));
                    }
                    else if (tiles[x, y].GetValue() == BoardValue.C)
                    {
                        cLocations.Add(new Point(x, y));
                    }
                }
            }
        }

        private void BlockHorizontalMoves()
        {
            int[] rows = new int[3];
            foreach(Point p in xLocations)
            {
                rows[p.X]++;
            }
            foreach(int i in rows)
            {
                if(i > 2 )
                {

                }
            }
        }

        private void PlaceLastPiece()
        {

        }


    }
}
