using Microsoft.Xna.Framework;
using System;
using System.Drawing;

namespace Library.Mapping
{
    public class MappingPos
    {
        public int X { get; set; }
        public int Y { get; set; }

        public MappingPos()
        {
            X = 0;
            Y = 0;
        }

        public MappingPos(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public MappingPos(int constant)
        {
            X = constant;
            Y = constant;
        }

        public Vector2 convertToCoord(Vector2 tileSize)
        {
            return new Vector2(X * tileSize.X, Y * tileSize.Y);
        }

        public MappingPos add(MappingPos p2) { return new MappingPos(X + p2.X, Y + p2.Y); }

        public override string ToString()
        {
            return "( " + X + ", " + Y + ")";
        }
    }
}
