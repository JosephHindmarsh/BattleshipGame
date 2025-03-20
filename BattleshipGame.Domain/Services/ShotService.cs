using BattleshipGame.Domain.Interfaces;
using BattleshipGame.Domain.Models;

namespace BattleshipGame.Domain.Services
{
    public class ShotService : IShotService
    {
        public ShotResult FireShot(Board board, Coordinate coord)
        {
            if (!board.IsWithinBounds(coord))
            {
                return new ShotResult(false, "Coordinates are out of bounds.");
            }

            var cell = board.Cells[coord.Row, coord.Col];

            if (cell.IsShot)
            {
                return new ShotResult(false, "You've already fired at this location.");
            }

            cell.IsShot = true;

            if (cell.Ship != null)
            {
                var ship = cell.Ship;
                ship.RegisterHit(coord);
                if (ship.IsSunk)
                {
                    return new ShotResult(true, $"Hit! You sunk the {ship.Name}!");
                }
                else
                {
                    return new ShotResult(true, "Hit!");
                }
            }
            else
            {
                return new ShotResult(false, "Miss.");
            }
        }
    }
}
