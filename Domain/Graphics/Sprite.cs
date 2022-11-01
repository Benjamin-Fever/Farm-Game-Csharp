using Microsoft.Xna.Framework.Graphics;
using Library.Util;

namespace Library.Graphics
{
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

        public void setTexture(Texture2D texture) { this.texture = texture; }
        public void setTexture(Texture2D texture, Box bbox)
        {
            this.texture = texture;
            this.bbox = bbox;
        }
        public void setBoundBox(float x1, float y1, float x2, float y2)
        {
            this.bbox = new Box(x1, y1, x2, y2);
        }
        public void setBoundBox(Box bbox)
        {
            this.bbox = bbox;
        }
        public void setVisible(bool visible) { this.visible = visible; }
        public bool getVisibile() { return visible; }
        public Texture2D getTexture() { return texture; }
        public Box getBoundBox() { return bbox; }

    }
}
