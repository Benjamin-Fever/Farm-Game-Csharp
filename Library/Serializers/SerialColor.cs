using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Library.Serializers
{
    /// <summary>
    /// Serializable Color
    /// </summary>
    [Serializable]
    public class SerialColor
    {
        [XmlAttribute("red")] public int red { get; set; }
        [XmlAttribute("green")] public int green { get; set; }
        [XmlAttribute("blue")] public int blue { get; set; }
    }
}
