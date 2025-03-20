using BattleshipGame.Domain.Models;

namespace BattleshipGame.Tests
{
    public class CoordinateTests
    {
        [Fact]
        public void TestCoordinateEquality()
        {
            var c1 = new Coordinate(0, 0);
            var c2 = new Coordinate(0, 0);
            var c3 = new Coordinate(1, 0);

            Assert.Equal(c1, c2);
            Assert.NotEqual(c1, c3);
        }

        [Fact]
        public void TestCoordinateToString()
        {
            var c = new Coordinate(2, 3);
            Assert.Equal("(2,3)", c.ToString());
        }
    }
}
