using System.IO;
using System.Xml.Serialization;
using BaseNS;

namespace FilerNS
{
    public class Saver : ISaver
    {
        private readonly Level _level;

        public Saver(Level level)
        {
            _level = level;
        }

        public void Save(string filename, IFileable callMeBackForDetails)
        {
            filename = $"{filename}.xml";
            var xmlSerializer = new XmlSerializer(typeof(Level));
            using TextWriter tw = new StreamWriter(filename);
            xmlSerializer.Serialize(tw, _level);
        }
    }
}