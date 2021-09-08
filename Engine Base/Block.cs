namespace Engine_Base
{
    public class Block : ISquare
    {
        public Block(Position blockPosition)
        {
            Position = blockPosition;
            SquarePart = Part.Block;
        }

        public Block()
        {
        }

        public Position Position { get; set; }
        public Part SquarePart { get; set; }
        public Goal Goal { get; set; } = null;
    }
}