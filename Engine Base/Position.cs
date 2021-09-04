using System;
using System.Runtime.Serialization;

namespace Engine_Base
{
    [Serializable]
    public struct Position : ISerializable
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("X", X);
            info.AddValue("Y", Y);
        }
    }
}