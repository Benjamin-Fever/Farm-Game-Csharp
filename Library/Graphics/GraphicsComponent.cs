using Microsoft.Xna.Framework.Graphics;

namespace Library.Graphics
{
    public interface IGraphicsComponent
    {
        public void draw();
    }

    public abstract class GraphicsComponent : IGraphicsComponent
    {
        protected static SpriteBatch spriteBatch;
        protected Sprite sprite;
        public abstract void draw();
        public static void setSpriteBatch(SpriteBatch sb) { spriteBatch = sb; }
    }
}
