using Battleship.Model;

namespace Battleship
{
    class Program
    {
        static void Main()
        {
            Game game = new Game(new ConsoleWriter());

            game.GameStart();
        }
    }
}
