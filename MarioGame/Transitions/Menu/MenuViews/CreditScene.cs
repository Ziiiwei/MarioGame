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
    internal class CreditScene : IView
    {
        private Texture2D IntroCreditTitle;
        public void Draw(SpriteBatch spriteBatch)
        {
            IntroCreditTitle = MarioGame.Instance.Content.Load<Texture2D>("IntroCreditTitle");
            MarioGame.Instance.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Draw(IntroCreditTitle, new Rectangle(0, 0, 1100, 1000), Color.White);
        }
    }
}
