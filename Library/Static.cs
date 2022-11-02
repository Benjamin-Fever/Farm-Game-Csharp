using Library.Mapping;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;

namespace Library.Static
{
    public static class Global
    {
        public static TileMap Map;
        public static int Window_Width = 800;
        public static int Window_Height = 512;
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

}
