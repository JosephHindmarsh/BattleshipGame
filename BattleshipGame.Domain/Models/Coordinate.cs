namespace BattleshipGame.Domain.Models
{
    public readonly struct Coordinate
    {
        public int Row { get; }
        public int Col { get; }

        public Coordinate(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Coordinate other)
            {
                return Row == other.Row && Col == other.Col;
            }
            return false;
        }

        public override int GetHashCode() => HashCode.Combine(Row, Col);

        public override string ToString() => $"({Row},{Col})";
    }
}
