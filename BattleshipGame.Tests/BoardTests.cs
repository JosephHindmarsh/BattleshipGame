using BattleshipGame.Domain;
using BattleshipGame.Domain.Models;
using BattleshipGame.Domain.Services;

namespace BattleshipGame.Tests
{
    public class BoardTests
    {
        [Fact]
        public void TestIsWithinBounds_ValidCoordinates()
        {
            var board = new BoardService().CreateBoard(10);
            var validCoord = new Coordinate(5, 5);
            Assert.True(board.IsWithinBounds(validCoord));
        }

        [Fact]
        public void TestIsWithinBounds_InvalidCoordinates()
        {
            var board = new BoardService().CreateBoard(10);
            var negativeCoord = new Coordinate(-1, 0);
            var tooHighRow = new Coordinate(10, 0);
            var negativeCol = new Coordinate(0, -1);
            var tooHighCol = new Coordinate(0, 10);

            Assert.False(board.IsWithinBounds(negativeCoord));
            Assert.False(board.IsWithinBounds(tooHighRow));
            Assert.False(board.IsWithinBounds(negativeCol));
            Assert.False(board.IsWithinBounds(tooHighCol));
        }
    }
}
