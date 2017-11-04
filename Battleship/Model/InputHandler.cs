using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Battleship.Model
{
    public static class InputHandler
    {
        public static ShipPlacement ConvertInputToShipPlacement(string input)
        {
            // Happy path scenario
            var columnChar = input[0];
            var rowChar = input[2];
            var directionChar = input[4];

            // Convert the column to a X coordinate
            var x = ((int)columnChar) - 64;
            var y = ((int)rowChar) - 48;

            Ship.ShipDirection direction;

            switch (directionChar)
            {
                case 'U':
                    direction = Ship.ShipDirection.Up;
                    break;
                case 'D':
                    direction = Ship.ShipDirection.Down;
                    break;
                case 'L':
                    direction = Ship.ShipDirection.Left;
                    break;
                case 'R':
                    direction = Ship.ShipDirection.Right;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(input), "Direction must be one of 'U','D','L', or 'R'");
            }

            return new ShipPlacement(direction, new Point(x, y));
        }

        public static Point ConvertInputToPoint(string input)
        {
            var columnChar = input[0];
            var rowChar = input[2];

            var x = columnChar - 64;
            var y = rowChar - 48;

            return new Point(x, y);
        }
    }
}
