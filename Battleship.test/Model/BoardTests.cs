﻿using System;
using System.Drawing;
using Battleship.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleship.test.Model
{
    [TestClass]
    public class BoardTests
    {
        private Board _board;

        public BoardTests()
        {
            _board = new Board();
        }

        [DataTestMethod]
        [DataRow(1, 1, Ship.ShipDirection.Up, false)]
        [DataRow(8, 8, Ship.ShipDirection.Down, false)]
        [DataRow(5, 2, Ship.ShipDirection.Up, false)]
        [DataRow(5, 7, Ship.ShipDirection.Down, false)]
        [DataRow(2, 1, Ship.ShipDirection.Left, false)]
        [DataRow(7, 8, Ship.ShipDirection.Right, false)]
        public void Board_TestPlaceBattleShip_InvalidLocation(int x, int y, Ship.ShipDirection shipDirection,
            bool result)
        {
            var placement = new ShipPlacement(shipDirection, new Point(x, y));
            Assert.AreEqual(result, _board.PlaceBattleShip(new Ship(3, "My Battleship"), placement));
        }

        [DataTestMethod]
        [DataRow(1, 1, Ship.ShipDirection.Down, true)]
        [DataRow(1, 1, Ship.ShipDirection.Right, true)]
        [DataRow(8, 8, Ship.ShipDirection.Up, true)]
        [DataRow(8, 8, Ship.ShipDirection.Left, true)]
        [DataRow(1, 8, Ship.ShipDirection.Up, true)]
        [DataRow(5, 7, Ship.ShipDirection.Left, true)]
        [DataRow(8, 1, Ship.ShipDirection.Left, true)]
        [DataRow(7, 5, Ship.ShipDirection.Down, true)]
        public void Board_TestPlaceBattleShip_ValidLocation(int x, int y, Ship.ShipDirection shipDirection,
            bool result)
        {
            var placement = new ShipPlacement(shipDirection, new Point(x, y));
            var battleShip = new Ship(3, "My Battleship");

            Assert.AreEqual(result, _board.PlaceBattleShip(battleShip, placement));
            Assert.AreSame(battleShip, _board.Battleship);
        }

        [DataTestMethod]
        [DataRow(3, 4, true)]
        [DataRow(5, 3, false)]
        [DataRow(3, 5, true)]
        public void Board_TestIsHitRegistersValidHitsAndMisses(int x, int y, bool result)
        {
            var placement = new ShipPlacement(Ship.ShipDirection.Down, new Point(3, 3));
            var battleShip = new Ship(3, "My Battleship");
            _board.PlaceBattleShip(battleShip, placement);

            Assert.AreEqual(result, _board.IsHit(x, y));
        }

        [DataTestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(-1, 1, Ship.ShipDirection.Up)]
        [DataRow(9, 1, Ship.ShipDirection.Up)]
        [DataRow(1, -1, Ship.ShipDirection.Up)]
        [DataRow(1, 9, Ship.ShipDirection.Up)]
        public void Board_Placement_XYCoordRange_Validation(int x, int y, Ship.ShipDirection shipDirection)
        {
            var battleShip = new Ship(3, "My Battleship");
            _board.PlaceBattleShip(battleShip, new ShipPlacement(shipDirection, new Point(x, y)));

            Assert.Fail("Should not reach this point, an argumentOutOfRange exception should be thrown");
        }
    }
}