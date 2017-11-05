using System;
using System.Collections.Generic;
using System.Text;
using Battleship.Interfaces;
using Battleship.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Battleship.test.Model
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void Game_TestWelcomeMessage()
        {
            var mockConsole = new Mock<IConsoleWriter>();
            var game = new Game(mockConsole.Object);

            game.WelcomeMessage();

            mockConsole.Verify(c=>  c.Clear());
            mockConsole.Verify(c => c.WriteLine("Welcome to Battleship\n"));
        }
    }
}
