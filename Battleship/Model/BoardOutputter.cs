using System.Text;

namespace Battleship.Model
{
    /// <summary>
    /// Outputter class to allow for other data output formats of the game board (eg. JSON, HTML etc.)
    /// </summary>
    public class BoardOutputter
    {
        private Board _board;

        public BoardOutputter(Board board)
        {
            _board = board;
        }

        /// <summary>
        /// Convert the game grid to a console printable board
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            for (var y = 0; y < Board.BoardHeight; y++)
            {
                for (var x = 0; x < Board.BoardWidth; x++)
                {
                    sb.Append("\t");
                    if (_board.Battleship != null && _board.Battleship.IsCoordInShip(x, y))
                    {
                        sb.Append('O');
                    }
                    else
                    {
                        sb.Append(_board.Grid[x, y]);
                    }
                }
                sb.Append("\n");

            }
            return sb.ToString();
        }
    }
}
