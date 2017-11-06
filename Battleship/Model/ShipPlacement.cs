namespace Battleship.Model
{
    public class ShipPlacement
    {
        public ShipDirection Direction { get; }

        public Coordinates SternPoint { get; }

        public ShipPlacement(ShipDirection direction, Coordinates sternPoint)
        {
            Direction = direction;
            SternPoint = sternPoint;
        }
    }
}
