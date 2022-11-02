using Microsoft.Xna.Framework;

namespace Library.Mapping
{
    /// <summary>
    /// MappingPos defines a position on the map
    /// </summary>
    public class MappingPos
    {
        /// <summary>
        /// X position
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y position
        /// </summary>
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

        /// <summary>
        /// Convert the mapping position to coordinates
        /// </summary>
        /// <param name="tileSize">The size of each tile</param>
        /// <returns>A vector2 of the coordinate positon of the tile</returns>
        public Vector2 ConvertToCoord(Vector2 tileSize)
        {
            return new Vector2(X * tileSize.X, Y * tileSize.Y);
        }

        /// <summary>
        /// Add a MappingPos to another
        /// </summary>
        /// <param name="p2">MappingPosition to add</param>
        /// <returns>A new MappingPos with the same of the two positions</returns>
        public MappingPos Add(MappingPos p2) { return new MappingPos(X + p2.X, Y + p2.Y); }

        public override string ToString()
        {
            return "( " + X + ", " + Y + ")";
        }
    }
}
