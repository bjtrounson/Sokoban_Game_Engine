using System;
using System.Runtime.Serialization;

namespace Engine_Base
{
    [Serializable]
    public class Block : ISquare
    {
        public Block(Position blockPosition)
        {
            Position = blockPosition;
            SquarePart = Part.Block;
        }

        public Block()
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