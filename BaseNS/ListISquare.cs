using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace BaseNS
{
    public class ListISquare : List<ISquare>, IXmlSerializable
    {
        public XmlSchema GetSchema()
        {
            return null;
        }

        public virtual void ReadXml(XmlReader reader)
        {
        }

        public void WriteXml(XmlWriter writer)
        {
            foreach (var square in this)
            {
                writer.WriteStartElement("Square");
                writer.WriteAttributeString("AssemblyQualifiedName",
                    square.GetType().AssemblyQualifiedName);
                var xmlSerializer = new XmlSerializer(square.GetType());
                xmlSerializer.Serialize(writer, square);
                writer.WriteEndElement();
            }
        }
    }
}