using System;
using System.Collections.Generic;
using System.Text;
using Battleship.Interfaces;
using Battleship.test.Model;

namespace Battleship.Model
{
    public class Game
    {
        private Board _player1Board;
        private Board _player2Board;

        private readonly IConsoleWriter _consoleWriter;

        public Game(IConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter;
        }

        public void GameStart()
        {
            _player1Board = new Board();
            _player2Board = new Board();
            
            WelcomeMessage();

            PlayerBoardSetup("Player 1", _player1Board);

            PlayerBoardSetup("Player 2", _player2Board);

            while (true)
            {
                PlayerTakeTurn("Player 1", _player2Board);
                if (_player2Board.IsAllShipsSunk())
                {
                    _consoleWriter.WriteLine("Player 2 yells 'You sank my battleship!!");
                    break;
                }

                PlayerTakeTurn("Player 2", _player1Board);
                if (_player1Board.IsAllShipsSunk())
                {
                    _consoleWriter.WriteLine("Player 1 yells 'You sank my battleship!!");
                    break;
                }
            }
        }

        public void WelcomeMessage()
        {
            _consoleWriter.Clear();
            _consoleWriter.WriteLine("Welcome to Battleship\n");
        }

        public void PlayerBoardSetup(string playerName, Board playerBoard)
        {
            _consoleWriter.WriteLine($"--- {playerName} ---");
            _consoleWriter.WriteLine("Enter the coordinates of the stern (rear) of your battleship and the direction it is pointing");
            _consoleWriter.WriteLine("Coordinates are specified as Column letter (A - H), then Row number (1 - 8).");
            _consoleWriter.WriteLine("Direction can be U, D, L, R (Up, Down, Left, Right)");
            _consoleWriter.WriteLine("For example 'F 4 R'");

            var boardOutputter = new BoardOutputter(playerBoard);
            _consoleWriter.Write(boardOutputter.ToString());
            
            var battleShip = new Ship(3, "My Battleship");

            var message = "";
            ShipPlacement placement;

            do
            {
                if (message.Length > 0)
                {
                    _consoleWriter.WriteLine(message);    
                }
                _consoleWriter.Write("Coordinates: ");
                var input = Console.ReadLine();
                while ((placement = InputHandler.ConvertInputToShipPlacement(input, out message)) == null)
                {
                    _consoleWriter.WriteLine(message);
                    _consoleWriter.Write("Coordinates: ");
                    input = Console.ReadLine();
                }

            } while (!playerBoard.PlaceBattleShip(battleShip, placement, out message));

            _consoleWriter.Write(playerBoard.ToString());
        }

        public void PlayerTakeTurn(string playerName, Board opposingPlayerBoard)
        {
            _consoleWriter.WriteLine($"--- {playerName} ---");
            _consoleWriter.WriteLine("Enter Shot Coordinates (Eg. 'D 2'");
            _consoleWriter.Write("Coordinates: ");
            var input = Console.ReadLine();

            Coordinates shotCoords;
            while ((shotCoords = InputHandler.ConvertInputToCoordinates(input, out var message)) == null)
            {
                _consoleWriter.WriteLine(message);
                _consoleWriter.Write("Coordinates: ");
                input = Console.ReadLine();
            }

            if (opposingPlayerBoard.IsHit(shotCoords.X, shotCoords.Y))
            {
                _consoleWriter.WriteLine("Hit!");
            }
            else
            {
                _consoleWriter.WriteLine("Miss!");
            }

            _consoleWriter.WriteLine(opposingPlayerBoard.ToString());
        }
    }
}
