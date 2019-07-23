using Gamespace.Views;
using Gamespace.Transitions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    internal class ContinueScreen : IView
    {
        private readonly string textOnScreen = "Press any key to continue";
        private readonly Vector2 positionOnScreen = new Vector2(MarioGame.WINDOW_WIDTH / 4, MarioGame.WINDOW_HEIGHT / 2);
      
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(MarioGame.Instance.Font, textOnScreen, positionOnScreen, Color.Black, 0.0f, Vector2.Zero, 2.0f, SpriteEffects.None, 0.0f);
        }
    }
}
