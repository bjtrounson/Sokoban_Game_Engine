namespace Engine_Base
{
    public class Goal : ISquare
    {
        public Goal(Position position)
        {
            Position = position;
        }

        public Goal()
        {
        }

        public bool Completed { get; set; } = false;
        public Position Position { get; set; }
        public Part SquarePart { get; } = Part.Goal;
    }
}