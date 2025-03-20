using BattleshipGame.Domain.Interfaces;
using BattleshipGame.Domain.Models;

namespace BattleshipGame.Domain.Services
{
    public class BoardService : IBoardService
    {
        public Board CreateBoard(int size)
        {
            var board = new Board(size);

            // Initialize each cell in the board using nested loops.
            // This explicit approach is chosen for clarity over a LINQ statement.
            board.Cells = new Cell[size, size];
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    board.Cells[row, col] = new Cell();
                }
            }
            return board;
        }
    }
}
