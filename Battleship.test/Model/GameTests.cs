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

        private readonly string _boardStringWithBattleShip1 =
            "\t \tA\tB\tC\tD\tE\tF\tG\tH\n" +
            "\t1\t \t \t \t \t \t \t \t \n" +
            "\t2\t \t \t \t \t \t \t \t \n" +
            "\t3\t \t \t \t \t \t \t \t \n" +
            "\t4\t \t \t \t \t \t \t \t \n" +
            "\t5\t \t \t \t \t \t \t \t \n" +
            "\t6\t \t \t \t \t \t \t \t \n" +
            "\t7\t \t \t \t \t \t \t \t \n" +
            "\t8\t \t \t \t \t \tO\tO\tO\n";

        [TestInitialize]
        public void SetUp()
        {
            _game = new Game(_mockConsole.Object);
        }

        [TestMethod]
        public void Game_TestWelcomeMessage()
        {
            _game.WelcomeMessage();

            _mockConsole.Verify(c => c.Clear());
            _mockConsole.Verify(c => c.WriteLine("Welcome to Battleship\n"));
        }

        [TestMethod]
        public void Game_TestPlayerSetup()
        {
            _mockConsole.Setup(c => c.ReadLine()).Returns("F 8 R");

            _game.PlayerBoardSetup("Test Player", new Board());

            _mockConsole.Verify(c => c.Write(_boardStringWithBattleShip1));
        }

        [TestMethod]
        public void Game_TestPlayerSetupInputInvalid()
        {
            _mockConsole.SetupSequence(c => c.ReadLine())
                .Returns("H 9 L")
                .Returns("F 8 R");

            _game.PlayerBoardSetup("Test Player", new Board());

            _mockConsole.Verify(c => c.WriteLine("Please enter coordinates using the following rules [A-H] [1-8] [U,D,L,R] (Eg. 'B 2 R')."));
            _mockConsole.Verify(c => c.Write(_boardStringWithBattleShip1));
        }

        [TestMethod]
        public void Game_TestGameStart_Player1Wins()
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
        public void Game_TestGameStart_Player2Wins()
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

        [TestMethod]
        public void Game_TestGetShotCoordsLoopsForValidInput()
        {
            _mockConsole.SetupSequence(c => c.ReadLine())
                .Returns("ff")
                .Returns("A1")
                .Returns("A 1");

           var shotCoords = _game.GetShotCoords();

            _mockConsole.Verify(c =>
                c.WriteLine("Please enter coordinates using the following rules [A-H] [1-8] (Eg. 'B 2')."));

            Assert.AreEqual(1, shotCoords.X);
            Assert.AreEqual(1, shotCoords.Y);
        }
    }
}