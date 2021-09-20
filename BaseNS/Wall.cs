namespace BaseNS
{
    public class Wall : ISquare
    {
        public Wall(Position position)
        {
            Position = position;
            SquarePart = Part.Wall;
        }

        public Wall()
        {
        }

        public Position Position { get; set; }
        public Part SquarePart { get; }
    }
}