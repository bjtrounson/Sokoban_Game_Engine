using System;
using System.Runtime.Serialization;

namespace Engine_Base
{
    [Serializable]
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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Position", Position);
            info.AddValue("SquarePart", SquarePart);
        }
    }
}