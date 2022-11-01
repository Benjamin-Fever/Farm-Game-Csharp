using Library.Mapping;
using Library.Util;
using Microsoft.Xna.Framework;
using System;
using System.Data;

namespace Library.Camera
{
    public static class Viewport
    {
        private const int width = 5;
        private const int height = 5;
        private const int scale = 2;
        public static MappingPos position = new MappingPos(0, 0);

        public static bool posInViewport(MappingPos pos)
        {
            return 
                (pos.x >= position.x) &&
                (pos.y >= position.y) && 
                (pos.x < (position.x + width)) &&
                (pos.y < (position.y + height));
        }

        public static void move(int x, int y)
        {
            position.x += x; 
            position.y += y;

            position.x = position.x > 0 ? position.x : 0;
            position.y = position.y > 0 ? position.y : 0;

            position.x = position.x + width > Global.Map.size.X ? (int)Global.Map.size.X - width : position.x;
            position.y = position.y + height > Global.Map.size.Y ? (int)Global.Map.size.Y - height : position.y;
        }

        public static int getX() { return position.x; }
        public static int getY() { return position.y; }
        public static int getScale() { return scale; }
        public static Vector2 getVectorScale() { return new Vector2(getScale()); }
    }
}
