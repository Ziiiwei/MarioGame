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
    internal class IntroScene : IView
    {
        private Texture2D Background;
        private Texture2D FreeLunchLogo;
        public void Draw(SpriteBatch spriteBatch)
        {
            FreeLunchLogo = MarioGame.Instance.Content.Load<Texture2D>("FreeLunchLogo");
            Background = MarioGame.Instance.Content.Load<Texture2D>("TestBackground");
            MarioGame.Instance.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Draw(FreeLunchLogo, new Rectangle(0, 0, 900, 900), Color.White);
          
        }
    }
}
