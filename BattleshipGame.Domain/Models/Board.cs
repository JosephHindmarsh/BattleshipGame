using System.Drawing;

namespace BattleshipGame.Domain.Models
{
    public class Board(int size)
    {
        public int Size { get; } = size;
        public Cell[,] Cells { get; set; }

        public bool IsWithinBounds(Coordinate coord)
        {
            return coord.Row >= 0 && coord.Row < Size && coord.Col >= 0 && coord.Col < Size;
        }
    }
}
