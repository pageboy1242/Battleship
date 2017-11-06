namespace Battleship.Model
{
    /// <summary>
    /// Represents x, y Coordinates for playing the game
    /// </summary>
    public class Coordinates
    {
        public Coordinates()
        {
            X = 0;
            Y = 0;
        }

        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }
    }
}
