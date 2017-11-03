using System;
using Battleship.Model;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Board();
            var battleShip = new MyBattleship(3, 1, MyBattleship.ShipDirection.Left);
            board.PlaceBattleShip(battleShip);

            var isHit = board.IsHit(1, 1);
            isHit = board.IsHit(4, 2);

            Console.Write(board.ToString());
        }
    }
}
