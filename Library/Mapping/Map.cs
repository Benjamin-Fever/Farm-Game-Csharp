using Library.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Library.Mapping
{
    public abstract class AbstractMap<T>
    {
        public string name = "";
        public Vector2 tileSize = new Vector2(0,0);
        public Vector2 size = new Vector2(0, 0);
        public Color background = new Color();
        public List<T> layers = new List<T>();

    }

    public class TileMap : AbstractMap<Layer>, IGraphicsComponent
    {
        public void draw()
        {
            
            layers.Sort();
            foreach (Layer layer in layers)
            {
                layer.draw();
            }
        }
    }
}
