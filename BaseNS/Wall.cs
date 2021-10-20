namespace BaseNS
{
    public class Wall : ISquare
    {
        public Wall(Position wallPosition)
        {
            Position = wallPosition;
        }

        public Wall()
        {
        }

        public Position Position { get; set; }
        public Part SquarePart { get; set; } = Part.Wall;
    }
}