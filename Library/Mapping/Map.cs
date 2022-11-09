using Library.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Library.Mapping
{
    /// <summary>
    /// Generic Abstract Layer. Takes a type of T which defines what variable type layers is
    /// </summary>
    /// <typeparam name="T">Define type for layers</typeparam>
    public abstract class AbstractMap<T>
    {
        public string name = "";
        public Vector2 tileSize = new Vector2(0,0);
        public Vector2 size = new Vector2(0, 0);
        public Color background = new Color();
        public List<T> layers = new List<T>();

    }

    /// <summary>
    /// A tilemap used to define what layers are in the map. Layer type is a TileLayer.
    /// Implements IGraphicsComponent.
    /// </summary>
    public class TileMap : AbstractMap<TileLayer>, IGraphicsComponent
    {
        /// <summary>
        /// Draw the map
        /// </summary>
        public void draw()
        {
            foreach (TileLayer layer in layers)
            {
                layer.draw();
            }
        }
    }
}
