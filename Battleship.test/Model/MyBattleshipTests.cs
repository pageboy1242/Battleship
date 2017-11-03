using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Battleship.Model;

namespace Battleship.test.Model
{
    [TestClass]
    public class MyBattleshipTests
    {
        [DataTestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(-1, 1, MyBattleship.ShipDirection.Up)]
        [DataRow(9, 1, MyBattleship.ShipDirection.Up)]
        [DataRow(1, -1, MyBattleship.ShipDirection.Up)]
        [DataRow(1, 9, MyBattleship.ShipDirection.Up)]
        public void Battleship_ConstructorTest_XYCoordRange_Validation(int x, int y, MyBattleship.ShipDirection shipDirection)
        {
            var battleShip = new MyBattleship(x, y, shipDirection);

            Assert.Fail("Should not reach this point, an argumentOutOfRange exception should be thrown");
        }
        
        [DataTestMethod]
        [DataRow(3, 1, MyBattleship.ShipDirection.Left, 1, 1, true)]
        [DataRow(3, 1, MyBattleship.ShipDirection.Left, 3, 1, true)]
        [DataRow(3, 1, MyBattleship.ShipDirection.Left, 2, 1, true)]
        [DataRow(3, 1, MyBattleship.ShipDirection.Left, 4, 1, false)]
        [DataRow(3, 1, MyBattleship.ShipDirection.Left, 1, 2, false)]
        [DataRow(3, 1, MyBattleship.ShipDirection.Left, 3, 2, false)]
        public void Battleship_IsCoordInShip(int x, int y, MyBattleship.ShipDirection direction, int i, int j, bool result)
        {
            var battleShip = new MyBattleship(x, y, direction);

            Assert.AreEqual(result, battleShip.IsCoordInShip(i, j));
        } 
    }
}
