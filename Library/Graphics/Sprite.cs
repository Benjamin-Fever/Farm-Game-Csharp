using Microsoft.Xna.Framework.Graphics;
using Library.Util;

namespace Library.Graphics
{
    /// <summary>
    /// Sprite class defines a sprites texure and hitbox
    /// </summary>
    public class Sprite
    {
        private Texture2D texture;
        private Box bbox;
        private bool visible;

        public Sprite(Texture2D texture)
        {
            this.texture = texture;
            bbox = new Box(0, 0, texture.Width, texture.Height);
        }
        public Sprite(Texture2D texture, bool visible)
        {
            this.texture = texture;
            this.visible = visible;
            bbox = new Box(0, 0, texture.Width, texture.Height);
        }
        public Sprite(Texture2D texture, Box bbox)
        {
            this.texture = texture;
            this.bbox = bbox;
        }
        public Sprite(Texture2D texture, Box bbox, bool visible)
        {
            this.texture = texture;
            this.bbox = bbox;
            this.visible = visible;
        }

        /// <summary>
        /// Set the sprites image
        /// </summary>
        /// <param name="texture">Sprite Image</param>
        public void SetTexture(Texture2D texture) { this.texture = texture; }

        /// <summary>
        /// Set the bounding box of the sprite
        /// </summary>
        /// <param name="x1">Left   Position</param>
        /// <param name="y1">Top    Position</param>
        /// <param name="x2">Right  Position</param>
        /// <param name="y2">Bottom Position</param>
        public void SetBoundBox(float x1, float y1, float x2, float y2)
        {
            this.bbox = new Box(x1, y1, x2, y2);
        }

        /// <summary>
        /// Set the bounding box of the sprite
        /// </summary>
        /// <param name="bbox">New Bounding Box</param>
        public void SetBoundBox(Box bbox)
        {
            this.bbox = bbox;
        }

        /// <summary>
        /// Set sprite visibility
        /// </summary>
        /// <param name="visible"></param>
        public void SetVisible(bool visible) { this.visible = visible; }

        /// <summary>
        /// Get sprite visibility
        /// </summary>
        /// <returns>True if sprite is visible, otherwise False</returns>
        public bool GetVisibile() { return visible; }

        /// <summary>
        /// Get sprite texture
        /// </summary>
        /// <returns>The sprites texture</returns>
        public Texture2D GetTexture() { return texture; }

        /// <summary>
        /// Get the bounding box of the sprite
        /// </summary>
        /// <returns>A box of the sprites bounding box</returns>
        public Box GetBoundBox() { return bbox; }

    }
}
