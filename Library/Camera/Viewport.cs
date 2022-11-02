using Library.Mapping;
using Library.Util;
using Microsoft.Xna.Framework;
using System;
using System.Data;
using Library.Static;

namespace Library.Camera
{
    public static class Viewport
    {
        private static Vector2 resolution = new Vector2(160, 128);
        public static MappingPos position = new MappingPos(0, 0);

        public static bool posInViewport(MappingPos pos)
        {
            return 
                (pos.X >= position.X) &&
                (pos.Y >= position.Y) && 
                (pos.X < (position.X + resolution.X)) &&
                (pos.Y < (position.Y + resolution.Y));
        }

        public static void move(int x, int y)
        {
            position.X += x; 
            position.Y += y;

            position.X = position.X > 0 ? position.X : 0;
            position.Y = position.Y > 0 ? position.Y : 0;

            int width  = (int)(resolution.X / Global.Map.tileSize.X);
            int height = (int)(resolution.Y / Global.Map.tileSize.Y);

            position.X = (int)(position.X + width  > Global.Map.size.X ? Global.Map.size.X - width  : position.X);
            position.Y = (int)(position.Y + height > Global.Map.size.Y ? Global.Map.size.Y - height : position.Y);
        }

        public static int getX() { return position.X; }
        public static int getY() { return position.Y; }
        public static Vector2 getScale() { return new Vector2(Global.Window_Width / resolution.X, Global.Window_Height / resolution.Y); }
    }
}
