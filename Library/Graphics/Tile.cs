using Library.Mapping;
using Library.Graphics;
using Library.Static;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Viewport = Library.Camera.Viewport;
using Library.Objects;

namespace Library.Graphics
{
    /// <summary>
    /// A graphics component that represents a map tile
    /// </summary>
    public class Tile : GameObject
    {
        public Vector2 tileSize;
        public MappingPos position;
        public int tileNum;
        public int columns;

        public Tile(Sprite sprite, MappingPos position, Vector2 tileSize, int columns, int tileNum, int depth)
        {
            base.sprite = sprite;
            this.position = position;
            this.tileSize = tileSize;
            this.columns = columns;
            this.tileNum = tileNum;
            this.depth = depth;
        }

        public override void draw()
        {
            int left = (int)((tileNum % columns == 0 ? columns-1 : (tileNum % columns) - 1) * tileSize.X);
            int top = (int)(MathF.Ceiling(tileNum / 40) * tileSize.Y);
            MappingPos drawPos = new MappingPos(position.X - Viewport.GetX(), position.Y - Viewport.GetY());
            drawPos.X *= (int)Viewport.GetScale().X;
            drawPos.Y *= (int)Viewport.GetScale().Y;
            Draw.sprite_part(sprite, left, top, (int)tileSize.X, (int)tileSize.Y, (int)drawPos.ConvertToCoord(tileSize).X, (int)drawPos.ConvertToCoord(tileSize).Y, depth);
        }

        public override void Update() { return; }
    }
}
