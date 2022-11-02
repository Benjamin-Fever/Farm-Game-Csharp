using Library.Graphics;
using Library.Mapping;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Library.Static;
using System;
using Viewport = Library.Camera.Viewport;

namespace Application
{
    public class App : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public App()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your init code here
            base.Window.Title = "Video Game";
            _graphics.PreferredBackBufferWidth = Global.Window_Width;
            _graphics.PreferredBackBufferHeight = Global.Window_Height;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            GraphicsComponent.setSpriteBatch(_spriteBatch);
            Assets.load(Content);
            Global.Map = Content.Load<TileMap>("assets/maps/map1");
            Console.WriteLine(Assets.get("assets\\textures\\overworld"));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.W)) { Viewport.move(0, -1); }
            if (Keyboard.GetState().IsKeyDown(Keys.S)) { Viewport.move(0, 1); }
            if (Keyboard.GetState().IsKeyDown(Keys.A)) { Viewport.move(-1, 0); }
            if (Keyboard.GetState().IsKeyDown(Keys.D)) { Viewport.move(1, 0); ; }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Global.Map.background);

            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, null);
            Global.Map.draw();
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}