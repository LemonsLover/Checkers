namespace Game.Logic
{
    public class Checker
    {
        public CheckerType Type { get; set; }

        public Position Position { get; set; }

        public bool IsKing { get; set; } = false;

        public Checker(CheckerType type, Position position)
        {
            Type = type;
            Position = position;
        }
    }
}
