using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Engine_Base
{
    [Serializable]
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
        public List<Position> PrevPositions { get; set; }
        public Position Position { get; set; }
        public Part SquarePart { get; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Position", Position);
            info.AddValue("SquarePart", SquarePart);
            info.AddValue("MoveCount", MoveCount);
            info.AddValue("PrevPositions", PrevPositions);
        }
    }
}