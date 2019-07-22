using Gamespace.Transitions;
using Gamespace.Views;
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
            for (int i = 0; i < playerCount; i++)
            {
                Color color = Color.Black;

                if (menu.PlayerCount == i)
                {
                    color = Color.Red;
                }

                spriteBatch.DrawString(MarioGame.Instance.Font, i.ToString() + "-player", stringsOrigin + stringDistance * i, color, 0.0f, Vector2.Zero, 2.0f, SpriteEffects.None, 0.0f);
            }
        }
    }
}
