using System.Collections.Generic;

namespace BaseNS
{
    public class Player : ISquare
    {
        public Player(Position playerPosition)
        {
            Position = playerPosition;
            PrevPositions = new List<Position> {playerPosition};
        }

        public Player(Position playerPosition, Goal playerGoal)
        {
            Position = playerPosition;
            PrevPositions = new List<Position> {playerPosition};
            SquarePart = Part.PlayerOnGoal;
            Goal = playerGoal;
        }

        public Player()
        {
        }

        public int MoveCount { get; set; } = 0;
        public Goal Goal { get; set; } = null;
        public List<Position> PrevPositions { get; set; }
        public Position Position { get; set; }
        public Part SquarePart { get; set; } = Part.Player;
    }
}