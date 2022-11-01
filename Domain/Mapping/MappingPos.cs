using Microsoft.Xna.Framework;
using System;
using System.Drawing;

namespace Library.Mapping
{
    public class MappingPos
    {
        public int x { get; set; }
        public int y { get; set; }

        public MappingPos()
        {
            x = 0;
            y = 0;
        }

        public MappingPos(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public MappingPos(int constant)
        {
            x = constant;
            y = constant;
        }

        public Vector2 convertToCoord(Vector2 tileSize)
        {
            return new Vector2(x * tileSize.X, y * tileSize.Y);
        }

        public MappingPos add(MappingPos p2) { return new MappingPos(x + p2.x, y + p2.y); }

        public override string ToString()
        {
            return "( " + x + ", " + y + ")";
        }
    }
}
