namespace BattleshipGame.Domain.Models
{
    public class ShotResult
    {
        public bool IsHit { get; }
        public string Message { get; }

        public ShotResult(bool isHit, string message)
        {
            IsHit = isHit;
            Message = message;
        }
    }
}
