using Library.Mapping;
using Library.Objects;
using Library.Static;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Library.Graphics
{
    /// <summary>
    /// Defines whats being rendered and draws it in the screen
    /// </summary>
    public class Renderer : IGraphicsComponent
    {
        private Game game;
        public Test t;

        public Renderer(Game game)
        {
            this.game = game;
        }

        public void draw()
        {
            game.GraphicsDevice.Clear(Global.Map.background); // Clear screen
            Global.Map.draw();
            t.draw();
        }
    }
}
