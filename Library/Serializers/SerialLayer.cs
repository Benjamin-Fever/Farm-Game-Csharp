using Library.Mapping;
using System;
using System.Xml.Serialization;

namespace Library.Serializers
{
    /// <summary>
    /// Serializable Layer
    /// </summary>
    [XmlRoot("layer"), Serializable]
    public class SerialLayer : AbstractLayer<string>
    {
        [XmlAttribute("name")]
        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        [XmlAttribute("depth")]
        public int Depth
        {
            set { depth = value; }
            get { return depth; }
        }

        [XmlElement]
        public SerialTileset Tileset { get; set; }

        [XmlElement]
        public string Data
        {
            set 
            { 
                // Tidy up data input remove formats etc
                tiles = value;
                tiles = tiles.Replace("\t", "");
                tiles = tiles.Replace(" ", "");
                tiles = tiles.Substring(1,tiles.Length-2);
            }
            get { return tiles; }
        }
    }
}
