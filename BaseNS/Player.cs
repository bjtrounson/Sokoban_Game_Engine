using System.Collections.Generic;

namespace BaseNS
{
    public class Player : ISquare
    {
        public Player(Position playerPosition)
        {
            Position = playerPosition;
            PrevPositions = new List<Position> {playerPosition};
            SquarePart = Part.Player;
        }

        public Player()
        {
        }

        public int MoveCount { get; set; } = 0;
        public Goal Goal { get; set; } = null;
        public List<Position> PrevPositions { get; }
        public Position Position { get; set; }
        public Part SquarePart { get; set; }
    }
}