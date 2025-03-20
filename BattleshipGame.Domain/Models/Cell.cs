namespace BattleshipGame.Domain.Models
{
    public class Cell
    {
        public bool IsShot { get; set; }
        public Ship? Ship { get; set; }
    }
}
