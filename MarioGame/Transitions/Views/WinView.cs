using Gamespace.Multiplayer;
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
    internal class WinView : IView
    {
        private readonly Vector2 stringsOrigin;
        private readonly Vector2 stringDistance;
        private Dictionary<IPlayer, int> scores;
        private int winner;

        public WinView(Dictionary<IPlayer, int> scores)
        {
            this.scores = scores;
            stringsOrigin = new Vector2(MarioGame.WINDOW_WIDTH / 4, MarioGame.WINDOW_HEIGHT / 3);
            stringDistance = new Vector2(0, 60);
            /*
            winner = scores.Keys.;

            foreach (IPlayer player in scores.Keys)
            {
                if (scores[player.PlayerID] > scores[winner])
                {

                }
            }
            */
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(MarioGame.Instance.Font, "Scores:", new Vector2(0, 0), Color.Black, 0.0f, Vector2.Zero, 2.0f, SpriteEffects.None, 0.0f);

            foreach (IPlayer play in scores.Keys)
            {
                spriteBatch.DrawString(MarioGame.Instance.Font, "Player: " + (play.PlayerID + 1).ToString() + ": " + scores[play].ToString(), stringsOrigin + stringDistance * play.PlayerID, Color.Black, 0.0f, Vector2.Zero, 2.0f, SpriteEffects.None, 0.0f);
            }
        }
    }
}
