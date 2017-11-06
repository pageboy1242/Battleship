using Battleship.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleship.test.Model
{
    [TestClass]
    public class InputHandlerTests
    {
        [DataTestMethod]
        [DataRow("E 4 D", 5, 4, ShipDirection.Down)]
        [DataRow("E 4 U", 5, 4, ShipDirection.Up)]
        [DataRow("E 4 L", 5, 4, ShipDirection.Left)]
        [DataRow("E 4 R", 5, 4, ShipDirection.Right)]
        public void InputHandler_TestConvertInputToShipPlacement_HappyPath(string input, int x, int y, ShipDirection expectedShipDirection)
        {
            var placement = InputHandler.ConvertInputToShipPlacement(input, out var message);

            Assert.IsTrue(message.Length == 0);
            Assert.AreEqual(expectedShipDirection, placement.Direction);
            Assert.AreEqual(x, placement.SternPoint.X);
            Assert.AreEqual(y, placement.SternPoint.Y);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow("A")]
        [DataRow("A 1")]
        [DataRow("A 4 G")]
        [DataRow("asdf")]
        [DataRow("5 5 U")]
        public void InputHandler_TestConvertInputToShipPlacement_InvalidInput(string input)
        {
            var placement = InputHandler.ConvertInputToShipPlacement(input, out var message);

            Assert.IsNull(placement);
            Assert.AreEqual("Please enter coordinates using the following rules [A-H] [1-8] [U,D,L,R] (Eg. 'B 2 R').",
                message);
        }

        [TestMethod]
        public void InputHandler_TestConvertInputToCoordinates_HappyPath()
        {
            var coords = InputHandler.ConvertInputToCoordinates("E 4", out var message);

            Assert.IsTrue(message.Length == 0);
            
            Assert.AreEqual(5, coords.X);
            Assert.AreEqual(4, coords.Y);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow("A")]
        [DataRow("A ")]
        [DataRow("A 4 G")]
        [DataRow("asdf")]
        [DataRow("5 5 U")]
        public void InputHandler_TestConvertInputToCoordinates_InvalidInput(string input)
        {
            var placement = InputHandler.ConvertInputToShipPlacement(input, out var message);

            Assert.IsNull(placement);
            Assert.AreEqual("Please enter coordinates using the following rules [A-H] [1-8] [U,D,L,R] (Eg. 'B 2 R').",
                message);
        }

    }
}
