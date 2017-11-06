using System;
using System.Text.RegularExpressions;

namespace Battleship.Model
{
    public static class InputHandler
    {
        /// <summary>
        /// Validates and converts user input into a placement object.  Returns a message if there is an error.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="message"></param>
        public static ShipPlacement ConvertInputToShipPlacement(string input, out string message)
        {
            message = "";
            // Validate input
            try
            {
                ValidatePlacementInput(input);
            }
            catch (ArgumentException e)
            {
                message = e.Message;
                return null;
            }

            var columnChar = input[0];
            var rowChar = input[2];
            var directionChar = input[4];

            // Convert the column to a X coordinate
            var x = columnChar - 64;
            var y = rowChar - 48;

            ShipDirection direction;

            switch (directionChar)
            {
                case 'U':
                    direction = ShipDirection.Up;
                    break;
                case 'D':
                    direction = ShipDirection.Down;
                    break;
                case 'L':
                    direction = ShipDirection.Left;
                    break;
                case 'R':
                    direction = ShipDirection.Right;
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
        private static void ValidatePlacementInput(string input)
        {
            // TODO: Build this dynamically based on the size of the board

            var match = Regex.Match(input, @"^[A-H] [1-8] [U,D,L,R]$");

            if (!match.Success)
            {
                throw new ArgumentException("Please enter coordinates using the following rules [A-H] [1-8] [U,D,L,R] (Eg. 'B 2 R').");
            }
        }
        /// <summary>
        /// Validates and converts user input into shot coordinates.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="message"></param>
        public static Coordinates ConvertInputToCoordinates(string input, out string message)
        {
            message = "";
            // Validate input
            try
            {
                ValidateCoordinateInput(input);
            }
            catch (ArgumentException e)
            {
                message = e.Message;
                return null;
            }
            var columnChar = input[0];
            var rowChar = input[2];

            var x = columnChar - 64;
            var y = rowChar - 48;

            return new Coordinates(x, y);
        }

        private static void ValidateCoordinateInput(string input)
        {
            var match = Regex.Match(input, @"^[A-H] [1-8]");

            if (!match.Success)
            {
                throw new ArgumentException(
                    "Please enter coordinates using the following rules [A-H] [1-8] (Eg. 'B 2').");
            }
        }
    }
}
