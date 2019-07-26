using Gamespace.Views;
using Gamespace.Transitions;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Gamespace
{
    internal class CharacterSelection : IView
    {

        GameMenu menu;
        Vector2 stringsOrigin;
        Dictionary<PlayerIndex, Vector2> characterOrigins;
        Vector2 stringDistance;

        public CharacterSelection(GameMenu menu)
        {
            this.menu = menu;
            stringsOrigin = new Vector2(0, 0);
            stringDistance = new Vector2(0, 50);
            characterOrigins = new Dictionary<PlayerIndex, Vector2>()
            {
                {PlayerIndex.One, new Vector2(MarioGame.WINDOW_WIDTH / 6, MarioGame.WINDOW_HEIGHT / 6) },
                {PlayerIndex.Two, new Vector2((3 * MarioGame.WINDOW_WIDTH) / 6, MarioGame.WINDOW_HEIGHT / 6) },
                {PlayerIndex.Three, new Vector2(MarioGame.WINDOW_WIDTH / 6, (3 * MarioGame.WINDOW_HEIGHT) / 6) },
                {PlayerIndex.Four, new Vector2((3 * MarioGame.WINDOW_WIDTH) / 6, (3 * MarioGame.WINDOW_HEIGHT) / 6) }
            };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(MarioGame.Instance.Font, "Select Your Character", stringsOrigin, Color.Black, 0.0f, Vector2.Zero, 2.0f, SpriteEffects.None, 0.0f);

            for (PlayerIndex i = PlayerIndex.One; i <= PlayerIndex.Four; i++)
            {
                spriteBatch.DrawString(MarioGame.Instance.Font, "Player " + i.ToString(), characterOrigins[i] - (stringDistance), Color.Gray);

                for (int j = 0; j < menu.PlayableCharacters.Count ; j++)
                {

                    Color color = Color.Black;
                    if (menu.PlayableCharacters[j] == menu.playerCharacterSelection[i])
                    {
                        color = Color.Red;
                    }

                    spriteBatch.DrawString(MarioGame.Instance.Font, menu.PlayableCharacters[j].Name.ToString(), characterOrigins[i] + (stringDistance * j), color);
                }
            }
        }
    }
}
