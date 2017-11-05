using System;
using Battleship.Model;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(new ConsoleWriter());

            game.GameStart();
        }
    }
}
