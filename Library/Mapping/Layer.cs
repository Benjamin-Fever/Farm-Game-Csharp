using Library.Camera;
using Library.Graphics;
using System;
using System.Collections.Generic;

namespace Library.Mapping
{
    public abstract class AbstractLayer<T>
    {
        public string name;
        public int depth;
        public T tiles;
    }

    public class Layer : AbstractLayer<List<Tile>>, IComparable<Layer>, IGraphicsComponent
    {
        public int CompareTo(Layer other)
        {
            if (other == null) { return 1; }
            if (depth == other.depth) { return 0; }
            if (depth > other.depth) { return -1; }
            return 1;
        }
        
        public void draw()
        {
            foreach (Tile tile in tiles)
            {
                if (Viewport.posInViewport(tile.position))
                {
                    tile.draw();
                }
            }
        }

        public int getDepth() { return depth; }
    }
}
