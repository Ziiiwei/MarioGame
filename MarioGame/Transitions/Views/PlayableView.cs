using Gamespace.Multiplayer;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Views
{
    internal class PlayableView : IView
    {
        private Scoreboard scoreboard;
        private ICamera cam;

        public PlayableView(Scoreboard scoreboard, ICamera cam)
        {
            this.scoreboard = scoreboard;
            this.cam = cam;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(MarioGame.Instance.Font,
                "Score: " + scoreboard.Score + " Coins: " + scoreboard.Coins + " Lives: " + scoreboard.Lives + " Time: " + scoreboard.Time,
                cam.CameraPosition, Color.Black);
            World.Instance.DrawWorld(spriteBatch);
        }
    }
}
