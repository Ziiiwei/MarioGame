using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Data;

namespace Gamespace.Views
{
    internal class DeadView : IView
    {
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(MarioGame.Instance.Font, "You are out of lives!",
                new Vector2(Numbers.CENTER_X, Numbers.CENTER_Y), Color.Red);
        }
    }
}
