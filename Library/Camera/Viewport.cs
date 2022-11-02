using Library.Mapping;
using Microsoft.Xna.Framework;
using Library.Static;

namespace Library.Camera
{
    /// <summary>
    /// The viewport class defines what space is viewable to the player at a given time.
    /// </summary>
    public static class Viewport
    {
        private static Vector2 resolution = new Vector2(160, 128);
        private static MappingPos position = new MappingPos(0, 0);

        /// <summary>
        /// Check if the mapping position is inside the viewable area
        /// </summary>
        /// <param name="pos">Position to check against</param>
        /// <returns>true if position is inside view area otherwise return false</returns>
        public static bool posInViewport(MappingPos pos)
        {
            return 
                (pos.X >= position.X) &&
                (pos.Y >= position.Y) && 
                (pos.X < (position.X + resolution.X)) &&
                (pos.Y < (position.Y + resolution.Y));
        }

        /// <summary>
        /// Move the viewport along and x and y axis
        /// </summary>
        /// <param name="x">How many positions along the x</param>
        /// <param name="y">How many positions along the y</param>
        public static void Move(int x, int y)
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

        /// <summary>
        /// Get the x position
        /// </summary>
        /// <returns>An int of the x position of the viewport</returns>
        public static int GetX() { return position.X; }

        /// <summary>
        /// Get the y position
        /// </summary>
        /// <returns>An int of the y position of the viewport</returns>
        public static int GetY() { return position.Y; }

        /// <summary>
        /// Gets how much to scale up the viewable area in proprtion to the window size
        /// </summary>
        /// <returns>A vector2 where x is the width scale and y is the height scale</returns>
        public static Vector2 GetScale() { return new Vector2(Global.Window_Width / resolution.X, Global.Window_Height / resolution.Y); }
    }
}
