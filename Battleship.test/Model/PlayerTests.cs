using System;
using System.Collections.Generic;
using System.Text;
using Battleship.Interfaces;
using Battleship.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Battleship.test.Model
{
    [TestClass]
    public class PlayerTests
    {
        private readonly Mock<IConsoleWriter> _mockConsole = new Mock<IConsoleWriter>();
        private Player _testPlayer;
        
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
            _testPlayer = new Player("Test Player", _mockConsole.Object);
        }

        [TestMethod]
        public void TestConstructor()
        {
            Assert.AreEqual("Test Player", _testPlayer.PlayerName);
            Assert.IsNotNull(_testPlayer.Board);
        }

        [TestMethod]
        public void TestPlayerSetup()
        {
            _mockConsole.Setup(c => c.ReadLine()).Returns("F 8 R");

            _testPlayer.SetupBoard();
            
            _mockConsole.Verify(c => c.Write(_boardStringWithBattleShip1));
        }

        [TestMethod]
        public void TestPlayerSetupInputInvalid()
        {
            _mockConsole.SetupSequence(c => c.ReadLine())
                .Returns("H 9 L")
                .Returns("F 8 R");

            _testPlayer.SetupBoard();
           
            _mockConsole.Verify(c => c.WriteLine("Please enter coordinates using the following rules [A-H] [1-8] [U,D,L,R] (Eg. 'B 2 R')."));
            _mockConsole.Verify(c => c.Write(_boardStringWithBattleShip1));
        }

        [TestMethod]
        public void TestGetShotCoordsLoopsForValidInput()
        {
            _mockConsole.SetupSequence(c => c.ReadLine())
                .Returns("ff")
                .Returns("A1")
                .Returns("A 1");

            var shotCoords = _testPlayer.GetShotCoords();

            _mockConsole.Verify(c =>
                c.WriteLine("Please enter coordinates using the following rules [A-H] [1-8] (Eg. 'B 2')."));

            Assert.AreEqual(1, shotCoords.X);
            Assert.AreEqual(1, shotCoords.Y);
        }
    }
}
