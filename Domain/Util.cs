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

    public static class Assets
    {
        private static Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();
        private static Dictionary<string, TileMap> maps = new Dictionary<string, TileMap>();
        public static void load(ContentManager content)
        {
            loadTexutres(content);
        }

        public static void load(ContentManager content, string location)
        {

        }

        public static object get(string key)
        {
            key = key.Replace("/", "\\");
            if (textures.ContainsKey(key)) { return textures[key]; }
            throw new IOException("Content was not loaded for key: " + key);
        }

        private static void loadTexutres(ContentManager content)
        {
            List<string> files = new List<string>(Directory.GetFiles("content\\assets\\textures"));
            foreach (string file in files)
            {
                string location = getContentLocation(file);
                location = location.Replace("/", "\\");
                textures.Add(location, content.Load<Texture2D>(location));
            }
        }



        private static string getContentLocation(string location)
        {
            string name = location.Remove(0, "Content\\".Length);
            for (int i = name.Length; i-- > 0;)
            {
                if (name[i] == '.')
                {
                    return name.Substring(0, i);
                }
            }
            return name;
        }
    }

    public static class Global
    {
        public static TileMap Map;
        public static int Window_Width = 1600;
        public static int Window_Height = 900;
    }
}
