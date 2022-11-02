using Microsoft.Xna.Framework.Graphics;

namespace Library.Graphics
{
    /// <summary>
    /// Generic graphics component interface
    /// </summary>
    public interface IGraphicsComponent
    {
        public void draw();
    }

    /// <summary>
    /// Generic graphics component abstract class
    /// </summary>
    public abstract class GraphicsComponent : IGraphicsComponent
    {
        protected static SpriteBatch spriteBatch;
        protected Sprite sprite;

        /// <summary>
        /// Draw the graphics component
        /// </summary>
        public abstract void draw();

        /// <summary>
        /// Set the spritebatch used by all graphics components
        /// </summary>
        /// <param name="sb"><code>SpriteBatch</code></param>
        public static void setSpriteBatch(SpriteBatch sb) { spriteBatch = sb; }
    }
}
