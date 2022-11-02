using Library.Mapping;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Viewport = Library.Camera.Viewport;

namespace Library.Graphics
{
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
            Texture2D texture = sprite.getTexture();
            int rectLeft = (int)((tileNum % columns == 0 ? columns-1 : (tileNum % columns) - 1) * tileSize.X);
            int rectTop = (int)(MathF.Ceiling(tileNum / 40) * tileSize.Y);
            Rectangle sourceRect = new Rectangle(rectLeft, rectTop, (int)tileSize.X, (int)tileSize.Y);
            MappingPos drawPos = new MappingPos(position.X - Viewport.getX(), position.Y - Viewport.getY());
            drawPos.X *= (int)Viewport.getScale().X;
            drawPos.Y *= (int)Viewport.getScale().Y;
            spriteBatch.Draw(texture, drawPos.convertToCoord(tileSize), sourceRect, Color.White, 0f, Vector2.Zero, Viewport.getScale(), SpriteEffects.None, 0f);
        }
    }
}
