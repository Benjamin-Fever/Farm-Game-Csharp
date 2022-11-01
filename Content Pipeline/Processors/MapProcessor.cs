using Library.Serializers;
using Microsoft.Xna.Framework.Content.Pipeline;
using System;

namespace Content_Library.Processor
{
    [ContentProcessor(DisplayName = "Map Processor - Map.Pipeline")]
    internal class MapProcessor : ContentProcessor<SerialMap, SerialMap>
    {
        public override SerialMap Process(SerialMap input, ContentProcessorContext context)
        {
            return input;
        }
    }
}
