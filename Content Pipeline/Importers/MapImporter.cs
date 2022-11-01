using Library.Serializers;
using Microsoft.Xna.Framework.Content.Pipeline;
using System;
using System.IO;
using System.Xml.Serialization;

namespace Content_Library.Importer
{
    [ContentImporter(".map", DisplayName = "Map Importer - Map.Pipeline", DefaultProcessor = "MapProcessor")]
    internal class MapImporter : ContentImporter<SerialMap>
    {
        public override SerialMap Import(string filename, ContentImporterContext context)
        {
            using (var streamReader = new StreamReader(filename))
            {
                var deserializer = new XmlSerializer(typeof(SerialMap));
                SerialMap m = (SerialMap)deserializer.Deserialize(streamReader);
                return m;
            }
        }
    }
}
