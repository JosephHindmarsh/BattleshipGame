using BattleshipGame.Application;
using BattleshipGame.Domain;
using BattleshipGame.Domain.Models;
using BattleshipGame.Domain.Services;
using Xunit;

namespace BattleshipGame.Tests
{
    public class GameTests
    {
        [Fact]
        public void TestMissShot()
        {
            var game = new Game(new ShipService(), new ShotService(), new BoardService());
            var shotFired = false;

            for (int row = 0; row < game.Board.Size; row++)
            {
                for (int col = 0; col < game.Board.Size; col++)
                {
                    if (game.Board.Cells[row, col].Ship == null)
                    {
                        char letter = (char)('A' + col);
                        string input = $"{letter}{row + 1}";
                        var message = game.FireShot(input);
                        Assert.Equal("Miss.", message);
                        shotFired = true;
                        break;
                    }
                }
                if (shotFired)
                    break;
            }

            Assert.True(shotFired, "No empty cell found to test a miss shot.");
        }

        [Fact]
        public void TestHitAndSunkShip()
        {
            var game = new Game(new ShipService(), new ShotService(), new BoardService());
            game.Ships.Clear();

            for (int row = 0; row < game.Board.Size; row++)
            {
                for (int col = 0; col < game.Board.Size; col++)
                {
                    game.Board.Cells[row, col].Ship = null;
                    game.Board.Cells[row, col].IsShot = false;
                }
            }

            var testShip = new Ship("TestShip", 2);
            var c1 = new Coordinate(0, 0);
            var c2 = new Coordinate(1, 0);
            testShip.Coordinates.Add(c1);
            testShip.Coordinates.Add(c2);
            game.Ships.Add(testShip);
            game.Board.Cells[0, 0].Ship = testShip;
            game.Board.Cells[1, 0].Ship = testShip;

            var message1 = game.FireShot("A1");
            Assert.Equal("Hit!", message1);

            var message2 = game.FireShot("A2");
            Assert.Contains("sunk", message2, System.StringComparison.OrdinalIgnoreCase);
        }
    }
}