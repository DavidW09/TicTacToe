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
        private Point myMove;
        private bool hasMove;

        public ComputerPlayer(GameController gc)
        {
            gameController = gc;
            gameController.setAI(this);
        }

        public void PlaceMove(Tile[,] t)
        {
            tiles = t;
            hasMove = false;
            int remainingMoves = CountEmptySlots();
            if (remainingMoves >= 8)
                DoStartingStrategy();
            else if (remainingMoves >= 2)
                EnsureCatsGame();
            else
                PlaceLastPiece();

            gameController.PlaceMove(myMove.X, myMove.Y);
             
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
            if (hasMove)
                return;                  
            BlockVerticalMoves();
            if (hasMove)
                return;                    
            BlockFirstDiagonal();
            if (hasMove)
                return;
            BlockSecondDiagonal();
            if (hasMove)
                return;
            PlaceLastPiece();
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
            for(int i = 0; i < rows.Length; i++)
            {
                if(rows[i] == 2 )
                {
                    PlaceMoveInRow(i);
                    break;
                }
            }
        }

        private void PlaceMoveInRow(int row)
        {
            foreach(Point p in cLocations)
            {
                if(p.X == row)
                {
                    myMove = p;
                    hasMove = true;
                    break;
                }
            }
        }

        private void BlockVerticalMoves()
        {
            int[] columns = new int[3];
            foreach(Point p in xLocations)
            {
                columns[p.Y]++;
            }
            for (int i = 0; i < columns.Length; i++)
            {
                if (columns[i] == 2)
                {
                    PlaceMoveInColumn(i);
                }
            }
        }

        private void PlaceMoveInColumn(int column)
        {
            foreach(Point p in cLocations)
            {
                if(p.Y == column)
                {
                    myMove = p;
                    hasMove = true;
                    break;
                }
            }
        }

        private void BlockFirstDiagonal()
        {
            int counter = 0;
            foreach(Point p in xLocations)
            {
                if(p.X == 0 && p.Y == 0)
                {
                    counter++;
                }
                if(p.X == 1 && p.Y == 1)
                {
                    counter++;
                }
                if(p.X == 2 && p.Y == 2)
                {
                    counter++;
                }
            }
            if(counter == 2)
            {
                PlaceMoveInFirstDiagonal();
            }
        }

        private void PlaceMoveInFirstDiagonal()
        {
            foreach (Point p in cLocations)
            {
                if (p.X == 0 && p.Y == 0)
                {
                    myMove = p;
                    hasMove = true;
                    break;
                }
                if (p.X == 1 && p.Y == 1)
                {
                    myMove = p;
                    hasMove = true;
                    break;
                }
                if (p.X == 2 && p.Y == 2)
                {
                    myMove = p;
                    hasMove = true;
                    break;
                }
            }
        }

        private void BlockSecondDiagonal()
        {
            int counter = 0;
            foreach (Point p in xLocations)
            {
                if (p.X == 2 && p.Y == 0)
                {
                    counter++;
                }
                if (p.X == 1 && p.Y == 1)
                {
                    counter++;
                }
                if (p.X == 0 && p.Y == 2)
                {
                    counter++;
                }
            }
            if (counter == 2)
            {
                PlaceMoveInSecondDiagonal();
            }
        }

        private void PlaceMoveInSecondDiagonal()
        {
            foreach(Point p in cLocations)
            {
                if(p.X == 2 && p.Y == 0)
                {
                    myMove = p;
                    hasMove = true;
                    break;
                }
                if(p.X == 1 && p.Y == 1)
                {
                    myMove = p;
                    hasMove = true;
                    break;
                }
                if(p.X == 0 && p.Y == 2)
                {
                    myMove = p;
                    hasMove = true;
                    break;
                }
            }
        }

        private void PlaceLastPiece()
        {
            foreach(Point p in cLocations)
            {
                myMove = p;
                hasMove = true;
                break;
            }

        }



    }
}
