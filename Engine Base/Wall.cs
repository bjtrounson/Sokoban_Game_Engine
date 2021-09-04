using System;
using System.Runtime.Serialization;

namespace Engine_Base
{
    [Serializable]
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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Position", Position);
            info.AddValue("SquarePart", SquarePart);
        }
    }
}