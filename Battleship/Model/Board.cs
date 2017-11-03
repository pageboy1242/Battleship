using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Battleship.Model
{
    public class Board
    {
        // TODO: Need something like this, but do I make it 8 or 9 or do I need more constants
        public const int BoardHeight = 9;
        public const int BoardWidth = 9;

        private readonly char[,] _grid;

        private MyBattleship _battleship;

        public MyBattleship Battleship => _battleship;

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
        /// Attempts to place a myBattleship on the board
        /// </summary>
        /// <param name="myBattleship"></param>
        /// <returns></returns>
        public bool PlaceBattleShip(MyBattleship myBattleship)
        {
            if (myBattleship.X < MyBattleship.Size && myBattleship.Direction == MyBattleship.ShipDirection.Left)
            {
                return false;
            }

            if (myBattleship.Y < MyBattleship.Size && myBattleship.Direction == MyBattleship.ShipDirection.Up)
            {
                return false;
            }

            if (myBattleship.X > (BoardWidth - MyBattleship.Size) && myBattleship.Direction == MyBattleship.ShipDirection.Right)
            {
                return false;
            }

            if (myBattleship.Y > (BoardHeight - MyBattleship.Size) && myBattleship.Direction == MyBattleship.ShipDirection.Down)
            {
                return false;
            }

            _battleship = myBattleship;

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
                return true;
            return false;
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
