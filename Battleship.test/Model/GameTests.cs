using Battleship.Interfaces;
using Battleship.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Battleship.test.Model
{
    [TestClass]
    public class GameTests
    {
        private readonly Mock<IConsoleWriter> _mockConsole = new Mock<IConsoleWriter>();
        private Game _game;

       

        [TestInitialize]
        public void SetUp()
        {
            _game = new Game(_mockConsole.Object);
        }

        [TestMethod]
        public void WelcomeMessage_ShouldDisplayWelcomeMessage()
        {
            _game.WelcomeMessage();

            _mockConsole.Verify(c => c.Clear());
            _mockConsole.Verify(c => c.WriteLine("Welcome to Battleship\n"));
        }
        
        [TestMethod]
        public void GameStart_ShouldDisplayGameMessage_WhenPlayer1Wins()
        {
            _mockConsole.SetupSequence(c => c.ReadLine())
                .Returns("H 1 L")
                .Returns("H 1 D")
                .Returns("A 1") // Miss
                .Returns("A 1") // Miss
                .Returns("H 1") // Hit
                .Returns("H 1") // Hit
                .Returns("H 2") // Hit
                .Returns("G 1") // Hit
                .Returns("H 3"); // Hit

            _game.GameStart();

            _mockConsole.Verify(c => c.WriteLine("Player 2 yells 'You sank my battleship!!'"));
        }

        [TestMethod]
        public void GameStart_ShouldDisplayGameMessage_WhenPlayer2Wins()
        {
            _mockConsole.SetupSequence(c => c.ReadLine())
                .Returns("A 1 D")
                .Returns("D 8 R")
                .Returns("A 1") // Miss
                .Returns("A 1") // Hit
                .Returns("D 8") // Hit
                .Returns("A 2") // Hit
                .Returns("D 7") // Miss
                .Returns("A 3"); // Hit

            _game.GameStart();

            _mockConsole.Verify(c => c.WriteLine("Player 1 yells 'You sank my battleship!!'"));
        }
    }
}