using BattleshipGame.Domain.Models;

namespace BattleshipGame.Domain.Interfaces
{
    public interface IShotService
    {
        ShotResult FireShot(Board board, Coordinate coord);
    }
}
