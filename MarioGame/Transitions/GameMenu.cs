using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Transitions
{
    internal class GameMenu
    {
        private DiscreteTimer timer;

        public GameMenu()
        {
            timer = new DiscreteTimer(360, new Action(() => MarioGame.Instance.OnMenuSelectionsComplete()));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(MarioGame.Instance.Font, "WOOOOO", new Vector2(500, 500), Color.Red);
            timer.Tick();
        }
    }
}
