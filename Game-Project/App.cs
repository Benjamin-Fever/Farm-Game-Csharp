using Library.Graphics;
using Library.Mapping;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Library.Static;

namespace Application
{
    /**
     * <summary>App extends on the monogame class Game to setup and run the game</summary>
     */
    public class App : Game
    {
        /// Initilize Varaibles
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
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
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            GraphicsComponent.setSpriteBatch(_spriteBatch);
            Assets.load(Content);  // Load all game assets
            Global.Map = Content.Load<TileMap>("assets/maps/map1");  // Load map
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();
            base.Update(gameTime);
        }

        /// <summary>
        /// The draw method used to display whats on the game window
        /// </summary>
        /// <param name="gameTime">Time passed between frames</param>
        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, null);
            _renderer.draw();
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}