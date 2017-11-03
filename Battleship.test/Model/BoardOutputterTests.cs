using System;
using System.Collections.Generic;
using System.Text;
using Battleship.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleship.test.Model
{
    [TestClass]
    public class BoardOutputterTests
    {
        private string _boardString;
        private string _boardStringWithBattleShip1;

        public BoardOutputterTests()
        {
            // TODO: Stringbuilder
            _boardString = "\t \tA\tB\tC\tD\tE\tF\tG\tH\n" +
                           "\t1\t \t \t \t \t \t \t \t \n" +
                           "\t2\t \t \t \t \t \t \t \t \n" +
                           "\t3\t \t \t \t \t \t \t \t \n" +
                           "\t4\t \t \t \t \t \t \t \t \n" +
                           "\t5\t \t \t \t \t \t \t \t \n" +
                           "\t6\t \t \t \t \t \t \t \t \n" +
                           "\t7\t \t \t \t \t \t \t \t \n" +
                           "\t8\t \t \t \t \t \t \t \t \n";

            _boardStringWithBattleShip1 =
                "\t \tA\tB\tC\tD\tE\tF\tG\tH\n" +
                "\t1\tO\tO\tO\t \t \t \t \t \n" +
                "\t2\t \t \t \t \t \t \t \t \n" +
                "\t3\t \t \t \t \t \t \t \t \n" +
                "\t4\t \t \t \t \t \t \t \t \n" +
                "\t5\t \t \t \t \t \t \t \t \n" +
                "\t6\t \t \t \t \t \t \t \t \n" +
                "\t7\t \t \t \t \t \t \t \t \n" +
                "\t8\t \t \t \t \t \t \t \t \n";
        }

        [TestMethod]
        public void Board_TestInitializeBoard()
        {
            var board = new Board();

            Assert.AreEqual(_boardString, board.ToString());
        }

        [TestMethod]
        public void Board_TestDisplaysBattleShip()
        {
            var board = new Board();
            var battleShip = new MyBattleship(3, 1, MyBattleship.ShipDirection.Left);

            board.PlaceBattleShip(battleShip);

            Assert.AreEqual(_boardStringWithBattleShip1, board.ToString());
        }
    }
}
