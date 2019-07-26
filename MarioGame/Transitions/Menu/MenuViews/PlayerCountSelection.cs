using Gamespace.Data;
using Gamespace.Sprites;
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
    internal class PlayerCountSelection : IView
    {
        private readonly GameMenu menu;
        private readonly Vector2 stringsOrigin;
        private readonly Vector2 stringDistance;

        public PlayerCountSelection(GameMenu menu)
        {
            this.menu = menu;
            stringsOrigin = new Vector2(MarioGame.WINDOW_WIDTH / 4, MarioGame.WINDOW_HEIGHT / 3);
            stringDistance = new Vector2(0, 60);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D Logo = MarioGame.Instance.Content.Load<Texture2D>("deathmatchlogo");
            spriteBatch.Draw(Logo, new Rectangle(250, -150, 1000, 900), Color.White);

            for (int i = 1; i <= Numbers.MAX_PLAYERS; i++)
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
