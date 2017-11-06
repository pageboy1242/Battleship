using System;
using System.Collections.Generic;
using System.Text;
using Battleship.Interfaces;

namespace Battleship.Model
{
    public class Player
    {
        private string _playerName;
        private Board _board;

        private readonly IConsoleWriter _consoleWriter;

        public Player(string playerName, IConsoleWriter consoleWriter)
        {
            _playerName = playerName;
            _board = new Board();

            _consoleWriter = consoleWriter;
        }

        public string PlayerName => _playerName;

        public Board Board => _board;

        /// <summary>
        /// Method to setup the player's board and allow player to place their battleship
        /// </summary>
        /// <param name="playerName"></param>
        /// <param name="playerBoard"></param>
        public void SetupBoard()
        {
            _consoleWriter.WriteLine($"--- {PlayerName} ---");
            _consoleWriter.WriteLine("Enter the coordinates of the stern (rear) of your battleship and the direction it is pointing");
            _consoleWriter.WriteLine("Coordinates are specified as Column letter (A - H), then Row number (1 - 8).");
            _consoleWriter.WriteLine("Direction can be U, D, L, R (Up, Down, Left, Right)");
            _consoleWriter.WriteLine("For example 'F 4 R'");

            _consoleWriter.Write(Board.ToString());

            var battleShip = new Ship(3, "My Battleship");

            var message = "";
            ShipPlacement placement;

            do
            {
                if (message.Length > 0)
                {
                    _consoleWriter.WriteLine(message);
                }
                string input;
                do
                {
                    if (message.Length > 0)
                        _consoleWriter.WriteLine(message);

                    _consoleWriter.Write("Coordinates: ");
                    input = _consoleWriter.ReadLine();
                } while ((placement = InputHandler.ConvertInputToShipPlacement(input, out message)) == null);

            } while (!Board.PlaceBattleShip(battleShip, placement, out message));

            _consoleWriter.Write(Board.ToString());
        }

        /// <summary>
        /// Repesents a Player's turn
        /// </summary>
        /// <param name="playerName"></param>
        /// <param name="opposingPlayerBoard"></param>
        public void TakeTurn(Board opposingPlayerBoard)
        {
            _consoleWriter.WriteLine($"--- {PlayerName} ---");
            _consoleWriter.WriteLine("Enter Shot Coordinates (Eg. 'D 2')");

            var shotCoords = GetShotCoords();

            _consoleWriter.WriteLine(opposingPlayerBoard.ApplyShot(shotCoords.X, shotCoords.Y) ? "Hit!" : "Miss!");

            _consoleWriter.WriteLine(opposingPlayerBoard.ToString());
        }
        /// <summary>
        /// Reads coords from console and converts them to a coordinate object
        /// </summary>
        /// <returns></returns>
        public Coordinates GetShotCoords()
        {
            string message = "";
            string input;

            Coordinates shotCoords;
            do
            {
                if (message.Length > 0)
                    _consoleWriter.WriteLine(message);

                _consoleWriter.Write("Coordinates: ");
                input = _consoleWriter.ReadLine();
            } while ((shotCoords = InputHandler.ConvertInputToCoordinates(input, out message)) == null);

            return shotCoords;
        }
    }
}
