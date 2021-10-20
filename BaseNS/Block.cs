namespace BaseNS
{
    public class Block : ISquare
    {
        public Block(Position blockPosition)
        {
            Position = blockPosition;
        }

        public Block(Position blockPosition, Goal blockGoal)
        {
            Position = blockPosition;
            Goal = blockGoal;
            SquarePart = Part.BlockOnGoal;
        }

        public Block()
        {
        }

        public Position Position { get; set; }
        public Part SquarePart { get; set; } = Part.Block;
        public Goal Goal { get; set; } = null;
    }
}