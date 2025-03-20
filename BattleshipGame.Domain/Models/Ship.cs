namespace BattleshipGame.Domain.Models
{
    public class Ship
    {
        public string Name { get; }
        public int Size { get; }
        public List<Coordinate> Coordinates { get; }
        public HashSet<Coordinate> Hits { get; }

        public Ship(string name, int size)
        {
            Name = name;
            Size = size;
            Coordinates = new List<Coordinate>();
            Hits = new HashSet<Coordinate>();
        }

        public bool IsSunk => Hits.Count >= Size;

        public bool RegisterHit(Coordinate coordinate)
        {
            if (Coordinates.Contains(coordinate))
            {
                Hits.Add(coordinate);
                return true;
            }
            return false;
        }
    }
}
