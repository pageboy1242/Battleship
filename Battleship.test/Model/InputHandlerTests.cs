using System;
using Battleship.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleship.test.Model
{
    [TestClass]
    public class InputHandlerTests
    {
        [TestMethod]
        public void InputHandler_TestConvertInputToShipPlacement_HappyPath()
        {
            var placement = InputHandler.ConvertInputToShipPlacement("E 4 D");

            Assert.AreEqual(Ship.ShipDirection.Down, placement.Direction);
            Assert.AreEqual(5, placement.SternPoint.X);
            Assert.AreEqual(4, placement.SternPoint.Y);
        }

        [DataTestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("")]
        [DataRow("A")]
        [DataRow("A 1")]
        [DataRow("A 4 G")]
        [DataRow("asdf")]
        [DataRow("5 5 U")]
        public void InputHandler_TestConvertInputToShipPlacement_InvalidInput(string input)
        {
            var placement = InputHandler.ConvertInputToShipPlacement(input);
        }

    }
}
