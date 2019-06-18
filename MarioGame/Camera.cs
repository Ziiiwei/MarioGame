using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Gamespace.Sprites;

namespace Gamespace
{
    internal class Camera
    {
        public Matrix Transform { get; private set; }

        public Camera(Point location)
        {
            Transform = Matrix.CreateTranslation(new Vector3(location.X, location.Y, 0));
        }
        
        public void Follow(Sprite target)
        {
            Matrix position = Matrix.CreateTranslation(
                -target.Position.X - (target.Rectangle.Width / 2),
                -target.Position.Y - (target.Rectangle.Height / 2),
                0);
            Matrix offset = Matrix.CreateTranslation(
                    MarioGame.ScreenWidth / 2,
                    MarioGame.ScreenHeight / 2,
                    0);
            Transform = position * offset;
        }



    }
}
