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

        public WinView(Dictionary<IPlayer, int> scores)
        {
            this.scores = scores;
            stringsOrigin = new Vector2(MarioGame.WINDOW_WIDTH / 4, MarioGame.WINDOW_HEIGHT / 3);
            stringDistance = new Vector2(0, 60);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IPlayer play in scores.Keys)
            {
                spriteBatch.DrawString(MarioGame.Instance.Font, "Player: " + (play.PlayerID + 1).ToString() + ": " + scores[play].ToString(), stringsOrigin + stringDistance * play.PlayerID, Color.Black, 0.0f, Vector2.Zero, 2.0f, SpriteEffects.None, 0.0f);
            }
        }
    }
}
