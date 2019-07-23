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
        private Texture2D FreeLunch;
        public void Draw(SpriteBatch spriteBatch)
        {
            FreeLunch = MarioGame.Instance.Content.Load<Texture2D>("TestBackground");
            spriteBatch.Draw(FreeLunch, new Rectangle(0, 0, 800, 480), Color.Black);
        }
    }
}
