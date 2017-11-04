using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Battleship.Model
{
    public class ShipPlacement
    {
        public Ship.ShipDirection Direction { get; }

        public Point SternPoint { get; }

        public ShipPlacement(Ship.ShipDirection direction, Point sternPoint)
        {
            Direction = direction;
            SternPoint = sternPoint;
        }
    }
}
