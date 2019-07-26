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
        private Texture2D Logo;
      
        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D Logo = MarioGame.Instance.Content.Load<Texture2D>("deathmatchlogo");
            spriteBatch.Draw(Logo, new Rectangle(250, -150, 1000, 900), Color.White);
            spriteBatch.DrawString(MarioGame.Instance.Font, textOnScreen, positionOnScreen, Color.Black, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0.0f);
        }
    }
}
