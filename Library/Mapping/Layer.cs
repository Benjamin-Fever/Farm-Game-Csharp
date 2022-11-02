using Library.Camera;
using Library.Graphics;
using System;
using System.Collections.Generic;

namespace Library.Mapping
{
    /// <summary>
    /// Generic Abstract Layer. Takes a type of T which defines what variable type tiles is
    /// </summary>
    /// <typeparam name="T">Define type for tiles</typeparam>
    public abstract class AbstractLayer<T>
    {
        public string name;
        public int depth;
        public T tiles;
    }

    /// <summary>
    /// A tilelayer used to define what tiles are visible at this depth. Tile type is a list of Tile.
    /// Extends AbstractLayer and implements comparable and graphics component.
    /// </summary>
    public class TileLayer : AbstractLayer<List<Tile>>, IComparable<TileLayer>, IGraphicsComponent
    {
        public int CompareTo(TileLayer other)
        {
            if (other == null) { return 1; }
            if (depth == other.depth) { return 0; }
            if (depth > other.depth) { return -1; }
            return 1;
        }

        /// <summary>
        /// Draw the layer
        /// </summary>
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

        /// <summary>
        /// Get layer depth
        /// </summary>
        /// <returns>A int of the layers depth</returns>
        public int GetDepth() { return depth; }
    }
}
