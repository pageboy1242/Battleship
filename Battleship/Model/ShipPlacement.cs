namespace Battleship.Model
{
    public class ShipPlacement
    {
        public Ship.ShipDirection Direction { get; }

        public Coordinates SternPoint { get; }

        public ShipPlacement(Ship.ShipDirection direction, Coordinates sternPoint)
        {
            Direction = direction;
            SternPoint = sternPoint;
        }
    }
}
