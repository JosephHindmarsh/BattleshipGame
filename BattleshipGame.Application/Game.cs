using BattleshipGame.Domain.Interfaces;
using BattleshipGame.Domain.Models;
using BattleshipGame.Domain.Services;

namespace BattleshipGame.Application
{
    public class Game
    {
        public Board Board { get; }
        public List<Ship> Ships { get; }
        private readonly IShipService _shipPlacementService;
        private readonly IShotService _shotService;
        private readonly IBoardService _boardService;

        public Game(IShipService shipPlacementService, IShotService shotService, IBoardService boardService)
        {
            _shipPlacementService = shipPlacementService;
            _shotService = shotService;
            _boardService = boardService;

            Board = _boardService.CreateBoard(10);
            Ships = new List<Ship>();
            
            PlaceShips();
        }

        private void PlaceShips()
        {
            _shipPlacementService.PlaceShip(Board, Ships, "Battleship", 5);
            _shipPlacementService.PlaceShip(Board, Ships, "Destroyer 1", 4);
            _shipPlacementService.PlaceShip(Board, Ships, "Destroyer 2", 4);
        }

        public string FireShot(string input)
        {
            if (!InputParser.TryParseCoordinate(input, out int row, out int col))
            {
                return "Invalid input. Please enter coordinates in format A5.";
            }

            var coord = new Coordinate(row, col);
            var result = _shotService.FireShot(Board, coord);
            return result.Message;
        }

        public bool AreAllShipsSunk()
        {
            return Ships.All(ship => ship.IsSunk);
        }
    }
}
