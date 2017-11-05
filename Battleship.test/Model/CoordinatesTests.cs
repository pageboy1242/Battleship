using System;
using System.Collections.Generic;
using System.Text;
using Battleship.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleship.test.Model
{
    [TestClass]
    public class CoordinatesTests
    {
        [TestMethod]
        public void TestDefaultConstructor()
        {
            var coords = new Coordinates();

            Assert.AreEqual(0, coords.X);
            Assert.AreEqual(0, coords.Y);
        }

        [TestMethod]
        public void TestConstructor()
        {
            var coords = new Coordinates(4, 5);

            Assert.AreEqual(4, coords.X);
            Assert.AreEqual(5, coords.Y);
        }
    }
}
