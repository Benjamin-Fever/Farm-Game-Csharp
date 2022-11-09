using Library.Static;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Viewport = Library.Camera.Viewport;

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
        protected Sprite sprite;
        public int depth;

        /// <summary>
        /// Draw the graphics component
        /// </summary>
        public abstract void draw();
    }

    public static class Draw 
    {
        public static void sprite(Sprite sp, int x, int y)
        {
            Global.Sprite_Batch.Draw(sp.GetTexture(), new Vector2(x, y), Color.White);
        }

        public static void sprite(Sprite sp, int x, int y, int depth)
        {
            Global.Sprite_Batch.Draw(sp.GetTexture(), new Vector2(x, y), new Rectangle(0, 0, sp.GetTexture().Width, sp.GetTexture().Height),Color.White, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, depth/100);
        }

        public static void sprite(Sprite sp, Vector2 pos)
        {
            sprite(sp, (int)pos.X, (int)pos.Y);
        }

        public static void sprite(Sprite sp, Vector2 pos, int depth)
        {
            sprite(sp, (int)pos.X, (int)pos.Y, depth);
        }

        public static void sprite_part(Sprite sp, int left, int top, int width, int height, int x, int y)
        {
            Texture2D texture = sp.GetTexture();
            Vector2 position = new Vector2(x, y);
            Rectangle soruceRect = new Rectangle(left, top, width, height);
            Global.Sprite_Batch.Draw(texture, position, soruceRect, Color.White, 0f, Vector2.Zero, Viewport.GetScale(), SpriteEffects.None, 0f);

        }

        public static void sprite_part(Sprite sp, int left, int top, int width, int height, int x, int y, int depth)
        {
            Texture2D texture = sp.GetTexture();
            Vector2 position = new Vector2(x, y);
            Rectangle soruceRect = new Rectangle(left, top, width, height);
            Global.Sprite_Batch.Draw(texture, position, soruceRect, Color.White, 0f, Vector2.Zero, Viewport.GetScale(), SpriteEffects.None, depth/100);

        }
    }
}
