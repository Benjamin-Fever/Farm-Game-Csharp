using Library.Static;
using Microsoft.Xna.Framework;

namespace Library.Graphics
{
    /// <summary>
    /// Defines whats being rendered and draws it in the screen
    /// </summary>
    public class Renderer : IGraphicsComponent
    {
        private Game game;

        public Renderer(Game game)
        {
            this.game = game;
        }

        public void draw()
        {
            game.GraphicsDevice.Clear(Global.Map.background); // Clear screen
            Global.Map.draw(); // Draw map
        }
    }
}
