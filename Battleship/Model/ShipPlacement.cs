namespace Battleship.Model
{
    public class ShipPlacement
    {
        public ShipDirection Direction { get; }

        public Coordinates SternPoint { get; }

        /// <summary>
        /// Contains data required to place a ship.
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="sternPoint"></param>
        public ShipPlacement(ShipDirection direction, Coordinates sternPoint)
        {
            Direction = direction;
            SternPoint = sternPoint;
        }
    }
}
