using Library.Mapping;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Viewport = Library.Camera.Viewport;

namespace Library.Graphics
{
    /// <summary>
    /// A graphics component that represents a map tile
    /// </summary>
    public class Tile : GraphicsComponent
    {
        public Vector2 tileSize;
        public MappingPos position;
        public int tileNum;
        public int columns;

        public Tile(Sprite sprite, MappingPos position, Vector2 tileSize, int columns, int tileNum)
        {
            base.sprite = sprite;
            this.position = position;
            this.tileSize = tileSize;
            this.columns = columns;
            this.tileNum = tileNum;
        }

        public override void draw()
        {
            Texture2D texture = sprite.GetTexture();
            int rectLeft = (int)((tileNum % columns == 0 ? columns-1 : (tileNum % columns) - 1) * tileSize.X);
            int rectTop = (int)(MathF.Ceiling(tileNum / 40) * tileSize.Y);
            Rectangle sourceRect = new Rectangle(rectLeft, rectTop, (int)tileSize.X, (int)tileSize.Y);
            MappingPos drawPos = new MappingPos(position.X - Viewport.GetX(), position.Y - Viewport.GetY());
            drawPos.X *= (int)Viewport.GetScale().X;
            drawPos.Y *= (int)Viewport.GetScale().Y;
            spriteBatch.Draw(texture, drawPos.ConvertToCoord(tileSize), sourceRect, Color.White, 0f, Vector2.Zero, Viewport.GetScale(), SpriteEffects.None, 0f);
        }
    }
}
