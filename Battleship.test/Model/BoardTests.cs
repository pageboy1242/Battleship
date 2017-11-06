using Battleship.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleship.test.Model
{
    [TestClass]
    public class BoardTests
    {
        private readonly Board _board;

        private readonly string _boardString;
        private readonly string _boardStringWithBattleShip1;
        private readonly string _boardStringWithBattleShipWithHits1;

        public BoardTests()
        {
            _board = new Board();

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
            var placement = new ShipPlacement(ShipDirection.Left, new Coordinates(3, 1));
            var battleShip = new Ship(3, "My Battleship");

            Assert.IsTrue(board.PlaceBattleShip(battleShip, placement, out var message));
            Assert.IsTrue(message.Length == 0);
            Assert.AreEqual(_boardStringWithBattleShip1, board.ToString());
        }

        [TestMethod]
        public void Board_TestDisplaysHits()
        {
            var board = new Board();
            var placement = new ShipPlacement(ShipDirection.Left, new Coordinates(3, 1));
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

        [DataTestMethod]
        [DataRow(1, 1, ShipDirection.Up, false)]
        [DataRow(8, 8, ShipDirection.Down, false)]
        [DataRow(5, 2, ShipDirection.Up, false)]
        [DataRow(5, 7, ShipDirection.Down, false)]
        [DataRow(2, 1, ShipDirection.Left, false)]
        [DataRow(7, 8, ShipDirection.Right, false)]
        public void Board_TestPlaceBattleShip_InvalidLocation(int x, int y, ShipDirection shipDirection,
            bool result)
        {
            var placement = new ShipPlacement(shipDirection, new Coordinates(x, y));
            Assert.AreEqual(result, _board.PlaceBattleShip(new Ship(3, "My Battleship"), placement, out var message));
            Assert.IsTrue(message.Length > 0);
        }

        [DataTestMethod]
        [DataRow(1, 1, ShipDirection.Down, true)]
        [DataRow(1, 1, ShipDirection.Right, true)]
        [DataRow(8, 8, ShipDirection.Up, true)]
        [DataRow(8, 8, ShipDirection.Left, true)]
        [DataRow(1, 8, ShipDirection.Up, true)]
        [DataRow(5, 7, ShipDirection.Left, true)]
        [DataRow(8, 1, ShipDirection.Left, true)]
        [DataRow(7, 5, ShipDirection.Down, true)]
        public void Board_TestPlaceBattleShip_ValidLocation(int x, int y, ShipDirection shipDirection,
            bool result)
        {
            var placement = new ShipPlacement(shipDirection, new Coordinates(x, y));
            var battleShip = new Ship(3, "My Battleship");

            Assert.AreEqual(result, _board.PlaceBattleShip(battleShip, placement, out var message));
            Assert.AreSame(battleShip, _board.Battleship);
            Assert.IsTrue(message.Length == 0);
        }

        [DataTestMethod]
        [DataRow(3, 4, true)]
        [DataRow(5, 3, false)]
        [DataRow(3, 5, true)]
        public void Board_TestIsHitRegistersValidHitsAndMisses(int x, int y, bool result)
        {
            var placement = new ShipPlacement(ShipDirection.Down, new Coordinates(3, 3));
            var battleShip = new Ship(3, "My Battleship");
            _board.PlaceBattleShip(battleShip, placement, out var message);
            Assert.IsTrue(message.Length == 0);
            Assert.AreEqual(result, _board.ApplyShot(x, y));
        }

        [DataTestMethod]
        [DataRow(-1, 1, ShipDirection.Up)]
        [DataRow(9, 1, ShipDirection.Up)]
        [DataRow(1, -1, ShipDirection.Up)]
        [DataRow(1, 9, ShipDirection.Up)]
        public void Board_Placement_XYCoordRange_Validation(int x, int y, ShipDirection shipDirection)
        {
            var battleShip = new Ship(3, "My Battleship");
            var result = _board.PlaceBattleShip(battleShip, new ShipPlacement(shipDirection, new Coordinates(x, y)), out var message);

            Assert.IsFalse(result);
            Assert.IsTrue(message.Length > 0);
        }
    }
}