using Gamespace.Views;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    internal class GameOver : IView
    {

        private readonly string textOnScreen = "GAME OVER";
        private readonly Vector2 positionOnScreen = new Vector2(MarioGame.WINDOW_WIDTH / 4, MarioGame.WINDOW_HEIGHT / 2);
        public void Draw(SpriteBatch spriteBatch)
        {
            MarioGame.Instance.GraphicsDevice.Clear(Color.Black);
            spriteBatch.DrawString(MarioGame.Instance.Font, textOnScreen, positionOnScreen, Color.Black, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0.0f);

        }
    }
}
