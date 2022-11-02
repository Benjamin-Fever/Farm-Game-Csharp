using Library.Graphics;
using Library.Mapping;
using Library.Serializers;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Library.Static;
using Microsoft.Xna.Framework;

namespace Content_Library.Reader
{
    public class MapReader : ContentTypeReader<TileMap>
    {
        protected override TileMap Read(ContentReader input, TileMap existingInstance)
        {
            TileMap map = new TileMap();
            map.name = input.ReadString();
            map.size = new Vector2(input.ReadInt32(), input.ReadInt32());
            map.tileSize = new Vector2(input.ReadInt32(), input.ReadInt32());
            map.background = new Color(input.ReadInt32(), input.ReadInt32(), input.ReadInt32());
            int count = input.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                Layer layer = new Layer();
                layer.name = input.ReadString();
                layer.depth = input.ReadInt32();
                SerialTileset ts = new SerialTileset();
                ts.Name = input.ReadString();
                ts.columns = input.ReadInt32();
                ts.source = input.ReadString();
                string tiles = input.ReadString();
                layer.tiles = getTiles(tiles, map, ts);
                map.layers.Add(layer);
            }
            return map;
        }

        private static List<Tile> getTiles(string data, TileMap m, SerialTileset ts)
        {
            Sprite sp = new Sprite((Texture2D)Assets.get(ts.source));
            List<Tile> tiles = new List<Tile>();
            List<string> cols = new List<string>(data.Split('\n'));
            int y = 0;
            int x = 0;
            foreach (string col in cols)
            {
                List<string> rows = new List<string>(col.Split(','));
                foreach (string value in rows)
                {
                    if (value == "") { continue; }
                    Tile t = new Tile(sp, new MappingPos(x, y), m.tileSize, ts.columns, Int32.Parse(value));
                    tiles.Add(t);
                    x++;
                }
                x = 0;
                y++;
            }
            return tiles;
        }
    }
}
