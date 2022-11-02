using Library.Mapping;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Library.Util
{
    public class Box
    {
        public float x1;
        public float x2;
        public float y1;
        public float y2;

        public Box(float x1, float y1, float x2, float y2)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.y2 = y2;
        }

        public Box(Vector2 topLeft, Vector2 bottomRight)
        {
            this.x1 = topLeft.X;
            this.x2 = bottomRight.X;
            this.y1 = topLeft.Y;
            this.y2 = bottomRight.Y;
        }

        public override string ToString()
        {
            return "Square:\n    Top Left:\n        X: " + x1 + "\n        Y: " + y1 + "\n    Bottom Right:\n        X: " + x1 + "\n        Y: " + y1;
        }

        public Rectangle convertXnaRect()
        {
            return new Rectangle((int)x1, (int)y1, (int)(x2 - x1), (int)(y2 - y1));
        }
    }
}
