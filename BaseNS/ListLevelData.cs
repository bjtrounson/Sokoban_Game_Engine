using System;
using System.Xml;
using System.Xml.Serialization;

namespace BaseNS
{
    public class ListLevelData : ListISquare
    {
        public override void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement("LevelData");
            while (reader.IsStartElement("Square"))
            {
                var type = Type.GetType(reader.GetAttribute("AssemblyQualifiedName")!);
                var serial = new XmlSerializer(type!);

                reader.ReadStartElement("Square");
                Add((ISquare) serial.Deserialize(reader));
                reader.ReadEndElement();
            }

            reader.ReadEndElement();
        }
    }
}