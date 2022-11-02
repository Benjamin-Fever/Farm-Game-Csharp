using Library.Mapping;
using System.Xml.Serialization;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Library.Serializers
{
    /// <summary>
    /// Serializable map
    /// </summary>
    [XmlRoot("Map"), Serializable]
    public class SerialMap : AbstractMap<SerialLayer>
    {
        [XmlAttribute("name")]
        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        [XmlAttribute("tilewidth")]
        public int TileWidth
        {
            set { tileSize.X = value; }
            get { return (int)tileSize.X; }
        }

        [XmlAttribute("tileheight")]
        public int TileHeight
        {
            set { tileSize.Y = value; }
            get { return (int)tileSize.Y; }
        }

        [XmlAttribute("width")]
        public int Width
        {
            set { size.X = value; }
            get { return (int)size.X; }
        }

        [XmlAttribute("height")]
        public int Height
        {
            set { size.Y = value; }
            get { return (int)size.Y; }
        }
        [XmlElement]
        public SerialColor Background
        {
            get 
            { 
                SerialColor sc = new SerialColor();
                sc.red = background.R;
                sc.green = background.G;
                sc.blue = background.B;
                return sc;
            }
            set { background = new Color(value.red, value.green, value.blue); }
        }

        [XmlArray("Layers")]
        [XmlArrayItem("Layer")]
        public List<SerialLayer> Layers
        {
            get { return layers; }
            set { layers = value; }
        }
    }
}
