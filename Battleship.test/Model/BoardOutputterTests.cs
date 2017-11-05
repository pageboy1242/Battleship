using Battleship.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleship.test.Model
{
    [TestClass]
    public class BoardOutputterTests
    {
        private readonly string _boardString;
        private readonly string _boardStringWithBattleShip1;
        private readonly string _boardStringWithBattleShipWithHits1;
       
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

            _boardStringWithBattleShipWithHits1 =
                "\t \tA\tB\tC\tD\tE\tF\tG\tH\n" +
                "\t1\tX\tO\tO\t \t \t \t \tX\n" +
                "\t2\t \t \t \t \t \t \t \t \n" +
                "\t3\t \t \t \tX\t \t \t \t \n" +
                "\t4\t \t \t \t \t \t \t \t \n" +
                "\t5\t \t \t \t \t \t \t \t \n" +
                "\t6\t \t \t \t \t \t \t \t \n" +
                "\t7\t \t \t \t \t \t \tX\t \n" +
                "\t8\tX\t \t \t \t \t \t \tX\n";
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
            var placement = new ShipPlacement(Ship.ShipDirection.Left, new Coordinates(3, 1));
            var battleShip = new Ship(3, "My Battleship");
            
            Assert.IsTrue(board.PlaceBattleShip(battleShip, placement, out var message));
            Assert.IsTrue(message.Length == 0);
            Assert.AreEqual(_boardStringWithBattleShip1, board.ToString());
        }

        [TestMethod]
        public void Board_TestDisplaysHits()
        {
            var board = new Board();
            var placement = new ShipPlacement(Ship.ShipDirection.Left, new Coordinates(3, 1));
            var battleShip = new Ship(3, "My Battleship");
            
            board.PlaceBattleShip(battleShip, placement, out var message);

            Assert.IsTrue(message.Length == 0);

            board.ApplyShot(1, 1);
            board.ApplyShot(4, 3);
            board.ApplyShot(8, 1);
            board.ApplyShot(7, 7);
            board.ApplyShot(1, 8);
            board.ApplyShot(8, 8);

            Assert.AreEqual(_boardStringWithBattleShipWithHits1, board.ToString());
        }
    }
}
