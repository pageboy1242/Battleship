using System;
using System.Drawing;
using System.Linq;

namespace Battleship.Model
{
    public class Ship
    {
        public enum ShipDirection
        {
            Up,
            Down,
            Left,
            Right
        };

        public Ship(int size, string name)
        {
            Size = size;
            Name = name;
            hits = new bool[Size];
        }

        public int Size { get; }

        public string Name { get; }

        private Point[] _coords;

        private readonly bool[] hits;
        
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

        public bool ApplyShot(int x, int y)
        {
            if(IsCoordInShip(x, y))
            {
                for (var i = 0; i < Size; i++)
                {
                    if (_coords[i].X == x && _coords[i].Y == y)
                    {
                        hits[i] = true;
                    }
                }
                return true;
            }
            return false;
        }

        public void CalculateCoords(ShipPlacement placement)
        {
            var x = placement.SternPoint.X;
            var y = placement.SternPoint.Y;

            _coords = new Point[Size];

            // Initial Point denotes the Stern
            _coords[0].X = x;
            _coords[0].Y = y;

            //TODO: Convert to algebraic line functions?
            switch (placement.Direction)
            {
                case ShipDirection.Up:
                    _coords[1].X = x;
                    _coords[1].Y = y - 1;
                    _coords[2].X = x;
                    _coords[2].Y = y - 2;
                    break;
                case ShipDirection.Down:
                    _coords[1].X = x;
                    _coords[1].Y = y + 1;
                    _coords[2].X = x;
                    _coords[2].Y = y + 2;
                    break;
                case ShipDirection.Left:
                    _coords[1].X = x - 1;
                    _coords[1].Y = y;
                    _coords[2].X = x - 2;
                    _coords[2].Y = y;
                    break;
                case ShipDirection.Right:
                    _coords[1].X = x + 1;
                    _coords[1].Y = y;
                    _coords[2].X = x + 2;
                    _coords[2].Y = y;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        /// <summary>
        /// Indicates whether or not the ship has been sunk, I.e. has taken the maximum number of direct hits
        /// </summary>
        /// <returns></returns>
        public bool IsSunk()
        {
            return hits.Aggregate(true, (current, hit) => current && hit);
        }
    }
}
