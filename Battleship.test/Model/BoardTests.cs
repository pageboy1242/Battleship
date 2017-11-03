using Battleship.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleship.test.Model
{
    [TestClass]
    public class BoardTests
    {
        private readonly string _boardString;

        private string _boardStringWithBattleShip1;

        [DataTestMethod]
        [DataRow(1, 1, MyBattleship.ShipDirection.Up, false)]
        [DataRow(8, 8, MyBattleship.ShipDirection.Down, false)]
        [DataRow(5, 2, MyBattleship.ShipDirection.Up, false)]
        [DataRow(5, 7, MyBattleship.ShipDirection.Down, false)]
        [DataRow(2, 1, MyBattleship.ShipDirection.Left, false)]
        [DataRow(7, 8, MyBattleship.ShipDirection.Right, false)]
        public void Board_TestPlaceBattleShip_InvalidLocation(int x, int y, MyBattleship.ShipDirection shipDirection,
            bool result)
        {
            var board = new Board();

            Assert.AreEqual(result, board.PlaceBattleShip(new MyBattleship(x, y, shipDirection)));
        }

        [DataTestMethod]
        [DataRow(1, 1, MyBattleship.ShipDirection.Down, true)]
        [DataRow(1, 1, MyBattleship.ShipDirection.Right, true)]
        [DataRow(8, 8, MyBattleship.ShipDirection.Up, true)]
        [DataRow(8, 8, MyBattleship.ShipDirection.Left, true)]
        [DataRow(1, 8, MyBattleship.ShipDirection.Up, true)]
        [DataRow(5, 7, MyBattleship.ShipDirection.Left, true)]
        [DataRow(8, 1, MyBattleship.ShipDirection.Left, true)]
        [DataRow(7, 5, MyBattleship.ShipDirection.Down, true)]
        public void Board_TestPlaceBattleShip_ValidLocation(int x, int y, MyBattleship.ShipDirection shipDirection,
            bool result)
        {
            var board = new Board();
            var battleShip = new MyBattleship(x, y, shipDirection);

            Assert.AreEqual(result, board.PlaceBattleShip(battleShip));
            Assert.AreSame(battleShip, board.Battleship);
        }

        [DataTestMethod]
        [DataRow(3, 4, true)]
        [DataRow(5, 3, false)]
        [DataRow(3, 5, true)]
        public void Board_TestIsHitRegistersValidHitsAndMisses(int x, int y, bool result)
        {
            var board = new Board();
            var battleShip = new MyBattleship(3, 3, MyBattleship.ShipDirection.Down);
            board.PlaceBattleShip(battleShip);

            Assert.AreEqual(result, board.IsHit(x, y));
        }
    }
}