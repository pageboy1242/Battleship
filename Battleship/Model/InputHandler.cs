using System;
using System.Text.RegularExpressions;

namespace Battleship.Model
{
    public static class InputHandler
    {
        public static ShipPlacement ConvertInputToShipPlacement(string input, out string message)
        {
            message = "";
            // Validate input
            var msg = ValidatePlacementInput(input);
            if (msg.Length != 0)
            {
                message = msg;
                return null;
            }

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

            return new ShipPlacement(direction, new Coordinates(x, y));
        }

        /// <summary>
        /// Validate the user input to place a ship ([A-H] [1-8] [U,D,L,R])
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string ValidatePlacementInput(string input)
        {
            var message = "";

            var regex = @"^[A-H] [1-8] [U,D,L,R]$";

            Match match = Regex.Match(input, regex);

            if (!match.Success)
            {
                message = "Please enter coordinates using the following rules [A-H] [1-8] [U,D,L,R] (Eg. 'B 2 R').";
            }

            return message;
        }

        public static Coordinates ConvertInputToCoordinates(string input, out string message)
        {
            message = "";
            // Validate input
            var msg = ValidateCoordinateInput(input);
            if (msg.Length != 0)
            {
                message = msg;
                return null;
            }

            var columnChar = input[0];
            var rowChar = input[2];

            var x = columnChar - 64;
            var y = rowChar - 48;

            return new Coordinates(x, y);
        }

        private static string ValidateCoordinateInput(string input)
        {
            var message = "";

            var regex = @"^[A-H] [1-8]";

            Match match = Regex.Match(input, regex);

            if (!match.Success)
            {
                message = "Please enter coordinates using the following rules [A-H] [1-8] (Eg. 'B 2').";
            }

            return message;
        }
    }
}
