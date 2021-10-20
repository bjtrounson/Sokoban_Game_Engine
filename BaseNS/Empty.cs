namespace BaseNS
{
    public class Empty : ISquare
    {
        public Empty(Position emptyPosition)
        {
            Position = emptyPosition;
        }

        public Empty()
        {
        }

        public Position Position { get; set; }
        public Part SquarePart { get; set; } = Part.Empty;
    }
}