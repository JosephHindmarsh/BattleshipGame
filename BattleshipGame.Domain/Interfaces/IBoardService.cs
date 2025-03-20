using BattleshipGame.Domain.Models;

namespace BattleshipGame.Domain.Interfaces
{
    public interface IBoardService
    {
        Board CreateBoard(int size);
    }
}
