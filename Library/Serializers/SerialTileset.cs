using System.Xml.Serialization;

namespace Library.Serializers
{
    /// <summary>
    /// Serializable Tileset
    /// </summary>
    public class SerialTileset
    {
        [XmlAttribute("name")] 
        public string Name { get; set; }

        [XmlAttribute("source")]
        public string source { get; set; }

        [XmlAttribute("columns")]
        public int columns { get; set; }
    }
}
