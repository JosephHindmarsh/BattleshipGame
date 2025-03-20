namespace BattleshipGame.Application
{
    public static class InputParser
    {
        /// <summary>
        /// Tries to parse a coordinate string into zero-indexed row and column values.
        /// </summary>
        public static bool TryParseCoordinate(string input, out int row, out int col)
        {
            row = -1;
            col = -1;
            if (string.IsNullOrWhiteSpace(input) || input.Length < 2)
                return false;

            input = input.Trim().ToUpper();
            var letter = input[0];
            if (letter < 'A' || letter > 'J')
                return false;
            col = letter - 'A';

            var numberPart = input.Substring(1);
            if (!int.TryParse(numberPart, out int number))
                return false;
            if (number < 1 || number > 10)
                return false;
            row = number - 1;
            return true;
        }
    }
}
