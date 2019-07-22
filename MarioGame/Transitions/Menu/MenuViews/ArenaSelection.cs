using Gamespace.Transitions;
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
    internal class ArenaSelection : IView
    {
        GameMenu menu;

        public ArenaSelection(GameMenu menu)
        {
            this.menu = menu;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(MarioGame.Instance.Font, "COOOL", new Vector2(400, 400), Color.Red);
        }
    }
}
