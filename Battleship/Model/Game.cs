using Battleship.Interfaces;

namespace Battleship.Model
{
    public class Game
    {
        private Player _player1;
        private Player _player2;

        private readonly IConsoleWriter _consoleWriter;

        public Game(IConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter;

            _player1 = new Player("Player 1", _consoleWriter);
            _player2 = new Player("Player 2", _consoleWriter);
        }

        public void GameStart()
        {
            WelcomeMessage();

            _player1.SetupBoard();
            _player2.SetupBoard();

           while (true)
            {
                _player1.TakeTurn(_player2.Board);
                if (_player2.Board.IsAllShipsSunk())
                {
                    _consoleWriter.WriteLine("Player 2 yells 'You sank my battleship!!'");
                    break;
                }

                _player2.TakeTurn(_player1.Board);
                if (_player1.Board.IsAllShipsSunk())
                {
                    _consoleWriter.WriteLine("Player 1 yells 'You sank my battleship!!'");
                    break;
                }
            }
        }

        public void WelcomeMessage()
        {
            _consoleWriter.Clear();
            _consoleWriter.WriteLine("Welcome to Battleship\n");
        }
        
        
    }
}
