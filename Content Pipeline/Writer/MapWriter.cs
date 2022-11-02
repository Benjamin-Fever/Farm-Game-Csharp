using Content_Library.Reader;
using Library.Serializers;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

namespace Content_Library.Writer
{
    /// <summary>
    /// A public class that writes the map that has been imported through the pipeline and write it
    /// into binary
    /// </summary>
    [ContentTypeWriter]
    public class MapWriter : ContentTypeWriter<SerialMap>
    {
        protected override void Write(ContentWriter output, SerialMap value)
        {
            output.Write(value.Name);
            output.Write(value.Width);
            output.Write(value.Height);
            output.Write(value.TileWidth);
            output.Write(value.TileHeight);
            output.Write(value.Background.red);
            output.Write(value.Background.green);
            output.Write(value.Background.blue);
            output.Write(value.layers.Count);
            foreach (SerialLayer layer in value.layers)
            {
                output.Write(layer.Name);
                output.Write(layer.Depth);
                output.Write(layer.Tileset.Name);
                output.Write(layer.Tileset.columns);
                output.Write(layer.Tileset.source);
                output.Write(layer.tiles);
            }
        }
        public override string GetRuntimeType(TargetPlatform targetPlatform) { return typeof(SerialMap).AssemblyQualifiedName; }
        public override string GetRuntimeReader(TargetPlatform targetPlatform) { return typeof(MapReader).AssemblyQualifiedName; }
    }
}
