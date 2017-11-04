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
                    break;

                PlayerTakeTurn("Player 2", _player1Board);
                if (_player1Board.IsAllShipsSunk())
                    break;
            }
        }

        public void WelcomeMessage()
        {
            Console.Clear();
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
            _consoleWriter.Write("Coordinates: ");
            var input = Console.ReadLine();

            var placement = InputHandler.ConvertInputToShipPlacement(input);
            var battleShip = new Ship(3, "My Battleship");

            playerBoard.PlaceBattleShip(battleShip, placement);

            _consoleWriter.Write(playerBoard.ToString());
        }

        public void PlayerTakeTurn(string playerName, Board opposingPlayerBoard)
        {
            _consoleWriter.WriteLine($"--- {playerName} ---");
            _consoleWriter.WriteLine("Enter Shot Coordinates (Eg. 'D 2'");

            var input = Console.ReadLine();

            var shotCoords = InputHandler.ConvertInputToPoint(input);
            opposingPlayerBoard.IsHit(shotCoords.X, shotCoords.Y);

            _consoleWriter.WriteLine(opposingPlayerBoard.ToString());
        }
    }
}
