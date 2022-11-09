using Library.Camera;
using Library.Graphics;
using Library.Mapping;
using Library.Static;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Viewport = Library.Camera.Viewport;

namespace Library.Objects
{
    public abstract class GameObject : GraphicsComponent
    {
        public int x = 0;
        public int y = 0;
        
        public GameObject()
        {
            sprite = Sprite.Null();
        }

        public override void draw()
        {
            Draw.sprite(sprite, new Vector2(x, y));
        }

        public abstract void Update();
    }

    public class Test : GameObject
    {
        public Test()
        {
            sprite = new Sprite((Texture2D)Assets.get("assets/textures/character"));
        }
        public override void Update()
        {
            Viewport.SetPos(x / (int)Global.Map.tileSize.X, y / (int)Global.Map.tileSize.Y);
        }

        public override void draw()
        {
            if (!Viewport.posInViewport(new MappingPos(x / 16, y / 32))) { return; }
            Draw.sprite_part(sprite, 0, 0, 16, 32, x, y);
        }

        public void move(int x, int y)
        {
            base.x += x;
            base.y += y;
        }
    }
}
