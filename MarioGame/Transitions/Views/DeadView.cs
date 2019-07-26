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
    internal class DeadView : IView
    {
        private ICamera cam;

        public DeadView(ICamera cam)
        {
            this.cam = cam;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            int scale = (MarioGame.Instance.PlayerCount > 1) ? 2 : 1;
            scale = (MarioGame.Instance.PlayerCount > 2) ? 4 : 2;
            spriteBatch.DrawString(MarioGame.Instance.Font, "You are out of lives!",
                new Vector2(cam.CameraPosition.X + (MarioGame.WINDOW_WIDTH / scale), cam.CameraPosition.Y + (MarioGame.WINDOW_HEIGHT / scale)), Color.Red);
        }
    }
}
