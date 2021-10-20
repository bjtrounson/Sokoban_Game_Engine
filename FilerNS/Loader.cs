using System.IO;
using System.Linq;
using System.Xml.Serialization;
using BaseNS;

namespace FilerNS
{
    public class Loader : ILoader
    {
        public Level Level { get; private set; }

        public string Load(string fileName)
        {
            // XML Serializer
            fileName = $"{fileName}.xml";
            var deserializer = new XmlSerializer(typeof(Level));
            TextReader reader = new StreamReader(fileName);
            var level = deserializer.Deserialize(reader);
            Level = (Level) level;

            // Turns Level into string for return
            return Level.LevelData.Select(square => (int) square.SquarePart).Aggregate("", (current, squarePart) => current + squarePart);
        }
    }
}