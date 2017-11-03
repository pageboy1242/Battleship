using System;
using System.Drawing;
using System.Linq;

namespace Battleship.Model
{
    public class MyBattleship
    {
        public enum ShipDirection
        {
            Up,
            Down,
            Left,
            Right
        };

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="shipDirection"></param>
        public MyBattleship(int x, int y, ShipDirection shipDirection)
        {
            // TODO: This is board specific and not ship specific, move to place method
            if (x < 1 || x > 8)
            {
                throw new ArgumentOutOfRangeException(nameof(x), "x parameter must be between 1 and 8");
            }

            if (y < 1 || y > 8)
            {
                throw new ArgumentOutOfRangeException(nameof(x), "x parameter must be between 1 and 8");
            }

            X = x;
            Y = y;
            Direction = shipDirection;

            CalculateCoords();
        }

        public int X { get; }

        public int Y { get; }

        public const int Size = 3;

        private Point[] _coords;

        public ShipDirection Direction { get; }

        /// <summary>
        /// Checks if the supplied coordinate overlaps with the location of the battleship
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsCoordInShip(int x, int y)
        {
            return _coords.Any(t => t.X == x && t.Y == y);
        }

        private void CalculateCoords()
        {
            _coords = new Point[Size];

            // Initial Point denotes the Stern
            _coords[0].X = X;
            _coords[0].Y = Y;

            switch (Direction)
            {
                case ShipDirection.Up:
                    _coords[1].X = X;
                    _coords[1].Y = Y - 1;
                    _coords[2].X = X;
                    _coords[2].Y = Y - 2;
                    break;
                case ShipDirection.Down:
                    _coords[1].X = X;
                    _coords[1].Y = Y + 1;
                    _coords[2].X = X;
                    _coords[2].Y = Y + 2;
                    break;
                case ShipDirection.Left:
                    _coords[1].X = X - 1;
                    _coords[1].Y = Y;
                    _coords[2].X = X - 2;
                    _coords[2].Y = Y;
                    break;
                case ShipDirection.Right:
                    _coords[1].X = X + 1;
                    _coords[1].Y = Y;
                    _coords[2].X = X + 2;
                    _coords[2].Y = Y;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
