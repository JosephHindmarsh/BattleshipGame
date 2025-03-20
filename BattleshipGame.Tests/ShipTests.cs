using BattleshipGame.Domain.Models;

namespace BattleshipGame.Tests
{
    public class ShipTests
    {
        [Fact]
        public void TestRegisterHitAndSunk()
        {
            var ship = new Ship("TestShip", 2);
            Coordinate c1 = new Coordinate(0, 0);
            Coordinate c2 = new Coordinate(0, 1);
            ship.Coordinates.Add(c1);
            ship.Coordinates.Add(c2);

            Assert.False(ship.IsSunk);

            var hit1 = ship.RegisterHit(c1);
            Assert.True(hit1);
            Assert.False(ship.IsSunk);

            var hit2 = ship.RegisterHit(c2);
            Assert.True(hit2);
            Assert.True(ship.IsSunk);
        }
    }
}
