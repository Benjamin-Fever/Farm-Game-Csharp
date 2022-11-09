using Library.Graphics;
using Library.Mapping;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Library.Static;
using Library.Camera;
using Viewport = Library.Camera.Viewport;
using Library.Objects;

namespace Application
{
    /**
     * <summary>App extends on the monogame class Game to setup and run the game</summary>
     */
    public class App : Game
    {
        /// Initilize Varaibles
        private GraphicsDeviceManager _graphics;
        private Renderer _renderer;

        public App()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// Initilize game window
        /// </summary>
        protected override void Initialize()
        {
            Window.Title = "Video Game";
            _renderer = new Renderer(this);
            _graphics.PreferredBackBufferWidth = Global.Window_Width;
            _graphics.PreferredBackBufferHeight = Global.Window_Height;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        /// <summary>
        /// Load game content compiled using the monogame content pipeline
        /// </summary>
        protected override void LoadContent()
        {
            Global.Sprite_Batch = new SpriteBatch(GraphicsDevice);
            Assets.load(Content);  // Load all game assets
            Global.Map = Content.Load<TileMap>("assets/maps/map1");  // Load map
            _renderer.t = new Test();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.W)) _renderer.t.move(0, -1);
            if (Keyboard.GetState().IsKeyDown(Keys.S)) _renderer.t.move(0, 1);
            if (Keyboard.GetState().IsKeyDown(Keys.A)) _renderer.t.move(-1, 0);
            if (Keyboard.GetState().IsKeyDown(Keys.D)) _renderer.t.move(1, 0);
            _renderer.t.Update();
            base.Update(gameTime);
        }

        /// <summary>
        /// The draw method used to display whats on the game window
        /// </summary>
        /// <param name="gameTime">Time passed between frames</param>
        protected override void Draw(GameTime gameTime)
        {
            Global.Sprite_Batch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, null);
            _renderer.draw();
            Global.Sprite_Batch.End();
            base.Draw(gameTime);
        }
    }
}