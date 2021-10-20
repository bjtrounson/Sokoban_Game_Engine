namespace BaseNS
{
    public class Goal : ISquare
    {
        public Goal(Position goalPosition)
        {
            Position = goalPosition;
        }

        public Goal(Position goalPosition, bool completed)
        {
            Position = goalPosition;
            Completed = completed;
        }

        public Goal()
        {
        }

        public bool Completed { get; set; } = false;
        public Position Position { get; set; }
        public Part SquarePart { get; set; } = Part.Goal;
    }
}