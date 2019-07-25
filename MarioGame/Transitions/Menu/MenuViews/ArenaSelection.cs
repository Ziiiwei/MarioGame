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
        private readonly Vector2 stringsOrigin;
        private readonly Vector2 stringDistance;

        public ArenaSelection(GameMenu menu)
        {
            this.menu = menu;
            stringsOrigin = new Vector2(MarioGame.WINDOW_WIDTH / 4, MarioGame.WINDOW_HEIGHT / 3);
            stringDistance = new Vector2(0, 60);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < MarioGame.Instance.ArenaPaths.Count; i++)
            {
                Color color = Color.Black;
                
                if (menu.ArenaSelected == i)
                {
                    color = Color.Red;
                }

                spriteBatch.DrawString(MarioGame.Instance.Font, MarioGame.Instance.ArenaPaths[i].Item1, stringsOrigin + stringDistance * i, color, 0.0f, Vector2.Zero, 2.0f, SpriteEffects.None, 0.0f);
            }
        }
    }
}
