using BattleshipGame.Domain.Models;

namespace BattleshipGame.Domain.Interfaces
{
    public interface IShipService
    {
        void PlaceShip(Board board, List<Ship> ships, string name, int size);
    }
}
