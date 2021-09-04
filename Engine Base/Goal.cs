using System;
using System.Runtime.Serialization;

namespace Engine_Base
{
    [Serializable]
    public class Goal : ISquare
    {
        public Goal(Position position)
        {
            Position = position;
            SquarePart = Part.Goal;
        }

        public Goal()
        {
        }

        public bool Completed { get; set; } = false;
        public Position Position { get; set; }
        public Part SquarePart { get; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Position", Position);
            info.AddValue("SquarePart", SquarePart);
            info.AddValue("Completed", Completed);
        }
    }
}