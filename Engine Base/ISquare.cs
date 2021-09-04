using System.Runtime.Serialization;

namespace Engine_Base
{
    public interface ISquare : ISerializable
    {
        public Position Position { get; set; }
        public Part SquarePart { get; }
    }
}