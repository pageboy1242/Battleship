using System;
using System.Linq;

namespace Battleship.Model
{
    public class Ship
    {
        public Ship(int size, string name)
        {
            Size = size;
            Name = name;
            _hits = new bool[Size];
        }

        public int Size { get; }

        public string Name { get; }

        private Coordinates[] _coords;

        private readonly bool[] _hits;
        
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

        /// <summary>
        /// Saves a shot to the board so it can be displayed
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool ApplyShot(int x, int y)
        {
            if(IsCoordInShip(x, y))
            {
                for (var i = 0; i < Size; i++)
                {
                    if (_coords[i].X == x && _coords[i].Y == y)
                    {
                        _hits[i] = true;
                    }
                }
                return true;
            }
            return false;
        }
        /// <summary>
        /// Calculates the real board coordinates of a placed battleship.  Needed to determine if a ship is sunk.
        /// </summary>
        /// <param name="placement"></param>
        public void CalculateCoords(ShipPlacement placement)
        {
            var x = placement.SternPoint.X;
            var y = placement.SternPoint.Y;

            _coords = new Coordinates[Size];

            // Initial Point denotes the Stern
            _coords[0] = new Coordinates(x , y);

            //TODO: Convert to loops to support multiple ships
            switch (placement.Direction)
            {
                case ShipDirection.Up:
                    _coords[1] = new Coordinates(x, y - 1);
                    _coords[2] = new Coordinates(x, y - 2);
                    break;
                case ShipDirection.Down:
                    _coords[1] = new Coordinates(x, y + 1);
                    _coords[2] = new Coordinates(x, y + 2);
                    break;
                case ShipDirection.Left:
                    _coords[1] = new Coordinates(x - 1, y);
                    _coords[2] = new Coordinates(x - 2, y);
                    break;
                case ShipDirection.Right:
                    _coords[1] = new Coordinates(x + 1, y);
                    _coords[2] = new Coordinates(x + 2, y);
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
            return _hits.Aggregate(true, (current, hit) => current && hit);
        }
    }
}
