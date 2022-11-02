using Library.Serializers;
using Microsoft.Xna.Framework.Content.Pipeline;
using System;

namespace Content_Library.Processor
{
    /// <summary>
    /// Internal class that passes the map importeted into the content pipeline 
    /// </summary>
    [ContentProcessor(DisplayName = "Map Processor - Map.Pipeline")]
    internal class MapProcessor : ContentProcessor<SerialMap, SerialMap>
    {
        public override SerialMap Process(SerialMap input, ContentProcessorContext context)
        {
            return input;
        }
    }
}
