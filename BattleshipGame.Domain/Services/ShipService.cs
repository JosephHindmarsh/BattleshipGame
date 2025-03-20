using BattleshipGame.Domain.Interfaces;
using BattleshipGame.Domain.Models;

namespace BattleshipGame.Domain.Services
{
    public class ShipService : IShipService
    {
        private readonly Random _random;

        public ShipService()
        {
            _random = new Random();
        }

        public void PlaceShip(Board board, List<Ship> ships, string name, int size)
        {
            var placed = false;
            while (!placed)
            {
                // Randomly select orientation.
                Orientation orientation = (Orientation)_random.Next(0, 2);
                var startRow = _random.Next(0, board.Size);
                var startCol = _random.Next(0, board.Size);

                // Adjust starting coordinate if necessary so the ship fits on the board.
                if (orientation == Orientation.Horizontal && startCol + size > board.Size)
                {
                    startCol = board.Size - size;
                }
                else if (orientation == Orientation.Vertical && startRow + size > board.Size)
                {
                    startRow = board.Size - size;
                }

                var candidateCoordinates = new List<Coordinate>();
                for (int i = 0; i < size; i++)
                {
                    int row = orientation == Orientation.Horizontal ? startRow : startRow + i;
                    int col = orientation == Orientation.Horizontal ? startCol + i : startCol;
                    candidateCoordinates.Add(new Coordinate(row, col));
                }

                // Check for collision with already placed ships.
                var collision = false;
                foreach (var coord in candidateCoordinates)
                {
                    if (board.Cells[coord.Row, coord.Col].Ship != null)
                    {
                        collision = true;
                        break;
                    }
                }
                if (collision)
                    continue;

                var ship = new Ship(name, size);
                ship.Coordinates.AddRange(candidateCoordinates);
                ships.Add(ship);
                foreach (var coord in candidateCoordinates)
                {
                    board.Cells[coord.Row, coord.Col].Ship = ship;
                }
                placed = true;
            }
        }
    }
}
