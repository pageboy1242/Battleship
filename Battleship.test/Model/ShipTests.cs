using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Battleship.Model;
using Testable;

namespace Battleship.test.Model
{
    [TestClass]
    public class ShipTests
    {
        private Board testBoard;
        private Ship testShip;
        private ShipPlacement testPlacement;

        public ShipTests()
        {
            testShip = new Ship(3, "Battleship");   
        }

        [TestInitialize]
        public void Setup()
        {
            testBoard = new Board();
        }

        [DataTestMethod]
        [DataRow(3, 1, Ship.ShipDirection.Left, 1, 1, true)]
        [DataRow(3, 1, Ship.ShipDirection.Left, 3, 1, true)]
        [DataRow(3, 1, Ship.ShipDirection.Left, 2, 1, true)]
        [DataRow(3, 1, Ship.ShipDirection.Left, 4, 1, false)]
        [DataRow(3, 1, Ship.ShipDirection.Left, 1, 2, false)]
        [DataRow(3, 1, Ship.ShipDirection.Left, 3, 2, false)]
        public void Battleship_IsCoordInShip(int x, int y, Ship.ShipDirection direction, int i, int j, bool result)
        {
            var battleShip = new Ship(3, "My Battleship");

            var placement = new ShipPlacement(direction, new Point(x, y));
            testBoard.PlaceBattleShip(battleShip, placement);

            Assert.AreEqual(result, battleShip.IsCoordInShip(i, j));
        }

        [TestMethod]
        public void Battleship_IsSunkTest()
        {
            testPlacement = new ShipPlacement(Ship.ShipDirection.Down, new Point(6, 1));
            testBoard.PlaceBattleShip(testShip, testPlacement);

            // Verify ship is not sunk as no shots have been fired
            Assert.IsFalse(testBoard.Battleship.IsSunk());

            // Apply 3 direct hits
            Assert.IsTrue(testBoard.IsHit(6, 1));
            Assert.IsTrue(testBoard.IsHit(6, 2));
            Assert.IsTrue(testBoard.IsHit(6, 3));

            // Verify ship is sunk
            Assert.IsTrue(testBoard.Battleship.IsSunk());
        }

        [TestMethod]
        public void Ship_ApplyShot_VerifyValidAndInvalidShots()
        {
            testPlacement = new ShipPlacement(Ship.ShipDirection.Left, new Point(8, 6));
            testBoard.PlaceBattleShip(testShip, testPlacement);

            // Valid hit coords would be (8,6),(7,6),(6,6)  
            Assert.IsFalse(testShip.ApplyShot(6, 3));
            Assert.IsFalse(testShip.ApplyShot(8, 5));
            
            Assert.IsTrue(testShip.ApplyShot(7, 6));
        }
    }
}
