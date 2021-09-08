namespace Engine_Base
{
    public class Empty : ISquare
    {
        public Empty(Position emptyPosition)
        {
            Position = emptyPosition;
            SquarePart = Part.Empty;
        }

        public Empty()
        {
        }

        public Position Position { get; set; }
        public Part SquarePart { get; }
    }
}