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
    internal class LivesView : IView
    {
        private int lives;
        
        public LivesView(int lives)
        {
            this.lives = lives;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // TODO: change the font to something more specific?
            spriteBatch.DrawString(MarioGame.Instance.Font, "Lives " + lives.ToString(), 
                new Vector2(Numbers.CENTER_X, Numbers.CENTER_Y), Color.Red);
        }
    }
}
