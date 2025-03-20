using BattleshipGame.Application;

namespace BattleshipGame.Tests
{
    public class InputParserTests
    {
        [Fact]
        public void TestValidCoordinate()
        {
            var result = InputParser.TryParseCoordinate("A5", out int row, out int col);
            Assert.True(result);
            Assert.Equal(4, row); // 5 - 1
            Assert.Equal(0, col); // 'A' => 0
        }

        [Fact]
        public void TestInvalidCoordinate()
        {
            var result = InputParser.TryParseCoordinate("Z1", out int row, out int col);
            Assert.False(result);
        }

        [Fact]
        public void TestCoordinateWithTwoDigits()
        {
            var result = InputParser.TryParseCoordinate("J10", out int row, out int col);
            Assert.True(result);
            Assert.Equal(9, row); // 10 - 1
            Assert.Equal(9, col); // 'J' => 9
        }
    }
}
