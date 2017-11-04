using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Battleship.Model
{
    public class Board
    {
        public const int BoardHeight = 9;
        public const int BoardWidth = 9;

        private readonly char[,] _grid;

        private Ship _battleship;

        public Ship Battleship => _battleship;

        /// <summary>
        /// Creates and Initializes the player's board
        /// </summary>
        public Board()
        {
            _grid = new char[BoardWidth, BoardHeight];

            for (int x = 0; x < BoardWidth; x++)
            {
                for (int y = 0; y < BoardHeight; y++)
                {
                    if (y == 0 && x > 0)
                    {
                        _grid[x, y] = (char)(64 + x); // Column Headings
                    }
                    else if (x == 0 && y > 0)
                    {
                        _grid[x, y] = (char)(48 + y); // Row Headings
                    }
                    else
                    {
                        _grid[x, y] = ' ';
                    }
                }
            }
        }

        public char[,] Grid => _grid;

        /// <summary>
        /// Attempts to place a ship on the board
        /// </summary>
        /// <param name="ship"></param>
        /// <returns></returns>
        public bool PlaceBattleShip(Ship ship, ShipPlacement placement)
        {
            // Ensure Coordinates are within range
            if (placement.SternPoint.X < 1 || placement.SternPoint.X >= BoardWidth)
            {
                throw new ArgumentOutOfRangeException(nameof(placement), "x parameter must be between 1 and 8");
            }

            if (placement.SternPoint.Y < 1 || placement.SternPoint.Y >= BoardHeight)
            {
                throw new ArgumentOutOfRangeException(nameof(placement), "x parameter must be between 1 and 8");
            }

            // Ensure Ship direction is not outside the range of the board
            if (placement.SternPoint.X < ship.Size && placement.Direction == Ship.ShipDirection.Left)
            {
                return false;
            }

            if (placement.SternPoint.Y < ship.Size && placement.Direction == Ship.ShipDirection.Up)
            {
                return false;
            }

            if (placement.SternPoint.X > (BoardWidth - ship.Size) && placement.Direction == Ship.ShipDirection.Right)
            {
                return false;
            }

            if (placement.SternPoint.Y > (BoardHeight - ship.Size) && placement.Direction == Ship.ShipDirection.Down)
            {
                return false;
            }

            ship.CalculateCoords(placement);

            _battleship = ship;

            return true;
        }

        /// <summary>
        /// IsHit represents a shot from the other player
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>true if was a hit, false otherwise</returns>
        public bool IsHit(int x, int y)
        {
            // TODO: This is 2 actions
            // Capture the shot on the board
            _grid[x, y] = 'X';

            if (_battleship.IsCoordInShip(x, y))
            {
                _battleship.TryShot(x, y);
                return true;
            }
               
            return false;
        }

        public bool IsAllShipsSunk()
        {
            return Battleship.IsSunk();
        }

        /// <summary>
        /// Convert the game grid to a console printable board
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            for (var y = 0; y < BoardHeight; y++)
            {
                for (var x = 0; x < BoardWidth; x++)
                {
                    sb.Append("\t");
                    if (_battleship != null && _battleship.IsCoordInShip(x, y))
                    {
                        if (_grid[x, y] == 'X')
                        {
                            sb.Append('X');

                        }
                        else
                        {
                            sb.Append('O');
                        }
                    }
                    else
                    {
                        sb.Append(_grid[x, y]);
                    }
                }
                sb.Append("\n");

            }
            return sb.ToString();
        }
    }
}
